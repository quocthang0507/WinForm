<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.MyMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MyStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.MyToolStrip = New System.Windows.Forms.ToolStrip()
        Me.btnAddNewDownload = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnResume = New System.Windows.Forms.ToolStripButton()
        Me.btnResumeAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPause = New System.Windows.Forms.ToolStripButton()
        Me.btnPauseAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRemove = New System.Windows.Forms.ToolStripButton()
        Me.btnRemoveAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ListViewEx = New SampleProject.ListViewExtended()
        Me.MyMenuStrip.SuspendLayout()
        Me.MyToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MyMenuStrip
        '
        Me.MyMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.InfoToolStripMenuItem})
        Me.MyMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MyMenuStrip.Name = "MyMenuStrip"
        Me.MyMenuStrip.Size = New System.Drawing.Size(919, 24)
        Me.MyMenuStrip.TabIndex = 0
        Me.MyMenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.InfoToolStripMenuItem.Text = "Info"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'MyStatusStrip
        '
        Me.MyStatusStrip.Location = New System.Drawing.Point(0, 454)
        Me.MyStatusStrip.Name = "MyStatusStrip"
        Me.MyStatusStrip.Size = New System.Drawing.Size(919, 22)
        Me.MyStatusStrip.TabIndex = 2
        Me.MyStatusStrip.Text = "StatusStrip1"
        '
        'BottomToolStripPanel
        '
        Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
        Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'TopToolStripPanel
        '
        Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStripPanel.Name = "TopToolStripPanel"
        Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'RightToolStripPanel
        '
        Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightToolStripPanel.Name = "RightToolStripPanel"
        Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'LeftToolStripPanel
        '
        Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
        Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'MyToolStrip
        '
        Me.MyToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAddNewDownload, Me.ToolStripSeparator1, Me.btnResume, Me.btnResumeAll, Me.ToolStripSeparator2, Me.btnPause, Me.btnPauseAll, Me.ToolStripSeparator3, Me.btnRemove, Me.btnRemoveAll, Me.ToolStripSeparator6})
        Me.MyToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.MyToolStrip.Name = "MyToolStrip"
        Me.MyToolStrip.Size = New System.Drawing.Size(919, 25)
        Me.MyToolStrip.TabIndex = 1
        Me.MyToolStrip.Text = "ToolStrip1"
        '
        'btnAddNewDownload
        '
        Me.btnAddNewDownload.Image = CType(resources.GetObject("btnAddNewDownload.Image"), System.Drawing.Image)
        Me.btnAddNewDownload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAddNewDownload.Name = "btnAddNewDownload"
        Me.btnAddNewDownload.Size = New System.Drawing.Size(120, 22)
        Me.btnAddNewDownload.Text = "Add New Download"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnResume
        '
        Me.btnResume.Enabled = False
        Me.btnResume.Image = CType(resources.GetObject("btnResume.Image"), System.Drawing.Image)
        Me.btnResume.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnResume.Name = "btnResume"
        Me.btnResume.Size = New System.Drawing.Size(65, 22)
        Me.btnResume.Text = "Resume"
        '
        'btnResumeAll
        '
        Me.btnResumeAll.Image = CType(resources.GetObject("btnResumeAll.Image"), System.Drawing.Image)
        Me.btnResumeAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnResumeAll.Name = "btnResumeAll"
        Me.btnResumeAll.Size = New System.Drawing.Size(79, 22)
        Me.btnResumeAll.Text = "Resume All"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnPause
        '
        Me.btnPause.Enabled = False
        Me.btnPause.Image = CType(resources.GetObject("btnPause.Image"), System.Drawing.Image)
        Me.btnPause.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(56, 22)
        Me.btnPause.Text = "Pause"
        '
        'btnPauseAll
        '
        Me.btnPauseAll.Image = CType(resources.GetObject("btnPauseAll.Image"), System.Drawing.Image)
        Me.btnPauseAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPauseAll.Name = "btnPauseAll"
        Me.btnPauseAll.Size = New System.Drawing.Size(70, 22)
        Me.btnPauseAll.Text = "Pause All"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnRemove
        '
        Me.btnRemove.Enabled = False
        Me.btnRemove.Image = CType(resources.GetObject("btnRemove.Image"), System.Drawing.Image)
        Me.btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(66, 22)
        Me.btnRemove.Text = "Remove"
        '
        'btnRemoveAll
        '
        Me.btnRemoveAll.Image = CType(resources.GetObject("btnRemoveAll.Image"), System.Drawing.Image)
        Me.btnRemoveAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRemoveAll.Name = "btnRemoveAll"
        Me.btnRemoveAll.Size = New System.Drawing.Size(80, 22)
        Me.btnRemoveAll.Text = "Remove All"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ListViewEx
        '
        Me.ListViewEx.BackColor = System.Drawing.Color.White
        Me.ListViewEx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewEx.FullRowSelect = True
        Me.ListViewEx.Location = New System.Drawing.Point(0, 49)
        Me.ListViewEx.Name = "ListViewEx"
        Me.ListViewEx.OwnerDraw = True
        Me.ListViewEx.ShowItemToolTips = True
        Me.ListViewEx.Size = New System.Drawing.Size(919, 405)
        Me.ListViewEx.TabIndex = 3
        Me.ListViewEx.UseCompatibleStateImageBehavior = False
        Me.ListViewEx.View = System.Windows.Forms.View.Details
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 476)
        Me.Controls.Add(Me.ListViewEx)
        Me.Controls.Add(Me.MyStatusStrip)
        Me.Controls.Add(Me.MyToolStrip)
        Me.Controls.Add(Me.MyMenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MyMenuStrip
        Me.MaximizeBox = False
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sample Project"
        Me.MyMenuStrip.ResumeLayout(False)
        Me.MyMenuStrip.PerformLayout()
        Me.MyToolStrip.ResumeLayout(False)
        Me.MyToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MyMenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents MyStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents TopToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents RightToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents MyToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAddNewDownload As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnResume As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnResumeAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPause As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPauseAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRemove As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRemoveAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ListViewEx As SampleProject.ListViewExtended

End Class
