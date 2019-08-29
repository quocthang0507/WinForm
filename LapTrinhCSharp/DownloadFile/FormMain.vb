Imports System.IO

Public Class FormMain

    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '// The DefaultConnectionLimit is 2, which means you can normally only do two
        '// simultaneous downloads. This code allows you to change the limit.
        Net.ServicePointManager.DefaultConnectionLimit = 5
    End Sub

    Private Sub FormMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim wClient As DownloadFileAsyncExtended

        For i As Integer = 0 To ListViewEx.Items.Count - 1
            '// Check if the Tag isn't Nothing, because else the download has already
            '// finished or an error occurred, so it can't be cancelled.
            If ListViewEx.Items(i).Tag IsNot Nothing Then
                '// Get the DownloadFileAsyncExtended class instance from the ListViewItem Tag.
                wClient = DirectCast(ListViewEx.Items(i).Tag, DownloadFileAsyncExtended)
                '// Cancel the download if it's still busy.
                wClient.CancelAsync()
            End If
        Next
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("Sample Project for DownloadFileAsyncExtended", "Sample Project", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnAddNewDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNewDownload.Click
        Dim strURL As String
        Dim strFileName As String
        Dim strSavePath As String

        Using frm As New FormNewDownload
            '// Show Add New Download dialog and get result.
            If frm.ShowDialog = DialogResult.OK Then
                strURL = frm.TextBoxURL.Text.Trim
                strFileName = frm.TextBoxFilename.Text.Trim
                strSavePath = frm.TextBoxBrowse.Text.Trim
                '// Start the download.
                ListViewEx.StartDownload(strURL, Path.Combine(strSavePath, strFileName))
            End If
        End Using
    End Sub

    Private Sub ListViewEx_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListViewEx.MouseUp
        Dim objDrawingPoint As Point
        Dim objListViewItem As ListViewItem

        objDrawingPoint = ListViewEx.PointToClient(Cursor.Position)

        '// Check to see if an item has been selected.
        If Not IsNothing(objDrawingPoint) Then
            With objDrawingPoint
                objListViewItem = ListViewEx.GetItemAt(.X, .Y)
            End With

            '// If an item has been selected, then enable toolstrip buttons.
            If Not IsNothing(objListViewItem) Then
                btnResume.Enabled = True
                btnPause.Enabled = True
                btnRemove.Enabled = True
            Else '// Else disable them.
                btnResume.Enabled = False
                btnPause.Enabled = False
                btnRemove.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnResume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResume.Click
        Dim wClient As DownloadFileAsyncExtended

        For i As Integer = 0 To ListViewEx.SelectedItems.Count - 1
            If ListViewEx.SelectedItems(i).Tag IsNot Nothing Then
                wClient = DirectCast(ListViewEx.SelectedItems(i).Tag, DownloadFileAsyncExtended)
                '// Make sure you check if the download is not
                '// already busy or an exception will be thrown.
                If wClient.IsBusy = False Then
                    wClient.ResumeAsync()
                End If
            End If
        Next
    End Sub

    Private Sub btnResumeAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResumeAll.Click
        Dim wClient As DownloadFileAsyncExtended

        For i As Integer = 0 To ListViewEx.Items.Count - 1
            If ListViewEx.Items(i).Tag IsNot Nothing Then
                wClient = DirectCast(ListViewEx.Items(i).Tag, DownloadFileAsyncExtended)
                '// Make sure you check if the download is not
                '// already busy or an exception will be thrown.
                If wClient.IsBusy = False Then
                    wClient.ResumeAsync()
                End If
            End If
        Next
    End Sub

    Private Sub btnPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPause.Click
        Dim wClient As DownloadFileAsyncExtended

        For i As Integer = 0 To ListViewEx.SelectedItems.Count - 1
            If ListViewEx.SelectedItems(i).Tag IsNot Nothing Then
                wClient = DirectCast(ListViewEx.SelectedItems(i).Tag, DownloadFileAsyncExtended)
                '// Pause the download.
                wClient.CancelAsync()
            End If
        Next
    End Sub

    Private Sub btnPauseAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPauseAll.Click
        Dim wClient As DownloadFileAsyncExtended

        For i As Integer = 0 To ListViewEx.Items.Count - 1
            If ListViewEx.Items(i).Tag IsNot Nothing Then
                wClient = DirectCast(ListViewEx.Items(i).Tag, DownloadFileAsyncExtended)
                '// Pause the download.
                wClient.CancelAsync()
            End If
        Next
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Dim wClient As DownloadFileAsyncExtended

        '// Always loop backwards when removing items from the list,
        '// because the index gets updated when an item is removed.
        '// This can result in certain items not getting removed.
        For i As Integer = ListViewEx.SelectedItems.Count - 1 To 0 Step -1
            If ListViewEx.SelectedItems(i).Tag IsNot Nothing Then
                '// Get the DownloadFileAsyncExtended class instance from the ListViewItem Tag.
                wClient = DirectCast(ListViewEx.SelectedItems(i).Tag, DownloadFileAsyncExtended)
                '// Pause (cancel) the download and remove it from the list.
                wClient.CancelAsync()
                ListViewEx.SelectedItems(i).Tag = Nothing
                ListViewEx.SelectedItems(i).Remove()
            Else
                '// There's nothing to cancel, because the
                '// download has finished or caused an error.
                '// Just remove the item from the list.
                ListViewEx.SelectedItems(i).Remove()
            End If
        Next
    End Sub

    Private Sub btnRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAll.Click
        Dim wClient As DownloadFileAsyncExtended

        '// Always loop backwards when removing items from the list,
        '// because the index gets updated when an item is removed.
        '// This can result in certain items not getting removed.
        For i As Integer = ListViewEx.Items.Count - 1 To 0 Step -1
            If ListViewEx.Items(i).Tag IsNot Nothing Then
                '// Get the DownloadFileAsyncExtended class instance from the ListViewItem Tag.
                wClient = DirectCast(ListViewEx.Items(i).Tag, DownloadFileAsyncExtended)
                '// Pause (cancel) the download and remove it from the list.
                wClient.CancelAsync()
                ListViewEx.Items(i).Tag = Nothing
                ListViewEx.Items(i).Remove()
            Else
                '// There's nothing to cancel, because the
                '// download has finished or caused an error.
                '// Just remove the item from the list.
                ListViewEx.Items(i).Remove()
            End If
        Next
    End Sub
End Class
