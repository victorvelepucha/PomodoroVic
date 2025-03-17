﻿using System;
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
    /// <summary>
	/// Pomodoro. Autor: Victor Velepucha
	/// </summary>
    public partial class Pomodoro : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private IntPtr HT_CAPTION = (IntPtr)0x2;
        private const int POMODORO_TRABAJO = 0x019;
        private const int POMODORO_DESCANSO = 0x005;
        private bool banderaBoton25;
        private System.DateTime dtmTiempoAuxiliar;
        private System.DateTime dtmTiempoActualizado;

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Pomodoro()
        {
            InitializeComponent();
        }
        private void Pomodoro_Load(object sender, System.EventArgs e)
        {
            this.Opacity = 1 - 0.75;
            this.TopMost = true;
            banderaBoton25 = false;
            this.ntfPomodoro.Icon = this.Icon;
            lblFecha.Visible = false;
            ntfPomodoro.ContextMenu = this.ctmMenu;
            notifierInfo1.Interval = 75;
            notifierInfo1.TimeOut = 3;
            PlaceLowerRight();
        }

        private void menuItem25Minutos_Click(object sender, System.EventArgs e)
        {
            dtmTiempoAuxiliar = new DateTime(1901, 1, 1, 1, 0, 0);//24 min, 50 segundos, coloco para pruebas en desarrollo
            dtmTiempoActualizado = new DateTime(1901, 1, 1, 1, 0, 0);
            dtmTiempoActualizado = dtmTiempoActualizado.AddMinutes(POMODORO_TRABAJO);//(POMODORO_TRABAJO o 1);
            lblTiempo.ForeColor = System.Drawing.Color.SteelBlue;
            lblFecha.Visible = false;
            banderaBoton25 = true;

            timerControlTiempo.Start();
        }

        private void menuItem5Minutos_Click(object sender, System.EventArgs e)
        {
            dtmTiempoAuxiliar = new DateTime(1901, 1, 1, 1, 0, 0);//4,55 segundos, coloco para pruebas en desarrollo
            dtmTiempoActualizado = new DateTime(1901, 1, 1, 1, 0, 0);
            dtmTiempoActualizado = dtmTiempoActualizado.AddMinutes(POMODORO_DESCANSO);//(POMODORO_DESCANSO o 1);
            lblTiempo.ForeColor = System.Drawing.Color.Navy;
            lblFecha.Visible = false;
            banderaBoton25 = false;

            timerControlTiempo.Start();
        }

        private void timerControlTiempo_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            dtmTiempoActualizado = dtmTiempoActualizado.Subtract(new TimeSpan(0, 0, 0, 1));
            lblTiempo.Text = dtmTiempoActualizado.ToString("mm:ss");
            if (dtmTiempoActualizado.Minute < 1 && menuItemBlink.Checked)
            {
                if (banderaBoton25)
                {
                    if (lblTiempo.ForeColor == System.Drawing.Color.SteelBlue)
                    {
                        lblTiempo.ForeColor = System.Drawing.Color.Maroon;
                    }
                    else
                    {
                        lblTiempo.ForeColor = System.Drawing.Color.SteelBlue;
                    }
                }
                else
                {
                    if (lblTiempo.ForeColor == System.Drawing.Color.Navy)
                    {
                        lblTiempo.ForeColor = System.Drawing.Color.Maroon;
                    }
                    else
                    {
                        lblTiempo.ForeColor = System.Drawing.Color.Navy;
                    }
                }
            }
            if (dtmTiempoActualizado <= dtmTiempoAuxiliar)
            {
                timerControlTiempo.Stop();
                int tiempo = (banderaBoton25 == true) ? POMODORO_TRABAJO : POMODORO_DESCANSO;
                lblTiempo.ForeColor = System.Drawing.Color.Maroon;
                lblFecha.Text = "Finalizado a las " + DateTime.Now.ToString("hh:mm:ss");
                lblFecha.Visible = true;
                notifierInfo1.Info = "Fin del Pomodoro " + tiempo;
                notifierInfo1.ShowInfo();
                if (menuItemAutoSwitch.Checked)
                {
                    if (banderaBoton25)
                    {
                        menuItem5Minutos_Click(null, null);
                    }
                    else
                    {
                        menuItem25Minutos_Click(null, null);
                    }
                }

            }
            Application.DoEvents();
        }

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ProcesarVentana(sender, e);
        }

        private void lblTiempo_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ProcesarVentana(sender, e);
        }
        private void lblFecha_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ProcesarVentana(sender, e);
        }

        private void ProcesarVentana(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, IntPtr.Zero);
            }
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                ProcesarPomodoro();
            }
            if (e.Button == MouseButtons.Right)
            {
                ctmMenu.Show(lblTiempo, new Point(e.X, e.Y));
            }
        }

        private void ProcesarPomodoro()
        {
            lblFecha.Text = DateTime.Now.ToString("hh:mm:ss");
            if (banderaBoton25)
            {
                menuItem5Minutos_Click(null, null);
            }
            else
            {
                menuItem25Minutos_Click(null, null);
            }
        }

        private void menuItemAutoSwitch_Click(object sender, System.EventArgs e)
        {
            if (menuItemAutoSwitch.Checked)
            {
                menuItemAutoSwitch.Checked = false;
            }
            else
            {
                menuItemAutoSwitch.Checked = true;
            }
        }
        private void menuItemBlink_Click(object sender, System.EventArgs e)
        {
            if (menuItemBlink.Checked)
            {
                menuItemBlink.Checked = false;
            }
            else
            {
                menuItemBlink.Checked = true;
            }
        }

        private void menuItemSalir_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void menuItemAlwaysOnTop_Click(object sender, System.EventArgs e)
        {
            if (menuItemAlwaysOnTop.Checked)
            {
                this.TopMost = false;
                menuItemAlwaysOnTop.Checked = false;
            }
            else
            {
                this.TopMost = true;
                menuItemAlwaysOnTop.Checked = true;
            }
        }

        private void menuItemDetener_Click(object sender, System.EventArgs e)
        {
            lblTiempo.Text = "00:00";
            timerControlTiempo.Stop();
            lblFecha.Visible = false;
            banderaBoton25 = false;
        }

        private void menuItemMinimizar_Click(object sender, System.EventArgs e)
        {
            ntfPomodoro.Visible = true;
            this.ntfPomodoro.Text = "Doble clic para maximizar...";
            this.Hide();
        }
        private void ntfPomodoro_DoubleClick(object sender, System.EventArgs e)
        {
            this.Show();
            ntfPomodoro.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void ntfPomodoro_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.ntfPomodoro.Text = lblTiempo.Text;
        }

        private void menuItemTransp0_Click(object sender, System.EventArgs e)
        {
            this.Opacity = 1 - 0;
            menuItemTransp0.Checked = true;
            menuItemTransp25.Checked = false;
            menuItemTransp50.Checked = false;
            menuItemTransp75.Checked = false;
        }

        private void menuItemTransp25_Click(object sender, System.EventArgs e)
        {
            this.Opacity = 1 - 0.25;
            menuItemTransp0.Checked = false;
            menuItemTransp25.Checked = true;
            menuItemTransp50.Checked = false;
            menuItemTransp75.Checked = false;
        }

        private void menuItemTransp50_Click(object sender, System.EventArgs e)
        {
            this.Opacity = 1 - 0.5;
            menuItemTransp0.Checked = false;
            menuItemTransp25.Checked = false;
            menuItemTransp50.Checked = true;
            menuItemTransp75.Checked = false;
        }

        private void menuItemTransp75_Click(object sender, System.EventArgs e)
        {
            this.Opacity = 1 - 0.75;
            menuItemTransp0.Checked = false;
            menuItemTransp25.Checked = false;
            menuItemTransp50.Checked = false;
            menuItemTransp75.Checked = true;
        }

        private void menuItemAcercaDe_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Pomodoro 25/5" +
                Environment.NewLine + "Herramienta gratuita." +
                Environment.NewLine + "Autor: Victor Velepucha" +
                Environment.NewLine +
                Environment.NewLine + "Doble clic para alternar entre pomodoros." +
                Environment.NewLine + "Tiempo en color celeste para Pomodoro 25 min." +
                Environment.NewLine + "Tiempo en color azul para Pomodoro 05 min.",
                "PomodoroVic!!!");
        }

        private void PlaceLowerRight()
        {
            Screen rightmost = Screen.AllScreens[0];
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                    rightmost = screen;
            }

            this.Left = rightmost.WorkingArea.Right - this.Width;
            this.Top = rightmost.WorkingArea.Bottom - this.Height;
        }
    }
}
