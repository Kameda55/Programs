<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pMsg = New System.Windows.Forms.PictureBox()
        Me.pTAKIGYO = New System.Windows.Forms.PictureBox()
        Me.pGameover = New System.Windows.Forms.PictureBox()
        Me.pExp = New System.Windows.Forms.PictureBox()
        Me.pPlayer = New System.Windows.Forms.PictureBox()
        Me.pBase = New System.Windows.Forms.PictureBox()
        Me.pIwa = New System.Windows.Forms.PictureBox()
        Me.pTaki = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.pMsg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pTAKIGYO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pGameover, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pExp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pIwa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pTaki, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pMsg
        '
        Me.pMsg.Image = Global.TAKIGYO.My.Resources.Resources.p_msg
        Me.pMsg.Location = New System.Drawing.Point(621, 382)
        Me.pMsg.Name = "pMsg"
        Me.pMsg.Size = New System.Drawing.Size(148, 43)
        Me.pMsg.TabIndex = 7
        Me.pMsg.TabStop = False
        '
        'pTAKIGYO
        '
        Me.pTAKIGYO.Image = Global.TAKIGYO.My.Resources.Resources.p_TAKIGYO
        Me.pTAKIGYO.Location = New System.Drawing.Point(390, 394)
        Me.pTAKIGYO.Name = "pTAKIGYO"
        Me.pTAKIGYO.Size = New System.Drawing.Size(148, 118)
        Me.pTAKIGYO.TabIndex = 6
        Me.pTAKIGYO.TabStop = False
        '
        'pGameover
        '
        Me.pGameover.Image = Global.TAKIGYO.My.Resources.Resources.p_Gameover
        Me.pGameover.Location = New System.Drawing.Point(420, 211)
        Me.pGameover.Name = "pGameover"
        Me.pGameover.Size = New System.Drawing.Size(148, 118)
        Me.pGameover.TabIndex = 5
        Me.pGameover.TabStop = False
        '
        'pExp
        '
        Me.pExp.Image = Global.TAKIGYO.My.Resources.Resources.p_explosion
        Me.pExp.Location = New System.Drawing.Point(747, 266)
        Me.pExp.Name = "pExp"
        Me.pExp.Size = New System.Drawing.Size(87, 63)
        Me.pExp.TabIndex = 4
        Me.pExp.TabStop = False
        '
        'pPlayer
        '
        Me.pPlayer.Image = Global.TAKIGYO.My.Resources.Resources.p_player
        Me.pPlayer.Location = New System.Drawing.Point(414, 12)
        Me.pPlayer.Name = "pPlayer"
        Me.pPlayer.Size = New System.Drawing.Size(124, 118)
        Me.pPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pPlayer.TabIndex = 3
        Me.pPlayer.TabStop = False
        '
        'pBase
        '
        Me.pBase.Location = New System.Drawing.Point(-9, 1)
        Me.pBase.Name = "pBase"
        Me.pBase.Size = New System.Drawing.Size(897, 651)
        Me.pBase.TabIndex = 2
        Me.pBase.TabStop = False
        '
        'pIwa
        '
        Me.pIwa.Image = Global.TAKIGYO.My.Resources.Resources.p_iwa
        Me.pIwa.Location = New System.Drawing.Point(662, 23)
        Me.pIwa.Name = "pIwa"
        Me.pIwa.Size = New System.Drawing.Size(172, 149)
        Me.pIwa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pIwa.TabIndex = 0
        Me.pIwa.TabStop = False
        '
        'pTaki
        '
        Me.pTaki.Image = Global.TAKIGYO.My.Resources.Resources.p_bg
        Me.pTaki.Location = New System.Drawing.Point(420, 51)
        Me.pTaki.Name = "pTaki"
        Me.pTaki.Size = New System.Drawing.Size(339, 234)
        Me.pTaki.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pTaki.TabIndex = 1
        Me.pTaki.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 20
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 644)
        Me.Controls.Add(Me.pPlayer)
        Me.Controls.Add(Me.pMsg)
        Me.Controls.Add(Me.pTAKIGYO)
        Me.Controls.Add(Me.pGameover)
        Me.Controls.Add(Me.pExp)
        Me.Controls.Add(Me.pIwa)
        Me.Controls.Add(Me.pTaki)
        Me.Controls.Add(Me.pBase)
        Me.Name = "Form1"
        Me.Text = "TAKIGYO"
        CType(Me.pMsg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pTAKIGYO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pGameover, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pExp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pIwa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pTaki, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pIwa As PictureBox
    Friend WithEvents pTaki As PictureBox
    Friend WithEvents pBase As PictureBox
    Friend WithEvents pPlayer As PictureBox
    Friend WithEvents pExp As PictureBox
    Friend WithEvents pGameover As PictureBox
    Friend WithEvents pTAKIGYO As PictureBox
    Friend WithEvents pMsg As PictureBox
    Friend WithEvents Timer1 As Timer
End Class
