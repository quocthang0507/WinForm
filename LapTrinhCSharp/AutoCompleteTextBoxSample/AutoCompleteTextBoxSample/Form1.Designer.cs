namespace AutoCompleteTextBoxSample
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.autoCompleteTextbox1 = new AutoCompleteTextBoxSample.AutoCompleteTextbox();
            this.SuspendLayout();
            // 
            // autoCompleteTextbox1
            // 
            this.autoCompleteTextbox1.AutoCompleteList = ((System.Collections.Generic.List<string>)(resources.GetObject("autoCompleteTextbox1.AutoCompleteList")));
            this.autoCompleteTextbox1.CaseSensitive = true;
            this.autoCompleteTextbox1.Location = new System.Drawing.Point(12, 29);
            this.autoCompleteTextbox1.MinTypedCharacters = 2;
            this.autoCompleteTextbox1.Name = "autoCompleteTextbox1";
            this.autoCompleteTextbox1.SelectedIndex = -1;
            this.autoCompleteTextbox1.Size = new System.Drawing.Size(301, 20);
            this.autoCompleteTextbox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 169);
            this.Controls.Add(this.autoCompleteTextbox1);
            this.Name = "Form1";
            this.Text = "Autocomplete Middle TextBox C#";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AutoCompleteTextbox autoCompleteTextbox1;
    }
}

