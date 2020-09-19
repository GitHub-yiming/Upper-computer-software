namespace thinger.com.MelsecFXPro
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pic_Lndicator_light = new System.Windows.Forms.PictureBox();
            this.cmb_Stop_bit = new System.Windows.Forms.ComboBox();
            this.cmb_Data_bits = new System.Windows.Forms.ComboBox();
            this.cmb_Check_bits = new System.Windows.Forms.ComboBox();
            this.cmb_Baud_rate = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_DisConn = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.cmb_Port = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ric_Read_Q = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_ForceOFF = new System.Windows.Forms.Button();
            this.btn_ForceON = new System.Windows.Forms.Button();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ric_Read_D = new System.Windows.Forms.RichTextBox();
            this.btn_Read_D = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Address_Read2_D = new System.Windows.Forms.TextBox();
            this.txt_Address_Read1_D = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Write_D = new System.Windows.Forms.Button();
            this.txt_Data_number_D = new System.Windows.Forms.TextBox();
            this.txt_Data_D = new System.Windows.Forms.TextBox();
            this.txt_Address_D = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Lndicator_light)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(603, 606);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pic_Lndicator_light);
            this.tabPage1.Controls.Add(this.cmb_Stop_bit);
            this.tabPage1.Controls.Add(this.cmb_Data_bits);
            this.tabPage1.Controls.Add(this.cmb_Check_bits);
            this.tabPage1.Controls.Add(this.cmb_Baud_rate);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.btn_DisConn);
            this.tabPage1.Controls.Add(this.btn_Connect);
            this.tabPage1.Controls.Add(this.cmb_Port);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(595, 570);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "通信配置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pic_Lndicator_light
            // 
            this.pic_Lndicator_light.Image = global::thinger.com.MelsecFXPro.Properties.Resources.灯泡__1_;
            this.pic_Lndicator_light.Location = new System.Drawing.Point(332, 358);
            this.pic_Lndicator_light.Name = "pic_Lndicator_light";
            this.pic_Lndicator_light.Size = new System.Drawing.Size(35, 32);
            this.pic_Lndicator_light.TabIndex = 41;
            this.pic_Lndicator_light.TabStop = false;
            this.pic_Lndicator_light.Visible = false;
            // 
            // cmb_Stop_bit
            // 
            this.cmb_Stop_bit.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmb_Stop_bit.FormattingEnabled = true;
            this.cmb_Stop_bit.Items.AddRange(new object[] {
            "One",
            "Two",
            "OnePointFive"});
            this.cmb_Stop_bit.Location = new System.Drawing.Point(235, 263);
            this.cmb_Stop_bit.Name = "cmb_Stop_bit";
            this.cmb_Stop_bit.Size = new System.Drawing.Size(139, 35);
            this.cmb_Stop_bit.TabIndex = 36;
            this.cmb_Stop_bit.Text = "One";
            // 
            // cmb_Data_bits
            // 
            this.cmb_Data_bits.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmb_Data_bits.FormattingEnabled = true;
            this.cmb_Data_bits.Items.AddRange(new object[] {
            "8",
            "7"});
            this.cmb_Data_bits.Location = new System.Drawing.Point(235, 215);
            this.cmb_Data_bits.Name = "cmb_Data_bits";
            this.cmb_Data_bits.Size = new System.Drawing.Size(139, 35);
            this.cmb_Data_bits.TabIndex = 35;
            this.cmb_Data_bits.Text = "7";
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
            this.cmb_Check_bits.Location = new System.Drawing.Point(235, 167);
            this.cmb_Check_bits.Name = "cmb_Check_bits";
            this.cmb_Check_bits.Size = new System.Drawing.Size(139, 35);
            this.cmb_Check_bits.TabIndex = 34;
            this.cmb_Check_bits.Text = "Even";
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
            this.cmb_Baud_rate.Location = new System.Drawing.Point(235, 119);
            this.cmb_Baud_rate.Name = "cmb_Baud_rate";
            this.cmb_Baud_rate.Size = new System.Drawing.Size(139, 35);
            this.cmb_Baud_rate.TabIndex = 33;
            this.cmb_Baud_rate.Text = "9600";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label9.Location = new System.Drawing.Point(157, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 27);
            this.label9.TabIndex = 37;
            this.label9.Text = "停止位";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label8.Location = new System.Drawing.Point(157, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 27);
            this.label8.TabIndex = 38;
            this.label8.Text = "数据位";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label7.Location = new System.Drawing.Point(157, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 27);
            this.label7.TabIndex = 39;
            this.label7.Text = "校验位";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label6.Location = new System.Drawing.Point(157, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 27);
            this.label6.TabIndex = 40;
            this.label6.Text = "波特率";
            // 
            // btn_DisConn
            // 
            this.btn_DisConn.Location = new System.Drawing.Point(235, 424);
            this.btn_DisConn.Name = "btn_DisConn";
            this.btn_DisConn.Size = new System.Drawing.Size(91, 29);
            this.btn_DisConn.TabIndex = 32;
            this.btn_DisConn.Text = "断开";
            this.btn_DisConn.UseVisualStyleBackColor = true;
            this.btn_DisConn.Click += new System.EventHandler(this.btn_DisConn_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(235, 358);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(91, 29);
            this.btn_Connect.TabIndex = 31;
            this.btn_Connect.Text = "连接";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // cmb_Port
            // 
            this.cmb_Port.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmb_Port.FormattingEnabled = true;
            this.cmb_Port.Location = new System.Drawing.Point(235, 71);
            this.cmb_Port.Name = "cmb_Port";
            this.cmb_Port.Size = new System.Drawing.Size(139, 35);
            this.cmb_Port.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(157, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 27);
            this.label1.TabIndex = 29;
            this.label1.Text = "串口号";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(595, 570);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "强制写入";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ric_Read_Q);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(8, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(579, 312);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "读取";
            // 
            // ric_Read_Q
            // 
            this.ric_Read_Q.Location = new System.Drawing.Point(6, 159);
            this.ric_Read_Q.Name = "ric_Read_Q";
            this.ric_Read_Q.Size = new System.Drawing.Size(567, 117);
            this.ric_Read_Q.TabIndex = 2;
            this.ric_Read_Q.Text = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(423, 61);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 36);
            this.button3.TabIndex = 1;
            this.button3.Text = "读取";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "至";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(230, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 34);
            this.textBox2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 34);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ForceOFF);
            this.groupBox1.Controls.Add(this.btn_ForceON);
            this.groupBox1.Controls.Add(this.txt_Address);
            this.groupBox1.Location = new System.Drawing.Point(8, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 135);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "写入";
            // 
            // btn_ForceOFF
            // 
            this.btn_ForceOFF.Location = new System.Drawing.Point(423, 60);
            this.btn_ForceOFF.Name = "btn_ForceOFF";
            this.btn_ForceOFF.Size = new System.Drawing.Size(119, 36);
            this.btn_ForceOFF.TabIndex = 1;
            this.btn_ForceOFF.Text = "OFF";
            this.btn_ForceOFF.UseVisualStyleBackColor = true;
            this.btn_ForceOFF.Click += new System.EventHandler(this.btn_ForceOFF_Click);
            // 
            // btn_ForceON
            // 
            this.btn_ForceON.Location = new System.Drawing.Point(243, 60);
            this.btn_ForceON.Name = "btn_ForceON";
            this.btn_ForceON.Size = new System.Drawing.Size(119, 36);
            this.btn_ForceON.TabIndex = 1;
            this.btn_ForceON.Text = "ON";
            this.btn_ForceON.UseVisualStyleBackColor = true;
            this.btn_ForceON.Click += new System.EventHandler(this.btn_ForceON_Click);
            // 
            // txt_Address
            // 
            this.txt_Address.Location = new System.Drawing.Point(64, 60);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(100, 34);
            this.txt_Address.TabIndex = 0;
            this.txt_Address.Text = "Y0";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(595, 570);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Y区";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Location = new System.Drawing.Point(4, 32);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(595, 570);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "D区";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ric_Read_D);
            this.groupBox4.Controls.Add(this.btn_Read_D);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txt_Address_Read2_D);
            this.groupBox4.Controls.Add(this.txt_Address_Read1_D);
            this.groupBox4.Location = new System.Drawing.Point(8, 210);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(579, 312);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "读取";
            // 
            // ric_Read_D
            // 
            this.ric_Read_D.Location = new System.Drawing.Point(6, 159);
            this.ric_Read_D.Name = "ric_Read_D";
            this.ric_Read_D.Size = new System.Drawing.Size(567, 117);
            this.ric_Read_D.TabIndex = 2;
            this.ric_Read_D.Text = "";
            // 
            // btn_Read_D
            // 
            this.btn_Read_D.Location = new System.Drawing.Point(423, 61);
            this.btn_Read_D.Name = "btn_Read_D";
            this.btn_Read_D.Size = new System.Drawing.Size(119, 36);
            this.btn_Read_D.TabIndex = 1;
            this.btn_Read_D.Text = "读取";
            this.btn_Read_D.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "至";
            // 
            // txt_Address_Read2_D
            // 
            this.txt_Address_Read2_D.Location = new System.Drawing.Point(230, 59);
            this.txt_Address_Read2_D.Name = "txt_Address_Read2_D";
            this.txt_Address_Read2_D.Size = new System.Drawing.Size(100, 31);
            this.txt_Address_Read2_D.TabIndex = 0;
            // 
            // txt_Address_Read1_D
            // 
            this.txt_Address_Read1_D.Location = new System.Drawing.Point(64, 59);
            this.txt_Address_Read1_D.Name = "txt_Address_Read1_D";
            this.txt_Address_Read1_D.Size = new System.Drawing.Size(100, 31);
            this.txt_Address_Read1_D.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btn_Write_D);
            this.groupBox3.Controls.Add(this.txt_Data_number_D);
            this.groupBox3.Controls.Add(this.txt_Data_D);
            this.groupBox3.Controls.Add(this.txt_Address_D);
            this.groupBox3.Location = new System.Drawing.Point(10, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(579, 135);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "写入";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "数据";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(280, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 24);
            this.label10.TabIndex = 2;
            this.label10.Text = "写入个数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "地址";
            // 
            // btn_Write_D
            // 
            this.btn_Write_D.Location = new System.Drawing.Point(284, 86);
            this.btn_Write_D.Name = "btn_Write_D";
            this.btn_Write_D.Size = new System.Drawing.Size(119, 36);
            this.btn_Write_D.TabIndex = 1;
            this.btn_Write_D.Text = "写入";
            this.btn_Write_D.UseVisualStyleBackColor = true;
            this.btn_Write_D.Click += new System.EventHandler(this.btn_Write_D_Click);
            // 
            // txt_Data_number_D
            // 
            this.txt_Data_number_D.Location = new System.Drawing.Point(366, 31);
            this.txt_Data_number_D.Name = "txt_Data_number_D";
            this.txt_Data_number_D.Size = new System.Drawing.Size(100, 31);
            this.txt_Data_number_D.TabIndex = 0;
            this.txt_Data_number_D.Text = "1";
            // 
            // txt_Data_D
            // 
            this.txt_Data_D.Location = new System.Drawing.Point(137, 86);
            this.txt_Data_D.Name = "txt_Data_D";
            this.txt_Data_D.Size = new System.Drawing.Size(100, 31);
            this.txt_Data_D.TabIndex = 0;
            this.txt_Data_D.Text = "1234";
            // 
            // txt_Address_D
            // 
            this.txt_Address_D.Location = new System.Drawing.Point(137, 30);
            this.txt_Address_D.Name = "txt_Address_D";
            this.txt_Address_D.Size = new System.Drawing.Size(100, 31);
            this.txt_Address_D.TabIndex = 0;
            this.txt_Address_D.Text = "D0";
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 32);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(595, 570);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "M区";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 32);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(595, 570);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "T区";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 32);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(595, 570);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "C区";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 606);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用C#与三菱FX系列PLC通信";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Lndicator_light)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmb_Stop_bit;
        private System.Windows.Forms.ComboBox cmb_Data_bits;
        private System.Windows.Forms.ComboBox cmb_Check_bits;
        private System.Windows.Forms.ComboBox cmb_Baud_rate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_DisConn;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.ComboBox cmb_Port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_ForceOFF;
        private System.Windows.Forms.Button btn_ForceON;
        private System.Windows.Forms.RichTextBox ric_Read_Q;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.PictureBox pic_Lndicator_light;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox ric_Read_D;
        private System.Windows.Forms.Button btn_Read_D;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Address_Read2_D;
        private System.Windows.Forms.TextBox txt_Address_Read1_D;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Write_D;
        private System.Windows.Forms.TextBox txt_Data_D;
        private System.Windows.Forms.TextBox txt_Address_D;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Data_number_D;
    }
}

