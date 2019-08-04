namespace OMR.Forms
{
    partial class answerKeyDesigner
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
            this.sheetSize = new System.Windows.Forms.ComboBox();
            this.addBubbleBlock = new System.Windows.Forms.Button();
            this.setSheetSize = new System.Windows.Forms.Button();
            this.nOfOpts = new System.Windows.Forms.ComboBox();
            this.sizeOfBlock = new System.Windows.Forms.ComboBox();
            this.digitsOfRegNum = new System.Windows.Forms.ComboBox();
            this.addRegBlock = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.typeOfOpt = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addImageBlock = new System.Windows.Forms.Button();
            this.imageBlock = new System.Windows.Forms.Panel();
            this.imageKey = new System.Windows.Forms.Panel();
            this.transImageBlock = new System.Windows.Forms.Panel();
            this.addTransImageBlock = new System.Windows.Forms.Button();
            this.clearRegion = new System.Windows.Forms.Button();
            this.clearAll = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.help = new System.Windows.Forms.ToolStripStatusLabel();
            this.allControls = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.startOfNum = new System.Windows.Forms.CheckBox();
            this.startNum = new System.Windows.Forms.NumericUpDown();
            this.addTextBlock = new System.Windows.Forms.Button();
            this.sheet = new OMR.dbPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.statusStrip1.SuspendLayout();
            this.allControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startNum)).BeginInit();
            this.SuspendLayout();
            // 
            // sheetSize
            // 
            this.sheetSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sheetSize.FormattingEnabled = true;
            this.sheetSize.Items.AddRange(new object[] {
            "A4, Normal (210 x 297mm)",
            "A4, Landscape (297 x 210 mm)",
            "A5, Normal (148.5 x 210mm)",
            "A5, Landscape (210 x 148.5mm)"});
            this.sheetSize.Location = new System.Drawing.Point(12, 17);
            this.sheetSize.Name = "sheetSize";
            this.sheetSize.Size = new System.Drawing.Size(176, 21);
            this.sheetSize.TabIndex = 1;
            // 
            // addBubbleBlock
            // 
            this.addBubbleBlock.Location = new System.Drawing.Point(187, 3);
            this.addBubbleBlock.Name = "addBubbleBlock";
            this.addBubbleBlock.Size = new System.Drawing.Size(101, 23);
            this.addBubbleBlock.TabIndex = 3;
            this.addBubbleBlock.Text = "Add bubble block";
            this.addBubbleBlock.UseVisualStyleBackColor = true;
            this.addBubbleBlock.Click += new System.EventHandler(this.addBubbleBlock_Click);
            // 
            // setSheetSize
            // 
            this.setSheetSize.Location = new System.Drawing.Point(194, 17);
            this.setSheetSize.Name = "setSheetSize";
            this.setSheetSize.Size = new System.Drawing.Size(101, 22);
            this.setSheetSize.TabIndex = 3;
            this.setSheetSize.Text = "Set Sheet Size";
            this.setSheetSize.UseVisualStyleBackColor = true;
            this.setSheetSize.Click += new System.EventHandler(this.setSheetSize_Click);
            // 
            // nOfOpts
            // 
            this.nOfOpts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nOfOpts.FormattingEnabled = true;
            this.nOfOpts.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.nOfOpts.Location = new System.Drawing.Point(5, 5);
            this.nOfOpts.Name = "nOfOpts";
            this.nOfOpts.Size = new System.Drawing.Size(64, 21);
            this.nOfOpts.TabIndex = 1;
            // 
            // sizeOfBlock
            // 
            this.sizeOfBlock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeOfBlock.FormattingEnabled = true;
            this.sizeOfBlock.Items.AddRange(new object[] {
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50"});
            this.sizeOfBlock.Location = new System.Drawing.Point(112, 5);
            this.sizeOfBlock.Name = "sizeOfBlock";
            this.sizeOfBlock.Size = new System.Drawing.Size(67, 21);
            this.sizeOfBlock.TabIndex = 1;
            // 
            // digitsOfRegNum
            // 
            this.digitsOfRegNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.digitsOfRegNum.FormattingEnabled = true;
            this.digitsOfRegNum.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.digitsOfRegNum.Location = new System.Drawing.Point(5, 85);
            this.digitsOfRegNum.Name = "digitsOfRegNum";
            this.digitsOfRegNum.Size = new System.Drawing.Size(101, 21);
            this.digitsOfRegNum.TabIndex = 1;
            // 
            // addRegBlock
            // 
            this.addRegBlock.Location = new System.Drawing.Point(112, 84);
            this.addRegBlock.Name = "addRegBlock";
            this.addRegBlock.Size = new System.Drawing.Size(176, 23);
            this.addRegBlock.TabIndex = 3;
            this.addRegBlock.Text = "Add Registration Number Block";
            this.addRegBlock.UseVisualStyleBackColor = true;
            this.addRegBlock.Click += new System.EventHandler(this.addRegBlock_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(188, 299);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Rasterize";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // typeOfOpt
            // 
            this.typeOfOpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeOfOpt.FormattingEnabled = true;
            this.typeOfOpt.Items.AddRange(new object[] {
            "NIL",
            "1, 2, 3 . . .",
            "A, B, C . . .",
            "a, b, c . . . "});
            this.typeOfOpt.Location = new System.Drawing.Point(5, 57);
            this.typeOfOpt.Name = "typeOfOpt";
            this.typeOfOpt.Size = new System.Drawing.Size(174, 21);
            this.typeOfOpt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 6;
            // 
            // addImageBlock
            // 
            this.addImageBlock.Location = new System.Drawing.Point(187, 188);
            this.addImageBlock.Name = "addImageBlock";
            this.addImageBlock.Size = new System.Drawing.Size(101, 21);
            this.addImageBlock.TabIndex = 3;
            this.addImageBlock.Text = "Add Image Block";
            this.addImageBlock.UseVisualStyleBackColor = true;
            // 
            // imageBlock
            // 
            this.imageBlock.Location = new System.Drawing.Point(5, 188);
            this.imageBlock.Name = "imageBlock";
            this.imageBlock.Size = new System.Drawing.Size(84, 79);
            this.imageBlock.TabIndex = 8;
            // 
            // imageKey
            // 
            this.imageKey.Location = new System.Drawing.Point(189, 218);
            this.imageKey.Name = "imageKey";
            this.imageKey.Size = new System.Drawing.Size(15, 49);
            this.imageKey.TabIndex = 9;
            // 
            // transImageBlock
            // 
            this.transImageBlock.Location = new System.Drawing.Point(95, 188);
            this.transImageBlock.Name = "transImageBlock";
            this.transImageBlock.Size = new System.Drawing.Size(84, 79);
            this.transImageBlock.TabIndex = 8;
            // 
            // addTransImageBlock
            // 
            this.addTransImageBlock.Location = new System.Drawing.Point(206, 218);
            this.addTransImageBlock.Name = "addTransImageBlock";
            this.addTransImageBlock.Size = new System.Drawing.Size(82, 49);
            this.addTransImageBlock.TabIndex = 3;
            this.addTransImageBlock.Text = "Add Transparent Image Block";
            this.addTransImageBlock.UseVisualStyleBackColor = true;
            // 
            // clearRegion
            // 
            this.clearRegion.Location = new System.Drawing.Point(5, 275);
            this.clearRegion.Name = "clearRegion";
            this.clearRegion.Size = new System.Drawing.Size(49, 52);
            this.clearRegion.TabIndex = 5;
            this.clearRegion.Text = "Clear region";
            this.clearRegion.UseVisualStyleBackColor = true;
            // 
            // clearAll
            // 
            this.clearAll.Location = new System.Drawing.Point(56, 275);
            this.clearAll.Name = "clearAll";
            this.clearAll.Size = new System.Drawing.Size(49, 52);
            this.clearAll.TabIndex = 5;
            this.clearAll.Text = "Clear All";
            this.clearAll.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.help});
            this.statusStrip1.Location = new System.Drawing.Point(0, 489);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(770, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // help
            // 
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(92, 17);
            this.help.Text = "Select an option";
            // 
            // allControls
            // 
            this.allControls.Controls.Add(this.richTextBox1);
            this.allControls.Controls.Add(this.label1);
            this.allControls.Controls.Add(this.startOfNum);
            this.allControls.Controls.Add(this.startNum);
            this.allControls.Controls.Add(this.imageKey);
            this.allControls.Controls.Add(this.transImageBlock);
            this.allControls.Controls.Add(this.imageBlock);
            this.allControls.Controls.Add(this.label3);
            this.allControls.Controls.Add(this.clearAll);
            this.allControls.Controls.Add(this.clearRegion);
            this.allControls.Controls.Add(this.button4);
            this.allControls.Controls.Add(this.addTransImageBlock);
            this.allControls.Controls.Add(this.addTextBlock);
            this.allControls.Controls.Add(this.addImageBlock);
            this.allControls.Controls.Add(this.addRegBlock);
            this.allControls.Controls.Add(this.addBubbleBlock);
            this.allControls.Controls.Add(this.digitsOfRegNum);
            this.allControls.Controls.Add(this.typeOfOpt);
            this.allControls.Controls.Add(this.sizeOfBlock);
            this.allControls.Controls.Add(this.nOfOpts);
            this.allControls.Enabled = false;
            this.allControls.Location = new System.Drawing.Point(7, 42);
            this.allControls.Name = "allControls";
            this.allControls.Size = new System.Drawing.Size(294, 378);
            this.allControls.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "X";
            // 
            // startOfNum
            // 
            this.startOfNum.AutoSize = true;
            this.startOfNum.Location = new System.Drawing.Point(5, 34);
            this.startOfNum.Name = "startOfNum";
            this.startOfNum.Size = new System.Drawing.Size(114, 17);
            this.startOfNum.TabIndex = 11;
            this.startOfNum.Text = "Start of Numbering";
            this.startOfNum.UseVisualStyleBackColor = true;
            // 
            // startNum
            // 
            this.startNum.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.startNum.Location = new System.Drawing.Point(128, 32);
            this.startNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startNum.Name = "startNum";
            this.startNum.Size = new System.Drawing.Size(51, 20);
            this.startNum.TabIndex = 10;
            this.startNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // addTextBlock
            // 
            this.addTextBlock.Location = new System.Drawing.Point(231, 113);
            this.addTextBlock.Name = "addTextBlock";
            this.addTextBlock.Size = new System.Drawing.Size(57, 37);
            this.addTextBlock.TabIndex = 3;
            this.addTextBlock.Text = "Add text block";
            this.addTextBlock.UseVisualStyleBackColor = true;
            this.addTextBlock.Click += new System.EventHandler(this.addTextBlock_Click);
            // 
            // sheet
            // 
            this.sheet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sheet.Location = new System.Drawing.Point(302, 0);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(420, 420);
            this.sheet.TabIndex = 2;
            this.sheet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseMove);
            this.sheet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseDown);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 112);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(222, 70);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // answerKeyDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 511);
            this.Controls.Add(this.allControls);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.setSheetSize);
            this.Controls.Add(this.sheet);
            this.Controls.Add(this.sheetSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "answerKeyDesigner";
            this.Text = "answerKeyDesigner";
            this.Load += new System.EventHandler(this.answerKeyDesigner_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.allControls.ResumeLayout(false);
            this.allControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox sheetSize;
        private dbPanel sheet;
        private System.Windows.Forms.Button addBubbleBlock;
        private System.Windows.Forms.Button setSheetSize;
        private System.Windows.Forms.ComboBox nOfOpts;
        private System.Windows.Forms.ComboBox sizeOfBlock;
        private System.Windows.Forms.ComboBox digitsOfRegNum;
        private System.Windows.Forms.Button addRegBlock;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox typeOfOpt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addImageBlock;
        private System.Windows.Forms.Panel imageBlock;
        private System.Windows.Forms.Panel imageKey;
        private System.Windows.Forms.Panel transImageBlock;
        private System.Windows.Forms.Button addTransImageBlock;
        private System.Windows.Forms.Button clearRegion;
        private System.Windows.Forms.Button clearAll;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel help;
        private System.Windows.Forms.Panel allControls;
        private System.Windows.Forms.Button addTextBlock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox startOfNum;
        private System.Windows.Forms.NumericUpDown startNum;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}