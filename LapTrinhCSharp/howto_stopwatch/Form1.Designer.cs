namespace howto_stopwatch
{
    partial class Form1
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
            this.btnStart = new System.Windows.Forms.Button();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.lblElapsed = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lbl_milisecond = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStart.Location = new System.Drawing.Point(270, 209);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tmrClock
            // 
            this.tmrClock.Interval = 1;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // lblElapsed
            // 
            this.lblElapsed.AutoSize = true;
            this.lblElapsed.BackColor = System.Drawing.Color.Transparent;
            this.lblElapsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElapsed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblElapsed.Location = new System.Drawing.Point(88, 96);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(425, 108);
            this.lblElapsed.TabIndex = 5;
            this.lblElapsed.Text = "00:00:00";
            this.lblElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.lblDay.ForeColor = System.Drawing.Color.White;
            this.lblDay.Location = new System.Drawing.Point(12, 46);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(598, 41);
            this.lblDay.TabIndex = 7;
            this.lblDay.Text = "STOP WATCH - LAPTRINHVB.NET";
            // 
            // lbl_milisecond
            // 
            this.lbl_milisecond.AutoSize = true;
            this.lbl_milisecond.BackColor = System.Drawing.Color.Transparent;
            this.lbl_milisecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_milisecond.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbl_milisecond.Location = new System.Drawing.Point(495, 140);
            this.lbl_milisecond.Name = "lbl_milisecond";
            this.lbl_milisecond.Size = new System.Drawing.Size(108, 55);
            this.lbl_milisecond.TabIndex = 8;
            this.lbl_milisecond.Text = "000";
            this.lbl_milisecond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(615, 272);
            this.Controls.Add(this.lbl_milisecond);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblElapsed);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "StopWatch - https://laptrinhvb.net";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.Label lblElapsed;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lbl_milisecond;
    }
}

