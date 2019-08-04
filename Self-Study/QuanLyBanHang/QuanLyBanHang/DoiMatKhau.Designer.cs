namespace QuanLyBanHang
{
	partial class DoiMatKhau
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbx_MatKhauMoi = new System.Windows.Forms.TextBox();
			this.tbx_MatKhauCu = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_Thoat = new System.Windows.Forms.Button();
			this.btn_DongY = new System.Windows.Forms.Button();
			this.tbx_NhapLaiMK = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbx_NhapLaiMK);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tbx_MatKhauMoi);
			this.groupBox1.Controls.Add(this.tbx_MatKhauCu);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.groupBox1.Location = new System.Drawing.Point(75, 30);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(352, 151);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Đổi mật khẩu";
			// 
			// tbx_MatKhauMoi
			// 
			this.tbx_MatKhauMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.tbx_MatKhauMoi.Location = new System.Drawing.Point(178, 70);
			this.tbx_MatKhauMoi.MaxLength = 50;
			this.tbx_MatKhauMoi.Name = "tbx_MatKhauMoi";
			this.tbx_MatKhauMoi.Size = new System.Drawing.Size(149, 23);
			this.tbx_MatKhauMoi.TabIndex = 2;
			this.tbx_MatKhauMoi.UseSystemPasswordChar = true;
			// 
			// tbx_MatKhauCu
			// 
			this.tbx_MatKhauCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.tbx_MatKhauCu.Location = new System.Drawing.Point(178, 37);
			this.tbx_MatKhauCu.MaxLength = 50;
			this.tbx_MatKhauCu.Name = "tbx_MatKhauCu";
			this.tbx_MatKhauCu.Size = new System.Drawing.Size(149, 23);
			this.tbx_MatKhauCu.TabIndex = 1;
			this.tbx_MatKhauCu.UseSystemPasswordChar = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label2.Location = new System.Drawing.Point(49, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "Mật khẩu mới";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label1.Location = new System.Drawing.Point(58, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mật khẩu cũ";
			// 
			// btn_Thoat
			// 
			this.btn_Thoat.Location = new System.Drawing.Point(253, 201);
			this.btn_Thoat.Name = "btn_Thoat";
			this.btn_Thoat.Size = new System.Drawing.Size(96, 30);
			this.btn_Thoat.TabIndex = 5;
			this.btn_Thoat.Text = "Thoát";
			this.btn_Thoat.UseVisualStyleBackColor = true;
			this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
			// 
			// btn_DongY
			// 
			this.btn_DongY.Location = new System.Drawing.Point(137, 201);
			this.btn_DongY.Name = "btn_DongY";
			this.btn_DongY.Size = new System.Drawing.Size(96, 30);
			this.btn_DongY.TabIndex = 4;
			this.btn_DongY.Text = "Đồng ý";
			this.btn_DongY.UseVisualStyleBackColor = true;
			this.btn_DongY.Click += new System.EventHandler(this.btn_DongY_Click);
			// 
			// tbx_NhapLaiMK
			// 
			this.tbx_NhapLaiMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.tbx_NhapLaiMK.Location = new System.Drawing.Point(178, 99);
			this.tbx_NhapLaiMK.MaxLength = 50;
			this.tbx_NhapLaiMK.Name = "tbx_NhapLaiMK";
			this.tbx_NhapLaiMK.Size = new System.Drawing.Size(149, 23);
			this.tbx_NhapLaiMK.TabIndex = 4;
			this.tbx_NhapLaiMK.UseSystemPasswordChar = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label3.Location = new System.Drawing.Point(17, 99);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 20);
			this.label3.TabIndex = 3;
			this.label3.Text = "Nhập lại mật khẩu";
			// 
			// DoiMatKhau
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(486, 261);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btn_Thoat);
			this.Controls.Add(this.btn_DongY);
			this.MaximizeBox = false;
			this.Name = "DoiMatKhau";
			this.Text = "DoiMatKhau";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbx_NhapLaiMK;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbx_MatKhauMoi;
		private System.Windows.Forms.TextBox tbx_MatKhauCu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn_Thoat;
		private System.Windows.Forms.Button btn_DongY;
	}
}