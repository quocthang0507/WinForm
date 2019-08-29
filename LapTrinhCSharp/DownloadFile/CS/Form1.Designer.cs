namespace SampleProject
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
            this.listViewExtended1 = new SampleProject.ListViewExtended();
            this.SuspendLayout();
            // 
            // listViewExtended1
            // 
            this.listViewExtended1.BackColor = System.Drawing.Color.White;
            this.listViewExtended1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewExtended1.FullRowSelect = true;
            this.listViewExtended1.Location = new System.Drawing.Point(0, 0);
            this.listViewExtended1.Name = "listViewExtended1";
            this.listViewExtended1.OwnerDraw = true;
            this.listViewExtended1.ShowItemToolTips = true;
            this.listViewExtended1.Size = new System.Drawing.Size(1128, 481);
            this.listViewExtended1.TabIndex = 0;
            this.listViewExtended1.UseCompatibleStateImageBehavior = false;
            this.listViewExtended1.View = System.Windows.Forms.View.Details;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 481);
            this.Controls.Add(this.listViewExtended1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ListViewExtended listViewExtended1;
    }
}