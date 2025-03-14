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
    public partial class Pomodoro : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private System.DateTime dtmTiempoAuxiliar;
        private System.DateTime dtmTiempoActualizado;
        private double valor;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Pomodoro()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            lblTiempo.Text = "00:00";
        }

        private void btn25Minutos_Click(object sender, System.EventArgs e)
        {
            dtmTiempoAuxiliar = new DateTime(1901, 1, 1, 1, 0, 0);//24 min, 55 segundos, coloco para pruebas en desarrollo
            dtmTiempoActualizado = new DateTime(1901, 1, 1, 1, 0, 0);
            dtmTiempoActualizado = dtmTiempoActualizado.AddMinutes(25);
            lblTiempo.Text = dtmTiempoActualizado.ToString("mm:ss");

            timerControlTiempo.Start();
        }

        private void btn5Minutos_Click(object sender, System.EventArgs e)
        {
            dtmTiempoAuxiliar = new DateTime(1901, 1, 1, 1, 0, 0);//4, 55 segundos, coloco para pruebas en desarrollo
            dtmTiempoActualizado = new DateTime(1901, 1, 1, 1, 0, 0);
            dtmTiempoActualizado = dtmTiempoActualizado.AddMinutes(5);
            lblTiempo.Text = dtmTiempoActualizado.ToString("mm:ss");

            timerControlTiempo.Start();
        }

        private void timerControlTiempo_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            dtmTiempoActualizado = dtmTiempoActualizado.Subtract(new TimeSpan(0, 0, 0, 1));
            lblTiempo.Text = dtmTiempoActualizado.ToString("mm:ss");
            if (dtmTiempoActualizado <= dtmTiempoAuxiliar)
            {
                timerControlTiempo.Stop();
                MessageBox.Show("Fin del tiempo", "Fin Pomodoro!!!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            Application.DoEvents();
        }

        private void btnDetener_Click(object sender, System.EventArgs e)
        {
            lblTiempo.Text = "00:00";
            timerControlTiempo.Stop();
        }

        private void trbOpacidad_Scroll(object sender, System.EventArgs e)
        {
            valor = trbOpacidad.Value;
            valor = 1 - (valor / 10);
            this.Opacity = valor;
        }

        private void chkAlwaysOnTop_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkAlwaysOnTop.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                ntfPomodoro.Visible = true;
                //ntfPomodoro.ShowBalloonTip(500);
                //this.ntfPomodoro.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info; //Shows the info icon so the user doesn't thing there is an error.
                //this.ntfPomodoro.BalloonTipText = "[Balloon Text when Minimized]";
                //this.ntfPomodoro.BalloonTipTitle = "[Balloon Title when Minimized]";
                this.ntfPomodoro.Text = "Doble clic para maximizar...";
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                ntfPomodoro.Visible = false;
            }
        }

        private void ntfPomodoro_DoubleClick(object sender, System.EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void ntfPomodoro_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.ntfPomodoro.Text = lblTiempo.Text;
        }

        private void Form1_DoubleClick(object sender, System.EventArgs e)
        {

        }

        private void lblTiempo_Click(object sender, System.EventArgs e)
        {

        }

        private void lblTiempo_DoubleClick(object sender, System.EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ProcesarVentana(sender, e);
        }

        private void lblTiempo_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ProcesarVentana(sender, e);
        }

        private void lblOpacidad_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ProcesarVentana(sender, e);
        }

        private void ProcesarVentana(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                RedimensionarVentana();
            }
        }

        private void RedimensionarVentana()
        {
            if (this.Width >= 328)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.ClientSize = new System.Drawing.Size(176, 60);

            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.ClientSize = new System.Drawing.Size(320, 122);
            }
        }
    }
}
