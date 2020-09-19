using Modbus;
using ModbusDemo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Speech.Recognition;
using System.Windows.Forms;

namespace ModbusDemo
{
	public class aaa : Form
	{
		private Timer Tim_Disable = new Timer();

		private ModbusRTU objModbus = new ModbusRTU();

		private SpeechRecognitionEngine recognitionEngine = new SpeechRecognitionEngine();

		private IContainer components = null;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private TabPage aa;

		private Label label4;

		private Button btn_DisConn;

		private RichTextBox richTextBox1;

		private TextBox txt_Start;

		private TextBox txt_Slave;

		private TextBox txt_Length;

		private Button btn_Connect;

		private Button button1;

		private Label label3;

		private Label label2;

		private Label label1;

		private ComboBox comboBox1;

		private Label label8;

		private Label label7;

		private Label label6;

		private Label label5;

		private ComboBox cmb_Port;

		private ComboBox cmb_Stop_bit;

		private ComboBox cmb_Data_bits;

		private ComboBox cmb_Check_bits;

		private ComboBox cmb_Baud_rate;

		private Label label9;

		private CheckBox cbx_Continuous_read;

		private Label label11;

		private Button but_Eliminate;

		private Timer tim_Continuity;

		private PictureBox pic_Lndicator_light;

		private Panel pan_Continuous_time;

		private TextBox txt_Continuous_time;

		private Label label12;

		private ComboBox com_Functioncode_M;

		private Label label10;

		private TextBox txt_Start_M;

		private TextBox txt_Slave_M;

		private TextBox txt_Datawriting_M;

		private Label label16;

		private TextBox txt_Length_M;

		private Label label13;

		private Label label14;

		private Label label15;

		private TabPage tabPage3;

		private Button btn_Datawriting_M;

		private Button btn_stop;

		private Button btn_start;

		private Label label17;

		public aaa()
		{
			InitializeComponent();
			cmb_Port.DataSource = SerialPort.GetPortNames();
			Tim_Disable.Interval = 10;
			Tim_Disable.Start();
			Tim_Disable.Tick += Tim_Disable_Tick;
		}

		private void Tim_Disable_Tick(object sender, EventArgs e)
		{
			if (pic_Lndicator_light.Visible)
			{
				button1.Enabled = true;
				cbx_Continuous_read.Enabled = true;
				btn_DisConn.Enabled = true;
			}
			else
			{
				button1.Enabled = false;
				cbx_Continuous_read.Enabled = false;
				btn_DisConn.Enabled = false;
			}
			if (btn_DisConn.Enabled)
			{
				btn_Connect.Enabled = false;
			}
			else
			{
				btn_Connect.Enabled = true;
			}
		}

		private void btn_Connect_Click(object sender, EventArgs e)
		{
			try
			{
				Choices choices = new Choices();
				choices.Add("信捷开始", "流水灯开始", "发送", "停止");
				GrammarBuilder gb = new GrammarBuilder(choices);
				Grammar grm = new Grammar(gb);
				recognitionEngine.LoadGrammar(grm);
				recognitionEngine.SetInputToDefaultAudioDevice();
				recognitionEngine.SpeechRecognized += RecognitionEngine_SpeechRecognized;
				objModbus.Connect(cmb_Port.Text, Convert.ToInt32(cmb_Baud_rate.Text, 10), (Parity)Enum.Parse(typeof(Parity), cmb_Check_bits.Text), int.Parse(cmb_Data_bits.Text), (StopBits)Enum.Parse(typeof(StopBits), cmb_Stop_bit.Text));
			}
			catch (Exception)
			{
				MessageBox.Show("连接失败！");
				return;
			}
			pic_Lndicator_light.Visible = true;
		}

		private void RecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
		{
			string info = e.Result.Text;
			string text = e.Result.Text;
			string text2 = text;
			if (text2 != null && text2 == "发送")
			{
				btn_Datawriting_M_Click(null, null);
			}
		}

