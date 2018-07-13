namespace ThongTinSinhVien_DLU
{
    partial class Form_DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DangNhap));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_Password = new System.Windows.Forms.TextBox();
            this.tbx_UserName = new System.Windows.Forms.TextBox();
            this.btn_LogIn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(80, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mật khẩu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(38, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mã số sinh viên:";
            // 
            // tbx_Password
            // 
            this.tbx_Password.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbx_Password.Location = new System.Drawing.Point(156, 146);
            this.tbx_Password.MaxLength = 50;
            this.tbx_Password.Name = "tbx_Password";
            this.tbx_Password.PasswordChar = '*';
            this.tbx_Password.Size = new System.Drawing.Size(100, 25);
            this.tbx_Password.TabIndex = 2;
            // 
            // tbx_UserName
            // 
            this.tbx_UserName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbx_UserName.Location = new System.Drawing.Point(156, 115);
            this.tbx_UserName.MaxLength = 10;
            this.tbx_UserName.Name = "tbx_UserName";
            this.tbx_UserName.Size = new System.Drawing.Size(100, 25);
            this.tbx_UserName.TabIndex = 1;
            // 
            // btn_LogIn
            // 
            this.btn_LogIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_LogIn.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_LogIn.Location = new System.Drawing.Point(96, 189);
            this.btn_LogIn.Name = "btn_LogIn";
            this.btn_LogIn.Size = new System.Drawing.Size(102, 33);
            this.btn_LogIn.TabIndex = 3;
            this.btn_LogIn.Text = "Đăng nhập";
            this.btn_LogIn.UseVisualStyleBackColor = true;
            this.btn_LogIn.Click += new System.EventHandler(this.btn_LogIn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::ThongTinSinhVien_DLU.Properties.Resources.logo_DLU;
            this.pictureBox1.Location = new System.Drawing.Point(25, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 94);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(293, 251);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_Password);
            this.Controls.Add(this.tbx_UserName);
            this.Controls.Add(this.btn_LogIn);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng nhập vào trang sinh viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_DangNhap_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_Password;
        private System.Windows.Forms.TextBox tbx_UserName;
        private System.Windows.Forms.Button btn_LogIn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

