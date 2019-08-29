// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using SampleProject;

namespace SampleProject
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class FormMain : System.Windows.Forms.Form
	{
		
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.MyMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MyStatusStrip = new System.Windows.Forms.StatusStrip();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.MyToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnAddNewDownload = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnResume = new System.Windows.Forms.ToolStripButton();
            this.btnResumeAll = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPause = new System.Windows.Forms.ToolStripButton();
            this.btnPauseAll = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRemove = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveAll = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ListViewEx = new SampleProject.ListViewExtended();
            this.MyMenuStrip.SuspendLayout();
            this.MyToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyMenuStrip
            // 
            this.MyMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.InfoToolStripMenuItem});
            this.MyMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MyMenuStrip.Name = "MyMenuStrip";
            this.MyMenuStrip.Size = new System.Drawing.Size(919, 24);
            this.MyMenuStrip.TabIndex = 0;
            this.MyMenuStrip.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // InfoToolStripMenuItem
            // 
            this.InfoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
            this.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem";
            this.InfoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.InfoToolStripMenuItem.Text = "Info";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.AboutToolStripMenuItem.Text = "About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // MyStatusStrip
            // 
            this.MyStatusStrip.Location = new System.Drawing.Point(0, 454);
            this.MyStatusStrip.Name = "MyStatusStrip";
            this.MyStatusStrip.Size = new System.Drawing.Size(919, 22);
            this.MyStatusStrip.TabIndex = 2;
            this.MyStatusStrip.Text = "StatusStrip1";
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // MyToolStrip
            // 
            this.MyToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNewDownload,
            this.ToolStripSeparator1,
            this.btnResume,
            this.btnResumeAll,
            this.ToolStripSeparator2,
            this.btnPause,
            this.btnPauseAll,
            this.ToolStripSeparator3,
            this.btnRemove,
            this.btnRemoveAll,
            this.ToolStripSeparator6});
            this.MyToolStrip.Location = new System.Drawing.Point(0, 24);
            this.MyToolStrip.Name = "MyToolStrip";
            this.MyToolStrip.Size = new System.Drawing.Size(919, 25);
            this.MyToolStrip.TabIndex = 1;
            this.MyToolStrip.Text = "ToolStrip1";
            // 
            // btnAddNewDownload
            // 
            this.btnAddNewDownload.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewDownload.Image")));
            this.btnAddNewDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNewDownload.Name = "btnAddNewDownload";
            this.btnAddNewDownload.Size = new System.Drawing.Size(133, 22);
            this.btnAddNewDownload.Text = "Add New Download";
            this.btnAddNewDownload.Click += new System.EventHandler(this.btnAddNewDownload_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnResume
            // 
            this.btnResume.Enabled = false;
            this.btnResume.Image = ((System.Drawing.Image)(resources.GetObject("btnResume.Image")));
            this.btnResume.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(69, 22);
            this.btnResume.Text = "Resume";
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnResumeAll
            // 
            this.btnResumeAll.Image = ((System.Drawing.Image)(resources.GetObject("btnResumeAll.Image")));
            this.btnResumeAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResumeAll.Name = "btnResumeAll";
            this.btnResumeAll.Size = new System.Drawing.Size(86, 22);
            this.btnResumeAll.Text = "Resume All";
            this.btnResumeAll.Click += new System.EventHandler(this.btnResumeAll_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPause.Image")));
            this.btnPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(58, 22);
            this.btnPause.Text = "Pause";
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnPauseAll
            // 
            this.btnPauseAll.Image = ((System.Drawing.Image)(resources.GetObject("btnPauseAll.Image")));
            this.btnPauseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPauseAll.Name = "btnPauseAll";
            this.btnPauseAll.Size = new System.Drawing.Size(75, 22);
            this.btnPauseAll.Text = "Pause All";
            this.btnPauseAll.Click += new System.EventHandler(this.btnPauseAll_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(70, 22);
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveAll.Image")));
            this.btnRemoveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(87, 22);
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // ToolStripSeparator6
            // 
            this.ToolStripSeparator6.Name = "ToolStripSeparator6";
            this.ToolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // ListViewEx
            // 
            this.ListViewEx.BackColor = System.Drawing.Color.White;
            this.ListViewEx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewEx.FullRowSelect = true;
            this.ListViewEx.Location = new System.Drawing.Point(0, 49);
            this.ListViewEx.Name = "ListViewEx";
            this.ListViewEx.OwnerDraw = true;
            this.ListViewEx.ShowItemToolTips = true;
            this.ListViewEx.Size = new System.Drawing.Size(919, 405);
            this.ListViewEx.TabIndex = 3;
            this.ListViewEx.UseCompatibleStateImageBehavior = false;
            this.ListViewEx.View = System.Windows.Forms.View.Details;
            this.ListViewEx.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListViewEx_MouseUp);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 476);
            this.Controls.Add(this.ListViewEx);
            this.Controls.Add(this.MyStatusStrip);
            this.Controls.Add(this.MyToolStrip);
            this.Controls.Add(this.MyMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MyMenuStrip;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download Multifile With Listview - https://laptrinhvb.net [Convert code vb.net =>" +
    " C#]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.MyMenuStrip.ResumeLayout(false);
            this.MyMenuStrip.PerformLayout();
            this.MyToolStrip.ResumeLayout(false);
            this.MyToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.MenuStrip MyMenuStrip;
		internal System.Windows.Forms.StatusStrip MyStatusStrip;
		internal System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
		internal System.Windows.Forms.ToolStripPanel TopToolStripPanel;
		internal System.Windows.Forms.ToolStripPanel RightToolStripPanel;
		internal System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
		internal System.Windows.Forms.ToolStrip MyToolStrip;
		internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem InfoToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
		internal System.Windows.Forms.ToolStripButton btnAddNewDownload;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
		internal System.Windows.Forms.ToolStripButton btnResume;
		internal System.Windows.Forms.ToolStripButton btnResumeAll;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
		internal System.Windows.Forms.ToolStripButton btnPause;
		internal System.Windows.Forms.ToolStripButton btnPauseAll;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
		internal System.Windows.Forms.ToolStripButton btnRemove;
		internal System.Windows.Forms.ToolStripButton btnRemoveAll;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator6;
        private System.ComponentModel.IContainer components;
        private ListViewExtended ListViewEx;
    }
	
}
