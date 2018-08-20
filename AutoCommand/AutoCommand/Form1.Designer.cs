namespace AutoCommand
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
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.btn_Browse1 = new System.Windows.Forms.Button();
			this.btn_Start1 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Col_OldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Col_NewName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Col_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Col_Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.cbx_Digits = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.nud_Step = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.nud_Start = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cbx_Case = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.tbx_Replace = new System.Windows.Forms.TextBox();
			this.tbx_Find = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btn_eCounter = new System.Windows.Forms.Button();
			this.btn_eRange = new System.Windows.Forms.Button();
			this.btn_eExtension = new System.Windows.Forms.Button();
			this.tbx_Extension = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_Time = new System.Windows.Forms.Button();
			this.btn_Date = new System.Windows.Forms.Button();
			this.btn_Counter = new System.Windows.Forms.Button();
			this.btn_Range = new System.Windows.Forms.Button();
			this.btn_Name = new System.Windows.Forms.Button();
			this.tbx_fileName = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btn_Browse2 = new System.Windows.Forms.Button();
			this.btn_Start2 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.cbx_Size = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.listFont = new System.Windows.Forms.ListBox();
			this.tbx_Path2 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tbx_Text = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pbx_Before = new System.Windows.Forms.PictureBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label11 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_Step)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_Start)).BeginInit();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbx_Before)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(728, 400);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label11);
			this.tabPage1.Controls.Add(this.progressBar1);
			this.tabPage1.Controls.Add(this.btn_Browse1);
			this.tabPage1.Controls.Add(this.btn_Start1);
			this.tabPage1.Controls.Add(this.dataGridView1);
			this.tabPage1.Controls.Add(this.groupBox5);
			this.tabPage1.Controls.Add(this.groupBox4);
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(720, 374);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Multi-Rename";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// progressBar1
			// 
			this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.progressBar1.ForeColor = System.Drawing.Color.Chartreuse;
			this.progressBar1.Location = new System.Drawing.Point(3, 348);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(714, 23);
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar1.TabIndex = 18;
			// 
			// btn_Browse1
			// 
			this.btn_Browse1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
			this.btn_Browse1.Location = new System.Drawing.Point(74, 6);
			this.btn_Browse1.Name = "btn_Browse1";
			this.btn_Browse1.Size = new System.Drawing.Size(114, 27);
			this.btn_Browse1.TabIndex = 17;
			this.btn_Browse1.Text = "Browse...";
			this.btn_Browse1.UseVisualStyleBackColor = true;
			this.btn_Browse1.Click += new System.EventHandler(this.btn_Browse1_Click);
			// 
			// btn_Start1
			// 
			this.btn_Start1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.btn_Start1.Location = new System.Drawing.Point(598, 100);
			this.btn_Start1.Name = "btn_Start1";
			this.btn_Start1.Size = new System.Drawing.Size(114, 27);
			this.btn_Start1.TabIndex = 17;
			this.btn_Start1.Text = "Start";
			this.btn_Start1.UseVisualStyleBackColor = true;
			this.btn_Start1.Click += new System.EventHandler(this.btn_Start1_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_OldName,
            this.Col_NewName,
            this.Size,
            this.Col_Date,
            this.Col_Location});
			this.dataGridView1.Location = new System.Drawing.Point(11, 144);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(703, 198);
			this.dataGridView1.TabIndex = 5;
			// 
			// Col_OldName
			// 
			this.Col_OldName.HeaderText = "Old name";
			this.Col_OldName.Name = "Col_OldName";
			this.Col_OldName.ReadOnly = true;
			// 
			// Col_NewName
			// 
			this.Col_NewName.HeaderText = "New name";
			this.Col_NewName.Name = "Col_NewName";
			this.Col_NewName.ReadOnly = true;
			// 
			// Size
			// 
			this.Size.HeaderText = "Size";
			this.Size.Name = "Size";
			this.Size.ReadOnly = true;
			// 
			// Col_Date
			// 
			this.Col_Date.HeaderText = "Date modification";
			this.Col_Date.Name = "Col_Date";
			this.Col_Date.ReadOnly = true;
			// 
			// Col_Location
			// 
			this.Col_Location.HeaderText = "Location";
			this.Col_Location.Name = "Col_Location";
			this.Col_Location.ReadOnly = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.cbx_Digits);
			this.groupBox5.Controls.Add(this.label5);
			this.groupBox5.Controls.Add(this.nud_Step);
			this.groupBox5.Controls.Add(this.label4);
			this.groupBox5.Controls.Add(this.nud_Start);
			this.groupBox5.Controls.Add(this.label3);
			this.groupBox5.Location = new System.Drawing.Point(598, 6);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(114, 91);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "[C] Counter";
			// 
			// cbx_Digits
			// 
			this.cbx_Digits.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cbx_Digits.FormattingEnabled = true;
			this.cbx_Digits.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
			this.cbx_Digits.Location = new System.Drawing.Point(68, 64);
			this.cbx_Digits.Name = "cbx_Digits";
			this.cbx_Digits.Size = new System.Drawing.Size(40, 21);
			this.cbx_Digits.TabIndex = 16;
			this.cbx_Digits.Text = "1";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 65);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(36, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Digits:";
			// 
			// nud_Step
			// 
			this.nud_Step.Location = new System.Drawing.Point(68, 41);
			this.nud_Step.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nud_Step.Name = "nud_Step";
			this.nud_Step.Size = new System.Drawing.Size(40, 20);
			this.nud_Step.TabIndex = 15;
			this.nud_Step.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 43);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Step by:";
			// 
			// nud_Start
			// 
			this.nud_Start.Location = new System.Drawing.Point(68, 18);
			this.nud_Start.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nud_Start.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nud_Start.Name = "nud_Start";
			this.nud_Start.Size = new System.Drawing.Size(40, 20);
			this.nud_Start.TabIndex = 14;
			this.nud_Start.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Start at:";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.cbx_Case);
			this.groupBox4.Location = new System.Drawing.Point(392, 81);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(200, 46);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Change case";
			// 
			// cbx_Case
			// 
			this.cbx_Case.FormattingEnabled = true;
			this.cbx_Case.Items.AddRange(new object[] {
            "Default",
            "all lowercase",
            "ALL UPPERCASE",
            "First letter uppercase",
            "First Of Each Word Uppercase"});
			this.cbx_Case.Location = new System.Drawing.Point(6, 19);
			this.cbx_Case.Name = "cbx_Case";
			this.cbx_Case.Size = new System.Drawing.Size(188, 21);
			this.cbx_Case.TabIndex = 13;
			this.cbx_Case.Text = "Default";
			this.cbx_Case.SelectedValueChanged += new System.EventHandler(this.cbx_Case_SelectedValueChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.tbx_Replace);
			this.groupBox3.Controls.Add(this.tbx_Find);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Location = new System.Drawing.Point(392, 6);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(200, 70);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Find and Replace";
			// 
			// tbx_Replace
			// 
			this.tbx_Replace.Location = new System.Drawing.Point(95, 43);
			this.tbx_Replace.Name = "tbx_Replace";
			this.tbx_Replace.Size = new System.Drawing.Size(100, 20);
			this.tbx_Replace.TabIndex = 12;
			this.tbx_Replace.TextChanged += new System.EventHandler(this.tbx_Replace_TextChanged);
			// 
			// tbx_Find
			// 
			this.tbx_Find.Location = new System.Drawing.Point(95, 18);
			this.tbx_Find.Name = "tbx_Find";
			this.tbx_Find.Size = new System.Drawing.Size(100, 20);
			this.tbx_Find.TabIndex = 11;
			this.tbx_Find.TextChanged += new System.EventHandler(this.tbx_Find_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Replace with:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Find:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btn_eCounter);
			this.groupBox2.Controls.Add(this.btn_eRange);
			this.groupBox2.Controls.Add(this.btn_eExtension);
			this.groupBox2.Controls.Add(this.tbx_Extension);
			this.groupBox2.Location = new System.Drawing.Point(260, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(126, 121);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Extension";
			// 
			// btn_eCounter
			// 
			this.btn_eCounter.Location = new System.Drawing.Point(6, 92);
			this.btn_eCounter.Name = "btn_eCounter";
			this.btn_eCounter.Size = new System.Drawing.Size(114, 23);
			this.btn_eCounter.TabIndex = 10;
			this.btn_eCounter.Text = "[C] Counter";
			this.btn_eCounter.UseVisualStyleBackColor = true;
			this.btn_eCounter.Click += new System.EventHandler(this.btn_eCounter_Click);
			// 
			// btn_eRange
			// 
			this.btn_eRange.Location = new System.Drawing.Point(6, 68);
			this.btn_eRange.Name = "btn_eRange";
			this.btn_eRange.Size = new System.Drawing.Size(114, 23);
			this.btn_eRange.TabIndex = 9;
			this.btn_eRange.Text = "[E#-#] Range";
			this.btn_eRange.UseVisualStyleBackColor = true;
			this.btn_eRange.Click += new System.EventHandler(this.btn_eRange_Click);
			// 
			// btn_eExtension
			// 
			this.btn_eExtension.Location = new System.Drawing.Point(6, 43);
			this.btn_eExtension.Name = "btn_eExtension";
			this.btn_eExtension.Size = new System.Drawing.Size(114, 23);
			this.btn_eExtension.TabIndex = 8;
			this.btn_eExtension.Text = "[E] Extension";
			this.btn_eExtension.UseVisualStyleBackColor = true;
			this.btn_eExtension.Click += new System.EventHandler(this.btn_eExtension_Click);
			// 
			// tbx_Extension
			// 
			this.tbx_Extension.Location = new System.Drawing.Point(6, 17);
			this.tbx_Extension.Name = "tbx_Extension";
			this.tbx_Extension.Size = new System.Drawing.Size(114, 20);
			this.tbx_Extension.TabIndex = 7;
			this.tbx_Extension.Text = "[E]";
			this.tbx_Extension.Click += new System.EventHandler(this.tbx_Extension_Click);
			this.tbx_Extension.TextChanged += new System.EventHandler(this.tbx_Extension_TextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btn_Time);
			this.groupBox1.Controls.Add(this.btn_Date);
			this.groupBox1.Controls.Add(this.btn_Counter);
			this.groupBox1.Controls.Add(this.btn_Range);
			this.groupBox1.Controls.Add(this.btn_Name);
			this.groupBox1.Controls.Add(this.tbx_fileName);
			this.groupBox1.Location = new System.Drawing.Point(8, 37);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(246, 90);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Rename mask: File name";
			// 
			// btn_Time
			// 
			this.btn_Time.Location = new System.Drawing.Point(175, 37);
			this.btn_Time.Name = "btn_Time";
			this.btn_Time.Size = new System.Drawing.Size(60, 23);
			this.btn_Time.TabIndex = 4;
			this.btn_Time.Text = "[T] Time";
			this.btn_Time.UseVisualStyleBackColor = true;
			this.btn_Time.Click += new System.EventHandler(this.btn_Time_Click);
			// 
			// btn_Date
			// 
			this.btn_Date.Location = new System.Drawing.Point(149, 64);
			this.btn_Date.Name = "btn_Date";
			this.btn_Date.Size = new System.Drawing.Size(56, 23);
			this.btn_Date.TabIndex = 6;
			this.btn_Date.Text = "[D] Date";
			this.btn_Date.UseVisualStyleBackColor = true;
			this.btn_Date.Click += new System.EventHandler(this.btn_Date_Click);
			// 
			// btn_Counter
			// 
			this.btn_Counter.Location = new System.Drawing.Point(89, 37);
			this.btn_Counter.Name = "btn_Counter";
			this.btn_Counter.Size = new System.Drawing.Size(75, 23);
			this.btn_Counter.TabIndex = 3;
			this.btn_Counter.Text = "[C] Counter";
			this.btn_Counter.UseVisualStyleBackColor = true;
			this.btn_Counter.Click += new System.EventHandler(this.btn_Counter_Click);
			// 
			// btn_Range
			// 
			this.btn_Range.Location = new System.Drawing.Point(55, 63);
			this.btn_Range.Name = "btn_Range";
			this.btn_Range.Size = new System.Drawing.Size(88, 23);
			this.btn_Range.TabIndex = 5;
			this.btn_Range.Text = "[N#-#] Range";
			this.btn_Range.UseVisualStyleBackColor = true;
			this.btn_Range.Click += new System.EventHandler(this.btn_Range_Click);
			// 
			// btn_Name
			// 
			this.btn_Name.Location = new System.Drawing.Point(17, 37);
			this.btn_Name.Name = "btn_Name";
			this.btn_Name.Size = new System.Drawing.Size(60, 23);
			this.btn_Name.TabIndex = 2;
			this.btn_Name.Text = "[N] Name";
			this.btn_Name.UseVisualStyleBackColor = true;
			this.btn_Name.Click += new System.EventHandler(this.btn_Name_Click);
			// 
			// tbx_fileName
			// 
			this.tbx_fileName.Location = new System.Drawing.Point(33, 15);
			this.tbx_fileName.Name = "tbx_fileName";
			this.tbx_fileName.Size = new System.Drawing.Size(186, 20);
			this.tbx_fileName.TabIndex = 1;
			this.tbx_fileName.Text = "[N]";
			this.tbx_fileName.Click += new System.EventHandler(this.tbx_fileName_Click);
			this.tbx_fileName.TextChanged += new System.EventHandler(this.tbx_fileName_TextChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btn_Browse2);
			this.tabPage2.Controls.Add(this.btn_Start2);
			this.tabPage2.Controls.Add(this.comboBox1);
			this.tabPage2.Controls.Add(this.label10);
			this.tabPage2.Controls.Add(this.cbx_Size);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.listFont);
			this.tabPage2.Controls.Add(this.tbx_Path2);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.tbx_Text);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.groupBox6);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(720, 374);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Multi-Watermark";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btn_Browse2
			// 
			this.btn_Browse2.Location = new System.Drawing.Point(322, 17);
			this.btn_Browse2.Name = "btn_Browse2";
			this.btn_Browse2.Size = new System.Drawing.Size(26, 20);
			this.btn_Browse2.TabIndex = 14;
			this.btn_Browse2.Text = "...";
			this.btn_Browse2.UseVisualStyleBackColor = true;
			this.btn_Browse2.Click += new System.EventHandler(this.btn_Browse2_Click);
			// 
			// btn_Start2
			// 
			this.btn_Start2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
			this.btn_Start2.Location = new System.Drawing.Point(322, 94);
			this.btn_Start2.Name = "btn_Start2";
			this.btn_Start2.Size = new System.Drawing.Size(75, 23);
			this.btn_Start2.TabIndex = 13;
			this.btn_Start2.Text = "Start";
			this.btn_Start2.UseVisualStyleBackColor = true;
			this.btn_Start2.Click += new System.EventHandler(this.btn_Start2_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Bold",
            "Italic",
            "Regular",
            "Strikeout",
            "Underline"});
			this.comboBox1.Location = new System.Drawing.Point(243, 67);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(105, 21);
			this.comboBox1.TabIndex = 12;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(182, 70);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(55, 13);
			this.label10.TabIndex = 11;
			this.label10.Text = "Font style:";
			// 
			// cbx_Size
			// 
			this.cbx_Size.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cbx_Size.FormattingEnabled = true;
			this.cbx_Size.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
			this.cbx_Size.Location = new System.Drawing.Point(53, 67);
			this.cbx_Size.Name = "cbx_Size";
			this.cbx_Size.Size = new System.Drawing.Size(57, 21);
			this.cbx_Size.TabIndex = 10;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(9, 70);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(30, 13);
			this.label9.TabIndex = 9;
			this.label9.Text = "Size:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(357, 20);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(31, 13);
			this.label8.TabIndex = 8;
			this.label8.Text = "Font:";
			// 
			// listFont
			// 
			this.listFont.FormattingEnabled = true;
			this.listFont.Location = new System.Drawing.Point(400, 20);
			this.listFont.Name = "listFont";
			this.listFont.Size = new System.Drawing.Size(310, 69);
			this.listFont.TabIndex = 7;
			this.listFont.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listFont_DrawItem);
			// 
			// tbx_Path2
			// 
			this.tbx_Path2.Location = new System.Drawing.Point(53, 17);
			this.tbx_Path2.Name = "tbx_Path2";
			this.tbx_Path2.Size = new System.Drawing.Size(266, 20);
			this.tbx_Path2.TabIndex = 6;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(9, 19);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(32, 13);
			this.label7.TabIndex = 5;
			this.label7.Text = "Path:";
			// 
			// tbx_Text
			// 
			this.tbx_Text.Location = new System.Drawing.Point(53, 43);
			this.tbx_Text.MaxLength = 200;
			this.tbx_Text.Name = "tbx_Text";
			this.tbx_Text.Size = new System.Drawing.Size(295, 20);
			this.tbx_Text.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(9, 45);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(31, 13);
			this.label6.TabIndex = 3;
			this.label6.Text = "Text:";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.pictureBox1);
			this.groupBox6.Controls.Add(this.pbx_Before);
			this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox6.Location = new System.Drawing.Point(3, 116);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(714, 255);
			this.groupBox6.TabIndex = 2;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Preview";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(365, 14);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(342, 235);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// pbx_Before
			// 
			this.pbx_Before.Location = new System.Drawing.Point(3, 15);
			this.pbx_Before.Name = "pbx_Before";
			this.pbx_Before.Size = new System.Drawing.Size(342, 235);
			this.pbx_Before.TabIndex = 0;
			this.pbx_Before.TabStop = false;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
			this.label11.Location = new System.Drawing.Point(204, 20);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(39, 13);
			this.label11.TabIndex = 19;
			this.label11.Text = "History";
			this.label11.Click += new System.EventHandler(this.label11_Click);
			this.label11.MouseLeave += new System.EventHandler(this.label11_MouseLeave);
			this.label11.MouseHover += new System.EventHandler(this.label11_MouseHover);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(728, 400);
			this.Controls.Add(this.tabControl1);
			this.Name = "Form1";
			this.Text = "AutoCommand";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_Step)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_Start)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbx_Before)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btn_Time;
		private System.Windows.Forms.Button btn_Date;
		private System.Windows.Forms.Button btn_Counter;
		private System.Windows.Forms.Button btn_Range;
		private System.Windows.Forms.Button btn_Name;
		private System.Windows.Forms.TextBox tbx_fileName;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btn_eCounter;
		private System.Windows.Forms.Button btn_eRange;
		private System.Windows.Forms.Button btn_eExtension;
		private System.Windows.Forms.TextBox tbx_Extension;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox cbx_Case;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox tbx_Replace;
		private System.Windows.Forms.TextBox tbx_Find;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.ComboBox cbx_Digits;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown nud_Step;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nud_Start;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button btn_Start1;
		private System.Windows.Forms.TextBox tbx_Path2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbx_Text;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pbx_Before;
		private System.Windows.Forms.ListBox listFont;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cbx_Size;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btn_Start2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button btn_Browse2;
		private System.Windows.Forms.Button btn_Browse1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Col_OldName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Col_NewName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Size;
		private System.Windows.Forms.DataGridViewTextBoxColumn Col_Date;
		private System.Windows.Forms.DataGridViewTextBoxColumn Col_Location;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label label11;
	}
}

