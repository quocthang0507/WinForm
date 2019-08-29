Imports System.IO
Imports System.Drawing.Drawing2D

Public Class ListViewExtended
    Inherits ListView

    Private StatusImageList As New ImageList

    Public Sub New()
        '// Set OwnerDraw to True, so we can draw the progressbar.
        Me.OwnerDraw = True

        '// The control flickers if it's continuously
        '// updated and not double-buffered.
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)

        '// Configure the columns and such.
        Me.View = Windows.Forms.View.Details
        Me.BackColor = Color.White
        Me.ShowItemToolTips = True
        Me.FullRowSelect = True
        Me.HideSelection = True
        Me.Dock = DockStyle.Fill
        Me.BackColor = Color.White
        Me.Columns.Add("Filename", 225, HorizontalAlignment.Left)
        Me.Columns.Add("Size", 80, HorizontalAlignment.Right)
        Me.Columns.Add("Status", 125, HorizontalAlignment.Left)
        Me.Columns.Add("Completed", 100, HorizontalAlignment.Right)
        Me.Columns.Add("Progress", 125, HorizontalAlignment.Center)
        Me.Columns.Add("Speed", 75, HorizontalAlignment.Right)
        Me.Columns.Add("Time", 80, HorizontalAlignment.Left)
        Me.Columns.Add("Time Left", 80, HorizontalAlignment.Left)

        '// Configure Imagelist and assign it to the Listview.
        StatusImageList.ColorDepth = ColorDepth.Depth32Bit
        StatusImageList.ImageSize = New Size(16, 16)
        StatusImageList.Images.Add("Initializing", My.Resources.StatusInitializing)
        StatusImageList.Images.Add("Downloading", My.Resources.StatusDownload)
        StatusImageList.Images.Add("Paused", My.Resources.StatusPaused)
        StatusImageList.Images.Add("Finished", My.Resources.StatusFinished)
        StatusImageList.Images.Add("Error", My.Resources.StatusError)
        Me.SmallImageList = StatusImageList

    End Sub

    '// Draw default ColumnHeader.
    Private Sub Me_DrawColumnHeader(ByVal sender As Object, _
                ByVal e As DrawListViewColumnHeaderEventArgs) Handles Me.DrawColumnHeader
        e.DrawDefault = True
    End Sub

    '// Draw default main item.
    Private Sub Me_DrawItem(ByVal sender As Object, _
                ByVal e As DrawListViewItemEventArgs) Handles Me.DrawItem
        e.DrawDefault = False
    End Sub

    '// Here we draw the progressbar in the 4th SubItem.
    Private Sub Me_DrawSubItem(ByVal sender As Object, ByVal e As DrawListViewSubItemEventArgs) Handles Me.DrawSubItem

        If (e.ItemState And ListViewItemStates.Selected) <> 0 Then
            '// Item is highlighted.
            e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds)
        End If

        '// Draw the progressbar.
        If e.ColumnIndex = 4 Then
            '// Center the text in the progressbar.
            Dim sf As New StringFormat
            sf.Alignment = StringAlignment.Center
            '// Background color of the progressbar is white.
            e.Graphics.FillRectangle(Brushes.White, e.Bounds)
            '// Percentage of the progressbar to fill.
            Dim FillPercent As Integer = CInt((CDbl(e.SubItem.Text) / 100) * (e.Bounds.Width - 2))
            '// This creates a nice gradient. From top (White) to bottom (Red).
            Dim brGradient As Brush = New LinearGradientBrush(New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), Color.Red, Color.White, 270, True)
            '// Draw the actual progressbar.
            e.Graphics.FillRectangle(brGradient, e.Bounds.X + 1, e.Bounds.Y + 2, FillPercent, e.Bounds.Height - 3)
            '// Draw the percentage number and percent sign.
            '// NOTE: make sure that e.SubItem.Text only contains a number or an error will occur.
            e.Graphics.DrawString(e.SubItem.Text & " %", Me.Font, Brushes.Black, CSng(e.Bounds.X + (e.Bounds.Width / 2)), e.Bounds.Y + 3, sf)
            '// Draw a light gray rectangle/border around the progressbar.
            e.Graphics.DrawRectangle(Pens.LightGray, e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width - 1, e.Bounds.Height - 2)
        Else
            e.DrawDefault = True
        End If
    End Sub

    Public Sub StartDownload(ByVal URL As String, ByVal LocalFilePath As String)
        Dim wClient As New DownloadFileAsyncExtended

        '// Add some initial data to the Listview.
        Dim lvw As ListViewItem = Me.Items.Add(Path.GetFileName(LocalFilePath))
        lvw.SubItems.Add("0 Bytes") '// Total Size.
        lvw.SubItems.Add("Initializing...") '// Status.
        lvw.SubItems.Add("0 Bytes") '// Completed.
        lvw.SubItems.Add("0") '// Progress Percentage. NOTE: Only add a number here, no letters/signs!
        lvw.SubItems.Add("0 kB/s") '// Download Speed.
        lvw.SubItems.Add("00:00:00") '// Download Time.
        lvw.SubItems.Add("00:00:00") '// Remaining Time.
        lvw.ImageKey = "Initializing" '// Initializing image.
        '// Store the DownloadFileAsyncExtended class instance in the Tag,
        '// so we can use it later to cancel/resume the download if necessary.
        lvw.Tag = wClient

        '// Add Event handlers, so we can update the progress to the user.
        AddHandler wClient.DownloadProgressChanged, AddressOf DownloadProgressChanged
        AddHandler wClient.DownloadCompleted, AddressOf DownloadCompleted

        '// IMPORTANT !!
        '// If you don't add this line, then all events are raised on a separate
        '// thread and you will get cross-thread errors when accessing the Listview
        '// or other controls directly in the raised events.
        wClient.SynchronizingObject = Me

        '// Update frequency. You can select NoDelay, HalfSecond or Second.
        '// HalfSecond and Second will prevent the DownloadProgressChanged event
        '// from firing continuously and hogging CPU when updating the controls.
        '// If you download small files that could be downloaded within a second,
        '// then set it to NoDelay or the progress might not be visible.
        wClient.ProgressUpdateFrequency = DownloadFileAsyncExtended.UpdateFrequency.Second

        '// The method to actually download a file. The userToken parameter can
        '// for example be a control you wish to update in the DownloadProgressChanged
        '// and DownloadCompleted events. A ListViewItem in this example.
        wClient.DowloadFileAsync(URL, LocalFilePath, lvw)

        '// Set wClient to Nothing, because we don't need it anymore.
        wClient = Nothing
    End Sub

    '// This event allows you to show the download progress to the user.

    '// e.BytesReceived = Bytes received so far.
    '// e.DownloadSpeedBytesPerSec = Download speed in bytes per second.
    '// e.DownloadTimeSeconds = Download time in seconds so far.
    '// e.ProgressPercentage = Percentage of the file downloaded.
    '// e.RemainingTimeSeconds = Remaining download time in seconds.
    '// e.TotalBytesToReceive = Total size of the file that is being downloaded.
    '// e.userToken = Usually the control(s) you wish to update.
    Private Sub DownloadProgressChanged(ByVal sender As Object, ByVal e As FileDownloadProgressChangedEventArgs)
        '// Get the ListViewItem we passed as userToken parameter, so we can update it.
        Dim lvw As ListViewItem = DirectCast(e.userToken, ListViewItem)

        '// Update the ListView items.
        lvw.SubItems(1).Text = ConvertBytes(e.TotalBytesToReceive)
        lvw.SubItems(2).Text = "Downloading"
        lvw.SubItems(3).Text = ConvertBytes(e.BytesReceived)
        lvw.SubItems(4).Text = e.ProgressPercentage
        lvw.SubItems(5).Text = (e.DownloadSpeedBytesPerSec \ 1024).ToString & " kB/s"
        lvw.SubItems(6).Text = ConvertSeconds(e.DownloadTimeSeconds)
        lvw.SubItems(7).Text = ConvertSeconds(e.RemainingTimeSeconds)
        lvw.ImageKey = "Downloading"
    End Sub

    '// This event lets you know when the download is complete. The download finished
    '// successfully, the user cancelled the download or there was an error.
    Private Sub DownloadCompleted(ByVal sender As Object, ByVal e As FileDownloadCompletedEventArgs)
        '// Get the ListViewItem we passed as userToken parameter, so we can update it
        Dim lvw As ListViewItem = DirectCast(e.userToken, ListViewItem)

        If e.ErrorMessage IsNot Nothing Then '// Was there an error.
            lvw.SubItems(2).Text = e.ErrorMessage.Message.ToString
            lvw.ImageKey = "Error"
            '// Set Tag to Nothing in order to remove the wClient class instance.
            '// This way we know we can't resume the download.
            lvw.Tag = Nothing

        ElseIf e.Cancelled Then '// The user cancelled the download.
            lvw.SubItems(2).Text = "Paused"
            lvw.ImageKey = "Paused"

        Else '// Download was successful.
            lvw.SubItems(2).Text = "Finished"
            lvw.ImageKey = "Finished"
            '// Set Tag to Nothing in order to remove the wClient class instance.
            '// This way we know we can't resume the download.
            lvw.Tag = Nothing
        End If

        '// Reset Speed and Time values.
        lvw.SubItems(5).Text = "0 kB/s"
        lvw.SubItems(6).Text = ConvertSeconds(0)
        lvw.SubItems(7).Text = ConvertSeconds(0)
    End Sub

    '// Convert seconds to hour:minute:seconds (00:00:00) format.
    Private Function ConvertSeconds(ByVal Seconds As Long) As String
        If Seconds <= 0 Then Seconds = 0
        Return String.Format("{0}:{1}:{2}", _
                             (Seconds \ 3600).ToString("00"), _
                             ((Seconds Mod 3600) \ 60).ToString("00"), _
                             (Seconds Mod 60).ToString("00"))
    End Function

    '// Convert Bytes to KiloBytes.
    Private Function ConvertBytes(ByVal Bytes As Long) As String
        If Bytes < 1024 Then
            Return "1 KB"
        Else
            Return String.Format("{0:#,#} KB", (Bytes / 1024))
        End If
    End Function
End Class
