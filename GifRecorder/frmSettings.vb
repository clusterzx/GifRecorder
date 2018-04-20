Imports System.ComponentModel

Public Class frmSettings
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtOutputPath.Text = My.Settings.outputpath
        frmMain.Hide()
        If My.Settings.quality = vbEmpty Then
            If cmbQuality.Items.Count > 0 Then
                cmbQuality.SelectedIndex = 0
            End If
        ElseIf My.Settings.quality = 0 Then
            cmbQuality.SelectedIndex = 0
        ElseIf My.Settings.quality = 1 Then
            cmbQuality.SelectedIndex = 1
        ElseIf My.Settings.quality = 2 Then
            cmbQuality.SelectedIndex = 2
        ElseIf My.Settings.quality = 3 Then
            cmbQuality.SelectedIndex = 3
        End If

        If My.Settings.encoder = 0 Then
            cmbEncoder.SelectedIndex = 0
        ElseIf My.Settings.encoder = 1 Then
            cmbEncoder.SelectedIndex = 1
        ElseIf My.Settings.encoder = 2 Then
            cmbEncoder.SelectedIndex = 2
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        If Not txtOutputPath.Text = "" Then
            My.Settings.outputpath = txtOutputPath.Text
            My.Settings.quality = cmbQuality.SelectedIndex
            My.Settings.encoder = cmbEncoder.SelectedIndex
            My.Settings.Save()
            My.Settings.Reload()
            Me.Close()
        Else
            MsgBox("You have to set a output folder for your GIFs!", vbExclamation, "Warning")
        End If

    End Sub

    Private Sub frmSettings_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmMain.Show()
    End Sub

    Private Sub cmdChooseOutputFolder_Click(sender As Object, e As EventArgs) Handles cmdChooseOutputFolder.Click
        If folderBrowser.ShowDialog = DialogResult.OK Then
            txtOutputPath.Text = folderBrowser.SelectedPath
            My.Settings.outputpath = txtOutputPath.Text
        End If
    End Sub

    Private Sub cmbEncoder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEncoder.SelectedIndexChanged
        If cmbEncoder.SelectedIndex = 0 Then
            cmbQuality.Enabled = True
            txtEncoderInfo.Text = "The built-in encoder does not use any 3rd party dependencies." &
                "The result quality is overall very good but it will take much longer to encode."
        ElseIf cmbEncoder.SelectedIndex = 1 Then
            cmbQuality.Enabled = False
            txtEncoderInfo.Text = "The ffmpeg encoder is the most common used encoder for videos and audi files. It produces images in good quality and is much faster." &
                "Though it requires 3rd party dependencies."
        Else
            cmbQuality.Enabled = False
            txtEncoderInfo.Text = "The gifski encoder is a open source gif encoder. It is continuously. It produces very good outputs with reasonable speed. " &
                "Though it requires 3rd party dependencies."
        End If
    End Sub
End Class