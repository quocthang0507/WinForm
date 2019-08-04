namespace CongCuTreeView
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbt1 = new System.Windows.Forms.ToolStripButton();
			this.tsbt2 = new System.Windows.Forms.ToolStripButton();
			this.treeView = new System.Windows.Forms.TreeView();
			this.ilslcons = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbt1,
            this.tsbt2});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(284, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbt1
			// 
			this.tsbt1.Image = ((System.Drawing.Image)(resources.GetObject("tsbt1.Image")));
			this.tsbt1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbt1.Name = "tsbt1";
			this.tsbt1.Size = new System.Drawing.Size(73, 22);
			this.tsbt1.Text = "Mở rộng";
			this.tsbt1.Click += new System.EventHandler(this.tsbt1_Click);
			// 
			// tsbt2
			// 
			this.tsbt2.Image = ((System.Drawing.Image)(resources.GetObject("tsbt2.Image")));
			this.tsbt2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbt2.Name = "tsbt2";
			this.tsbt2.Size = new System.Drawing.Size(72, 22);
			this.tsbt2.Text = "Thu gọn";
			this.tsbt2.Click += new System.EventHandler(this.tsbt2_Click);
			// 
			// treeView
			// 
			this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeView.Location = new System.Drawing.Point(0, 25);
			this.treeView.Name = "treeView";
			this.treeView.Size = new System.Drawing.Size(284, 237);
			this.treeView.TabIndex = 1;
			// 
			// ilslcons
			// 
			this.ilslcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilslcons.ImageStream")));
			this.ilslcons.TransparentColor = System.Drawing.Color.Transparent;
			this.ilslcons.Images.SetKeyName(0, "58927-down-arrow.png");
			this.ilslcons.Images.SetKeyName(1, "up-arrow_318-74795.jpg");
			this.ilslcons.Images.SetKeyName(2, "Flat%20Folder%20icon.png");
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.treeView);
			this.Controls.Add(this.toolStrip1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsbt1;
		private System.Windows.Forms.ToolStripButton tsbt2;
		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.ImageList ilslcons;
	}
}

