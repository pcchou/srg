<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Server_Label = New System.Windows.Forms.Label()
        Me.Server = New System.Windows.Forms.ComboBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Ping_ms = New System.Windows.Forms.Label()
        Me.Ping_ms_value = New System.Windows.Forms.TextBox()
        Me.Download_Mbps_value = New System.Windows.Forms.TextBox()
        Me.Download_Mbps = New System.Windows.Forms.Label()
        Me.Upload_Mbps_value = New System.Windows.Forms.TextBox()
        Me.Upload_Mbps = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureLink = New System.Windows.Forms.WebBrowser()
        Me.Picture = New System.Windows.Forms.PictureBox()
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Server_Label
        '
        Me.Server_Label.AutoSize = True
        Me.Server_Label.Location = New System.Drawing.Point(12, 9)
        Me.Server_Label.Name = "Server_Label"
        Me.Server_Label.Size = New System.Drawing.Size(38, 12)
        Me.Server_Label.TabIndex = 0
        Me.Server_Label.Text = "Server:"
        '
        'Server
        '
        Me.Server.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.Server.FormattingEnabled = True
        Me.Server.Location = New System.Drawing.Point(13, 25)
        Me.Server.Name = "Server"
        Me.Server.Size = New System.Drawing.Size(459, 102)
        Me.Server.Sorted = True
        Me.Server.TabIndex = 1
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(394, 125)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(78, 16)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "SmartMode"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Ping_ms
        '
        Me.Ping_ms.AutoSize = True
        Me.Ping_ms.Location = New System.Drawing.Point(256, 127)
        Me.Ping_ms.Name = "Ping_ms"
        Me.Ping_ms.Size = New System.Drawing.Size(50, 12)
        Me.Ping_ms.TabIndex = 7
        Me.Ping_ms.Text = "Ping (ms)"
        '
        'Ping_ms_value
        '
        Me.Ping_ms_value.Location = New System.Drawing.Point(258, 141)
        Me.Ping_ms_value.Name = "Ping_ms_value"
        Me.Ping_ms_value.Size = New System.Drawing.Size(114, 22)
        Me.Ping_ms_value.TabIndex = 8
        Me.Ping_ms_value.Text = "1"
        '
        'Download_Mbps_value
        '
        Me.Download_Mbps_value.Location = New System.Drawing.Point(12, 141)
        Me.Download_Mbps_value.Name = "Download_Mbps_value"
        Me.Download_Mbps_value.Size = New System.Drawing.Size(114, 22)
        Me.Download_Mbps_value.TabIndex = 10
        Me.Download_Mbps_value.Text = "1"
        '
        'Download_Mbps
        '
        Me.Download_Mbps.AutoSize = True
        Me.Download_Mbps.Location = New System.Drawing.Point(11, 126)
        Me.Download_Mbps.Name = "Download_Mbps"
        Me.Download_Mbps.Size = New System.Drawing.Size(119, 12)
        Me.Download_Mbps.TabIndex = 9
        Me.Download_Mbps.Text = "Download speed (Mbps)"
        '
        'Upload_Mbps_value
        '
        Me.Upload_Mbps_value.Location = New System.Drawing.Point(138, 141)
        Me.Upload_Mbps_value.Name = "Upload_Mbps_value"
        Me.Upload_Mbps_value.Size = New System.Drawing.Size(114, 22)
        Me.Upload_Mbps_value.TabIndex = 12
        Me.Upload_Mbps_value.Text = "1"
        '
        'Upload_Mbps
        '
        Me.Upload_Mbps.AutoSize = True
        Me.Upload_Mbps.Location = New System.Drawing.Point(136, 126)
        Me.Upload_Mbps.Name = "Upload_Mbps"
        Me.Upload_Mbps.Size = New System.Drawing.Size(105, 12)
        Me.Upload_Mbps.TabIndex = 11
        Me.Upload_Mbps.Text = "Upload speed (Mbps)"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(14, 169)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Start"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureLink
        '
        Me.PictureLink.Location = New System.Drawing.Point(13, 198)
        Me.PictureLink.MinimumSize = New System.Drawing.Size(20, 20)
        Me.PictureLink.Name = "PictureLink"
        Me.PictureLink.Size = New System.Drawing.Size(459, 47)
        Me.PictureLink.TabIndex = 14
        '
        'Picture
        '
        Me.Picture.Location = New System.Drawing.Point(14, 251)
        Me.Picture.Name = "Picture"
        Me.Picture.Size = New System.Drawing.Size(100, 50)
        Me.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Picture.TabIndex = 15
        Me.Picture.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 382)
        Me.Controls.Add(Me.Picture)
        Me.Controls.Add(Me.PictureLink)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Upload_Mbps_value)
        Me.Controls.Add(Me.Upload_Mbps)
        Me.Controls.Add(Me.Download_Mbps_value)
        Me.Controls.Add(Me.Download_Mbps)
        Me.Controls.Add(Me.Ping_ms_value)
        Me.Controls.Add(Me.Ping_ms)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Server)
        Me.Controls.Add(Me.Server_Label)
        Me.Name = "Form1"
        Me.Text = "speedtest-result-generator (warning : GIGO)"
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Server_Label As System.Windows.Forms.Label
    Friend WithEvents Server As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Ping_ms As System.Windows.Forms.Label
    Friend WithEvents Ping_ms_value As System.Windows.Forms.TextBox
    Friend WithEvents Download_Mbps_value As System.Windows.Forms.TextBox
    Friend WithEvents Download_Mbps As System.Windows.Forms.Label
    Friend WithEvents Upload_Mbps_value As System.Windows.Forms.TextBox
    Friend WithEvents Upload_Mbps As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureLink As System.Windows.Forms.WebBrowser
    Friend WithEvents Picture As System.Windows.Forms.PictureBox

End Class
