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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pomodoro));
            this.lblTiempo = new System.Windows.Forms.Label();
            this.btn25Minutos = new System.Windows.Forms.Button();
            this.timerControlTiempo = new System.Timers.Timer();
            this.label1 = new System.Windows.Forms.Label();
            this.btn5Minutos = new System.Windows.Forms.Button();
            this.btnDetener = new System.Windows.Forms.Button();
            this.trbOpacidad = new System.Windows.Forms.TrackBar();
            this.chkAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.ntfPomodoro = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblOpacidad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.timerControlTiempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbOpacidad)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTiempo
            // 
            this.lblTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTiempo.Location = new System.Drawing.Point(8, 8);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(280, 56);
            this.lblTiempo.TabIndex = 0;
            this.lblTiempo.Text = "label1";
            this.lblTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn25Minutos
            // 
            this.btn25Minutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn25Minutos.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn25Minutos.Location = new System.Drawing.Point(288, 8);
            this.btn25Minutos.Name = "btn25Minutos";
            this.btn25Minutos.Size = new System.Drawing.Size(64, 32);
            this.btn25Minutos.TabIndex = 1;
            this.btn25Minutos.Text = "focus 25";
            this.btn25Minutos.Click += new System.EventHandler(this.btn25Minutos_Click);
            // 
            // timerControlTiempo
            // 
            this.timerControlTiempo.Interval = 1000D;
            this.timerControlTiempo.SynchronizingObject = this;
            this.timerControlTiempo.Elapsed += new System.Timers.ElapsedEventHandler(this.timerControlTiempo_Elapsed);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // btn5Minutos
            // 
            this.btn5Minutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5Minutos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn5Minutos.Location = new System.Drawing.Point(288, 48);
            this.btn5Minutos.Name = "btn5Minutos";
            this.btn5Minutos.Size = new System.Drawing.Size(64, 32);
            this.btn5Minutos.TabIndex = 3;
            this.btn5Minutos.Text = "focus 5";
            this.btn5Minutos.Click += new System.EventHandler(this.btn5Minutos_Click);
            // 
            // btnDetener
            // 
            this.btnDetener.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetener.ForeColor = System.Drawing.Color.Maroon;
            this.btnDetener.Location = new System.Drawing.Point(288, 88);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(64, 32);
            this.btnDetener.TabIndex = 4;
            this.btnDetener.Text = "Detener";
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // trbOpacidad
            // 
            this.trbOpacidad.Enabled = false;
            this.trbOpacidad.LargeChange = 1;
            this.trbOpacidad.Location = new System.Drawing.Point(112, 72);
            this.trbOpacidad.Maximum = 9;
            this.trbOpacidad.Name = "trbOpacidad";
            this.trbOpacidad.Size = new System.Drawing.Size(176, 69);
            this.trbOpacidad.TabIndex = 5;
            this.trbOpacidad.Scroll += new System.EventHandler(this.trbOpacidad_Scroll);
            // 
            // chkAlwaysOnTop
            // 
            this.chkAlwaysOnTop.Location = new System.Drawing.Point(0, 72);
            this.chkAlwaysOnTop.Name = "chkAlwaysOnTop";
            this.chkAlwaysOnTop.Size = new System.Drawing.Size(64, 32);
            this.chkAlwaysOnTop.TabIndex = 7;
            this.chkAlwaysOnTop.Text = "AlwaysOnTop";
            this.chkAlwaysOnTop.CheckedChanged += new System.EventHandler(this.chkAlwaysOnTop_CheckedChanged);
            // 
            // ntfPomodoro
            // 
            this.ntfPomodoro.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfPomodoro.Icon")));
            this.ntfPomodoro.Text = "notifyIcon1";
            this.ntfPomodoro.DoubleClick += new System.EventHandler(this.ntfPomodoro_DoubleClick);
            this.ntfPomodoro.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ntfPomodoro_MouseMove);
            // 
            // lblOpacidad
            // 
            this.lblOpacidad.Location = new System.Drawing.Point(56, 80);
            this.lblOpacidad.Name = "lblOpacidad";
            this.lblOpacidad.Size = new System.Drawing.Size(64, 16);
            this.lblOpacidad.TabIndex = 8;
            this.lblOpacidad.Text = "| Opacidad:";
            // 
            // Pomodoro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 127);
            this.Controls.Add(this.lblOpacidad);
            this.Controls.Add(this.trbOpacidad);
            this.Controls.Add(this.chkAlwaysOnTop);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.btn5Minutos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn25Minutos);
            this.Controls.Add(this.lblTiempo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Pomodoro";
            this.Text = "Pomodoro v1.3";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.timerControlTiempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbOpacidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Button btn25Minutos;
        private System.Timers.Timer timerControlTiempo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn5Minutos;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.TrackBar trbOpacidad;
        private System.Windows.Forms.CheckBox chkAlwaysOnTop;
        private System.Windows.Forms.NotifyIcon ntfPomodoro;
        private System.Windows.Forms.Label lblOpacidad;
    }
}

