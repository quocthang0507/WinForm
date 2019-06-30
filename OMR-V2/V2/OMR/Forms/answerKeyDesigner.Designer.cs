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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.sheetNameLB = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveB = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.akTitleTB = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.randKeys = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.setTabsB = new System.Windows.Forms.Button();
            this.randBlockId = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.rbInfoB = new System.Windows.Forms.Button();
            this.answerG = new System.Windows.Forms.GroupBox();
            this.orOpRB = new System.Windows.Forms.RadioButton();
            this.andOpRB = new System.Windows.Forms.RadioButton();
            this.optionsG = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.negMark = new System.Windows.Forms.NumericUpDown();
            this.posMark = new System.Windows.Forms.NumericUpDown();
            this.randEn = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randKeys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.randBlockId)).BeginInit();
            this.answerG.SuspendLayout();
            this.optionsG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.negMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posMark)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 24);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 19);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open OMR Sheet Database";
            this.toolTip1.SetToolTip(this.button1, "Open an existing database which was created using OMR Sheet Designer");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.selectSheetFile_Click);
            // 
            // sheetNameLB
            // 
            this.sheetNameLB.Enabled = false;
            this.sheetNameLB.FormattingEnabled = true;
            this.sheetNameLB.Location = new System.Drawing.Point(55, 24);
            this.sheetNameLB.Margin = new System.Windows.Forms.Padding(2);
            this.sheetNameLB.Name = "sheetNameLB";
            this.sheetNameLB.ScrollAlwaysVisible = true;
            this.sheetNameLB.Size = new System.Drawing.Size(145, 43);
            this.sheetNameLB.TabIndex = 1;
            this.toolTip1.SetToolTip(this.sheetNameLB, "Select a sheet name, for which you want to create answer key");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sheet\r\nName";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(203, 49);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 20);
            this.button2.TabIndex = 3;
            this.button2.Text = "Use Selected sheet";
            this.toolTip1.SetToolTip(this.button2, "Reads the selected sheet. This operation cannot be undone. Should you want to sel" +
        "ect some other file, you will have to restart the tool.");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.selectSheetName_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saveB);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.sheetNameLB);
            this.groupBox1.Controls.Add(this.akTitleTB);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(14, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(351, 113);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // saveB
            // 
            this.saveB.Enabled = false;
            this.saveB.Location = new System.Drawing.Point(203, 74);
            this.saveB.Margin = new System.Windows.Forms.Padding(2);
            this.saveB.Name = "saveB";
            this.saveB.Size = new System.Drawing.Size(134, 20);
            this.saveB.TabIndex = 13;
            this.saveB.Text = "Save Answer Key";
            this.toolTip1.SetToolTip(this.saveB, "Once you have created all the keys, press this button to add the answer sheet to " +
        "the database selected");
            this.saveB.UseVisualStyleBackColor = true;
            this.saveB.Click += new System.EventHandler(this.saveB_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 79);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Title";
            // 
            // akTitleTB
            // 
            this.akTitleTB.Location = new System.Drawing.Point(55, 76);
            this.akTitleTB.Margin = new System.Windows.Forms.Padding(2);
            this.akTitleTB.Name = "akTitleTB";
            this.akTitleTB.Size = new System.Drawing.Size(145, 20);
            this.akTitleTB.TabIndex = 11;
            this.toolTip1.SetToolTip(this.akTitleTB, "It is preffered not to use special characters and spaces");
            this.akTitleTB.Leave += new System.EventHandler(this.akTitleTB_Leave);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(347, 21);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(297, 281);
            this.tabControl1.TabIndex = 5;
            // 
            // randKeys
            // 
            this.randKeys.Enabled = false;
            this.randKeys.Location = new System.Drawing.Point(166, 21);
            this.randKeys.Margin = new System.Windows.Forms.Padding(2);
            this.randKeys.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.randKeys.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.randKeys.Name = "randKeys";
            this.randKeys.Size = new System.Drawing.Size(56, 20);
            this.randKeys.TabIndex = 6;
            this.randKeys.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.randKeys.ValueChanged += new System.EventHandler(this.randKeys_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Total random answer keys";
            // 
            // setTabsB
            // 
            this.setTabsB.Enabled = false;
            this.setTabsB.Location = new System.Drawing.Point(226, 20);
            this.setTabsB.Margin = new System.Windows.Forms.Padding(2);
            this.setTabsB.Name = "setTabsB";
            this.setTabsB.Size = new System.Drawing.Size(43, 20);
            this.setTabsB.TabIndex = 8;
            this.setTabsB.Text = "Set";
            this.toolTip1.SetToolTip(this.setTabsB, "Freeze the answer key parameters.");
            this.setTabsB.UseVisualStyleBackColor = true;
            this.setTabsB.Click += new System.EventHandler(this.setTabsB_Click);
            // 
            // randBlockId
            // 
            this.randBlockId.Enabled = false;
            this.randBlockId.Location = new System.Drawing.Point(166, 51);
            this.randBlockId.Margin = new System.Windows.Forms.Padding(2);
            this.randBlockId.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.randBlockId.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.randBlockId.Name = "randBlockId";
            this.randBlockId.Size = new System.Drawing.Size(56, 20);
            this.randBlockId.TabIndex = 6;
            this.randBlockId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.randBlockId.ValueChanged += new System.EventHandler(this.randBlockId_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Block Used for\r\nRandomization Key";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbInfoB
            // 
            this.rbInfoB.Enabled = false;
            this.rbInfoB.Location = new System.Drawing.Point(226, 50);
            this.rbInfoB.Margin = new System.Windows.Forms.Padding(2);
            this.rbInfoB.Name = "rbInfoB";
            this.rbInfoB.Size = new System.Drawing.Size(23, 19);
            this.rbInfoB.TabIndex = 8;
            this.rbInfoB.Text = "?";
            this.rbInfoB.UseVisualStyleBackColor = true;
            this.rbInfoB.Click += new System.EventHandler(this.rbInfoB_Click);
            // 
            // answerG
            // 
            this.answerG.Controls.Add(this.orOpRB);
            this.answerG.Controls.Add(this.andOpRB);
            this.answerG.Controls.Add(this.optionsG);
            this.answerG.Controls.Add(this.tabControl1);
            this.answerG.Controls.Add(this.label6);
            this.answerG.Controls.Add(this.label10);
            this.answerG.Controls.Add(this.label9);
            this.answerG.Controls.Add(this.label8);
            this.answerG.Controls.Add(this.label7);
            this.answerG.Controls.Add(this.negMark);
            this.answerG.Controls.Add(this.posMark);
            this.answerG.Enabled = false;
            this.answerG.Location = new System.Drawing.Point(14, 125);
            this.answerG.Margin = new System.Windows.Forms.Padding(2);
            this.answerG.Name = "answerG";
            this.answerG.Padding = new System.Windows.Forms.Padding(2);
            this.answerG.Size = new System.Drawing.Size(649, 312);
            this.answerG.TabIndex = 9;
            this.answerG.TabStop = false;
            this.answerG.Text = "Answers";
            // 
            // orOpRB
            // 
            this.orOpRB.AutoSize = true;
            this.orOpRB.Location = new System.Drawing.Point(185, 163);
            this.orOpRB.Margin = new System.Windows.Forms.Padding(2);
            this.orOpRB.Name = "orOpRB";
            this.orOpRB.Size = new System.Drawing.Size(138, 17);
            this.orOpRB.TabIndex = 9;
            this.orOpRB.Text = "Any of the right answers";
            this.orOpRB.UseVisualStyleBackColor = true;
            // 
            // andOpRB
            // 
            this.andOpRB.AutoSize = true;
            this.andOpRB.Checked = true;
            this.andOpRB.Location = new System.Drawing.Point(19, 163);
            this.andOpRB.Margin = new System.Windows.Forms.Padding(2);
            this.andOpRB.Name = "andOpRB";
            this.andOpRB.Size = new System.Drawing.Size(131, 17);
            this.andOpRB.TabIndex = 9;
            this.andOpRB.TabStop = true;
            this.andOpRB.Text = "All of the right answers";
            this.andOpRB.UseVisualStyleBackColor = true;
            // 
            // optionsG
            // 
            this.optionsG.Controls.Add(this.checkBox1);
            this.optionsG.Controls.Add(this.checkBox2);
            this.optionsG.Controls.Add(this.checkBox3);
            this.optionsG.Controls.Add(this.checkBox4);
            this.optionsG.Controls.Add(this.checkBox5);
            this.optionsG.Controls.Add(this.checkBox6);
            this.optionsG.Enabled = false;
            this.optionsG.Location = new System.Drawing.Point(33, 270);
            this.optionsG.Margin = new System.Windows.Forms.Padding(2);
            this.optionsG.Name = "optionsG";
            this.optionsG.Size = new System.Drawing.Size(268, 22);
            this.optionsG.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(2, 2);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(32, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.optChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(50, 2);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(32, 17);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.optChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(97, 2);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(32, 17);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "3";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.optChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(144, 2);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(32, 17);
            this.checkBox4.TabIndex = 0;
            this.checkBox4.Text = "4";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.optChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(191, 2);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(32, 17);
            this.checkBox5.TabIndex = 0;
            this.checkBox5.Text = "5";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.optChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(238, 2);
            this.checkBox6.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(32, 17);
            this.checkBox6.TabIndex = 0;
            this.checkBox6.Text = "6";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.optChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(148, 254);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Answer";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 157);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 129);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(331, 26);
            this.label9.TabIndex = 7;
            this.label9.Text = "In case multiple answers are right, what options should be marked for\r\ncorrect an" +
    "swer?";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 76);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(170, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Marks deduction on wrong answer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(102, 50);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Marks on right answer";
            // 
            // negMark
            // 
            this.negMark.Location = new System.Drawing.Point(216, 74);
            this.negMark.Margin = new System.Windows.Forms.Padding(2);
            this.negMark.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.negMark.Name = "negMark";
            this.negMark.Size = new System.Drawing.Size(56, 20);
            this.negMark.TabIndex = 6;
            this.negMark.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // posMark
            // 
            this.posMark.Location = new System.Drawing.Point(216, 49);
            this.posMark.Margin = new System.Windows.Forms.Padding(2);
            this.posMark.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.posMark.Name = "posMark";
            this.posMark.Size = new System.Drawing.Size(56, 20);
            this.posMark.TabIndex = 6;
            this.posMark.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // randEn
            // 
            this.randEn.AutoSize = true;
            this.randEn.Enabled = false;
            this.randEn.Location = new System.Drawing.Point(166, 81);
            this.randEn.Margin = new System.Windows.Forms.Padding(2);
            this.randEn.Name = "randEn";
            this.randEn.Size = new System.Drawing.Size(15, 14);
            this.randEn.TabIndex = 0;
            this.randEn.UseVisualStyleBackColor = true;
            this.randEn.CheckedChanged += new System.EventHandler(this.randEn_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Use Randomzation";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.randBlockId);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.randEn);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.randKeys);
            this.groupBox3.Controls.Add(this.rbInfoB);
            this.groupBox3.Controls.Add(this.setTabsB);
            this.groupBox3.Location = new System.Drawing.Point(369, 7);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(289, 113);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Answer Keys";
            // 
            // answerKeyDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 451);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.answerG);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "answerKeyDesigner";
            this.Text = "Answer Key Designer";
            this.Load += new System.EventHandler(this.answerKeyDesigner_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randKeys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.randBlockId)).EndInit();
            this.answerG.ResumeLayout(false);
            this.answerG.PerformLayout();
            this.optionsG.ResumeLayout(false);
            this.optionsG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.negMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posMark)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox sheetNameLB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.NumericUpDown randKeys;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button setTabsB;
        private System.Windows.Forms.NumericUpDown randBlockId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button rbInfoB;
        private System.Windows.Forms.GroupBox answerG;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox randEn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox akTitleTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveB;
        private System.Windows.Forms.Panel optionsG;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton orOpRB;
        private System.Windows.Forms.RadioButton andOpRB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown negMark;
        private System.Windows.Forms.NumericUpDown posMark;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}