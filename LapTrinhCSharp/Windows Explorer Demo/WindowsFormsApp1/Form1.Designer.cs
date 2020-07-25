namespace WindowsFormsApp1
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
			this.explorerBrowser = new Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser();
			this.btn_back = new System.Windows.Forms.Button();
			this.btn_forward = new System.Windows.Forms.Button();
			this.txt_location = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lbl_fileName_select = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// explorerBrowser
			// 
			this.explorerBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.explorerBrowser.Location = new System.Drawing.Point(-1, 91);
			this.explorerBrowser.Name = "explorerBrowser";
			this.explorerBrowser.PropertyBagName = "Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser";
			this.explorerBrowser.Size = new System.Drawing.Size(733, 430);
			this.explorerBrowser.TabIndex = 0;
			// 
			// btn_back
			// 
			this.btn_back.Enabled = false;
			this.btn_back.Location = new System.Drawing.Point(3, 42);
			this.btn_back.Name = "btn_back";
			this.btn_back.Size = new System.Drawing.Size(75, 23);
			this.btn_back.TabIndex = 1;
			this.btn_back.Text = "< Back";
			this.btn_back.UseVisualStyleBackColor = true;
			this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
			// 
			// btn_forward
			// 
			this.btn_forward.Enabled = false;
			this.btn_forward.Location = new System.Drawing.Point(84, 42);
			this.btn_forward.Name = "btn_forward";
			this.btn_forward.Size = new System.Drawing.Size(75, 23);
			this.btn_forward.TabIndex = 2;
			this.btn_forward.Text = "Forward >";
			this.btn_forward.UseVisualStyleBackColor = true;
			this.btn_forward.Click += new System.EventHandler(this.btn_forward_Click);
			// 
			// txt_location
			// 
			this.txt_location.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_location.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_location.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.txt_location.Location = new System.Drawing.Point(237, 44);
			this.txt_location.Name = "txt_location";
			this.txt_location.Size = new System.Drawing.Size(408, 21);
			this.txt_location.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(165, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Location:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.label2.Location = new System.Drawing.Point(3, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(718, 21);
			this.label2.TabIndex = 5;
			this.label2.Text = "INCLUDE WINDOWS EXPLORER TO WINFORM C# - LAPTRINHVB.NET";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(4, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(132, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Windows Explorer";
			// 
			// lbl_fileName_select
			// 
			this.lbl_fileName_select.AutoSize = true;
			this.lbl_fileName_select.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_fileName_select.ForeColor = System.Drawing.Color.Red;
			this.lbl_fileName_select.Location = new System.Drawing.Point(165, 72);
			this.lbl_fileName_select.Name = "lbl_fileName_select";
			this.lbl_fileName_select.Size = new System.Drawing.Size(0, 16);
			this.lbl_fileName_select.TabIndex = 7;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(733, 520);
			this.Controls.Add(this.lbl_fileName_select);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txt_location);
			this.Controls.Add(this.btn_forward);
			this.Controls.Add(this.btn_back);
			this.Controls.Add(this.explorerBrowser);
			this.Name = "Form1";
			this.Text = "[C#] File Managent Windows Explorer - https://laptrinhvb.net";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser explorerBrowser;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_forward;
        private System.Windows.Forms.TextBox txt_location;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_fileName_select;
    }
}

