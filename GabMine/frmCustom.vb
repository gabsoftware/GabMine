Imports System.Windows.Forms

Public Class frmCustom

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim x As Integer = Decimal.ToInt32(nudWidth.Value)
        Dim y As Integer = Decimal.ToInt32(nudHeight.Value)
        Dim n As Integer = Decimal.ToInt32(nudMines.Value)

        If n > Int((x * y) * 0.5) Then
            'on n'autorise qu'un nombre de mines inférieur ou égal à 50% de la surface totale
            n = CInt(Int((x * y) * 0.5))
        End If

        DirectCast(Application.OpenForms("frmMain"), frmMain).nbMines = n
        DirectCast(Application.OpenForms("frmMain"), frmMain).sizeX = x
        DirectCast(Application.OpenForms("frmMain"), frmMain).sizeY = y
        DirectCast(Application.OpenForms("frmMain"), frmMain).GameType = frmMain.eGameType.Custom
        DirectCast(Application.OpenForms("frmMain"), frmMain).NewGame(x, y, n)


        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