		private void btn_DisConn_Click(object sender, EventArgs e)
		{
			objModbus.DisConnect();
			pic_Lndicator_light.Visible = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				byte[] res = objModbus.ReadOutputStatus(Convert.ToByte(txt_Slave.Text), Convert.ToUInt16(txt_Start.Text), Convert.ToUInt16(txt_Length.Text));
				if (res != null)
				{
					bool[] boolRes = GetBitArrayFormByteArray(res);
					string result = string.Empty;
					for (int i = 0; i < Convert.ToUInt16(txt_Length.Text); i++)
					{
						result = result + boolRes[i] + " ";
					}
					richTextBox1.AppendText(result.Trim() + Environment.NewLine);
				}
			}
			catch (Exception)
			{
			}
		}

		private bool[] GetBitArrayFormByte(byte b, bool reverse = false)
		{
			bool[] array = new bool[8];
			if (reverse)
			{
				for (int j = 7; j >= 0; j--)
				{
					array[j] = ((b & 1) == 1);
					b = (byte)(b >> 1);
				}
			}
			else
			{
				for (int i = 0; i <= 7; i++)
				{
					array[i] = ((b & 1) == 1);
					b = (byte)(b >> 1);
				}
			}
			return array;
		}

		private bool[] GetBitArrayFormByteArray(byte[] b, bool reverse = false)
		{
			List<bool> res = new List<bool>();
			foreach (byte item in b)
			{
				res.AddRange(GetBitArrayFormByte(item, reverse));
			}
			return res.ToArray();
		}

		private void cbx_Continuous_read_CheckedChanged(object sender, EventArgs e)
		{
			if (cbx_Continuous_read.Checked)
			{
				tim_Continuity.Start();
				pan_Continuous_time.Visible = true;
			}
			else
			{
				tim_Continuity.Stop();
				pan_Continuous_time.Visible = false;
			}
		}

		private void but_Eliminate_Click(object sender, EventArgs e)
		{
			richTextBox1.Text = "";
		}

