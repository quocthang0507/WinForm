namespace JumplistDemo
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblRecentAction = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbRecentFiles = new System.Windows.Forms.ListBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnClearHistory = new System.Windows.Forms.Button();
            this.btnNotepad = new System.Windows.Forms.Button();
            this.btnCalculator = new System.Windows.Forms.Button();
            this.btnPaint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Recent files";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(305, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 19;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblRecentAction
            // 
            this.lblRecentAction.AutoSize = true;
            this.lblRecentAction.Location = new System.Drawing.Point(95, 9);
            this.lblRecentAction.Name = "lblRecentAction";
            this.lblRecentAction.Size = new System.Drawing.Size(22, 13);
            this.lblRecentAction.TabIndex = 18;
            this.lblRecentAction.Text = ".....";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Recent action:";
            // 
            // lbRecentFiles
            // 
            this.lbRecentFiles.FormattingEnabled = true;
            this.lbRecentFiles.Location = new System.Drawing.Point(15, 64);
            this.lbRecentFiles.Name = "lbRecentFiles";
            this.lbRecentFiles.Size = new System.Drawing.Size(365, 173);
            this.lbRecentFiles.TabIndex = 16;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(15, 25);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(284, 20);
            this.txtFilePath.TabIndex = 15;
            // 
            // btnClearHistory
            // 
            this.btnClearHistory.Location = new System.Drawing.Point(271, 243);
            this.btnClearHistory.Name = "btnClearHistory";
            this.btnClearHistory.Size = new System.Drawing.Size(74, 23);
            this.btnClearHistory.TabIndex = 13;
            this.btnClearHistory.Text = "Clear history";
            this.btnClearHistory.UseVisualStyleBackColor = true;
            this.btnClearHistory.Click += new System.EventHandler(this.btnClearHistory_Click);
            // 
            // btnNotepad
            // 
            this.btnNotepad.Location = new System.Drawing.Point(30, 243);
            this.btnNotepad.Name = "btnNotepad";
            this.btnNotepad.Size = new System.Drawing.Size(74, 23);
            this.btnNotepad.TabIndex = 12;
            this.btnNotepad.Text = "Notepad";
            this.btnNotepad.UseVisualStyleBackColor = true;
            this.btnNotepad.Click += new System.EventHandler(this.btnNotepad_Click);
            // 
            // btnCalculator
            // 
            this.btnCalculator.Location = new System.Drawing.Point(110, 243);
            this.btnCalculator.Name = "btnCalculator";
            this.btnCalculator.Size = new System.Drawing.Size(74, 23);
            this.btnCalculator.TabIndex = 11;
            this.btnCalculator.Text = "Calculator";
            this.btnCalculator.UseVisualStyleBackColor = true;
            this.btnCalculator.Click += new System.EventHandler(this.btnCalculator_Click);
            // 
            // btnPaint
            // 
            this.btnPaint.Location = new System.Drawing.Point(190, 243);
            this.btnPaint.Name = "btnPaint";
            this.btnPaint.Size = new System.Drawing.Size(74, 23);
            this.btnPaint.TabIndex = 21;
            this.btnPaint.Text = "Paint";
            this.btnPaint.UseVisualStyleBackColor = true;
            this.btnPaint.Click += new System.EventHandler(this.btnPaint_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 275);
            this.Controls.Add(this.btnPaint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblRecentAction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbRecentFiles);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnClearHistory);
            this.Controls.Add(this.btnNotepad);
            this.Controls.Add(this.btnCalculator);
            this.Name = "Form1";
            this.Text = "[C#] JumpList Demo - https://laptrinhvb.net";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblRecentAction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbRecentFiles;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnClearHistory;
        private System.Windows.Forms.Button btnNotepad;
        private System.Windows.Forms.Button btnCalculator;
        private System.Windows.Forms.Button btnPaint;
    }
}

