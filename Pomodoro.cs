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
        private double valor;
        private System.DateTime dtmTiempoAuxiliar;
        private System.DateTime dtmTiempoActualizado;

        public Pomodoro()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            lblTiempo.Text = "00:00";
            label1.Text = lblTiempo.Text;//Temporal
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
            label1.Text = dtmTiempoAuxiliar.ToString("mm:ss");
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
            label1.Text = lblTiempo.Text;//Temporal
            timerControlTiempo.Stop();
        }

        private void trbOpacidad_Scroll(object sender, System.EventArgs e)
        {
            valor = trbOpacidad.Value;
            valor = 1 - (valor / 10);
            this.Opacity = valor;
            //MessageBox.Show(trbOpacidad.Value + "|" + this.Opacity.ToString());
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
    }
}
