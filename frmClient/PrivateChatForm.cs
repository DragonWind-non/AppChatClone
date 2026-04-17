using System;
using System.Drawing;
using System.Windows.Forms;

namespace frmClient
{
    public partial class PrivateChatForm : Form
    {
        private TcpClientService _client;
        public string TargetUser { get; private set; }

        public PrivateChatForm(TcpClientService client, string targetUser)
        {
            InitializeComponent();
            _client = client;
            TargetUser = targetUser;
            this.Text = $"Chat Riêng - {targetUser}";
        }

        public void ReceiveMessage(ChatMessage msg)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => ReceiveMessage(msg)));
                return;
            }
            AppendLog($"[{msg.Time:HH:mm:ss}] {msg.From}: {msg.Content}", Color.Blue);
        }

        private void AppendLog(string message, Color color)
        {
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionLength = 0;
            rtbChat.SelectionColor = color;
            rtbChat.AppendText(message + "\r\n");
            rtbChat.SelectionColor = rtbChat.ForeColor;
            rtbChat.ScrollToCaret();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMsg.Text)) return;

            var msg = new ChatMessage
            {
                Type = "PRIVATE",
                From = _client.Username,
                To = TargetUser,
                Content = txtMsg.Text,
                Time = DateTime.Now
            };

            _client.SendMessage(msg);
            
            // Tự hiện lên phía mình
            AppendLog($"[{msg.Time:HH:mm:ss}] Bạn: {msg.Content}", Color.Black);
            
            txtMsg.Text = "";
            txtMsg.Focus();
        }

        private void txtMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                btnSend_Click(sender, e);
            }
        }
    }
}
