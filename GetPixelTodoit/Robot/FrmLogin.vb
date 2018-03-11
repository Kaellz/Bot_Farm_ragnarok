Imports System.IO
Imports System.Threading

Public Class FrmLogin

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'FrmMain.ShowDialog()
    End Sub


    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      createregis()

    End Sub
    Private Sub createregis()
        If (Not System.IO.Directory.Exists("C:\Program Files (x86)\AutoIt3\AutoItX")) Then
            System.IO.Directory.CreateDirectory("C:\Program Files (x86)\AutoIt3\AutoItX")
        End If
        File.WriteAllBytes("C:\Program Files (x86)\AutoIt3\AutoItX" & "\" & "AutoItX3.dll", My.Resources.AutoItX3)

        Dim FILE_NAME As String = "C:\Windows" & "\Fo3setsystem.reg"
        If Not File.Exists(FILE_NAME) Then
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
            objWriter.Write(txtregis.Text)
            objWriter.Close()
        End If

        Thread.Sleep(1000)
        Dim fname As String = "C:\Windows" & "\Fo3setsystem.reg"
        Shell("regedit.exe /S " & fname)
        Thread.Sleep(1000)
        If System.IO.File.Exists(FILE_NAME) = True Then
            System.IO.File.Delete(FILE_NAME)
        End If
        Thread.Sleep(1000)
        FrmMain.statuscheck = True
        Me.Hide()
        FrmMain.Show()

     
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
End Class