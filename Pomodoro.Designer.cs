﻿using PomodoroVic.Properties;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pomodoro));
            this.lblTiempo = new System.Windows.Forms.Label();
            this.timerControlTiempo = new System.Timers.Timer();
            this.ntfPomodoro = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctmMenu = new System.Windows.Forms.ContextMenu();
            this.menuItem25Minutos = new System.Windows.Forms.MenuItem();
            this.menuItem5Minutos = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem52Minutos = new System.Windows.Forms.MenuItem();
            this.menuItem17Minutos = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItemDetener = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItemConfiguracion = new System.Windows.Forms.MenuItem();
            this.menuItemAlwaysOnTop = new System.Windows.Forms.MenuItem();
            this.menuItemAutoSwitch = new System.Windows.Forms.MenuItem();
            this.menuItemBlink = new System.Windows.Forms.MenuItem();
            this.menuItemTransparencia = new System.Windows.Forms.MenuItem();
            this.menuItemTransp0 = new System.Windows.Forms.MenuItem();
            this.menuItemTransp25 = new System.Windows.Forms.MenuItem();
            this.menuItemTransp50 = new System.Windows.Forms.MenuItem();
            this.menuItemTransp75 = new System.Windows.Forms.MenuItem();
            this.menuItemActivarLog = new System.Windows.Forms.MenuItem();
            this.menuItemPlaySound = new System.Windows.Forms.MenuItem();
            this.menuItemMinimizar = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemAcercaDe = new System.Windows.Forms.MenuItem();
            this.menuItemSalir = new System.Windows.Forms.MenuItem();
            this.lblFecha = new System.Windows.Forms.Label();
            this.notifierInfo1 = new PomodoroVic.Notificador();
            ((System.ComponentModel.ISupportInitialize)(this.timerControlTiempo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTiempo
            // 
            this.lblTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTiempo.Location = new System.Drawing.Point(0, 0);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(216, 64);
            this.lblTiempo.TabIndex = 0;
            this.lblTiempo.Text = "00:00";
            this.lblTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTiempo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTiempo_MouseDown);
            // 
            // timerControlTiempo
            // 
            this.timerControlTiempo.Interval = 1000D;
            this.timerControlTiempo.SynchronizingObject = this;
            this.timerControlTiempo.Elapsed += new System.Timers.ElapsedEventHandler(this.timerControlTiempo_Elapsed);
            // 
            // ntfPomodoro
            // 
            this.ntfPomodoro.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfPomodoro.Icon")));
            this.ntfPomodoro.Text = "notifyIcon1";
            this.ntfPomodoro.DoubleClick += new System.EventHandler(this.ntfPomodoro_DoubleClick);
            this.ntfPomodoro.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ntfPomodoro_MouseMove);
            // 
            // ctmMenu
            // 
            this.ctmMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem25Minutos,
            this.menuItem5Minutos,
            this.menuItem2,
            this.menuItem52Minutos,
            this.menuItem17Minutos,
            this.menuItem3,
            this.menuItemDetener,
            this.menuItem4,
            this.menuItemConfiguracion,
            this.menuItem1,
            this.menuItemAcercaDe,
            this.menuItemSalir});
            // 
            // menuItem25Minutos
            // 
            this.menuItem25Minutos.Index = 0;
            this.menuItem25Minutos.Text = "25 minutos";
            this.menuItem25Minutos.Click += new System.EventHandler(this.menuItem25Minutos_Click);
            // 
            // menuItem5Minutos
            // 
            this.menuItem5Minutos.Index = 1;
            this.menuItem5Minutos.Text = "5 minutos";
            this.menuItem5Minutos.Click += new System.EventHandler(this.menuItem5Minutos_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "-";
            // 
            // menuItem52Minutos
            // 
            this.menuItem52Minutos.Index = 3;
            this.menuItem52Minutos.Text = "52 minutos";
            this.menuItem52Minutos.Click += new System.EventHandler(this.menuItem52Minutos_Click);
            // 
            // menuItem17Minutos
            // 
            this.menuItem17Minutos.Index = 4;
            this.menuItem17Minutos.Text = "17 minutos";
            this.menuItem17Minutos.Click += new System.EventHandler(this.menuItem17Minutos_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 5;
            this.menuItem3.Text = "-";
            // 
            // menuItemDetener
            // 
            this.menuItemDetener.Index = 6;
            this.menuItemDetener.Text = "Cancelar";
            this.menuItemDetener.Click += new System.EventHandler(this.menuItemDetener_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 7;
            this.menuItem4.Text = "-";
            // 
            // menuItemConfiguracion
            // 
            this.menuItemConfiguracion.Index = 8;
            this.menuItemConfiguracion.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemAlwaysOnTop,
            this.menuItemAutoSwitch,
            this.menuItemBlink,
            this.menuItemTransparencia,
            this.menuItemActivarLog,
            this.menuItemPlaySound,
            this.menuItemMinimizar});
            this.menuItemConfiguracion.Text = "Configuración";
            // 
            // menuItemAlwaysOnTop
            // 
            this.menuItemAlwaysOnTop.Checked = true;
            this.menuItemAlwaysOnTop.Index = 0;
            this.menuItemAlwaysOnTop.Text = "AlwaysOnTop";
            this.menuItemAlwaysOnTop.Click += new System.EventHandler(this.menuItemAlwaysOnTop_Click);
            // 
            // menuItemAutoSwitch
            // 
            this.menuItemAutoSwitch.Index = 1;
            this.menuItemAutoSwitch.Text = "AutoSwitch trabajo/descanso";
            this.menuItemAutoSwitch.Click += new System.EventHandler(this.menuItemAutoSwitch_Click);
            // 
            // menuItemBlink
            // 
            this.menuItemBlink.Checked = true;
            this.menuItemBlink.Index = 2;
            this.menuItemBlink.Text = "Blink antes de finalizar";
            this.menuItemBlink.Click += new System.EventHandler(this.menuItemBlink_Click);
            // 
            // menuItemTransparencia
            // 
            this.menuItemTransparencia.Index = 3;
            this.menuItemTransparencia.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemTransp0,
            this.menuItemTransp25,
            this.menuItemTransp50,
            this.menuItemTransp75});
            this.menuItemTransparencia.Text = "Transparencia";
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
            this.menuItemTransp50.Index = 2;
            this.menuItemTransp50.Text = "50%";
            this.menuItemTransp50.Click += new System.EventHandler(this.menuItemTransp50_Click);
            // 
            // menuItemTransp75
            // 
            this.menuItemTransp75.Checked = true;
            this.menuItemTransp75.Index = 3;
            this.menuItemTransp75.Text = "75%";
            this.menuItemTransp75.Click += new System.EventHandler(this.menuItemTransp75_Click);
            // 
            // menuItemActivarLog
            // 
            this.menuItemActivarLog.Checked = true;
            this.menuItemActivarLog.Index = 4;
            this.menuItemActivarLog.Text = "Activar Log";
            this.menuItemActivarLog.Click += new System.EventHandler(this.menuItemActivarLog_Click);
            // 
            // menuItemPlaySound
            // 
            this.menuItemPlaySound.Checked = true;
            this.menuItemPlaySound.Index = 5;
            this.menuItemPlaySound.Text = "Play Sound";
            this.menuItemPlaySound.Click += new System.EventHandler(this.menuItemPlaySound_Click);
            // 
            // menuItemMinimizar
            // 
            this.menuItemMinimizar.Index = 6;
            this.menuItemMinimizar.Text = "Minimizar a SystemTray";
            this.menuItemMinimizar.Click += new System.EventHandler(this.menuItemMinimizar_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 9;
            this.menuItem1.Text = "-";
            // 
            // menuItemAcercaDe
            // 
            this.menuItemAcercaDe.Index = 10;
            this.menuItemAcercaDe.Text = "Acerca de ...";
            this.menuItemAcercaDe.Click += new System.EventHandler(this.menuItemAcercaDe_Click);
            // 
            // menuItemSalir
            // 
            this.menuItemSalir.Index = 11;
            this.menuItemSalir.Text = "&Salir";
            this.menuItemSalir.Click += new System.EventHandler(this.menuItemSalir_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Black;
            this.lblFecha.Location = new System.Drawing.Point(0, 56);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(221, 14);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = ".";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFecha.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblFecha_MouseDown);
            // 
            // notifierInfo1
            // 
            this.notifierInfo1.BackColor = System.Drawing.SystemColors.Info;
            this.notifierInfo1.ClientSize = new System.Drawing.Size(160, 40);
            this.notifierInfo1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.notifierInfo1.Info = null;
            this.notifierInfo1.Interval = 75;
            this.notifierInfo1.Location = new System.Drawing.Point(1280, 1024);
            this.notifierInfo1.Name = "notifierInfo1";
            this.notifierInfo1.ShowInTaskbar = false;
            this.notifierInfo1.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.notifierInfo1.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.notifierInfo1.Text = "Notificador";
            this.notifierInfo1.TimeOut = 3;
            this.notifierInfo1.TopMost = true;
            this.notifierInfo1.Visible = false;
            // 
            // Pomodoro
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.ClientSize = new System.Drawing.Size(216, 105);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblTiempo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Pomodoro";
            this.ShowInTaskbar = false;
            this.Text = "Pomodoro";
            this.Load += new System.EventHandler(this.Pomodoro_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Pomodoro_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.timerControlTiempo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTiempo;
        private System.Timers.Timer timerControlTiempo;
        private System.Windows.Forms.NotifyIcon ntfPomodoro;
        private System.Windows.Forms.ContextMenu ctmMenu;
        private System.Windows.Forms.MenuItem menuItemSalir;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItemAlwaysOnTop;
        private System.Windows.Forms.MenuItem menuItemTransp25;
        private System.Windows.Forms.MenuItem menuItemTransp50;
        private System.Windows.Forms.MenuItem menuItemTransp75;
        private System.Windows.Forms.MenuItem menuItemDetener;
        private System.Windows.Forms.MenuItem menuItemMinimizar;
        private System.Windows.Forms.MenuItem menuItemAcercaDe;
        private System.Windows.Forms.MenuItem menuItemTransp0;
        private PomodoroVic.Notificador notifierInfo1;

        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem25Minutos;
        private System.Windows.Forms.MenuItem menuItem5Minutos;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.MenuItem menuItemAutoSwitch;
        private System.Windows.Forms.MenuItem menuItemConfiguracion;
        private System.Windows.Forms.MenuItem menuItemTransparencia;
        private System.Windows.Forms.MenuItem menuItemActivarLog;
        private System.Windows.Forms.MenuItem menuItem17Minutos;
        private System.Windows.Forms.MenuItem menuItem52Minutos;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItemBlink;
        private System.Windows.Forms.MenuItem menuItemPlaySound;
    }
}

