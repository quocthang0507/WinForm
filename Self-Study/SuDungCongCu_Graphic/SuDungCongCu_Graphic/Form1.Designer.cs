namespace SuDungCongCu_Graphic
{
	partial class VeHCN
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.btPlay = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Location = new System.Drawing.Point(20, 61);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(239, 178);
			this.panel1.TabIndex = 0;
			// 
			// btPlay
			// 
			this.btPlay.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btPlay.Location = new System.Drawing.Point(101, 21);
			this.btPlay.Name = "btPlay";
			this.btPlay.Size = new System.Drawing.Size(75, 23);
			this.btPlay.TabIndex = 1;
			this.btPlay.Text = "Play";
			this.btPlay.UseVisualStyleBackColor = true;
			this.btPlay.Click += new System.EventHandler(this.btPlay_Click);
			// 
			// VeHCN
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.btPlay);
			this.Controls.Add(this.panel1);
			this.MaximizeBox = false;
			this.Name = "VeHCN";
			this.Text = "Chương trình vẽ hình chữ nhật";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btPlay;
	}
}

