namespace EncryptAndDecryptFile
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
			this.txt_pass = new System.Windows.Forms.TextBox();
			this.txtPlaintextFile = new System.Windows.Forms.RichTextBox();
			this.txtCiphertextFile = new System.Windows.Forms.RichTextBox();
			this.txtDecipheredFile = new System.Windows.Forms.RichTextBox();
			this.btn_encrypt = new System.Windows.Forms.Button();
			this.btn_decrypt = new System.Windows.Forms.Button();
			this.btn_browser = new System.Windows.Forms.Button();
			this.txt_url = new System.Windows.Forms.TextBox();
			this.txt_url_encrypt = new System.Windows.Forms.TextBox();
			this.txt_url_decrypt = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(306, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mật khẩu:";
			// 
			// txt_pass
			// 
			this.txt_pass.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txt_pass.Location = new System.Drawing.Point(367, 12);
			this.txt_pass.Name = "txt_pass";
			this.txt_pass.Size = new System.Drawing.Size(510, 20);
			this.txt_pass.TabIndex = 1;
			this.txt_pass.Text = "MatKhau";
			// 
			// txtPlaintextFile
			// 
			this.txtPlaintextFile.Location = new System.Drawing.Point(12, 79);
			this.txtPlaintextFile.Name = "txtPlaintextFile";
			this.txtPlaintextFile.Size = new System.Drawing.Size(350, 350);
			this.txtPlaintextFile.TabIndex = 2;
			this.txtPlaintextFile.Text = "";
			// 
			// txtCiphertextFile
			// 
			this.txtCiphertextFile.Location = new System.Drawing.Point(437, 79);
			this.txtCiphertextFile.Name = "txtCiphertextFile";
			this.txtCiphertextFile.Size = new System.Drawing.Size(350, 350);
			this.txtCiphertextFile.TabIndex = 3;
			this.txtCiphertextFile.Text = "";
			// 
			// txtDecipheredFile
			// 
			this.txtDecipheredFile.Location = new System.Drawing.Point(862, 78);
			this.txtDecipheredFile.Name = "txtDecipheredFile";
			this.txtDecipheredFile.Size = new System.Drawing.Size(350, 351);
			this.txtDecipheredFile.TabIndex = 4;
			this.txtDecipheredFile.Text = "";
			// 
			// btn_encrypt
			// 
			this.btn_encrypt.Location = new System.Drawing.Point(368, 234);
			this.btn_encrypt.Name = "btn_encrypt";
			this.btn_encrypt.Size = new System.Drawing.Size(63, 23);
			this.btn_encrypt.TabIndex = 5;
			this.btn_encrypt.Text = "Mã hóa";
			this.btn_encrypt.UseVisualStyleBackColor = true;
			this.btn_encrypt.Click += new System.EventHandler(this.btn_encrypt_Click);
			// 
			// btn_decrypt
			// 
			this.btn_decrypt.Location = new System.Drawing.Point(793, 234);
			this.btn_decrypt.Name = "btn_decrypt";
			this.btn_decrypt.Size = new System.Drawing.Size(63, 23);
			this.btn_decrypt.TabIndex = 6;
			this.btn_decrypt.Text = "Giải mã";
			this.btn_decrypt.UseVisualStyleBackColor = true;
			this.btn_decrypt.Click += new System.EventHandler(this.btn_decrypt_Click);
			// 
			// btn_browser
			// 
			this.btn_browser.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_browser.Location = new System.Drawing.Point(908, 12);
			this.btn_browser.Name = "btn_browser";
			this.btn_browser.Size = new System.Drawing.Size(83, 23);
			this.btn_browser.TabIndex = 7;
			this.btn_browser.Text = "Chọn file...";
			this.btn_browser.UseVisualStyleBackColor = true;
			this.btn_browser.Click += new System.EventHandler(this.button2_Click);
			// 
			// txt_url
			// 
			this.txt_url.Location = new System.Drawing.Point(12, 41);
			this.txt_url.Multiline = true;
			this.txt_url.Name = "txt_url";
			this.txt_url.Size = new System.Drawing.Size(350, 30);
			this.txt_url.TabIndex = 8;
			// 
			// txt_url_encrypt
			// 
			this.txt_url_encrypt.Location = new System.Drawing.Point(437, 42);
			this.txt_url_encrypt.Multiline = true;
			this.txt_url_encrypt.Name = "txt_url_encrypt";
			this.txt_url_encrypt.Size = new System.Drawing.Size(350, 30);
			this.txt_url_encrypt.TabIndex = 9;
			// 
			// txt_url_decrypt
			// 
			this.txt_url_decrypt.Location = new System.Drawing.Point(862, 44);
			this.txt_url_decrypt.Multiline = true;
			this.txt_url_decrypt.Name = "txt_url_decrypt";
			this.txt_url_decrypt.Size = new System.Drawing.Size(350, 30);
			this.txt_url_decrypt.TabIndex = 10;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1224, 441);
			this.Controls.Add(this.txt_url_decrypt);
			this.Controls.Add(this.txt_url_encrypt);
			this.Controls.Add(this.txt_url);
			this.Controls.Add(this.btn_browser);
			this.Controls.Add(this.btn_decrypt);
			this.Controls.Add(this.btn_encrypt);
			this.Controls.Add(this.txtDecipheredFile);
			this.Controls.Add(this.txtCiphertextFile);
			this.Controls.Add(this.txtPlaintextFile);
			this.Controls.Add(this.txt_pass);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Mã hóa và Giải mã File";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.RichTextBox txtPlaintextFile;
        private System.Windows.Forms.RichTextBox txtCiphertextFile;
        private System.Windows.Forms.RichTextBox txtDecipheredFile;
        private System.Windows.Forms.Button btn_encrypt;
        private System.Windows.Forms.Button btn_decrypt;
        private System.Windows.Forms.Button btn_browser;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.TextBox txt_url_encrypt;
        private System.Windows.Forms.TextBox txt_url_decrypt;
    }
}

