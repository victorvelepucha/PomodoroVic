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
        private bool banderaBoton25;
        private System.DateTime dtmTiempoAuxiliar;
        private System.DateTime dtmTiempoActualizado;

        private const UInt32 WM_CLOSE = 0x0010;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [System.Runtime.InteropServices.DllImportAttribute("user32.Dll")]
        static extern int PostMessage(IntPtr hWnd, UInt32 msg, int wParam, int lParam);

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
            this.Opacity = 1 - 0.5;
            this.TopMost = true;
            banderaBoton25 = false;
            PlaceLowerRight();
        }

        private void btn25Minutos_Click(object sender, System.EventArgs e)
        {
            dtmTiempoAuxiliar = new DateTime(1901, 1, 1, 1, 0, 0);//24 min, 55 segundos, coloco para pruebas en desarrollo
            dtmTiempoActualizado = new DateTime(1901, 1, 1, 1, 0, 0);
            dtmTiempoActualizado = dtmTiempoActualizado.AddMinutes(25);//(25);
            lblTiempo.Text = dtmTiempoActualizado.ToString("mm:ss");
            banderaBoton25 = true;

            timerControlTiempo.Start();
        }

        private void btn5Minutos_Click(object sender, System.EventArgs e)
        {
            dtmTiempoAuxiliar = new DateTime(1901, 1, 1, 1, 0, 0);//4, 55 segundos, coloco para pruebas en desarrollo
            dtmTiempoActualizado = new DateTime(1901, 1, 1, 1, 0, 0);
            dtmTiempoActualizado = dtmTiempoActualizado.AddMinutes(5);//(5);
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
                string tiempo = (banderaBoton25 == true) ? "25" : "5";
                MessageBox.Show("Fin del tiempo " + tiempo, "Fin Pomodoro!!!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
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
            DialogResult result = MessageBox.Show("Seguro desea salir?", "Confirmaci�n", MessageBoxButtons.YesNo);
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
            //Determine "rightmost" screen
            Screen rightmost = Screen.AllScreens[0];
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                    rightmost = screen;
            }

            this.Left = rightmost.WorkingArea.Right - this.Width;
            this.Top = rightmost.WorkingArea.Bottom - this.Height;
        }

        public void ShowAutoClosingMessageBox(string message, string caption)
        {
            System.Timers.Timer timer = new System.Timers.Timer(5000);// { AutoReset = false };
            /*timer.Elapsed += delegate
							 {
			IntPtr hWnd = FindWindowByCaption(IntPtr.Zero, caption);
			if (hWnd.ToInt32() != 0) PostMessage(hWnd, WM_CLOSE, 0, 0);
					};*/
            timer.Enabled = true;
            MessageBox.Show(message, caption);
        }
    }
}
