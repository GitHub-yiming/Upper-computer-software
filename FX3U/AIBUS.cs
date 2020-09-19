using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace FX3U
{
    public class AIBUS
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

        //关闭串口
        public void DisConnect()
        {
            //先判断
            if (MyCom.IsOpen)
            {
                MyCom.Close();
            }
        }


        public Param ReadParam(int Devadd,byte ParamID)
        {

            List<byte> Send = new List<byte>();

            //第一步：拼接报文

            //读取参数：地址代号(重复的2个字节)  +  52H（82）+  要读的参数代号  +  00  +  00  +  校验码

            //地址代号（重复的2个字节）

            Send.Add((byte)(128 + Devadd));
            Send.Add((byte)(128 + Devadd));

            //固定值
            Send.Add(82);

            //要读的参数代号
            Send.Add(ParamID);

            //00  +  00
            Send.Add(0);
            Send.Add(0);

            //校验码
            byte[] sum = GetSendSum(Devadd, ParamID);
            Send.AddRange(sum);

            //第二步：发送报文
            MyCom.Write(Send.ToArray(), 0, Send.Count);

            //第三步：接收报文
            Thread.Sleep(50);
            byte[] readBuffer = new byte[MyCom.BytesToRead];
            MyCom.Read(readBuffer, 0, readBuffer.Length);

            //第四步：解析报文





        }

        /// <summary>
        /// 发送的校验和
        /// </summary>
        /// <param name="DevAdd"></param>
        /// <param name="ParamID"></param>
        /// <returns></returns>
        private byte[] GetSendSum(int DevAdd,byte ParamID)
        {

           int  sum = ParamID * 256 + 82 + DevAdd;
            byte[] result = new byte[2];
            result[0] = (byte)(sum % 256);
            result[1] = (byte)(sum / 256);

            return result;
        }







        }



    }

