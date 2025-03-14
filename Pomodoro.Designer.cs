using PomodoroVic.Properties;
using System.Resources;

namespace PomodoroVic
{
    partial class Pomodoro
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Pomodoro));
            this.lblTiempo = new System.Windows.Forms.Label();
            this.btn25Minutos = new System.Windows.Forms.Button();
            this.timerControlTiempo = new System.Timers.Timer();
            this.btn5Minutos = new System.Windows.Forms.Button();
            this.ntfPomodoro = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctmMenu = new System.Windows.Forms.ContextMenu();
            this.menuItemAlwaysOnTop = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemTransp0 = new System.Windows.Forms.MenuItem();
            this.menuItemTransp25 = new System.Windows.Forms.MenuItem();
            this.menuItemTransp50 = new System.Windows.Forms.MenuItem();
            this.menuItemTransp75 = new System.Windows.Forms.MenuItem();
            this.menuItemMinimizar = new System.Windows.Forms.MenuItem();
            this.menuItemDetener = new System.Windows.Forms.MenuItem();
            this.menuItemRestaurar = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemAcercaDe = new System.Windows.Forms.MenuItem();
            this.menuItemSalir = new System.Windows.Forms.MenuItem();
            this.menuItemMostrarOcultarTitulo = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.timerControlTiempo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTiempo
            // 
            this.lblTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.lblTiempo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTiempo.Location = new System.Drawing.Point(0, 0);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(144, 56);
            this.lblTiempo.TabIndex = 0;
            this.lblTiempo.Text = "label1";
            this.lblTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTiempo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTiempo_MouseDown);
            // 
            // btn25Minutos
            // 
            this.btn25Minutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.btn25Minutos.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn25Minutos.Location = new System.Drawing.Point(144, 0);
            this.btn25Minutos.Name = "btn25Minutos";
            this.btn25Minutos.Size = new System.Drawing.Size(28, 28);
            this.btn25Minutos.TabIndex = 1;
            this.btn25Minutos.Text = "25";
            this.btn25Minutos.Click += new System.EventHandler(this.btn25Minutos_Click);
            // 
            // timerControlTiempo
            // 
            this.timerControlTiempo.Interval = 1000;
            this.timerControlTiempo.SynchronizingObject = this;
            this.timerControlTiempo.Elapsed += new System.Timers.ElapsedEventHandler(this.timerControlTiempo_Elapsed);
            // 
            // btn5Minutos
            // 
            this.btn5Minutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.btn5Minutos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn5Minutos.Location = new System.Drawing.Point(144, 32);
            this.btn5Minutos.Name = "btn5Minutos";
            this.btn5Minutos.Size = new System.Drawing.Size(28, 28);
            this.btn5Minutos.TabIndex = 3;
            this.btn5Minutos.Text = "5";
            this.btn5Minutos.Click += new System.EventHandler(this.btn5Minutos_Click);
            // 
            // ntfPomodoro
            // 
            this.ntfPomodoro.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfPomodoro.Icon")));
            this.ntfPomodoro.Text = "notifyIcon1";
            this.ntfPomodoro.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ntfPomodoro_MouseMove);
            this.ntfPomodoro.DoubleClick += new System.EventHandler(this.ntfPomodoro_DoubleClick);
            // 
            // ctmMenu
            // 
            this.ctmMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                    this.menuItemAlwaysOnTop,
                                                                                    this.menuItem2,
                                                                                    this.menuItemMinimizar,
                                                                                    this.menuItemDetener,
                                                                                    this.menuItemRestaurar,
                                                                                    this.menuItemMostrarOcultarTitulo,
                                                                                    this.menuItem1,
                                                                                    this.menuItemAcercaDe,
                                                                                    this.menuItemSalir});
            // 
            // menuItemAlwaysOnTop
            // 
            this.menuItemAlwaysOnTop.Checked = true;
            this.menuItemAlwaysOnTop.Index = 0;
            this.menuItemAlwaysOnTop.Text = "AlwaysOnTop";
            this.menuItemAlwaysOnTop.Click += new System.EventHandler(this.menuItemAlwaysOnTop_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.menuItemTransp0,
                                                                                      this.menuItemTransp25,
                                                                                      this.menuItemTransp50,
                                                                                      this.menuItemTransp75});
            this.menuItem2.Text = "Transparencia";
            // 
            // menuItemTransp0
            // 
            this.menuItemTransp0.Index = 0;
            this.menuItemTransp0.Text = "0%";
            this.menuItemTransp0.Click += new System.EventHandler(this.menuItemTransp0_Click);
            // 
            // menuItemTransp25
            // 
            this.menuItemTransp25.Index = 1;
            this.menuItemTransp25.Text = "25%";
            this.menuItemTransp25.Click += new System.EventHandler(this.menuItemTransp25_Click);
            // 
            // menuItemTransp50
            // 
            this.menuItemTransp50.Checked = true;
            this.menuItemTransp50.Index = 2;
            this.menuItemTransp50.Text = "50%";
            this.menuItemTransp50.Click += new System.EventHandler(this.menuItemTransp50_Click);
            // 
            // menuItemTransp75
            // 
            this.menuItemTransp75.Index = 3;
            this.menuItemTransp75.Text = "75%";
            this.menuItemTransp75.Click += new System.EventHandler(this.menuItemTransp75_Click);
            // 
            // menuItemMinimizar
            // 
            this.menuItemMinimizar.Index = 2;
            this.menuItemMinimizar.Text = "Minimizar a SystemTray";
            this.menuItemMinimizar.Click += new System.EventHandler(this.menuItemMinimizar_Click);
            // 
            // menuItemDetener
            // 
            this.menuItemDetener.Index = 3;
            this.menuItemDetener.Text = "Detener Tiempo";
            this.menuItemDetener.Click += new System.EventHandler(this.menuItemDetener_Click);
            // 
            // menuItemRestaurar
            // 
            this.menuItemRestaurar.Index = 4;
            this.menuItemRestaurar.Text = "&Restaurar Ventana";
            this.menuItemRestaurar.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 6;
            this.menuItem1.Text = "-";
            // 
            // menuItemAcercaDe
            // 
            this.menuItemAcercaDe.Index = 7;
            this.menuItemAcercaDe.Text = "Acerca de ...";
            this.menuItemAcercaDe.Click += new System.EventHandler(this.menuItemAcercaDe_Click);
            // 
            // menuItemSalir
            // 
            this.menuItemSalir.Index = 8;
            this.menuItemSalir.Text = "&Salir";
            this.menuItemSalir.Click += new System.EventHandler(this.menuItemSalir_Click);
            // 
            // menuItemMostrarOcultarTitulo
            // 
            this.menuItemMostrarOcultarTitulo.Index = 5;
            this.menuItemMostrarOcultarTitulo.Text = "Mostrar/Ocultar t�tulo";
            this.menuItemMostrarOcultarTitulo.Click += new System.EventHandler(this.menuItemMostrarOcultarTitulo_Click);
            // 
            // Pomodoro
            //
            this.AcceptButton = this.btn25Minutos;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 60);
            this.Controls.Add(this.btn5Minutos);
            this.Controls.Add(this.btn25Minutos);
            this.Controls.Add(this.lblTiempo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pomodoro";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timerControlTiempo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Button btn25Minutos;
        private System.Timers.Timer timerControlTiempo;
        private System.Windows.Forms.Button btn5Minutos;
        private System.Windows.Forms.NotifyIcon ntfPomodoro;
        private System.Windows.Forms.ContextMenu ctmMenu;
        private System.Windows.Forms.MenuItem menuItemRestaurar;
        private System.Windows.Forms.MenuItem menuItemSalir;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItemAlwaysOnTop;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItemTransp25;
        private System.Windows.Forms.MenuItem menuItemTransp50;
        private System.Windows.Forms.MenuItem menuItemTransp75;
        private System.Windows.Forms.MenuItem menuItemDetener;
        private System.Windows.Forms.MenuItem menuItemMinimizar;
        private System.Windows.Forms.MenuItem menuItemAcercaDe;
        private System.Windows.Forms.MenuItem menuItemTransp0;
        private System.Windows.Forms.MenuItem menuItemMostrarOcultarTitulo;
    }
}

