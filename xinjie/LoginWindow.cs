using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModbusDemo
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();

            CloseTimer.Interval = 10;
            CloseTimer.Tick += CloseTimer_Tick;
        }


        #region 淡出效果算法
        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            if(this.Opacity >= 0.025)
            {
                this.Opacity -= 0.025;
            }
            else
            {
                this.CloseTimer.Enabled = false;
                this.Close();
            }
        }

        #endregion

        //创建定时器
        private Timer CloseTimer = new Timer();

        #region 无边框拖动

        private Point mPoint;
        private void Pan_Title_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = e.Location;
        }

        private void Pan_Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);

            }
        }

        #endregion


        #region 窗口淡出效果

        /// <summary>
        /// 关闭淡出效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Close_Click(object sender, EventArgs e)
        {
            //开启定时器
            CloseTimer.Enabled = true;

        }

        #endregion

        private void btn_Login_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void txt_UserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btn_Login_Click(null, null);
            }
        }
    }
}
