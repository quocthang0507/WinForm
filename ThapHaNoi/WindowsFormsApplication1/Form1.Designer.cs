namespace WindowsFormsApplication1
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
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cboNhanDia3 = new System.Windows.Forms.ComboBox();
			this.cboNhanDia2 = new System.Windows.Forms.ComboBox();
			this.cboNhanDia1 = new System.Windows.Forms.ComboBox();
			this.txtSoDia = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.listBox_FieldList = new System.Windows.Forms.ListBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.txtTongBuoc = new System.Windows.Forms.TextBox();
			this.btXoaDuLieuChayLai = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Blue;
			this.label1.Location = new System.Drawing.Point(229, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(451, 42);
			this.label1.TabIndex = 0;
			this.label1.Text = "BÀI TOÁN THÁP HÀ NỘI";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.label2.Location = new System.Drawing.Point(59, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 21);
			this.label2.TabIndex = 1;
			this.label2.Text = "Nhập số đĩa:";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.label3.Location = new System.Drawing.Point(38, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(127, 21);
			this.label3.TabIndex = 1;
			this.label3.Text = "Nhập nhãn cọc:";
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(42, 319);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(183, 42);
			this.button1.TabIndex = 3;
			this.button1.Text = "Chạy thuật toán";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.groupBox1.Controls.Add(this.cboNhanDia3);
			this.groupBox1.Controls.Add(this.cboNhanDia2);
			this.groupBox1.Controls.Add(this.cboNhanDia1);
			this.groupBox1.Controls.Add(this.txtSoDia);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(42, 67);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(577, 164);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông tin nhập";
			// 
			// cboNhanDia3
			// 
			this.cboNhanDia3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cboNhanDia3.FormattingEnabled = true;
			this.cboNhanDia3.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
			this.cboNhanDia3.Location = new System.Drawing.Point(408, 104);
			this.cboNhanDia3.Name = "cboNhanDia3";
			this.cboNhanDia3.Size = new System.Drawing.Size(80, 29);
			this.cboNhanDia3.TabIndex = 3;
			this.cboNhanDia3.SelectedIndexChanged += new System.EventHandler(this.cboNhanDia3_SelectedIndexChanged);
			// 
			// cboNhanDia2
			// 
			this.cboNhanDia2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cboNhanDia2.FormattingEnabled = true;
			this.cboNhanDia2.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
			this.cboNhanDia2.Location = new System.Drawing.Point(298, 104);
			this.cboNhanDia2.Name = "cboNhanDia2";
			this.cboNhanDia2.Size = new System.Drawing.Size(80, 29);
			this.cboNhanDia2.TabIndex = 3;
			this.cboNhanDia2.SelectedIndexChanged += new System.EventHandler(this.cboNhanDia2_SelectedIndexChanged);
			// 
			// cboNhanDia1
			// 
			this.cboNhanDia1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cboNhanDia1.FormattingEnabled = true;
			this.cboNhanDia1.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
			this.cboNhanDia1.Location = new System.Drawing.Point(188, 104);
			this.cboNhanDia1.Name = "cboNhanDia1";
			this.cboNhanDia1.Size = new System.Drawing.Size(80, 29);
			this.cboNhanDia1.TabIndex = 3;
			this.cboNhanDia1.SelectedIndexChanged += new System.EventHandler(this.cboNhanDia1_SelectedIndexChanged);
			// 
			// txtSoDia
			// 
			this.txtSoDia.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtSoDia.FormattingEnabled = true;
			this.txtSoDia.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
			this.txtSoDia.Location = new System.Drawing.Point(194, 34);
			this.txtSoDia.Name = "txtSoDia";
			this.txtSoDia.Size = new System.Drawing.Size(81, 29);
			this.txtSoDia.TabIndex = 3;
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.label6.Location = new System.Drawing.Point(418, 78);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 21);
			this.label6.TabIndex = 1;
			this.label6.Text = "Cọc 3";
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.label5.Location = new System.Drawing.Point(308, 78);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 21);
			this.label5.TabIndex = 1;
			this.label5.Text = "Cọc 2";
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.label4.Location = new System.Drawing.Point(198, 78);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 21);
			this.label4.TabIndex = 1;
			this.label4.Text = "Cọc 1";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.groupBox2.Controls.Add(this.listBox_FieldList);
			this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(258, 310);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(587, 252);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Thông tin xuất";
			// 
			// listBox_FieldList
			// 
			this.listBox_FieldList.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.listBox_FieldList.FormattingEnabled = true;
			this.listBox_FieldList.ItemHeight = 21;
			this.listBox_FieldList.Location = new System.Drawing.Point(17, 30);
			this.listBox_FieldList.Name = "listBox_FieldList";
			this.listBox_FieldList.ScrollAlwaysVisible = true;
			this.listBox_FieldList.Size = new System.Drawing.Size(551, 214);
			this.listBox_FieldList.TabIndex = 33;
			// 
			// button2
			// 
			this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(42, 529);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(183, 33);
			this.button2.TabIndex = 3;
			this.button2.Text = "Thoát";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.label7.Location = new System.Drawing.Point(271, 577);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(161, 21);
			this.label7.TabIndex = 1;
			this.label7.Text = "Tổng số bước chạy:";
			// 
			// txtTongBuoc
			// 
			this.txtTongBuoc.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtTongBuoc.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTongBuoc.Location = new System.Drawing.Point(450, 577);
			this.txtTongBuoc.Name = "txtTongBuoc";
			this.txtTongBuoc.Size = new System.Drawing.Size(160, 29);
			this.txtTongBuoc.TabIndex = 7;
			this.txtTongBuoc.TextChanged += new System.EventHandler(this.txtTongBuoc_TextChanged);
			// 
			// btXoaDuLieuChayLai
			// 
			this.btXoaDuLieuChayLai.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btXoaDuLieuChayLai.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btXoaDuLieuChayLai.Location = new System.Drawing.Point(42, 376);
			this.btXoaDuLieuChayLai.Name = "btXoaDuLieuChayLai";
			this.btXoaDuLieuChayLai.Size = new System.Drawing.Size(183, 36);
			this.btXoaDuLieuChayLai.TabIndex = 8;
			this.btXoaDuLieuChayLai.Text = "Xóa dữ liệu chạy lại";
			this.btXoaDuLieuChayLai.UseVisualStyleBackColor = true;
			this.btXoaDuLieuChayLai.Click += new System.EventHandler(this.btXoaDuLieuChayLai_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(855, 639);
			this.Controls.Add(this.btXoaDuLieuChayLai);
			this.Controls.Add(this.txtTongBuoc);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Tháp Hà Nội";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cboNhanDia3;
        private System.Windows.Forms.ComboBox cboNhanDia2;
        private System.Windows.Forms.ComboBox cboNhanDia1;
        private System.Windows.Forms.ComboBox txtSoDia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox_FieldList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTongBuoc;
        private System.Windows.Forms.Button btXoaDuLieuChayLai;
    }
}

