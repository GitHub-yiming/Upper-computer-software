using FX3U;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thinger.com.MelsecFXPro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //获取所有串口

            this.cmb_Port.DataSource = SerialPort.GetPortNames();
        }


        FXSerial objFX3U = new FXSerial();

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                objFX3U.Connect(cmb_Port.Text, Convert.ToInt32(cmb_Baud_rate.Text, 10), (Parity)Enum.Parse(typeof(Parity), cmb_Check_bits.Text), int.Parse(cmb_Data_bits.Text), (StopBits)Enum.Parse(typeof(StopBits), cmb_Stop_bit.Text));
            }
            catch (Exception)
            {

                MessageBox.Show("连接失败！！");
            }

            //Form1.ActiveForm.Text = "使用C#与三菱FX系列PLC通信  - -  连接成功";

            pic_Lndicator_light.Visible = true;
        }

        private void btn_DisConn_Click(object sender, EventArgs e)
        {
            objFX3U.DisConnect();

            Form1.ActiveForm.Text = "使用C#与三菱FX系列PLC通信";

            pic_Lndicator_light.Visible = false;
        }

        private void btn_ForceON_Click(object sender, EventArgs e)
        {
            objFX3U.ForceON(this.txt_Address.Text);
        }

        private void btn_ForceOFF_Click(object sender, EventArgs e)
        {
            objFX3U.ForceOFF(this.txt_Address.Text);



        }

        /// <summary>
        /// D区写入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Write_D_Click(object sender, EventArgs e)
        {
            objFX3U.btn_Write_D(this.txt_Address_D.Text, this.txt_Data_D.Text, txt_Data_number_D.Text);
        }
    }
}
