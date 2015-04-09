Imports System.IO
Imports System.Security.Cryptography

Public Class frmMain

    Friend WithEvents b As System.Windows.Forms.Button
    Private NewGameStarted As Boolean = False
    Private MiddleMouseButtonIsPressed As Boolean = False
    Private ShiftIsPressed As Boolean = False
    Private MiddleMouse_row As Integer = -1
    Private MiddleMouse_col As Integer = -1
    Friend nbMines As Integer = 10
    Friend sizeX As Integer = 10
    Friend sizeY As Integer = 10
    Friend GameType As eGameType = eGameType.Easy
    Friend GameStatus As eGameStatus = eGameStatus.Init
    Private mines(,) As Integer
    Private numbers(,) As Integer
    Private time As Integer = 0
    Private score As Integer = 0
    Private scoreTimeBonusLimit As Integer = 50
    Private remainingMines As Integer = nbMines
    Private lvl1 As Boolean = False
    Private lvl2 As Boolean = False
    Private lvl3 As Boolean = False
    Private lvl4 As Boolean = False
    Private lvl5 As Boolean = False
    Private lvl6 As Boolean = False
    Private lvl7 As Boolean = False
    Private lvl8 As Boolean = False
    Private Wrapfield As Boolean = False
    Private NoNumbers As Boolean = False
    Private NoFlags As Boolean = False
    Private nbHint As Integer = 0
    Private isUsingHit As Boolean = False

    Friend Enum eGameType
        Easy = 1
        Medium = 2
        Hard = 3
        Custom = 4
        God = 5
    End Enum

    Friend Enum eGameStatus
        Won = 1
        Lost = 2
        Unfinished = 3
        Init = 4
    End Enum

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If GameStatus = eGameStatus.Unfinished Then
            My.Settings.SettingNbGameUnfinished += 1
            My.Settings.Save()
        End If
    End Sub


    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'NoNumbers = True
        'NoFlags = True
        'Wrapfield = True

        'on détermine les récompenses à activer
        LoadLevels()
        NewGame(sizeX, sizeY, nbMines)


    End Sub


    Private Function Combinations(ByVal characters As ArrayList, ByVal length As Integer) As ArrayList
        Dim res As ArrayList = New ArrayList()

        For i As Integer = 0 To characters.Count - 1
            If length = 1 Then
                res.Add(characters(i))
            Else
                For Each nextaze As String In Combinations(characters.GetRange(i + 1, characters.Count - (i + 1)), length - 1)
                    res.Add(characters(i).ToString() & " " & nextaze)
                Next
            End If
        Next
        Return res
    End Function


    Private Sub LoadLevels()

        Dim nb As Double
        Dim nb1 As UInt64
        Dim nb2 As UInt16

        'les masques des 8 niveaux
        Dim bin() As UInt16 = { _
Convert.ToUInt16("1111111101111111", 2), _
Convert.ToUInt16("1011111110111111", 2), _
Convert.ToUInt16("1101111111011111", 2), _
Convert.ToUInt16("1110111111101111", 2), _
Convert.ToUInt16("1111011111110111", 2), _
Convert.ToUInt16("1111101111111011", 2), _
Convert.ToUInt16("1111110111111101", 2), _
Convert.ToUInt16("1111111011111111", 2) _
}

        Dim l As New ArrayList()
        l.Add("1") : l.Add("2") : l.Add("3") : l.Add("4") : l.Add("5") : l.Add("6") : l.Add("7") : l.Add("8")

        Dim i As Integer
        Dim nb3 As Integer = l.Count
        Dim tokens() As String
        Dim flags As New ArrayList

        Dim flag As UInt16

        For i = 1 To nb3
            Dim res As ArrayList = Combinations(l, i)
            For Each s As String In res

                tokens = Split(s.ToString(), " ")
                flag = Convert.ToUInt16("1111111111111111", 2)
                For Each token As String In tokens
                    flag = flag And bin(Convert.ToInt32(Val(token)) - 1)
                Next

                flags.Add(flag)
            Next
        Next

        Dim valid() As UInt16 = CType(flags.ToArray(GetType(UInt16)), UInt16())
        Dim ok As Boolean = False

        nb1 = My.Settings.SettingMisc
        nb = nb1 / (My.Settings.SettingNbGamePlayed + 1)
        If Math.Truncate(nb) = nb Then

            nb2 = Convert.ToUInt16(nb)

            For Each bt As UInt16 In valid
                If bt = nb2 Then
                    ok = True
                    Exit For
                End If
            Next

            If ok Then
                nb2 = Not nb2

                lvl1 = (nb2 And Not bin(0)) = (Not bin(0))
                lvl2 = (nb2 And Not bin(1)) = (Not bin(1))
                lvl3 = (nb2 And Not bin(2)) = (Not bin(2))
                lvl4 = (nb2 And Not bin(3)) = (Not bin(3))
                lvl5 = (nb2 And Not bin(4)) = (Not bin(4))
                lvl6 = (nb2 And Not bin(5)) = (Not bin(5))
                lvl7 = (nb2 And Not bin(6)) = (Not bin(6))
                lvl8 = (nb2 And Not bin(7)) = (Not bin(7))

            End If
        End If
    End Sub

    Private Sub UpdateLevels()
        Dim nb As UInt16 = Convert.ToUInt16("1111111111111111", 2)
        Dim nb1 As UInt64
        'les masques des 8 niveaux
        Dim bin() As UInt16 = { _
Convert.ToUInt16("1111111101111111", 2), _
Convert.ToUInt16("1011111110111111", 2), _
Convert.ToUInt16("1101111111011111", 2), _
Convert.ToUInt16("1110111111101111", 2), _
Convert.ToUInt16("1111011111110111", 2), _
Convert.ToUInt16("1111101111111011", 2), _
Convert.ToUInt16("1111110111111101", 2), _
Convert.ToUInt16("1111111011111111", 2) _
}

        If lvl1 Then
            nb = Convert.ToUInt16((nb And bin(0)))
        End If
        If lvl2 Then
            nb = Convert.ToUInt16((nb And bin(1)))
        End If
        If lvl3 Then
            nb = Convert.ToUInt16((nb And bin(2)))
        End If
        If lvl4 Then
            nb = Convert.ToUInt16((nb And bin(3)))
        End If
        If lvl5 Then
            nb = Convert.ToUInt16((nb And bin(4)))
        End If
        If lvl6 Then
            nb = Convert.ToUInt16((nb And bin(5)))
        End If
        If lvl7 Then
            nb = Convert.ToUInt16((nb And bin(6)))
        End If
        If lvl8 Then
            nb = Convert.ToUInt16((nb And bin(7)))
        End If


        nb1 = Convert.ToUInt64(nb * (My.Settings.SettingNbGamePlayed + 1))

        My.Settings.SettingMisc = nb1

    End Sub


    Friend Sub NewGame(ByVal largeur As Integer, ByVal hauteur As Integer, ByVal nbmines As Integer)

        Dim w As Integer = btn_0_0.Width
        Dim h As Integer = btn_0_0.Height
        Dim s As Integer = 1 'espace vide entre 2 mines
        Dim i As Integer
        Dim j As Integer
        Dim btns((largeur * hauteur) - 1) As Button

        If GameStatus = eGameStatus.Unfinished Then
            My.Settings.SettingNbGameUnfinished += 1
            My.Settings.Save()
        End If
        Me.GameStatus = eGameStatus.Init

        Me.MinimumSize = New Size(1, 1)
        Me.MaximumSize = New Size(10000, 10000)
        Me.Width = (largeur * w) + ((largeur + 1) * s) + 34
        Me.Height = (hauteur * h) + ((hauteur + 1) * s) + 158
        Me.MinimumSize = New Size(Me.Width, Me.Height)
        Me.MaximumSize = New Size(Me.Width, Me.Height)
        Me.CenterToScreen()

        Me.Panel2.Enabled = True
        mainTimer.Stop()

        'on supprime tous les boutons éventuellement créés auparavant.
        Try
            Me.Panel2.Hide()
            For i = 1 To largeur
                For j = 1 To hauteur
                    If i <> 1 Or j <> 1 Then
                        Me.Panel2.Controls.RemoveByKey("btn_" & (i - 1).ToString() & "_" & (j - 1).ToString())
                    End If
                Next
            Next
        Catch ex As Exception

        End Try

        'on clone tous les boutons
        'Me.Panel2.Hide()
        'Me.Refresh()
        'Application.DoEvents()

        For i = 1 To largeur
            For j = 1 To hauteur

                If i <> 1 Or j <> 1 Then
                    b = New Button()



                    b.Name = "btn_" & (i - 1).ToString() & "_" & (j - 1).ToString()
                    b.BackColor = System.Drawing.Color.Silver
                    b.FlatAppearance.BorderColor = System.Drawing.Color.Gray
                    b.FlatStyle = System.Windows.Forms.FlatStyle.Standard
                    b.Location = New System.Drawing.Point((w * (i - 1)) + (s * i), (h * (j - 1)) + (s * j))
                    b.Size = New System.Drawing.Size(w, h)
                    b.TabIndex = 0
                    b.UseVisualStyleBackColor = False
                    b.BringToFront()
                    b.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    AddHandler b.MouseDown, AddressOf btn_Mine_MouseDown
                    AddHandler b.MouseClick, AddressOf btn_Mine_MouseClick
                    AddHandler b.MouseUp, AddressOf frmMain_MouseUp
                    AddHandler b.MouseMove, AddressOf frmMain_MouseMove


                    btns((i - 1) + ((j - 1) * sizeX)) = b

                End If
            Next
        Next

        Me.Panel2.SuspendLayout()
        Me.Panel2.Controls.AddRange(btns)
        Me.Panel2.Show()
        Me.Panel2.ResumeLayout()
        Application.DoEvents()
        'Me.Panel2.Refresh()



        btn_0_0.Text = ""
        btn_0_0.ForeColor = Color.Black
        btn_0_0.BackColor = Color.Silver
        btn_0_0.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        btn_0_0.FlatStyle = FlatStyle.Standard

        time = 0
        score = 0
        remainingMines = nbmines

        If lvl2 Then
            nbHint = 1
        End If
        If lvl3 Then
            nbHint = 5
        End If
        If lvl8 Then
            nbHint = Integer.MaxValue
        End If

        lblMines.Text = remainingMines.ToString().PadLeft(3, Convert.ToChar("0"))
        lblTime.Text = time.ToString().PadLeft(3, Convert.ToChar("0"))
        LblScore.Text = "Score : " & score

        NewGameStarted = True



    End Sub

    Private Sub InitMines(ByVal clickedRow As Integer, ByVal clickedCol As Integer, Optional ByVal generate As Boolean = True)
        Dim nb1 As Integer
        Dim nb2 As Integer
        Dim i As Integer
        Dim ok As Boolean

        Randomize()

        NewGameStarted = False

        GameStatus = eGameStatus.Unfinished


        If generate = True Then
            ReDim mines(sizeX - 1, sizeY - 1)
            Array.Clear(mines, 0, mines.Length)
            ReDim numbers(sizeX - 1, sizeY - 1)
            Array.Clear(numbers, 0, numbers.Length)

            For i = 1 To nbMines
                ok = False
                While Not ok
                    nb1 = CInt(Int(sizeX - 1) * Rnd())
                    nb2 = CInt(Int(sizeY - 1) * Rnd())

                    If (nb1 <> clickedCol Or nb2 <> clickedRow) And mines(nb1, nb2) <> 1 Then

                        'set the mine to 1. 0 means no mine, 1 means there's a mine
                        mines(nb1, nb2) = 1

                        'we compute the intersection numbers of the mines

                        If Wrapfield = False Then

                            'if left side is visible
                            If nb1 > 0 Then
                                numbers(nb1 - 1, nb2) += 1
                                If nb2 > 0 Then
                                    numbers(nb1 - 1, nb2 - 1) += 1
                                End If
                                If nb2 < sizeY - 1 Then
                                    numbers(nb1 - 1, nb2 + 1) += 1
                                End If
                            End If

                            'if right side is visible
                            If nb1 < sizeX - 1 Then
                                numbers(nb1 + 1, nb2) += 1
                                If nb2 > 0 Then
                                    numbers(nb1 + 1, nb2 - 1) += 1
                                End If
                                If nb2 < sizeY - 1 Then
                                    numbers(nb1 + 1, nb2 + 1) += 1
                                End If
                            End If

                            'if top side is visible
                            If nb2 > 0 Then
                                numbers(nb1, nb2 - 1) += 1
                            End If

                            'if down side is visible
                            If nb2 < sizeY - 1 Then
                                numbers(nb1, nb2 + 1) += 1
                            End If

                        Else 'WRAPFIELD mode. Serious things begin !

                            'if left side is visible
                            If nb1 > 0 Then
                                numbers(nb1 - 1, nb2) += 1
                                If nb2 > 0 Then
                                    numbers(nb1 - 1, nb2 - 1) += 1
                                Else 'we report mines to the opposite side
                                    numbers(nb1 - 1, sizeY - 1) += 1
                                End If
                                If nb2 < sizeY - 1 Then
                                    numbers(nb1 - 1, nb2 + 1) += 1
                                Else 'we report mines to the opposite side
                                    numbers(nb1 - 1, 0) += 1
                                End If
                            Else 'we report mines to the opposite side
                                numbers(sizeX - 1, nb2) += 1
                                If nb2 > 0 Then
                                    numbers(sizeX - 1, nb2 - 1) += 1
                                Else 'we report mines to the opposite side
                                    numbers(sizeX - 1, sizeY - 1) += 1
                                End If
                                If nb2 < sizeY - 1 Then
                                    numbers(sizeX - 1, nb2 + 1) += 1
                                Else 'we report mines to the opposite side
                                    numbers(sizeX - 1, 0) += 1
                                End If
                            End If

                            'if right side is visible
                            If nb1 < sizeX - 1 Then
                                numbers(nb1 + 1, nb2) += 1
                                If nb2 > 0 Then
                                    numbers(nb1 + 1, nb2 - 1) += 1
                                Else 'we report mines to the opposite side
                                    numbers(nb1 + 1, sizeY - 1) += 1
                                End If
                                If nb2 < sizeY - 1 Then
                                    numbers(nb1 + 1, nb2 + 1) += 1
                                Else 'we report mines to the opposite side
                                    numbers(nb1 + 1, 0) += 1
                                End If
                            Else
                                numbers(0, nb2) += 1
                                If nb2 > 0 Then
                                    numbers(0, nb2 - 1) += 1
                                Else 'we report mines to the opposite side
                                    numbers(0, sizeY - 1) += 1
                                End If
                                If nb2 < sizeY - 1 Then
                                    numbers(0, nb2 + 1) += 1
                                Else 'we report mines to the opposite side
                                    numbers(0, 0) += 1
                                End If
                            End If

                            'if top side is visible
                            If nb2 > 0 Then
                                numbers(nb1, nb2 - 1) += 1
                            Else 'we report mines to the opposite side
                                numbers(nb1, sizeY - 1) += 1
                            End If

                            'if down side is visible
                            If nb2 < sizeY - 1 Then
                                numbers(nb1, nb2 + 1) += 1
                            Else 'we report mines to the opposite side
                                numbers(nb1, 0) += 1
                            End If

                        End If

                        ok = True
                    End If

                End While
            Next

            ''to debug
            'mines = New Integer(,) _
            '{ _
            '    {1, 0, 0, 0, 0, 0, 0, 0, 0, 0}, _
            '    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, _
            '    {1, 0, 0, 0, 0, 0, 0, 0, 0, 0}, _
            '    {0, 0, 0, 0, 0, 0, 0, 1, 0, 0}, _
            '    {1, 0, 0, 0, 0, 0, 0, 0, 0, 0}, _
            '    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, _
            '    {1, 0, 0, 0, 1, 0, 0, 0, 0, 1}, _
            '    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, _
            '    {1, 0, 0, 0, 0, 0, 0, 0, 0, 0}, _
            '    {0, 0, 0, 1, 0, 0, 0, 1, 0, 0} _
            '}

            'numbers = New Integer(,) _
            '{ _
            '    {0, 1, 0, 0, 0, 0, 0, 0, 0, 0}, _
            '    {2, 2, 0, 0, 0, 0, 0, 0, 0, 0}, _
            '    {0, 1, 0, 0, 0, 0, 1, 1, 1, 0}, _
            '    {2, 2, 0, 0, 0, 0, 1, 0, 1, 0}, _
            '    {0, 1, 0, 0, 0, 0, 1, 1, 1, 0}, _
            '    {2, 2, 0, 1, 1, 1, 0, 0, 1, 1}, _
            '    {0, 1, 0, 1, 0, 1, 0, 0, 1, 0}, _
            '    {2, 2, 0, 1, 1, 1, 0, 0, 1, 1}, _
            '    {0, 1, 1, 1, 1, 0, 1, 1, 1, 0}, _
            '    {1, 1, 1, 0, 1, 0, 1, 0, 1, 0} _
            '}

        End If

        My.Settings.SettingNbGamePlayed += 1
        UpdateLevels()

        My.Settings.Save()

        mainTimer.Start()

    End Sub

    Private Sub ClearArroundMine(ByVal row As Integer, ByVal col As Integer, Optional ByVal recursive As Boolean = True)
        Dim ctrl As Control
        Dim btn As Button

        'we make sure to process valid button
        If row < 0 Or row >= sizeX Or col < 0 Or col >= sizeX Then
            Exit Sub
        End If

        ctrl = Me.Panel2.Controls("btn_" & col.ToString() & "_" & row.ToString())
        btn = DirectCast(ctrl, Button)


        If btn.BackColor = Color.White Then
            'on est déjà passé par là
            Exit Sub
        End If

        If btn.Text = "¤" Then
            'interdiction de déminer cette case
            Exit Sub
        End If

        btn.BackColor = Color.White
        btn.FlatStyle = FlatStyle.Flat
        score += 5

        If numbers(col, row) > 0 Then

            If NoNumbers = True Then
                btn.Text = "0"
            Else
                btn.Text = numbers(col, row).ToString()
            End If

            score += numbers(col, row)

            LblScore.Text = "Score : " & score

            If NoNumbers = True Then
                btn.ForeColor = Color.Black
            Else
                Select Case numbers(col, row)
                    Case 1
                        btn.ForeColor = Color.Blue
                    Case 2
                        btn.ForeColor = Color.DarkGreen
                    Case 3
                        btn.ForeColor = Color.Red
                    Case 4
                        btn.ForeColor = Color.DodgerBlue
                    Case 5
                        btn.ForeColor = Color.DarkViolet
                    Case 6
                        btn.ForeColor = Color.DarkSlateBlue
                    Case 7
                        btn.ForeColor = Color.Fuchsia
                    Case 8
                        btn.ForeColor = Color.Gray
                    Case Is > 8
                        btn.ForeColor = Color.Black
                End Select
            End If
            'pas la peine d'aller plus loin
            Exit Sub
        Else
            btn.Text = "" 'pour les éventuels "?"
        End If

        If recursive = True Then
            'if left side is visible
            If col > 0 Then
                ClearArroundMine(row, col - 1)
                If row > 0 Then

                    ClearArroundMine(row - 1, col - 1)

                End If
                If row < sizeY - 1 Then

                    ClearArroundMine(row + 1, col - 1)

                End If
            End If

            'if right side is visible
            If col < sizeX - 1 Then
                ClearArroundMine(row, col + 1)
                If row > 0 Then

                    ClearArroundMine(row - 1, col + 1)

                End If
                If row < sizeY - 1 Then

                    ClearArroundMine(row + 1, col + 1)

                End If
            End If

            'if top side is visible
            If row > 0 Then
                ClearArroundMine(row - 1, col)
            End If

            'if down side is visible
            If row < sizeY - 1 Then
                ClearArroundMine(row + 1, col)
            End If
        End If
    End Sub

    Private Sub Loose(ByVal row As Integer, ByVal col As Integer)
        Dim ctrl As Control
        Dim btn As Button
        Dim i As Integer
        Dim j As Integer

        GameStatus = eGameStatus.Lost

        For i = 1 To sizeX
            For j = 1 To sizeY
                If mines(i - 1, j - 1) = 1 Then
                    ctrl = Me.Panel2.Controls("btn_" & (i - 1).ToString() & "_" & (j - 1).ToString())
                    btn = DirectCast(ctrl, Button)
                    btn.ForeColor = Color.Red
                    btn.Text = "#"
                    If i - 1 = col And j - 1 = row Then
                        btn.BackColor = Color.Red
                    End If
                End If
            Next
        Next

        Panel2.Refresh()

        Panel2.Enabled = False
        mainTimer.Stop()



        My.Settings.SettingNbGameLost += 1
        My.Settings.Save()

        MsgBox("Boom !", MsgBoxStyle.Critical, "Booh!")
    End Sub

    Private Sub Win()
        Dim finalscore As Integer
        Dim timebonus As Integer
        Dim markbonus As Integer
        Dim f As frmNewHighScore
        Dim mul As Integer
        Panel2.Enabled = False
        mainTimer.Stop()
        GameStatus = eGameStatus.Won

        'we compute the score
        Select Case GameType
            Case eGameType.Easy
                mul = 1
            Case eGameType.Medium
                mul = 2
            Case eGameType.Hard
                mul = 3
            Case eGameType.God
                mul = 4
            Case eGameType.Custom
                mul = 1
            Case Else
                mul = 1
        End Select
        If NoFlags Then
            mul += 1
        End If
        If NoNumbers Then
            mul += 1
        End If
        If Wrapfield Then
            mul += 1
        End If


        If time >= scoreTimeBonusLimit Then
            timebonus = 0
        Else
            Select Case (scoreTimeBonusLimit - time) / scoreTimeBonusLimit
                Case Is < 0.2
                    mul = 1 * mul
                Case Is < 0.4
                    mul = 2 * mul
                Case Is < 0.6
                    mul = 3 * mul
                Case Is < 0.8
                    mul = 4 * mul
                Case Is <= 1
                    mul = 5 * mul
            End Select
            timebonus = Convert.ToInt32((scoreTimeBonusLimit - time) / scoreTimeBonusLimit * mul * score)
        End If

        Try
            markbonus = Convert.ToInt32((1 - (1 / (nbMines - remainingMines))) * score)
        Catch ex As Exception
            markbonus = 0
        End Try
        If remainingMines > nbMines Then
            markbonus = 0
        End If

        finalscore = score + timebonus + markbonus
        LblScore.Text = "Score : " & finalscore

        My.Settings.SettingNbGameWon += 1

        MsgBox("You win !" & vbNewLine & vbNewLine & _
               "Score : " & score & vbNewLine & _
               "Time bonus : " & timebonus & vbNewLine & _
               "Mark bonus : " & markbonus & vbNewLine & _
               "Final score : " & finalscore, MsgBoxStyle.Information, "Congratulations !")

        Select Case GameType
            Case eGameType.Easy

                If time < 15 And lvl1 = False Then
                    lvl1 = True
                    MsgBox("You are awarded with Level 1 !" & vbNewLine & "You can now disable the numbers !")
                    UpdateLevels()
                End If
                If time < 10 And NoNumbers = True And lvl3 = False Then
                    lvl3 = True
                    MsgBox("You are awarded with Level 3 !" & vbNewLine & "You can now load/save your games !")
                    UpdateLevels()
                End If
                If time < My.Settings.SettingHSEasyBestTime Or finalscore > My.Settings.SettingHSEasyBestScore Then
                    f = New frmNewHighScore(time, finalscore)
                    f.Show()
                End If

            Case eGameType.Medium

                If time < 200 And lvl2 = False Then
                    lvl2 = True
                    MsgBox("You are awarded with Level 2 !" & vbNewLine & "You can now disable flags !")
                    UpdateLevels()
                End If
                If time < 100 And lvl4 = False Then
                    lvl4 = True
                    MsgBox("You are awarded with Level 4 !" & vbNewLine & "You can now use ONE (1) hint to find wether the specified box contains a mine !")
                    UpdateLevels()
                End If
                If time < My.Settings.SettingHSMediumBestTime Or finalscore > My.Settings.SettingHSMediumBestScore Then
                    f = New frmNewHighScore(time, finalscore)
                    f.Show()
                End If

            Case eGameType.Hard
                If time < 200 And lvl5 = False Then
                    lvl5 = True
                    MsgBox("You are awarded with Level 5 !" & vbNewLine & "You can now use FIVE (5) hints to find wether the specified box contains a mine !")
                    UpdateLevels()
                End If
                If time < My.Settings.SettingHSHardBestTime Or finalscore > My.Settings.SettingHSHardBestScore Then
                    f = New frmNewHighScore(time, finalscore)
                    f.Show()
                End If

            Case eGameType.God
                If time < 300 And lvl7 = False Then
                    lvl7 = True
                    MsgBox("What a genius ! You are awarded with Level 7 !" & vbNewLine & "You can now play in Wrapfield mode !")
                    UpdateLevels()
                End If
                If lvl8 = False And Wrapfield = True And NoNumbers = True And NoFlags = True Then
                    lvl8 = True
                    MsgBox("Unbelievable ! You are awarded with Level 8 !" & vbNewLine & "You can now enjoy INFINITE hints to find wether the specified box contains a mine !")
                    UpdateLevels()
                End If
                If time < My.Settings.SettingHSGodBestTime Or finalscore > My.Settings.SettingHSGodBestScore Then
                    f = New frmNewHighScore(time, finalscore)
                    f.Show()
                End If

        End Select

        If (My.Settings.SettingHSEasyBestTime + My.Settings.SettingHSMediumBestTime + My.Settings.SettingHSHardBestTime) < 200 And lvl6 = False Then
            lvl6 = True
            MsgBox("Oh my god ! You are awarded with Level 6 !" & vbNewLine & "You can now play in God mode !")
            UpdateLevels()
        End If

        My.Settings.Save()



    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        NewGame(sizeX, sizeY, nbMines)
    End Sub

    Private Sub EasyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EasyToolStripMenuItem.Click
        sizeX = 10
        sizeY = 10
        nbMines = 10
        scoreTimeBonusLimit = 50

        GameType = eGameType.Easy

        NewGame(sizeX, sizeY, nbMines)
    End Sub

    Private Sub MediumToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MediumToolStripMenuItem.Click
        sizeX = 16
        sizeY = 16
        nbMines = 40
        scoreTimeBonusLimit = 200

        GameType = eGameType.Medium

        NewGame(sizeX, sizeY, nbMines)
    End Sub

    Private Sub HardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HardToolStripMenuItem.Click
        sizeX = 30
        sizeY = 16
        nbMines = 99
        scoreTimeBonusLimit = 500

        GameType = eGameType.Hard

        NewGame(sizeX, sizeY, nbMines)
    End Sub

    Private Sub GodToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GodToolStripMenuItem.Click

        If lvl4 Then
            sizeX = 30
            sizeY = 16
            nbMines = 199
            scoreTimeBonusLimit = 1000

            GameType = eGameType.God

            NewGame(sizeX, sizeY, nbMines)
        Else
            MsgBox("You can't play the God game unless you're a god at playing GabMine !" & vbNewLine & _
            "To enable the God game, the sum of your best times in Easy, Medium and Hard games must be less than 200 seconds." & vbNewLine & _
            "Good luck !", MsgBoxStyle.Information, "You're not a god")
        End If
    End Sub

    Private Sub mainTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainTimer.Tick
        time += 1
        lblTime.Text = time.ToString().PadLeft(3, Convert.ToChar("0"))
    End Sub

    'Left button only (MouseClick does not take right and middle mouse buttons, I don't know why)
    Private Function btn_Mine_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs, Optional ByVal humanplay As Boolean = True) As Integer Handles btn_0_0.MouseClick
        Dim btn As Button
        Dim row As Integer
        Dim col As Integer
        Dim name As String
        Dim sep() As Char = {CChar("_")}
        Dim res() As String
        Dim win As Boolean = True
        Dim ctrl As Control
        Dim i As Integer
        Dim j As Integer
        Dim ret As Integer = 0

        btn = DirectCast(sender, Button)
        'we determine the line and row
        name = btn.Name
        res = name.Split(New Char() {CChar("_")})
        col = Convert.ToInt32(res(1))
        row = Convert.ToInt32(res(2))

        If e.Button = Windows.Forms.MouseButtons.Left Then

            If isUsingHit Then
                isUsingHit = False
                If NewGameStarted = False Then
                    nbHint -= 1
                    If mines(col, row) = 1 Then
                        MsgBox("There IS a mine here !" & vbNewLine & "You still have " & nbHint & " hints to use.", MsgBoxStyle.Critical, "Hint")
                    Else
                        MsgBox("There is NO mine here !" & vbNewLine & "You still have " & nbHint & " hints to use.", MsgBoxStyle.Information, "Hint")
                    End If
                End If
                Exit Function
            End If

            If NewGameStarted = True Then
                InitMines(row, col, humanplay = True)
            End If



            If btn.Text = "¤" Then
                'on protège l'emplacement d'un clic malencontreux
                Exit Function
            End If

            If mines(col, row) = 1 Then
                Me.Loose(row, col)
                ret = 1
            Else

                Me.ClearArroundMine(row, col, humanplay = True)

                For i = 1 To sizeX
                    For j = 1 To sizeY
                        ctrl = Me.Panel2.Controls("btn_" & (i - 1).ToString() & "_" & (j - 1).ToString())
                        btn = DirectCast(ctrl, Button)
                        If mines(i - 1, j - 1) = 0 And btn.BackColor = Color.Silver Then
                            win = False
                        End If
                    Next
                Next

                If win = True Then
                    Me.Win()
                    ret = 2
                End If

            End If

            Array.Clear(sep, 0, sep.Length)
            Array.Clear(res, 0, res.Length)

        End If
        Return ret
    End Function

    'For right and middle buttons (only way to make it work)
    Private Function btn_Mine_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs, Optional ByVal humanplay As Boolean = True) As Integer Handles btn_0_0.MouseDown

        Dim btn As Button
        Dim row As Integer
        Dim col As Integer
        Dim name As String
        Dim sep() As Char = {CChar("_")}
        Dim res() As String
        Dim win As Boolean = True
        'Dim ctrl As Control
        'Dim i As Integer
        'Dim j As Integer
        Dim ret As Integer = 0

        btn = DirectCast(sender, Button)
        'we determine the line and row
        name = btn.Name
        res = name.Split(New Char() {CChar("_")})
        col = Convert.ToInt32(res(1))
        row = Convert.ToInt32(res(2))

        'If e.Button = Windows.Forms.MouseButtons.Left Then

        '    If isUsingHit Then
        '        isUsingHit = False
        '        If NewGameStarted = False Then
        '            nbHint -= 1
        '            If mines(col, row) = 1 Then
        '                MsgBox("There IS a mine here !" & vbNewLine & "You still have " & nbHint & " hints to use.", MsgBoxStyle.Critical, "Hint")
        '            Else
        '                MsgBox("There is NO mine here !" & vbNewLine & "You still have " & nbHint & " hints to use.", MsgBoxStyle.Information, "Hint")
        '            End If
        '        End If
        '        Exit Function
        '    End If

        '    If NewGameStarted = True Then
        '        InitMines(row, col, humanplay = True)
        '    End If



        '    If btn.Text = "¤" Then
        '        'on protège l'emplacement d'un clic malencontreux
        '        Exit Function
        '    End If

        '    If mines(col, row) = 1 Then
        '        Me.Loose(row, col)
        '        ret = 1
        '    Else

        '        Me.ClearArroundMine(row, col, humanplay = True)

        '        For i = 1 To sizeX
        '            For j = 1 To sizeY
        '                ctrl = Me.Panel2.Controls("btn_" & (i - 1).ToString() & "_" & (j - 1).ToString())
        '                btn = DirectCast(ctrl, Button)
        '                If mines(i - 1, j - 1) = 0 And btn.BackColor = Color.Silver Then
        '                    win = False
        '                End If
        '            Next
        '        Next

        '        If win = True Then
        '            Me.Win()
        '            ret = 2
        '        End If

        '    End If

        '    Array.Clear(sep, 0, sep.Length)
        '    Array.Clear(res, 0, res.Length)




        'right click
        'ElseIf e.Button = Windows.Forms.MouseButtons.Right And NoFlags = False Then

        If e.Button = Windows.Forms.MouseButtons.Right And NoFlags = False Then
            If btn.BackColor = Color.Silver Then
                Select Case btn.Text

                    Case ""
                        btn.Text = "¤"
                        btn.ForeColor = Color.Red
                        remainingMines -= 1
                        If remainingMines >= 0 Then
                            lblMines.Text = remainingMines.ToString().PadLeft(3, Convert.ToChar("0"))
                        Else
                            lblMines.Text = "-" & Math.Abs(remainingMines).ToString().PadLeft(3, Convert.ToChar("0"))
                        End If

                    Case "¤"
                        btn.Text = "?"
                        btn.ForeColor = Color.DarkGreen
                        remainingMines += 1
                        If remainingMines >= 0 Then
                            lblMines.Text = remainingMines.ToString().PadLeft(3, Convert.ToChar("0"))
                        Else
                            lblMines.Text = "-" & Math.Abs(remainingMines).ToString().PadLeft(3, Convert.ToChar("0"))
                        End If
                    Case "?"
                        btn.Text = ""
                        btn.ForeColor = Color.Black
                    Case Else

                End Select
            End If

            'middle click
        ElseIf e.Button = Windows.Forms.MouseButtons.Middle Then 'Or (e.Button = Windows.Forms.MouseButtons.Left And (Control.ModifierKeys And Keys.Shift) = Keys.Shift) Then

            MiddleMouseButtonIsPressed = True
            Oula(col, row)

        End If


        Return ret
    End Function

    Private Sub frmMain_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp, btn_0_0.MouseUp
        Dim btn As Button
        Dim ctrl As Control
        Dim row As Integer
        Dim col As Integer
        Dim name As String
        Dim res() As String
        Dim ev As MouseEventArgs
        Dim i As Integer
        Dim j As Integer
        Dim cntMines As Integer = 0
        Dim cntMistakes As Integer = 0
        Dim valret As Integer

        If MiddleMouseButtonIsPressed Then



            ctrl = Me.Panel2.GetChildAtPoint(Me.Panel2.PointToClient(Control.MousePosition), GetChildAtPointSkip.None)

            If ctrl IsNot Nothing Then
                If TypeOf ctrl Is Button Then
                    btn = DirectCast(ctrl, Button)
                    'we determine the line and row
                    name = btn.Name
                    res = name.Split(New Char() {CChar("_")})
                    col = Convert.ToInt32(res(1))
                    row = Convert.ToInt32(res(2))

                    MiddleMouseButtonIsPressed = False
                    Oula(col, row, True)


                    MiddleMouse_col = -1
                    MiddleMouse_row = -1

                    'if we release the middle mouse button on a number, it's valid
                    If btn.BackColor = Color.White And btn.Text <> "" Then

                        'we count if we are able to discover the mines or if there is a mistake
                        For i = -1 To 1
                            For j = -1 To 1
                                If i <> 0 Or j <> 0 Then
                                    Try
                                        ctrl = Me.Panel2.Controls("btn_" & (col + i).ToString() & "_" & (row + j).ToString())
                                        btn = DirectCast(ctrl, Button)
                                        If btn.BackColor = Color.Silver And btn.Text <> "¤" And mines(col + i, row + j) > 0 Then

                                            'we forget to mark that mine.
                                            cntMines += 1

                                        ElseIf btn.BackColor = Color.Silver And btn.Text = "¤" And mines(col + i, row + j) = 0 Then

                                            'we do a mistake, bad mark
                                            cntMistakes += 1

                                        End If

                                    Catch ex As Exception

                                    End Try

                                End If
                            Next
                        Next

                        'we allow to clear the buttons only if we found all the mines or if we do some mistakes in our marks
                        If cntMines = 0 Or cntMistakes > 0 Then

                            For i = -1 To 1
                                For j = -1 To 1
                                    If i <> 0 Or j <> 0 Then
                                        Try
                                            ctrl = Me.Panel2.Controls("btn_" & (col + i).ToString() & "_" & (row + j).ToString())
                                            btn = DirectCast(ctrl, Button)
                                            If btn.BackColor <> Color.White Or btn.Text <> "¤" Then
                                                ev = New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, e.X, e.Y, e.Delta)
                                                valret = btn_Mine_MouseClick(btn, ev)
                                                If valret > 0 Then
                                                    'we already lost or won. We quit.
                                                    Exit Sub
                                                End If
                                            End If
                                        Catch ex As Exception

                                        End Try

                                    End If
                                Next
                            Next
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub CustomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomToolStripMenuItem.Click
        Dim f As frmCustom = New frmCustom()
        f.ShowDialog()

    End Sub

    Private Sub NewGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewGameToolStripMenuItem.Click
        NewGame(sizeX, sizeY, nbMines)
    End Sub

    Private Sub HighScoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HighScoresToolStripMenuItem.Click
        Dim f As frmHighScores = New frmHighScores()
        f.Show()
    End Sub

    Private Sub AboutGabMineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutGabMineToolStripMenuItem.Click
        MsgBox("GabMine " & Application.ProductVersion & vbNewLine & "Copyleft GabSoftware 2001-2010")
    End Sub


    Private Sub frmMain_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, btn_0_0.MouseMove
        Dim ctrl As Control
        Dim res() As String
        Dim col As Integer
        Dim row As Integer

        ctrl = Me.Panel2.GetChildAtPoint(Me.Panel2.PointToClient(Control.MousePosition), GetChildAtPointSkip.None)

        If ctrl IsNot Nothing Then

            'Label1.Text = ctrl.Name & " at (" & e.Location.X.ToString() & ", " & e.Location.Y.ToString() & ")"

            If TypeOf ctrl Is Button Then

                If MiddleMouseButtonIsPressed Then

                    'we determine the line and row
                    res = ctrl.Name.Split(New Char() {CChar("_")})
                    col = Convert.ToInt32(res(1))
                    row = Convert.ToInt32(res(2))

                    If e.Button = Windows.Forms.MouseButtons.None Then
                        Oula(col, row, True)
                    Else
                        Oula(col, row)
                    End If


                End If

            End If

            'Else
            'Label1.Text = "Nothing at (" & e.Location.X.ToString() & ", " & e.Location.Y.ToString() & ")"
        End If
    End Sub

    Private Sub Oula(ByVal col As Integer, ByVal row As Integer, Optional ByVal resetOnly As Boolean = False)
        Dim i As Integer
        Dim j As Integer
        Dim ctrl As Control
        Dim btn As Button

        If col <> Me.MiddleMouse_col Or row <> Me.MiddleMouse_row Or resetOnly = True Then
            'TODO : on réinitialise l'état des boutons de l'ancienne position
            For i = -1 To 1
                For j = -1 To 1

                    Try
                        ctrl = Me.Panel2.Controls("btn_" & (MiddleMouse_col + i).ToString() & "_" & (MiddleMouse_row + j).ToString())
                        btn = DirectCast(ctrl, Button)
                        If btn.BackColor = Color.SteelBlue Then
                            btn.FlatStyle = FlatStyle.Standard
                            btn.BackColor = Color.Silver
                        End If
                    Catch ex As Exception

                    End Try

                Next
            Next

        Else
            'On ne fait rien
            Exit Sub

        End If

        'On met les témoins à jour
        Me.MiddleMouse_row = row
        Me.MiddleMouse_col = col

        If resetOnly = True Then
            Exit Sub
        End If


        For i = -1 To 1
            For j = -1 To 1
                Try
                    ctrl = Me.Panel2.Controls("btn_" & (col + i).ToString() & "_" & (row + j).ToString())
                    btn = DirectCast(ctrl, Button)
                    If btn.BackColor = Color.Silver And btn.Text <> "¤" Then
                        btn.FlatStyle = FlatStyle.Flat
                        btn.BackColor = Color.SteelBlue
                    End If
                Catch ex As Exception

                End Try
            Next
        Next





    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub SaveGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveGameToolStripMenuItem.Click

        If lvl3 Then
            If GameStatus = eGameStatus.Unfinished Then
                SaveGameAs()
            End If
        Else
            MsgBox("You must finish the Easy game in less than 10 seconds and without numbers to enable Load/Save functionnality !", MsgBoxStyle.Information, "Ha ha ! You're funny !")
        End If

    End Sub

    Private Sub SaveGameAs()
        Dim dr As DialogResult
        Dim filename As String

        dr = Me.SaveGameDlg.ShowDialog()
        If dr = Windows.Forms.DialogResult.OK Then
            filename = SaveGameDlg.FileName
            SaveGame(filename)
        End If


    End Sub

    Private Sub SaveGame(ByVal targetFile As String)
        Dim header(15) As Byte
        Dim theMines((sizeX * sizeY) - 1) As Byte
        Dim theNumbers(theMines.Length - 1) As Byte
        Dim theButtons(theMines.Length - 1) As Byte
        Dim buffer(12 + (theMines.Length * 3) - 1) As Byte
        Dim finalbuffer() As Byte
        Dim entropy() As Byte = {98, 8, 186, 4, 9, 65, 15, 49, 9, 78, 12, 65, 70, 24, 98, 121}
        Dim i As Integer
        Dim j As Integer
        Dim c As Control
        Dim b As Button

        '
        ' Header
        '

        'début : 4 bytes
        header(0) = &H0
        header(1) = &HFF
        header(2) = &HF
        header(3) = &HF0

        'largeur : 1 byte, valeur max : 70
        header(4) = Convert.ToByte(sizeX)

        'hauteur : 1 byte, valeur max : 35
        header(5) = Convert.ToByte(sizeY)

        'nombre de mines : 2 bytes, valeur max : 1225
        header(6) = Convert.ToByte(ExtractFromUINT32(Convert.ToUInt32(nbMines), 8, 0))
        header(7) = Convert.ToByte(ExtractFromUINT32(Convert.ToUInt32(nbMines), 8, 8))

        'time : 4 bytes, valeur max : 0xFFFF FFFF
        header(8) = Convert.ToByte(ExtractFromUINT32(Convert.ToUInt32(time), 8, 0))
        header(9) = Convert.ToByte(ExtractFromUINT32(Convert.ToUInt32(time), 8, 8))
        header(10) = Convert.ToByte(ExtractFromUINT32(Convert.ToUInt32(time), 8, 16))
        header(11) = Convert.ToByte(ExtractFromUINT32(Convert.ToUInt32(time), 8, 24))

        'score : 3 bytes, valeur max : 16777215 soit 0x00FF FFFF
        header(12) = Convert.ToByte(ExtractFromUINT32(Convert.ToUInt32(score), 8, 0))
        header(13) = Convert.ToByte(ExtractFromUINT32(Convert.ToUInt32(score), 8, 8))
        header(14) = Convert.ToByte(ExtractFromUINT32(Convert.ToUInt32(score), 8, 16))

        'game type : 1 byte
        header(15) = Convert.ToByte(GameType)


        '
        ' Mines
        '
        For i = 0 To sizeX - 1
            For j = 0 To sizeY - 1
                theMines(j * sizeX + i) = Convert.ToByte(mines(i, j))
            Next
        Next


        '
        ' Numbers
        '
        For i = 0 To sizeX - 1
            For j = 0 To sizeY - 1
                theNumbers(j * sizeX + i) = Convert.ToByte(numbers(i, j))
            Next
        Next


        '
        ' Buttons : 0=Pas cliqué, 1=?, 2=¤, 3=cliqué
        '
        For i = 0 To sizeX - 1
            For j = 0 To sizeY - 1
                c = Me.Panel2.Controls("btn_" & i.ToString() & "_" & j.ToString())
                b = DirectCast(c, Button)

                If b.BackColor = Color.Silver And b.Text = "" Then 'pas cliqué
                    theButtons(j * sizeX + i) = 0
                ElseIf b.BackColor = Color.Silver And b.Text = "?" Then '?
                    theButtons(j * sizeX + i) = 1
                ElseIf b.BackColor = Color.Silver And b.Text = "¤" Then '¤
                    theButtons(j * sizeX + i) = 2
                Else 'cliqué
                    theButtons(j * sizeX + i) = 3
                End If
            Next
        Next




        '
        ' On copie les 3 tables dans un buffer
        '
        'header.CopyTo(buffer, 3)
        Array.Copy(header, 4, buffer, 0, 12)
        theMines.CopyTo(buffer, 12)
        theNumbers.CopyTo(buffer, 12 + theMines.Length)
        theButtons.CopyTo(buffer, 12 + theMines.Length + theNumbers.Length)

        '
        ' On encode le buffer pour éviter la triche
        '
        buffer = ProtectedData.Protect(buffer, entropy, DataProtectionScope.LocalMachine)
        ReDim finalbuffer(4 + buffer.Length - 1)

        '
        ' On ajoute la signature
        '
        'header.CopyTo(finalbuffer, 4)
        Array.Copy(header, finalbuffer, 4)
        buffer.CopyTo(finalbuffer, 4)

        System.IO.File.WriteAllBytes(targetFile, finalbuffer)


    End Sub

    Private Function ExtractFromUINT32(ByVal n As UInt32, ByVal sizeOfChunk As UInt32, ByVal offset As UInt32) As UInt32
        Dim res As UInt32
        Dim mask As UInt32

        mask = CType(((Math.Pow(2, sizeOfChunk) - 1) * Math.Pow(2, offset)), UInt32)

        res = CType(((n And mask) / Math.Pow(2, offset)), UInt32)

        Return res
    End Function


    Private Sub LoadGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadGameToolStripMenuItem.Click
        Dim dr As DialogResult

        If lvl3 Then

            dr = LoadGameDlg.ShowDialog()
            If dr = Windows.Forms.DialogResult.OK Then
                LoadGame(LoadGameDlg.FileName)
            End If
        Else
            MsgBox("You must finish the Easy game in less than 10 seconds without numbers to enable Load/Save functionnality !", MsgBoxStyle.Information, "Ha ha ! Are you kidding ?")
        End If
    End Sub

    Private Sub LoadGame(ByVal sourceFile As String)

        Dim header(15) As Byte
        Dim theMines() As Byte = {}
        Dim theNumbers() As Byte = {}
        Dim theButtons() As Byte = {}
        Dim buffer() As Byte
        Dim unprotectedbuffer() As Byte
        Dim entropy() As Byte = {98, 8, 186, 4, 9, 65, 15, 49, 9, 78, 12, 65, 70, 24, 98, 121}
        Dim largeur As Integer
        Dim hauteur As Integer
        Dim nombredemines As Integer
        Dim temps As Integer
        Dim typedejeu As Integer
        Dim lescore As Integer
        Dim wegotanerror As Boolean = False

        'on lit le contenu de tout le fichier
        buffer = File.ReadAllBytes(sourceFile)

        'on teste la signature du fichier pour vérifier vite fait si c'est un fichier de GabMine
        If buffer(0) = &H0 And buffer(1) = &HFF And buffer(2) = &HF And buffer(3) = &HF0 Then

            Try
                'on copie la signature. Ca sert à rien, mais c'est classe.
                Array.Copy(buffer, 0, header, 0, 4)

                'on redimensionne le buffer à la bonne taille
                ReDim unprotectedbuffer(buffer.Length - 4 - 1)

                'on copie dans unprotectedbuffer le contenu de buffer sans la signature
                Array.Copy(buffer, 4, unprotectedbuffer, 0, buffer.Length - 4)

                'on décode unprotectedbuffer
                unprotectedbuffer = ProtectedData.Unprotect(unprotectedbuffer, entropy, DataProtectionScope.LocalMachine)

                'on extrait le header
                Array.Copy(unprotectedbuffer, 0, header, 4, 12)

                'on charge les valeurs du header
                largeur = header(4)
                hauteur = header(5)
                nombredemines = header(6) + (header(7) * &H100)
                temps = header(8) + (header(9) * &H100) + (header(10) * &H10000) + (header(11) * &H1000000)
                lescore = header(12) + (header(13) * &H100) + (header(14) * &H10000)
                typedejeu = header(15)

                'on prépare les 3 tableaux de données (mines, nombres et boutons)
                ReDim theMines((largeur * hauteur) - 1)
                ReDim theNumbers(theMines.Length - 1)
                ReDim theButtons(theMines.Length - 1)

                'on copie les données des mines
                Array.Copy(unprotectedbuffer, 12, theMines, 0, theMines.Length)

                'on copie les données des nombres
                Array.Copy(unprotectedbuffer, 12 + theMines.Length, theNumbers, 0, theNumbers.Length)

                'on copie les données des boutons
                Array.Copy(unprotectedbuffer, 12 + theMines.Length + theNumbers.Length, theButtons, 0, theButtons.Length)


            Catch ex As Exception

                MsgBox("There was en error during game loading :" & vbNewLine & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & ex.TargetSite.Name)
                wegotanerror = True

            Finally

                If wegotanerror = False Then
                    'tout s'est bien passé on dirait bien. On va donc charger le jeu !
                    LoadGameWithParams(largeur, hauteur, nombredemines, temps, lescore, typedejeu, theMines, theNumbers, theButtons)
                End If

            End Try

        Else
            MsgBox("Invalid file format !", MsgBoxStyle.Critical, "Error")
        End If

    End Sub

    Private Sub LoadGameWithParams(ByVal largeur As Integer, ByVal hauteur As Integer, ByVal nombremines As Integer, ByVal temps As Integer, ByVal cescore As Integer, ByVal typejeu As Integer, ByVal theMines() As Byte, ByVal theNumbers() As Byte, ByVal theButtons() As Byte)
        Dim i As Integer
        Dim j As Integer
        Dim c As Control
        Dim b As Button
        Dim m As MouseEventArgs

        sizeX = largeur
        sizeY = hauteur
        nbMines = nombremines
        GameType = CType(typejeu, eGameType)

        ReDim mines(sizeX - 1, sizeY - 1)
        Array.Clear(mines, 0, mines.Length)
        ReDim numbers(sizeX - 1, sizeY - 1)
        Array.Clear(numbers, 0, numbers.Length)

        NewGame(sizeX, sizeY, nbMines)

        For i = 0 To sizeX - 1
            For j = 0 To sizeY - 1
                mines(i, j) = theMines(i + (largeur * j))
                numbers(i, j) = theNumbers(i + (largeur * j))
            Next
        Next

        For i = 0 To sizeX - 1
            For j = 0 To sizeY - 1

                c = Me.Panel2.Controls("btn_" & i.ToString() & "_" & j.ToString())
                b = DirectCast(c, Button)

                Select Case theButtons(i + (largeur * j))

                    Case 0 'rien

                    Case 1 '?
                        m = New MouseEventArgs(Windows.Forms.MouseButtons.Right, 1, b.Left + CInt(b.Width / 2), b.Top + CInt(b.Height / 2), 0)
                        btn_Mine_MouseDown(b, m, False)
                        m = New MouseEventArgs(Windows.Forms.MouseButtons.Right, 1, b.Left + CInt(b.Width / 2), b.Top + CInt(b.Height / 2), 0)
                        btn_Mine_MouseDown(b, m, False)

                    Case 2 '¤
                        m = New MouseEventArgs(Windows.Forms.MouseButtons.Right, 1, b.Left + CInt(b.Width / 2), b.Top + CInt(b.Height / 2), 0)
                        btn_Mine_MouseDown(b, m, False)

                    Case 3 'cliqué
                        m = New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, b.Left + CInt(b.Width / 2), b.Top + CInt(b.Height / 2), 0)
                        btn_Mine_MouseClick(b, m, False)

                End Select

            Next
        Next

        time = temps
        lblTime.Text = time.ToString().PadLeft(3, Convert.ToChar("0"))

        score = cescore
        LblScore.Text = "Score : " & score

        If remainingMines >= 0 Then
            lblMines.Text = remainingMines.ToString().PadLeft(3, Convert.ToChar("0"))
        Else
            lblMines.Text = "-" & Math.Abs(remainingMines).ToString().PadLeft(3, Convert.ToChar("0"))
        End If

    End Sub

    Private Sub HintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HintToolStripMenuItem.Click

        If GameStatus = eGameStatus.Unfinished Then
            If lvl4 = True Or lvl5 = True Or lvl8 = True Then
                If nbHint > 0 Then
                    If MsgBox("Click a box to discover if a mine is present !", MsgBoxStyle.Question Or MsgBoxStyle.OkCancel, "Let's get some help") = MsgBoxResult.Ok Then
                        isUsingHit = True
                    End If
                Else
                    MsgBox("Oh no ! You used all your available hints !", MsgBoxStyle.Exclamation, "Ooops !")
                End If
            Else
                MsgBox("You are not allowed to use hints !" & vbNewLine & vbNewLine & _
                       "Small FAQ :" & vbNewLine & _
                       "Q: What are hints useful for ?" & vbNewLine & _
                       "A: One hint allow you to discover the location of the specified box." & vbNewLine & vbNewLine & _
                       "Q: How to get hints ?" & vbNewLine & _
                       "A: Check in the 'Objectives' menu to discover how to get hints." & vbNewLine & vbNewLine & _
                       "Good luck !", MsgBoxStyle.Information, "Sorry...")
            End If
        End If
    End Sub

    Private Sub AwardsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AwardsToolStripMenuItem.Click
        Dim msg As String = "Your currently got :" & vbNewLine

        If lvl1 Then
            msg += vbNewLine & "Level 1 : You can play without numbers."
        End If
        If lvl2 Then
            msg += vbNewLine & "Level 2 : You can play without using flags."
        End If
        If lvl3 Then
            msg += vbNewLine & "Level 3 : You can load/save your games."
        End If
        If lvl4 Then
            msg += vbNewLine & "Level 4 : You can use ONE (1) hint per played game to discover if the box of your choice got a mine."
        End If
        If lvl5 Then
            msg += vbNewLine & "Level 5 : You can use FIVE (5) hints per played game to discover if the box of your choice got a mine."
        End If
        If lvl6 Then
            msg += vbNewLine & "Level 6 : You can play in God mode."
        End If
        If lvl7 Then
            msg += vbNewLine & "Level 7 : You can play in Wrapfield mode."
        End If
        If lvl8 Then
            msg += vbNewLine & "Level 8 : You can use INFINITE hints per played game to discover if the box of your choice got a mine."
        End If
        If Not (lvl1 = True Or lvl2 = True Or lvl3 = True Or lvl4 = True) Then
            msg += vbNewLine & "Level 0 : You are a total newbie. Do more training !"
        End If

        MsgBox(msg, MsgBoxStyle.Information, "Awards")
    End Sub

    Private Sub NoNumbersToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NoNumbersToolStripMenuItem.Click
        If lvl1 Then


            Dim current As Boolean = NoNumbers
            NoNumbers = NoNumbersToolStripMenuItem.Checked
            If current <> NoNumbers Then

                If MsgBox("Are you sure that you want to play " & (IIf(NoNumbers = True, "without", "with")).ToString() & " numbers ? This will begin a new game.", MsgBoxStyle.OkCancel Or MsgBoxStyle.Question, "Warning !") = MsgBoxResult.Ok Then
                    NewGame(sizeX, sizeY, nbMines)
                Else
                    NoNumbersToolStripMenuItem.Checked = Not NoNumbers
                    NoNumbers = Not NoNumbers
                End If
            End If

        Else

            NoNumbersToolStripMenuItem.Checked = False
            MsgBox("You can't play without numbers yet. You have yet to do less than 15s in Easy mode before." & vbNewLine & vbNewLine & _
                   "What does mean 'No numbers' ?" & vbNewLine & _
                   "It means that all the numbers are replaced by 0. This makes the game more difficult.", MsgBoxStyle.Information, "No no no !")

        End If
    End Sub


    Private Sub NoFlagsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoFlagsToolStripMenuItem.Click
        If lvl2 Then

            Dim current As Boolean = NoFlags
            NoFlags = NoFlagsToolStripMenuItem.Checked
            If current <> NoFlags Then

                If MsgBox("Are you sure that you want to play " & (IIf(NoFlags = True, "without", "with")).ToString() & " flags ? This will begin a new game.", MsgBoxStyle.OkCancel Or MsgBoxStyle.Question, "Warning !") = MsgBoxResult.Ok Then
                    NewGame(sizeX, sizeY, nbMines)
                Else
                    NoFlagsToolStripMenuItem.Checked = Not NoFlags
                    NoFlags = Not NoFlags
                End If
            End If


        Else

            NoFlagsToolStripMenuItem.Checked = False
            MsgBox("You can't play without flags yet. You have yet to do less than 200s in Medium mode before." & vbNewLine & vbNewLine & _
                   "What does mean 'No flags' ?" & vbNewLine & _
                   "It means that you can't mark the mines at all. Using the middle-click is also less easy, because you can't mark mines.", MsgBoxStyle.Information, "Come back later !")

        End If
    End Sub

    Private Sub WrapfieldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WrapfieldToolStripMenuItem.Click
        If lvl7 Then

            Dim current As Boolean = Wrapfield
            Wrapfield = WrapfieldToolStripMenuItem.Checked
            If current <> Wrapfield Then

                If MsgBox("Are you sure that you want to play in " & (IIf(Wrapfield = True, "Wrapfield", "normal")).ToString() & " mode ? This will begin a new game.", MsgBoxStyle.OkCancel Or MsgBoxStyle.Question, "Warning !") = MsgBoxResult.Ok Then
                    NewGame(sizeX, sizeY, nbMines)
                Else
                    WrapfieldToolStripMenuItem.Checked = Not Wrapfield
                    Wrapfield = Not Wrapfield
                End If
            End If


        Else

            WrapfieldToolStripMenuItem.Checked = False
            MsgBox("You can't play in Wrapfield mode yet. Check the 'Objectives' menu to discover how to enable the Wrapfield mode." & vbNewLine & vbNewLine & _
                   "What is Wrapfield mode ?" & vbNewLine & _
                   "Wrapfield mode is a special mode where numbers arround mines located in borders are reported to the opposite side, making the game more challenging !", MsgBoxStyle.Information, "You're not good enough...")

        End If
    End Sub

    Private Sub ObjectivesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjectivesToolStripMenuItem.Click
        Dim msg As String = "There are several objectives in GabMine :" & vbNewLine & vbNewLine & _
        " - Level 1 : Win the Easy game in less than 15 seconds." & vbNewLine & "   Award : You can play without numbers." & vbNewLine & vbNewLine & _
        " - Level 2 : Win the Medium game in less than 200 seconds." & vbNewLine & "   Award : You can play without flags." & vbNewLine & vbNewLine & _
        " - Level 3 : Win the Easy game in less than 10 seconds without numbers." & vbNewLine & "   Award : You can Load/Save your games." & vbNewLine & vbNewLine & _
        " - Level 4 : Win the Medium game in less than 100 seconds." & vbNewLine & "   Award : You can use ONE (1) Hint to discover wether the specified box contains a mine." & vbNewLine & vbNewLine & _
        " - Level 5 : Win the Hard game in less than 200 seconds." & vbNewLine & "   Award : You can use FIVE (5) Hints to discover wether the specified box contains a mine." & vbNewLine & vbNewLine & _
        " - Level 6 : The sum of the times of Easy, Medium and Hard games is less than 200 seconds." & vbNewLine & "   Award : You can play in God mode." & vbNewLine & vbNewLine & _
        " - Level 7 : Win the God game in less than 300 seconds." & vbNewLine & "   Award : You can play in Wrapfield mode." & vbNewLine & vbNewLine & _
        " - Level 8 : Win the God game in Wrapfield mode, without numbers and flags." & vbNewLine & "   Award : You can use INFINITE Hints !" & vbNewLine & vbNewLine & _
        "Good luck !"

        MsgBox(msg, MsgBoxStyle.Information, "Objectives")


    End Sub

    Private Sub HelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem.Click
        MsgBox("No help yet...", MsgBoxStyle.Information, "The dev is lazy...")
    End Sub

 
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        Application.Exit()

    End Sub
End Class
