namespace RegisterClient
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
            label1 = new Label();
            txtUsername = new TextBox();
            txtServerIP = new TextBox();
            btnConnect = new Button();
            btnOUT = new Button();
            label2 = new Label();
            label3 = new Label();
            txtPort = new TextBox();
            label4 = new Label();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(332, 9);
            label1.Name = "label1";
            label1.Size = new Size(122, 35);
            label1.TabIndex = 0;
            label1.Text = "Đăng Kí";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(201, 132);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(402, 27);
            txtUsername.TabIndex = 1;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // txtServerIP
            // 
            txtServerIP.Location = new Point(201, 192);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(402, 27);
            txtServerIP.TabIndex = 2;
            txtServerIP.TextChanged += txtServerIP_TextChanged;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(201, 301);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(154, 41);
            btnConnect.TabIndex = 3;
            btnConnect.Text = "Kết Nối";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += button1_Click;
            // 
            // btnOUT
            // 
            btnOUT.Location = new Point(449, 301);
            btnOUT.Name = "btnOUT";
            btnOUT.Size = new Size(154, 41);
            btnOUT.TabIndex = 4;
            btnOUT.Text = "Thoát";
            btnOUT.UseVisualStyleBackColor = true;
            btnOUT.Click += btnOUT_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 139);
            label2.Name = "label2";
            label2.Size = new Size(118, 20);
            label2.TabIndex = 5;
            label2.Text = "Tên Người Dùng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(170, 199);
            label3.Name = "label3";
            label3.Size = new Size(25, 20);
            label3.TabIndex = 6;
            label3.Text = "IP ";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(201, 249);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(402, 27);
            txtPort.TabIndex = 7;
            txtPort.TextChanged += txtPort_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(151, 256);
            label4.Name = "label4";
            label4.Size = new Size(44, 20);
            label4.TabIndex = 8;
            label4.Text = "Cổng";
            label4.Click += label4_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(0, 430);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(89, 20);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "Trạng Thái : ";
            lblStatus.Click += lblStatus_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblStatus);
            Controls.Add(label4);
            Controls.Add(txtPort);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnOUT);
            Controls.Add(btnConnect);
            Controls.Add(txtServerIP);
            Controls.Add(txtUsername);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUsername;
        private TextBox txtServerIP;
        private Button btnConnect;
        private Button btnOUT;
        private Label label2;
        private Label label3;
        private TextBox txtPort;
        private Label label4;
        private Label lblStatus;
    }
}
