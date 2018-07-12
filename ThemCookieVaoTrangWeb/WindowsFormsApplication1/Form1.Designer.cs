namespace WindowsFormsApplication1
{
    partial class TrinhDuyet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrinhDuyet));
            this.btn_load = new System.Windows.Forms.Button();
            this.rtx_viewCode = new System.Windows.Forms.RichTextBox();
            this.txt_cookie = new System.Windows.Forms.TextBox();
            this.wbr_Browser = new System.Windows.Forms.WebBrowser();
            this.tbx_address = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_load
            // 
            resources.ApplyResources(this.btn_load, "btn_load");
            this.btn_load.Name = "btn_load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtx_viewCode
            // 
            resources.ApplyResources(this.rtx_viewCode, "rtx_viewCode");
            this.rtx_viewCode.Name = "rtx_viewCode";
            // 
            // txt_cookie
            // 
            resources.ApplyResources(this.txt_cookie, "txt_cookie");
            this.txt_cookie.Name = "txt_cookie";
            // 
            // wbr_Browser
            // 
            resources.ApplyResources(this.wbr_Browser, "wbr_Browser");
            this.wbr_Browser.Name = "wbr_Browser";
            // 
            // tbx_address
            // 
            resources.ApplyResources(this.tbx_address, "tbx_address");
            this.tbx_address.Name = "tbx_address";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.rtx_viewCode);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.wbr_Browser);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // TrinhDuyet
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_address);
            this.Controls.Add(this.txt_cookie);
            this.Controls.Add(this.btn_load);
            this.Name = "TrinhDuyet";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.RichTextBox rtx_viewCode;
        private System.Windows.Forms.TextBox txt_cookie;
        private System.Windows.Forms.WebBrowser wbr_Browser;
        private System.Windows.Forms.TextBox tbx_address;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

