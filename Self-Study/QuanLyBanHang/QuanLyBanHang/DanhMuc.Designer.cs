namespace QuanLyBanHang
{
	partial class DanhMuc
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
			this.lbl_DM = new System.Windows.Forms.Label();
			this.dgv_DanhMuc = new System.Windows.Forms.DataGridView();
			this.btn_TroVe = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgv_DanhMuc)).BeginInit();
			this.SuspendLayout();
			// 
			// lbl_DM
			// 
			this.lbl_DM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbl_DM.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.lbl_DM.Location = new System.Drawing.Point(2, 9);
			this.lbl_DM.Name = "lbl_DM";
			this.lbl_DM.Size = new System.Drawing.Size(285, 19);
			this.lbl_DM.TabIndex = 0;
			this.lbl_DM.Text = "DANH MỤC KHÁCH HÀNG";
			this.lbl_DM.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// dgv_DanhMuc
			// 
			this.dgv_DanhMuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgv_DanhMuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgv_DanhMuc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgv_DanhMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_DanhMuc.Location = new System.Drawing.Point(12, 41);
			this.dgv_DanhMuc.Name = "dgv_DanhMuc";
			this.dgv_DanhMuc.Size = new System.Drawing.Size(260, 171);
			this.dgv_DanhMuc.TabIndex = 1;
			// 
			// btn_TroVe
			// 
			this.btn_TroVe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_TroVe.Location = new System.Drawing.Point(197, 226);
			this.btn_TroVe.Name = "btn_TroVe";
			this.btn_TroVe.Size = new System.Drawing.Size(75, 23);
			this.btn_TroVe.TabIndex = 2;
			this.btn_TroVe.Text = "Trở về";
			this.btn_TroVe.UseVisualStyleBackColor = true;
			this.btn_TroVe.Click += new System.EventHandler(this.btn_TroVe_Click);
			// 
			// DanhMuc
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.btn_TroVe);
			this.Controls.Add(this.dgv_DanhMuc);
			this.Controls.Add(this.lbl_DM);
			this.Name = "DanhMuc";
			this.Text = "Danh mục khách hàng";
			this.Load += new System.EventHandler(this.DanhMucKhachHang_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv_DanhMuc)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lbl_DM;
		private System.Windows.Forms.DataGridView dgv_DanhMuc;
		private System.Windows.Forms.Button btn_TroVe;
	}
}