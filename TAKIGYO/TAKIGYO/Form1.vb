Public Class Form1
    Dim canvas As New Bitmap(900, 700)
    Dim g As Graphics = Graphics.FromImage(canvas)
    Dim PW, PH As Long
    Dim Cpos As Point
    Dim enX(9), enY(9) As Long
    Dim rand As New Random
    Dim RR As Long
    Dim hitFlg As Boolean
    Dim ecnt, ex, ey As Long
    Dim msgcnt As Long
    Dim titleFlg As Boolean
    Dim score As Long
    Dim myFont As Font = New Font("Arial", 18)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pIwa.Hide()
        pPlayer.Hide()
        pTaki.Hide()
        pExp.Hide()
        pGameover.Hide()
        pMsg.Hide()
        pTAKIGYO.Hide()

        gameinit()
    End Sub

    Private Sub pBase_Click(sender As Object, e As EventArgs) Handles pBase.Click
        If titleFlg Then
            If msgcnt > 20 Then
                msgcnt = 0
                titleFlg = False
            End If
            Exit Sub
        End If
        If msgcnt > 100 Then
            gameinit()
        End If
    End Sub

    Private Sub playerExplosion()
        ecnt += 4
        If ecnt > 40 Then
            ecnt = 8
            ex = Cpos.X + rand.Next(40)
            ey = 320 + rand.Next(50)
        End If
        g.DrawImage(pTaki.Image, New Rectangle(0, 0, 900, 700))
        For i As Long = 0 To 9
            g.DrawImage(pIwa.Image, New Rectangle(enX(i), enY(i), RR * 2, RR * 2))
        Next
        g.DrawImage(pPlayer.Image, New Rectangle(Cpos.X, 320, PW, PH))
        g.DrawImage(pExp.Image, New Rectangle(ex - ecnt / 2, ey - ecnt / 2, ecnt, ecnt))
        msgcnt += 1
        If msgcnt > 60 Then
            g.DrawImage(pGameover.Image, New Rectangle(100, 110, 350, 60))
            If (msgcnt Mod 60) > 20 Then
                g.DrawImage(pMsg.Image, New Rectangle(140, 220, 271, 26))
            End If
        End If
        g.DrawString("SCORE:" & score.ToString(), myFont, Brushes.White, 10, 10)
        pBase.Image = canvas
    End Sub

    Private Sub titleDisp()
        msgcnt += 1
        g.DrawImage(pTaki.Image, New Rectangle(0, 0, 900, 700))
        g.DrawImage(pTAKIGYO.Image, New Rectangle(100, 120, 350, 60))
        If (msgcnt Mod 60) > 20 Then
            g.DrawImage(pMsg.Image, New Rectangle(140, 270, 271, 26))
        End If
        pBase.Image = canvas
    End Sub

    Private Sub gameinit()
        PW = 41
        PH = 51
        RR = 70 / 2
        For i As Long = 0 To 9
            enX(i) = rand.Next(1, 800)
            enY(i) = rand.Next(1, 900) - 1000
        Next
        hitFlg = False
        ecnt = 40
        msgcnt = 0
        titleFlg = True
        score = 0
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If titleFlg Then
            titleDisp()
            Exit Sub
        End If
        If hitFlg Then
            playerExplosion()
            Exit Sub
        End If
        g.DrawImage(pTaki.Image, New Rectangle(0, 0, 900, 700))

        For i As Long = 0 To 9
            enY(i) += 5
            g.DrawImage(pIwa.Image, New Rectangle(enX(i), enY(i), RR * 2, RR * 2))
            If enY(i) > pBase.Height Then
                enX(i) = rand.Next(1, 800)
                enY(i) = rand.Next(1, 300) - 400
            End If
        Next

        Cpos = PointToClient(Cursor.Position)
        If Cpos.X < 0 Then
            Cpos.X = 0
        End If
        If Cpos.X > Width - PW Then
            Cpos.X = Width - PW
        End If

        g.DrawImage(pPlayer.Image, New Rectangle(Cpos.X, 320, PW, PH))
        score += 1
        g.DrawString("SCORE:" & score.ToString(), myFont, Brushes.White, 10, 10)
        pBase.Image = canvas
        hitCheck()
    End Sub

    Private Sub hitCheck()
        Dim pcx As Long = Cpos.X + (PW / 2)
        Dim pcy As Long = 320 + (PH / 2)
        Dim ecx, ecy, dis As Long

        For i As Long = 0 To 9
            ecx = enX(i) + RR
            ecy = enY(i) + RR
            dis = (ecx - pcx) * (ecx - pcx) + (ecy - pcy) * (ecy - pcy)
            If dis < RR * RR Then
                hitFlg = True
                Exit For
            End If
        Next
    End Sub
End Class
