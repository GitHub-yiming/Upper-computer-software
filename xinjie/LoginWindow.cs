using ModbusDemo.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ModbusDemo
{
	public class LoginWindow : Form
	{
		private Timer CloseTimer = new Timer();

		private Point mPoint;

		private IContainer components = null;

		private PictureBox pictureBox1;

		private PictureBox pictureBox2;

		private TextBox txt_Password;

		private TextBox txt_UserName;

		private Panel panel1;

		private Button btn_Login;

		private Button but_Close;

		private Panel Pan_Title;

		private Label label1;

		public LoginWindow()
		{
			InitializeComponent();
			CloseTimer.Interval = 10;
			CloseTimer.Tick += CloseTimer_Tick;
		}

		private void CloseTimer_Tick(object sender, EventArgs e)
		{
			if (base.Opacity >= 0.025)
			{
				base.Opacity -= 0.025;
				return;
			}
			CloseTimer.Enabled = false;
			Close();
		}

		private void Pan_Title_MouseDown(object sender, MouseEventArgs e)
		{
			mPoint = e.Location;
		}

		private void Pan_Title_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				base.Location = new Point(base.Location.X + e.X - mPoint.X, base.Location.Y + e.Y - mPoint.Y);
			}
		}

		private void but_Close_Click(object sender, EventArgs e)
		{
			CloseTimer.Enabled = true;
		}

		private void btn_Login_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void txt_UserName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				btn_Login_Click(null, null);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginWindow));
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.but_Close = new System.Windows.Forms.Button();
            this.Pan_Title = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Pan_Title.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Password
            // 
            this.txt_Password.Font = new System.Drawing.Font("宋体", 14F);
            this.txt_Password.Location = new System.Drawing.Point(109, 128);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(180, 34);
            this.txt_Password.TabIndex = 1;
            this.txt_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Password.UseSystemPasswordChar = true;
            this.txt_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_UserName_KeyDown);
            // 
            // txt_UserName
            // 
            this.txt_UserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txt_UserName.Font = new System.Drawing.Font("宋体", 14F);
            this.txt_UserName.Location = new System.Drawing.Point(109, 40);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(180, 34);
            this.txt_UserName.TabIndex = 0;
            this.txt_UserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_UserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_UserName_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txt_Password);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.txt_UserName);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(199, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 215);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(43, 126);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 36);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(43, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 36);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.Transparent;
            this.btn_Login.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Login.Location = new System.Drawing.Point(199, 329);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(89, 37);
            this.btn_Login.TabIndex = 1;
            this.btn_Login.Text = "登录";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // but_Close
            // 
            this.but_Close.BackColor = System.Drawing.Color.Transparent;
            this.but_Close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.but_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.but_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_Close.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Close.Location = new System.Drawing.Point(425, 329);
            this.but_Close.Name = "but_Close";
            this.but_Close.Size = new System.Drawing.Size(89, 37);
            this.but_Close.TabIndex = 2;
            this.but_Close.Text = "退出";
            this.but_Close.UseVisualStyleBackColor = false;
            this.but_Close.Click += new System.EventHandler(this.but_Close_Click);
            // 
            // Pan_Title
            // 
            this.Pan_Title.BackColor = System.Drawing.Color.Transparent;
            this.Pan_Title.Controls.Add(this.label1);
            this.Pan_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pan_Title.Location = new System.Drawing.Point(0, 0);
            this.Pan_Title.Name = "Pan_Title";
            this.Pan_Title.Size = new System.Drawing.Size(707, 99);
            this.Pan_Title.TabIndex = 0;
            this.Pan_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pan_Title_MouseDown);
            this.Pan_Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pan_Title_MouseMove);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(249, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modbus-RTU";
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(707, 393);
            this.Controls.Add(this.Pan_Title);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.but_Close);
            this.Controls.Add(this.btn_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Pan_Title.ResumeLayout(false);
            this.ResumeLayout(false);

		}
	}
}
