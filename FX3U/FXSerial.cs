using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace FX3U
{
    public class FXSerial
    {
        private SerialPort MyCom = new SerialPort();

        ///9600 N 8 1 端口号
        public bool Connect(string PortNum, int BaudRate, Parity Parity, int DataBits, StopBits StopBits)
        {
            //设置串口属性
            MyCom.PortName = PortNum; //端口号
            MyCom.BaudRate = BaudRate; //波特率
            MyCom.Parity = Parity; //奇偶校验
            MyCom.DataBits = DataBits; //数据位
            MyCom.StopBits = StopBits; //停止位

            //打开串口
            try
            {
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


        /// <summary>
        /// 给某个变量置位
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool ForceON(string address)
        {
            //第一步：拼接报文
            //用数组实现
            byte[] send = new byte[9];

            send[0] = 0x02;

            send[1] = 0x37;

            //地址
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



            //第二部：发送报文

            MyCom.Write(send, 0, send.Length);

            //第三部：接收报文



            //第四部：验证报文


            return true;

        }

        public bool ForceOFF(string address)
        {
            //第一步：拼接报文
            //用数组实现
            byte[] send = new byte[9];

            send[0] = 0x02;

            send[1] = 0x38;

            //地址
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



            //第二部：发送报文

            MyCom.Write(send, 0, send.Length);

            //第三部：接收报文



            //第四部：验证报文


            return true;

        }

        //获取PLC地址
        private byte[] AnalysisAddress(string address)
        {
            //address 有可能是 y0 m0 s0

            //拿到第一个字符并转换成大写

            string storeArea = address.Substring(0, 1).ToUpper();

            ushort result = 0;

            string addressValue=string.Empty;

            switch (storeArea)
            {
                case "Y":
                    //拿地址的数值
                    addressValue = address.Substring(1);



                    //转换成8进制
                    result = (ushort)Convert.ToInt16(0x500 + Convert.ToInt32(addressValue, 8));

                    break;
                case "M":



                    break;
                case "S":
                    break;
                default:
                    break;
            }

            return Encoding.ASCII.GetBytes(result.ToString("X4"));
        }

       //校验和计算
       private byte[] SUM(byte[] data,int start,int length)
        {

            //data 6个字节    1开始3个    123
            int sum = 0;
            
            for(int i = 1; i < start+length; i++)
            {
                sum += data[i];
            }

            byte b = (byte)sum;

            return Encoding.ASCII.GetBytes(b.ToString("X2"));


        }

    }


    }

