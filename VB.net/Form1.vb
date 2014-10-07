Public Class Form1
    'VB.net version is made by x21999125x and speedtest-result-generator.php is reuploaded by x21999125x
    'Credits:
    'http://www.vbforums.com/showthread.php?387841-Display-image-from-internet-in-a-Picturebox
    'For that easy to use code.
    'https://github.com/YSITD/speedtest-result-generator/blob/master/php/srg.php
    'For main Picturegen work.
    Const url_php As String = "http://21tutorials.mzzhost.com/speedtest-result-generator.php"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim AllList As String() = System.IO.File.ReadAllLines("Server-List")
        For i = 0 To AllList.Length - 1
            Server.Items.Add(AllList(i))
        Next
        Server.Text = Server.Items.Item(0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not Server.Items.Contains(Server.Text) Then
            MsgBox("Error - Invalid server")
            Exit Sub
        End If
        If Val(Download_Mbps_value.Text) < 0 Or Val(Download_Mbps_value.Text) > 2000 Then
            MsgBox("Error - Invalid download speed value")
            Exit Sub
        End If
        If Val(Upload_Mbps_value.Text) < 0 Or Val(Upload_Mbps_value.Text) > 2000 Then
            MsgBox("Error - Invalid upload speed value")
            Exit Sub
        End If
        If Val(Ping_ms_value.Text) < 0 Or Val(Ping_ms_value.Text) > 2000 Then
            MsgBox("Error - Invalid Ping ms value")
            Exit Sub
        End If

        Dim server_value, DLspeed, UpSpeed As Integer
        Dim tmp As String()
        Dim mode As String
        DLspeed = Download_Mbps_value.Text * 1000
        UpSpeed = Upload_Mbps_value.Text * 1000
        tmp = Split(Server.Text, " ")
        server_value = tmp(1).Substring(0, tmp(1).Length - 1)
        If CheckBox1.Checked = True Then
            mode = "smart"
        Else
            mode = "normal"
        End If
        PictureLink.Navigate(url_php & "?dlkbps=" & DLspeed & "&ulkbps=" & UpSpeed & "&pingms=" & Ping_ms_value.Text & "&srv=" & server_value & "&mode=" & mode)
    End Sub

    Private Sub PictureLink_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles PictureLink.DocumentCompleted
        Picture.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(PictureLink.DocumentText)))
    End Sub
End Class
