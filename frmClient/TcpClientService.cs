using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace frmClient
{
    public class TcpClientService
    {
        private TcpClient _client;
        private StreamReader _reader;
        private StreamWriter _writer;
        private CancellationTokenSource _cts;

        public string Username { get; private set; }

        public event Action<ChatMessage> OnMessageReceived;
        public event Action<string> OnDisconnected;

        public bool Connect(string ip, int port, string username)
        {
            try
            {
                _client = new TcpClient();
                _client.Connect(ip, port);
                
                var stream = _client.GetStream();
                _reader = new StreamReader(stream);
                _writer = new StreamWriter(stream) { AutoFlush = true };
                
                this.Username = username;

                // Gửi thông điệp JOIN
                var joinMsg = new ChatMessage
                {
                    Type = "JOIN",
                    From = username,
                    Time = DateTime.Now
                };
                SendMessage(joinMsg);

                _cts = new CancellationTokenSource();
                Task.Run(() => ReceiveLoopAsync(_cts.Token));
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Disconnect()
        {
            if (_client != null && _client.Connected)
            {
                try 
                { 
                    SendMessage(new ChatMessage { Type = "LEAVE", From = Username, Time = DateTime.Now }); 
                } 
                catch {}
            }
            _cts?.Cancel();
            _client?.Close();
        }

        public void SendMessage(ChatMessage msg)
        {
            if (_writer != null)
            {
                string json = JsonSerializer.Serialize(msg);
                _writer.WriteLine(json);
            }
        }

        private async Task ReceiveLoopAsync(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    string line = await _reader.ReadLineAsync(token);
                    if (string.IsNullOrEmpty(line)) break;

                    try
                    {
                        var msg = JsonSerializer.Deserialize<ChatMessage>(line);
                        if (msg != null)
                        {
                            OnMessageReceived?.Invoke(msg);
                        }
                    }
                    catch { }
                }
            }
            catch (Exception) { }
            finally
            {
                OnDisconnected?.Invoke("Mất kết nối với Server.");
            }
        }
    }
}
