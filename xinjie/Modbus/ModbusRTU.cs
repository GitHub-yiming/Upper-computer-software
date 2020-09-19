using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace Modbus
{
    public class ModbusRTU
    {
        #region Filed

        //创建串口对象

        private SerialPort MyCom;

        #endregion

        #region Property

        //串口读取超时时间
        public int RcvTimeOut { get; set; } = 1000;

        #endregion

        #region Methods
        /// <summary>
        /// 连接串口的方法
        /// </summary>
        /// <param name="iPortName"></param>
        /// <param name="iBaudRate"></param>
        /// <param name="iParty"></param>
        /// <param name="IdataBits"></param>
        /// <param name="iStopBits"></param>
        public void Connect(string iPortName, int iBaudRate, Parity iParity, int iDataBits, StopBits iStopBits)
        {
            //实例化串口对象
            MyCom = new SerialPort(iPortName, iBaudRate, iParity, iDataBits, iStopBits);

            //MyCom.DataReceived += MyCom_DataReceived;

            if (MyCom.IsOpen)
            {
                MyCom.Close();
            }

            MyCom.Open();

        }

        //private void MyCom_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
 
        //}


        //关闭串口
        public void DisConnect()
        {
            if (MyCom.IsOpen)
            {
                MyCom.Close();
            }
        }


        /// <summary>
        /// 报文拼接
        /// </summary>
        /// <param name="iDevAdd">从站地址</param>
        /// <param name="iAddress">开始地址</param>
        /// <param name="iLength">读取长度</param>
        /// <returns></returns>
        public byte[] ReadOutputStatus(byte iDevAdd, ushort iAddress, ushort iLength)
        {

            //拼接报文

            List<byte> SendCommand = new List<byte>();

            SendCommand.Add(iDevAdd);

            SendCommand.Add(0x01);

            //地址计算
            //SendCommand.Add((byte)(iAddress / 256)); //高位
            //SendCommand.Add((byte)(iAddress % 256)); //低位
            ushort kk = iAddress;
            ushort dd = 18432;
            int  cc = dd + kk;

            SendCommand.Add((byte)(cc / 256));  //高位     针对信捷做的改变
            SendCommand.Add((byte)(cc % 256)); //低位

            SendCommand.Add((byte)(iLength / 256));
            SendCommand.Add((byte)(iLength % 256));

            //byte[] crc = Crc16(SendCommand.ToArray(), SendCommand.Count);

            //SendCommand.AddRange(crc);

            //把CRC追加到最后
            SendCommand.AddRange(Crc16(SendCommand.ToArray(), SendCommand.Count));

            #region 折叠

            //MyCom.Write(SendCommand.ToArray(), 0, SendCommand.Count);



            ////串口接收事件

            //MemoryStream ms = new MemoryStream();

            //DateTime start = DateTime.Now;

            //byte[] buffer = new byte[1024];

            //while (true)
            //{
            //    Thread.Sleep(20);

            //    if (MyCom.BytesToRead > 0)
            //    {
            //        int count = MyCom.Read(buffer, 0, buffer.Length);

            //        ms.Write(buffer, 0, count);
            //    }
            //    else
            //    {
            //        if ((DateTime.Now - start).TotalMilliseconds > this.RcvTimeOut)
            //        {
            //            ms.Dispose();
            //            return null;
            //        }
            //        else if (ms.Length > 0)
            //        {
            //            break;
            //        }
            //    }
            //}

            //byte[] response = ms.ToArray();

            #endregion

            byte[] response = null;

            int byteLength = iLength % 8 == 0 ? iLength / 8 : iLength / 8 + 1;


            if (SendAndReceive(SendCommand.ToArray(), ref response))
            {
                //验证收到的数据是否正确
                if(response.Length==5+ byteLength)
                {
                    if (response[0] == iDevAdd && response[1] == 0x01 && response[2] == byteLength && CheckCRC(response))
                    {
                        //加个CRC校验
                        return GetByteArray(response, 3, response.Length - 5);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
            return null;
            }


        }

        /// <summary>
        /// 截取数据
        /// </summary>
        /// <param name="source">从站的数据</param>
        /// <param name="start">截取位置</param>
        /// <param name="count">线圈数据</param>
        /// <returns></returns>
        private byte[] GetByteArray(byte[] source,int start,int count)
        {

            if (source == null || source?.Length <= 0) return null;

            if (start < 0 || count < 0) return null;

            if (source.Length < start + count) return null;

            byte[] result = new byte[count];

            Array.Copy(source, start, result, 0, count);

            return result;

        }


        private bool CheckCRC(byte[] response)
        {
            byte[] crc = Crc16(response, response.Length - 2);

            if (crc[0] == response[response.Length - 2] && crc[1] == response[response.Length - 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 串口接收
        /// </summary>
        /// <param name="send"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        private bool SendAndReceive(byte[] send,ref byte[] response)
        {
            try
            {
            MyCom.Write(send,0,send.Length); //从串口接收
        
            //串口接收事件

            MemoryStream ms = new MemoryStream(); //内存

            DateTime start = DateTime.Now;

            byte[] buffer = new byte[1024];

            while (true)
            {
                Thread.Sleep(20); //挂起延时线程

                if (MyCom.BytesToRead > 0)
                {
                    int count = MyCom.Read(buffer, 0, buffer.Length);

                    ms.Write(buffer, 0, count);
                }
                else
                {
                    if ((DateTime.Now - start).TotalMilliseconds > this.RcvTimeOut)
                    {
                        ms.Dispose();
                        return false;
                    }
                    else if (ms.Length > 0)
                    {
                       
                        break;
                    }
                }
            }

            response = ms.ToArray();
            return true;
            }
            catch (Exception)
            {

                return false;
            }



        }


        #endregion


        #region M区数据写入

        /// <summary>
        /// M区数据写入
        /// </summary>
        /// <param name="iDevAdd">从站地址</param>  /// 
        /// <param name="Functioncode">功能码</param>
        /// <param name="iAddress">开始地址</param>
        /// <param name="iLength">写入长度</param>
        /// <param name="iData">写入数据</param>
        /// <returns></returns>
        public byte[] ReadOutputStatus_M(byte iDevAdd, ushort Functioncode , ushort iAddress, ushort iLength, ushort iData)
        {
            //报文拼接

                List<byte> SendCommand = new List<byte>();

            //先做功能码的判断
            if (Functioncode == 15)
            {

                //从站地址
                SendCommand.Add(iDevAdd);

                //功能码
                SendCommand.Add((byte)Functioncode);

                //开始地址
                SendCommand.Add((byte)(iAddress / 256));
                SendCommand.Add((byte)(iAddress % 256));

                //写入长度
                SendCommand.Add((byte)(iLength / 256));
                SendCommand.Add((byte)(iLength % 256));

                //字节数
                SendCommand.Add(0x02);

                //写入数据
                SendCommand.Add((byte)(iData % 256));
                SendCommand.Add((byte)(iData / 256));

                //CRC校验
                SendCommand.AddRange(Crc16(SendCommand.ToArray(), SendCommand.Count));

                //发送报文
                MyCom.Write(SendCommand.ToArray(), 0, SendCommand.Count);

            }

            return SendCommand.ToArray();
        }






        #endregion




        #region SendAndReceive折叠

        //       private bool SendAndReceive(byte[] send,ref byte[] response)
        //       {

        //           try
        //           {
        ////发送
        //           MyCom.Write(send, 0, send.Length);

        //           //接收
        //           MemoryStream ms = new MemoryStream();

        //           DateTime start = DateTime.Now;

        //           byte[] buffer = new byte[1024];

        //           while (true)
        //           {
        //               Thread.Sleep(20);

        //               if (MyCom.BytesToRead > 0)
        //               {
        //                   int count = MyCom.Read(buffer,0,buffer.Length);

        //                   ms.Write(buffer, 0, count);
        //               }
        //               else
        //               {
        //                   if ((DateTime.Now - start).TotalMilliseconds > this.RcvTimeOut)
        //                   {
        //                       ms.Dispose();
        //                       return false;
        //                   }
        //                   else if(ms.Length>0)
        //                   {
        //                       break;
        //                   }
        //               }
        //           }
        //           response = ms.ToArray();
        //           return true;
        //           }
        //           catch (Exception)
        //           {
        //               return false;
        //           }

        //       }

        #endregion

        #region CRC校验

        private static readonly byte[] aucCRCHi =
        {
0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
0x00, 0xC1, 0x81, 0x40



        };

        private static readonly byte[] aucCRCLo =
            {
0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 0x07, 0xC7,
0x05, 0xC5, 0xC4, 0x04, 0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E,
0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09, 0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9,
0x1B, 0xDB, 0xDA, 0x1A, 0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC,
0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32,
0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4, 0x3C, 0xFC, 0xFD, 0x3D,
0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A, 0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38,
0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 0x2E, 0x2F, 0xEF,
0x2D, 0xED, 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 0x61, 0xA1,
0x63, 0xA3, 0xA2, 0x62, 0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4,
0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F, 0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB,
0x69, 0xA9, 0xA8, 0x68, 0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA,
0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0,
0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92, 0x96, 0x56, 0x57, 0x97,
0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C, 0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E,
0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98, 0x88, 0x48, 0x49, 0x89,
0x4B, 0x8B, 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 0x43, 0x83,
0x41, 0x81, 0x80, 0x40


        };

        private byte[] Crc16(byte[] pucFrame, int usLen)
        {
            int i = 0;
            byte[] res = new byte[2] { 0xFF, 0xFF };

            UInt16 iIndex = 0x0000;

            while (usLen-- > 0)
            {
                iIndex = (UInt16)(res[0] ^ pucFrame[i++]);
                res[0] = (byte)(res[1] ^ aucCRCHi[iIndex]);
                res[1] = aucCRCLo[iIndex];
            }
            return res;
        }

        private void CalculateCRC(byte[] pByte, int nNumberOfBytes, out ushort pChecksum)
        {
            int nBit;
            ushort nShiftedBit;
            pChecksum = 0xFFFF;

            for(int nByte = 0; nByte < nNumberOfBytes; nByte++)
            {
                pChecksum ^= pByte[nByte];
                for (nBit = 0; nBit < 8; nBit++)
                {
                    if ((pChecksum & 0x01) == 1)
                    {
                        nShiftedBit = 1;
                    }
                    else
                    {
                        nShiftedBit = 0;
                    }
                    pChecksum >>= 1;
                    if (nShiftedBit != 0)
                    {
                        pChecksum ^= 0xA001;
                    }
                }
            }
        }


        private void CalculateCRC(byte[] pByte,int nNumberOfBytes,out byte  hi,out byte lo)
        {
            ushort sum;
            CalculateCRC(pByte, nNumberOfBytes, out sum);
            lo = (byte)(sum & 0xFF);
            hi = (byte)((sum & 0xFF00) >> 8);
        }


        #endregion


    }
}
