namespace Ma_di_tuan
{
    partial class Init
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Init));
            this.label1 = new System.Windows.Forms.Label();
            this.txtKT = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.vistaButton1 = new VistaButton.VistaButton();
            this.vistaButton2 = new VistaButton.VistaButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(65, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kích thước bàn cờ:";
            // 
            // txtKT
            // 
            this.txtKT.Location = new System.Drawing.Point(170, 51);
            this.txtKT.Name = "txtKT";
            this.txtKT.Size = new System.Drawing.Size(100, 20);
            this.txtKT.TabIndex = 0;
            this.txtKT.Text = "8";
            this.txtKT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtKT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtY);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtX);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 96);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vị trí xuất phát";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(158, 58);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(100, 20);
            this.txtY.TabIndex = 2;
            this.txtY.Text = "3";
            this.txtY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tọa độ Y:";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(158, 32);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(100, 20);
            this.txtX.TabIndex = 1;
            this.txtX.Text = "4";
            this.txtX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tọa độ X:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(332, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Chương trình mô phỏng bài toán mã đi tuần";
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.BaseColor = System.Drawing.Color.MidnightBlue;
            this.vistaButton1.ButtonText = "OK";
            this.vistaButton1.Location = new System.Drawing.Point(253, 185);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(80, 29);
            this.vistaButton1.TabIndex = 6;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // vistaButton2
            // 
            this.vistaButton2.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton2.BaseColor = System.Drawing.Color.MidnightBlue;
            this.vistaButton2.ButtonText = "Cancel";
            this.vistaButton2.Location = new System.Drawing.Point(170, 185);
            this.vistaButton2.Name = "vistaButton2";
            this.vistaButton2.Size = new System.Drawing.Size(80, 29);
            this.vistaButton2.TabIndex = 7;
            this.vistaButton2.Click += new System.EventHandler(this.vistaButton2_Click);
            // 
            // Init
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(345, 221);
            this.Controls.Add(this.vistaButton2);
            this.Controls.Add(this.vistaButton1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtKT);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Init";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Init";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private VistaButton.VistaButton vistaButton1;
        private VistaButton.VistaButton vistaButton2;
    }
}