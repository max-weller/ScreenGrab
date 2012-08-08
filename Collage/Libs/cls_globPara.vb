Public Class cls_globPara

  ': ========== Globale Variablen ==========================================

  Dim m_paraFileSpec As String
  Dim m_content As New Dictionary(Of String, String)
  Const tabDelimiter As String = "<=" + vbTab



  ': ========== Konstruktor + Destruktor ==================================

  Public Sub New(Optional ByVal fileSpec As String = "")
    m_paraFileSpec = fileSpec
    If m_paraFileSpec = "" Then
      m_paraFileSpec = fp(My.Application.Info.DirectoryPath, My.Application.Info.AssemblyName + ".para.txt")
    End If
    Dim folder As String = My.Computer.FileSystem.GetParentPath(m_paraFileSpec)
    System.IO.Directory.CreateDirectory(folder)

    Debug.Print("paraFilespec: " + m_paraFileSpec)

    readFile()
  End Sub
  Protected Overrides Sub Finalize()
    saveParaFile()
    MyBase.Finalize()
  End Sub



  ': ========== Haupteigenschaft ========================

  Public Property para(ByVal key As String, Optional ByVal def As String = "") As String
    Get
      If m_content.ContainsKey(key) Then
        para = m_content.Item(key)
      Else
        para = def
      End If
    End Get
    Set(ByVal value As String)
      If m_content.ContainsKey(key) Then
        m_content.Item(key) = value
      Else
        m_content.Add(key, value)
      End If
    End Set
  End Property


  ': ========== Hilfsfunktionen ========================

  Public Function appPath() As String
    Return fp(My.Computer.FileSystem.GetParentPath(Application.ExecutablePath))
  End Function
  Public Function fp(ByVal path As String, Optional ByVal fileName As String = "")
    fp = path + IIf(path.EndsWith("\"), "", "\") + fileName
  End Function

  Public Function fpUNIX(ByVal path As String, Optional ByVal fileName As String = "")
    fpUNIX = path + IIf(path.EndsWith("/"), "", "/") + fileName
  End Function


  Public Function Contains(ByVal key As String) As Boolean
    Contains = m_content.ContainsKey(key)

  End Function


  Enum FormPosFlags
    Pos = 1
    Size = 2
    Both = 3
  End Enum

  ': ========== Form-Tools ========================

  Public Sub readFormPos(ByVal frm As Form, Optional ByVal Flags As FormPosFlags = FormPosFlags.Both)
    Try
      Dim paraName As String = frm.Name.ToLower + "__" + "Rect"
      Dim formPos() As String = Split(Me.para(paraName), ";")
      If (Flags And FormPosFlags.Pos) > 0 Then
        frm.Left = CInt(formPos(0))
        frm.Top = CInt(formPos(1))
      End If
      If (Flags And FormPosFlags.Size) > 0 Then
        frm.Width = CInt(formPos(2))
        frm.Height = CInt(formPos(3))
      End If

    Catch ex As Exception

    End Try
  End Sub

  Public Sub saveFormPos(ByVal frm As Form, Optional ByVal Flags As FormPosFlags = FormPosFlags.Both)
    Dim formPos As String

    With frm
      If .WindowState = FormWindowState.Minimized Then .WindowState = FormWindowState.Normal
      formPos = .Left.ToString + ";" + .Top.ToString _
              + ";" + .Width.ToString + ";" + .Height.ToString
      Dim paraName As String = frm.Name.ToLower + "__" + "Rect"
      Me.para(paraName) = formPos
    End With
  End Sub

  Public Sub readTuttiFrutti(ByVal frm As Form)
    recursive_readTuttiFrutti(frm, frm)
  End Sub

  Public Sub saveTuttiFrutti(ByVal frm As Form)
    recursive_saveTuttiFrutti(frm, frm)
  End Sub

  Public Sub recursive_readTuttiFrutti(ByVal frm As Form, ByVal ctrl As Control)
    Dim typ As String
    Dim prefix As String = frm.Name + "__"
    For Each subctrl As Object In ctrl.Controls
      If subctrl.Controls.Count > 0 Then recursive_readTuttiFrutti(frm, subctrl)
      If Not Contains(prefix + subctrl.Name) Then Continue For

      typ = subctrl.GetType().ToString

      If typ = "System.Windows.Forms.TextBox" Then
        subctrl.Text = Me.para(prefix + subctrl.Name)
      End If
      If typ = "System.Windows.Forms.ComboBox" Then
        subctrl.Text = Me.para(prefix + subctrl.Name)
      End If
      If typ = "System.Windows.Forms.CheckBox" Then
        subctrl.Checked = (Me.para(prefix + subctrl.Name) = "TRUE")
      End If
      If typ = "System.Windows.Forms.NumericUpDown" Then
        subctrl.Value = Val(Me.para(prefix + subctrl.Name))
      End If
      If typ = "System.Windows.Forms.RadioButton" Then
        Dim paras() As String = Split(subctrl.Name, "__")
        If Me.para(prefix + paras(0)) = paras(1) Then
          subctrl.Checked = True
        Else
          subctrl.checked = False
        End If
      End If
    Next
  End Sub
  Public Sub recursive_saveTuttiFrutti(ByVal frm As Form, ByVal ctrl As Control)
    Dim typ As String
    'Stop
    Dim prefix As String = frm.Name + "__"
    For Each subctrl As Control In ctrl.Controls
      typ = subctrl.GetType().ToString

      If typ = "System.Windows.Forms.TextBox" Then
        Me.para(prefix + subctrl.Name) = CType(subctrl, TextBox).Text
      End If
      If typ = "System.Windows.Forms.ComboBox" Then
        Me.para(prefix + subctrl.Name) = CType(subctrl, ComboBox).Text
      End If
      If typ = "System.Windows.Forms.CheckBox" Then
        Me.para(prefix + subctrl.Name) = IIf(CType(subctrl, CheckBox).Checked, "TRUE", "FALSE")
      End If
      If typ = "System.Windows.Forms.NumericUpDown" Then
        Me.para(prefix + subctrl.Name) = CType(subctrl, NumericUpDown).Value
      End If
      If typ = "System.Windows.Forms.RadioButton" Then
        Dim radioBox As RadioButton = subctrl
        If radioBox.Checked AndAlso radioBox.Name.Contains("__") Then
          Dim paras() As String = Split(subctrl.Name, "__")
          Me.para(prefix + paras(0)) = paras(1)
        End If
      End If

      If subctrl.Controls.Count > 0 Then recursive_saveTuttiFrutti(frm, subctrl)
    Next
  End Sub


  ': ========== Private Funktionen ====================

  Private Sub readFile()
    On Error Resume Next
    Err.Clear()

    If Not My.Computer.FileSystem.FileExists(m_paraFileSpec) Then Exit Sub

    Dim cont() As String = _
       Split(My.Computer.FileSystem.ReadAllText(m_paraFileSpec), vbNewLine)

    Dim line(), lineString As String
    For Each lineString In cont
      line = Split(lineString, tabDelimiter)
      If line.Length < 2 Then Continue For

      m_content.Add(line(0), Replace(line(1), "|�ZS�|", vbNewLine))
      Debug.Print(lineString)
      'Stop
    Next

    If Err.Number <> 0 Then MsgBox("beim Laden der Einstellungen ist ein Fehler aufgetreten:" + vbNewLine + Err.Description + vbNewLine + "(cls_globPara)")


  End Sub

  Sub saveParaFile()
    Dim cont As String = ""
    Dim key, item As String

    For Each key In m_content.Keys
      item = m_content.Item(key)
      item = Replace(item, vbNewLine, "|�ZS�|")
      cont += key + tabDelimiter + item + tabDelimiter + vbNewLine
    Next
    'MsgBox(cont)
    My.Computer.FileSystem.WriteAllText(m_paraFileSpec, cont, False)
  End Sub




End Class
