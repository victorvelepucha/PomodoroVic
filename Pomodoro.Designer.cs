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
            this.lblTiempo = new System.Windows.Forms.Label();
            this.btn25Minutos = new System.Windows.Forms.Button();
            this.timerControlTiempo = new System.Timers.Timer();
            this.label1 = new System.Windows.Forms.Label();
            this.btn5Minutos = new System.Windows.Forms.Button();
            this.btnDetener = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTiempo
            // 
            this.lblTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.lblTiempo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTiempo.Location = new System.Drawing.Point(24, 16);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(368, 56);
            this.lblTiempo.TabIndex = 0;
            this.lblTiempo.Text = "label1";
            this.lblTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn25Minutos
            // 
            this.btn25Minutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.btn25Minutos.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn25Minutos.Location = new System.Drawing.Point(8, 104);
            this.btn25Minutos.Name = "btn25Minutos";
            this.btn25Minutos.Size = new System.Drawing.Size(120, 32);
            this.btn25Minutos.TabIndex = 1;
            this.btn25Minutos.Text = "focus 25";
            this.btn25Minutos.Click += new System.EventHandler(this.btn25Minutos_Click);
            // 
            // timerControlTiempo
            // 
            this.timerControlTiempo.Interval = 1000;
            this.timerControlTiempo.SynchronizingObject = this;
            this.timerControlTiempo.Elapsed += new System.Timers.ElapsedEventHandler(this.timerControlTiempo_Elapsed);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(80, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // btn5Minutos
            // 
            this.btn5Minutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.btn5Minutos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn5Minutos.Location = new System.Drawing.Point(144, 104);
            this.btn5Minutos.Name = "btn5Minutos";
            this.btn5Minutos.Size = new System.Drawing.Size(120, 32);
            this.btn5Minutos.TabIndex = 3;
            this.btn5Minutos.Text = "focus 5";
            this.btn5Minutos.Click += new System.EventHandler(this.btn5Minutos_Click);
            // 
            // btnDetener
            // 
            this.btnDetener.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.btnDetener.ForeColor = System.Drawing.Color.Maroon;
            this.btnDetener.Location = new System.Drawing.Point(280, 104);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(120, 32);
            this.btnDetener.TabIndex = 4;
            this.btnDetener.Text = "Detener";
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 143);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.btn5Minutos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn25Minutos);
            this.Controls.Add(this.lblTiempo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Pomodoro v1.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.DateTime dtmTiempoAuxiliar;
        private System.DateTime dtmTiempoActualizado;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Button btn25Minutos;
        private System.Timers.Timer timerControlTiempo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn5Minutos;
        private System.Windows.Forms.Button btnDetener;
    }
}

