using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PomodoroVic
{
    public partial class Notificador : Form
    {
        #region private Members
        private string strInfo; // the info to b shown in the GmailNotifierControl
        private int nInterval = 75; //75, the interval for moving the GmailNotifierControl
        private bool bHide = false;
        private bool bFinished = false;
        private int nPitch = 4;
        private int nTimeOut = 10;
        #endregion
        public Notificador()
        {
            InitializeComponent();
        }
        public int TimeOut
        {
            get
            {
                return this.nTimeOut / 1000;
            }
            set
            {
                if (value <= 0) value = 3;
                this.nTimeOut = value * 1000;
                this.tmrEnd.Interval = value * 1000;
            }
        }

        public string Info
        {
            get
            {
                return this.strInfo;
            }
            set
            {
                this.lblInfo.Text = value;
                this.strInfo = value;
                this.Refresh();
            }
        }

        public int Interval
        {
            get
            {
                return this.nInterval;
            }
            set
            {
                this.nInterval = value;
                this.tmrMove.Interval = value;
            }
        }

        private void tmrMove_Tick(object sender, System.EventArgs e)
        {
            if (!bHide) // Show the Info Box
            {
                this.Show();
                if (this.Top > Screen.PrimaryScreen.Bounds.Bottom - (this.Height + 30)) //scrren limit - 30 for the TaskBar
                {
                    this.Top -= nPitch;
                    bFinished = false;
                    this.Refresh();
                }
                else
                {
                    bFinished = true;
                    bHide = true;
                }
            }
            else if (!bFinished) // Hide It
            {
                if (this.Top < Screen.PrimaryScreen.Bounds.Bottom)
                {
                    this.Top += nPitch;
                    bFinished = false;
                    this.Refresh();
                }
                else
                {
                    bFinished = true;
                    bHide = false;
                    this.Hide();
                }
            }
            if (bFinished)
                tmrMove.Stop();
            if (bHide && bFinished)
                tmrEnd.Start();
        }

        private void tmrEnd_Tick(object sender, System.EventArgs e)
        {
            tmrEnd.Stop();
            HideMyInfo();
        }
        private void HideMyInfo()
        {
            bHide = true;
            bFinished = false;
            ShowInfo();
        }
        public void ShowInfo() // method to show the info in the GmailNotifierControl
        {
            if (!bHide) //the GmailNotifierControl is about to be shown we initialize its location
                this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - this.Size.Width - 50,
                    Screen.PrimaryScreen.Bounds.Bottom);
            lblInfo.Text = strInfo;
            //pctLogo.Image = imgList.Images[1];
            this.Show();
            tmrMove.Start();
        }
    }
}
