namespace ChuongTrinhThiTracNghiem
{
    partial class Form_Welcome
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
			this.label1 = new System.Windows.Forms.Label();
			this.btn_Thi = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tbx_Ten = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbx_ThoiGian = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.chk_Random = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Blue;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(349, 49);
			this.label1.TabIndex = 0;
			this.label1.Text = "CHƯƠNG TRÌNH THI TRẮC NGHIỆM";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn_Thi
			// 
			this.btn_Thi.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btn_Thi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.btn_Thi.Location = new System.Drawing.Point(137, 159);
			this.btn_Thi.Name = "btn_Thi";
			this.btn_Thi.Size = new System.Drawing.Size(75, 23);
			this.btn_Thi.TabIndex = 4;
			this.btn_Thi.Text = "Vào thi";
			this.btn_Thi.UseVisualStyleBackColor = true;
			this.btn_Thi.Click += new System.EventHandler(this.btn_Thi_Click);
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label2.Location = new System.Drawing.Point(45, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "Họ và tên:";
			// 
			// tbx_Ten
			// 
			this.tbx_Ten.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tbx_Ten.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.tbx_Ten.Location = new System.Drawing.Point(119, 52);
			this.tbx_Ten.MaxLength = 100;
			this.tbx_Ten.Name = "tbx_Ten";
			this.tbx_Ten.Size = new System.Drawing.Size(172, 21);
			this.tbx_Ten.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label3.Location = new System.Drawing.Point(46, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 15);
			this.label3.TabIndex = 4;
			this.label3.Text = "Thời gian:";
			// 
			// tbx_ThoiGian
			// 
			this.tbx_ThoiGian.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tbx_ThoiGian.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.tbx_ThoiGian.Location = new System.Drawing.Point(119, 83);
			this.tbx_ThoiGian.MaxLength = 3;
			this.tbx_ThoiGian.Name = "tbx_ThoiGian";
			this.tbx_ThoiGian.Size = new System.Drawing.Size(56, 21);
			this.tbx_ThoiGian.TabIndex = 2;
			this.tbx_ThoiGian.Text = "40";
			this.tbx_ThoiGian.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_ThoiGian_KeyPress);
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label4.Location = new System.Drawing.Point(181, 86);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 15);
			this.label4.TabIndex = 6;
			this.label4.Text = "phút";
			// 
			// chk_Random
			// 
			this.chk_Random.AutoSize = true;
			this.chk_Random.Location = new System.Drawing.Point(105, 124);
			this.chk_Random.Name = "chk_Random";
			this.chk_Random.Size = new System.Drawing.Size(131, 17);
			this.chk_Random.TabIndex = 3;
			this.chk_Random.Text = "Sắp thứ tự ngẫu nhiên";
			this.chk_Random.UseVisualStyleBackColor = true;
			// 
			// Form_Welcome
			// 
			this.AcceptButton = this.btn_Thi;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(349, 194);
			this.Controls.Add(this.chk_Random);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbx_ThoiGian);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbx_Ten);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btn_Thi);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Form_Welcome";
			this.Text = "Chương trình Thi trắc nghiệm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Welcome_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Thi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tbx_Ten;
        public System.Windows.Forms.TextBox tbx_ThoiGian;
        public System.Windows.Forms.CheckBox chk_Random;
    }
}

