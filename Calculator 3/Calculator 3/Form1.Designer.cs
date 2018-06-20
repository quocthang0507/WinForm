namespace Calculator_3
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
			this.label1 = new System.Windows.Forms.Label();
			this.tbx_TrungTo = new System.Windows.Forms.TextBox();
			this.tbx_HauTo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbx_KetQua = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btn_Tinh = new System.Windows.Forms.Button();
			this.lbl_Loi = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
			this.label1.Location = new System.Drawing.Point(9, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(137, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nhập biểu thức trung tố:";
			// 
			// tbx_TrungTo
			// 
			this.tbx_TrungTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
			this.tbx_TrungTo.Location = new System.Drawing.Point(152, 29);
			this.tbx_TrungTo.MaxLength = 100;
			this.tbx_TrungTo.Name = "tbx_TrungTo";
			this.tbx_TrungTo.Size = new System.Drawing.Size(120, 21);
			this.tbx_TrungTo.TabIndex = 1;
			// 
			// tbx_HauTo
			// 
			this.tbx_HauTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
			this.tbx_HauTo.Location = new System.Drawing.Point(152, 62);
			this.tbx_HauTo.Name = "tbx_HauTo";
			this.tbx_HauTo.Size = new System.Drawing.Size(120, 21);
			this.tbx_HauTo.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
			this.label2.Location = new System.Drawing.Point(9, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "Biểu thức hậu tố:";
			// 
			// tbx_KetQua
			// 
			this.tbx_KetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
			this.tbx_KetQua.Location = new System.Drawing.Point(152, 97);
			this.tbx_KetQua.Multiline = true;
			this.tbx_KetQua.Name = "tbx_KetQua";
			this.tbx_KetQua.Size = new System.Drawing.Size(120, 20);
			this.tbx_KetQua.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
			this.label3.Location = new System.Drawing.Point(9, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 15);
			this.label3.TabIndex = 4;
			this.label3.Text = "Kết quả:";
			// 
			// btn_Tinh
			// 
			this.btn_Tinh.Location = new System.Drawing.Point(104, 159);
			this.btn_Tinh.Name = "btn_Tinh";
			this.btn_Tinh.Size = new System.Drawing.Size(75, 23);
			this.btn_Tinh.TabIndex = 6;
			this.btn_Tinh.Text = "Tính";
			this.btn_Tinh.UseVisualStyleBackColor = true;
			this.btn_Tinh.Click += new System.EventHandler(this.btn_Tinh_Click);
			// 
			// lbl_Loi
			// 
			this.lbl_Loi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
			this.lbl_Loi.ForeColor = System.Drawing.Color.Red;
			this.lbl_Loi.Location = new System.Drawing.Point(24, 133);
			this.lbl_Loi.Name = "lbl_Loi";
			this.lbl_Loi.Size = new System.Drawing.Size(228, 23);
			this.lbl_Loi.TabIndex = 7;
			this.lbl_Loi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.lbl_Loi);
			this.Controls.Add(this.btn_Tinh);
			this.Controls.Add(this.tbx_KetQua);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbx_HauTo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbx_TrungTo);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Máy tính";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbx_TrungTo;
		private System.Windows.Forms.TextBox tbx_HauTo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbx_KetQua;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btn_Tinh;
		private System.Windows.Forms.Label lbl_Loi;
	}
}

