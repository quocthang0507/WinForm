namespace OMRReader_test1
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
            this.mainImageP = new System.Windows.Forms.Panel();
            this.histoGramSmoothP = new System.Windows.Forms.Panel();
            this.histoGramRawP = new System.Windows.Forms.Panel();
            this.filenamet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusTB = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.readFileB = new System.Windows.Forms.Button();
            this.engineTesterB = new System.Windows.Forms.Button();
            this.asyncProgress = new System.Windows.Forms.ProgressBar();
            this.asyncPrT = new System.Windows.Forms.Timer(this.components);
            this.multiTaskB = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.inDepthUpdates = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sheetNameTB = new System.Windows.Forms.TextBox();
            this.sheetAddTB = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.inDepthTB = new System.Windows.Forms.TextBox();
            this.prevB = new System.Windows.Forms.Button();
            this.nextB = new System.Windows.Forms.Button();
            this.inDepthPanel = new System.Windows.Forms.Panel();
            this.akTitleTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainImageP
            // 
            this.mainImageP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mainImageP.Location = new System.Drawing.Point(17, 15);
            this.mainImageP.Margin = new System.Windows.Forms.Padding(4);
            this.mainImageP.Name = "mainImageP";
            this.mainImageP.Size = new System.Drawing.Size(527, 575);
            this.mainImageP.TabIndex = 1;
            // 
            // histoGramSmoothP
            // 
            this.histoGramSmoothP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.histoGramSmoothP.Location = new System.Drawing.Point(16, 76);
            this.histoGramSmoothP.Margin = new System.Windows.Forms.Padding(4);
            this.histoGramSmoothP.Name = "histoGramSmoothP";
            this.histoGramSmoothP.Size = new System.Drawing.Size(113, 105);
            this.histoGramSmoothP.TabIndex = 7;
            this.toolTip1.SetToolTip(this.histoGramSmoothP, "Shows a histogram when Test Image Preparation is pressed");
            // 
            // histoGramRawP
            // 
            this.histoGramRawP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.histoGramRawP.Location = new System.Drawing.Point(137, 78);
            this.histoGramRawP.Margin = new System.Windows.Forms.Padding(4);
            this.histoGramRawP.Name = "histoGramRawP";
            this.histoGramRawP.Size = new System.Drawing.Size(113, 105);
            this.histoGramRawP.TabIndex = 7;
            this.toolTip1.SetToolTip(this.histoGramRawP, "Shows a smooth histogram when Test Image Preparation is pressed");
            // 
            // filenamet
            // 
            this.filenamet.Location = new System.Drawing.Point(140, 22);
            this.filenamet.Margin = new System.Windows.Forms.Padding(4);
            this.filenamet.Name = "filenamet";
            this.filenamet.Size = new System.Drawing.Size(231, 22);
            this.filenamet.TabIndex = 2;
            this.filenamet.Text = "testImage.jpg";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cam Image";
            // 
            // statusTB
            // 
            this.statusTB.Location = new System.Drawing.Point(16, 227);
            this.statusTB.Margin = new System.Windows.Forms.Padding(4);
            this.statusTB.Multiline = true;
            this.statusTB.Name = "statusTB";
            this.statusTB.ReadOnly = true;
            this.statusTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusTB.Size = new System.Drawing.Size(234, 202);
            this.statusTB.TabIndex = 4;
            this.statusTB.TextChanged += new System.EventHandler(this.statusTB_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1157, 1134);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 28);
            this.button4.TabIndex = 6;
            this.button4.Text = "CandidateSignature";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(16, 191);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(234, 28);
            this.button6.TabIndex = 0;
            this.button6.Text = "Full Process";
            this.toolTip1.SetToolTip(this.button6, "Reads, pre-processes, and extracts the image from file");
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.fullProcessB_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(16, 22);
            this.button9.Margin = new System.Windows.Forms.Padding(4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(113, 50);
            this.button9.TabIndex = 0;
            this.button9.Text = "OMR Sheet Creator";
            this.toolTip1.SetToolTip(this.button9, "Opens a utility which can be used to create OMR sheets compatible with this engin" +
        "e");
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.answerKeyDesignerB_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(137, 22);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 46);
            this.button3.TabIndex = 0;
            this.button3.Text = "Test image preparation";
            this.toolTip1.SetToolTip(this.button3, "Test if the image preprocessor is working");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.testImageForExtractionB_Click);
            // 
            // readFileB
            // 
            this.readFileB.Location = new System.Drawing.Point(16, 22);
            this.readFileB.Margin = new System.Windows.Forms.Padding(4);
            this.readFileB.Name = "readFileB";
            this.readFileB.Size = new System.Drawing.Size(113, 46);
            this.readFileB.TabIndex = 0;
            this.readFileB.Text = "readFile";
            this.toolTip1.SetToolTip(this.readFileB, "Test the image address for containing image. It should end with the image updated" +
        " in the mainPanel");
            this.readFileB.UseVisualStyleBackColor = true;
            this.readFileB.Click += new System.EventHandler(this.readImageB_Click);
            this.readFileB.MouseHover += new System.EventHandler(this.button10_MouseHover);
            // 
            // engineTesterB
            // 
            this.engineTesterB.Location = new System.Drawing.Point(15, 22);
            this.engineTesterB.Margin = new System.Windows.Forms.Padding(4);
            this.engineTesterB.Name = "engineTesterB";
            this.engineTesterB.Size = new System.Drawing.Size(172, 40);
            this.engineTesterB.TabIndex = 0;
            this.engineTesterB.Text = "OMR EngineTester";
            this.toolTip1.SetToolTip(this.engineTesterB, "Starts an aSync process on the image. DON\'T PRESS any OTHER BUTTONS unless the pr" +
        "ocess has finished.");
            this.engineTesterB.UseVisualStyleBackColor = true;
            this.engineTesterB.Click += new System.EventHandler(this.engineTesterB_Click);
            // 
            // asyncProgress
            // 
            this.asyncProgress.Location = new System.Drawing.Point(15, 410);
            this.asyncProgress.Margin = new System.Windows.Forms.Padding(4);
            this.asyncProgress.Name = "asyncProgress";
            this.asyncProgress.Size = new System.Drawing.Size(356, 13);
            this.asyncProgress.TabIndex = 8;
            // 
            // asyncPrT
            // 
            this.asyncPrT.Tick += new System.EventHandler(this.asyncPrT_Tick);
            // 
            // multiTaskB
            // 
            this.multiTaskB.Location = new System.Drawing.Point(195, 22);
            this.multiTaskB.Margin = new System.Windows.Forms.Padding(4);
            this.multiTaskB.Name = "multiTaskB";
            this.multiTaskB.Size = new System.Drawing.Size(176, 40);
            this.multiTaskB.TabIndex = 0;
            this.multiTaskB.Text = "Multitask Tester";
            this.toolTip1.SetToolTip(this.multiTaskB, "Developer\'s Only Button");
            this.multiTaskB.UseVisualStyleBackColor = true;
            this.multiTaskB.Click += new System.EventHandler(this.multiTaskB_Click);
            // 
            // inDepthUpdates
            // 
            this.inDepthUpdates.Location = new System.Drawing.Point(15, 70);
            this.inDepthUpdates.Margin = new System.Windows.Forms.Padding(4);
            this.inDepthUpdates.Multiline = true;
            this.inDepthUpdates.Name = "inDepthUpdates";
            this.inDepthUpdates.ReadOnly = true;
            this.inDepthUpdates.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inDepthUpdates.Size = new System.Drawing.Size(356, 96);
            this.inDepthUpdates.TabIndex = 9;
            this.toolTip1.SetToolTip(this.inDepthUpdates, "Shows inDepth progress Updates");
            this.inDepthUpdates.TextChanged += new System.EventHandler(this.inDepthUpdates_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.readFileB);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.histoGramRawP);
            this.groupBox1.Controls.Add(this.statusTB);
            this.groupBox1.Controls.Add(this.histoGramSmoothP);
            this.groupBox1.Location = new System.Drawing.Point(552, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 444);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic OMR reader";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.akTitleTB);
            this.groupBox2.Controls.Add(this.sheetNameTB);
            this.groupBox2.Controls.Add(this.sheetAddTB);
            this.groupBox2.Controls.Add(this.filenamet);
            this.groupBox2.Location = new System.Drawing.Point(825, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 145);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Files";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sheet Database";
            // 
            // sheetNameTB
            // 
            this.sheetNameTB.Location = new System.Drawing.Point(140, 80);
            this.sheetNameTB.Margin = new System.Windows.Forms.Padding(4);
            this.sheetNameTB.Name = "sheetNameTB";
            this.sheetNameTB.Size = new System.Drawing.Size(231, 22);
            this.sheetNameTB.TabIndex = 2;
            this.sheetNameTB.Text = "A4_1";
            // 
            // sheetAddTB
            // 
            this.sheetAddTB.Location = new System.Drawing.Point(140, 51);
            this.sheetAddTB.Margin = new System.Windows.Forms.Padding(4);
            this.sheetAddTB.Name = "sheetAddTB";
            this.sheetAddTB.Size = new System.Drawing.Size(231, 22);
            this.sheetAddTB.TabIndex = 2;
            this.sheetAddTB.Text = "omrSheet1.accdb";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.inDepthTB);
            this.groupBox3.Controls.Add(this.prevB);
            this.groupBox3.Controls.Add(this.nextB);
            this.groupBox3.Controls.Add(this.inDepthPanel);
            this.groupBox3.Controls.Add(this.inDepthUpdates);
            this.groupBox3.Controls.Add(this.engineTesterB);
            this.groupBox3.Controls.Add(this.multiTaskB);
            this.groupBox3.Controls.Add(this.asyncProgress);
            this.groupBox3.Location = new System.Drawing.Point(825, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(386, 430);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "The OMR Engine";
            // 
            // inDepthTB
            // 
            this.inDepthTB.Location = new System.Drawing.Point(14, 383);
            this.inDepthTB.Name = "inDepthTB";
            this.inDepthTB.Size = new System.Drawing.Size(324, 22);
            this.inDepthTB.TabIndex = 11;
            // 
            // prevB
            // 
            this.prevB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.7F);
            this.prevB.Location = new System.Drawing.Point(338, 382);
            this.prevB.Name = "prevB";
            this.prevB.Size = new System.Drawing.Size(17, 23);
            this.prevB.TabIndex = 0;
            this.prevB.Text = "<";
            this.prevB.UseVisualStyleBackColor = true;
            this.prevB.Click += new System.EventHandler(this.prevB_Click);
            // 
            // nextB
            // 
            this.nextB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.7F);
            this.nextB.Location = new System.Drawing.Point(354, 382);
            this.nextB.Name = "nextB";
            this.nextB.Size = new System.Drawing.Size(17, 23);
            this.nextB.TabIndex = 0;
            this.nextB.Text = ">";
            this.nextB.UseVisualStyleBackColor = true;
            this.nextB.Click += new System.EventHandler(this.nextB_Click);
            // 
            // inDepthPanel
            // 
            this.inDepthPanel.BackColor = System.Drawing.Color.Black;
            this.inDepthPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.inDepthPanel.Location = new System.Drawing.Point(15, 173);
            this.inDepthPanel.Name = "inDepthPanel";
            this.inDepthPanel.Size = new System.Drawing.Size(356, 207);
            this.inDepthPanel.TabIndex = 10;
            // 
            // akTitleTB
            // 
            this.akTitleTB.Location = new System.Drawing.Point(143, 109);
            this.akTitleTB.Margin = new System.Windows.Forms.Padding(4);
            this.akTitleTB.Name = "akTitleTB";
            this.akTitleTB.Size = new System.Drawing.Size(228, 22);
            this.akTitleTB.TabIndex = 2;
            this.akTitleTB.Text = "Nov 8th Literature 6th Grade";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sheet Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 112);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Answer Key Title";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.Location = new System.Drawing.Point(552, 465);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(267, 118);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tools";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Answer Key Maker";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 77);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(234, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "OMR Engine Console";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1231, 606);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.mainImageP);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainImageP;
        private System.Windows.Forms.TextBox filenamet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox statusTB;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel histoGramRawP;
        private System.Windows.Forms.Panel histoGramSmoothP;
        private System.Windows.Forms.Button readFileB;
        private System.Windows.Forms.Button engineTesterB;
        private System.Windows.Forms.ProgressBar asyncProgress;
        private System.Windows.Forms.Timer asyncPrT;
        private System.Windows.Forms.Button multiTaskB;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sheetAddTB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox inDepthUpdates;
        private System.Windows.Forms.Panel inDepthPanel;
        private System.Windows.Forms.TextBox sheetNameTB;
        private System.Windows.Forms.Button prevB;
        private System.Windows.Forms.Button nextB;
        private System.Windows.Forms.TextBox inDepthTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox akTitleTB;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

