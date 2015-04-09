Public Class frmHighScores

    Private Sub frmHighScores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtEasyTime.Text = My.Settings.SettingHSEasyName & " in " & My.Settings.SettingHSEasyBestTime & " s."
        txtMediumTime.Text = My.Settings.SettingHSMediumName & " in " & My.Settings.SettingHSMediumBestTime & " s."
        txtHardTime.Text = My.Settings.SettingHSHardName & " in " & My.Settings.SettingHSHardBestTime & " s."
        txtGodTime.Text = My.Settings.SettingHSGodName & " in " & My.Settings.SettingHSGodBestTime & " s."

        txtEasyScore.Text = My.Settings.SettingHSEasyName & " with " & My.Settings.SettingHSEasyBestScore
        txtMediumScore.Text = My.Settings.SettingHSMediumName & " with " & My.Settings.SettingHSMediumBestScore
        txtHardScore.Text = My.Settings.SettingHSHardName & " with " & My.Settings.SettingHSHardBestScore
        txtGodScore.Text = My.Settings.SettingHSGodName & " with " & My.Settings.SettingHSGodBestScore

        txtNbTotal.Text = My.Settings.SettingNbGamePlayed.ToString()
        txtNbWon.Text = My.Settings.SettingNbGameWon.ToString()
        txtNbLost.Text = My.Settings.SettingNbGameLost.ToString()
        txtNbUnfinished.Text = My.Settings.SettingNbGameUnfinished.ToString()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class