using System;
using System.Drawing;
using System.IO;
using System.Media;
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
        private const int POMODORO_25 = 25;
        private const int POMODORO_5 = 5;
        private const int POMODORO_52 = 52;
        private const int POMODORO_17 = 17;
        private int POMODORO_EN_EJECUCION = 25;
        private string pathLog;
        private string variable;

        private System.DateTime dtmTiempoAuxiliar;
        private System.DateTime dtmTiempoActualizado;
        public string Variable { get => Variable1; set => Variable1 = value; }
        public string Variable1 { get => variable; set => variable = value; }

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
            pathLog = System.Environment.CurrentDirectory + "\\" + Application.ProductName + ".log";
            //Configuracion inicial
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["AppCulture"]);
            this.Opacity = 1 - Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["opacidad"]);
            this.TopMost = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["TopMost"]);
            menuItemAlwaysOnTop.Checked = this.TopMost;
            this.menuItemAutoSwitch.Checked = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["AutoSwitch"]);
            this.menuItemBlink.Checked = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["Blink"]); ;
            this.menuItemActivarLog.Checked = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["LogEnabled"]); ;
            int iniciarConTiempoPomodoro = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["IniciarConPomodoro"]);
            if (iniciarConTiempoPomodoro == POMODORO_25)
            {
                POMODORO_EN_EJECUCION = POMODORO_5;//Al hacer doble clic se hace switch y se coloca en POMODORO_25
                menuItem25Minutos.Checked = true;
                menuItem5Minutos.Checked = false;
                menuItem52Minutos.Checked = false;
                menuItem17Minutos.Checked = false;
            }
            else
            {
                POMODORO_EN_EJECUCION = POMODORO_17;
                menuItem25Minutos.Checked = false;
                menuItem5Minutos.Checked = false;
                menuItem52Minutos.Checked = true;
                menuItem17Minutos.Checked = false;
            }

            this.ntfPomodoro.Icon = this.Icon;
            //lblFecha.Visible=false;
            ntfPomodoro.ContextMenu = this.ctmMenu;
            notifierInfo1.Interval = 75;
            notifierInfo1.TimeOut = 3;
            PlaceLowerRight();
        }

        private void menuItem25Minutos_Click(object sender, System.EventArgs e)
        {
            menuItem25Minutos.Checked = true;
            menuItem5Minutos.Checked = false;
            menuItem52Minutos.Checked = false;
            menuItem17Minutos.Checked = false;
            ProcesarPomodoro(POMODORO_25);
        }

        private void menuItem5Minutos_Click(object sender, System.EventArgs e)
        {
            menuItem25Minutos.Checked = false;
            menuItem5Minutos.Checked = true;
            menuItem52Minutos.Checked = false;
            menuItem17Minutos.Checked = false;
            ProcesarPomodoro(POMODORO_5);
        }

        private void menuItem52Minutos_Click(object sender, System.EventArgs e)
        {
            menuItem25Minutos.Checked = false;
            menuItem5Minutos.Checked = false;
            menuItem52Minutos.Checked = true;
            menuItem17Minutos.Checked = false;
            ProcesarPomodoro(POMODORO_52);
        }

        private void menuItem17Minutos_Click(object sender, System.EventArgs e)
        {
            menuItem25Minutos.Checked = false;
            menuItem5Minutos.Checked = false;
            menuItem52Minutos.Checked = false;
            menuItem17Minutos.Checked = true;
            ProcesarPomodoro(POMODORO_17);
        }
        private void ProcesarPomodoro(int pomodoroAEjecutar)
        {
            POMODORO_EN_EJECUCION = pomodoroAEjecutar;
            dtmTiempoAuxiliar = new DateTime(1901, 1, 1, 1, 0, 0);//(1901, 1, 1, 1, 24, 50) 24 min, 50 segundos, coloco para pruebas en desarrollo
            dtmTiempoActualizado = new DateTime(1901, 1, 1, 1, 0, 0);
            dtmTiempoActualizado = dtmTiempoActualizado.AddMinutes(pomodoroAEjecutar);//colocar 1 para pruebas internas/unitarias
            if (POMODORO_EN_EJECUCION == POMODORO_5 || POMODORO_EN_EJECUCION == POMODORO_17)
            {
                lblTiempo.ForeColor = System.Drawing.Color.SteelBlue;
            }
            else
            {
                lblTiempo.ForeColor = System.Drawing.Color.Navy;
            }
            lblFecha.Text = "Iniciado: " + DateTime.Now.ToString("hh:mm:ss");
            if (menuItemActivarLog.Checked)
            {
                using (StreamWriter escribirArchivo = new StreamWriter(pathLog, true))
                {
                    escribirArchivo.WriteLine("Pomodoro " + pomodoroAEjecutar + " iniciado: " + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
            }
            timerControlTiempo.Start();
        }

        private void timerControlTiempo_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            dtmTiempoActualizado = dtmTiempoActualizado.Subtract(new TimeSpan(0, 0, 0, 1));
            lblTiempo.Text = dtmTiempoActualizado.ToString("mm:ss");
            if (dtmTiempoActualizado.Minute < 1 && menuItemBlink.Checked)
            {
                if (POMODORO_EN_EJECUCION == POMODORO_5 || POMODORO_EN_EJECUCION == POMODORO_17)
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
                lblTiempo.ForeColor = System.Drawing.Color.Maroon;
                lblFecha.Text = "P:" + POMODORO_EN_EJECUCION + " finalizado a las " + DateTime.Now.ToString("hh:mm:ss");
                lblFecha.Visible = true;
                if (menuItemActivarLog.Checked)
                {
                    using (StreamWriter escribirArchivo = new StreamWriter(pathLog, true))
                    {
                        escribirArchivo.WriteLine("Pomodoro " + POMODORO_EN_EJECUCION + " finalizado: " + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                }
                notifierInfo1.Info = "Fin del Pomodoro " + POMODORO_EN_EJECUCION;
                notifierInfo1.ShowInfo();
                //Se identifica que la mayoria de windows tienen este archivo por default, por lo que se decide utilizar este archivo wav.
                string audioFile = @"c:\Windows\Media\chimes.wav";
                //Valida existencia de archivo antes de abrirlo y ejecutar (play).
                if (File.Exists(audioFile))
                {
                    SoundPlayer simpleSound = new SoundPlayer(audioFile);
                    simpleSound.Play();
                }

                if (menuItemAutoSwitch.Checked)
                {
                    //Ejecuta el metodo contrario
                    if (POMODORO_EN_EJECUCION == POMODORO_5)
                    {
                        menuItem25Minutos_Click(null, null);
                    }
                    else if (POMODORO_EN_EJECUCION == POMODORO_25)
                    {
                        menuItem5Minutos_Click(null, null);
                    }
                    else if (POMODORO_EN_EJECUCION == POMODORO_52)
                    {
                        menuItem17Minutos_Click(null, null);
                    }
                    else
                    {
                        menuItem52Minutos_Click(null, null);
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
                //Ejecuta el metodo contrario
                if (POMODORO_EN_EJECUCION == POMODORO_5)
                {
                    menuItem25Minutos_Click(null, null);
                }
                else if (POMODORO_EN_EJECUCION == POMODORO_25)
                {
                    menuItem5Minutos_Click(null, null);
                }
                else if (POMODORO_EN_EJECUCION == POMODORO_52)
                {
                    menuItem17Minutos_Click(null, null);
                }
                else
                {
                    menuItem52Minutos_Click(null, null);
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                ctmMenu.Show(lblTiempo, new Point(e.X, e.Y));
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

        private void menuItemActivarLog_Click(object sender, System.EventArgs e)
        {
            if (menuItemActivarLog.Checked)
            {
                menuItemActivarLog.Checked = false;
            }
            else
            {
                menuItemActivarLog.Checked = true;
            }
        }

        private void menuItemSalir_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro desea salir?", "Confirmaci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void menuItemDetener_Click(object sender, System.EventArgs e)
        {
            lblTiempo.Text = "00:00";
            timerControlTiempo.Stop();
            lblTiempo.ForeColor = System.Drawing.Color.Maroon;
            lblFecha.Text = "P:" + POMODORO_EN_EJECUCION + " cancelado a las " + DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Visible = true;
            if (menuItemActivarLog.Checked)
            {
                using (StreamWriter escribirArchivo = new StreamWriter(pathLog, true))
                {
                    escribirArchivo.WriteLine("Pomodoro " + POMODORO_EN_EJECUCION + " cancelado: " + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
            }

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
            MessageBox.Show("Pomodoro Timer" +
                Environment.NewLine + "Aplicación gratuita v2.3." +
                Environment.NewLine + "Autor: Victor Velepucha" +
                Environment.NewLine + "Copyright ©  2025" +
                Environment.NewLine +
                Environment.NewLine + "Doble clic para alternar entre pomodoros." +
                Environment.NewLine + "Tiempo en color celeste para Pomodoro Trabajo" +
                Environment.NewLine + "Tiempo en color azul para Pomodoro descanso",
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
