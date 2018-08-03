namespace ChuongTrinhThiTracNghiem
{
    partial class Form_Question
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Remaining = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Sau = new System.Windows.Forms.Button();
            this.btn_Truoc = new System.Windows.Forms.Button();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.lbl_CauHoi = new System.Windows.Forms.Label();
            this.btn_NopBai = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(530, 28);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(0, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(530, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thời gian còn lại:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Remaining
            // 
            this.lbl_Remaining.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Remaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_Remaining.Location = new System.Drawing.Point(0, 59);
            this.lbl_Remaining.Name = "lbl_Remaining";
            this.lbl_Remaining.Size = new System.Drawing.Size(530, 20);
            this.lbl_Remaining.TabIndex = 2;
            this.lbl_Remaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_Sau);
            this.groupBox1.Controls.Add(this.btn_Truoc);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.lbl_CauHoi);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(0, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 270);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btn_Sau
            // 
            this.btn_Sau.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Sau.Location = new System.Drawing.Point(280, 241);
            this.btn_Sau.Name = "btn_Sau";
            this.btn_Sau.Size = new System.Drawing.Size(75, 23);
            this.btn_Sau.TabIndex = 6;
            this.btn_Sau.Text = ">>";
            this.btn_Sau.UseVisualStyleBackColor = true;
            this.btn_Sau.Click += new System.EventHandler(this.btn_Sau_Click);
            // 
            // btn_Truoc
            // 
            this.btn_Truoc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Truoc.Location = new System.Drawing.Point(199, 241);
            this.btn_Truoc.Name = "btn_Truoc";
            this.btn_Truoc.Size = new System.Drawing.Size(75, 23);
            this.btn_Truoc.TabIndex = 5;
            this.btn_Truoc.Text = "<<";
            this.btn_Truoc.UseVisualStyleBackColor = true;
            this.btn_Truoc.Click += new System.EventHandler(this.btn_Truoc_Click);
            // 
            // radioButton4
            // 
            this.radioButton4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton4.AutoSize = true;
            this.radioButton4.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButton4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton4.Location = new System.Drawing.Point(270, 158);
            this.radioButton4.MaximumSize = new System.Drawing.Size(250, 80);
            this.radioButton4.MinimumSize = new System.Drawing.Size(121, 80);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(121, 80);
            this.radioButton4.TabIndex = 4;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "radioButton4";
            this.radioButton4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton3.AutoSize = true;
            this.radioButton3.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton3.Location = new System.Drawing.Point(12, 158);
            this.radioButton3.MaximumSize = new System.Drawing.Size(250, 80);
            this.radioButton3.MinimumSize = new System.Drawing.Size(121, 80);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(121, 80);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton2.AutoSize = true;
            this.radioButton2.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton2.Location = new System.Drawing.Point(270, 72);
            this.radioButton2.MaximumSize = new System.Drawing.Size(250, 80);
            this.radioButton2.MinimumSize = new System.Drawing.Size(121, 80);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(121, 80);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton1.AutoSize = true;
            this.radioButton1.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton1.Location = new System.Drawing.Point(12, 72);
            this.radioButton1.MaximumSize = new System.Drawing.Size(250, 80);
            this.radioButton1.MinimumSize = new System.Drawing.Size(121, 80);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(121, 80);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // lbl_CauHoi
            // 
            this.lbl_CauHoi.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_CauHoi.Location = new System.Drawing.Point(3, 22);
            this.lbl_CauHoi.Name = "lbl_CauHoi";
            this.lbl_CauHoi.Size = new System.Drawing.Size(524, 47);
            this.lbl_CauHoi.TabIndex = 0;
            this.lbl_CauHoi.Text = "label3";
            this.lbl_CauHoi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_NopBai
            // 
            this.btn_NopBai.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_NopBai.AutoSize = true;
            this.btn_NopBai.Location = new System.Drawing.Point(234, 355);
            this.btn_NopBai.Name = "btn_NopBai";
            this.btn_NopBai.Size = new System.Drawing.Size(75, 26);
            this.btn_NopBai.TabIndex = 7;
            this.btn_NopBai.Text = "Nộp bài";
            this.btn_NopBai.UseVisualStyleBackColor = true;
            this.btn_NopBai.Click += new System.EventHandler(this.btn_NopBai_Click);
            // 
            // Form_Question
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 393);
            this.Controls.Add(this.btn_NopBai);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_Remaining);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_Question";
            this.Text = "Chương trình Thi trắc nghiệm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Question_FormClosing);
            this.Load += new System.EventHandler(this.Form_Question_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Remaining;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_NopBai;
        private System.Windows.Forms.Label lbl_CauHoi;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btn_Sau;
        private System.Windows.Forms.Button btn_Truoc;
    }
}