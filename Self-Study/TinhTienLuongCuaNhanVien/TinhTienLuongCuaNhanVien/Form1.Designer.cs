namespace TinhTienLuongCuaNhanVien
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtten = new System.Windows.Forms.TextBox();
			this.txtcoban = new System.Windows.Forms.TextBox();
			this.txtgio = new System.Windows.Forms.TextBox();
			this.txttongluong = new System.Windows.Forms.TextBox();
			this.chkpc = new System.Windows.Forms.CheckBox();
			this.btntinh = new System.Windows.Forms.Button();
			this.btnxoa = new System.Windows.Forms.Button();
			this.btntongket = new System.Windows.Forms.Button();
			this.btnthoat = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(26, 32);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(146, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Họ và tên nhân viên:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 71);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(113, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "Lương cơ bản:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(26, 111);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(154, 18);
			this.label3.TabIndex = 2;
			this.label3.Text = "Số giờ làm việc/tuần:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(26, 191);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(93, 18);
			this.label4.TabIndex = 3;
			this.label4.Text = "Tổng lương:";
			// 
			// txtten
			// 
			this.txtten.Location = new System.Drawing.Point(229, 29);
			this.txtten.Margin = new System.Windows.Forms.Padding(2);
			this.txtten.MaxLength = 50;
			this.txtten.Name = "txtten";
			this.txtten.Size = new System.Drawing.Size(164, 26);
			this.txtten.TabIndex = 4;
			// 
			// txtcoban
			// 
			this.txtcoban.Location = new System.Drawing.Point(229, 69);
			this.txtcoban.Margin = new System.Windows.Forms.Padding(2);
			this.txtcoban.MaxLength = 9;
			this.txtcoban.Name = "txtcoban";
			this.txtcoban.Size = new System.Drawing.Size(95, 26);
			this.txtcoban.TabIndex = 5;
			// 
			// txtgio
			// 
			this.txtgio.Location = new System.Drawing.Point(229, 109);
			this.txtgio.Margin = new System.Windows.Forms.Padding(2);
			this.txtgio.MaxLength = 3;
			this.txtgio.Name = "txtgio";
			this.txtgio.Size = new System.Drawing.Size(69, 26);
			this.txtgio.TabIndex = 6;
			this.txtgio.TextChanged += new System.EventHandler(this.txtgio_TextChanged);
			// 
			// txttongluong
			// 
			this.txttongluong.Location = new System.Drawing.Point(229, 189);
			this.txttongluong.Margin = new System.Windows.Forms.Padding(2);
			this.txttongluong.MaxLength = 9;
			this.txttongluong.Name = "txttongluong";
			this.txttongluong.Size = new System.Drawing.Size(95, 26);
			this.txttongluong.TabIndex = 7;
			// 
			// chkpc
			// 
			this.chkpc.AutoSize = true;
			this.chkpc.Location = new System.Drawing.Point(71, 152);
			this.chkpc.Margin = new System.Windows.Forms.Padding(2);
			this.chkpc.Name = "chkpc";
			this.chkpc.Size = new System.Drawing.Size(156, 22);
			this.chkpc.TabIndex = 8;
			this.chkpc.Text = "Phụ cấp (50.000đ)";
			this.chkpc.UseVisualStyleBackColor = true;
			// 
			// btntinh
			// 
			this.btntinh.Location = new System.Drawing.Point(75, 249);
			this.btntinh.Margin = new System.Windows.Forms.Padding(2);
			this.btntinh.Name = "btntinh";
			this.btntinh.Size = new System.Drawing.Size(78, 28);
			this.btntinh.TabIndex = 9;
			this.btntinh.Text = "Tính";
			this.btntinh.UseVisualStyleBackColor = true;
			this.btntinh.Click += new System.EventHandler(this.btntinh_Click);
			// 
			// btnxoa
			// 
			this.btnxoa.Location = new System.Drawing.Point(262, 249);
			this.btnxoa.Margin = new System.Windows.Forms.Padding(2);
			this.btnxoa.Name = "btnxoa";
			this.btnxoa.Size = new System.Drawing.Size(78, 28);
			this.btnxoa.TabIndex = 10;
			this.btnxoa.Text = "Xoá";
			this.btnxoa.UseVisualStyleBackColor = true;
			this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
			// 
			// btntongket
			// 
			this.btntongket.Location = new System.Drawing.Point(75, 303);
			this.btntongket.Margin = new System.Windows.Forms.Padding(2);
			this.btntongket.Name = "btntongket";
			this.btntongket.Size = new System.Drawing.Size(78, 28);
			this.btntongket.TabIndex = 11;
			this.btntongket.Text = "Tổng kết";
			this.btntongket.UseVisualStyleBackColor = true;
			this.btntongket.Click += new System.EventHandler(this.btntongket_Click);
			// 
			// btnthoat
			// 
			this.btnthoat.Location = new System.Drawing.Point(262, 303);
			this.btnthoat.Margin = new System.Windows.Forms.Padding(2);
			this.btnthoat.Name = "btnthoat";
			this.btnthoat.Size = new System.Drawing.Size(78, 28);
			this.btnthoat.TabIndex = 12;
			this.btnthoat.Text = "Thoát";
			this.btnthoat.UseVisualStyleBackColor = true;
			this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(426, 362);
			this.Controls.Add(this.btnthoat);
			this.Controls.Add(this.btntongket);
			this.Controls.Add(this.btnxoa);
			this.Controls.Add(this.btntinh);
			this.Controls.Add(this.chkpc);
			this.Controls.Add(this.txttongluong);
			this.Controls.Add(this.txtgio);
			this.Controls.Add(this.txtcoban);
			this.Controls.Add(this.txtten);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.Name = "Form1";
			this.Text = "Nhân viên";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtten;
		private System.Windows.Forms.TextBox txtcoban;
		private System.Windows.Forms.TextBox txtgio;
		private System.Windows.Forms.TextBox txttongluong;
		private System.Windows.Forms.CheckBox chkpc;
		private System.Windows.Forms.Button btntinh;
		private System.Windows.Forms.Button btnxoa;
		private System.Windows.Forms.Button btntongket;
		private System.Windows.Forms.Button btnthoat;
	}
}

