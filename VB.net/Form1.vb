Imports System.Security.Cryptography
Imports System.Text

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form.CheckForIllegalCrossThreadCalls = False
        If Not My.Computer.FileSystem.FileExists("Server-List") Then
            MsgBox("Server-List not found.  Program closing...")
            End
        End If

        Dim AllList As String() = System.IO.File.ReadAllLines("Server-List")
        For i = 0 To AllList.Length - 1
            Server.Items.Add(AllList(i))
        Next
        Server.Text = Server.Items.Item(0)
    End Sub

    Private Sub ResultGen_DoWork(sender As Object, e As EventArgs) Handles ResultGen.DoWork

        Dim server_value, DLspeed, UpSpeed As Integer
        Dim tmp As String()
        DLspeed = Download_Mbps_value.Text * 1000
        UpSpeed = Upload_Mbps_value.Text * 1000
        tmp = Split(Server.Text, " ")
        If tmp(0) = "" Then
            server_value = tmp(1).Substring(0, tmp(1).Length - 1)
        Else
            server_value = tmp(0).Substring(0, tmp(0).Length - 1)
        End If
        If SmartMode.Checked = True Then
            Dim rand As Single
            Randomize()

            rand = ((Rnd() * 30) + 945) / 1000
            DLspeed *= rand

            rand = ((Rnd() * 30) + 945) / 1000
            UpSpeed *= rand
        End If
        Dim md5 As String = GetMd5Hash(Ping_ms_value.Text & "-" & UpSpeed & "-" & DLspeed & "-297aae72")
        Dim web As New System.Net.WebClient()
        web.Headers.Add("Content-Type", "application/x-www-form-urlencoded")
        web.Headers.Add("Referer", "http://c.speedtest.net/flash/speedtest.swf")
        Dim d As Byte() = System.Text.Encoding.UTF8.GetBytes("download=" & DLspeed & "&ping=" & Ping_ms_value.Text & "&upload=" & UpSpeed & "&promo=&startmode=pingselect&recommendedserverid=" & server_value & "&accuracy=1&serverid=" & server_value & "&hash=" & md5)
        Dim res As Byte() = web.UploadData("http://www.speedtest.net/api/api.php", "POST", d)
        Dim response As String = System.Text.Encoding.UTF8.GetString(res)

        Dim resultid As String = Split(Split(response, "&")(0), "=")(1)
        ResultLink.Text = "Result : http://www.speedtest.net/my-result/" & resultid & vbCrLf & "Picture : http://www.speedtest.net/result/" & resultid & ".png"
        Picture.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData("http://www.speedtest.net/result/" & resultid & ".png")))
        Button1.Enabled = True
    End Sub

    Shared Function GetMd5Hash(ByVal input As String) As String
        '參考自MSDN  https://msdn.microsoft.com/zh-tw/library/system.security.cryptography.md5.aspx

        Dim md5Hash As MD5 = MD5.Create
        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return sBuilder.ToString()

    End Function 'GetMd5Hash

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
        Button1.Enabled = False
        ResultGen.RunWorkerAsync()
    End Sub
End Class
