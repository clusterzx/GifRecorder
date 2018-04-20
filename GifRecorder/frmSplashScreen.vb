Public Class frmSplashScreen
    Dim count
    Private Sub tmrStart_Tick(sender As Object, e As EventArgs) Handles tmrStart.Tick
        count += 1
        Me.Opacity += 0.1
        If count = 10 Then
            System.Threading.Thread.Sleep(1500)
            frmMain.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub frmSplashScreen_Load(sender As Object, e As EventArgs) Handles Me.Load
        tmrStart.Enabled = True
        tmrStart.Start()
    End Sub
End Class