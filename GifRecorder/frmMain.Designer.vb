<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.panelTranspacrency = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.RecordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopRecordingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateGIFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrWork = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelTranspacrency
        '
        Me.panelTranspacrency.BackColor = System.Drawing.Color.Magenta
        Me.panelTranspacrency.Location = New System.Drawing.Point(8, 27)
        Me.panelTranspacrency.Name = "panelTranspacrency"
        Me.panelTranspacrency.Size = New System.Drawing.Size(781, 554)
        Me.panelTranspacrency.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RecordToolStripMenuItem, Me.StopRecordingToolStripMenuItem, Me.CreateGIFToolStripMenuItem, Me.SettingsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(798, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'RecordToolStripMenuItem
        '
        Me.RecordToolStripMenuItem.Name = "RecordToolStripMenuItem"
        Me.RecordToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.RecordToolStripMenuItem.Text = "Record"
        '
        'StopRecordingToolStripMenuItem
        '
        Me.StopRecordingToolStripMenuItem.Enabled = False
        Me.StopRecordingToolStripMenuItem.Name = "StopRecordingToolStripMenuItem"
        Me.StopRecordingToolStripMenuItem.Size = New System.Drawing.Size(97, 20)
        Me.StopRecordingToolStripMenuItem.Text = "Stop recording"
        '
        'CreateGIFToolStripMenuItem
        '
        Me.CreateGIFToolStripMenuItem.Enabled = False
        Me.CreateGIFToolStripMenuItem.Name = "CreateGIFToolStripMenuItem"
        Me.CreateGIFToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.CreateGIFToolStripMenuItem.Text = "Create GIF"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'tmrWork
        '
        Me.tmrWork.Interval = 30
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 588)
        Me.Controls.Add(Me.panelTranspacrency)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GifRecorder"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Magenta
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panelTranspacrency As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents RecordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tmrWork As Timer
    Friend WithEvents StopRecordingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreateGIFToolStripMenuItem As ToolStripMenuItem
End Class
