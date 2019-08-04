namespace UngDungTaoFormDonGian
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
			this.dgv_HienThi = new System.Windows.Forms.DataGridView();
			this.tbx_MSSV = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbx_HoTen = new System.Windows.Forms.TextBox();
			this.btn_Them = new System.Windows.Forms.Button();
			this.btn_Sua = new System.Windows.Forms.Button();
			this.btn_Xoa = new System.Windows.Forms.Button();
			this.btn_HienThi = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgv_HienThi)).BeginInit();
			this.SuspendLayout();
			// 
			// dgv_HienThi
			// 
			this.dgv_HienThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_HienThi.Location = new System.Drawing.Point(12, 20);
			this.dgv_HienThi.Name = "dgv_HienThi";
			this.dgv_HienThi.Size = new System.Drawing.Size(318, 291);
			this.dgv_HienThi.TabIndex = 0;
			this.dgv_HienThi.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellEnter);
			// 
			// tbx_MSSV
			// 
			this.tbx_MSSV.Location = new System.Drawing.Point(347, 40);
			this.tbx_MSSV.Name = "tbx_MSSV";
			this.tbx_MSSV.Size = new System.Drawing.Size(130, 20);
			this.tbx_MSSV.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(348, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Nhập MSSV:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(348, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Nhập họ tên:";
			// 
			// tbx_HoTen
			// 
			this.tbx_HoTen.Location = new System.Drawing.Point(347, 87);
			this.tbx_HoTen.Name = "tbx_HoTen";
			this.tbx_HoTen.Size = new System.Drawing.Size(130, 20);
			this.tbx_HoTen.TabIndex = 3;
			// 
			// btn_Them
			// 
			this.btn_Them.Location = new System.Drawing.Point(347, 124);
			this.btn_Them.Name = "btn_Them";
			this.btn_Them.Size = new System.Drawing.Size(130, 22);
			this.btn_Them.TabIndex = 5;
			this.btn_Them.Text = "Thêm";
			this.btn_Them.UseVisualStyleBackColor = true;
			this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
			// 
			// btn_Sua
			// 
			this.btn_Sua.Location = new System.Drawing.Point(347, 152);
			this.btn_Sua.Name = "btn_Sua";
			this.btn_Sua.Size = new System.Drawing.Size(130, 22);
			this.btn_Sua.TabIndex = 5;
			this.btn_Sua.Text = "Sửa";
			this.btn_Sua.UseVisualStyleBackColor = true;
			this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
			// 
			// btn_Xoa
			// 
			this.btn_Xoa.Location = new System.Drawing.Point(347, 180);
			this.btn_Xoa.Name = "btn_Xoa";
			this.btn_Xoa.Size = new System.Drawing.Size(130, 22);
			this.btn_Xoa.TabIndex = 5;
			this.btn_Xoa.Text = "Xoá";
			this.btn_Xoa.UseVisualStyleBackColor = true;
			this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
			// 
			// btn_HienThi
			// 
			this.btn_HienThi.Location = new System.Drawing.Point(347, 208);
			this.btn_HienThi.Name = "btn_HienThi";
			this.btn_HienThi.Size = new System.Drawing.Size(130, 22);
			this.btn_HienThi.TabIndex = 5;
			this.btn_HienThi.Text = "Hiển thị";
			this.btn_HienThi.UseVisualStyleBackColor = true;
			this.btn_HienThi.Click += new System.EventHandler(this.btn_HienThi_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(489, 328);
			this.Controls.Add(this.btn_HienThi);
			this.Controls.Add(this.btn_Xoa);
			this.Controls.Add(this.btn_Sua);
			this.Controls.Add(this.btn_Them);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbx_HoTen);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbx_MSSV);
			this.Controls.Add(this.dgv_HienThi);
			this.Name = "Form1";
			this.Text = "Danh sách nhận học bổng";
			this.Load += new System.EventHandler(this.btn_HienThi_Click);
			((System.ComponentModel.ISupportInitialize)(this.dgv_HienThi)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgv_HienThi;
		private System.Windows.Forms.TextBox tbx_MSSV;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbx_HoTen;
		private System.Windows.Forms.Button btn_Them;
		private System.Windows.Forms.Button btn_Sua;
		private System.Windows.Forms.Button btn_Xoa;
		private System.Windows.Forms.Button btn_HienThi;
	}
}

