﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.txtpass = New System.Windows.Forms.TextBox()
        Me.txtuser = New System.Windows.Forms.TextBox()
        Me.labupdatedok = New System.Windows.Forms.Label()
        Me.labversionmsg = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.checkTime = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtpass
        '
        Me.txtpass.Location = New System.Drawing.Point(384, 366)
        Me.txtpass.Name = "txtpass"
        Me.txtpass.Size = New System.Drawing.Size(119, 20)
        Me.txtpass.TabIndex = 29
        Me.txtpass.UseSystemPasswordChar = True
        '
        'txtuser
        '
        Me.txtuser.Location = New System.Drawing.Point(384, 338)
        Me.txtuser.Name = "txtuser"
        Me.txtuser.Size = New System.Drawing.Size(119, 20)
        Me.txtuser.TabIndex = 28
        '
        'labupdatedok
        '
        Me.labupdatedok.BackColor = System.Drawing.Color.Transparent
        Me.labupdatedok.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labupdatedok.ForeColor = System.Drawing.Color.Lime
        Me.labupdatedok.Location = New System.Drawing.Point(277, 263)
        Me.labupdatedok.Name = "labupdatedok"
        Me.labupdatedok.Size = New System.Drawing.Size(211, 20)
        Me.labupdatedok.TabIndex = 27
        Me.labupdatedok.Text = "Your version is updated!"
        Me.labupdatedok.Visible = False
        '
        'labversionmsg
        '
        Me.labversionmsg.BackColor = System.Drawing.Color.Transparent
        Me.labversionmsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labversionmsg.ForeColor = System.Drawing.Color.Red
        Me.labversionmsg.Location = New System.Drawing.Point(277, 263)
        Me.labversionmsg.Name = "labversionmsg"
        Me.labversionmsg.Size = New System.Drawing.Size(211, 20)
        Me.labversionmsg.TabIndex = 26
        Me.labversionmsg.Text = "Please, update the software!"
        Me.labversionmsg.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.KuhiScan.My.Resources.Resources.loginnow
        Me.PictureBox1.Location = New System.Drawing.Point(280, 404)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(208, 35)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'checkTime
        '
        Me.checkTime.Interval = 30000
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.KuhiScan.My.Resources.Resources.Home_Page_53
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(724, 500)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtpass)
        Me.Controls.Add(Me.txtuser)
        Me.Controls.Add(Me.labupdatedok)
        Me.Controls.Add(Me.labversionmsg)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtpass As TextBox
    Friend WithEvents txtuser As TextBox
    Friend WithEvents labupdatedok As Label
    Friend WithEvents labversionmsg As Label
    Friend WithEvents checkTime As Timer
End Class
