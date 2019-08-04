namespace TaoFormDangNhap
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.txtPass = new System.Windows.Forms.TextBox();
			this.chkNho = new System.Windows.Forms.CheckBox();
			this.btnDangNhap = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			this.btnDung = new System.Windows.Forms.Button();
			this.btnView = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(35, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tên đăng nhập";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(65, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "Mật khẩu";
			// 
			// txtUser
			// 
			this.txtUser.Location = new System.Drawing.Point(130, 20);
			this.txtUser.MaxLength = 50;
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(144, 23);
			this.txtUser.TabIndex = 2;
			// 
			// txtPass
			// 
			this.txtPass.Location = new System.Drawing.Point(130, 50);
			this.txtPass.MaxLength = 50;
			this.txtPass.Name = "txtPass";
			this.txtPass.PasswordChar = '*';
			this.txtPass.Size = new System.Drawing.Size(144, 23);
			this.txtPass.TabIndex = 3;
			// 
			// chkNho
			// 
			this.chkNho.AutoSize = true;
			this.chkNho.Location = new System.Drawing.Point(55, 85);
			this.chkNho.Name = "chkNho";
			this.chkNho.Size = new System.Drawing.Size(68, 19);
			this.chkNho.TabIndex = 4;
			this.chkNho.Text = "Ghi nhớ";
			this.chkNho.UseVisualStyleBackColor = true;
			// 
			// btnDangNhap
			// 
			this.btnDangNhap.Location = new System.Drawing.Point(22, 113);
			this.btnDangNhap.Name = "btnDangNhap";
			this.btnDangNhap.Size = new System.Drawing.Size(83, 27);
			this.btnDangNhap.TabIndex = 5;
			this.btnDangNhap.Text = "Đăng nhập";
			this.btnDangNhap.UseVisualStyleBackColor = true;
			this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
			// 
			// btnXoa
			// 
			this.btnXoa.Location = new System.Drawing.Point(129, 113);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(83, 27);
			this.btnXoa.TabIndex = 6;
			this.btnXoa.Text = "Xóa";
			this.btnXoa.UseVisualStyleBackColor = true;
			this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
			// 
			// btnDung
			// 
			this.btnDung.Location = new System.Drawing.Point(233, 113);
			this.btnDung.Name = "btnDung";
			this.btnDung.Size = new System.Drawing.Size(83, 27);
			this.btnDung.TabIndex = 7;
			this.btnDung.Text = "Dừng";
			this.btnDung.UseVisualStyleBackColor = true;
			this.btnDung.Click += new System.EventHandler(this.btnDung_Click);
			// 
			// btnView
			// 
			this.btnView.Location = new System.Drawing.Point(280, 51);
			this.btnView.Name = "btnView";
			this.btnView.Size = new System.Drawing.Size(21, 23);
			this.btnView.TabIndex = 8;
			this.btnView.Text = "😎";
			this.btnView.UseVisualStyleBackColor = true;
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			// 
			// Form_DangNhap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightCyan;
			this.ClientSize = new System.Drawing.Size(338, 154);
			this.Controls.Add(this.btnView);
			this.Controls.Add(this.btnDung);
			this.Controls.Add(this.btnXoa);
			this.Controls.Add(this.btnDangNhap);
			this.Controls.Add(this.chkNho);
			this.Controls.Add(this.txtPass);
			this.Controls.Add(this.txtUser);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaximizeBox = false;
			this.Name = "Form_DangNhap";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Đăng nhập";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.TextBox txtPass;
		private System.Windows.Forms.CheckBox chkNho;
		private System.Windows.Forms.Button btnDangNhap;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnDung;
		private System.Windows.Forms.Button btnView;
	}
}

