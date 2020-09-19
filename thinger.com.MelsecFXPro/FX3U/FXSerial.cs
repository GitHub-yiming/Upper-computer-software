using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FX3U
{
    public class FXSerial
    {
        public FXSerial()
        {
            MyCom = new SerialPort();
        }

        private SerialPort MyCom = null;

        /// <summary>
        /// 9600 N 8 1 端口号
        /// </summary>
        /// <returns></returns>
        public bool Connect(string PortNum, int BaudRate, Parity Parity, int DataBits, StopBits StopBits)
        {
            //设置属性
            MyCom.PortName = PortNum;
            MyCom.BaudRate = BaudRate;
            MyCom.Parity = Parity;
            MyCom.DataBits = DataBits;
            MyCom.StopBits = StopBits;
            try
            {
                //打开串口
                MyCom.Open();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


        public void DisConnect()
        {
            //先判断
            if (MyCom.IsOpen)
            {
                MyCom.Close();
            }
        }

        #region 强制写入


        byte[] buffer = new byte[19];



        /// <summary>
        /// 给某个变量置位
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool ForceON(string address)
        {
            try
            {
            //第一步：拼接报文

            //数组 或者 集合

            byte[] send = new byte[9];

            send[0] = 0x02;

            send[1] = 0x37;

            //地址      //我给你一个字符串，你还我一个字节数组（4个）

            byte[] result = AnalysisAddress(address);

            send[2] = result[2];
            send[3] = result[3];
            send[4] = result[0];
            send[5] = result[1];

            send[6] = 0x03;

            //校验和

            byte[] sum = SUM(send, 1, 6);

            send[7] = sum[0];
            send[8] = sum[1];

            //第二步：发送报文

            MyCom.Write(send, 0, send.Length);

                Thread.Sleep(20);

                //第三步：接收报文
                if (MyCom.BytesToRead > 0)
                {
                    int count = MyCom.Read(buffer, 0, buffer.Length);

                }

                //第四步：验证报文

                if (buffer[0] != 06 || buffer[0]==0)
                {
                     MessageBox.Show("返回的数据不是0X06，请检查通信线缆是否有干扰！！");
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }



        }


        public bool ForceOFF(string address)
        {

            try
            {
                //第一步：拼接报文

                //数组 或者 集合

                byte[] send = new byte[9];

                send[0] = 0x02;

                send[1] = 0x38;

                //地址      //我给你一个字符串，你还我一个字节数组（4个）

                byte[] result = AnalysisAddress(address);

                send[2] = result[2];
                send[3] = result[3];
                send[4] = result[0];
                send[5] = result[1];

                send[6] = 0x03;

                //校验和

                byte[] sum = SUM(send, 1, 6);

                send[7] = sum[0];
                send[8] = sum[1];

                //第二步：发送报文

                MyCom.Write(send, 0, send.Length);

                Thread.Sleep(20);

                //第三步：接收报文
                if (MyCom.BytesToRead > 0)
                {
                    int count = MyCom.Read(buffer, 0, buffer.Length);

                }

                //第四步：验证报文

                if (buffer[0] != 06)
                {
                    MessageBox.Show("返回的数据不是0X06，请检查通信线缆是否有干扰！！");
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }


        /// <summary>
        /// 地址识别
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        /// 
        private byte[] AnalysisAddress(string address)
        {

            try
            {
                //address   x0  y0  m10  s0  X0  Y10        Y8  Y9

                //拿第一个字符并转换成大写

                string storeArea = address.Substring(0, 1).ToUpper();

                ushort result = 0;

                string addressValue = string.Empty;

                switch (storeArea)
                {
                    case "Y":
                        //拿地址的数值
                        //string addressValue = address.Substring(1, address.Length - 1);

                        addressValue = address.Substring(1);

                        result = Convert.ToUInt16(0x500 + Convert.ToInt32(addressValue, 8));

                        break;

                    //case "X":

                    //     addressValue = address.Substring(1);

                    //    result = Convert.ToUInt16(0x400 + Convert.ToInt32(addressValue, 8));

                    //    break;

                    case "S":
                        addressValue = address.Substring(1);

                        result = Convert.ToUInt16(0x000 + Convert.ToInt32(addressValue, 8));


                        break;

                    case "D":
                        addressValue = address.Substring(1);
                        if (Convert.ToInt32( addressValue) <= 8000)
                        {
                            result =  Convert.ToUInt16(0x1000 + Convert.ToInt32(addressValue, 10)*2);
                        }
                        else
                        {
                            result = Convert.ToUInt16(0x0E00 + (Convert.ToInt32(addressValue, 10)-8000) * 2);
                        }
                        break;

                    default:
                        break;

                }
                return Encoding.ASCII.GetBytes(result.ToString("X4"));
            }
            catch (Exception)
            {

                return null;
            }

        }



        /// <summary>
        /// 数据识别
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        private byte[] Datarecognition(String Data)
        {

            //List<byte> bb = new List<byte>();

            int ii = 4 - Data.Length;

            string kk = "0";

            string bb = string.Empty;

            //string ff = string.Empty;

            if (Data == "")
            {
                Data += "0000";
            }
            else
            {
                for (int i = 0; i < ii; i++)
                {
                    bb += kk;

                }

            }

            ushort cc = 0;

            if (Data == "0000")
            {
                return Encoding.ASCII.GetBytes(Data);
            }
            else
            {
                cc = Convert.ToUInt16(Convert.ToInt32(Data.ToString(), 10));

                return Encoding.ASCII.GetBytes(bb+cc.ToString());


            }


        }

        private byte[] Data_number(String Data)
        {
            string storeData = Data;

            ushort result = 0;
            //result = Convert.ToUInt16(0x1000 + Convert.ToInt32(addressValue, 10) * 2);

            //ushort ii = 0;

            //ii = Convert.ToUInt16(Data);

            result = Convert.ToUInt16(Convert.ToInt32(Data,10)*2);

            return Encoding.ASCII.GetBytes(result.ToString("X2"));

        }



        /// <summary>
        /// 累加校验和
        /// </summary>
        /// <param name="data">数组长度</param>
        /// <param name="start">数组要从哪里开始索引</param>
        /// <param name="length">索引的长度</param>
        /// <returns></returns>
        private byte[] SUM(byte[] data, int start, int length)
        {
            //data  6个字节    1开始3个    1 2 3

            int sum = 0;

            for (int i = start; i <= start + length-2; i++)
            {
                sum += data[i];
            }

            //byte[] b = new byte[] {}

            byte b = (byte)sum;



            return Encoding.ASCII.GetBytes(b.ToString("X2"));

        }


        #endregion


        #region Y区

        #endregion

        #region D区

        /// <summary>
        /// 将要发送的报文拼接
        /// </summary>
        /// <param name="address">D区地址</param>
        /// <param name="txt_Data_D">要写进D区的数据</param>
        /// <param name="txt_Data_number">写入D区的地址个数</param>
        /// <returns></returns>
        public bool btn_Write_D (String address, String txt_Data_D,String txt_Data_number)
        {
            List<byte> send = new List<byte>();


            //地址，功能码
            send.Add(0x02);
            send.Add(0x31);

            //地址

            byte[] result = AnalysisAddress(address);

            send.Add(result[0]);
            send.Add(result[1]);
            send.Add(result[2]);
            send.Add(result[3]);


            //字节数
            byte[] Data_number_D = Data_number(txt_Data_number);

            send.Add(Data_number_D[0]);
            send.Add(Data_number_D[1]);

            //数据
            byte[] Data_result = Datarecognition(txt_Data_D);

            //for(int i = 0; i >= Data_result.Length; i++)
            //{
            //send.Add(Data_result[i]);
            //}



            send.Add(Data_result[2]);
            send.Add(Data_result[3]);
            send.Add(Data_result[0]);
            send.Add(Data_result[1]);


            //结束

            send.Add(0x03);



            //校验和

            byte[] aa = SUM(send.ToArray(), 1, send.Count);

            send.AddRange(aa);

            //byte[] sum = SUM(send, 1, 12);

            //send[13] = sum[0];
            //send[14] = sum[1];

            //发送报文


            byte[] ee = send.ToArray();

            MyCom.Write(ee, 0, send.Count);
            



            return true;
        }

        #endregion

    }
}

