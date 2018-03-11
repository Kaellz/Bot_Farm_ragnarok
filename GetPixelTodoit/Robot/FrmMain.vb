Imports System.IO
Imports AutoItX3Lib
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Text

Public Class FrmMain
    Public statuscheck As String = False
    Dim AutoitCommand As New AutoItX3
    Dim bgwork As Boolean = True
    Declare Sub mouse_event Lib "user32.dll" Alias "mouse_event" (ByVal dwFlags As Int32, ByVal dx As Int32, ByVal dy As Int32, ByVal cButtons As Int32, ByVal dwExtraInfo As Int32) '''mouseclick
    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Long) As Integer ''hotkeys
    Public Enum WMeaasge As Integer
        WM_LBUTTONDOWN = &H201
        WM_LBUTTONUP = &H202
        WM_LBUTTONDBCLICK = &H203
        WM_RBUTTONDOWN = &H204
        WM_RBUTTONUP = &H205
        WM_RBUTTONDBCLICK = &H206
    End Enum
    '<DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=False, ExactSpelling:=True)> _
    'Private Shared Function WindowFromPoint(xPoint As Integer, yPoint As Integer) As IntPtr
    'End Function
    Declare Function WindowFromPoint Lib "user32" (ByVal xPoint As Integer, ByVal yPoint As Integer) As Integer
    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function FindWindowEx(parentHandle As IntPtr, childAfter As IntPtr, classname As String, windowstitle As IntPtr) As IntPtr
    End Function
    '<DllImport("user32.dll", SetLastError:=True)> _
    'Private Shared Function FindWindow(className As String, sAppName As String) As IntPtr
    'End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=False)> _
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As IntPtr
    End Function
    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function PostMessage(hWnd As IntPtr, Msg As UInteger, wParam As Integer, lParam As Integer) As Boolean
    End Function
    <DllImport("user32.dll", ExactSpelling:=True)> _
    Public Shared Function SetActiveWindow(hWnd As IntPtr) As Integer
    End Function
    <DllImport("user32.dll")> _
    Public Shared Function SetForegroundWindow(hWnd As IntPtr) As Integer
    End Function
    <DllImport("user32.dll")> _
    Public Shared Function GetForegroundWindow() As IntPtr
    End Function
    <DllImport("user32.dll")> _
    Public Shared Function GetWindowText(hWnd As IntPtr, lpstring As StringBuilder, nMaxCount As Integer) As IntPtr
    End Function
    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.ExitThread()
    End Sub
    Private Sub timecheckhotkey_Tick(sender As Object, e As EventArgs)
        If GetAsyncKeyState(Keys.F1) Then
            btnstart.PerformClick() ''start

        End If
        If GetAsyncKeyState(Keys.F2) Then
            Application.ExitThread()
        End If

    End Sub

    Private Sub workit_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles workit.RunWorkerCompleted
        If bgwork = False Then
            workit.CancelAsync()

            btnstart.Enabled = True

        End If
        If bgwork = True Then
            workit.RunWorkerAsync()

            btnstart.Enabled = False

        End If
    End Sub


    Public color As Integer
    Public color1 As Integer
   
    Public xx, yy As Integer
    Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    Private Declare Function GetWindowRect Lib "user32" Alias "GetWindowRect" (ByVal hwnd As Integer, ByVal lpRect As RECT) As Integer


    Public Function WindowHandle(ByVal sTitle As String) As Long
        WindowHandle = FindWindow(vbNullString, sTitle)
    End Function


    <DllImport("user32.dll")> _
    Private Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef rect As Rectangle) As Boolean
    End Function

    Dim programx As String
    Dim programy As String
    Dim programwith As String
    Dim programyhight As String
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


    End Sub
    Private Sub getposition()
        Dim windowname As String = "Ragnarok"
        Dim ParenthWnd As New IntPtr(0)

        ParenthWnd = WindowHandle(windowname)

        Dim theprogramrectangle As System.Drawing.Rectangle

        GetWindowRect(ParenthWnd, theprogramrectangle)

        programx = theprogramrectangle.X
        programy = theprogramrectangle.Y
        programwith = theprogramrectangle.Width
        programyhight = theprogramrectangle.Height

        'MsgBox("x = " & programx & _
        'vbCrLf & "Y = " & programy & _
        'vbCrLf & "Left = " & programwith & _
        'vbCrLf & "Right = " & programyhight)

    End Sub

    Private Sub เดินลงล่าง()
        Windows.Forms.Cursor.Position = New System.Drawing.Point(programwith / 2 + 50, (programyhight / 2) + 250)
        AutoitCommand.MouseClick("left")
        AutoitCommand.Send("{LEFT}")
        AutoitCommand.Send("{DOWN}")
        AutoitCommand.MouseDown("LEFT")
        AutoitCommand.Sleep(200)
    End Sub
    Private Sub เดินขึ้นบน()
        Windows.Forms.Cursor.Position = New System.Drawing.Point(programwith / 2 + 50, (programyhight / 2) - 250)
        AutoitCommand.MouseClick("left")
        AutoitCommand.Send("{LEFT}")
        AutoitCommand.Send("{DOWN}")
        AutoitCommand.MouseDown("LEFT")
        AutoitCommand.Sleep(200)
    End Sub
    Private Sub เดินขวา()
        Windows.Forms.Cursor.Position = New System.Drawing.Point(programwith / 2 + 250, programyhight / 2)
        AutoitCommand.MouseClick("left")
        AutoitCommand.Send("{LEFT}")
        AutoitCommand.Send("{DOWN}")
        AutoitCommand.MouseDown("LEFT")
        AutoitCommand.Sleep(200)
    End Sub
    Private Sub เดินซ้าย()
        Windows.Forms.Cursor.Position = New System.Drawing.Point(programwith / 2 - 250, programyhight / 2)
        AutoitCommand.MouseClick("left")
        AutoitCommand.Send("{LEFT}")
        AutoitCommand.Send("{DOWN}")
        AutoitCommand.MouseDown("LEFT")
        AutoitCommand.Sleep(200)
    End Sub
    Function randoเดิน()
        getposition()
        Dim pointrandom As Integer = GetRandom(1, 5)
        If pointrandom = 1 Then
            เดินลงล่าง()

        End If
        If pointrandom = 2 Then
            เดินขึ้นบน()

        End If
        If pointrandom = 3 Then
            เดินขวา()

        End If
        If pointrandom = 4 Then
            เดินซ้าย()

        End If
    End Function
    Function randoค้นหา()
        getposition()
        Dim pointrandom As Integer = GetRandom(1, 5)
        If pointrandom = 1 Then ''ซ้ายไปขวา บนล่าง
            Try
                Dim Getpos As Array = AutoitCommand.PixelSearch(programx, programy, programwith, programyhight, color, 5, 1)
                d1 = Now.ToString
                Windows.Forms.Cursor.Position = New System.Drawing.Point(Getpos(0), Getpos(1))
                AutoitCommand.MouseClick("left")
                AutoitCommand.Send("{LEFT}")
                AutoitCommand.Send("{DOWN}")
                AutoitCommand.Send("{LEFT}")
                AutoitCommand.Send("{DOWN}")

            Catch ex As Exception

            End Try

        End If

        If pointrandom = 2 Then
            Try
                Dim Getpos As Array = AutoitCommand.PixelSearch(programwith, programy, programx, programyhight, color, 5, 1)

                d1 = Now.ToString
                Windows.Forms.Cursor.Position = New System.Drawing.Point(Getpos(0), Getpos(1)) ''เปลี่ยนจาก ขวา ไปซ้าย บนลงล่า
                AutoitCommand.MouseClick("left")
                AutoitCommand.Send("{LEFT}")
                AutoitCommand.Send("{DOWN}")
                AutoitCommand.Send("{LEFT}")
                AutoitCommand.Send("{DOWN}")

            Catch ex As Exception

            End Try



        End If
        If pointrandom = 3 Then
            Try
                Dim Getpos As Array = AutoitCommand.PixelSearch(programx, programyhight, programwith, programy, color, 5, 1)

                d1 = Now.ToString
                Windows.Forms.Cursor.Position = New System.Drawing.Point(Getpos(0), Getpos(1)) 'เปลี่ยนจาก ล่างขึ้นบน ซ้ายไปขวา
                AutoitCommand.MouseClick("left")
                AutoitCommand.Send("{LEFT}")
                AutoitCommand.Send("{DOWN}")
                AutoitCommand.Send("{LEFT}")
                AutoitCommand.Send("{DOWN}")

            Catch ex As Exception

            End Try


        End If
        If pointrandom = 4 Then
            Try
                Dim Getpos As Array = AutoitCommand.PixelSearch(programwith, programyhight, programx, programy, color, 5, 1)

                d1 = Now.ToString
                Windows.Forms.Cursor.Position = New System.Drawing.Point(Getpos(0), Getpos(1)) 'เปลี่ยนจาก ล่างขึ้นบน ขวาไปซ้าย
                AutoitCommand.MouseClick("left")
                AutoitCommand.Send("{LEFT}")
                AutoitCommand.Send("{DOWN}")
                AutoitCommand.Send("{LEFT}")
                AutoitCommand.Send("{DOWN}")

            Catch ex As Exception

            End Try


        End If
    End Function
    Sub เก็บของ()
        Try
            Dim Getpos As Array = AutoitCommand.PixelSearch(programwith, programyhight, programx, programy, color1, 5, 1)

            d1 = Now.ToString
            Windows.Forms.Cursor.Position = New System.Drawing.Point(Getpos(0), Getpos(1)) 'เปลี่ยนจาก ล่างขึ้นบน ขวาไปซ้าย
            AutoitCommand.MouseClick("left")
            AutoitCommand.Send("{LEFT}")
            AutoitCommand.Send("{DOWN}")
            AutoitCommand.Send("{LEFT}")
            AutoitCommand.Send("{DOWN}")

        Catch ex As Exception

        End Try

    End Sub
    Private Sub workit_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles workit.DoWork

        getposition()
        AutoitCommand.WinActivate("Ragnarok")
        Do


            randoค้นหา()

            If CInt(Label3.Text) > 3 Then
                Try
                    randoเดิน()
                    AutoitCommand.ControlSend("", "", "", "{F8}")
                    d1 = Now.ToString
                Catch ex As Exception

                End Try
            End If


        Loop
    End Sub

    Private Sub btnstart_Click(sender As Object, e As EventArgs) Handles btnstart.Click
        workit.RunWorkerAsync()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'AutoitCommand.AutoItSetOption("MouseCoordMode", 2)
        'AutoitCommand.AutoItSetOption("PixelCoordMode", 2)
        'AutoitCommand.AutoItSetOption("CaretCoordMode", 2)
        x.Text = AutoitCommand.MouseGetPosX()
        y.Text = AutoitCommand.MouseGetPosY()

        'Label1.Text = AutoitCommand.WinGetPosX("[active]")
        'Label2.Text = AutoitCommand.WinGetPosY("[active]")
        'กว้าง.Text = AutoitCommand.WinGetPosWidth("[active]")
        'ยาว.Text = AutoitCommand.WinGetPosHeight("[active]")


        Label1.Text = AutoitCommand.MouseGetPosX()
        Label2.Text = AutoitCommand.MouseGetPosY()
        กว้าง.Text = AutoitCommand.WinGetPosWidth("[active]")
        ยาว.Text = AutoitCommand.WinGetPosHeight("[active]")

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If GetAsyncKeyState(Keys.Z) Then
            xx = AutoitCommand.MouseGetPosX()
            yy = AutoitCommand.MouseGetPosY()
            color = AutoitCommand.PixelGetColor(xx, yy)

            MsgBox("สีคือ " & color)
        End If

        If GetAsyncKeyState(Keys.F2) Then
            Application.ExitThread()
        End If



    End Sub



    Private Sub v_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

    End Sub
    Dim d1 As Date = Now.ToString
    Dim d2 As Date

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Dim d2 As Date = Now.ToString
        Label3.Text = DateDiff(DateInterval.Second, d1, d2)
    End Sub



End Class

