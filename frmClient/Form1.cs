using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace frmClient
{
    public partial class Form1 : Form
    {
        private TcpClientService _client;
        private Dictionary<string, PrivateChatForm> _privateForms = new Dictionary<string, PrivateChatForm>();

        // Constructor mặc định (Do designer dùng)
        public Form1()
        {
            InitializeComponent();
        }

        // Constructor thực tế nhận vào connection
        public Form1(TcpClientService client) : this()
        {
            _client = client;
            _client.OnMessageReceived += Client_OnMessageReceived;
            _client.OnDisconnected += Client_OnDisconnected;

            txtWelcomeUser.Text = _client.Username;
            lblLocalIp.Text = "IP: 127.0.0.1";
            lblConnectionStatus.Text = "Trạng thái : Đã kết nối";
            this.Text = $"Ứng dụng Chat nội bộ LAN - {_client.Username}";
            
            rtbChatLog.ReadOnly = true;
            lvwOnlineUsers.FullRowSelect = true;
        }

        private void Client_OnMessageReceived(ChatMessage msg)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => Client_OnMessageReceived(msg)));
                return;
            }

            switch (msg.Type)
            {
                case "PUBLIC":
                    AppendLog($"[{msg.Time:HH:mm}] {msg.From}: {msg.Content}", Color.Black);
                    break;
                case "JOIN":
                    AppendLog($"[{msg.Time:HH:mm}] Hệ thống: {msg.From} đã vào mạng", Color.Green);
                    break;
                case "LEAVE":
                    AppendLog($"[{msg.Time:HH:mm}] Hệ thống: {msg.From} đã rời mạng", Color.Red);
                    break;
                case "USER_LIST":
                    UpdateUsers(msg.Users);
                    break;
                case "PRIVATE":
                    OpenPrivateChat(msg.From);
                    if (_privateForms.TryGetValue(msg.From, out var chatForm))
                    {
                        chatForm.ReceiveMessage(msg);
                    }
                    break;
            }
        }

        private void Client_OnDisconnected(string reason)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => Client_OnDisconnected(reason)));
                return;
            }
            lblConnectionStatus.Text = "Trạng thái : " + reason;
            lblConnectionStatus.ForeColor = Color.Red;
            MessageBox.Show(reason, "Hệ thống");
            Application.Exit();
        }

        private void AppendLog(string message, Color color)
        {
            rtbChatLog.SelectionStart = rtbChatLog.TextLength;
            rtbChatLog.SelectionLength = 0;
            rtbChatLog.SelectionColor = color;
            rtbChatLog.AppendText(message + "\r\n");
            rtbChatLog.SelectionColor = rtbChatLog.ForeColor;
            rtbChatLog.ScrollToCaret();
        }

        private void UpdateUsers(List<string> users)
        {
            lvwOnlineUsers.Items.Clear();
            foreach (var u in users)
            {
                if (u == _client.Username) continue;
                var item = new ListViewItem(u, 0); 
                item.Tag = u;
                lvwOnlineUsers.Items.Add(item);
            }
            lblOnlineCount.Text = "Online : " + (users.Count);
        }

        private void OpenPrivateChat(string targetUser)
        {
            if (!_privateForms.ContainsKey(targetUser) || _privateForms[targetUser].IsDisposed)
            {
                var form = new PrivateChatForm(_client, targetUser);
                form.Show();
                _privateForms[targetUser] = form;
            }
            else
            {
                _privateForms[targetUser].BringToFront();
            }
        }

        // GUI EVENTS ================================

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessageInput.Text)) return;
            
            var msg = new ChatMessage
            {
                Type = "PUBLIC",
                From = _client.Username,
                Content = txtMessageInput.Text,
                Time = DateTime.Now
            };

            _client.SendMessage(msg);
            txtMessageInput.Text = "";
            txtMessageInput.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter key cho txtMessageInput
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnSend_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // btnDisconnect
            _client?.Disconnect();
            Application.Exit();
        }

        private void lvwOnlineUsers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2)
            {
                var hit = lvwOnlineUsers.HitTest(e.Location);
                if (hit.Item != null)
                {
                    string targetUser = hit.Item.Tag.ToString();
                    OpenPrivateChat(targetUser);
                }
            }
        }

        private void gửiTinNhắnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwOnlineUsers.SelectedItems.Count > 0)
            {
                string targetUser = lvwOnlineUsers.SelectedItems[0].Tag.ToString();
                OpenPrivateChat(targetUser);
            }
        }

        private void xemIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwOnlineUsers.SelectedItems.Count > 0)
            {
                string targetUser = lvwOnlineUsers.SelectedItems[0].Tag.ToString();
                MessageBox.Show($"IP của {targetUser} là đang được Server ẩn (Theo chuẩn LAN Chat).", "Thông tin IP");
            }
        }

        // Bỏ trống các sự kiện không liên quan
        private void Form1_Load(object sender, EventArgs e) { }
        private void cmsUserOptions_Opening(object sender, System.ComponentModel.CancelEventArgs e) { }
        private void rtbChatLog_TextChanged(object sender, EventArgs e) { }
        private void pnlSidebar_Paint(object sender, PaintEventArgs e) { }
        private void pnlStatusBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void lblLocalIp_Click(object sender, EventArgs e) { }
        private void lblOnlineCount_Click(object sender, EventArgs e) { }
        private void lblConnectionStatus_Click(object sender, EventArgs e) { }
        private void txtMessageInput_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void panelchat_Paint(object sender, PaintEventArgs e) { }
        private void nameapp_Click(object sender, EventArgs e) { }
    }
}
