namespace MovePictureBoxInsideWinForm
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
            this.myPictureBox3 = new MovePictureBoxInsideWinForm.MyPictureBox(this.components);
            this.myPictureBox2 = new MovePictureBoxInsideWinForm.MyPictureBox(this.components);
            this.myPictureBox1 = new MovePictureBoxInsideWinForm.MyPictureBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.myPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // myPictureBox3
            // 
            this.myPictureBox3.Image = global::MovePictureBoxInsideWinForm.Properties.Resources.z1375900108579_6fc7f5bf8534e115530a8481d4ee8b66;
            this.myPictureBox3.Location = new System.Drawing.Point(268, 99);
            this.myPictureBox3.Name = "myPictureBox3";
            this.myPictureBox3.Size = new System.Drawing.Size(133, 217);
            this.myPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.myPictureBox3.TabIndex = 2;
            this.myPictureBox3.TabStop = false;
            // 
            // myPictureBox2
            // 
            this.myPictureBox2.Image = global::MovePictureBoxInsideWinForm.Properties.Resources._2019_10_25_102853;
            this.myPictureBox2.Location = new System.Drawing.Point(531, 99);
            this.myPictureBox2.Name = "myPictureBox2";
            this.myPictureBox2.Size = new System.Drawing.Size(171, 217);
            this.myPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.myPictureBox2.TabIndex = 1;
            this.myPictureBox2.TabStop = false;
            // 
            // myPictureBox1
            // 
            this.myPictureBox1.Image = global::MovePictureBoxInsideWinForm.Properties.Resources._2019_10_25_102732;
            this.myPictureBox1.Location = new System.Drawing.Point(52, 99);
            this.myPictureBox1.Name = "myPictureBox1";
            this.myPictureBox1.Size = new System.Drawing.Size(169, 215);
            this.myPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.myPictureBox1.TabIndex = 0;
            this.myPictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.myPictureBox3);
            this.Controls.Add(this.myPictureBox2);
            this.Controls.Add(this.myPictureBox1);
            this.Name = "Form1";
            this.Text = "[C#] Move PictureBox inside Winform - https://laptrinhvb.net";
            ((System.ComponentModel.ISupportInitialize)(this.myPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyPictureBox myPictureBox1;
        private MyPictureBox myPictureBox2;
        private MyPictureBox myPictureBox3;
    }
}

