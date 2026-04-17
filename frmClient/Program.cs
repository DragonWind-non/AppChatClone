using System;
using System.Windows.Forms;

namespace frmClient
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            string ip = "127.0.0.1";
            int port = 8888;
            string user = "UnknownUser";

            if (args.Length >= 3)
            {
                ip = args[0];
                int.TryParse(args[1], out port);
                user = args[2];
            }

            TcpClientService service = new TcpClientService();
            if (service.Connect(ip, port, user))
            {
                Application.Run(new Form1(service));
            }
            else
            {
                MessageBox.Show($"Không thể kết nối tới Server {ip}:{port} bằng tài khoản {user}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}