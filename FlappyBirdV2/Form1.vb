Public Class Form1
    Dim yspeed As Integer = 0
    Dim gravity As Integer = 2
    Dim pipe(1) As PictureBox
    Dim topPipe(1) As PictureBox
    Dim gapBetweenPipes As Integer = 460
    Dim pipeSpeed As Single = 3.5

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        Timer1.Enabled = True
        CreatePipes(1)
        CreateTopPipes(1)

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        yspeed += gravity
        bird.Top += yspeed
        For i = 0 To 1
            pipe(i).Left -= pipeSpeed
            topPipe(i).Left -= pipeSpeed
            If (Collision(pipe(i), bird) = True) Or (Collision(topPipe(i), bird) = True) Then
                Timer1.Enabled = False
                Dim resposta = MsgBox("Tem a certeza?", vbYesNo, "Novo Jogo")
                If resposta = vbNo Then Return
                Application.Restart()
            End If
            If pipe(i).Left < 0 Then
                pipe(i).Left += 400
                topPipe(i).Left += 400
                pipe(i).Top = 70 + 290 * Rnd()
                topPipe(i).Top = pipe(i).Top - gapBetweenPipes
            End If
        Next
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Space Then
            yspeed = -15

        End If
    End Sub

    Private Sub CreatePipes(ByVal Number As Integer)
        Dim i As Integer = 0
        For i = 0 To Number
            Dim temp As New PictureBox
            Me.Controls.Add(temp)
            temp.Width = 50
            temp.Height = 350
            temp.BorderStyle = BorderStyle.FixedSingle
            temp.BackColor = Color.Green
            temp.Top = 70 + 290 * Rnd()
            temp.Left = (i * 200) + 300
            pipe(i) = temp

            pipe(i).Visible = True
        Next
    End Sub

    Private Sub CreateTopPipes(ByVal Number As Integer)
        Dim i As Integer = 0
        For i = 0 To Number
            Dim temp As New PictureBox
            Me.Controls.Add(temp)
            temp.Width = 50
            temp.Height = 350
            temp.BorderStyle = BorderStyle.FixedSingle
            temp.BackColor = Color.Green
            temp.Top = pipe(i).Top - gapBetweenPipes
            temp.Left = (i * 200) + 300
            topPipe(i) = temp
            topPipe(i).Visible = True
        Next
    End Sub



    Private Function Collision(ByVal Object1 As Object, ByVal Object2 As Object) As Boolean
        Dim Collided As Boolean = False
        If Object1.Top + Object1.Height >= Object2.Top And
            Object2.Top + Object2.Height >= Object1.Top And
            Object1.Left + Object1.Width >= Object2.Left And
            Object2.Left + Object2.Width >= Object1.Left And Object1.visible = True And Object2.visible = True Then
            Collided = True
        End If
        Return Collided
    End Function
End Class
