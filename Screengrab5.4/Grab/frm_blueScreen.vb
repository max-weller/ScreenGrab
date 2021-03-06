﻿Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports ScreenGrab6.vbAccelerator.Components.HotKey

Public Class frm_blueScreen
  Dim aktUploadDestFilename As String

  Structure HistoryItem
    Dim isUpload As Boolean
    Dim url As String
    Dim pic As Image
    Dim x, y, xx, yy As Integer
  End Structure

  Public Sub AddToHistory(ByVal item As HistoryItem)
    'If glob.para("frm_options__chkEnableHistory", "FALSE") = "TRUE" Then
    '  lstHistory.Items.Insert(0, item)
    'End If
  End Sub

  Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    MyBase.WndProc(m)
    'If m.Msg = WindowsMessages.WM_NCPAINT Then
    '  Dim rgn = m.WParam
    '  If rgn = 1 Then rgn = IntPtr.Zero

    '  '  Dim region1 As Region = Region.FromHrgn(rgn)

    '  'Dim hdc = GetDCEx(m.HWnd, rgn, DeviceContextValues.Window Or DeviceContextValues.IntersectRgn _
    '  '      Or DeviceContextValues.Cache Or DeviceContextValues.ClipSiblings)

    '  Dim r As New RECT
    '  GetWindowRect(m.HWnd, r)

    '  Dim g = Graphics.FromHwnd(m.HWnd) 'Graphics.FromHdc(hdc)
    '  g.DrawIcon(Me.Icon, 3, 3)
    '  g.DrawString("hallo Welt hallo Welt hallo Welt hallo Welt hallo Welt hallo Welt ", Me.Font, Brushes.Black, 3, 3)
    '  g.Dispose()

    'End If

  End Sub

  'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  'Dim oBitmap As New Bitmap(pic_viewPartial.Width, pic_viewPartial.Height)

  'End Sub

  Private Sub tmr_checkAsyncKeyState_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_checkAsyncKeyState.Tick
    onTimerEvent()

  End Sub

  Sub openFilePre(ByVal filespec As String)
    pnlOpenedFile.Show()

    txtOpenedFile.Text = filespec
    picOpenedFile.Image = Icon.ExtractAssociatedIcon(filespec).ToBitmap

    Dim ext = IO.Path.GetExtension(filespec).ToUpper
    If ext = ".JPG" Or ext = ".GIF" Or ext = ".PNG" Or ext = ".BMP" Then
      lnkOpenfile.Enabled = True
      lnkAddcolfile.Enabled = True
    Else
      lnkOpenfile.Enabled = False
      lnkAddcolfile.Enabled = False
    End If

  End Sub

  Private Sub frm_blueScreen_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
    'If e.Data.GetDataPresent("UniformResourceLocatorW") Then
    '  Dim ms As IO.MemoryStream = e.Data.GetData("UniformResourceLocatorW")
    '  Dim sw As New IO.StreamReader(ms)
    '  openFilePre(sw.ReadToEnd)
    '  sw.Close()
    'End If
    If e.Data.GetDataPresent("FileDrop") Then
      Dim files() As String = e.Data.GetData("FileDrop")
      If files.Length = 1 Then
        openFilePre(files(0))

      End If

    End If
  End Sub

  Private Sub frm_blueScreen_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
    'If e.Data.GetDataPresent("UniformResourceLocatorW") Then
    '  e.Effect = DragDropEffects.Copy
    'End If
    If e.Data.GetDataPresent("FileDrop") Then
      e.Effect = DragDropEffects.Copy
    End If

  End Sub

  Private Sub frm_blueScreen_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

  End Sub

  Private Sub frm_blueScreen_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    glob.saveFormPos(Me)
    glob.saveTuttiFrutti(Me)
    Hide()
    If glob.para("frm_options__chkAutoUpdate", "TRUE") = "TRUE" AndAlso checkForUpdate() Then
      frm_softwareUpdate.Show()
      frm_softwareUpdate.shutdownOnClose = True
      frm_softwareUpdate.startDownload()
      e.Cancel = True
    End If
  End Sub

  Private Sub frm_blueScreen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.Shift Then
      If e.KeyCode = Keys.Right Then _
        setImageSize(partialImageSize.Width + If(e.Control, 1, 16), partialImageSize.Height, True)

      If e.KeyCode = Keys.Up Then _
        setImageSize(partialImageSize.Width, partialImageSize.Height - If(e.Control, 1, 16), True)

      If e.KeyCode = Keys.Down Then _
        setImageSize(partialImageSize.Width, partialImageSize.Height + If(e.Control, 1, 16), True)

      If e.KeyCode = Keys.Left Then _
        setImageSize(partialImageSize.Width - If(e.Control, 1, 16), partialImageSize.Height, True)

    Else
      If e.KeyCode = Keys.Right Then
        deltaX -= If(e.Control, 1, 16)
        updatePartialView()
        pic_viewPartial.Refresh()
      End If
      If e.KeyCode = Keys.Up Then
        deltaY += If(e.Control, 1, 16)
        updatePartialView()
        pic_viewPartial.Refresh()
      End If
      If e.KeyCode = Keys.Down Then
        deltaY -= If(e.Control, 1, 16)
        updatePartialView()
        pic_viewPartial.Refresh()
      End If
      If e.KeyCode = Keys.Left Then
        deltaX += If(e.Control, 1, 16)
        updatePartialView()
        pic_viewPartial.Refresh()
      End If
      If e.Control And e.KeyCode = Keys.V Then
        btnPaste_Click(Nothing, Nothing)
        e.SuppressKeyPress = True : e.Handled = True
      End If
      If e.Control And e.KeyCode = Keys.C Then
        btnCopy_Click(Nothing, Nothing)
        e.SuppressKeyPress = True : e.Handled = True
      End If
    End If
    'Pfeiltasten einkassieren
    If e.KeyCode >= 37 And e.KeyCode <= 40 Then e.SuppressKeyPress = True : e.Handled = True
  End Sub

  Private Sub frm_blueScreen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    On Error Resume Next
    If e.KeyChar = "+"c Then
      tbrZoom.Value += 1
      cmbZoom.Text = tbrZoom.Value.ToString + "%"
      e.Handled = True
      'tslZoom.Text = cmbZoom.Text
    End If
    If e.KeyChar = "-"c Then
      tbrZoom.Value -= 1
      cmbZoom.Text = tbrZoom.Value.ToString + "%"
      e.Handled = True
      'tslZoom.Text = cmbZoom.Text
    End If
  End Sub

  Private Sub frm_blueScreen_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
    If e.Control And e.KeyCode = Keys.Enter Then
      'frm_tempScreenShotName.initTempUpload()
      btnSaveToWeb_Click(Nothing, Nothing)
    End If
    If e.Control And (e.KeyCode = Keys.T) Then
      onCollage()
    End If
    If e.Control And (e.KeyCode = Keys.U) Then
      btnSaveToWeb_Click(Nothing, Nothing)
    End If
    If e.Control And (e.KeyCode = Keys.P) Then
      btnPrint_Click(Nothing, Nothing)
    End If
    If e.Control And e.KeyCode = Keys.Q Then
      Me.Close()
    End If
    If e.Control And e.KeyCode = Keys.Oemcomma Then
      OptionenToolStripMenuItem_Click(Nothing, Nothing)
    End If
    'If e.KeyCode = Keys.F3 Or (e.Control And (e.KeyCode = Keys.U Or e.KeyCode = Keys.H Or e.KeyCode = Keys.Enter)) Then
    '  frm_saveFile.urlMode = False
    '  frm_saveFile.ShowDialog()
    'End If

    If e.Control And e.KeyCode = Keys.S Then
      save()
    End If

    If e.KeyCode = Keys.F2 Then
      openGrabWindow()
    End If

    If e.KeyCode = Keys.Add Or e.KeyCode = Keys.Subtract Or e.KeyCode = Keys.Oemplus Or e.KeyCode = Keys.OemMinus Then
      cmbZoom_SelectedIndexChanged(Nothing, Nothing)
    End If
    If (e.KeyCode = Keys.D0 Or e.KeyCode = Keys.NumPad0) And e.Control Then
      tbrZoom.Value = 100
      cmbZoom.Text = tbrZoom.Value.ToString + "%"
      cmbZoom_SelectedIndexChanged(Nothing, Nothing)
    End If

  End Sub

  Private Sub frm_blueScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    FRM = Me
    Me.Text = "ScreenGrab " + My.Application.Info.Version.ToString(2)

    ' CheckForIllegalCrossThreadCalls = False

    IO.Directory.CreateDirectory(IO.Path.Combine(glob.configDir, "IconCache"))

    glob.readTuttiFrutti(Me)
    glob.readFormPos(Me)
    'txtDIZ.Text = glob.para("diz")

    mwRegisterSelf()
    interproc_init()

    'If glob.para("user") <> "" Then
    '  Dim userData = Split(RC4StringDecrypt(glob.para("user"), kData), ":")
    '  If userData.Length = 2 Then doLogin(userData(0), userData(1), True)
    'End If
    'If twLoginuser = "" Then
    '  If Not onChangeLogin() Then Application.Exit() : Exit Sub
    'End If


    Try
      FRM.pnlViewPartial.BackColor = ColorTranslator.FromHtml(glob.para("frm_options__txtMainWinBG", "#eeeeee"))
    Catch : End Try


    initHotkeys()
    If chk_blueScreenMode.Checked = False Then
      '''''''''''''''''''''''''' openGrabWindow()
    End If

    GrabToolStripMenuItem.ShortcutKeyDisplayString = _
        hotkeyToString(glob.para("HotkeyKey", "71"), glob.para("HotkeyModifier", "8"))

    Show()
  End Sub


  Private Sub frm_blueScreen_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    If chk_blueScreenMode.Checked Then
      setImageSize(pic_viewPartial.Width, pic_viewPartial.Height, False)

    End If
  End Sub

  Private Sub pic_viewPartial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_viewPartial.Click

  End Sub

  Public Sub New()
    'Stop
    ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
    InitializeComponent()

    ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
  End Sub

  'Private Sub btnMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  deltaY += 1
  '  updatePartialView()
  'End Sub

  'Private Sub btnMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  deltaY -= 1
  '  updatePartialView()
  'End Sub

  'Private Sub btnMoveLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  deltaX += 1
  '  updatePartialView()
  'End Sub

  'Private Sub btnMoveRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  deltaX -= 1
  '  updatePartialView()
  'End Sub

  Private Sub tbrZoom_valueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbrZoom.ValueChanged
    'Stop
    cmbZoom.Text = tbrZoom.Value.ToString + "%"

    cmbZoom_SelectedIndexChanged(Nothing, Nothing)
  End Sub

  Private Sub cmbZoom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
  Handles cmbZoom.SelectedIndexChanged, cmbZoom.LostFocus
    'tslZoom.Text = cmbZoom.Text
    Try
      tbrZoom.Value = Val(cmbZoom.Text)
    Catch ex As Exception
      cmbZoom.Text = tbrZoom.Value.ToString + "%"
    End Try
    tmr_asyncUpdatePartialView.Enabled = True
  End Sub

  Private Sub tmr_asyncUpdatePartialView_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_asyncUpdatePartialView.Tick
    tmr_asyncUpdatePartialView.Enabled = False

    If Not chk_blueScreenMode.Checked Then
      setImageSize(Val(txtImageSizeWidth.Text), Val(txtImageSizeHeight.Text), False)
    End If
    'updatePartialView()
  End Sub


  Function savePicture(ByVal filespec As String) As Boolean
    Try
      Dim pic As System.Drawing.Image = getCompleteImage()
      'SavePng(filespec, pic, txtPngQuality.Value)
      If pic Is Nothing Then MsgBox("bitte erst einen Screenshot machen!") : Exit Function
      SaveImage(filespec, pic)
      Return True
    Catch ex As Exception
      MsgBox("Fehler beim Speichern der temporären Datei" + vbNewLine + vbNewLine + ex.Message)
      Return False
    End Try

  End Function


  Sub save()
    Dim file As String = Now().ToString("yyMMdd-HHmmss")
    If glob.para("frm_options__chkAlwaysUseDefaultFolder", "FALSE") = "TRUE" Then
      savePicture(IO.Path.Combine(glob.para("frm_options__txtDefaultFolder"), file + ".png"))
    Else
      With SaveFileDialog1
        .Title = "Bild speichern unter ..."
        .FileName = file
        .Filter = "PNG - Portable Network Graphics|*.png|JPG - JPG/JPEG Format|*.jpg|GIF - Compuserve GIF|*.gif|BMP - Windows Bitmap|*.bmp|Alle Dateien (*.*)|*.*)"
        .InitialDirectory = glob.para("frm_options__txtDefaultFolder")

        If .ShowDialog = Windows.Forms.DialogResult.OK Then
          savePicture(.FileName)
        End If
      End With
    End If
  End Sub

  'Private Sub btnSaveImage_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
  '  If e.Button = Windows.Forms.MouseButtons.Right Then
  '    With OpenFileDialog1
  '      .Title = "Datei öffnen"
  '      .Filter = "JPEG-Bild (*.jpg)|*.jpg|Alle Dateien (*.*)|*.*)"
  '      .InitialDirectory = glob.para("frm_options__txtDefaultFolder")

  '      If .ShowDialog = Windows.Forms.DialogResult.OK Then
  '        SaveJpeg(.FileName, getCompleteImage(), 100)

  '      End If

  '    End With
  '  End If
  '  If e.Button = Windows.Forms.MouseButtons.Left Then
  '    save()
  '  End If
  'End Sub


  'Private Sub btnInsertText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  If pic_viewPartial.Image Is Nothing Then
  '    MsgBox("Zuerst 'Texte löschen' anklicken!", MsgBoxStyle.Information, "Zeichnen")
  '    Exit Sub
  '  End If
  '  Dim g As Graphics = Graphics.FromImage(pic_viewPartial.Image)

  '  Dim xPos, yPos As Integer
  '  xPos = CInt(txtPaintPosX.Text)
  '  yPos = CInt(txtPaintPosY.Text)


  '  Dim oColor As Color = fntdialog_insertText.Color

  '  Dim oBrush As Brush = New SolidBrush(Color.FromArgb(166, oColor.R, oColor.G, oColor.B))

  '  Dim fnt As Font = fntdialog_insertText.Font
  '  Dim si As SizeF = g.MeasureString(txtInsertText.Text, fnt, getDestSize())

  '  Dim re As New Rectangle(xPos - 5, yPos - 5, si.Width + 11, si.Height + 11)
  '  g.FillRectangle(oBrush, re)


  '  Dim oBrush2 As Brush = New SolidBrush(Color.FromArgb(255, 255, 255, 255))

  '  g.DrawString(txtInsertText.Text, fnt, oBrush2, xPos, yPos)

  '  pic_viewPartial.Refresh()


  'End Sub

  'Private Sub pic_viewPartial_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pic_viewPartial.MouseClick
  '  If e.Button = Windows.Forms.MouseButtons.Left Then
  '    txtPaintPosX.Text = e.X.ToString
  '    txtPaintPosY.Text = e.Y.ToString
  '  ElseIf e.Button = Windows.Forms.MouseButtons.Middle Then
  '    frm_sidebar.Show()
  '  Else

  '    TabControl1.Visible = Not TabControl1.Visible

  '  End If

  'End Sub

  'Private Sub btn_insertText_changeFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  fntdialog_insertText.ShowDialog()
  '  lab_insertText_fontPreview.Font = fntdialog_insertText.Font
  '  lab_insertText_fontPreview.BackColor = fntdialog_insertText.Color
  '  lab_insertText_fontPreview.Text = fntdialog_insertText.Font.SizeInPoints.ToString + "pt | " + fntdialog_insertText.Font.Name

  'End Sub

  'Private Sub btn_paintTest1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  Dim si As Size = getDestSize()
  '  pic_viewPartial.Image = New Bitmap(si.Width, si.Height)

  'End Sub


  'Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  'upload()
  '  frm_saveFile.urlMode = False
  '  frm_saveFile.Enabled = True
  '  frm_saveFile.ShowDialog()

  'End Sub


  'Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  On Error Resume Next
  '  Dim ls() As String = GetServerDirList("/twiki_temp")
  '  If ls(0) Is Nothing Then
  '    MsgBox("Die Dateiliste konnte aus unergründlichen Gründen nicht geladen werden..." + vbNewLine + "Wenn du diese Meldung auch nach mehreren Versuchen noch bekommst, wende dich bitte an den Autor.", MsgBoxStyle.Critical, "ScreenGrab 3 - Fehler!")
  '    Exit Sub
  '  End If

  '  lvImageBrowser.Items.Clear()
  '  Dim count As Integer = 0
  '  For Each file As String In ls
  '    If Not file.EndsWith(".jpg") Then Continue For
  '    Dim im As Image = ImageFromWeb("http://teamwiki.de/twiki_temp/" + file)
  '    imlBrowseListviewPreview.Images.Add("F_" + file, im)

  '    lvImageBrowser.Items.Add(file, "F_" + file).Tag = "http://teamwiki.de/twiki_temp/" + file

  '    count += 1
  '    'If count > 20 Then Exit For

  '  Next
  'End Sub


  'Private Sub tsbCheckForUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  startWebUpdate(False)

  'End Sub

  'Private Sub tsbGetfilesize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

  '  showpicinfo()

  'End Sub
  'Sub showpicinfo()
  '  On Error Resume Next
  '  Dim filespec As String = System.IO.Path.GetTempPath() + "tmpupload.png"
  '  Dim pic As System.Drawing.Image = getCompleteImage(Me)
  '  savePicture(filespec)
  '  Dim filesize As String = CreateNiceFileSize(FileLen(filespec))
  '  IO.File.Delete(filespec)

  '  tsl_Debug1.Text = "Bildgröße: " + filesize

  '  With frm_pictureinfo.ListView1
  '    .Items.Clear()
  '    .Items.Add("Dateigröße:").SubItems.Add(filesize)
  '    .Items.Add("Bildabmessungen:").SubItems.Add(pic.Width & " x " & pic.Height)

  '  End With

  '  If frm_pictureinfo.Visible = False Then
  '    frm_pictureinfo.Top = Me.Top
  '    frm_pictureinfo.Left = Me.Left + 50
  '  End If

  '  frm_pictureinfo.Show()

  'End Sub

  'Private Sub tsbGrab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  openGrabWindow()
  'End Sub

  'Private Sub tsbView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  frm_viewer.Show()

  'End Sub

  'Private Sub tsbMDI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  frm_mdiViewer.Show()
  '  frm_mdiViewer.addPicClient()
  'End Sub

  'Private Sub tsbURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  frm_saveFile.urlMode = True
  '  frm_saveFile.ShowDialog()
  'End Sub

  Private Sub btnPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaste.Click, EinfügenToolStripMenuItem.Click
    If Clipboard.ContainsImage() Then
      'Stop
      Dim img As Image = Clipboard.GetImage()

      loadImage(img)

    ElseIf Clipboard.ContainsText Then
      Dim tx As String = Clipboard.GetText
      If tx.ToLower.StartsWith("http://") Then
        'If MsgBox("Willst du das Bild von der folgenden URL in den ScreenGrab laden?" + _
        '          vbNewLine + "Achtung: Das Programm reagiert während dem Download nicht!" + _
        '          vbNewLine + vbNewLine + tx, MsgBoxStyle.OkCancel + MsgBoxStyle.Question, _
        '          "ScreenGrab 3") = MsgBoxResult.Cancel Then Exit Sub

        Dim im As Image
        'tsl_Debug1.Text = "Bitte warten, das Programm wird einen Moment nicht reagieren ..."
        Application.DoEvents()
        Try
          'pnlSidebar.Enabled = False
          Cursor = Cursors.WaitCursor
          im = ImageFromWeb(tx)
          'tsl_Debug1.Text = "Bild geladen."
          loadImage(im)
        Catch
          'tsl_Debug1.Text = "Fehler beim Laden des Bildes."
        End Try
        'pnlSidebar.Enabled = True
        Cursor = Cursors.Default
      End If
    End If
  End Sub

  Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click, KopierenToolStripMenuItem.Click
    onCopy()
  End Sub

  Sub onCopy()
    'On Error Resume Next
    Dim pic As System.Drawing.Image = getCompleteImage()

    Clipboard.SetImage(pic)

  End Sub

  Private Sub btnGrab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
  Handles btnGrab.Click, GrabToolStripMenuItem.Click
    openGrabWindow()
  End Sub

  Private Sub OptionenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionenToolStripMenuItem.Click
    frm_options.confpage = 0
  End Sub

  Private Sub btnSaveLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveLocal.Click, SpeichernUnterToolStripMenuItem.Click
    save()
  End Sub

  Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
  Handles btnPrint.Click, DruckenToolStripMenuItem.Click
    Dim ppv As New frm_printDialog
    ppv.showimg = getCompleteImage()
    ppv.ShowDialog()

  End Sub

  Private Sub chk_blueScreenMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_blueScreenMode.CheckedChanged
    updatePartialView()

    If chk_blueScreenMode.Checked Then
      pic_viewPartial.Dock = DockStyle.Fill
      setImageSize(pnlViewPartial.Width, pnlViewPartial.Height, True)
    Else
      pic_viewPartial.Dock = DockStyle.None
      setImageSize(pnlViewPartial.Width / tbrZoom.Value * 100, pnlViewPartial.Height / tbrZoom.Value * 100, True)
    End If
  End Sub

  Private Sub MDIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
  Handles MDIToolStripMenuItem.Click, btnCollage.Click
    onCollage()
  End Sub

  Sub onCollage()
    'If MDI Is Nothing Then
    '  MDI = New frm_mdiViewer2
    'End If
    'MDI.Show()
    'MDI.Activate()
    'MDI.addPicClient()
    qq_chkAutoCollage.Enabled = True
    qq_chkAutoCollage.Checked = True
    oIntWin.EnsureAppRunning("collage", "collage")
    Dim tmpFilespec As String = IO.Path.Combine(IO.Path.GetTempPath, "ScreenGrab-to-Collage.png")
    Dim image = getCompleteImage()
    If image IsNot Nothing Then
      image.Save(tmpFilespec, System.Drawing.Imaging.ImageFormat.Png)
      oIntWin.SendCommand("collage", "AddImage", tmpFilespec)
    End If
  End Sub

  Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
    openGrabWindow()

  End Sub

  Private Sub ImmerImVordergrundToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImmerImVordergrundToolStripMenuItem.Click
    Me.TopMost = ImmerImVordergrundToolStripMenuItem.Checked

  End Sub

  Private Sub pnlSidebar_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlSidebar.MouseDown, Label3.MouseDown, Label2.MouseDown
    FormMoveTricky(Me.Handle)

  End Sub


  Private Sub btnSaveToWeb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
  Handles btnSaveToWeb.Click, ImTeamWikiSpeichernToolStripMenuItem.Click
    Dim pic As System.Drawing.Image = getCompleteImage()
    If pic Is Nothing Then MsgBox("bitte erst einen Screenshot machen!") : Return

    Dim tempFile = IO.Path.Combine(IO.Path.GetTempPath(), "grab5_temp.png")
    SaveImage(tempFile, pic)

    Using dlg As New frm_commonUpload
      dlg.sourceFilespec = tempFile
      dlg.ShowDialog()
    End Using

    ''Dim fu As New frm_uploadFile
    ''fu.UploadLocalFile = New String() {tempFile}
    ''fu.useLastFilename(True)

    ''fu.ShowDialog()

  End Sub

  Private Sub lnkUploadfile_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkUploadfile.LinkClicked
    Stop
    'Dim fu As New frm_uploadFile
    'fu.UploadLocalFile = New String() {txtOpenedFile.Text}
    'fu.showLocalFilePanel(txtOpenedFile.Text)

    'If fu.ShowDialog() = Windows.Forms.DialogResult.OK Then _
    '  pnlOpenedFile.Hide()
  End Sub

  Private Sub lnkOpenfile_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkOpenfile.LinkClicked
    loadImage(Image.FromFile(txtOpenedFile.Text))
    pnlOpenedFile.Hide()
  End Sub

  Private Sub lnkAddcolfile_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAddcolfile.LinkClicked
    'frm_mdiViewer.Show()
    'frm_mdiViewer.Activate()
    'frm_mdiViewer.addPicClient(Image.FromFile(txtOpenedFile.Text))
    'pnlOpenedFile.Hide()
  End Sub

  Private Sub lnkCloseFileBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkCloseFileBar.Click
    pnlOpenedFile.Hide()
  End Sub

  Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    frm_helpFile.Show()
    frm_helpFile.Activate()
  End Sub


  Private Sub txtImageSizeWidth_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
  Handles txtImageSizeWidth.KeyUp, txtImageSizeHeight.KeyUp
    If e.KeyCode = Keys.Enter Then
      setImageSize(txtImageSizeWidth.Text, txtImageSizeHeight.Text, True)
      lblPressEnter.Hide()
    End If
  End Sub
  Private Sub txtImageSizeWidth_TextChanged(ByVal sender As System.Object, ByVal e As KeyEventArgs) _
  Handles txtImageSizeWidth.KeyDown, txtImageSizeHeight.KeyDown
    lblPressEnter.Show()
  End Sub

  Private Sub lstHistory_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstHistory.DoubleClick
    If lstHistory.SelectedIndex = -1 Then Return
    Dim itm As HistoryItem = lstHistory.Items(lstHistory.SelectedIndex)
    If itm.isUpload Then
      Process.Start(itm.url)
    Else
      fullDesktopImage = itm.pic
      deltaX = itm.x : deltaY = itm.y
      setImageSize(itm.xx, itm.yy, True)
    End If
  End Sub

  Private Sub lstHistory_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lstHistory.DrawItem
    Dim itm As HistoryItem = lstHistory.Items(e.Index)
    e.DrawBackground()
    If itm.isUpload Then
      e.Graphics.DrawString("Bild hochgeladen:", lstHistory.Font, New SolidBrush(e.ForeColor), e.Bounds.Left + 5, e.Bounds.Top + 5)
      e.Graphics.DrawString(itm.url, lstHistory.Font, New SolidBrush(If(e.ForeColor = Color.White, Color.White, Color.Blue)), e.Bounds.Left + 5, e.Bounds.Top + 25)

    Else
      'e.Graphics.DrawImage(itm.pic, e.Bounds.Left + 5, e.Bounds.Top + 5, 70, 70)
      e.Graphics.DrawImage(itm.pic, New Rectangle(e.Bounds.Left + 5, e.Bounds.Top + 5, 100, 70), New Rectangle(itm.x, itm.y, itm.xx, itm.yy), GraphicsUnit.Pixel)
    End If
    e.DrawFocusRectangle()
  End Sub

  Private Sub lstHistory_MeasureItem(ByVal sender As Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles lstHistory.MeasureItem
    Dim itm As HistoryItem = lstHistory.Items(e.Index)
    If itm.isUpload Then
      e.ItemHeight = 40
    Else
      e.ItemHeight = 80
    End If
    e.ItemWidth = lstHistory.Width
  End Sub

  Private Sub lstHistory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstHistory.SelectedIndexChanged

  End Sub

  'Private Sub chkViewHist_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkViewHist.CheckedChanged
  '  lstHistory.Visible = chkViewHist.Checked
  '  pnlViewPartial.Left = lstHistory.Left + If(lstHistory.Visible, lstHistory.Width, 0)
  '  pnlViewPartial.Width = Me.ClientSize.Width - pnlViewPartial.Left
  '  setImageSize(partialImageSize.Width, partialImageSize.Height, True)
  'End Sub

  Private Sub btnInsertWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertWord.Click
    onInsertToWord()
  End Sub
  Sub onInsertToWord()
    If Not IsWordInitialised() Then CreateWordInstance()
    InsertImage(getCompleteImage())
  End Sub

  Private Sub InfoScreenGrabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoScreenGrabToolStripMenuItem.Click
    Using a As New AboutBox
      a.ShowDialog()
    End Using
  End Sub
End Class