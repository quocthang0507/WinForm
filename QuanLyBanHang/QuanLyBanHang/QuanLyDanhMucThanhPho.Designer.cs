namespace QuanLyBanHang
{
    partial class QuanLyDanhMucThanhPho
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_ThanhPho = new System.Windows.Forms.TextBox();
            this.tbx_TenThanhPho = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_ThanhPho = new System.Windows.Forms.DataGridView();
            this.btn_Reload = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_HuyBo = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_TroVe = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ThanhPho)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbx_TenThanhPho);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbx_ThanhPho);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(15, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 80);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(56, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thành phố";
            // 
            // tbx_ThanhPho
            // 
            this.tbx_ThanhPho.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbx_ThanhPho.Location = new System.Drawing.Point(141, 9);
            this.tbx_ThanhPho.Name = "tbx_ThanhPho";
            this.tbx_ThanhPho.Size = new System.Drawing.Size(134, 26);
            this.tbx_ThanhPho.TabIndex = 1;
            // 
            // tbx_TenThanhPho
            // 
            this.tbx_TenThanhPho.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbx_TenThanhPho.Location = new System.Drawing.Point(141, 38);
            this.tbx_TenThanhPho.Name = "tbx_TenThanhPho";
            this.tbx_TenThanhPho.Size = new System.Drawing.Size(134, 26);
            this.tbx_TenThanhPho.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(31, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên thành phố";
            // 
            // dgv_ThanhPho
            // 
            this.dgv_ThanhPho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ThanhPho.Location = new System.Drawing.Point(15, 106);
            this.dgv_ThanhPho.Name = "dgv_ThanhPho";
            this.dgv_ThanhPho.Size = new System.Drawing.Size(313, 150);
            this.dgv_ThanhPho.TabIndex = 1;
            // 
            // btn_Reload
            // 
            this.btn_Reload.Location = new System.Drawing.Point(20, 266);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(75, 23);
            this.btn_Reload.TabIndex = 2;
            this.btn_Reload.Text = "Reload";
            this.btn_Reload.UseVisualStyleBackColor = true;
            this.btn_Reload.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // btn_Luu
            // 
            this.btn_Luu.Location = new System.Drawing.Point(20, 295);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(75, 23);
            this.btn_Luu.TabIndex = 3;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(101, 266);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(75, 23);
            this.btn_Them.TabIndex = 4;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_HuyBo
            // 
            this.btn_HuyBo.Location = new System.Drawing.Point(101, 295);
            this.btn_HuyBo.Name = "btn_HuyBo";
            this.btn_HuyBo.Size = new System.Drawing.Size(75, 23);
            this.btn_HuyBo.TabIndex = 5;
            this.btn_HuyBo.Text = "Huỷ bỏ";
            this.btn_HuyBo.UseVisualStyleBackColor = true;
            this.btn_HuyBo.Click += new System.EventHandler(this.btn_HuyBo_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Location = new System.Drawing.Point(182, 266);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(75, 23);
            this.btn_Sua.TabIndex = 6;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Location = new System.Drawing.Point(182, 295);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(75, 23);
            this.btn_Xoa.TabIndex = 7;
            this.btn_Xoa.Text = "Xoá";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_TroVe
            // 
            this.btn_TroVe.Location = new System.Drawing.Point(260, 266);
            this.btn_TroVe.Name = "btn_TroVe";
            this.btn_TroVe.Size = new System.Drawing.Size(56, 52);
            this.btn_TroVe.TabIndex = 8;
            this.btn_TroVe.Text = "Trở về";
            this.btn_TroVe.UseVisualStyleBackColor = true;
            this.btn_TroVe.Click += new System.EventHandler(this.btn_TroVe_Click);
            // 
            // QuanLyDanhMucThanhPho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 327);
            this.Controls.Add(this.btn_TroVe);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.btn_HuyBo);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.btn_Reload);
            this.Controls.Add(this.dgv_ThanhPho);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "QuanLyDanhMucThanhPho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "QuanLyDanhMucThanhPho";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuanLyDanhMucThanhPho_FormClosing);
            this.Load += new System.EventHandler(this.QuanLyDanhMucThanhPho_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ThanhPho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbx_TenThanhPho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_ThanhPho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_ThanhPho;
        private System.Windows.Forms.Button btn_Reload;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_HuyBo;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_TroVe;
    }
}