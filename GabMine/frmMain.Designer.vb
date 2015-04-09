<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.GameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewGameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.LoadGameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveGameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EasyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MediumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GodToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.HighScoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AwardsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NoNumbersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NoFlagsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WrapfieldToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ObjectivesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.HintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutGabMineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblScore = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.lblMines = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_0_0 = New System.Windows.Forms.Button()
        Me.mainTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SaveGameDlg = New System.Windows.Forms.SaveFileDialog()
        Me.LoadGameDlg = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnNew
        '
        Me.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnNew.Location = New System.Drawing.Point(76, 18)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(100, 35)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "New game"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GameToolStripMenuItem, Me.ToolStripMenuItem1, Me.SOSToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(277, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'GameToolStripMenuItem
        '
        Me.GameToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewGameToolStripMenuItem, Me.ToolStripSeparator4, Me.LoadGameToolStripMenuItem, Me.SaveGameToolStripMenuItem, Me.ToolStripSeparator2, Me.EasyToolStripMenuItem, Me.MediumToolStripMenuItem, Me.HardToolStripMenuItem, Me.GodToolStripMenuItem, Me.CustomToolStripMenuItem, Me.ToolStripSeparator3, Me.HighScoresToolStripMenuItem, Me.AwardsToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.GameToolStripMenuItem.Name = "GameToolStripMenuItem"
        Me.GameToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.GameToolStripMenuItem.Text = "&Game"
        '
        'NewGameToolStripMenuItem
        '
        Me.NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem"
        Me.NewGameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.NewGameToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.NewGameToolStripMenuItem.Text = "&New Game"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(186, 6)
        '
        'LoadGameToolStripMenuItem
        '
        Me.LoadGameToolStripMenuItem.Name = "LoadGameToolStripMenuItem"
        Me.LoadGameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.LoadGameToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.LoadGameToolStripMenuItem.Text = "&Load Game..."
        '
        'SaveGameToolStripMenuItem
        '
        Me.SaveGameToolStripMenuItem.Name = "SaveGameToolStripMenuItem"
        Me.SaveGameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.SaveGameToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.SaveGameToolStripMenuItem.Text = "&Save Game As..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(186, 6)
        '
        'EasyToolStripMenuItem
        '
        Me.EasyToolStripMenuItem.Name = "EasyToolStripMenuItem"
        Me.EasyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.D1), System.Windows.Forms.Keys)
        Me.EasyToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.EasyToolStripMenuItem.Text = "&Easy"
        '
        'MediumToolStripMenuItem
        '
        Me.MediumToolStripMenuItem.Name = "MediumToolStripMenuItem"
        Me.MediumToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.D2), System.Windows.Forms.Keys)
        Me.MediumToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.MediumToolStripMenuItem.Text = "&Medium"
        '
        'HardToolStripMenuItem
        '
        Me.HardToolStripMenuItem.Name = "HardToolStripMenuItem"
        Me.HardToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.D3), System.Windows.Forms.Keys)
        Me.HardToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.HardToolStripMenuItem.Text = "&Hard"
        '
        'GodToolStripMenuItem
        '
        Me.GodToolStripMenuItem.Name = "GodToolStripMenuItem"
        Me.GodToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.D4), System.Windows.Forms.Keys)
        Me.GodToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.GodToolStripMenuItem.Text = "&God"
        '
        'CustomToolStripMenuItem
        '
        Me.CustomToolStripMenuItem.Name = "CustomToolStripMenuItem"
        Me.CustomToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CustomToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.CustomToolStripMenuItem.Text = "&Custom..."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(186, 6)
        '
        'HighScoresToolStripMenuItem
        '
        Me.HighScoresToolStripMenuItem.Name = "HighScoresToolStripMenuItem"
        Me.HighScoresToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.HighScoresToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.HighScoresToolStripMenuItem.Text = "High Sc&ores..."
        '
        'AwardsToolStripMenuItem
        '
        Me.AwardsToolStripMenuItem.Name = "AwardsToolStripMenuItem"
        Me.AwardsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.AwardsToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.AwardsToolStripMenuItem.Text = "&Awards..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(186, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NoNumbersToolStripMenuItem, Me.NoFlagsToolStripMenuItem, Me.WrapfieldToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(61, 20)
        Me.ToolStripMenuItem1.Text = "&Options"
        '
        'NoNumbersToolStripMenuItem
        '
        Me.NoNumbersToolStripMenuItem.CheckOnClick = True
        Me.NoNumbersToolStripMenuItem.Name = "NoNumbersToolStripMenuItem"
        Me.NoNumbersToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.NoNumbersToolStripMenuItem.Text = "No &numbers"
        '
        'NoFlagsToolStripMenuItem
        '
        Me.NoFlagsToolStripMenuItem.CheckOnClick = True
        Me.NoFlagsToolStripMenuItem.Name = "NoFlagsToolStripMenuItem"
        Me.NoFlagsToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.NoFlagsToolStripMenuItem.Text = "No &flags"
        '
        'WrapfieldToolStripMenuItem
        '
        Me.WrapfieldToolStripMenuItem.CheckOnClick = True
        Me.WrapfieldToolStripMenuItem.Name = "WrapfieldToolStripMenuItem"
        Me.WrapfieldToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.WrapfieldToolStripMenuItem.Text = "&Wrapfield mode"
        '
        'SOSToolStripMenuItem
        '
        Me.SOSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem, Me.ObjectivesToolStripMenuItem, Me.ToolStripSeparator6, Me.HintToolStripMenuItem, Me.ToolStripSeparator5, Me.AboutGabMineToolStripMenuItem})
        Me.SOSToolStripMenuItem.Name = "SOSToolStripMenuItem"
        Me.SOSToolStripMenuItem.Size = New System.Drawing.Size(24, 20)
        Me.SOSToolStripMenuItem.Text = "&?"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'ObjectivesToolStripMenuItem
        '
        Me.ObjectivesToolStripMenuItem.Name = "ObjectivesToolStripMenuItem"
        Me.ObjectivesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.ObjectivesToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ObjectivesToolStripMenuItem.Text = "&Objectives"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(169, 6)
        '
        'HintToolStripMenuItem
        '
        Me.HintToolStripMenuItem.Name = "HintToolStripMenuItem"
        Me.HintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.HintToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.HintToolStripMenuItem.Text = "H&int..."
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(169, 6)
        '
        'AboutGabMineToolStripMenuItem
        '
        Me.AboutGabMineToolStripMenuItem.Name = "AboutGabMineToolStripMenuItem"
        Me.AboutGabMineToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.AboutGabMineToolStripMenuItem.Text = "&About GabMine..."
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.LblScore)
        Me.Panel1.Controls.Add(Me.lblTime)
        Me.Panel1.Controls.Add(Me.lblMines)
        Me.Panel1.Controls.Add(Me.btnNew)
        Me.Panel1.Location = New System.Drawing.Point(12, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(253, 77)
        Me.Panel1.TabIndex = 2
        '
        'LblScore
        '
        Me.LblScore.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblScore.AutoSize = True
        Me.LblScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblScore.Location = New System.Drawing.Point(97, 56)
        Me.LblScore.Name = "LblScore"
        Me.LblScore.Size = New System.Drawing.Size(59, 13)
        Me.LblScore.TabIndex = 3
        Me.LblScore.Text = "Score : 0"
        '
        'lblTime
        '
        Me.lblTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime.AutoSize = True
        Me.lblTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.Location = New System.Drawing.Point(193, 22)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(59, 31)
        Me.lblTime.TabIndex = 2
        Me.lblTime.Text = "000"
        '
        'lblMines
        '
        Me.lblMines.AutoSize = True
        Me.lblMines.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMines.Location = New System.Drawing.Point(3, 22)
        Me.lblMines.Name = "lblMines"
        Me.lblMines.Size = New System.Drawing.Size(59, 31)
        Me.lblMines.TabIndex = 1
        Me.lblMines.Text = "010"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btn_0_0)
        Me.Panel2.Location = New System.Drawing.Point(12, 110)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(253, 253)
        Me.Panel2.TabIndex = 3
        '
        'btn_0_0
        '
        Me.btn_0_0.BackColor = System.Drawing.Color.Silver
        Me.btn_0_0.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btn_0_0.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_0_0.Location = New System.Drawing.Point(1, 1)
        Me.btn_0_0.Name = "btn_0_0"
        Me.btn_0_0.Size = New System.Drawing.Size(24, 24)
        Me.btn_0_0.TabIndex = 0
        Me.btn_0_0.UseVisualStyleBackColor = False
        '
        'mainTimer
        '
        Me.mainTimer.Interval = 1000
        '
        'SaveGameDlg
        '
        Me.SaveGameDlg.DefaultExt = "dem"
        Me.SaveGameDlg.FileName = "NewGame.dem"
        Me.SaveGameDlg.Filter = "GabMine games (*.dem)|*.dem|All files (*.*)|*.*"
        Me.SaveGameDlg.RestoreDirectory = True
        Me.SaveGameDlg.Title = "Save your current GabMine game as :"
        '
        'LoadGameDlg
        '
        Me.LoadGameDlg.DefaultExt = "dem"
        Me.LoadGameDlg.Filter = "GabMine games (*.dem)|*.dem|All files (*.*)|*.*"
        Me.LoadGameDlg.RestoreDirectory = True
        Me.LoadGameDlg.Title = "Load a GabMine saved game"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(277, 375)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GabMine"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents GameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewGameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EasyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HighScoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SOSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutGabMineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MediumToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CustomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btn_0_0 As System.Windows.Forms.Button

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents lblMines As System.Windows.Forms.Label
    Friend WithEvents mainTimer As System.Windows.Forms.Timer
    Friend WithEvents LblScore As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LoadGameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveGameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveGameDlg As System.Windows.Forms.SaveFileDialog
    Friend WithEvents LoadGameDlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AwardsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GodToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ObjectivesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NoNumbersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NoFlagsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WrapfieldToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
