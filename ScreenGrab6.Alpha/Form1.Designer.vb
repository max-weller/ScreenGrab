﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Timer1
    '
    Me.Timer1.Enabled = True
    '
    'PictureBox1
    '
    Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
    Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(809, 532)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.PictureBox1.TabIndex = 0
    Me.PictureBox1.TabStop = False
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
    Me.ClientSize = New System.Drawing.Size(809, 532)
    Me.Controls.Add(Me.PictureBox1)
    Me.Name = "Form1"
    Me.Text = "Drücke die PAUSE-Taste um einen Screenshot zu erstellen"
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Timer1 As System.Windows.Forms.Timer
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
