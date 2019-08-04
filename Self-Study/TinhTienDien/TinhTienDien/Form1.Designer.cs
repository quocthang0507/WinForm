namespace TinhTienDien
{
	partial class ChuongTrinh
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChuongTrinh));
			this.lblMucDich = new System.Windows.Forms.Label();
			this.lblNoiSuDung = new System.Windows.Forms.Label();
			this.cbbMucDich = new System.Windows.Forms.ComboBox();
			this.cbbNoiSuDung = new System.Windows.Forms.ComboBox();
			this.lblTen = new System.Windows.Forms.Label();
			this.lblChiSoMoi = new System.Windows.Forms.Label();
			this.lblChiSoCu = new System.Windows.Forms.Label();
			this.gpbThongTin = new System.Windows.Forms.GroupBox();
			this.cbbGioSD = new System.Windows.Forms.ComboBox();
			this.lblGioSD = new System.Windows.Forms.Label();
			this.ttbDNTT = new System.Windows.Forms.TextBox();
			this.ttbChiSoCu = new System.Windows.Forms.TextBox();
			this.ttbChiSoMoi = new System.Windows.Forms.TextBox();
			this.lblDNTT = new System.Windows.Forms.Label();
			this.ttbKetQua = new System.Windows.Forms.TextBox();
			this.btnKetQua = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.giờCaoĐiểmLàGìToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.vềToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gpbThongTin.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblMucDich
			// 
			this.lblMucDich.BackColor = System.Drawing.Color.Transparent;
			this.lblMucDich.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMucDich.Location = new System.Drawing.Point(13, 68);
			this.lblMucDich.Name = "lblMucDich";
			this.lblMucDich.Size = new System.Drawing.Size(200, 24);
			this.lblMucDich.TabIndex = 1;
			this.lblMucDich.Text = "Chọn mục đích sử dụng điện :";
			this.lblMucDich.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblNoiSuDung
			// 
			this.lblNoiSuDung.BackColor = System.Drawing.Color.Transparent;
			this.lblNoiSuDung.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNoiSuDung.Location = new System.Drawing.Point(8, 101);
			this.lblNoiSuDung.Name = "lblNoiSuDung";
			this.lblNoiSuDung.Size = new System.Drawing.Size(205, 25);
			this.lblNoiSuDung.TabIndex = 1;
			this.lblNoiSuDung.Text = "Chọn nơi sử dụng :";
			this.lblNoiSuDung.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbbMucDich
			// 
			this.cbbMucDich.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbbMucDich.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbbMucDich.FormattingEnabled = true;
			this.cbbMucDich.Items.AddRange(new object[] {
            "1. Điện sinh hoạt",
            "2. Điện kinh doanh",
            "3. Điện sản xuất",
            "4. Điện cho các cơ quan hành chính",
            "5. Bán buôn điện",
            "6. Bán điện cho khách hàng nước ngoài"});
			this.cbbMucDich.Location = new System.Drawing.Point(219, 71);
			this.cbbMucDich.MaxDropDownItems = 5;
			this.cbbMucDich.Name = "cbbMucDich";
			this.cbbMucDich.Size = new System.Drawing.Size(270, 25);
			this.cbbMucDich.TabIndex = 2;
			this.cbbMucDich.SelectedIndexChanged += new System.EventHandler(this.cbbMucDich_SelectedIndexChanged);
			// 
			// cbbNoiSuDung
			// 
			this.cbbNoiSuDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbbNoiSuDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbbNoiSuDung.FormattingEnabled = true;
			this.cbbNoiSuDung.Items.AddRange(new object[] {
            ""});
			this.cbbNoiSuDung.Location = new System.Drawing.Point(219, 102);
			this.cbbNoiSuDung.Name = "cbbNoiSuDung";
			this.cbbNoiSuDung.Size = new System.Drawing.Size(400, 25);
			this.cbbNoiSuDung.TabIndex = 3;
			this.cbbNoiSuDung.SelectedIndexChanged += new System.EventHandler(this.cbbNoiSuDung_SelectedIndexChanged);
			// 
			// lblTen
			// 
			this.lblTen.BackColor = System.Drawing.Color.Transparent;
			this.lblTen.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblTen.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTen.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblTen.Location = new System.Drawing.Point(0, 24);
			this.lblTen.Name = "lblTen";
			this.lblTen.Size = new System.Drawing.Size(653, 44);
			this.lblTen.TabIndex = 4;
			this.lblTen.Text = "CHƯƠNG TRÌNH TÍNH TIỀN ĐIỆN LỰC EVN";
			this.lblTen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblChiSoMoi
			// 
			this.lblChiSoMoi.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblChiSoMoi.BackColor = System.Drawing.Color.Transparent;
			this.lblChiSoMoi.Location = new System.Drawing.Point(20, 27);
			this.lblChiSoMoi.Name = "lblChiSoMoi";
			this.lblChiSoMoi.Size = new System.Drawing.Size(82, 17);
			this.lblChiSoMoi.TabIndex = 5;
			this.lblChiSoMoi.Text = "Chỉ số mới :";
			this.lblChiSoMoi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblChiSoMoi.Click += new System.EventHandler(this.lblChiSoMoi_Click);
			// 
			// lblChiSoCu
			// 
			this.lblChiSoCu.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblChiSoCu.BackColor = System.Drawing.Color.Transparent;
			this.lblChiSoCu.Location = new System.Drawing.Point(198, 27);
			this.lblChiSoCu.Name = "lblChiSoCu";
			this.lblChiSoCu.Size = new System.Drawing.Size(72, 17);
			this.lblChiSoCu.TabIndex = 6;
			this.lblChiSoCu.Text = "Chỉ số cũ :";
			this.lblChiSoCu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblChiSoCu.Click += new System.EventHandler(this.lblChiSoCu_Click);
			// 
			// gpbThongTin
			// 
			this.gpbThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gpbThongTin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.gpbThongTin.BackColor = System.Drawing.Color.Transparent;
			this.gpbThongTin.Controls.Add(this.cbbGioSD);
			this.gpbThongTin.Controls.Add(this.lblGioSD);
			this.gpbThongTin.Controls.Add(this.ttbDNTT);
			this.gpbThongTin.Controls.Add(this.ttbChiSoCu);
			this.gpbThongTin.Controls.Add(this.ttbChiSoMoi);
			this.gpbThongTin.Controls.Add(this.lblDNTT);
			this.gpbThongTin.Controls.Add(this.lblChiSoCu);
			this.gpbThongTin.Controls.Add(this.lblChiSoMoi);
			this.gpbThongTin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gpbThongTin.Location = new System.Drawing.Point(18, 142);
			this.gpbThongTin.Name = "gpbThongTin";
			this.gpbThongTin.Size = new System.Drawing.Size(603, 105);
			this.gpbThongTin.TabIndex = 11;
			this.gpbThongTin.TabStop = false;
			this.gpbThongTin.Text = "Nhập thông tin";
			// 
			// cbbGioSD
			// 
			this.cbbGioSD.AllowDrop = true;
			this.cbbGioSD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbbGioSD.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbbGioSD.FormattingEnabled = true;
			this.cbbGioSD.Location = new System.Drawing.Point(168, 69);
			this.cbbGioSD.Name = "cbbGioSD";
			this.cbbGioSD.Size = new System.Drawing.Size(357, 25);
			this.cbbGioSD.TabIndex = 12;
			this.cbbGioSD.SelectedIndexChanged += new System.EventHandler(this.cbbGioSD_SelectedIndexChanged);
			// 
			// lblGioSD
			// 
			this.lblGioSD.Location = new System.Drawing.Point(63, 72);
			this.lblGioSD.Name = "lblGioSD";
			this.lblGioSD.Size = new System.Drawing.Size(99, 17);
			this.lblGioSD.TabIndex = 11;
			this.lblGioSD.Text = "Giờ sử dụng :";
			this.lblGioSD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ttbDNTT
			// 
			this.ttbDNTT.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.ttbDNTT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ttbDNTT.Location = new System.Drawing.Point(510, 24);
			this.ttbDNTT.Name = "ttbDNTT";
			this.ttbDNTT.Size = new System.Drawing.Size(77, 25);
			this.ttbDNTT.TabIndex = 10;
			this.ttbDNTT.TextChanged += new System.EventHandler(this.ttbDNTT_TextChanged);
			this.ttbDNTT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ttbDNTT_KeyPress);
			// 
			// ttbChiSoCu
			// 
			this.ttbChiSoCu.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.ttbChiSoCu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ttbChiSoCu.Location = new System.Drawing.Point(276, 24);
			this.ttbChiSoCu.Name = "ttbChiSoCu";
			this.ttbChiSoCu.Size = new System.Drawing.Size(77, 25);
			this.ttbChiSoCu.TabIndex = 10;
			this.ttbChiSoCu.TextChanged += new System.EventHandler(this.ttbChiSoCu_TextChanged);
			this.ttbChiSoCu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ttbChiSoCu_KeyPress);
			// 
			// ttbChiSoMoi
			// 
			this.ttbChiSoMoi.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.ttbChiSoMoi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ttbChiSoMoi.Location = new System.Drawing.Point(108, 24);
			this.ttbChiSoMoi.Name = "ttbChiSoMoi";
			this.ttbChiSoMoi.Size = new System.Drawing.Size(77, 25);
			this.ttbChiSoMoi.TabIndex = 10;
			this.ttbChiSoMoi.TextChanged += new System.EventHandler(this.ttbChiSoMoi_TextChanged_1);
			this.ttbChiSoMoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ttbChiSoMoi_KeyPress);
			// 
			// lblDNTT
			// 
			this.lblDNTT.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblDNTT.BackColor = System.Drawing.Color.Transparent;
			this.lblDNTT.Location = new System.Drawing.Point(372, 27);
			this.lblDNTT.Name = "lblDNTT";
			this.lblDNTT.Size = new System.Drawing.Size(133, 17);
			this.lblDNTT.TabIndex = 9;
			this.lblDNTT.Text = "Điện năng tiêu thụ :";
			this.lblDNTT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblDNTT.Click += new System.EventHandler(this.lblDNTT_Click);
			// 
			// ttbKetQua
			// 
			this.ttbKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.ttbKetQua.Location = new System.Drawing.Point(84, 301);
			this.ttbKetQua.Multiline = true;
			this.ttbKetQua.Name = "ttbKetQua";
			this.ttbKetQua.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.ttbKetQua.Size = new System.Drawing.Size(461, 200);
			this.ttbKetQua.TabIndex = 12;
			this.ttbKetQua.TextChanged += new System.EventHandler(this.ttbKetQua_TextChanged);
			// 
			// btnKetQua
			// 
			this.btnKetQua.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnKetQua.Location = new System.Drawing.Point(214, 253);
			this.btnKetQua.Name = "btnKetQua";
			this.btnKetQua.Size = new System.Drawing.Size(82, 42);
			this.btnKetQua.TabIndex = 13;
			this.btnKetQua.Text = "Kết quả";
			this.btnKetQua.UseVisualStyleBackColor = true;
			this.btnKetQua.Click += new System.EventHandler(this.btnKetQua_Click);
			// 
			// btnXoa
			// 
			this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnXoa.Location = new System.Drawing.Point(333, 253);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(82, 42);
			this.btnXoa.TabIndex = 14;
			this.btnXoa.Text = "Xoá";
			this.btnXoa.UseVisualStyleBackColor = true;
			this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(653, 24);
			this.menuStrip1.TabIndex = 15;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thoátToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.fileToolStripMenuItem.Text = "FILE";
			// 
			// thoátToolStripMenuItem
			// 
			this.thoátToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
			this.thoátToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.thoátToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.thoátToolStripMenuItem.Text = "Thoát";
			this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.giờCaoĐiểmLàGìToolStripMenuItem,
            this.vềToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.helpToolStripMenuItem.Text = "HELP";
			this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
			// 
			// giờCaoĐiểmLàGìToolStripMenuItem
			// 
			this.giờCaoĐiểmLàGìToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.giờCaoĐiểmLàGìToolStripMenuItem.Name = "giờCaoĐiểmLàGìToolStripMenuItem";
			this.giờCaoĐiểmLàGìToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.giờCaoĐiểmLàGìToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.giờCaoĐiểmLàGìToolStripMenuItem.Text = "Giờ cao điểm là gì?";
			this.giờCaoĐiểmLàGìToolStripMenuItem.Click += new System.EventHandler(this.giờCaoĐiểmLàGìToolStripMenuItem_Click);
			// 
			// vềToolStripMenuItem
			// 
			this.vềToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.vềToolStripMenuItem.Name = "vềToolStripMenuItem";
			this.vềToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.vềToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.vềToolStripMenuItem.Text = "Về ...";
			this.vềToolStripMenuItem.Click += new System.EventHandler(this.vềToolStripMenuItem_Click);
			// 
			// ChuongTrinh
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(653, 513);
			this.Controls.Add(this.btnXoa);
			this.Controls.Add(this.btnKetQua);
			this.Controls.Add(this.ttbKetQua);
			this.Controls.Add(this.gpbThongTin);
			this.Controls.Add(this.lblTen);
			this.Controls.Add(this.cbbNoiSuDung);
			this.Controls.Add(this.cbbMucDich);
			this.Controls.Add(this.lblNoiSuDung);
			this.Controls.Add(this.lblMucDich);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ChuongTrinh";
			this.Text = "Chương trình tính tiền điện";
			this.gpbThongTin.ResumeLayout(false);
			this.gpbThongTin.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblMucDich;
		private System.Windows.Forms.Label lblNoiSuDung;
		private System.Windows.Forms.ComboBox cbbMucDich;
		private System.Windows.Forms.ComboBox cbbNoiSuDung;
		private System.Windows.Forms.Label lblTen;
		private System.Windows.Forms.Label lblChiSoMoi;
		private System.Windows.Forms.Label lblChiSoCu;
		private System.Windows.Forms.GroupBox gpbThongTin;
		private System.Windows.Forms.TextBox ttbKetQua;
		private System.Windows.Forms.Button btnKetQua;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.TextBox ttbChiSoCu;
		private System.Windows.Forms.TextBox ttbChiSoMoi;
		private System.Windows.Forms.TextBox ttbDNTT;
		private System.Windows.Forms.Label lblDNTT;
		private System.Windows.Forms.ComboBox cbbGioSD;
		private System.Windows.Forms.Label lblGioSD;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem giờCaoĐiểmLàGìToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem vềToolStripMenuItem;
	}
}

