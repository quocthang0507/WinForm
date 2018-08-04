namespace howto_fit_font
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
            this.label1 = new System.Windows.Forms.Label();
            this.autoResizeLabel1 = new howto_fit_font.AutoResizeLabel();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(415, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "input data:";
            // 
            // autoResizeLabel1
            // 
            this.autoResizeLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 52F);
            this.autoResizeLabel1.font_size = 52;
            this.autoResizeLabel1.ForeColor = System.Drawing.Color.Green;
            this.autoResizeLabel1.Location = new System.Drawing.Point(26, 118);
            this.autoResizeLabel1.Name = "autoResizeLabel1";
            this.autoResizeLabel1.Size = new System.Drawing.Size(602, 201);
            this.autoResizeLabel1.TabIndex = 2;
            this.autoResizeLabel1.Text = "autoResizeLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(630, 328);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.autoResizeLabel1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Create Component AutoResize Label - http://laptrinhvb.net";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private AutoResizeLabel autoResizeLabel1;
        private System.Windows.Forms.Label label1;
    }
}

