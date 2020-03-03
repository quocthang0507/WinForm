namespace CARO
{
    partial class fmLuatChoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmLuatChoi));
            this.LinkFB = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LinkFB
            // 
            this.LinkFB.AutoSize = true;
            this.LinkFB.Location = new System.Drawing.Point(323, 219);
            this.LinkFB.Name = "LinkFB";
            this.LinkFB.Size = new System.Drawing.Size(226, 13);
            this.LinkFB.TabIndex = 6;
            this.LinkFB.TabStop = true;
            this.LinkFB.Text = "Liên hệ:  www.facebook.com/PhongHkphone";
            this.LinkFB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkFB_LinkClicked);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(253, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(365, 137);
            this.label2.TabIndex = 5;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 223);
            this.label1.TabIndex = 7;
            // 
            // fmLuatChoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(630, 241);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LinkFB);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fmLuatChoi";
            this.Text = "Luật Chơi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel LinkFB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}