		private void tim_Continuity_Tick(object sender, EventArgs e)
		{
			try
			{
				byte[] res = objModbus.ReadOutputStatus(Convert.ToByte(txt_Slave.Text), Convert.ToUInt16(txt_Start.Text), Convert.ToUInt16(txt_Length.Text));
				if (res != null)
				{
					bool[] boolRes = GetBitArrayFormByteArray(res);
					string result = string.Empty;
					for (int i = 0; i < Convert.ToUInt16(txt_Length.Text); i++)
					{
						result = result + boolRes[i] + " ";
					}
					richTextBox1.AppendText(result.Trim() + Environment.NewLine);
				}
			}
			catch (Exception)
			{
			}
		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{
			richTextBox1.SelectionStart = richTextBox1.TextLength;
			richTextBox1.ScrollToCaret();
		}

		private void txt_Continuous_time_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				try
				{
					tim_Continuity.Interval = Convert.ToInt32(txt_Continuous_time.Text);
				}
				catch (Exception)
				{
				}
			}
		}

		private void btn_Datawriting_M_Click(object sender, EventArgs e)
		{
			string text = com_Functioncode_M.Text;
			string text2 = text;
			if (text2 != null && text2 == "0x0F")
			{
				com_Functioncode_M.Text = "15";
			}
			objModbus.ReadOutputStatus_M(Convert.ToByte(txt_Slave_M.Text), Convert.ToUInt16(com_Functioncode_M.Text), Convert.ToUInt16(txt_Start_M.Text), Convert.ToUInt16(txt_Length_M.Text), Convert.ToUInt16(txt_Datawriting_M.Text));
		}

		private void btn_start_Click(object sender, EventArgs e)
		{
			recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
			btn_start.Enabled = false;
			btn_stop.Enabled = true;
		}

		private void btn_stop_Click(object sender, EventArgs e)
		{
			recognitionEngine.RecognizeAsyncStop();
			btn_start.Enabled = true;
			btn_stop.Enabled = false;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(aaa));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_DisConn = new System.Windows.Forms.Button();
            this.pan_Continuous_time = new System.Windows.Forms.Panel();
            this.txt_Continuous_time = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pic_Lndicator_light = new System.Windows.Forms.PictureBox();
            this.but_Eliminate = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cbx_Continuous_read = new System.Windows.Forms.CheckBox();
            this.cmb_Stop_bit = new System.Windows.Forms.ComboBox();
            this.cmb_Data_bits = new System.Windows.Forms.ComboBox();
            this.cmb_Check_bits = new System.Windows.Forms.ComboBox();
            this.cmb_Baud_rate = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_Port = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txt_Start = new System.Windows.Forms.TextBox();
            this.txt_Slave = new System.Windows.Forms.TextBox();
            this.txt_Length = new System.Windows.Forms.TextBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.aa = new System.Windows.Forms.TabPage();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_Datawriting_M = new System.Windows.Forms.Button();
            this.com_Functioncode_M = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Start_M = new System.Windows.Forms.TextBox();
            this.txt_Slave_M = new System.Windows.Forms.TextBox();
            this.txt_Datawriting_M = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_Length_M = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tim_Continuity = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pan_Continuous_time.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Lndicator_light)).BeginInit();
            this.aa.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.aa);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1026, 594);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.btn_DisConn);
            this.tabPage1.Controls.Add(this.pan_Continuous_time);
            this.tabPage1.Controls.Add(this.pic_Lndicator_light);
            this.tabPage1.Controls.Add(this.but_Eliminate);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.cbx_Continuous_read);
            this.tabPage1.Controls.Add(this.cmb_Stop_bit);
            this.tabPage1.Controls.Add(this.cmb_Data_bits);
            this.tabPage1.Controls.Add(this.cmb_Check_bits);
            this.tabPage1.Controls.Add(this.cmb_Baud_rate);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cmb_Port);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.txt_Start);
            this.tabPage1.Controls.Add(this.txt_Slave);
            this.tabPage1.Controls.Add(this.txt_Length);
            this.tabPage1.Controls.Add(this.btn_Connect);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1018, 561);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Modbus-RTU";
            // 
            // btn_DisConn
            // 
            this.btn_DisConn.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_DisConn.Location = new System.Drawing.Point(35, 355);
            this.btn_DisConn.Name = "btn_DisConn";
            this.btn_DisConn.Size = new System.Drawing.Size(121, 40);
            this.btn_DisConn.TabIndex = 7;
            this.btn_DisConn.Text = "断开";
            this.btn_DisConn.UseVisualStyleBackColor = true;
            this.btn_DisConn.Click += new System.EventHandler(this.btn_DisConn_Click);
            // 
            // pan_Continuous_time
            // 
            this.pan_Continuous_time.Controls.Add(this.txt_Continuous_time);
            this.pan_Continuous_time.Controls.Add(this.label12);
            this.pan_Continuous_time.Location = new System.Drawing.Point(227, 431);
            this.pan_Continuous_time.Name = "pan_Continuous_time";
            this.pan_Continuous_time.Size = new System.Drawing.Size(169, 40);
            this.pan_Continuous_time.TabIndex = 26;
            this.pan_Continuous_time.Visible = false;
            // 
            // txt_Continuous_time
            // 
            this.txt_Continuous_time.Location = new System.Drawing.Point(3, 7);
            this.txt_Continuous_time.Name = "txt_Continuous_time";
            this.txt_Continuous_time.Size = new System.Drawing.Size(51, 27);
            this.txt_Continuous_time.TabIndex = 25;
            this.txt_Continuous_time.Text = "1000";
            this.txt_Continuous_time.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Continuous_time_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label12.Location = new System.Drawing.Point(52, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 27);
            this.label12.TabIndex = 26;
            this.label12.Text = "ms";
            // 
            // pic_Lndicator_light
            // 
            this.pic_Lndicator_light.BackColor = System.Drawing.Color.Transparent;
            this.pic_Lndicator_light.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pic_Lndicator_light.Image = ((System.Drawing.Image)(resources.GetObject("pic_Lndicator_light.Image")));
            this.pic_Lndicator_light.Location = new System.Drawing.Point(161, 285);
            this.pic_Lndicator_light.Name = "pic_Lndicator_light";
            this.pic_Lndicator_light.Size = new System.Drawing.Size(36, 33);
            this.pic_Lndicator_light.TabIndex = 24;
            this.pic_Lndicator_light.TabStop = false;
            this.pic_Lndicator_light.Visible = false;
            // 
            // but_Eliminate
            // 
            this.but_Eliminate.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.but_Eliminate.Location = new System.Drawing.Point(35, 503);
            this.but_Eliminate.Name = "but_Eliminate";
            this.but_Eliminate.Size = new System.Drawing.Size(121, 40);
            this.but_Eliminate.TabIndex = 9;
            this.but_Eliminate.Text = "清除";
            this.but_Eliminate.UseVisualStyleBackColor = true;
            this.but_Eliminate.Click += new System.EventHandler(this.but_Eliminate_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(228, 341);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(423, 57);
            this.label11.TabIndex = 22;
            this.label11.Text = "暂时只支持0x01读取";
            // 
            // cbx_Continuous_read
            // 
            this.cbx_Continuous_read.AutoSize = true;
            this.cbx_Continuous_read.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cbx_Continuous_read.Location = new System.Drawing.Point(162, 437);
            this.cbx_Continuous_read.Name = "cbx_Continuous_read";
            this.cbx_Continuous_read.Size = new System.Drawing.Size(74, 31);
            this.cbx_Continuous_read.TabIndex = 10;
            this.cbx_Continuous_read.Text = "连续";
            this.cbx_Continuous_read.UseVisualStyleBackColor = true;
            this.cbx_Continuous_read.CheckedChanged += new System.EventHandler(this.cbx_Continuous_read_CheckedChanged);
            // 
            // cmb_Stop_bit
            // 
            this.cmb_Stop_bit.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmb_Stop_bit.FormattingEnabled = true;
            this.cmb_Stop_bit.Items.AddRange(new object[] {
            "One",
            "Two",
            "OnePointFive"});
            this.cmb_Stop_bit.Location = new System.Drawing.Point(128, 210);
            this.cmb_Stop_bit.Name = "cmb_Stop_bit";
            this.cmb_Stop_bit.Size = new System.Drawing.Size(139, 35);
            this.cmb_Stop_bit.TabIndex = 5;
            this.cmb_Stop_bit.Text = "One";
            // 
            // cmb_Data_bits
            // 
            this.cmb_Data_bits.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmb_Data_bits.FormattingEnabled = true;
            this.cmb_Data_bits.Items.AddRange(new object[] {
            "8",
            "7"});
            this.cmb_Data_bits.Location = new System.Drawing.Point(128, 164);
            this.cmb_Data_bits.Name = "cmb_Data_bits";
            this.cmb_Data_bits.Size = new System.Drawing.Size(139, 35);
            this.cmb_Data_bits.TabIndex = 4;
            this.cmb_Data_bits.Text = "8";
            // 
            // cmb_Check_bits
            // 
            this.cmb_Check_bits.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmb_Check_bits.FormattingEnabled = true;
            this.cmb_Check_bits.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.cmb_Check_bits.Location = new System.Drawing.Point(128, 117);
            this.cmb_Check_bits.Name = "cmb_Check_bits";
            this.cmb_Check_bits.Size = new System.Drawing.Size(139, 35);
            this.cmb_Check_bits.TabIndex = 3;
            this.cmb_Check_bits.Text = "None";
            // 
            // cmb_Baud_rate
            // 
            this.cmb_Baud_rate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmb_Baud_rate.FormattingEnabled = true;
            this.cmb_Baud_rate.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "115200"});
            this.cmb_Baud_rate.Location = new System.Drawing.Point(128, 70);
            this.cmb_Baud_rate.Name = "cmb_Baud_rate";
            this.cmb_Baud_rate.Size = new System.Drawing.Size(139, 35);
            this.cmb_Baud_rate.TabIndex = 2;
            this.cmb_Baud_rate.Text = "9600";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label9.Location = new System.Drawing.Point(30, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 27);
            this.label9.TabIndex = 18;
            this.label9.Text = "停止位";
            // 
            // cmb_Port
            // 
            this.cmb_Port.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmb_Port.FormattingEnabled = true;
            this.cmb_Port.Location = new System.Drawing.Point(128, 23);
            this.cmb_Port.Name = "cmb_Port";
            this.cmb_Port.Size = new System.Drawing.Size(139, 35);
            this.cmb_Port.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label8.Location = new System.Drawing.Point(30, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 27);
            this.label8.TabIndex = 18;
            this.label8.Text = "数据位";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label7.Location = new System.Drawing.Point(30, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 27);
            this.label7.TabIndex = 18;
            this.label7.Text = "校验位";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label6.Location = new System.Drawing.Point(30, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 27);
            this.label6.TabIndex = 18;
            this.label6.Text = "波特率";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label5.Location = new System.Drawing.Point(30, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 27);
            this.label5.TabIndex = 17;
            this.label5.Text = "端口号";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0x01",
            "0x02",
            "0x03",
            "0x04",
            "0x06"});
            this.comboBox1.Location = new System.Drawing.Point(534, 23);
            this.comboBox1.MaxDropDownItems = 20;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(139, 35);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.Text = "0x01";
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(420, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 27);
            this.label4.TabIndex = 16;
            this.label4.Text = "功能码";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.richTextBox1.Location = new System.Drawing.Point(697, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(318, 555);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // txt_Start
            // 
            this.txt_Start.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Start.Location = new System.Drawing.Point(534, 118);
            this.txt_Start.Name = "txt_Start";
            this.txt_Start.Size = new System.Drawing.Size(139, 34);
            this.txt_Start.TabIndex = 13;
            this.txt_Start.Text = "0";
            this.txt_Start.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Slave
            // 
            this.txt_Slave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Slave.Location = new System.Drawing.Point(534, 71);
            this.txt_Slave.Name = "txt_Slave";
            this.txt_Slave.Size = new System.Drawing.Size(139, 34);
            this.txt_Slave.TabIndex = 12;
            this.txt_Slave.Text = "1";
            this.txt_Slave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Length
            // 
            this.txt_Length.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Length.Location = new System.Drawing.Point(534, 165);
            this.txt_Length.Name = "txt_Length";
            this.txt_Length.Size = new System.Drawing.Size(139, 34);
            this.txt_Length.TabIndex = 14;
            this.txt_Length.Text = "10";
            this.txt_Length.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Connect
            // 
            this.btn_Connect.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Connect.Location = new System.Drawing.Point(35, 281);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(121, 40);
            this.btn_Connect.TabIndex = 6;
            this.btn_Connect.Text = "连接";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.button1.Location = new System.Drawing.Point(35, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "读取";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(420, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 27);
            this.label3.TabIndex = 10;
            this.label3.Text = "读取长度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(420, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 27);
            this.label2.TabIndex = 11;
            this.label2.Text = "开始地址";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(420, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 27);
            this.label1.TabIndex = 12;
            this.label1.Text = "从站地址";
            // 
            // aa
            // 
            this.aa.BackColor = System.Drawing.Color.Gainsboro;
            this.aa.Controls.Add(this.btn_stop);
            this.aa.Controls.Add(this.btn_start);
            this.aa.Controls.Add(this.btn_Datawriting_M);
            this.aa.Controls.Add(this.com_Functioncode_M);
            this.aa.Controls.Add(this.label17);
            this.aa.Controls.Add(this.label10);
            this.aa.Controls.Add(this.txt_Start_M);
            this.aa.Controls.Add(this.txt_Slave_M);
            this.aa.Controls.Add(this.txt_Datawriting_M);
            this.aa.Controls.Add(this.label16);
            this.aa.Controls.Add(this.txt_Length_M);
            this.aa.Controls.Add(this.label13);
            this.aa.Controls.Add(this.label14);
            this.aa.Controls.Add(this.label15);
            this.aa.Location = new System.Drawing.Point(4, 29);
            this.aa.Name = "aa";
            this.aa.Padding = new System.Windows.Forms.Padding(3);
            this.aa.Size = new System.Drawing.Size(1018, 561);
            this.aa.TabIndex = 1;
            this.aa.Text = "M区";
            // 
            // btn_stop
            // 
            this.btn_stop.Enabled = false;
            this.btn_stop.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.btn_stop.Location = new System.Drawing.Point(784, 66);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(154, 40);
            this.btn_stop.TabIndex = 25;
            this.btn_stop.Text = "停止说话";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.btn_start.Location = new System.Drawing.Point(595, 66);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(154, 40);
            this.btn_start.TabIndex = 25;
            this.btn_start.Text = "开始说话";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_Datawriting_M
            // 
            this.btn_Datawriting_M.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.btn_Datawriting_M.Location = new System.Drawing.Point(287, 330);
            this.btn_Datawriting_M.Name = "btn_Datawriting_M";
            this.btn_Datawriting_M.Size = new System.Drawing.Size(121, 40);
            this.btn_Datawriting_M.TabIndex = 25;
            this.btn_Datawriting_M.Text = "写入";
            this.btn_Datawriting_M.UseVisualStyleBackColor = true;
            this.btn_Datawriting_M.Click += new System.EventHandler(this.btn_Datawriting_M_Click);
            // 
            // com_Functioncode_M
            // 
            this.com_Functioncode_M.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.com_Functioncode_M.FormattingEnabled = true;
            this.com_Functioncode_M.Items.AddRange(new object[] {
            "15",
            "5"});
            this.com_Functioncode_M.Location = new System.Drawing.Point(396, 114);
            this.com_Functioncode_M.MaxDropDownItems = 20;
            this.com_Functioncode_M.Name = "com_Functioncode_M";
            this.com_Functioncode_M.Size = new System.Drawing.Size(139, 35);
            this.com_Functioncode_M.TabIndex = 18;
            this.com_Functioncode_M.Text = "15";
            // 
            // label17
            // 
            this.label17.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(536, 118);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 27);
            this.label17.TabIndex = 24;
            this.label17.Text = "十进制";
            // 
            // label10
            // 
            this.label10.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(282, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 27);
            this.label10.TabIndex = 24;
            this.label10.Text = "功能码";
            // 
            // txt_Start_M
            // 
            this.txt_Start_M.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Start_M.Location = new System.Drawing.Point(396, 155);
            this.txt_Start_M.Name = "txt_Start_M";
            this.txt_Start_M.Size = new System.Drawing.Size(139, 34);
            this.txt_Start_M.TabIndex = 22;
            this.txt_Start_M.Text = "0";
            this.txt_Start_M.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Slave_M
            // 
            this.txt_Slave_M.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Slave_M.Location = new System.Drawing.Point(396, 74);
            this.txt_Slave_M.Name = "txt_Slave_M";
            this.txt_Slave_M.Size = new System.Drawing.Size(139, 34);
            this.txt_Slave_M.TabIndex = 20;
            this.txt_Slave_M.Text = "1";
            this.txt_Slave_M.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Datawriting_M
            // 
            this.txt_Datawriting_M.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Datawriting_M.Location = new System.Drawing.Point(396, 251);
            this.txt_Datawriting_M.Name = "txt_Datawriting_M";
            this.txt_Datawriting_M.Size = new System.Drawing.Size(139, 34);
            this.txt_Datawriting_M.TabIndex = 23;
            this.txt_Datawriting_M.Text = "1";
            this.txt_Datawriting_M.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(282, 258);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 27);
            this.label16.TabIndex = 17;
            this.label16.Text = "写入数据";
            // 
            // txt_Length_M
            // 
            this.txt_Length_M.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Length_M.Location = new System.Drawing.Point(396, 202);
            this.txt_Length_M.Name = "txt_Length_M";
            this.txt_Length_M.Size = new System.Drawing.Size(139, 34);
            this.txt_Length_M.TabIndex = 23;
            this.txt_Length_M.Text = "10";
            this.txt_Length_M.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(282, 209);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 27);
            this.label13.TabIndex = 17;
            this.label13.Text = "写入长度";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(282, 162);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 27);
            this.label14.TabIndex = 19;
            this.label14.Text = "开始地址";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(282, 79);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 27);
            this.label15.TabIndex = 21;
            this.label15.Text = "从站地址";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1018, 561);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tim_Continuity
            // 
            this.tim_Continuity.Interval = 1000;
            this.tim_Continuity.Tick += new System.EventHandler(this.tim_Continuity_Tick);
            // 
            // aaa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 594);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1044, 641);
            this.Name = "aaa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基于C#编写的ModbusRTU通讯库--胡一鸣";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.pan_Continuous_time.ResumeLayout(false);
            this.pan_Continuous_time.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Lndicator_light)).EndInit();
            this.aa.ResumeLayout(false);
            this.aa.PerformLayout();
            this.ResumeLayout(false);

		}
	}
}
