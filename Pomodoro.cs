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
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private IntPtr HT_CAPTION = (IntPtr)0x2;
        private const int POMODORO_TRABAJO = 0x019;
        private const int POMODORO_DESCANSO = 0x005;
        private bool banderaBoton25;
        private int cuentaAntesCierre;
        private System.Timers.Timer myTimer;
        private string tituloMensaje = "Fin Pomodoro!!!";
        private System.DateTime dtmTiempoAuxiliar;
        private System.DateTime dtmTiempoActualizado;
        //private const UInt32 WM_CLOSE = 0x0082;//0x0010;
        private const UInt32 WM_DESTROY = 0x0082;
        private const string WM_MSGBOXE = "#32770";

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Pomodoro()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            lblTiempo.Text = "00:00";
            this.Opacity = 1 - 0.5;
            this.TopMost = true;
            banderaBoton25 = false;
            PlaceLowerRight();
        }

        private void btn25Minutos_Click(object sender, System.EventArgs e)
        {
            dtmTiempoAuxiliar = new DateTime(1901, 1, 1, 1, 0, 0);//24 min, 55 segundos, coloco para pruebas en desarrollo
            dtmTiempoActualizado = new DateTime(1901, 1, 1, 1, 0, 0);
            dtmTiempoActualizado = dtmTiempoActualizado.AddMinutes(POMODORO_TRABAJO);//(POMODORO_TRABAJO);
            lblTiempo.Text = dtmTiempoActualizado.ToString("mm:ss");
            banderaBoton25 = true;

            timerControlTiempo.Start();
        }

        private void btn5Minutos_Click(object sender, System.EventArgs e)
        {
            dtmTiempoAuxiliar = new DateTime(1901, 1, 1, 1, 0, 0);//4,55 segundos, coloco para pruebas en desarrollo
            dtmTiempoActualizado = new DateTime(1901, 1, 1, 1, 0, 0);
            dtmTiempoActualizado = dtmTiempoActualizado.AddMinutes(POMODORO_DESCANSO);//(POMODORO_DESCANSO);
            lblTiempo.Text = dtmTiempoActualizado.ToString("mm:ss");
            banderaBoton25 = false;

            timerControlTiempo.Start();
        }

        private void timerControlTiempo_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            dtmTiempoActualizado = dtmTiempoActualizado.Subtract(new TimeSpan(0, 0, 0, 1));
            lblTiempo.Text = dtmTiempoActualizado.ToString("mm:ss");
            if (dtmTiempoActualizado.Minute < 1)
            {
                //ctmMenu.
                ntfPomodoro.Visible = true;
                ntfPomodoro.Text = "Menos de 1 minuto para finalizar";
                ntfPomodoro.ContextMenu = this.ctmMenu;

                if (lblTiempo.ForeColor == System.Drawing.Color.SteelBlue)
                {
                    lblTiempo.ForeColor = System.Drawing.Color.Navy;
                }
                else
                {
                    lblTiempo.ForeColor = System.Drawing.Color.SteelBlue;
                }
            }
            if (dtmTiempoActualizado <= dtmTiempoAuxiliar)
            {
                timerControlTiempo.Stop();
                int tiempo = (banderaBoton25 == true) ? POMODORO_TRABAJO : POMODORO_DESCANSO;
                int tiempo2 = (tiempo == POMODORO_DESCANSO) ? POMODORO_TRABAJO : POMODORO_DESCANSO;
                //MessageBox.Show("Fin del tiempo "+tiempo,tituloMensaje,MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1,MessageBoxOptions.DefaultDesktopOnly);
                ShowAutoClosingMessageBox("Fin del tiempo " + tiempo + Environment.NewLine + "Desea continuar con un nuevo ciclo " + tiempo2.ToString(), tituloMensaje, tiempo2);
            }
            Application.DoEvents();
        }

        private void ShowAutoClosingMessageBox(string message, string caption, int tiempo2)
        {
            myTimer = new System.Timers.Timer(1000);
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.myTimer_Elapsed);
            myTimer.Enabled = true;
            DialogResult resultado = MessageBox.Show(message, tituloMensaje, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (resultado == DialogResult.Yes)
            {
                if (tiempo2 == POMODORO_TRABAJO)
                {
                    btn25Minutos_Click(null, null);
                    btn25Minutos.Focus();
                }
                else
                {
                    btn5Minutos_Click(null, null);
                    btn5Minutos.Focus();
                }
            }
            myTimer.Enabled = false;
            cuentaAntesCierre = 0;
        }
        private void myTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (cuentaAntesCierre >= 10)//10 segundos antes del cierre autom�tico
            {
                IntPtr hWnd = FindWindow(WM_MSGBOXE, tituloMensaje);
                if (hWnd != IntPtr.Zero) SendMessage(hWnd, WM_DESTROY, IntPtr.Zero, IntPtr.Zero);
                System.Console.WriteLine("Prueba " + DateTime.Now.ToString());
                myTimer.Enabled = false;
                myTimer.Dispose();
                cuentaAntesCierre = 0;
            }
            cuentaAntesCierre += 1;
        }

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ProcesarVentana(sender, e);
        }

        private void lblTiempo_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
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
                RedimensionarVentana();
            }
            if (e.Button == MouseButtons.Right)
            {
                ctmMenu.Show(lblTiempo, new Point(e.X, e.Y));
            }
        }

        private void RedimensionarVentana()
        {
            if (this.Width >= 176)
            {
                this.ClientSize = new System.Drawing.Size(144, 50);
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(176, 60);
            }
        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            RedimensionarVentana();
        }

        private void menuItemSalir_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro desea salir?", "Confirmación", MessageBoxButtons.YesNo);
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
            MessageBox.Show("Aplicativo Pomodoro 25/5" +
                Environment.NewLine +
                "Autor: Victor Velepucha" +
                Environment.NewLine +
                "Uso gratuito",
                "PomodoroVic");
        }

        private void menuItemMostrarOcultarTitulo_Click(object sender, System.EventArgs e)
        {
            if (menuItemMostrarOcultarTitulo.Checked)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                menuItemMostrarOcultarTitulo.Checked = false;
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                menuItemMostrarOcultarTitulo.Checked = true;
            }
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
