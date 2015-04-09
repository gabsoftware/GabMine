<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHighScores
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnClose = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtEasyTime = New System.Windows.Forms.TextBox
        Me.txtMediumTime = New System.Windows.Forms.TextBox
        Me.txtHardTime = New System.Windows.Forms.TextBox
        Me.txtNbTotal = New System.Windows.Forms.TextBox
        Me.txtNbWon = New System.Windows.Forms.TextBox
        Me.txtNbLost = New System.Windows.Forms.TextBox
        Me.txtNbUnfinished = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtHardScore = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtMediumScore = New System.Windows.Forms.TextBox
        Me.txtEasyScore = New System.Windows.Forms.TextBox
        Me.txtGodTime = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtGodScore = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(517, 294)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(114, 25)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Easy :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Medium :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Hard :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Games played :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Games won :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Games lost :"
        '
        'txtEasyTime
        '
        Me.txtEasyTime.Location = New System.Drawing.Point(89, 31)
        Me.txtEasyTime.Name = "txtEasyTime"
        Me.txtEasyTime.ReadOnly = True
        Me.txtEasyTime.Size = New System.Drawing.Size(173, 20)
        Me.txtEasyTime.TabIndex = 7
        '
        'txtMediumTime
        '
        Me.txtMediumTime.Location = New System.Drawing.Point(89, 57)
        Me.txtMediumTime.Name = "txtMediumTime"
        Me.txtMediumTime.ReadOnly = True
        Me.txtMediumTime.Size = New System.Drawing.Size(173, 20)
        Me.txtMediumTime.TabIndex = 8
        '
        'txtHardTime
        '
        Me.txtHardTime.Location = New System.Drawing.Point(89, 83)
        Me.txtHardTime.Name = "txtHardTime"
        Me.txtHardTime.ReadOnly = True
        Me.txtHardTime.Size = New System.Drawing.Size(173, 20)
        Me.txtHardTime.TabIndex = 9
        '
        'txtNbTotal
        '
        Me.txtNbTotal.Location = New System.Drawing.Point(103, 28)
        Me.txtNbTotal.Name = "txtNbTotal"
        Me.txtNbTotal.ReadOnly = True
        Me.txtNbTotal.Size = New System.Drawing.Size(173, 20)
        Me.txtNbTotal.TabIndex = 10
        '
        'txtNbWon
        '
        Me.txtNbWon.Location = New System.Drawing.Point(103, 54)
        Me.txtNbWon.Name = "txtNbWon"
        Me.txtNbWon.ReadOnly = True
        Me.txtNbWon.Size = New System.Drawing.Size(173, 20)
        Me.txtNbWon.TabIndex = 11
        '
        'txtNbLost
        '
        Me.txtNbLost.Location = New System.Drawing.Point(103, 80)
        Me.txtNbLost.Name = "txtNbLost"
        Me.txtNbLost.ReadOnly = True
        Me.txtNbLost.Size = New System.Drawing.Size(173, 20)
        Me.txtNbLost.TabIndex = 12
        '
        'txtNbUnfinished
        '
        Me.txtNbUnfinished.Location = New System.Drawing.Point(103, 106)
        Me.txtNbUnfinished.Name = "txtNbUnfinished"
        Me.txtNbUnfinished.ReadOnly = True
        Me.txtNbUnfinished.Size = New System.Drawing.Size(173, 20)
        Me.txtNbUnfinished.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 109)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Unfinished :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtNbUnfinished)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtNbLost)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtNbWon)
        Me.GroupBox1.Controls.Add(Me.txtNbTotal)
        Me.GroupBox1.Location = New System.Drawing.Point(344, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(287, 259)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Statistics"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtGodTime)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtHardTime)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtMediumTime)
        Me.GroupBox2.Controls.Add(Me.txtEasyTime)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(283, 143)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Best times"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtGodScore)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtHardScore)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtMediumScore)
        Me.GroupBox3.Controls.Add(Me.txtEasyScore)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 172)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(283, 147)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Best scores"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Medium :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Easy :"
        '
        'txtHardScore
        '
        Me.txtHardScore.Location = New System.Drawing.Point(89, 83)
        Me.txtHardScore.Name = "txtHardScore"
        Me.txtHardScore.ReadOnly = True
        Me.txtHardScore.Size = New System.Drawing.Size(173, 20)
        Me.txtHardScore.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 86)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Hard :"
        '
        'txtMediumScore
        '
        Me.txtMediumScore.Location = New System.Drawing.Point(89, 57)
        Me.txtMediumScore.Name = "txtMediumScore"
        Me.txtMediumScore.ReadOnly = True
        Me.txtMediumScore.Size = New System.Drawing.Size(173, 20)
        Me.txtMediumScore.TabIndex = 14
        '
        'txtEasyScore
        '
        Me.txtEasyScore.Location = New System.Drawing.Point(89, 31)
        Me.txtEasyScore.Name = "txtEasyScore"
        Me.txtEasyScore.ReadOnly = True
        Me.txtEasyScore.Size = New System.Drawing.Size(173, 20)
        Me.txtEasyScore.TabIndex = 13
        '
        'txtGodTime
        '
        Me.txtGodTime.Location = New System.Drawing.Point(89, 109)
        Me.txtGodTime.Name = "txtGodTime"
        Me.txtGodTime.ReadOnly = True
        Me.txtGodTime.Size = New System.Drawing.Size(173, 20)
        Me.txtGodTime.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 112)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "God :"
        '
        'txtGodScore
        '
        Me.txtGodScore.Location = New System.Drawing.Point(89, 109)
        Me.txtGodScore.Name = "txtGodScore"
        Me.txtGodScore.ReadOnly = True
        Me.txtGodScore.Size = New System.Drawing.Size(173, 20)
        Me.txtGodScore.TabIndex = 17
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 112)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "God :"
        '
        'frmHighScores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 332)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmHighScores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "High scores"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEasyTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMediumTime As System.Windows.Forms.TextBox
    Friend WithEvents txtHardTime As System.Windows.Forms.TextBox
    Friend WithEvents txtNbTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtNbWon As System.Windows.Forms.TextBox
    Friend WithEvents txtNbLost As System.Windows.Forms.TextBox
    Friend WithEvents txtNbUnfinished As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtHardScore As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMediumScore As System.Windows.Forms.TextBox
    Friend WithEvents txtEasyScore As System.Windows.Forms.TextBox
    Friend WithEvents txtGodTime As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtGodScore As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
