namespace frmClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnSend = new Button();
            nameapp = new Label();
            label2 = new Label();
            pnlMainChat = new Panel();
            rtbChatLog = new RichTextBox();
            pnlSidebar = new Panel();
            lvwOnlineUsers = new ListView();
            User = new ColumnHeader();
            cmsUserOptions = new ContextMenuStrip(components);
            gửiTinNhắnToolStripMenuItem = new ToolStripMenuItem();
            xemIPToolStripMenuItem = new ToolStripMenuItem();
            imgStatusList = new ImageList(components);
            lblhello = new Label();
            txtWelcomeUser = new TextBox();
            pnlStatusBar = new StatusStrip();
            lblLocalIp = new ToolStripStatusLabel();
            lblOnlineCount = new ToolStripStatusLabel();
            lblConnectionStatus = new ToolStripStatusLabel();
            pnlInputArea = new Panel();
            txtMessageInput = new TextBox();
            btnDisconnect = new Button();
            pnlMainChat.SuspendLayout();
            pnlSidebar.SuspendLayout();
            cmsUserOptions.SuspendLayout();
            pnlStatusBar.SuspendLayout();
            pnlInputArea.SuspendLayout();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(128, 255, 255);
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Location = new Point(1081, 740);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(106, 49);
            btnSend.TabIndex = 7;
            btnSend.Text = "Gửi";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // nameapp
            // 
            nameapp.AutoSize = true;
            nameapp.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            nameapp.Location = new Point(15, 9);
            nameapp.Name = "nameapp";
            nameapp.Size = new Size(268, 28);
            nameapp.TabIndex = 11;
            nameapp.Text = "Ứng Dụng Chat Nội Bộ Lan";
            nameapp.Click += nameapp_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(381, 701);
            label2.Name = "label2";
            label2.Size = new Size(160, 23);
            label2.TabIndex = 13;
            label2.Text = "Nội dung tin nhắn :";
            label2.Click += label2_Click;
            // 
            // pnlMainChat
            // 
            pnlMainChat.BackColor = SystemColors.ButtonHighlight;
            pnlMainChat.Controls.Add(rtbChatLog);
            pnlMainChat.Location = new Point(381, 90);
            pnlMainChat.Name = "pnlMainChat";
            pnlMainChat.Size = new Size(1208, 613);
            pnlMainChat.TabIndex = 14;
            pnlMainChat.Paint += panelchat_Paint;
            // 
            // rtbChatLog
            // 
            rtbChatLog.BackColor = SystemColors.ButtonHighlight;
            rtbChatLog.Dock = DockStyle.Fill;
            rtbChatLog.Location = new Point(0, 0);
            rtbChatLog.Name = "rtbChatLog";
            rtbChatLog.ReadOnly = true;
            rtbChatLog.Size = new Size(1208, 613);
            rtbChatLog.TabIndex = 0;
            rtbChatLog.Text = "";
            rtbChatLog.TextChanged += rtbChatLog_TextChanged;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = SystemColors.ButtonHighlight;
            pnlSidebar.Controls.Add(lvwOnlineUsers);
            pnlSidebar.Controls.Add(lblhello);
            pnlSidebar.Controls.Add(txtWelcomeUser);
            pnlSidebar.Controls.Add(pnlStatusBar);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(288, 834);
            pnlSidebar.TabIndex = 15;
            pnlSidebar.Paint += pnlSidebar_Paint;
            // 
            // lvwOnlineUsers
            // 
            lvwOnlineUsers.Columns.AddRange(new ColumnHeader[] { User });
            lvwOnlineUsers.ContextMenuStrip = cmsUserOptions;
            lvwOnlineUsers.FullRowSelect = true;
            lvwOnlineUsers.Location = new Point(15, 87);
            lvwOnlineUsers.MultiSelect = false;
            lvwOnlineUsers.Name = "lvwOnlineUsers";
            lvwOnlineUsers.Size = new Size(255, 702);
            lvwOnlineUsers.SmallImageList = imgStatusList;
            lvwOnlineUsers.TabIndex = 17;
            lvwOnlineUsers.UseCompatibleStateImageBehavior = false;
            lvwOnlineUsers.View = View.SmallIcon;
            lvwOnlineUsers.SelectedIndexChanged += gửiTinNhắnToolStripMenuItem_Click;
            lvwOnlineUsers.MouseClick += lvwOnlineUsers_MouseDown;
            lvwOnlineUsers.MouseDown += lvwOnlineUsers_MouseDown;
            // 
            // User
            // 
            User.Text = "";
            User.Width = 255;
            // 
            // cmsUserOptions
            // 
            cmsUserOptions.ImageScalingSize = new Size(20, 20);
            cmsUserOptions.Items.AddRange(new ToolStripItem[] { gửiTinNhắnToolStripMenuItem, xemIPToolStripMenuItem });
            cmsUserOptions.Name = "cmsUserOptions";
            cmsUserOptions.Size = new Size(159, 52);
            cmsUserOptions.Opening += cmsUserOptions_Opening;
            // 
            // gửiTinNhắnToolStripMenuItem
            // 
            gửiTinNhắnToolStripMenuItem.Name = "gửiTinNhắnToolStripMenuItem";
            gửiTinNhắnToolStripMenuItem.Size = new Size(158, 24);
            gửiTinNhắnToolStripMenuItem.Text = "Gửi tin nhắn";
            gửiTinNhắnToolStripMenuItem.Click += gửiTinNhắnToolStripMenuItem_Click;
            // 
            // xemIPToolStripMenuItem
            // 
            xemIPToolStripMenuItem.Name = "xemIPToolStripMenuItem";
            xemIPToolStripMenuItem.Size = new Size(158, 24);
            xemIPToolStripMenuItem.Text = "Xem IP";
            xemIPToolStripMenuItem.Click += xemIPToolStripMenuItem_Click;
            // 
            // imgStatusList
            // 
            imgStatusList.ColorDepth = ColorDepth.Depth32Bit;
            imgStatusList.ImageStream = (ImageListStreamer)resources.GetObject("imgStatusList.ImageStream");
            imgStatusList.TransparentColor = Color.Transparent;
            imgStatusList.Images.SetKeyName(0, "1f7e2.png");
            imgStatusList.Images.SetKeyName(1, "download.jpg");
            // 
            // lblhello
            // 
            lblhello.AutoSize = true;
            lblhello.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblhello.Location = new Point(15, 61);
            lblhello.Name = "lblhello";
            lblhello.Size = new Size(90, 23);
            lblhello.TabIndex = 15;
            lblhello.Text = "Xin chào! ";
            lblhello.Click += label1_Click;
            // 
            // txtWelcomeUser
            // 
            txtWelcomeUser.BorderStyle = BorderStyle.None;
            txtWelcomeUser.Location = new Point(101, 60);
            txtWelcomeUser.Name = "txtWelcomeUser";
            txtWelcomeUser.ReadOnly = true;
            txtWelcomeUser.Size = new Size(152, 20);
            txtWelcomeUser.TabIndex = 14;
            txtWelcomeUser.TextChanged += textBox1_TextChanged_1;
            // 
            // pnlStatusBar
            // 
            pnlStatusBar.ImageScalingSize = new Size(20, 20);
            pnlStatusBar.Items.AddRange(new ToolStripItem[] { lblLocalIp, lblOnlineCount, lblConnectionStatus });
            pnlStatusBar.Location = new Point(0, 808);
            pnlStatusBar.Name = "pnlStatusBar";
            pnlStatusBar.Size = new Size(288, 26);
            pnlStatusBar.SizingGrip = false;
            pnlStatusBar.TabIndex = 13;
            pnlStatusBar.Text = "status1";
            pnlStatusBar.ItemClicked += pnlStatusBar_ItemClicked;
            // 
            // lblLocalIp
            // 
            lblLocalIp.Name = "lblLocalIp";
            lblLocalIp.Size = new Size(91, 20);
            lblLocalIp.Spring = true;
            lblLocalIp.Text = "IP: ";
            lblLocalIp.Click += lblLocalIp_Click;
            // 
            // lblOnlineCount
            // 
            lblOnlineCount.Name = "lblOnlineCount";
            lblOnlineCount.Size = new Size(91, 20);
            lblOnlineCount.Spring = true;
            lblOnlineCount.Text = "Online : ";
            lblOnlineCount.Click += lblOnlineCount_Click;
            // 
            // lblConnectionStatus
            // 
            lblConnectionStatus.Name = "lblConnectionStatus";
            lblConnectionStatus.Size = new Size(91, 20);
            lblConnectionStatus.Spring = true;
            lblConnectionStatus.Text = "Trạng thái : ";
            lblConnectionStatus.Click += lblConnectionStatus_Click;
            // 
            // pnlInputArea
            // 
            pnlInputArea.Controls.Add(txtMessageInput);
            pnlInputArea.Location = new Point(381, 727);
            pnlInputArea.Name = "pnlInputArea";
            pnlInputArea.Size = new Size(678, 62);
            pnlInputArea.TabIndex = 16;
            // 
            // txtMessageInput
            // 
            txtMessageInput.BackColor = SystemColors.ButtonHighlight;
            txtMessageInput.Dock = DockStyle.Fill;
            txtMessageInput.Location = new Point(0, 0);
            txtMessageInput.Multiline = true;
            txtMessageInput.Name = "txtMessageInput";
            txtMessageInput.Size = new Size(678, 62);
            txtMessageInput.TabIndex = 0;
            txtMessageInput.TextChanged += txtMessageInput_TextChanged;
            txtMessageInput.KeyDown += textBox2_KeyDown;
            // 
            // btnDisconnect
            // 
            btnDisconnect.BackColor = Color.FromArgb(128, 255, 255);
            btnDisconnect.FlatStyle = FlatStyle.Flat;
            btnDisconnect.ForeColor = Color.Red;
            btnDisconnect.Location = new Point(1252, 740);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(106, 49);
            btnDisconnect.TabIndex = 17;
            btnDisconnect.Text = "Ngắt Kết nối";
            btnDisconnect.UseVisualStyleBackColor = false;
            btnDisconnect.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1612, 834);
            Controls.Add(btnDisconnect);
            Controls.Add(pnlInputArea);
            Controls.Add(pnlMainChat);
            Controls.Add(label2);
            Controls.Add(nameapp);
            Controls.Add(btnSend);
            Controls.Add(pnlSidebar);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            pnlMainChat.ResumeLayout(false);
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            cmsUserOptions.ResumeLayout(false);
            pnlStatusBar.ResumeLayout(false);
            pnlStatusBar.PerformLayout();
            pnlInputArea.ResumeLayout(false);
            pnlInputArea.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnSend;
        private Label nameapp;
        private Label label2;
        private Panel pnlMainChat;
        private Panel pnlSidebar;
        private StatusStrip pnlStatusBar;
        private RichTextBox rtbChatLog;
        private Panel pnlInputArea;
        private TextBox txtMessageInput;
        private ToolStripStatusLabel lblLocalIp;
        private ToolStripStatusLabel lblOnlineCount;
        private ToolStripStatusLabel lblConnectionStatus;
        private TextBox txtWelcomeUser;
        private Label lblhello;
        private ListView lvwOnlineUsers;
        private ColumnHeader User;
        private ImageList imgStatusList;
        private ContextMenuStrip cmsUserOptions;
        private ToolStripMenuItem gửiTinNhắnToolStripMenuItem;
        private ToolStripMenuItem xemIPToolStripMenuItem;
        private Button btnDisconnect;
    }
}
