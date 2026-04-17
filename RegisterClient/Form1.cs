using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace RegisterClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ip = txtServerIP.Text;
            string port = txtPort.Text;
            string username = txtUsername.Text;

            if (string.IsNullOrWhiteSpace(ip) || string.IsNullOrWhiteSpace(port) || string.IsNullOrWhiteSpace(username))
            {
                lblStatus.Text = "Trạng Thái: Vui lòng nhập đủ thông tin!";
                return;
            }

            lblStatus.Text = "Trạng Thái: Đang kết nối...";

            try
            {
                string mainClientProj = Path.GetFullPath(Path.Combine(Application.StartupPath, "..", "..", "..", "..", "frmClient", "MainClient.csproj"));
                
                var psi = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = $"run --project \"{mainClientProj}\" \"{ip}\" \"{port}\" \"{username}\"",
                    UseShellExecute = true
                };

                Process.Start(psi);

                Application.Exit();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Trạng Thái: Lỗi - " + ex.Message;
            }
        }

        private void btnOUT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e) { }
        private void txtServerIP_TextChanged(object sender, EventArgs e) { }
        private void txtPort_TextChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void lblStatus_Click(object sender, EventArgs e) { }
    }
}
