namespace FindAllProcessLockedFile
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_find_kill = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.btn_browser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(411, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "C:\\Users\\nguye\\Desktop\\Book1.xlsx";
            // 
            // btn_find_kill
            // 
            this.btn_find_kill.Location = new System.Drawing.Point(426, 152);
            this.btn_find_kill.Name = "btn_find_kill";
            this.btn_find_kill.Size = new System.Drawing.Size(88, 23);
            this.btn_find_kill.TabIndex = 1;
            this.btn_find_kill.Text = "Find and Kill";
            this.btn_find_kill.UseVisualStyleBackColor = true;
            this.btn_find_kill.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Uri File Locked:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "List Process Locked File:";
            // 
            // txt_result
            // 
            this.txt_result.Location = new System.Drawing.Point(17, 87);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.Size = new System.Drawing.Size(497, 59);
            this.txt_result.TabIndex = 4;
            // 
            // btn_browser
            // 
            this.btn_browser.Location = new System.Drawing.Point(439, 37);
            this.btn_browser.Name = "btn_browser";
            this.btn_browser.Size = new System.Drawing.Size(75, 23);
            this.btn_browser.TabIndex = 5;
            this.btn_browser.Text = "Browser...";
            this.btn_browser.UseVisualStyleBackColor = true;
            this.btn_browser.Click += new System.EventHandler(this.btn_browser_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 187);
            this.Controls.Add(this.btn_browser);
            this.Controls.Add(this.txt_result);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_find_kill);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "[C#] Find Process Locked File and Kill Process - https://laptrinhvb.net";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_find_kill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.Button btn_browser;
    }
}

