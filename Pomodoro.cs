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
        public Pomodoro()
        {
            InitializeComponent();
        }
        private void btn25Minutos_Click(object sender, System.EventArgs e)
        {
            //dtmTiempoAuxiliar = new DateTime(1901, 1, 1, 1, 0, 50);//Tiempo para pruebas en desarrollo
            dtmTiempoAuxiliar = new DateTime(1901, 1, 1, 1, 0, 0);////dtmTiempoAuxiliar = DateTime.Now; //Para pruebas en desarrollo
            dtmTiempoActualizado = new DateTime(1901, 1, 1, 1, 0, 0);
            //dtmTiempoAuxiliar = dtmTiempoAuxiliar.AddMinutes(4);//Temporal para pruebas en desarrollo
            //dtmTiempoActualizado = dtmTiempoActualizado.AddMinutes(1);//1 min para desarrollo
            dtmTiempoActualizado = dtmTiempoActualizado.AddMinutes(25);
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
                MessageBox.Show("Fin del tiempo", "Fin Pomodoro!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            //Application.DoEvents();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            lblTiempo.Text = "00:00";
            label1.Text = lblTiempo.Text;//Temporal
        }
    }
}
