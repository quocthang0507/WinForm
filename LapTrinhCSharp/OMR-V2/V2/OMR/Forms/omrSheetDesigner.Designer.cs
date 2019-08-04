namespace OMR.Forms
{
    partial class omrSheetDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(omrSheetDesigner));
            this.sheetSizeCB = new System.Windows.Forms.ComboBox();
            this.addBubbleBlock = new System.Windows.Forms.Button();
            this.setSheetSize = new System.Windows.Forms.Button();
            this.addRegBlock = new System.Windows.Forms.Button();
            this.checkNameB = new System.Windows.Forms.Button();
            this.optCharCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.help = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.allControls = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridOffRB = new System.Windows.Forms.RadioButton();
            this.gridSmallRB = new System.Windows.Forms.RadioButton();
            this.gridBigRB = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.boxesRB = new System.Windows.Forms.RadioButton();
            this.circlesRB = new System.Windows.Forms.RadioButton();
            this.dbAddressTB = new System.Windows.Forms.TextBox();
            this.sheetNameTB = new System.Windows.Forms.TextBox();
            this.bkImageTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveDB_B = new System.Windows.Forms.Button();
            this.addTextBlock = new System.Windows.Forms.Button();
            this.dbBrowseB = new System.Windows.Forms.Button();
            this.browsBkB = new System.Windows.Forms.Button();
            this.setBckB = new System.Windows.Forms.Button();
            this.blockContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteMI = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.saveDB = new System.Windows.Forms.SaveFileDialog();
            this.sheet = new OMR.helpers.dbPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip.SuspendLayout();
            this.allControls.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.blockContextStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sheetSizeCB
            // 
            this.sheetSizeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sheetSizeCB.FormattingEnabled = true;
            this.sheetSizeCB.Items.AddRange(new object[] {
            "A4, Normal (210 x 297mm)",
            "A4, Landscape (297 x 210 mm)",
            "A5, Normal (148.5 x 210mm)",
            "A5, Landscape (210 x 148.5mm)"});
            this.sheetSizeCB.Location = new System.Drawing.Point(12, 17);
            this.sheetSizeCB.Name = "sheetSizeCB";
            this.sheetSizeCB.Size = new System.Drawing.Size(176, 21);
            this.sheetSizeCB.TabIndex = 1;
            // 
            // addBubbleBlock
            // 
            this.addBubbleBlock.Location = new System.Drawing.Point(4, 111);
            this.addBubbleBlock.Name = "addBubbleBlock";
            this.addBubbleBlock.Size = new System.Drawing.Size(101, 23);
            this.addBubbleBlock.TabIndex = 2;
            this.addBubbleBlock.Text = "Add bubble block";
            this.addBubbleBlock.UseVisualStyleBackColor = true;
            this.addBubbleBlock.Click += new System.EventHandler(this.addBubbleBlock_Click);
            // 
            // setSheetSize
            // 
            this.setSheetSize.Location = new System.Drawing.Point(194, 17);
            this.setSheetSize.Name = "setSheetSize";
            this.setSheetSize.Size = new System.Drawing.Size(101, 22);
            this.setSheetSize.TabIndex = 0;
            this.setSheetSize.Text = "Set Sheet Size";
            this.toolTip1.SetToolTip(this.setSheetSize, "Freeze the sheet size selected");
            this.setSheetSize.UseVisualStyleBackColor = true;
            this.setSheetSize.Click += new System.EventHandler(this.setSheetSize_Click);
            // 
            // addRegBlock
            // 
            this.addRegBlock.Location = new System.Drawing.Point(111, 111);
            this.addRegBlock.Name = "addRegBlock";
            this.addRegBlock.Size = new System.Drawing.Size(176, 23);
            this.addRegBlock.TabIndex = 3;
            this.addRegBlock.Text = "Add Number Block";
            this.addRegBlock.UseVisualStyleBackColor = true;
            this.addRegBlock.Click += new System.EventHandler(this.addRegBlock_Click);
            // 
            // checkNameB
            // 
            this.checkNameB.Location = new System.Drawing.Point(186, 172);
            this.checkNameB.Name = "checkNameB";
            this.checkNameB.Size = new System.Drawing.Size(101, 23);
            this.checkNameB.TabIndex = 5;
            this.checkNameB.Text = "Check Name";
            this.toolTip1.SetToolTip(this.checkNameB, "Runs a simple test to check if the selected name is conforming with the norms.");
            this.checkNameB.UseVisualStyleBackColor = true;
            this.checkNameB.Click += new System.EventHandler(this.checkNameB_Click);
            // 
            // optCharCB
            // 
            this.optCharCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optCharCB.FormattingEnabled = true;
            this.optCharCB.Items.AddRange(new object[] {
            "NIL",
            "1, 2, 3 . . .",
            "A, B, C . . .",
            "a, b, c . . . "});
            this.optCharCB.Location = new System.Drawing.Point(105, 50);
            this.optCharCB.Name = "optCharCB";
            this.optCharCB.Size = new System.Drawing.Size(183, 21);
            this.optCharCB.TabIndex = 1;
            this.optCharCB.SelectedIndexChanged += new System.EventHandler(this.optCharCB_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 6;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.help,
            this.progressStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 370);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(374, 22);
            this.statusStrip.TabIndex = 10;
            this.statusStrip.Text = "statusStrip1";
            // 
            // help
            // 
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(92, 17);
            this.help.Text = "Select an option";
            // 
            // progressStatus
            // 
            this.progressStatus.Name = "progressStatus";
            this.progressStatus.Size = new System.Drawing.Size(100, 16);
            this.progressStatus.Visible = false;
            // 
            // allControls
            // 
            this.allControls.Controls.Add(this.panel2);
            this.allControls.Controls.Add(this.panel1);
            this.allControls.Controls.Add(this.dbAddressTB);
            this.allControls.Controls.Add(this.sheetNameTB);
            this.allControls.Controls.Add(this.bkImageTB);
            this.allControls.Controls.Add(this.label1);
            this.allControls.Controls.Add(this.saveDB_B);
            this.allControls.Controls.Add(this.checkNameB);
            this.allControls.Controls.Add(this.addTextBlock);
            this.allControls.Controls.Add(this.addRegBlock);
            this.allControls.Controls.Add(this.dbBrowseB);
            this.allControls.Controls.Add(this.browsBkB);
            this.allControls.Controls.Add(this.setBckB);
            this.allControls.Controls.Add(this.addBubbleBlock);
            this.allControls.Controls.Add(this.optCharCB);
            this.allControls.Enabled = false;
            this.allControls.Location = new System.Drawing.Point(7, 42);
            this.allControls.Name = "allControls";
            this.allControls.Size = new System.Drawing.Size(294, 329);
            this.allControls.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridOffRB);
            this.panel2.Controls.Add(this.gridSmallRB);
            this.panel2.Controls.Add(this.gridBigRB);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(10, 223);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(89, 88);
            this.panel2.TabIndex = 19;
            // 
            // gridOffRB
            // 
            this.gridOffRB.AutoSize = true;
            this.gridOffRB.Location = new System.Drawing.Point(26, 63);
            this.gridOffRB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridOffRB.Name = "gridOffRB";
            this.gridOffRB.Size = new System.Drawing.Size(39, 17);
            this.gridOffRB.TabIndex = 2;
            this.gridOffRB.Text = "Off";
            this.gridOffRB.UseVisualStyleBackColor = true;
            // 
            // gridSmallRB
            // 
            this.gridSmallRB.AutoSize = true;
            this.gridSmallRB.Location = new System.Drawing.Point(26, 42);
            this.gridSmallRB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridSmallRB.Name = "gridSmallRB";
            this.gridSmallRB.Size = new System.Drawing.Size(50, 17);
            this.gridSmallRB.TabIndex = 1;
            this.gridSmallRB.Text = "Small";
            this.gridSmallRB.UseVisualStyleBackColor = true;
            // 
            // gridBigRB
            // 
            this.gridBigRB.AutoSize = true;
            this.gridBigRB.Checked = true;
            this.gridBigRB.Location = new System.Drawing.Point(26, 20);
            this.gridBigRB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridBigRB.Name = "gridBigRB";
            this.gridBigRB.Size = new System.Drawing.Size(40, 17);
            this.gridBigRB.TabIndex = 0;
            this.gridBigRB.TabStop = true;
            this.gridBigRB.Text = "Big";
            this.gridBigRB.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Snap to Grid";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.boxesRB);
            this.panel1.Controls.Add(this.circlesRB);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(5, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 29);
            this.panel1.TabIndex = 18;
            // 
            // boxesRB
            // 
            this.boxesRB.AutoSize = true;
            this.boxesRB.Checked = true;
            this.boxesRB.Location = new System.Drawing.Point(91, 5);
            this.boxesRB.Name = "boxesRB";
            this.boxesRB.Size = new System.Drawing.Size(127, 17);
            this.boxesRB.TabIndex = 17;
            this.boxesRB.TabStop = true;
            this.boxesRB.Text = "Boxes (Recomended)";
            this.boxesRB.UseVisualStyleBackColor = true;
            // 
            // circlesRB
            // 
            this.circlesRB.AutoSize = true;
            this.circlesRB.Location = new System.Drawing.Point(3, 5);
            this.circlesRB.Name = "circlesRB";
            this.circlesRB.Size = new System.Drawing.Size(56, 17);
            this.circlesRB.TabIndex = 17;
            this.circlesRB.Text = "Circles";
            this.circlesRB.UseVisualStyleBackColor = true;
            this.circlesRB.CheckedChanged += new System.EventHandler(this.circlesRB_CheckedChanged);
            // 
            // dbAddressTB
            // 
            this.dbAddressTB.Location = new System.Drawing.Point(6, 199);
            this.dbAddressTB.Name = "dbAddressTB";
            this.dbAddressTB.ReadOnly = true;
            this.dbAddressTB.Size = new System.Drawing.Size(147, 20);
            this.dbAddressTB.TabIndex = 16;
            this.dbAddressTB.Text = "C:\\Users\\techBOY\\Documents\\Visual Studio 2010\\Projects\\OMR2015\\OMR Test 1\\bin\\Deb" +
    "ug\\omrSheet1.accdb";
            // 
            // sheetNameTB
            // 
            this.sheetNameTB.Location = new System.Drawing.Point(5, 173);
            this.sheetNameTB.Name = "sheetNameTB";
            this.sheetNameTB.Size = new System.Drawing.Size(175, 20);
            this.sheetNameTB.TabIndex = 16;
            this.sheetNameTB.Text = "A4_1";
            // 
            // bkImageTB
            // 
            this.bkImageTB.Location = new System.Drawing.Point(10, 13);
            this.bkImageTB.Name = "bkImageTB";
            this.bkImageTB.Size = new System.Drawing.Size(100, 20);
            this.bkImageTB.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Options label char";
            // 
            // saveDB_B
            // 
            this.saveDB_B.Location = new System.Drawing.Point(187, 196);
            this.saveDB_B.Name = "saveDB_B";
            this.saveDB_B.Size = new System.Drawing.Size(101, 23);
            this.saveDB_B.TabIndex = 6;
            this.saveDB_B.Text = "Save Database";
            this.toolTip1.SetToolTip(this.saveDB_B, "Save the database to the selected file,");
            this.saveDB_B.UseVisualStyleBackColor = true;
            this.saveDB_B.Click += new System.EventHandler(this.resterize_Click);
            // 
            // addTextBlock
            // 
            this.addTextBlock.Location = new System.Drawing.Point(4, 140);
            this.addTextBlock.Name = "addTextBlock";
            this.addTextBlock.Size = new System.Drawing.Size(133, 23);
            this.addTextBlock.TabIndex = 4;
            this.addTextBlock.Text = "Set written input Region";
            this.addTextBlock.UseVisualStyleBackColor = true;
            this.addTextBlock.Click += new System.EventHandler(this.addTextBlock_Click);
            // 
            // dbBrowseB
            // 
            this.dbBrowseB.Location = new System.Drawing.Point(153, 199);
            this.dbBrowseB.Name = "dbBrowseB";
            this.dbBrowseB.Size = new System.Drawing.Size(28, 20);
            this.dbBrowseB.TabIndex = 3;
            this.dbBrowseB.Text = "---";
            this.toolTip1.SetToolTip(this.dbBrowseB, "Select asave name and location");
            this.dbBrowseB.UseVisualStyleBackColor = true;
            this.dbBrowseB.Click += new System.EventHandler(this.dbBrowseB_Click);
            // 
            // browsBkB
            // 
            this.browsBkB.Location = new System.Drawing.Point(223, 11);
            this.browsBkB.Name = "browsBkB";
            this.browsBkB.Size = new System.Drawing.Size(64, 23);
            this.browsBkB.TabIndex = 1;
            this.browsBkB.Text = "Browse";
            this.toolTip1.SetToolTip(this.browsBkB, "Browse for JPG or PDF images to serve as the background of sheet");
            this.browsBkB.UseVisualStyleBackColor = true;
            this.browsBkB.Click += new System.EventHandler(this.browsBkB_Click);
            // 
            // setBckB
            // 
            this.setBckB.Location = new System.Drawing.Point(116, 11);
            this.setBckB.Name = "setBckB";
            this.setBckB.Size = new System.Drawing.Size(101, 23);
            this.setBckB.TabIndex = 0;
            this.setBckB.Text = "Set Background";
            this.toolTip1.SetToolTip(this.setBckB, "Once a background image has been selected, this will apply it to the current shee" +
        "t");
            this.setBckB.UseVisualStyleBackColor = true;
            this.setBckB.Click += new System.EventHandler(this.setBckB_Click);
            // 
            // blockContextStrip
            // 
            this.blockContextStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.blockContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteMI});
            this.blockContextStrip.Name = "blockContextStrip";
            this.blockContextStrip.Size = new System.Drawing.Size(140, 26);
            this.blockContextStrip.Opening += new System.ComponentModel.CancelEventHandler(this.blockContextStrip_Opening);
            // 
            // deleteMI
            // 
            this.deleteMI.Name = "deleteMI";
            this.deleteMI.Size = new System.Drawing.Size(139, 22);
            this.deleteMI.Text = "Delete Block";
            this.deleteMI.Click += new System.EventHandler(this.deleteItem_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            this.openFile.Filter = "PDF Files (*.pdf)|*.pdf";
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\techBOY\\Documents\\Visual " +
    "Studio 2010\\Projects\\OMR2015\\OMR Test 1\\bin\\Debug\\omrSheet1.accdb\"";
            // 
            // saveDB
            // 
            this.saveDB.Filter = "Access Database 2007 (*.accdb)|*.accdb";
            // 
            // sheet
            // 
            this.sheet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sheet.Location = new System.Drawing.Point(311, 3);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(200, 100);
            this.sheet.TabIndex = 12;
            // 
            // omrSheetDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 392);
            this.Controls.Add(this.sheet);
            this.Controls.Add(this.allControls);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.setSheetSize);
            this.Controls.Add(this.sheetSizeCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "omrSheetDesigner";
            this.Text = "OMR sheet designer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.answerKeyDesigner_FormClosing);
            this.Load += new System.EventHandler(this.omrSheetDesigner_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.allControls.ResumeLayout(false);
            this.allControls.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.blockContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox sheetSizeCB;
        private System.Windows.Forms.Button addBubbleBlock;
        private System.Windows.Forms.Button setSheetSize;
        private System.Windows.Forms.Button addRegBlock;
        private System.Windows.Forms.Button checkNameB;
        private System.Windows.Forms.ComboBox optCharCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel help;
        private System.Windows.Forms.Panel allControls;
        private System.Windows.Forms.Button addTextBlock;
        private System.Windows.Forms.ContextMenuStrip blockContextStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteMI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox bkImageTB;
        private System.Windows.Forms.Button browsBkB;
        private System.Windows.Forms.Button setBckB;
        private System.Windows.Forms.OpenFileDialog openFile;
        private OMR.helpers.dbPanel sheet;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Windows.Forms.TextBox dbAddressTB;
        private System.Windows.Forms.TextBox sheetNameTB;
        private System.Windows.Forms.Button saveDB_B;
        private System.Windows.Forms.Button dbBrowseB;
        private System.Windows.Forms.SaveFileDialog saveDB;
        private System.Windows.Forms.RadioButton boxesRB;
        private System.Windows.Forms.RadioButton circlesRB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripProgressBar progressStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton gridOffRB;
        private System.Windows.Forms.RadioButton gridSmallRB;
        private System.Windows.Forms.RadioButton gridBigRB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}