namespace TypingMaster
{
	partial class form_welcome
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbx_gender = new System.Windows.Forms.ComboBox();
			this.nud_age = new System.Windows.Forms.NumericUpDown();
			this.tbx_name = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btn_start = new System.Windows.Forms.Button();
			this.btn_quit = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_age)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Dancing Script", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(477, 64);
			this.label1.TabIndex = 0;
			this.label1.Text = "Welcome you to Typing Master";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbx_gender);
			this.groupBox1.Controls.Add(this.nud_age);
			this.groupBox1.Controls.Add(this.tbx_name);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(47, 76);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(386, 203);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Your info";
			// 
			// cbx_gender
			// 
			this.cbx_gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbx_gender.FormattingEnabled = true;
			this.cbx_gender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Not at all"});
			this.cbx_gender.Location = new System.Drawing.Point(148, 137);
			this.cbx_gender.Name = "cbx_gender";
			this.cbx_gender.Size = new System.Drawing.Size(121, 29);
			this.cbx_gender.TabIndex = 3;
			// 
			// nud_age
			// 
			this.nud_age.Location = new System.Drawing.Point(148, 90);
			this.nud_age.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
			this.nud_age.Name = "nud_age";
			this.nud_age.Size = new System.Drawing.Size(85, 29);
			this.nud_age.TabIndex = 2;
			// 
			// tbx_name
			// 
			this.tbx_name.Location = new System.Drawing.Point(148, 48);
			this.tbx_name.MaxLength = 100;
			this.tbx_name.Name = "tbx_name";
			this.tbx_name.Size = new System.Drawing.Size(213, 29);
			this.tbx_name.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(60, 137);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 25);
			this.label4.TabIndex = 2;
			this.label4.Text = "Gender";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(77, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 25);
			this.label3.TabIndex = 1;
			this.label3.Text = "Age";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(60, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 25);
			this.label2.TabIndex = 0;
			this.label2.Text = "Name";
			// 
			// btn_start
			// 
			this.btn_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_start.Location = new System.Drawing.Point(129, 315);
			this.btn_start.Name = "btn_start";
			this.btn_start.Size = new System.Drawing.Size(87, 35);
			this.btn_start.TabIndex = 4;
			this.btn_start.Text = "Start!";
			this.btn_start.UseVisualStyleBackColor = true;
			this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
			// 
			// btn_quit
			// 
			this.btn_quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_quit.Location = new System.Drawing.Point(249, 315);
			this.btn_quit.Name = "btn_quit";
			this.btn_quit.Size = new System.Drawing.Size(87, 35);
			this.btn_quit.TabIndex = 5;
			this.btn_quit.Text = "Quit";
			this.btn_quit.UseVisualStyleBackColor = true;
			this.btn_quit.Click += new System.EventHandler(this.btn_quit_Click);
			// 
			// form_welcome
			// 
			this.AcceptButton = this.btn_start;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(477, 374);
			this.Controls.Add(this.btn_quit);
			this.Controls.Add(this.btn_start);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "form_welcome";
			this.Text = "Typing Master";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_age)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cbx_gender;
		private System.Windows.Forms.NumericUpDown nud_age;
		private System.Windows.Forms.TextBox tbx_name;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_start;
		private System.Windows.Forms.Button btn_quit;
	}
}

