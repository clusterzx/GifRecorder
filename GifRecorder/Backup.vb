Module Backup
    Sub DoEncodingFFMPEG()
        Try

            Dim ffmpeg_path As String = My.Computer.FileSystem.CurrentDirectory & "\ffmpeg\ffmpeg.exe"
            Dim tempPath As String = My.Settings.outputpath & "\temp\"
            Dim outputFilePath As String = My.Settings.outputpath & "\output.gif"

            Dim encBin As New ProcessStartInfo
            encBin.FileName = ffmpeg_path
            encBin.UseShellExecute = True
            encBin.WindowStyle = ProcessWindowStyle.Hidden
            encBin.RedirectStandardOutput = True
            encBin.Arguments = "-framerate 25 -i " & tempPath & "%d.png -c:v libx264 -profile:v high -crf 20 -pix_fmt yuv420p -vf ""scale=trunc(iw/2)*2:trunc(ih/2)*2"" " & tempPath & "video.avi"
            Dim proc As Process = Process.Start(encBin)

            Dim sOutput As String
            Using oStreamReader As System.IO.StreamReader = proc.StandardOutput
                sOutput = oStreamReader.ReadToEnd()
            End Using
            frmMain.txtEncodingOutput.Text = sOutput

            While Process.GetProcessesByName("ffmpeg").Count > 0

            End While

            Dim encBinx As New ProcessStartInfo
            encBinx.FileName = ffmpeg_path
            encBinx.UseShellExecute = True
            encBinx.WindowStyle = ProcessWindowStyle.Hidden
            encBin.RedirectStandardOutput = True
            encBinx.Arguments = "-i " & tempPath & "video.avi -pix_fmt rgb24 -vf fps=25 " & tempPath & "output.gif"
            Dim procx As Process = Process.Start(encBinx)

            While Process.GetProcessesByName("ffmpeg").Count > 0

            End While

            IO.File.Move(tempPath & "output.gif", My.Settings.outputpath & "\output_" & DateTime.Now.ToString("dd-mm-yyyy-HH-mm") & ".gif")

            Dim di As New IO.DirectoryInfo(My.Settings.outputpath & "\temp")
            IO.File.Delete(My.Settings.outputpath & "\temp\Thumbs.db")
            IO.File.Delete(My.Settings.outputpath & "\Thumbs.db")



            System.Threading.Thread.Sleep(1000)

            IO.Directory.Delete(My.Settings.outputpath & "\temp", True)
            frmMain.panelTranspacrency.BackgroundImage = Nothing
            frmMain.panelTranspacrency.BackgroundImageLayout = ImageLayout.Stretch
            MsgBox("Your GIF file is now ready. It was saved to: " & My.Settings.outputpath & "\output.gif" & vbCrLf & "Thanks for using GifRecorder. The application will now terminate itself.", vbInformation, "Finished")
            Application.Exit()
        Catch ex As Exception
            MsgBox(ex.Message)
            System.Threading.Thread.Sleep(1000)
            frmMain.panelTranspacrency.BackgroundImage = Nothing
            frmMain.panelTranspacrency.BackgroundImageLayout = ImageLayout.Stretch
            MsgBox("Your GIF file is now ready. It was saved to: " & My.Settings.outputpath & "\output.gif" & vbCrLf & "Thanks for using GifRecorder. The application will now terminate itself.", vbInformation, "Finished")
            Application.Exit()
        End Try
    End Sub
End Module
