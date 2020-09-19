using Modbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace ModbusDemo
{
    public partial class aaa : Form
    {
        public aaa()
        {
            InitializeComponent();

            //获取所有的串口
            this.cmb_Port.DataSource = SerialPort.GetPortNames();

            Tim_Disable.Interval = 10;
            Tim_Disable.Start();

            Tim_Disable.Tick += Tim_Disable_Tick;

        }

        //连续扫描按钮--计时器
        private Timer Tim_Disable = new Timer();

        /// <summary>
        /// 连续扫描按钮--事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tim_Disable_Tick(object sender, EventArgs e)
        {
            if (pic_Lndicator_light.Visible == true)
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

            if (btn_DisConn.Enabled == true)
            {
                btn_Connect.Enabled = false;
            }
            else
            {
                btn_Connect.Enabled = true;

            }

        }

        /// <summary>
        /// 导入ModbusRTU
        /// </summary>
        ModbusRTU objModbus = new ModbusRTU();


                SpeechRecognitionEngine recognitionEngine = new SpeechRecognitionEngine();
        //创建连续读取定时器
        /// <summary>
        /// 连接按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                //语音识别初始化

                //创建一组语音识别的语法约束选择
                Choices choices = new Choices();

                choices.Add(new string[] { "信捷开始","流水灯开始","发送" ,"停止"});

                //以编程的方式为语音生成语法选择
                GrammarBuilder gb = new GrammarBuilder(choices);

                //GrammarBuilder封装对象
                Grammar grm = new Grammar(gb);

                //SpeechRecognitionEngine
                recognitionEngine.LoadGrammar(grm);

                //音频输入
                recognitionEngine.SetInputToDefaultAudioDevice();

                //生成识别完成事件
                recognitionEngine.SpeechRecognized += RecognitionEngine_SpeechRecognized;

                objModbus.Connect(cmb_Port.Text, Convert.ToInt32(cmb_Baud_rate.Text, 10), (Parity)Enum.Parse(typeof(Parity), cmb_Check_bits.Text), int.Parse(cmb_Data_bits.Text), (StopBits)Enum.Parse(typeof(StopBits), cmb_Stop_bit.Text));
            }
            catch (Exception)
            {

                MessageBox.Show("连接失败！");
                return;
            }
            pic_Lndicator_light.Visible = true;
            //MessageBox.Show("连接成功！");

        }

        //语音识别完成事件
        private void RecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //做处理

            string info = e.Result.Text;

            
            switch (e.Result.Text)
            {
                case "发送":
                    btn_Datawriting_M_Click(null, null);
                    break;
                //case "停止":
                //    List<byte> SendCommand = new List<byte>();

                //    SendCommand.Add(0x01);

                //    SendCommand.Add(0x15);

                //    SendCommand.Add(0x00);
                //    SendCommand.Add(0X01);

                //    SendCommand.Add(0x00);
                //    SendCommand.Add(0x0a);

                //    //写入长度
                //    SendCommand.Add((byte)(iLength / 256));
                //    SendCommand.Add((byte)(iLength % 256));

                //    //字节数
                //    SendCommand.Add(0x02);

                //    //写入数据
                //    SendCommand.Add((byte)(iData % 256));
                //    SendCommand.Add((byte)(iData / 256));

                //    //CRC校验
                //    SendCommand.AddRange(Crc16(SendCommand.ToArray(), SendCommand.Count));

                //    //发送报文
                //    MyCom.Write(SendCommand.ToArray(), 0, SendCommand.Count);
                //    break;

                default:
                    break;
            }



        }


        /// <summary>
        /// 断开按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DisConn_Click(object sender, EventArgs e)
        {
            objModbus.DisConnect();
            pic_Lndicator_light.Visible = false;
        }

        /// <summary>
        /// 读取按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
             byte[] res = objModbus.ReadOutputStatus(Convert.ToByte(this.txt_Slave.Text), Convert.ToUInt16(this.txt_Start.Text), Convert.ToUInt16(this.txt_Length.Text));

            //bool[] boolRes = GetBitArrayFormByteArray(res);
            if (res != null)
            {
                bool[] boolRes = GetBitArrayFormByteArray(res);

                string result = string.Empty;

                for (int i = 0; i < Convert.ToUInt16(this.txt_Length.Text); i++)
                {
                    result += boolRes[i].ToString() + " ";
                }

                this.richTextBox1.AppendText(result.Trim() + Environment.NewLine);
            }
            }
            catch (Exception)
            {

                return;
            }



        }


        /// <summary>
        /// 将一个字节转换成布尔数组
        /// </summary>
        /// <param name="b">字节</param>
        /// <param name="reverse">位顺序</param>
        /// <returns>布尔数组</returns>
        private  bool[] GetBitArrayFormByte(byte b, bool reverse= false)
        {
            bool[] array = new bool[8];

            if (reverse)
            {
                for(int i =7;i >= 0; i--)
                {
                    //对于byte的每bit进行判定
                    array[i] = (b & 1) == 1;  //判定byte的最后一位是否为1，若为1，则是true，否则是false
                    b = (byte)(b >> 1);   //将byte右移一位
                }
            }
            else
            {
                for(int i = 0; i <= 7; i++)
                {
                  //对于byte的每bit进行判定
                    array[i] = (b & 1) == 1;  //判定byte的最后一位是否为1，若为1，则是true，否则是false
                    b = (byte)(b >> 1);  //将byte右移一位
                }
            }
            return array;
        }

        /// <summary>
        /// 将一个字节数组转换成布尔数组
        /// </summary>
        /// <param name="b">字节数组</param>
        /// <param name="reverse">位顺序</param>
        /// <returns>布尔数组</returns>
        private bool[] GetBitArrayFormByteArray(byte[] b, bool reverse = false)
        {
            List<bool> res = new List<bool>();

            foreach (var item in b)
            {
                res.AddRange(GetBitArrayFormByte(item, reverse));
            }
            return res.ToArray();
        }


        /// <summary>
        /// 连续读取按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_Continuous_read_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_Continuous_read.Checked == true)
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

        //定时器到达预设值触发的事件
        private void tim_Continuity_Tick(object sender, EventArgs e)
        {
            #region 读取
            try
            {
byte[] res = objModbus.ReadOutputStatus(Convert.ToByte(this.txt_Slave.Text), Convert.ToUInt16(this.txt_Start.Text), Convert.ToUInt16(this.txt_Length.Text));

            //bool[] boolRes = GetBitArrayFormByteArray(res);
            if (res != null)
            {
                bool[] boolRes = GetBitArrayFormByteArray(res);

                string result = string.Empty;

                for (int i = 0; i < Convert.ToUInt16(this.txt_Length.Text); i++)
                {
                    result += boolRes[i].ToString() + " ";
                }

                this.richTextBox1.AppendText(result.Trim() + Environment.NewLine);

            }

            }
            catch (Exception)
            {

                return;
            }

            #endregion

        }

        /// <summary>
        /// 文本框自动向下滚动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionStart = this.richTextBox1.TextLength;
            this.richTextBox1.ScrollToCaret();
        }

        /// <summary>
        /// 计时器赋值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Continuous_time_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            try
            {
            tim_Continuity.Interval = Convert.ToInt32(txt_Continuous_time.Text);
            }
            catch (Exception)
            {

                    //MessageBox.Show("格式错误");
                    return;
            }
            }


        }

        /// <summary>
        /// M区发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Datawriting_M_Click(object sender, EventArgs e)
        {
            switch (this.com_Functioncode_M.Text)
            {
                case "0x0F":
                    this.com_Functioncode_M.Text = "15";
                    break;
            }

            objModbus.ReadOutputStatus_M(Convert.ToByte(this.txt_Slave_M.Text), Convert.ToUInt16(this.com_Functioncode_M.Text), Convert.ToUInt16(this.txt_Start_M.Text), Convert.ToUInt16(this.txt_Length_M.Text), Convert.ToUInt16(this.txt_Datawriting_M.Text));
        }

        //开始说话
        private void btn_start_Click(object sender, EventArgs e)
        {
            recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
            this.btn_start.Enabled = false;
            this.btn_stop.Enabled = true;
        }

        //停止说话
        private void btn_stop_Click(object sender, EventArgs e)
        {
            recognitionEngine.RecognizeAsyncStop();
            this.btn_start.Enabled = true;
            this.btn_stop.Enabled = false;
        }
    }
}
