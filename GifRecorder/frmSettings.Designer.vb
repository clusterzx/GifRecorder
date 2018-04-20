<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdChooseOutputFolder = New System.Windows.Forms.Button()
        Me.txtOutputPath = New System.Windows.Forms.TextBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.folderBrowser = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbQuality = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblQuality = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbEncoder = New System.Windows.Forms.ComboBox()
        Me.txtEncoderInfo = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdChooseOutputFolder)
        Me.GroupBox1.Controls.Add(Me.txtOutputPath)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(357, 51)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Output folder"
        '
        'cmdChooseOutputFolder
        '
        Me.cmdChooseOutputFolder.Location = New System.Drawing.Point(310, 19)
        Me.cmdChooseOutputFolder.Name = "cmdChooseOutputFolder"
        Me.cmdChooseOutputFolder.Size = New System.Drawing.Size(43, 20)
        Me.cmdChooseOutputFolder.TabIndex = 1
        Me.cmdChooseOutputFolder.Text = "..."
        Me.cmdChooseOutputFolder.UseVisualStyleBackColor = True
        '
        'txtOutputPath
        '
        Me.txtOutputPath.Location = New System.Drawing.Point(6, 19)
        Me.txtOutputPath.Name = "txtOutputPath"
        Me.txtOutputPath.Size = New System.Drawing.Size(298, 20)
        Me.txtOutputPath.TabIndex = 0
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(12, 271)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(357, 27)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "Save settings"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbQuality)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.lblQuality)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 67)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(357, 71)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Set quality (only for built in encoder)"
        '
        'cmbQuality
        '
        Me.cmbQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbQuality.FormattingEnabled = True
        Me.cmbQuality.Items.AddRange(New Object() {"Low", "Normal", "Good", "Best"})
        Me.cmbQuality.Location = New System.Drawing.Point(223, 21)
        Me.cmbQuality.Name = "cmbQuality"
        Me.cmbQuality.Size = New System.Drawing.Size(128, 21)
        Me.cmbQuality.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(253, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "The higher the quality, the longer it takes to encode."
        '
        'lblQuality
        '
        Me.lblQuality.AutoSize = True
        Me.lblQuality.Location = New System.Drawing.Point(6, 25)
        Me.lblQuality.Name = "lblQuality"
        Me.lblQuality.Size = New System.Drawing.Size(211, 13)
        Me.lblQuality.TabIndex = 1
        Me.lblQuality.Text = "You can select the quality of your GIF here."
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cmbEncoder)
        Me.GroupBox3.Controls.Add(Me.txtEncoderInfo)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 144)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(357, 121)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Endcoder"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Choose your prefered encoder here :"
        '
        'cmbEncoder
        '
        Me.cmbEncoder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEncoder.FormattingEnabled = True
        Me.cmbEncoder.Items.AddRange(New Object() {"Built in - v0.2", "ffmpeg - v3.4.2", "gifski -v0.8.2"})
        Me.cmbEncoder.Location = New System.Drawing.Point(213, 19)
        Me.cmbEncoder.Name = "cmbEncoder"
        Me.cmbEncoder.Size = New System.Drawing.Size(135, 21)
        Me.cmbEncoder.TabIndex = 1
        '
        'txtEncoderInfo
        '
        Me.txtEncoderInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEncoderInfo.Location = New System.Drawing.Point(9, 47)
        Me.txtEncoderInfo.Multiline = True
        Me.txtEncoderInfo.Name = "txtEncoderInfo"
        Me.txtEncoderInfo.ReadOnly = True
        Me.txtEncoderInfo.Size = New System.Drawing.Size(339, 68)
        Me.txtEncoderInfo.TabIndex = 0
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 303)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmdChooseOutputFolder As Button
    Friend WithEvents txtOutputPath As TextBox
    Friend WithEvents cmdSave As Button
    Friend WithEvents folderBrowser As FolderBrowserDialog
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbQuality As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblQuality As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtEncoderInfo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbEncoder As ComboBox
End Class
