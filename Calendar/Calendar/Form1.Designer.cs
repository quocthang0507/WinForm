namespace Calendar
{
	partial class Form_Duong_Am
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
			this.tbNgay = new System.Windows.Forms.TextBox();
			this.tbThang = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbNam = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnNhap = new System.Windows.Forms.Button();
			this.btnTuDong = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rtbKetQua = new System.Windows.Forms.RichTextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnChuyen = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nhập ngày";
			// 
			// tbNgay
			// 
			this.tbNgay.Location = new System.Drawing.Point(71, 23);
			this.tbNgay.Name = "tbNgay";
			this.tbNgay.Size = new System.Drawing.Size(100, 20);
			this.tbNgay.TabIndex = 1;
			// 
			// tbThang
			// 
			this.tbThang.Location = new System.Drawing.Point(71, 56);
			this.tbThang.Name = "tbThang";
			this.tbThang.Size = new System.Drawing.Size(100, 20);
			this.tbThang.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Nhập tháng";
			// 
			// tbNam
			// 
			this.tbNam.Location = new System.Drawing.Point(71, 86);
			this.tbNam.Name = "tbNam";
			this.tbNam.Size = new System.Drawing.Size(100, 20);
			this.tbNam.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 89);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Nhập năm";
			// 
			// btnNhap
			// 
			this.btnNhap.Location = new System.Drawing.Point(179, 90);
			this.btnNhap.Name = "btnNhap";
			this.btnNhap.Size = new System.Drawing.Size(75, 23);
			this.btnNhap.TabIndex = 6;
			this.btnNhap.Text = "Nhập";
			this.btnNhap.UseVisualStyleBackColor = true;
			this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
			// 
			// btnTuDong
			// 
			this.btnTuDong.Location = new System.Drawing.Point(179, 45);
			this.btnTuDong.Name = "btnTuDong";
			this.btnTuDong.Size = new System.Drawing.Size(75, 39);
			this.btnTuDong.TabIndex = 7;
			this.btnTuDong.Text = "Lấy thời gian hiện tại";
			this.btnTuDong.UseVisualStyleBackColor = true;
			this.btnTuDong.Click += new System.EventHandler(this.btnTuDong_Click);
			// 
			// btnXoa
			// 
			this.btnXoa.Location = new System.Drawing.Point(180, 16);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(75, 23);
			this.btnXoa.TabIndex = 8;
			this.btnXoa.Text = "Xóa";
			this.btnXoa.UseVisualStyleBackColor = true;
			this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rtbKetQua);
			this.groupBox1.Location = new System.Drawing.Point(14, 166);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(260, 140);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Âm lịch";
			// 
			// rtbKetQua
			// 
			this.rtbKetQua.Location = new System.Drawing.Point(6, 19);
			this.rtbKetQua.Name = "rtbKetQua";
			this.rtbKetQua.Size = new System.Drawing.Size(249, 106);
			this.rtbKetQua.TabIndex = 0;
			this.rtbKetQua.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.Transparent;
			this.groupBox2.Controls.Add(this.btnXoa);
			this.groupBox2.Controls.Add(this.btnTuDong);
			this.groupBox2.Controls.Add(this.btnNhap);
			this.groupBox2.Controls.Add(this.tbNgay);
			this.groupBox2.Controls.Add(this.tbNam);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.tbThang);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Location = new System.Drawing.Point(14, 20);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(260, 140);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Nhập ngày dương";
			// 
			// btnChuyen
			// 
			this.btnChuyen.Location = new System.Drawing.Point(260, 312);
			this.btnChuyen.Name = "btnChuyen";
			this.btnChuyen.Size = new System.Drawing.Size(29, 22);
			this.btnChuyen.TabIndex = 1;
			this.btnChuyen.Text = " Â";
			this.btnChuyen.UseVisualStyleBackColor = true;
			this.btnChuyen.Click += new System.EventHandler(this.btnChuyen_Click);
			// 
			// Form_Duong_Am
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 336);
			this.Controls.Add(this.btnChuyen);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form_Duong_Am";
			this.Text = "Lịch Dương sang Âm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbNgay;
		private System.Windows.Forms.TextBox tbThang;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbNam;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnNhap;
		private System.Windows.Forms.Button btnTuDong;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RichTextBox rtbKetQua;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnChuyen;
	}
}

