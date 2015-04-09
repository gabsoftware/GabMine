Imports System.Windows.Forms

Public Class frmNewHighScore

    Private time As Integer
    Private score As Integer

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click


        Select Case DirectCast(Application.OpenForms("frmMain"), frmMain).GameType
            Case frmMain.eGameType.Easy

                My.Settings.SettingHSEasyName = txtName.Text
                If My.Settings.SettingHSEasyBestScore < score Then
                    My.Settings.SettingHSEasyBestScore = score
                End If
                If My.Settings.SettingHSEasyBestTime > time Then
                    My.Settings.SettingHSEasyBestTime = time
                End If

            Case frmMain.eGameType.Medium

                My.Settings.SettingHSMediumName = txtName.Text
                If My.Settings.SettingHSMediumBestScore < score Then
                    My.Settings.SettingHSMediumBestScore = score
                End If
                If My.Settings.SettingHSMediumBestTime > time Then
                    My.Settings.SettingHSMediumBestTime = time
                End If

            Case frmMain.eGameType.Hard

                My.Settings.SettingHSHardName = txtName.Text
                If My.Settings.SettingHSHardBestScore < score Then
                    My.Settings.SettingHSHardBestScore = score
                End If
                If My.Settings.SettingHSHardBestTime > time Then
                    My.Settings.SettingHSHardBestTime = time
                End If

            Case frmMain.eGameType.God

                My.Settings.SettingHSGodName = txtName.Text
                If My.Settings.SettingHSGodBestScore < score Then
                    My.Settings.SettingHSGodBestScore = score
                End If
                If My.Settings.SettingHSGodBestTime > time Then
                    My.Settings.SettingHSGodBestTime = time
                End If

        End Select

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmNewHighScore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        Select Case DirectCast(Application.OpenForms("frmMain"), frmMain).GameType
            Case frmMain.eGameType.Easy
                txtName.Text = My.Settings.SettingHSEasyName
                If time < My.Settings.SettingHSEasyBestTime And score > My.Settings.SettingHSEasyBestScore Then
                    lblCongratulations.Text = lblCongratulations.Text.Replace("%1", "time and score")
                ElseIf time < My.Settings.SettingHSEasyBestTime Then
                    lblCongratulations.Text = lblCongratulations.Text.Replace("%1", "time")
                ElseIf score > My.Settings.SettingHSEasyBestScore Then
                    lblCongratulations.Text = lblCongratulations.Text.Replace("%1", "score")
                End If
                lblDesc.Text = lblDesc.Text.Replace("%1", "Easy")
            Case frmMain.eGameType.Medium
                txtName.Text = My.Settings.SettingHSMediumName
                If time < My.Settings.SettingHSMediumBestTime And score > My.Settings.SettingHSMediumBestScore Then
                    lblCongratulations.Text = lblCongratulations.Text.Replace("%1", "time and score")
                ElseIf time < My.Settings.SettingHSMediumBestTime Then
                    lblCongratulations.Text = lblCongratulations.Text.Replace("%1", "time")
                ElseIf score > My.Settings.SettingHSMediumBestScore Then
                    lblCongratulations.Text = lblCongratulations.Text.Replace("%1", "score")
                End If
                lblDesc.Text = lblDesc.Text.Replace("%1", "Medium")
            Case frmMain.eGameType.Hard
                txtName.Text = My.Settings.SettingHSHardName
                If time < My.Settings.SettingHSHardBestTime And score > My.Settings.SettingHSHardBestScore Then
                    lblCongratulations.Text = lblCongratulations.Text.Replace("%1", "time and score")
                ElseIf time < My.Settings.SettingHSHardBestTime Then
                    lblCongratulations.Text = lblCongratulations.Text.Replace("%1", "time")
                ElseIf score > My.Settings.SettingHSHardBestScore Then
                    lblCongratulations.Text = lblCongratulations.Text.Replace("%1", "score")
                End If
                lblDesc.Text = lblDesc.Text.Replace("%1", "Hard")
            Case frmMain.eGameType.God
                txtName.Text = My.Settings.SettingHSGodName
                If time < My.Settings.SettingHSGodBestTime And score > My.Settings.SettingHSGodBestScore Then
                    lblCongratulations.Text = lblCongratulations.Text.Replace("%1", "time and score")
                ElseIf time < My.Settings.SettingHSGodBestTime Then
                    lblCongratulations.Text = lblCongratulations.Text.Replace("%1", "time")
                ElseIf score > My.Settings.SettingHSGodBestScore Then
                    lblCongratulations.Text = lblCongratulations.Text.Replace("%1", "score")
                End If
                lblDesc.Text = lblDesc.Text.Replace("%1", "God")
        End Select
        lblDesc.Text = lblDesc.Text.Replace("%2", time.ToString())
        lblDesc.Text = lblDesc.Text.Replace("%3", score.ToString())
        txtName.SelectAll()

    End Sub

    Public Sub New(ByVal myTime As Integer, ByVal myScore As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        time = myTime
        score = myScore

    End Sub
End Class
