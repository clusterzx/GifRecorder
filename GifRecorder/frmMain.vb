Imports System.Threading
Imports System.Windows.Media.Imaging
Imports Gif.Components
Public Class frmMain
    Dim rs As New Resizer
    Dim counter As Integer = 0
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.outputpath = "" Then
            MsgBox("You have to set some settings!", vbInformation, "Hey")
            frmSettings.Show()
        End If
        'rs.FindAllControls(Me)
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'rs.ResizeAllControls(Me)
        panelTranspacrency.Width = Me.Width - 30
        panelTranspacrency.Height = Me.Height - 75
    End Sub

    Private Sub RecordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecordToolStripMenuItem.Click
        If My.Settings.outputpath = "" Then
            MsgBox("You have not specified a folder to save your images!", vbExclamation, "Warning!")
        Else
            If IO.Directory.Exists(My.Settings.outputpath & "\temp") Then
                IO.Directory.Delete(My.Settings.outputpath & "\temp", True)
            End If
            IO.Directory.CreateDirectory(My.Settings.outputpath & "\temp")
            RecordToolStripMenuItem.Enabled = False
            StopRecordingToolStripMenuItem.Enabled = True
            tmrWork.Enabled = True
            tmrWork.Start()
        End If
    End Sub
    Private Function getBitmap(ByVal pCtrl As Control) As Drawing.Bitmap
        Dim myBmp As New Bitmap(pCtrl.Width, pCtrl.Height)
        Dim g As Graphics = Graphics.FromImage(myBmp)

        Dim p As New Point(pCtrl.Parent.Width - pCtrl.Parent.ClientRectangle.Width - 4, pCtrl.Parent.Height - pCtrl.Parent.ClientRectangle.Height - 4)
        g.CopyFromScreen(pCtrl.Parent.Location + pCtrl.Location + p, Point.Empty, myBmp.Size)
        Dim LocalMousePosition As Point
        LocalMousePosition = panelTranspacrency.PointToClient(Cursor.Position)
        Cursor.Draw(g, New Rectangle(New Point(LocalMousePosition.X, LocalMousePosition.Y), Cursor.Size))
        Return myBmp
        g.Dispose()
    End Function

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        frmSettings.Show()
    End Sub

    Private Sub tmrWork_Tick(sender As Object, e As EventArgs) Handles tmrWork.Tick
        counter += 1
        Dim bm As Bitmap = getBitmap(Me.panelTranspacrency)
        bm.Save(My.Settings.outputpath & "\temp\" & counter & ".png", Drawing.Imaging.ImageFormat.Png)
        bm.Dispose()
    End Sub

    Private Sub StopRecordingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopRecordingToolStripMenuItem.Click
        tmrWork.Enabled = False
        tmrWork.Stop()
        MsgBox("Recording stopped, now you can click Create GIF")
        CreateGIFToolStripMenuItem.Enabled = True
        RecordToolStripMenuItem.Enabled = True
    End Sub

    Private Sub CreateGIFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateGIFToolStripMenuItem.Click
        Try

            panelTranspacrency.BackgroundImage = My.Resources.encoding
            panelTranspacrency.BackgroundImageLayout = ImageLayout.Stretch

            Dim thread As New Thread(AddressOf DoEncoding)
            thread.Start()

        Catch ex As Exception

        End Try
    End Sub
    Sub DoEncoding()
        Try
            'Dim filenames As New List(Of Bitmap)
            'Dim di As New IO.DirectoryInfo(My.Settings.outputpath)
            'IO.File.Delete(My.Settings.outputpath & "\Thumbs.db")
            'Dim fis = di.GetFiles().OrderBy(Function(fi) CInt(IO.Path.GetFileNameWithoutExtension(fi.Name))).ToArray()
            'For Each filestr In fis
            '    filenames.Add(New Bitmap(filestr.FullName))
            'Next

            Dim outputFilePath As String = My.Settings.outputpath & "\output.gif"
            Dim ex As AnimatedGifEncoder = New AnimatedGifEncoder()
            ex.Start(outputFilePath)
            ex.SetDelay(1)
            ex.SetRepeat(0)
            ex.SetFrameRate(30)
            If My.Settings.quality = 0 Then
                ex.SetQuality(20)
            ElseIf My.Settings.quality = 1 Then
                ex.SetQuality(15)
            ElseIf My.Settings.quality = 2 Then
                ex.SetQuality(5)
            ElseIf My.Settings.quality = 3 Then
                ex.SetQuality(1)
            End If

            Dim di As New IO.DirectoryInfo(My.Settings.outputpath & "\temp")
            IO.File.Delete(My.Settings.outputpath & "\temp\Thumbs.db")
            IO.File.Delete(My.Settings.outputpath & "\Thumbs.db")
            Dim fis = di.GetFiles().OrderBy(Function(fi) CInt(IO.Path.GetFileNameWithoutExtension(fi.Name))).ToArray()
            For Each filestr In fis
                ex.AddFrame(Image.FromFile(filestr.FullName))
            Next

            ex.Finish()
            System.Threading.Thread.Sleep(1000)

            IO.Directory.Delete(My.Settings.outputpath & "\temp", True)
            panelTranspacrency.BackgroundImage = Nothing
            panelTranspacrency.BackgroundImageLayout = ImageLayout.Stretch
            MsgBox("Your GIF file is now ready. It was saved to: " & My.Settings.outputpath & "\output.gif" & vbCrLf & "Thanks for using GifRecorder. The application will now terminate itself.", vbInformation, "Finished")
            Application.Exit()
        Catch ex As Exception
            System.Threading.Thread.Sleep(1000)
            panelTranspacrency.BackgroundImage = Nothing
            panelTranspacrency.BackgroundImageLayout = ImageLayout.Stretch
            MsgBox("Your GIF file is now ready. It was saved to: " & My.Settings.outputpath & "\output.gif" & vbCrLf & "Thanks for using GifRecorder. The application will now terminate itself.", vbInformation, "Finished")
            Application.Exit()
        End Try
    End Sub
End Class
