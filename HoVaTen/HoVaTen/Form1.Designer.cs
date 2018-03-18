namespace HoVaTen
{
	partial class Form_HoVaTen
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
			this.txtHoVaTen = new System.Windows.Forms.TextBox();
			this.txtKetQua = new System.Windows.Forms.TextBox();
			this.btnHoLot = new System.Windows.Forms.Button();
			this.btnDemTu = new System.Windows.Forms.Button();
			this.btnDung = new System.Windows.Forms.Button();
			this.btnVietHoa = new System.Windows.Forms.Button();
			this.btnTen = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			this.btnIn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(162, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nhập vào chuỗi họ và tên:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(19, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Kết quả:";
			// 
			// txtHoVaTen
			// 
			this.txtHoVaTen.Location = new System.Drawing.Point(62, 31);
			this.txtHoVaTen.Name = "txtHoVaTen";
			this.txtHoVaTen.Size = new System.Drawing.Size(243, 21);
			this.txtHoVaTen.TabIndex = 1;
			// 
			// txtKetQua
			// 
			this.txtKetQua.Location = new System.Drawing.Point(62, 76);
			this.txtKetQua.Multiline = true;
			this.txtKetQua.Name = "txtKetQua";
			this.txtKetQua.Size = new System.Drawing.Size(243, 71);
			this.txtKetQua.TabIndex = 1;
			// 
			// btnHoLot
			// 
			this.btnHoLot.Location = new System.Drawing.Point(96, 183);
			this.btnHoLot.Name = "btnHoLot";
			this.btnHoLot.Size = new System.Drawing.Size(72, 27);
			this.btnHoLot.TabIndex = 2;
			this.btnHoLot.Text = "Họ lót";
			this.btnHoLot.UseVisualStyleBackColor = true;
			this.btnHoLot.Click += new System.EventHandler(this.btnHoLot_Click);
			// 
			// btnDemTu
			// 
			this.btnDemTu.Location = new System.Drawing.Point(174, 183);
			this.btnDemTu.Name = "btnDemTu";
			this.btnDemTu.Size = new System.Drawing.Size(72, 27);
			this.btnDemTu.TabIndex = 2;
			this.btnDemTu.Text = "Đếm từ";
			this.btnDemTu.UseVisualStyleBackColor = true;
			this.btnDemTu.Click += new System.EventHandler(this.btnDemTu_Click);
			// 
			// btnDung
			// 
			this.btnDung.Location = new System.Drawing.Point(252, 242);
			this.btnDung.Name = "btnDung";
			this.btnDung.Size = new System.Drawing.Size(72, 27);
			this.btnDung.TabIndex = 2;
			this.btnDung.Text = "Dừng";
			this.btnDung.UseVisualStyleBackColor = true;
			this.btnDung.Click += new System.EventHandler(this.btnDung_Click);
			// 
			// btnVietHoa
			// 
			this.btnVietHoa.Location = new System.Drawing.Point(174, 242);
			this.btnVietHoa.Name = "btnVietHoa";
			this.btnVietHoa.Size = new System.Drawing.Size(72, 27);
			this.btnVietHoa.TabIndex = 2;
			this.btnVietHoa.Text = "Viết hoa";
			this.btnVietHoa.UseVisualStyleBackColor = true;
			this.btnVietHoa.Click += new System.EventHandler(this.btnVietHoa_Click);
			// 
			// btnTen
			// 
			this.btnTen.Location = new System.Drawing.Point(96, 240);
			this.btnTen.Name = "btnTen";
			this.btnTen.Size = new System.Drawing.Size(72, 27);
			this.btnTen.TabIndex = 2;
			this.btnTen.Text = "Tên";
			this.btnTen.UseVisualStyleBackColor = true;
			this.btnTen.Click += new System.EventHandler(this.btnTen_Click);
			// 
			// btnXoa
			// 
			this.btnXoa.Location = new System.Drawing.Point(252, 183);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(72, 27);
			this.btnXoa.TabIndex = 2;
			this.btnXoa.Text = "Xoá";
			this.btnXoa.UseVisualStyleBackColor = true;
			this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
			// 
			// btnIn
			// 
			this.btnIn.Location = new System.Drawing.Point(15, 183);
			this.btnIn.Name = "btnIn";
			this.btnIn.Size = new System.Drawing.Size(75, 86);
			this.btnIn.TabIndex = 3;
			this.btnIn.Text = "In lời giới thiệu";
			this.btnIn.UseVisualStyleBackColor = true;
			this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
			// 
			// Form_HoVaTen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(331, 301);
			this.Controls.Add(this.btnIn);
			this.Controls.Add(this.btnTen);
			this.Controls.Add(this.btnXoa);
			this.Controls.Add(this.btnVietHoa);
			this.Controls.Add(this.btnDung);
			this.Controls.Add(this.btnDemTu);
			this.Controls.Add(this.btnHoLot);
			this.Controls.Add(this.txtKetQua);
			this.Controls.Add(this.txtHoVaTen);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
			this.Name = "Form_HoVaTen";
			this.Text = "Họ và tên";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtHoVaTen;
		private System.Windows.Forms.TextBox txtKetQua;
		private System.Windows.Forms.Button btnHoLot;
		private System.Windows.Forms.Button btnDemTu;
		private System.Windows.Forms.Button btnDung;
		private System.Windows.Forms.Button btnVietHoa;
		private System.Windows.Forms.Button btnTen;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnIn;
	}
}

