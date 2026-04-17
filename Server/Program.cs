using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        private static TcpListener _listener;
        private static CancellationTokenSource _cts = new CancellationTokenSource();
        private static ConcurrentDictionary<string, TcpClient> _clients = new ConcurrentDictionary<string, TcpClient>();

        static async Task Main(string[] args)
        {
            Console.WriteLine("=== LAN CHAT SERVER ===");
            int port = 8888;
            Console.Write("Nhập Port để khởi động Server (Mặc định 8888): ");
            string portStr = Console.ReadLine();
            if (int.TryParse(portStr, out int p)) port = p;

            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start();
            Console.WriteLine($"[+] Server đang lắng nghe trên cổng {port}...");

            try
            {
                while (!_cts.IsCancellationRequested)
                {
                    TcpClient client = await _listener.AcceptTcpClientAsync(_cts.Token);
                    Console.WriteLine($"[+] Có client mới kết nối từ {client.Client.RemoteEndPoint}");
                    _ = Task.Run(() => HandleClientAsync(client, _cts.Token));
                }
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                Console.WriteLine($"[-] Lỗi: {ex.Message}");
            }
        }

        private static async Task HandleClientAsync(TcpClient client, CancellationToken token)
        {
            string username = "";
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };

            try
            {
                while (!token.IsCancellationRequested)
                {
                    string line = await reader.ReadLineAsync(token);
                    if (string.IsNullOrEmpty(line)) break;

                    ChatMessage msg = null;
                    try { msg = JsonSerializer.Deserialize<ChatMessage>(line); } catch { continue; }
                    if (msg == null) continue;

                    if (msg.Type == "JOIN")
                    {
                        username = msg.From;
                        _clients.AddOrUpdate(username, client, (k, v) => client);
                        Console.WriteLine($"[JOIN] {username} đã vào phòng.");
                        
                        await BroadcastAsync(msg);
                        await BroadcastUserListAsync();
                    }
                    else if (msg.Type == "PUBLIC")
                    {
                        Console.WriteLine($"[PUBLIC] {msg.From}: {msg.Content}");
                        await BroadcastAsync(msg);
                    }
                    else if (msg.Type == "PRIVATE")
                    {
                        Console.WriteLine($"[PRIVATE] {msg.From} -> {msg.To}: {msg.Content}");
                        await SendToUserAsync(msg.To, msg);
                    }
                    else if (msg.Type == "LEAVE")
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[-] Lỗi client {username}: {ex.Message}");
            }
            finally
            {
                if (!string.IsNullOrEmpty(username))
                {
                    _clients.TryRemove(username, out _);
                    Console.WriteLine($"[LEAVE] {username} đã ngắt kết nối.");

                    await BroadcastAsync(new ChatMessage { Type = "LEAVE", From = username, Time = DateTime.Now });
                    await BroadcastUserListAsync();
                }
                try { client.Close(); } catch { }
            }
        }

        private static async Task BroadcastAsync(ChatMessage msg)
        {
            string json = JsonSerializer.Serialize(msg);
            var tasks = new List<Task>();
            foreach (var c in _clients.Values.Where(v => v.Connected))
            {
                StreamWriter writer = new StreamWriter(c.GetStream()) { AutoFlush = true };
                tasks.Add(writer.WriteLineAsync(json));
            }
            await Task.WhenAll(tasks);
        }

        private static async Task BroadcastUserListAsync()
        {
            var msg = new ChatMessage
            {
                Type = "USER_LIST",
                From = "SERVER",
                Time = DateTime.Now,
                Users = _clients.Keys.ToList()
            };
            await BroadcastAsync(msg);
        }

        private static async Task SendToUserAsync(string toUsername, ChatMessage msg)
        {
            if (_clients.TryGetValue(toUsername, out TcpClient client) && client.Connected)
            {
                string json = JsonSerializer.Serialize(msg);
                StreamWriter writer = new StreamWriter(client.GetStream()) { AutoFlush = true };
                await writer.WriteLineAsync(json);
            }
        }
    }
}
