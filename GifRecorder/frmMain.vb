Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Media.Imaging
Imports Gif.Components
Public Class frmMain
    Dim rs As New Resizer
    Dim counter As Integer = 0
    Private Delegate Sub InvokeWithString(ByVal text As String)
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

        txtEncodingOutput.Width = Me.Width - 30
        txtEncodingOutput.Height = Me.Height - 75
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
    Private Function getBitmap(ByVal pCtrl As Control) As Bitmap
        Dim myBmp As Bitmap
        If myBmp IsNot Nothing Then
            myBmp.Dispose()
        End If
        myBmp = New Bitmap(pCtrl.Width, pCtrl.Height)
        Dim g As Graphics = Graphics.FromImage(myBmp)

        Dim p As New Point(pCtrl.Parent.Width - pCtrl.Parent.ClientRectangle.Width - 4, pCtrl.Parent.Height - pCtrl.Parent.ClientRectangle.Height - 4)
        g.CopyFromScreen(pCtrl.Parent.Location + pCtrl.Location + p, Point.Empty, myBmp.Size)
        Dim LocalMousePosition As Point
        LocalMousePosition = panelTranspacrency.PointToClient(Cursor.Position)
        Cursor.Draw(g, New Rectangle(New Point(LocalMousePosition.X, LocalMousePosition.Y), Cursor.Size))
        'Return myBmp
        myBmp.Save(My.Settings.outputpath & "\temp\" & counter & ".png", Drawing.Imaging.ImageFormat.Png)
        myBmp.Dispose()
        g.Dispose()

    End Function

    Private Sub tmrWork_Tick(sender As Object, e As EventArgs) Handles tmrWork.Tick
        counter += 1
        'Dim bm As Bitmap
        getBitmap(Me.panelTranspacrency)
        'bm.Save(My.Settings.outputpath & "\temp\" & counter & ".png", Drawing.Imaging.ImageFormat.Png)
        'bm.Dispose()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        frmSettings.Show()
    End Sub

    Private Sub StopRecordingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopRecordingToolStripMenuItem.Click
        tmrWork.Enabled = False
        tmrWork.Stop()
        MsgBox("Recording stopped, now you can click Create GIF")
        CreateGIFToolStripMenuItem.Enabled = True
        RecordToolStripMenuItem.Enabled = False
        StopRecordingToolStripMenuItem.Enabled = False
    End Sub

    Private Sub CreateGIFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateGIFToolStripMenuItem.Click
        Try



            If My.Settings.encoder = 0 Then
                Dim thread As New Thread(AddressOf DoEncodingBuiltIn)
                thread.Start()
                panelTranspacrency.BackgroundImage = My.Resources.encoding
                panelTranspacrency.BackgroundImageLayout = ImageLayout.Stretch
                Me.TopMost = False
            ElseIf My.Settings.encoder = 1 Then
                'Dim thread As New Thread(AddressOf DoEncodingFFMPEG)
                'thread.Start()
                txtEncodingOutput.Visible = True
                Me.TopMost = False
                workerEncode.RunWorkerAsync()
            Else
                txtEncodingOutput.Visible = True
                Me.TopMost = False
                workerGifski.RunWorkerAsync()
            End If


        Catch ex As Exception

        End Try
    End Sub
    Sub DoEncodingBuiltIn()
        Try

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
            'panelTranspacrency.BackgroundImage = Nothing
            'panelTranspacrency.BackgroundImageLayout = ImageLayout.Stretch
            MsgBox("Your GIF file is now ready. It was saved to: " & My.Settings.outputpath & "\output.gif" & vbCrLf & "Thanks for using GifRecorder. The application will now terminate itself.", vbInformation, "Finished")
            Application.Exit()
        Catch ex As Exception
            System.Threading.Thread.Sleep(1000)
            'panelTranspacrency.BackgroundImage = Nothing
            'panelTranspacrency.BackgroundImageLayout = ImageLayout.Stretch
            MsgBox("Your GIF file is now ready. It was saved to: " & My.Settings.outputpath & "\output.gif" & vbCrLf & "Thanks for using GifRecorder. The application will now terminate itself.", vbInformation, "Finished")
            Application.Exit()
        End Try
    End Sub
    Function ShowTxt()
        txtEncodingOutput.Visible = True
    End Function
    Private Sub workerEncode_DoWork(sender As Object, e As DoWorkEventArgs) Handles workerEncode.DoWork
        Try
            Dim ffmpeg_path As String = My.Computer.FileSystem.CurrentDirectory & "\ffmpeg\ffmpeg.exe"
            Dim tempPath As String = My.Settings.outputpath & "\temp\"
            Dim outputFilePath As String = My.Settings.outputpath & "\output.gif"

            Dim systemencoding As System.Text.Encoding
            systemencoding = System.Text.Encoding.GetEncoding(Globalization.CultureInfo.CurrentUICulture.TextInfo.OEMCodePage)

            Dim encBin As New Process

            With encBin.StartInfo
                .FileName = ffmpeg_path
                .Arguments = "-framerate 25 -i " & tempPath & "%d.png -c:v libx264 -profile:v high -crf 20 -pix_fmt yuv420p -vf ""scale=trunc(iw/2)*2:trunc(ih/2)*2"" " & tempPath & "video.avi"
                .UseShellExecute = False
                .RedirectStandardError = True
                .RedirectStandardOutput = True
                .RedirectStandardInput = True
                .CreateNoWindow = True
                .StandardOutputEncoding = systemencoding
                .StandardErrorEncoding = systemencoding
            End With
            encBin.EnableRaisingEvents = True
            AddHandler encBin.ErrorDataReceived, AddressOf Async_Data_Received
            AddHandler encBin.OutputDataReceived, AddressOf Async_Data_Received

            encBin.Start()

            encBin.BeginOutputReadLine()
            encBin.BeginErrorReadLine()

            'workerEncode.ReportProgress(50, sOutput)
            'If txtEncodingOutput.InvokeRequired Then
            '    txtEncodingOutput.Invoke(Sub() txtEncodingOutput.Text = sOutput)
            'Else
            '    txtEncodingOutput.Text = sOutput
            'End If

            While Process.GetProcessesByName("ffmpeg").Count > 0

            End While


            Dim encBinx As New Process
            With encBinx.StartInfo
                .FileName = ffmpeg_path
                .Arguments = "-i " & tempPath & "video.avi -pix_fmt rgb24 -vf fps=25 " & tempPath & "output.gif"
                .UseShellExecute = False
                .RedirectStandardError = True
                .RedirectStandardOutput = True
                .RedirectStandardInput = True
                .CreateNoWindow = True
                .StandardOutputEncoding = systemencoding
                .StandardErrorEncoding = systemencoding
            End With

            encBinx.EnableRaisingEvents = True
            AddHandler encBinx.ErrorDataReceived, AddressOf Async_Data_Received
            AddHandler encBinx.OutputDataReceived, AddressOf Async_Data_Received

            encBinx.Start()
            encBinx.BeginOutputReadLine()
            encBinx.BeginErrorReadLine()



            While Process.GetProcessesByName("ffmpeg").Count > 0

            End While

            IO.File.Move(tempPath & "output.gif", My.Settings.outputpath & "\output_" & DateTime.Now.ToString("dd-mm-yyyy-HH-mm") & ".gif")

            Dim di As New IO.DirectoryInfo(My.Settings.outputpath & "\temp")
            IO.File.Delete(My.Settings.outputpath & "\temp\Thumbs.db")
            IO.File.Delete(My.Settings.outputpath & "\Thumbs.db")



            System.Threading.Thread.Sleep(1000)

            IO.Directory.Delete(My.Settings.outputpath & "\temp", True)
            panelTranspacrency.BackgroundImage = Nothing
            panelTranspacrency.BackgroundImageLayout = ImageLayout.Stretch
            MsgBox("Your GIF file is now ready. It was saved to: " & My.Settings.outputpath & "\output.gif" & vbCrLf & "Thanks for using GifRecorder. The application will now terminate itself.", vbInformation, "Finished")
            Application.Exit()
        Catch ex As Exception
            MsgBox(ex.Message)
            System.Threading.Thread.Sleep(1000)
            panelTranspacrency.BackgroundImage = Nothing
            panelTranspacrency.BackgroundImageLayout = ImageLayout.Stretch
            MsgBox("Your GIF file is now ready. It was saved to: " & My.Settings.outputpath & "\output.gif" & vbCrLf & "Thanks for using GifRecorder. The application will now terminate itself.", vbInformation, "Finished")
            Application.Exit()
        End Try
    End Sub


    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim ffmpeg_path As String = My.Computer.FileSystem.CurrentDirectory & "\ffmpeg\ffmpeg.exe"
    '    Dim tempPath As String = My.Settings.outputpath & "\temp\"
    '    Dim outputFilePath As String = My.Settings.outputpath & "\output.gif"
    '    Dim encBin As New ProcessStartInfo
    '    encBin.FileName = ffmpeg_path
    '    encBin.UseShellExecute = True
    '    encBin.WindowStyle = ProcessWindowStyle.Normal
    '    encBin.Arguments = "-framerate 25 -i " & tempPath & "%d.png -c:v libx264 -profile:v high -crf 20 -pix_fmt yuv420p -vf ""scale=trunc(iw/2)*2:trunc(ih/2)*2"" " & tempPath & "video.avi"
    '    Dim proc As Process = Process.Start(encBin)
    '    'Dim test As String = "-framerate 25 -i " & tempPath & "%d.png -c:v libx264 -profile:v high -crf 20 -pix_fmt yuv420p -vf ""scale=trunc(iw/2)*2:trunc(ih/2)*2"" " & tempPath & "video.avi"
    '    'Clipboard.SetText(test)
    'End Sub

    Private Sub Async_Data_Received(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        Me.Invoke(New InvokeWithString(AddressOf Sync_Output), e.Data)
    End Sub
    Private Sub Sync_Output(ByVal text As String)
        txtEncodingOutput.AppendText(text & Environment.NewLine)
        txtEncodingOutput.ScrollToCaret()
    End Sub

    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmSplashScreen.Close()
    End Sub

    Private Sub workerGifski_DoWork(sender As Object, e As DoWorkEventArgs) Handles workerGifski.DoWork
        Try
            Dim gifski_path As String = My.Computer.FileSystem.CurrentDirectory & "\gifski\gifski.exe"
            Dim tempPath As String = My.Settings.outputpath & "\temp\"

            Dim systemencoding As System.Text.Encoding
            systemencoding = System.Text.Encoding.GetEncoding(Globalization.CultureInfo.CurrentUICulture.TextInfo.OEMCodePage)

            Dim encBinx As New Process
            With encBinx.StartInfo
                .FileName = gifski_path
                .Arguments = "--fps 30 " & tempPath & "*.png " & "--output " & tempPath & "output.gif"
                .UseShellExecute = False
                .RedirectStandardError = True
                .RedirectStandardOutput = True
                .RedirectStandardInput = True
                .CreateNoWindow = True
                .StandardOutputEncoding = systemencoding
                .StandardErrorEncoding = systemencoding
            End With

            encBinx.EnableRaisingEvents = True

            AddHandler encBinx.ErrorDataReceived, AddressOf Async_Data_Received
            AddHandler encBinx.OutputDataReceived, AddressOf Async_Data_Received

            encBinx.Start()
            encBinx.BeginOutputReadLine()
            encBinx.BeginErrorReadLine()



            While Process.GetProcessesByName("gifski").Count > 0

            End While

            IO.File.Move(tempPath & "output.gif", My.Settings.outputpath & "\output_" & DateTime.Now.ToString("dd-mm-yyyy-HH-mm") & ".gif")

            Dim di As New IO.DirectoryInfo(My.Settings.outputpath & "\temp")
            IO.File.Delete(My.Settings.outputpath & "\temp\Thumbs.db")
            IO.File.Delete(My.Settings.outputpath & "\Thumbs.db")



            System.Threading.Thread.Sleep(1000)

            IO.Directory.Delete(My.Settings.outputpath & "\temp", True)
            panelTranspacrency.BackgroundImage = Nothing
            panelTranspacrency.BackgroundImageLayout = ImageLayout.Stretch
            MsgBox("Your GIF file is now ready. It was saved to: " & My.Settings.outputpath & "\output.gif" & vbCrLf & "Thanks for using GifRecorder. The application will now terminate itself.", vbInformation, "Finished")
            Application.Exit()
        Catch ex As Exception
            MsgBox(ex.Message)
            System.Threading.Thread.Sleep(1000)
            panelTranspacrency.BackgroundImage = Nothing
            panelTranspacrency.BackgroundImageLayout = ImageLayout.Stretch
            MsgBox("Your GIF file is now ready. It was saved to: " & My.Settings.outputpath & "\output.gif" & vbCrLf & "Thanks for using GifRecorder. The application will now terminate itself.", vbInformation, "Finished")
            Application.Exit()
        End Try
    End Sub
End Class
