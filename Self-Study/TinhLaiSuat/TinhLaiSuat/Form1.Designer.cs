namespace TinhLaiSuat
{
	partial class TinhLaiSuat
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtTienBanDau = new System.Windows.Forms.TextBox();
			this.txtLaiSuat = new System.Windows.Forms.TextBox();
			this.nudNam = new System.Windows.Forms.NumericUpDown();
			this.btXoa = new System.Windows.Forms.Button();
			this.btTinh = new System.Windows.Forms.Button();
			this.rtbKetQua = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.nudNam)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(378, 38);
			this.label1.TabIndex = 0;
			this.label1.Text = "CHƯƠNG TRÌNH TÍNH TIỀN LÃI GỬI TIẾT KIỆM";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Số tiền ban đầu :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(39, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Lãi suất năm :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(85, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Năm :";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// txtTienBanDau
			// 
			this.txtTienBanDau.Location = new System.Drawing.Point(135, 50);
			this.txtTienBanDau.Name = "txtTienBanDau";
			this.txtTienBanDau.Size = new System.Drawing.Size(119, 22);
			this.txtTienBanDau.TabIndex = 4;
			// 
			// txtLaiSuat
			// 
			this.txtLaiSuat.Location = new System.Drawing.Point(134, 89);
			this.txtLaiSuat.Name = "txtLaiSuat";
			this.txtLaiSuat.Size = new System.Drawing.Size(120, 22);
			this.txtLaiSuat.TabIndex = 5;
			// 
			// nudNam
			// 
			this.nudNam.Location = new System.Drawing.Point(134, 126);
			this.nudNam.Name = "nudNam";
			this.nudNam.Size = new System.Drawing.Size(120, 22);
			this.nudNam.TabIndex = 6;
			// 
			// btXoa
			// 
			this.btXoa.Location = new System.Drawing.Point(284, 63);
			this.btXoa.Name = "btXoa";
			this.btXoa.Size = new System.Drawing.Size(67, 23);
			this.btXoa.TabIndex = 7;
			this.btXoa.Text = "Clear";
			this.btXoa.UseVisualStyleBackColor = true;
			this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
			// 
			// btTinh
			// 
			this.btTinh.Location = new System.Drawing.Point(284, 92);
			this.btTinh.Name = "btTinh";
			this.btTinh.Size = new System.Drawing.Size(67, 52);
			this.btTinh.TabIndex = 8;
			this.btTinh.Text = "Tính lãi suất";
			this.btTinh.UseVisualStyleBackColor = true;
			this.btTinh.Click += new System.EventHandler(this.btTinh_Click);
			// 
			// rtbKetQua
			// 
			this.rtbKetQua.Location = new System.Drawing.Point(25, 176);
			this.rtbKetQua.Name = "rtbKetQua";
			this.rtbKetQua.Size = new System.Drawing.Size(326, 133);
			this.rtbKetQua.TabIndex = 9;
			this.rtbKetQua.Text = "";
			// 
			// TinhLaiSuat
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(378, 321);
			this.Controls.Add(this.rtbKetQua);
			this.Controls.Add(this.btTinh);
			this.Controls.Add(this.btXoa);
			this.Controls.Add(this.nudNam);
			this.Controls.Add(this.txtLaiSuat);
			this.Controls.Add(this.txtTienBanDau);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "TinhLaiSuat";
			this.Text = "Chương trình tính lãi suất";
			((System.ComponentModel.ISupportInitialize)(this.nudNam)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtTienBanDau;
		private System.Windows.Forms.TextBox txtLaiSuat;
		private System.Windows.Forms.NumericUpDown nudNam;
		private System.Windows.Forms.Button btXoa;
		private System.Windows.Forms.Button btTinh;
		private System.Windows.Forms.RichTextBox rtbKetQua;
	}
}

