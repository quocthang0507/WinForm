namespace ConvertIP_2
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtIP = new System.Windows.Forms.MaskedTextBox();
			this.txtSubnet = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtBroadcast = new System.Windows.Forms.TextBox();
			this.txtNetwork = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnFile = new System.Windows.Forms.Button();
			this.btn_Convert = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panel1.Controls.Add(this.txtIP);
			this.panel1.Controls.Add(this.txtSubnet);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(327, 62);
			this.panel1.TabIndex = 5;
			// 
			// txtIP
			// 
			this.txtIP.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtIP.AsciiOnly = true;
			this.txtIP.BeepOnError = true;
			this.txtIP.Location = new System.Drawing.Point(143, 3);
			this.txtIP.Mask = "000.000.000.000";
			this.txtIP.Name = "txtIP";
			this.txtIP.Size = new System.Drawing.Size(165, 22);
			this.txtIP.TabIndex = 1;
			this.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtIP.Leave += new System.EventHandler(this.txtIP_Leave);
			// 
			// txtSubnet
			// 
			this.txtSubnet.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtSubnet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.txtSubnet.Location = new System.Drawing.Point(143, 33);
			this.txtSubnet.MaxLength = 2;
			this.txtSubnet.Name = "txtSubnet";
			this.txtSubnet.Size = new System.Drawing.Size(72, 22);
			this.txtSubnet.TabIndex = 2;
			this.txtSubnet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSubnet_KeyPress);
			this.txtSubnet.Leave += new System.EventHandler(this.txtSubnet_Leave);
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label2.Location = new System.Drawing.Point(8, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Subnet mask";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label1.Location = new System.Drawing.Point(8, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "IP Address";
			// 
			// panel2
			// 
			this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panel2.Controls.Add(this.txtBroadcast);
			this.panel2.Controls.Add(this.txtNetwork);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.panel2.Location = new System.Drawing.Point(12, 109);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(327, 70);
			this.panel2.TabIndex = 6;
			// 
			// txtBroadcast
			// 
			this.txtBroadcast.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtBroadcast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.txtBroadcast.Location = new System.Drawing.Point(143, 37);
			this.txtBroadcast.MaxLength = 15;
			this.txtBroadcast.Name = "txtBroadcast";
			this.txtBroadcast.ReadOnly = true;
			this.txtBroadcast.Size = new System.Drawing.Size(165, 22);
			this.txtBroadcast.TabIndex = 7;
			this.txtBroadcast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtNetwork
			// 
			this.txtNetwork.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtNetwork.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.txtNetwork.Location = new System.Drawing.Point(143, 7);
			this.txtNetwork.MaxLength = 15;
			this.txtNetwork.Name = "txtNetwork";
			this.txtNetwork.ReadOnly = true;
			this.txtNetwork.Size = new System.Drawing.Size(165, 22);
			this.txtNetwork.TabIndex = 6;
			this.txtNetwork.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label4.Location = new System.Drawing.Point(8, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(124, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "Broadcast Address";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label3.Location = new System.Drawing.Point(8, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(111, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Network Address";
			// 
			// btnReset
			// 
			this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.btnReset.Location = new System.Drawing.Point(134, 80);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(75, 23);
			this.btnReset.TabIndex = 4;
			this.btnReset.Text = "Reset!";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnFile
			// 
			this.btnFile.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnFile.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.btnFile.Location = new System.Drawing.Point(227, 80);
			this.btnFile.Name = "btnFile";
			this.btnFile.Size = new System.Drawing.Size(75, 23);
			this.btnFile.TabIndex = 5;
			this.btnFile.Text = "File...";
			this.btnFile.UseVisualStyleBackColor = true;
			this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
			// 
			// btn_Convert
			// 
			this.btn_Convert.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_Convert.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_Convert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.btn_Convert.Location = new System.Drawing.Point(42, 80);
			this.btn_Convert.Name = "btn_Convert";
			this.btn_Convert.Size = new System.Drawing.Size(75, 23);
			this.btn_Convert.TabIndex = 3;
			this.btn_Convert.Text = "Convert!";
			this.btn_Convert.UseVisualStyleBackColor = true;
			this.btn_Convert.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// Form1
			// 
			this.AcceptButton = this.btn_Convert;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CancelButton = this.btnReset;
			this.ClientSize = new System.Drawing.Size(348, 189);
			this.Controls.Add(this.btn_Convert);
			this.Controls.Add(this.btnFile);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.btnReset);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Chuyển đổi IP";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtSubnet;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.MaskedTextBox txtIP;
		private System.Windows.Forms.TextBox txtBroadcast;
		private System.Windows.Forms.TextBox txtNetwork;
		private System.Windows.Forms.Button btnFile;
		private System.Windows.Forms.Button btn_Convert;
	}
}

