namespace QuanLyBanHang
{
	partial class DangNhap
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
			this.tbx_MatKhau = new System.Windows.Forms.TextBox();
			this.tbx_TenDangNhap = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_DangNhap = new System.Windows.Forms.Button();
			this.btn_Thoat = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbx_MatKhau);
			this.groupBox1.Controls.Add(this.tbx_TenDangNhap);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.groupBox1.Location = new System.Drawing.Point(25, 33);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(336, 151);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Đăng nhập hệ thống";
			// 
			// tbx_MatKhau
			// 
			this.tbx_MatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.tbx_MatKhau.Location = new System.Drawing.Point(153, 99);
			this.tbx_MatKhau.MaxLength = 50;
			this.tbx_MatKhau.Name = "tbx_MatKhau";
			this.tbx_MatKhau.Size = new System.Drawing.Size(149, 23);
			this.tbx_MatKhau.TabIndex = 2;
			this.tbx_MatKhau.UseSystemPasswordChar = true;
			// 
			// tbx_TenDangNhap
			// 
			this.tbx_TenDangNhap.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbx_TenDangNhap.Location = new System.Drawing.Point(153, 49);
			this.tbx_TenDangNhap.MaxLength = 50;
			this.tbx_TenDangNhap.Name = "tbx_TenDangNhap";
			this.tbx_TenDangNhap.Size = new System.Drawing.Size(149, 23);
			this.tbx_TenDangNhap.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label2.Location = new System.Drawing.Point(58, 99);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "Mật khẩu";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label1.Location = new System.Drawing.Point(17, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tên đăng nhập";
			// 
			// btn_DangNhap
			// 
			this.btn_DangNhap.Location = new System.Drawing.Point(87, 204);
			this.btn_DangNhap.Name = "btn_DangNhap";
			this.btn_DangNhap.Size = new System.Drawing.Size(96, 30);
			this.btn_DangNhap.TabIndex = 1;
			this.btn_DangNhap.Text = "Đăng nhập";
			this.btn_DangNhap.UseVisualStyleBackColor = true;
			this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
			// 
			// btn_Thoat
			// 
			this.btn_Thoat.Location = new System.Drawing.Point(203, 204);
			this.btn_Thoat.Name = "btn_Thoat";
			this.btn_Thoat.Size = new System.Drawing.Size(96, 30);
			this.btn_Thoat.TabIndex = 2;
			this.btn_Thoat.Text = "Thoát";
			this.btn_Thoat.UseVisualStyleBackColor = true;
			this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
			// 
			// DangNhap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(390, 261);
			this.Controls.Add(this.btn_Thoat);
			this.Controls.Add(this.btn_DangNhap);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.Name = "DangNhap";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Đăng nhập hệ thống";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbx_MatKhau;
		private System.Windows.Forms.TextBox tbx_TenDangNhap;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn_DangNhap;
		private System.Windows.Forms.Button btn_Thoat;
	}
}