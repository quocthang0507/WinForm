namespace DeCaptcha
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
			this.pic_orgin = new System.Windows.Forms.PictureBox();
			this.resultLabel = new System.Windows.Forms.Label();
			this.btn_browser = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.btn_decaptcha = new System.Windows.Forms.Button();
			this.pic_decaptcha = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pic_orgin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pic_decaptcha)).BeginInit();
			this.SuspendLayout();
			// 
			// pic_orgin
			// 
			this.pic_orgin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pic_orgin.Location = new System.Drawing.Point(22, 40);
			this.pic_orgin.Name = "pic_orgin";
			this.pic_orgin.Size = new System.Drawing.Size(292, 246);
			this.pic_orgin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pic_orgin.TabIndex = 0;
			this.pic_orgin.TabStop = false;
			// 
			// resultLabel
			// 
			this.resultLabel.AutoSize = true;
			this.resultLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.resultLabel.ForeColor = System.Drawing.Color.Red;
			this.resultLabel.Location = new System.Drawing.Point(537, 298);
			this.resultLabel.Name = "resultLabel";
			this.resultLabel.Size = new System.Drawing.Size(78, 23);
			this.resultLabel.TabIndex = 3;
			this.resultLabel.Text = "Result:";
			// 
			// btn_browser
			// 
			this.btn_browser.Location = new System.Drawing.Point(337, 137);
			this.btn_browser.Name = "btn_browser";
			this.btn_browser.Size = new System.Drawing.Size(75, 23);
			this.btn_browser.TabIndex = 4;
			this.btn_browser.Text = "Browse...";
			this.btn_browser.UseVisualStyleBackColor = true;
			this.btn_browser.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog1";
			// 
			// btn_decaptcha
			// 
			this.btn_decaptcha.Location = new System.Drawing.Point(337, 178);
			this.btn_decaptcha.Name = "btn_decaptcha";
			this.btn_decaptcha.Size = new System.Drawing.Size(75, 23);
			this.btn_decaptcha.TabIndex = 5;
			this.btn_decaptcha.Text = "DeCaptcha";
			this.btn_decaptcha.UseVisualStyleBackColor = true;
			this.btn_decaptcha.Click += new System.EventHandler(this.btn_decaptcha_Click);
			// 
			// pic_decaptcha
			// 
			this.pic_decaptcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pic_decaptcha.Location = new System.Drawing.Point(436, 40);
			this.pic_decaptcha.Name = "pic_decaptcha";
			this.pic_decaptcha.Size = new System.Drawing.Size(292, 246);
			this.pic_decaptcha.TabIndex = 6;
			this.pic_decaptcha.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(742, 351);
			this.Controls.Add(this.pic_decaptcha);
			this.Controls.Add(this.btn_decaptcha);
			this.Controls.Add(this.btn_browser);
			this.Controls.Add(this.resultLabel);
			this.Controls.Add(this.pic_orgin);
			this.Name = "Form1";
			this.Text = "DeCaptcha using Aforge.NET";
			((System.ComponentModel.ISupportInitialize)(this.pic_orgin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pic_decaptcha)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_orgin;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button btn_browser;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btn_decaptcha;
        private System.Windows.Forms.PictureBox pic_decaptcha;
    }
}

