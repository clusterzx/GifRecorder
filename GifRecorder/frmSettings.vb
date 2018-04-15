Imports System.ComponentModel

Public Class frmSettings
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtOutputPath.Text = My.Settings.outputpath
        frmMain.Hide()
        If My.Settings.quality = Nothing Then
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
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        If Not txtOutputPath.Text = "" Then
            My.Settings.outputpath = txtOutputPath.Text
            My.Settings.quality = cmbQuality.SelectedIndex
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
End Class