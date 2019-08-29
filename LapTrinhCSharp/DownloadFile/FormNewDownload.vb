Imports System.IO
Imports System.Text.RegularExpressions

'// Select the 'URL', 'Filename' and 'Save to' folder.
'// No real error checking has been added.
Public Class FormNewDownload

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        '// Select a new download folder
        FBDialog.Description = "Select download folder:"
        FBDialog.ShowDialog()
        If FBDialog.SelectedPath <> String.Empty Then
            TextBoxBrowse.Text = FBDialog.SelectedPath & If(FBDialog.SelectedPath.EndsWith("\"), "", "\")
        End If
    End Sub

    '// Return filename from the url. Remove illegal characters.
    Private Function ExtractFileNameFromURL(ByVal URL As String) As String
        Try
            Dim FixedURL As String = Regex.Replace(URL.Substring(URL.LastIndexOf("/") + 1), "[^a-zA-Z0-9!@$%^&*()_+=[\]{}';,.-]", String.Empty)
            Return FixedURL
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Private Sub FormAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '// Set initial download folder to the 'Application StartupPath' folder
        TextBoxBrowse.Text = Application.StartupPath & If(Application.StartupPath.EndsWith("\"), "", "\")

        '// See if there's an URL loaded in the clipboard and show it.
        If Clipboard.ContainsText = False Then Return
        Try
            Dim fileUri As New Uri(Clipboard.GetText)
            If fileUri.Scheme = Uri.UriSchemeHttp Or fileUri.Scheme = Uri.UriSchemeHttps Then
                TextBoxURL.Text = Clipboard.GetText
                TextBoxFilename.Text = ExtractFileNameFromURL(Clipboard.GetText)
            End If
        Catch
        End Try
    End Sub
End Class