﻿Public Class frm_imageshackUploaded

  Sub setInfo(ByVal hasht As Hashtable)
    For Each key As String In hasht.Keys
      RichTextBox1.AppendText(key + ":" + vbCrLf + hasht(key) + vbCrLf + vbCrLf)
    Next
    PictureBox1.ImageLocation = hasht("yfrog_thumb")
    Clipboard.Clear()
    Clipboard.SetText(hasht("is_link"))
  End Sub

  Private Sub RichTextBox1_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles RichTextBox1.LinkClicked
    Process.Start(e.LinkText)
  End Sub

End Class