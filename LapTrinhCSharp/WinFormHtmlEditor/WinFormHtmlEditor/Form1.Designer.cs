namespace WinFormHtmlEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.winFormHtmlEditor1 = new SpiceLogic.WinHTMLEditor.WinForm.WinFormHtmlEditor();
            this.winFormHtmlEditor1.SuspendLayout();
            this.SuspendLayout();
            // 
            // winFormHtmlEditor1
            // 
            this.winFormHtmlEditor1.AllowWebInEditorNavigationInPreview = false;
            this.winFormHtmlEditor1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.winFormHtmlEditor1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.winFormHtmlEditor1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.winFormHtmlEditor1.BackgroundImagePath = "";
            this.winFormHtmlEditor1.BaseUrl = "";
            this.winFormHtmlEditor1.BodyColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.winFormHtmlEditor1.BodyHtml = "";
            this.winFormHtmlEditor1.BodyStyle = "";
            this.winFormHtmlEditor1.Charset = "unicode";
            this.winFormHtmlEditor1.DefaultForeColor = System.Drawing.Color.Black;
            this.winFormHtmlEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winFormHtmlEditor1.DocumentCSSFilePath = "";
            this.winFormHtmlEditor1.DocumentHtml = resources.GetString("winFormHtmlEditor1.DocumentHtml");
            this.winFormHtmlEditor1.DocumentTitle = "";
            this.winFormHtmlEditor1.EditorContextMenuStrip = null;
            this.winFormHtmlEditor1.Location = new System.Drawing.Point(0, 0);
            this.winFormHtmlEditor1.Name = "winFormHtmlEditor1";
            this.winFormHtmlEditor1.Options.ConvertFileUrlsToLocalPaths = true;
            this.winFormHtmlEditor1.Options.FooterTagNavigatorFont = null;
            this.winFormHtmlEditor1.Options.FooterTagNavigatorTextColor = System.Drawing.Color.Teal;
            this.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.Host = null;
            this.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.Password = null;
            this.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.RemoteFolderPath = null;
            this.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.UrlOfTheRemoteFolderPath = null;
            this.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.UserName = null;
            this.winFormHtmlEditor1.Options.YouTubeVideoIFrameDefaultCSS = "border:1px;border-style:solid;border-color:gray;";
            this.winFormHtmlEditor1.ScrollBarSetting = SpiceLogic.HtmlEditorControl.Domain.BOs.ScrollBarVisibility.Default;
            this.winFormHtmlEditor1.Size = new System.Drawing.Size(800, 450);
            this.winFormHtmlEditor1.SpellCheckOptions.DictionaryFilePath = null;
            this.winFormHtmlEditor1.SpellCheckOptions.SuggestionMode = SpiceLogic.HtmlEditorControl.FrameworkExtensions.SpellCheck.NetSpell.Spelling.SuggestionEnum.PhoneticNearMiss;
            this.winFormHtmlEditor1.SpellCheckOptions.WaitAlertMessage = "Searching next messpelled word..... (please wait)";
            this.winFormHtmlEditor1.TabIndex = 0;
            // 
            // winFormHtmlEditor1.WinFormHtmlEditor_Toolbar1
            // 
            this.winFormHtmlEditor1.Toolbar1.Location = new System.Drawing.Point(0, 0);
            this.winFormHtmlEditor1.Toolbar1.Name = "WinFormHtmlEditor_Toolbar1";
            this.winFormHtmlEditor1.Toolbar1.Size = new System.Drawing.Size(800, 29);
            this.winFormHtmlEditor1.Toolbar1.TabIndex = 0;
            // 
            // winFormHtmlEditor1.WinFormHtmlEditor_Toolbar2
            // 
            this.winFormHtmlEditor1.Toolbar2.Location = new System.Drawing.Point(0, 29);
            this.winFormHtmlEditor1.Toolbar2.Name = "WinFormHtmlEditor_Toolbar2";
            this.winFormHtmlEditor1.Toolbar2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.winFormHtmlEditor1.Toolbar2.Size = new System.Drawing.Size(800, 29);
            this.winFormHtmlEditor1.Toolbar2.TabIndex = 0;
            this.winFormHtmlEditor1.ToolbarContextMenuStrip = null;
            // 
            // winFormHtmlEditor1.WinFormHtmlEditor_ToolbarFooter
            // 
            this.winFormHtmlEditor1.ToolbarFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.winFormHtmlEditor1.ToolbarFooter.Location = new System.Drawing.Point(0, 425);
            this.winFormHtmlEditor1.ToolbarFooter.Name = "WinFormHtmlEditor_ToolbarFooter";
            this.winFormHtmlEditor1.ToolbarFooter.Size = new System.Drawing.Size(800, 25);
            this.winFormHtmlEditor1.ToolbarFooter.TabIndex = 7;
            this.winFormHtmlEditor1.z__ignore = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.winFormHtmlEditor1);
            this.Name = "Form1";
            this.Text = "Winform Html Editor - https://laptrinhvb.net";
            this.winFormHtmlEditor1.ResumeLayout(false);
            this.winFormHtmlEditor1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SpiceLogic.WinHTMLEditor.WinForm.WinFormHtmlEditor winFormHtmlEditor1;
    }
}

