namespace FakeIP
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
            this.txt_sock5 = new System.Windows.Forms.TextBox();
            this.txt_website = new System.Windows.Forms.TextBox();
            this.btn_get = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP sock5:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Website:";
            // 
            // txt_sock5
            // 
            this.txt_sock5.Location = new System.Drawing.Point(78, 19);
            this.txt_sock5.Name = "txt_sock5";
            this.txt_sock5.Size = new System.Drawing.Size(263, 20);
            this.txt_sock5.TabIndex = 2;
            this.txt_sock5.Text = "104.248.241.145:1080";
            // 
            // txt_website
            // 
            this.txt_website.Location = new System.Drawing.Point(78, 50);
            this.txt_website.Name = "txt_website";
            this.txt_website.Size = new System.Drawing.Size(263, 20);
            this.txt_website.TabIndex = 3;
            this.txt_website.Text = "https://whoer.net";
            // 
            // btn_get
            // 
            this.btn_get.Location = new System.Drawing.Point(363, 19);
            this.btn_get.Name = "btn_get";
            this.btn_get.Size = new System.Drawing.Size(75, 51);
            this.btn_get.TabIndex = 5;
            this.btn_get.Text = "Get";
            this.btn_get.UseVisualStyleBackColor = true;
            this.btn_get.Click += new System.EventHandler(this.btn_get_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(12, 92);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(421, 286);
            this.webBrowser1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 390);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btn_get);
            this.Controls.Add(this.txt_website);
            this.Controls.Add(this.txt_sock5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Fake Ip Xnet - https://laptrinhvb.net";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_sock5;
        private System.Windows.Forms.TextBox txt_website;
        private System.Windows.Forms.Button btn_get;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}

