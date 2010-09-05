﻿Imports System.Runtime.InteropServices

Module sys_editWindowMenu

  <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
  Function AppendMenu(ByVal hMenu As IntPtr, ByVal uFlags As MenuFlags, ByVal uIDNewItem As Int32, ByVal lpNewItem As String) As Boolean
  End Function

  <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
  Function InsertMenu(ByVal hMenu As IntPtr, ByVal uPosition As Integer, _
       ByVal uFlags As Integer, ByVal uIDNewItem As Integer, _
       <MarshalAs(UnmanagedType.LPTStr)> ByVal lpNewItem As String) As Boolean
  End Function

  <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
  Function ModifyMenu(ByVal hMenu As IntPtr, ByVal uPosition As Integer, ByVal uFlags As MenuFlags, ByVal uIDNewItem As Int32, ByVal lpNewItem As String) As Boolean
  End Function

  <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
  Function CheckMenuItem(ByVal hMenu As IntPtr, ByVal uIDCheckItem As Integer, ByVal uCheck As MenuFlags) As Boolean
  End Function

  <DllImport("user32.dll", CallingConvention:=CallingConvention.Cdecl)> _
  Function GetSystemMenu(ByVal hWnd As IntPtr, ByVal bRevert As Boolean) As IntPtr
  End Function

  <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
  Function GetMenu(ByVal hWnd As IntPtr) As IntPtr
  End Function

  <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
  Function GetMenuItemCount(ByVal hMenu As IntPtr) As Integer
  End Function

  <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
  Function GetMenuItemID(ByVal hMenu As IntPtr, ByVal nPos As Integer) As Integer
  End Function

  <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
  Function RemoveMenu(ByVal hMenu As IntPtr, ByVal uPosition As Integer, ByVal uFlags As Integer) As Boolean
  End Function

  <DllImport("user32.dll", CallingConvention:=CallingConvention.Cdecl)> _
  Public Function EnableMenuItem(ByVal hMenu As IntPtr, ByVal wIDEnableItem As UInteger, ByVal wEnable As MenuFlags) As IntPtr
  End Function

  <Flags()> _
  Enum MenuFlags
    MF_INSERT = &H0
    MF_CHANGE = &H80
    MF_APPEND = &H100
    MF_DELETE = &H200
    MF_REMOVE = &H1000

    MF_BYCOMMAND = &H0
    MF_BYPOSITION = &H400

    MF_SEPARATOR = &H800

    MF_ENABLED = &H0
    MF_GRAYED = &H1
    MF_DISABLED = &H2

    MF_UNCHECKED = &H0
    MF_CHECKED = &H8
    MF_USECHECKBITMAPS = &H200

    MF_STRING = &H0
    MF_BITMAP = &H4
    MF_OWNERDRAW = &H100

    MF_POPUP = &H10
    MF_MENUBARBREAK = &H20
    MF_MENUBREAK = &H40

    MF_UNHILITE = &H0
    MF_HILITE = &H80

    MF_DEFAULT = &H1000
    MF_SYSMENU = &H2000
    MF_HELP = &H4000
    MF_RIGHTJUSTIFY = &H4000

    MF_MOUSESELECT = &H8000
    MF_END = &H80  '/* Obsolete -- only used by old RES files */

    MFT_STRING = MF_STRING
    MFT_BITMAP = MF_BITMAP
    MFT_MENUBARBREAK = MF_MENUBARBREAK
    MFT_MENUBREAK = MF_MENUBREAK
    MFT_OWNERDRAW = MF_OWNERDRAW
    MFT_RADIOCHECK = &H200
    MFT_SEPARATOR = MF_SEPARATOR
    MFT_RIGHTORDER = &H2000
    MFT_RIGHTJUSTIFY = MF_RIGHTJUSTIFY

    MFS_GRAYED = &H3
    MFS_DISABLED = MFS_GRAYED
    MFS_CHECKED = MF_CHECKED
    MFS_HILITE = MF_HILITE
    MFS_ENABLED = MF_ENABLED
    MFS_UNCHECKED = MF_UNCHECKED
    MFS_UNHILITE = MF_UNHILITE
    MFS_DEFAULT = MF_DEFAULT
  End Enum

  Public Enum WindowsMessages As Integer
    WM_NULL = &H0
    WM_CREATE = &H1
    WM_DESTROY = &H2
    WM_MOVE = &H3
    WM_SIZE = &H5
    WM_ACTIVATE = &H6
    WM_SETFOCUS = &H7
    WM_KILLFOCUS = &H8
    WM_ENABLE = &HA
    WM_SETREDRAW = &HB
    WM_SETTEXT = &HC
    WM_GETTEXT = &HD
    WM_GETTEXTLENGTH = &HE
    WM_PAINT = &HF
    WM_CLOSE = &H10
    WM_QUERYENDSESSION = &H11
    WM_QUERYOPEN = &H13
    WM_ENDSESSION = &H16
    WM_QUIT = &H12
    WM_ERASEBKGND = &H14
    WM_SYSCOLORCHANGE = &H15
    WM_SHOWWINDOW = &H18
    WM_WININICHANGE = &H1A
    WM_SETTINGCHANGE = &H1A
    WM_DEVMODECHANGE = &H1B
    WM_ACTIVATEAPP = &H1C
    WM_FONTCHANGE = &H1D
    WM_TIMECHANGE = &H1E
    WM_CANCELMODE = &H1F
    WM_SETCURSOR = &H20
    WM_MOUSEACTIVATE = &H21
    WM_CHILDACTIVATE = &H22
    WM_QUEUESYNC = &H23
    WM_GETMINMAXINFO = &H24
    WM_PAINTICON = &H26
    WM_ICONERASEBKGND = &H27
    WM_NEXTDLGCTL = &H28
    WM_SPOOLERSTATUS = &H2A
    WM_DRAWITEM = &H2B
    WM_MEASUREITEM = &H2C
    WM_DELETEITEM = &H2D
    WM_VKEYTOITEM = &H2E
    WM_CHARTOITEM = &H2F
    WM_SETFONT = &H30
    WM_GETFONT = &H31
    WM_SETHOTKEY = &H32
    WM_GETHOTKEY = &H33
    WM_QUERYDRAGICON = &H37
    WM_COMPAREITEM = &H39
    WM_GETOBJECT = &H3D
    WM_COMPACTING = &H41
    WM_COMMNOTIFY = &H44
    WM_WINDOWPOSCHANGING = &H46
    WM_WINDOWPOSCHANGED = &H47
    WM_POWER = &H48
    WM_COPYDATA = &H4A
    WM_CANCELJOURNAL = &H4B
    WM_NOTIFY = &H4E
    WM_INPUTLANGCHANGEREQUEST = &H50
    WM_INPUTLANGCHANGE = &H51
    WM_TCARD = &H52
    WM_HELP = &H53
    WM_USERCHANGED = &H54
    WM_NOTIFYFORMAT = &H55
    WM_CONTEXTMENU = &H7B
    WM_STYLECHANGING = &H7C
    WM_STYLECHANGED = &H7D
    WM_DISPLAYCHANGE = &H7E
    WM_GETICON = &H7F
    WM_SETICON = &H80
    WM_NCCREATE = &H81
    WM_NCDESTROY = &H82
    WM_NCCALCSIZE = &H83
    WM_NCHITTEST = &H84
    WM_NCPAINT = &H85
    WM_NCACTIVATE = &H86
    WM_GETDLGCODE = &H87
    WM_SYNCPAINT = &H88
    WM_NCMOUSEMOVE = &HA0
    WM_NCLBUTTONDOWN = &HA1
    WM_NCLBUTTONUP = &HA2
    WM_NCLBUTTONDBLCLK = &HA3
    WM_NCRBUTTONDOWN = &HA4
    WM_NCRBUTTONUP = &HA5
    WM_NCRBUTTONDBLCLK = &HA6
    WM_NCMBUTTONDOWN = &HA7
    WM_NCMBUTTONUP = &HA8
    WM_NCMBUTTONDBLCLK = &HA9
    WM_NCXBUTTONDOWN = &HAB
    WM_NCXBUTTONUP = &HAC
    WM_NCXBUTTONDBLCLK = &HAD
    WM_INPUT = &HFF
    WM_KEYFIRST = &H100
    WM_KEYDOWN = &H100
    WM_KEYUP = &H101
    WM_CHAR = &H102
    WM_DEADCHAR = &H103
    WM_SYSKEYDOWN = &H104
    WM_SYSKEYUP = &H105
    WM_SYSCHAR = &H106
    WM_SYSDEADCHAR = &H107
    WM_UNICHAR = &H109
    WM_KEYLAST_NT501 = &H109
    UNICODE_NOCHAR = &HFFFF
    WM_KEYLAST_PRE501 = &H108
    WM_IME_STARTCOMPOSITION = &H10D
    WM_IME_ENDCOMPOSITION = &H10E
    WM_IME_COMPOSITION = &H10F
    WM_IME_KEYLAST = &H10F
    WM_INITDIALOG = &H110
    WM_COMMAND = &H111
    WM_SYSCOMMAND = &H112
    WM_TIMER = &H113
    WM_HSCROLL = &H114
    WM_VSCROLL = &H115
    WM_INITMENU = &H116
    WM_INITMENUPOPUP = &H117
    WM_MENUSELECT = &H11F
    WM_MENUCHAR = &H120
    WM_ENTERIDLE = &H121
    WM_MENURBUTTONUP = &H122
    WM_MENUDRAG = &H123
    WM_MENUGETOBJECT = &H124
    WM_UNINITMENUPOPUP = &H125
    WM_MENUCOMMAND = &H126
    WM_CHANGEUISTATE = &H127
    WM_UPDATEUISTATE = &H128
    WM_QUERYUISTATE = &H129
    WM_CTLCOLORMSGBOX = &H132
    WM_CTLCOLOREDIT = &H133
    WM_CTLCOLORLISTBOX = &H134
    WM_CTLCOLORBTN = &H135
    WM_CTLCOLORDLG = &H136
    WM_CTLCOLORSCROLLBAR = &H137
    WM_CTLCOLORSTATIC = &H138
    WM_MOUSEFIRST = &H200
    WM_MOUSEMOVE = &H200
    WM_LBUTTONDOWN = &H201
    WM_LBUTTONUP = &H202
    WM_LBUTTONDBLCLK = &H203
    WM_RBUTTONDOWN = &H204
    WM_RBUTTONUP = &H205
    WM_RBUTTONDBLCLK = &H206
    WM_MBUTTONDOWN = &H207
    WM_MBUTTONUP = &H208
    WM_MBUTTONDBLCLK = &H209
    WM_MOUSEWHEEL = &H20A
    WM_XBUTTONDOWN = &H20B
    WM_XBUTTONUP = &H20C
    WM_XBUTTONDBLCLK = &H20D
    WM_MOUSELAST_5 = &H20D
    WM_MOUSELAST_4 = &H20A
    WM_MOUSELAST_PRE_4 = &H209
    WM_PARENTNOTIFY = &H210
    WM_ENTERMENULOOP = &H211
    WM_EXITMENULOOP = &H212
    WM_NEXTMENU = &H213
    WM_SIZING = &H214
    WM_CAPTURECHANGED = &H215
    WM_MOVING = &H216
    WM_POWERBROADCAST = &H218
    WM_DEVICECHANGE = &H219
    WM_MDICREATE = &H220
    WM_MDIDESTROY = &H221
    WM_MDIACTIVATE = &H222
    WM_MDIRESTORE = &H223
    WM_MDINEXT = &H224
    WM_MDIMAXIMIZE = &H225
    WM_MDITILE = &H226
    WM_MDICASCADE = &H227
    WM_MDIICONARRANGE = &H228
    WM_MDIGETACTIVE = &H229
    WM_MDISETMENU = &H230
    WM_ENTERSIZEMOVE = &H231
    WM_EXITSIZEMOVE = &H232
    WM_DROPFILES = &H233
    WM_MDIREFRESHMENU = &H234
    WM_IME_SETCONTEXT = &H281
    WM_IME_NOTIFY = &H282
    WM_IME_CONTROL = &H283
    WM_IME_COMPOSITIONFULL = &H284
    WM_IME_SELECT = &H285
    WM_IME_CHAR = &H286
    WM_IME_REQUEST = &H288
    WM_IME_KEYDOWN = &H290
    WM_IME_KEYUP = &H291
    WM_MOUSEHOVER = &H2A1
    WM_MOUSELEAVE = &H2A3
    WM_NCMOUSEHOVER = &H2A0
    WM_NCMOUSELEAVE = &H2A2
    WM_WTSSESSION_CHANGE = &H2B1
    WM_TABLET_FIRST = &H2C0
    WM_TABLET_LAST = &H2DF
    WM_CUT = &H300
    WM_COPY = &H301
    WM_PASTE = &H302
    WM_CLEAR = &H303
    WM_UNDO = &H304
    WM_RENDERFORMAT = &H305
    WM_RENDERALLFORMATS = &H306
    WM_DESTROYCLIPBOARD = &H307
    WM_DRAWCLIPBOARD = &H308
    WM_PAINTCLIPBOARD = &H309
    WM_VSCROLLCLIPBOARD = &H30A
    WM_SIZECLIPBOARD = &H30B
    WM_ASKCBFORMATNAME = &H30C
    WM_CHANGECBCHAIN = &H30D
    WM_HSCROLLCLIPBOARD = &H30E
    WM_QUERYNEWPALETTE = &H30F
    WM_PALETTEISCHANGING = &H310
    WM_PALETTECHANGED = &H311
    WM_HOTKEY = &H312
    WM_PRINT = &H317
    WM_PRINTCLIENT = &H318
    WM_APPCOMMAND = &H319
    WM_THEMECHANGED = &H31A
    WM_HANDHELDFIRST = &H358
    WM_HANDHELDLAST = &H35F
    WM_AFXFIRST = &H360
    WM_AFXLAST = &H37F
    WM_PENWINFIRST = &H380
    WM_PENWINLAST = &H38F
    WM_APP = &H8000
    WM_USER = &H400
    EM_GETSEL = &HB0
    EM_SETSEL = &HB1
    EM_GETRECT = &HB2
    EM_SETRECT = &HB3
    EM_SETRECTNP = &HB4
    EM_SCROLL = &HB5
    EM_LINESCROLL = &HB6
    EM_SCROLLCARET = &HB7
    EM_GETMODIFY = &HB8
    EM_SETMODIFY = &HB9
    EM_GETLINECOUNT = &HBA
    EM_LINEINDEX = &HBB
    EM_SETHANDLE = &HBC
    EM_GETHANDLE = &HBD
    EM_GETTHUMB = &HBE
    EM_LINELENGTH = &HC1
    EM_REPLACESEL = &HC2
    EM_GETLINE = &HC4
    EM_LIMITTEXT = &HC5
    EM_CANUNDO = &HC6
    EM_UNDO = &HC7
    EM_FMTLINES = &HC8
    EM_LINEFROMCHAR = &HC9
    EM_SETTABSTOPS = &HCB
    EM_SETPASSWORDCHAR = &HCC
    EM_EMPTYUNDOBUFFER = &HCD
    EM_GETFIRSTVISIBLELINE = &HCE
    EM_SETREADONLY = &HCF
    EM_SETWORDBREAKPROC = &HD0
    EM_GETWORDBREAKPROC = &HD1
    EM_GETPASSWORDCHAR = &HD2
    EM_SETMARGINS = &HD3
    EM_GETMARGINS = &HD4
    EM_SETLIMITTEXT = EM_LIMITTEXT
    EM_GETLIMITTEXT = &HD5
    EM_POSFROMCHAR = &HD6
    EM_CHARFROMPOS = &HD7
    EM_SETIMESTATUS = &HD8
    EM_GETIMESTATUS = &HD9
    BM_GETCHECK = &HF0
    BM_SETCHECK = &HF1
    BM_GETSTATE = &HF2
    BM_SETSTATE = &HF3
    BM_SETSTYLE = &HF4
    BM_CLICK = &HF5
    BM_GETIMAGE = &HF6
    BM_SETIMAGE = &HF7
    STM_SETICON = &H170
    STM_GETICON = &H171
    STM_SETIMAGE = &H172
    STM_GETIMAGE = &H173
    STM_MSGMAX = &H174
    DM_GETDEFID = (WM_USER + 0)
    DM_SETDEFID = (WM_USER + 1)
    DM_REPOSITION = (WM_USER + 2)
    LB_ADDSTRING = &H180
    LB_INSERTSTRING = &H181
    LB_DELETESTRING = &H182
    LB_SELITEMRANGEEX = &H183
    LB_RESETCONTENT = &H184
    LB_SETSEL = &H185
    LB_SETCURSEL = &H186
    LB_GETSEL = &H187
    LB_GETCURSEL = &H188
    LB_GETTEXT = &H189
    LB_GETTEXTLEN = &H18A
    LB_GETCOUNT = &H18B
    LB_SELECTSTRING = &H18C
    LB_DIR = &H18D
    LB_GETTOPINDEX = &H18E
    LB_FINDSTRING = &H18F
    LB_GETSELCOUNT = &H190
    LB_GETSELITEMS = &H191
    LB_SETTABSTOPS = &H192
    LB_GETHORIZONTALEXTENT = &H193
    LB_SETHORIZONTALEXTENT = &H194
    LB_SETCOLUMNWIDTH = &H195
    LB_ADDFILE = &H196
    LB_SETTOPINDEX = &H197
    LB_GETITEMRECT = &H198
    LB_GETITEMDATA = &H199
    LB_SETITEMDATA = &H19A
    LB_SELITEMRANGE = &H19B
    LB_SETANCHORINDEX = &H19C
    LB_GETANCHORINDEX = &H19D
    LB_SETCARETINDEX = &H19E
    LB_GETCARETINDEX = &H19F
    LB_SETITEMHEIGHT = &H1A0
    LB_GETITEMHEIGHT = &H1A1
    LB_FINDSTRINGEXACT = &H1A2
    LB_SETLOCALE = &H1A5
    LB_GETLOCALE = &H1A6
    LB_SETCOUNT = &H1A7
    LB_INITSTORAGE = &H1A8
    LB_ITEMFROMPOINT = &H1A9
    LB_MULTIPLEADDSTRING = &H1B1
    LB_GETLISTBOXINFO = &H1B2
    LB_MSGMAX_501 = &H1B3
    LB_MSGMAX_WCE4 = &H1B1
    LB_MSGMAX_4 = &H1B0
    LB_MSGMAX_PRE4 = &H1A8
    CB_GETEDITSEL = &H140
    CB_LIMITTEXT = &H141
    CB_SETEDITSEL = &H142
    CB_ADDSTRING = &H143
    CB_DELETESTRING = &H144
    CB_DIR = &H145
    CB_GETCOUNT = &H146
    CB_GETCURSEL = &H147
    CB_GETLBTEXT = &H148
    CB_GETLBTEXTLEN = &H149
    CB_INSERTSTRING = &H14A
    CB_RESETCONTENT = &H14B
    CB_FINDSTRING = &H14C
    CB_SELECTSTRING = &H14D
    CB_SETCURSEL = &H14E
    CB_SHOWDROPDOWN = &H14F
    CB_GETITEMDATA = &H150
    CB_SETITEMDATA = &H151
    CB_GETDROPPEDCONTROLRECT = &H152
    CB_SETITEMHEIGHT = &H153
    CB_GETITEMHEIGHT = &H154
    CB_SETEXTENDEDUI = &H155
    CB_GETEXTENDEDUI = &H156
    CB_GETDROPPEDSTATE = &H157
    CB_FINDSTRINGEXACT = &H158
    CB_SETLOCALE = &H159
    CB_GETLOCALE = &H15A
    CB_GETTOPINDEX = &H15B
    CB_SETTOPINDEX = &H15C
    CB_GETHORIZONTALEXTENT = &H15D
    CB_SETHORIZONTALEXTENT = &H15E
    CB_GETDROPPEDWIDTH = &H15F
    CB_SETDROPPEDWIDTH = &H160
    CB_INITSTORAGE = &H161
    CB_MULTIPLEADDSTRING = &H163
    CB_GETCOMBOBOXINFO = &H164
    CB_MSGMAX_501 = &H165
    CB_MSGMAX_WCE400 = &H163
    CB_MSGMAX_400 = &H162
    CB_MSGMAX_PRE400 = &H15B
    SBM_SETPOS = &HE0
    SBM_GETPOS = &HE1
    SBM_SETRANGE = &HE2
    SBM_SETRANGEREDRAW = &HE6
    SBM_GETRANGE = &HE3
    SBM_ENABLE_ARROWS = &HE4
    SBM_SETSCROLLINFO = &HE9
    SBM_GETSCROLLINFO = &HEA
    SBM_GETSCROLLBARINFO = &HEB
    LVM_FIRST = &H1000
    ' ListView messages
    TV_FIRST = &H1100
    ' TreeView messages
    HDM_FIRST = &H1200
    ' Header messages
    TCM_FIRST = &H1300
    ' Tab control messages
    PGM_FIRST = &H1400
    ' Pager control messages
    ECM_FIRST = &H1500
    ' Edit control messages
    BCM_FIRST = &H1600
    ' Button control messages
    CBM_FIRST = &H1700
    ' Combobox control messages
    CCM_FIRST = &H2000
    ' Common control shared messages
    CCM_LAST = (CCM_FIRST + &H200)
    CCM_SETBKCOLOR = (CCM_FIRST + 1)
    CCM_SETCOLORSCHEME = (CCM_FIRST + 2)
    CCM_GETCOLORSCHEME = (CCM_FIRST + 3)
    CCM_GETDROPTARGET = (CCM_FIRST + 4)
    CCM_SETUNICODEFORMAT = (CCM_FIRST + 5)
    CCM_GETUNICODEFORMAT = (CCM_FIRST + 6)
    CCM_SETVERSION = (CCM_FIRST + &H7)
    CCM_GETVERSION = (CCM_FIRST + &H8)
    CCM_SETNOTIFYWINDOW = (CCM_FIRST + &H9)
    CCM_SETWINDOWTHEME = (CCM_FIRST + &HB)
    CCM_DPISCALE = (CCM_FIRST + &HC)
    HDM_GETITEMCOUNT = (HDM_FIRST + 0)
    HDM_INSERTITEMA = (HDM_FIRST + 1)
    HDM_INSERTITEMW = (HDM_FIRST + 10)
    HDM_DELETEITEM = (HDM_FIRST + 2)
    HDM_GETITEMA = (HDM_FIRST + 3)
    HDM_GETITEMW = (HDM_FIRST + 11)
    HDM_SETITEMA = (HDM_FIRST + 4)
    HDM_SETITEMW = (HDM_FIRST + 12)
    HDM_LAYOUT = (HDM_FIRST + 5)
    HDM_HITTEST = (HDM_FIRST + 6)
    HDM_GETITEMRECT = (HDM_FIRST + 7)
    HDM_SETIMAGELIST = (HDM_FIRST + 8)
    HDM_GETIMAGELIST = (HDM_FIRST + 9)
    HDM_ORDERTOINDEX = (HDM_FIRST + 15)
    HDM_CREATEDRAGIMAGE = (HDM_FIRST + 16)
    HDM_GETORDERARRAY = (HDM_FIRST + 17)
    HDM_SETORDERARRAY = (HDM_FIRST + 18)
    HDM_SETHOTDIVIDER = (HDM_FIRST + 19)
    HDM_SETBITMAPMARGIN = (HDM_FIRST + 20)
    HDM_GETBITMAPMARGIN = (HDM_FIRST + 21)
    HDM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT
    HDM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT
    HDM_SETFILTERCHANGETIMEOUT = (HDM_FIRST + 22)
    HDM_EDITFILTER = (HDM_FIRST + 23)
    HDM_CLEARFILTER = (HDM_FIRST + 24)
    TB_ENABLEBUTTON = (WM_USER + 1)
    TB_CHECKBUTTON = (WM_USER + 2)
    TB_PRESSBUTTON = (WM_USER + 3)
    TB_HIDEBUTTON = (WM_USER + 4)
    TB_INDETERMINATE = (WM_USER + 5)
    TB_MARKBUTTON = (WM_USER + 6)
    TB_ISBUTTONENABLED = (WM_USER + 9)
    TB_ISBUTTONCHECKED = (WM_USER + 10)
    TB_ISBUTTONPRESSED = (WM_USER + 11)
    TB_ISBUTTONHIDDEN = (WM_USER + 12)
    TB_ISBUTTONINDETERMINATE = (WM_USER + 13)
    TB_ISBUTTONHIGHLIGHTED = (WM_USER + 14)
    TB_SETSTATE = (WM_USER + 17)
    TB_GETSTATE = (WM_USER + 18)
    TB_ADDBITMAP = (WM_USER + 19)
    TB_ADDBUTTONSA = (WM_USER + 20)
    TB_INSERTBUTTONA = (WM_USER + 21)
    TB_ADDBUTTONS = (WM_USER + 20)
    TB_INSERTBUTTON = (WM_USER + 21)
    TB_DELETEBUTTON = (WM_USER + 22)
    TB_GETBUTTON = (WM_USER + 23)
    TB_BUTTONCOUNT = (WM_USER + 24)
    TB_COMMANDTOINDEX = (WM_USER + 25)
    TB_SAVERESTOREA = (WM_USER + 26)
    TB_SAVERESTOREW = (WM_USER + 76)
    TB_CUSTOMIZE = (WM_USER + 27)
    TB_ADDSTRINGA = (WM_USER + 28)
    TB_ADDSTRINGW = (WM_USER + 77)
    TB_GETITEMRECT = (WM_USER + 29)
    TB_BUTTONSTRUCTSIZE = (WM_USER + 30)
    TB_SETBUTTONSIZE = (WM_USER + 31)
    TB_SETBITMAPSIZE = (WM_USER + 32)
    TB_AUTOSIZE = (WM_USER + 33)
    TB_GETTOOLTIPS = (WM_USER + 35)
    TB_SETTOOLTIPS = (WM_USER + 36)
    TB_SETPARENT = (WM_USER + 37)
    TB_SETROWS = (WM_USER + 39)
    TB_GETROWS = (WM_USER + 40)
    TB_SETCMDID = (WM_USER + 42)
    TB_CHANGEBITMAP = (WM_USER + 43)
    TB_GETBITMAP = (WM_USER + 44)
    TB_GETBUTTONTEXTA = (WM_USER + 45)
    TB_GETBUTTONTEXTW = (WM_USER + 75)
    TB_REPLACEBITMAP = (WM_USER + 46)
    TB_SETINDENT = (WM_USER + 47)
    TB_SETIMAGELIST = (WM_USER + 48)
    TB_GETIMAGELIST = (WM_USER + 49)
    TB_LOADIMAGES = (WM_USER + 50)
    TB_GETRECT = (WM_USER + 51)
    TB_SETHOTIMAGELIST = (WM_USER + 52)
    TB_GETHOTIMAGELIST = (WM_USER + 53)
    TB_SETDISABLEDIMAGELIST = (WM_USER + 54)
    TB_GETDISABLEDIMAGELIST = (WM_USER + 55)
    TB_SETSTYLE = (WM_USER + 56)
    TB_GETSTYLE = (WM_USER + 57)
    TB_GETBUTTONSIZE = (WM_USER + 58)
    TB_SETBUTTONWIDTH = (WM_USER + 59)
    TB_SETMAXTEXTROWS = (WM_USER + 60)
    TB_GETTEXTROWS = (WM_USER + 61)
    TB_GETOBJECT = (WM_USER + 62)
    TB_GETHOTITEM = (WM_USER + 71)
    TB_SETHOTITEM = (WM_USER + 72)
    TB_SETANCHORHIGHLIGHT = (WM_USER + 73)
    TB_GETANCHORHIGHLIGHT = (WM_USER + 74)
    TB_MAPACCELERATORA = (WM_USER + 78)
    TB_GETINSERTMARK = (WM_USER + 79)
    TB_SETINSERTMARK = (WM_USER + 80)
    TB_INSERTMARKHITTEST = (WM_USER + 81)
    TB_MOVEBUTTON = (WM_USER + 82)
    TB_GETMAXSIZE = (WM_USER + 83)
    TB_SETEXTENDEDSTYLE = (WM_USER + 84)
    TB_GETEXTENDEDSTYLE = (WM_USER + 85)
    TB_GETPADDING = (WM_USER + 86)
    TB_SETPADDING = (WM_USER + 87)
    TB_SETINSERTMARKCOLOR = (WM_USER + 88)
    TB_GETINSERTMARKCOLOR = (WM_USER + 89)
    TB_SETCOLORSCHEME = CCM_SETCOLORSCHEME
    TB_GETCOLORSCHEME = CCM_GETCOLORSCHEME
    TB_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT
    TB_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT
    TB_MAPACCELERATORW = (WM_USER + 90)
    TB_GETBITMAPFLAGS = (WM_USER + 41)
    TB_GETBUTTONINFOW = (WM_USER + 63)
    TB_SETBUTTONINFOW = (WM_USER + 64)
    TB_GETBUTTONINFOA = (WM_USER + 65)
    TB_SETBUTTONINFOA = (WM_USER + 66)
    TB_INSERTBUTTONW = (WM_USER + 67)
    TB_ADDBUTTONSW = (WM_USER + 68)
    TB_HITTEST = (WM_USER + 69)
    TB_SETDRAWTEXTFLAGS = (WM_USER + 70)
    TB_GETSTRINGW = (WM_USER + 91)
    TB_GETSTRINGA = (WM_USER + 92)
    TB_GETMETRICS = (WM_USER + 101)
    TB_SETMETRICS = (WM_USER + 102)
    TB_SETWINDOWTHEME = CCM_SETWINDOWTHEME
    RB_INSERTBANDA = (WM_USER + 1)
    RB_DELETEBAND = (WM_USER + 2)
    RB_GETBARINFO = (WM_USER + 3)
    RB_SETBARINFO = (WM_USER + 4)
    RB_GETBANDINFO = (WM_USER + 5)
    RB_SETBANDINFOA = (WM_USER + 6)
    RB_SETPARENT = (WM_USER + 7)
    RB_HITTEST = (WM_USER + 8)
    RB_GETRECT = (WM_USER + 9)
    RB_INSERTBANDW = (WM_USER + 10)
    RB_SETBANDINFOW = (WM_USER + 11)
    RB_GETBANDCOUNT = (WM_USER + 12)
    RB_GETROWCOUNT = (WM_USER + 13)
    RB_GETROWHEIGHT = (WM_USER + 14)
    RB_IDTOINDEX = (WM_USER + 16)
    RB_GETTOOLTIPS = (WM_USER + 17)
    RB_SETTOOLTIPS = (WM_USER + 18)
    RB_SETBKCOLOR = (WM_USER + 19)
    RB_GETBKCOLOR = (WM_USER + 20)
    RB_SETTEXTCOLOR = (WM_USER + 21)
    RB_GETTEXTCOLOR = (WM_USER + 22)
    RB_SIZETORECT = (WM_USER + 23)
    RB_SETCOLORSCHEME = CCM_SETCOLORSCHEME
    RB_GETCOLORSCHEME = CCM_GETCOLORSCHEME
    RB_BEGINDRAG = (WM_USER + 24)
    RB_ENDDRAG = (WM_USER + 25)
    RB_DRAGMOVE = (WM_USER + 26)
    RB_GETBARHEIGHT = (WM_USER + 27)
    RB_GETBANDINFOW = (WM_USER + 28)
    RB_GETBANDINFOA = (WM_USER + 29)
    RB_MINIMIZEBAND = (WM_USER + 30)
    RB_MAXIMIZEBAND = (WM_USER + 31)
    RB_GETDROPTARGET = (CCM_GETDROPTARGET)
    RB_GETBANDBORDERS = (WM_USER + 34)
    RB_SHOWBAND = (WM_USER + 35)
    RB_SETPALETTE = (WM_USER + 37)
    RB_GETPALETTE = (WM_USER + 38)
    RB_MOVEBAND = (WM_USER + 39)
    RB_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT
    RB_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT
    RB_GETBANDMARGINS = (WM_USER + 40)
    RB_SETWINDOWTHEME = CCM_SETWINDOWTHEME
    RB_PUSHCHEVRON = (WM_USER + 43)
    TTM_ACTIVATE = (WM_USER + 1)
    TTM_SETDELAYTIME = (WM_USER + 3)
    TTM_ADDTOOLA = (WM_USER + 4)
    TTM_ADDTOOLW = (WM_USER + 50)
    TTM_DELTOOLA = (WM_USER + 5)
    TTM_DELTOOLW = (WM_USER + 51)
    TTM_NEWTOOLRECTA = (WM_USER + 6)
    TTM_NEWTOOLRECTW = (WM_USER + 52)
    TTM_RELAYEVENT = (WM_USER + 7)
    TTM_GETTOOLINFOA = (WM_USER + 8)
    TTM_GETTOOLINFOW = (WM_USER + 53)
    TTM_SETTOOLINFOA = (WM_USER + 9)
    TTM_SETTOOLINFOW = (WM_USER + 54)
    TTM_HITTESTA = (WM_USER + 10)
    TTM_HITTESTW = (WM_USER + 55)
    TTM_GETTEXTA = (WM_USER + 11)
    TTM_GETTEXTW = (WM_USER + 56)
    TTM_UPDATETIPTEXTA = (WM_USER + 12)
    TTM_UPDATETIPTEXTW = (WM_USER + 57)
    TTM_GETTOOLCOUNT = (WM_USER + 13)
    TTM_ENUMTOOLSA = (WM_USER + 14)
    TTM_ENUMTOOLSW = (WM_USER + 58)
    TTM_GETCURRENTTOOLA = (WM_USER + 15)
    TTM_GETCURRENTTOOLW = (WM_USER + 59)
    TTM_WINDOWFROMPOINT = (WM_USER + 16)
    TTM_TRACKACTIVATE = (WM_USER + 17)
    TTM_TRACKPOSITION = (WM_USER + 18)
    TTM_SETTIPBKCOLOR = (WM_USER + 19)
    TTM_SETTIPTEXTCOLOR = (WM_USER + 20)
    TTM_GETDELAYTIME = (WM_USER + 21)
    TTM_GETTIPBKCOLOR = (WM_USER + 22)
    TTM_GETTIPTEXTCOLOR = (WM_USER + 23)
    TTM_SETMAXTIPWIDTH = (WM_USER + 24)
    TTM_GETMAXTIPWIDTH = (WM_USER + 25)
    TTM_SETMARGIN = (WM_USER + 26)
    TTM_GETMARGIN = (WM_USER + 27)
    TTM_POP = (WM_USER + 28)
    TTM_UPDATE = (WM_USER + 29)
    TTM_GETBUBBLESIZE = (WM_USER + 30)
    TTM_ADJUSTRECT = (WM_USER + 31)
    TTM_SETTITLEA = (WM_USER + 32)
    TTM_SETTITLEW = (WM_USER + 33)
    TTM_POPUP = (WM_USER + 34)
    TTM_GETTITLE = (WM_USER + 35)
    TTM_SETWINDOWTHEME = CCM_SETWINDOWTHEME
    SB_SETTEXTA = (WM_USER + 1)
    SB_SETTEXTW = (WM_USER + 11)
    SB_GETTEXTA = (WM_USER + 2)
    SB_GETTEXTW = (WM_USER + 13)
    SB_GETTEXTLENGTHA = (WM_USER + 3)
    SB_GETTEXTLENGTHW = (WM_USER + 12)
    SB_SETPARTS = (WM_USER + 4)
    SB_GETPARTS = (WM_USER + 6)
    SB_GETBORDERS = (WM_USER + 7)
    SB_SETMINHEIGHT = (WM_USER + 8)
    SB_SIMPLE = (WM_USER + 9)
    SB_GETRECT = (WM_USER + 10)
    SB_ISSIMPLE = (WM_USER + 14)
    SB_SETICON = (WM_USER + 15)
    SB_SETTIPTEXTA = (WM_USER + 16)
    SB_SETTIPTEXTW = (WM_USER + 17)
    SB_GETTIPTEXTA = (WM_USER + 18)
    SB_GETTIPTEXTW = (WM_USER + 19)
    SB_GETICON = (WM_USER + 20)
    SB_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT
    SB_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT
    SB_SETBKCOLOR = CCM_SETBKCOLOR
    SB_SIMPLEID = &HFF
    TBM_GETPOS = (WM_USER)
    TBM_GETRANGEMIN = (WM_USER + 1)
    TBM_GETRANGEMAX = (WM_USER + 2)
    TBM_GETTIC = (WM_USER + 3)
    TBM_SETTIC = (WM_USER + 4)
    TBM_SETPOS = (WM_USER + 5)
    TBM_SETRANGE = (WM_USER + 6)
    TBM_SETRANGEMIN = (WM_USER + 7)
    TBM_SETRANGEMAX = (WM_USER + 8)
    TBM_CLEARTICS = (WM_USER + 9)
    TBM_SETSEL = (WM_USER + 10)
    TBM_SETSELSTART = (WM_USER + 11)
    TBM_SETSELEND = (WM_USER + 12)
    TBM_GETPTICS = (WM_USER + 14)
    TBM_GETTICPOS = (WM_USER + 15)
    TBM_GETNUMTICS = (WM_USER + 16)
    TBM_GETSELSTART = (WM_USER + 17)
    TBM_GETSELEND = (WM_USER + 18)
    TBM_CLEARSEL = (WM_USER + 19)
    TBM_SETTICFREQ = (WM_USER + 20)
    TBM_SETPAGESIZE = (WM_USER + 21)
    TBM_GETPAGESIZE = (WM_USER + 22)
    TBM_SETLINESIZE = (WM_USER + 23)
    TBM_GETLINESIZE = (WM_USER + 24)
    TBM_GETTHUMBRECT = (WM_USER + 25)
    TBM_GETCHANNELRECT = (WM_USER + 26)
    TBM_SETTHUMBLENGTH = (WM_USER + 27)
    TBM_GETTHUMBLENGTH = (WM_USER + 28)
    TBM_SETTOOLTIPS = (WM_USER + 29)
    TBM_GETTOOLTIPS = (WM_USER + 30)
    TBM_SETTIPSIDE = (WM_USER + 31)
    TBM_SETBUDDY = (WM_USER + 32)
    TBM_GETBUDDY = (WM_USER + 33)
    TBM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT
    TBM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT
    DL_BEGINDRAG = (WM_USER + 133)
    DL_DRAGGING = (WM_USER + 134)
    DL_DROPPED = (WM_USER + 135)
    DL_CANCELDRAG = (WM_USER + 136)
    UDM_SETRANGE = (WM_USER + 101)
    UDM_GETRANGE = (WM_USER + 102)
    UDM_SETPOS = (WM_USER + 103)
    UDM_GETPOS = (WM_USER + 104)
    UDM_SETBUDDY = (WM_USER + 105)
    UDM_GETBUDDY = (WM_USER + 106)
    UDM_SETACCEL = (WM_USER + 107)
    UDM_GETACCEL = (WM_USER + 108)
    UDM_SETBASE = (WM_USER + 109)
    UDM_GETBASE = (WM_USER + 110)
    UDM_SETRANGE32 = (WM_USER + 111)
    UDM_GETRANGE32 = (WM_USER + 112)
    UDM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT
    UDM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT
    UDM_SETPOS32 = (WM_USER + 113)
    UDM_GETPOS32 = (WM_USER + 114)
    PBM_SETRANGE = (WM_USER + 1)
    PBM_SETPOS = (WM_USER + 2)
    PBM_DELTAPOS = (WM_USER + 3)
    PBM_SETSTEP = (WM_USER + 4)
    PBM_STEPIT = (WM_USER + 5)
    PBM_SETRANGE32 = (WM_USER + 6)
    PBM_GETRANGE = (WM_USER + 7)
    PBM_GETPOS = (WM_USER + 8)
    PBM_SETBARCOLOR = (WM_USER + 9)
    PBM_SETBKCOLOR = CCM_SETBKCOLOR
    HKM_SETHOTKEY = (WM_USER + 1)
    HKM_GETHOTKEY = (WM_USER + 2)
    HKM_SETRULES = (WM_USER + 3)
    LVM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT
    LVM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT
    LVM_GETBKCOLOR = (LVM_FIRST + 0)
    LVM_SETBKCOLOR = (LVM_FIRST + 1)
    LVM_GETIMAGELIST = (LVM_FIRST + 2)
    LVM_SETIMAGELIST = (LVM_FIRST + 3)
    LVM_GETITEMCOUNT = (LVM_FIRST + 4)
    LVM_GETITEMA = (LVM_FIRST + 5)
    LVM_GETITEMW = (LVM_FIRST + 75)
    LVM_SETITEMA = (LVM_FIRST + 6)
    LVM_SETITEMW = (LVM_FIRST + 76)
    LVM_INSERTITEMA = (LVM_FIRST + 7)
    LVM_INSERTITEMW = (LVM_FIRST + 77)
    LVM_DELETEITEM = (LVM_FIRST + 8)
    LVM_DELETEALLITEMS = (LVM_FIRST + 9)
    LVM_GETCALLBACKMASK = (LVM_FIRST + 10)
    LVM_SETCALLBACKMASK = (LVM_FIRST + 11)
    LVM_FINDITEMA = (LVM_FIRST + 13)
    LVM_FINDITEMW = (LVM_FIRST + 83)
    LVM_GETITEMRECT = (LVM_FIRST + 14)
    LVM_SETITEMPOSITION = (LVM_FIRST + 15)
    LVM_GETITEMPOSITION = (LVM_FIRST + 16)
    LVM_GETSTRINGWIDTHA = (LVM_FIRST + 17)
    LVM_GETSTRINGWIDTHW = (LVM_FIRST + 87)
    LVM_HITTEST = (LVM_FIRST + 18)
    LVM_ENSUREVISIBLE = (LVM_FIRST + 19)
    LVM_SCROLL = (LVM_FIRST + 20)
    LVM_REDRAWITEMS = (LVM_FIRST + 21)
    LVM_ARRANGE = (LVM_FIRST + 22)
    LVM_EDITLABELA = (LVM_FIRST + 23)
    LVM_EDITLABELW = (LVM_FIRST + 118)
    LVM_GETEDITCONTROL = (LVM_FIRST + 24)
    LVM_GETCOLUMNA = (LVM_FIRST + 25)
    LVM_GETCOLUMNW = (LVM_FIRST + 95)
    LVM_SETCOLUMNA = (LVM_FIRST + 26)
    LVM_SETCOLUMNW = (LVM_FIRST + 96)
    LVM_INSERTCOLUMNA = (LVM_FIRST + 27)
    LVM_INSERTCOLUMNW = (LVM_FIRST + 97)
    LVM_DELETECOLUMN = (LVM_FIRST + 28)
    LVM_GETCOLUMNWIDTH = (LVM_FIRST + 29)
    LVM_SETCOLUMNWIDTH = (LVM_FIRST + 30)
    LVM_CREATEDRAGIMAGE = (LVM_FIRST + 33)
    LVM_GETVIEWRECT = (LVM_FIRST + 34)
    LVM_GETTEXTCOLOR = (LVM_FIRST + 35)
    LVM_SETTEXTCOLOR = (LVM_FIRST + 36)
    LVM_GETTEXTBKCOLOR = (LVM_FIRST + 37)
    LVM_SETTEXTBKCOLOR = (LVM_FIRST + 38)
    LVM_GETTOPINDEX = (LVM_FIRST + 39)
    LVM_GETCOUNTPERPAGE = (LVM_FIRST + 40)
    LVM_GETORIGIN = (LVM_FIRST + 41)
    LVM_UPDATE = (LVM_FIRST + 42)
    LVM_SETITEMSTATE = (LVM_FIRST + 43)
    LVM_GETITEMSTATE = (LVM_FIRST + 44)
    LVM_GETITEMTEXTA = (LVM_FIRST + 45)
    LVM_GETITEMTEXTW = (LVM_FIRST + 115)
    LVM_SETITEMTEXTA = (LVM_FIRST + 46)
    LVM_SETITEMTEXTW = (LVM_FIRST + 116)
    LVM_SETITEMCOUNT = (LVM_FIRST + 47)
    LVM_SORTITEMS = (LVM_FIRST + 48)
    LVM_SETITEMPOSITION32 = (LVM_FIRST + 49)
    LVM_GETSELECTEDCOUNT = (LVM_FIRST + 50)
    LVM_GETITEMSPACING = (LVM_FIRST + 51)
    LVM_GETISEARCHSTRINGA = (LVM_FIRST + 52)
    LVM_GETISEARCHSTRINGW = (LVM_FIRST + 117)
    LVM_SETICONSPACING = (LVM_FIRST + 53)
    LVM_SETEXTENDEDLISTVIEWSTYLE = (LVM_FIRST + 54)
    LVM_GETEXTENDEDLISTVIEWSTYLE = (LVM_FIRST + 55)
    LVM_GETSUBITEMRECT = (LVM_FIRST + 56)
    LVM_SUBITEMHITTEST = (LVM_FIRST + 57)
    LVM_SETCOLUMNORDERARRAY = (LVM_FIRST + 58)
    LVM_GETCOLUMNORDERARRAY = (LVM_FIRST + 59)
    LVM_SETHOTITEM = (LVM_FIRST + 60)
    LVM_GETHOTITEM = (LVM_FIRST + 61)
    LVM_SETHOTCURSOR = (LVM_FIRST + 62)
    LVM_GETHOTCURSOR = (LVM_FIRST + 63)
    LVM_APPROXIMATEVIEWRECT = (LVM_FIRST + 64)
    LVM_SETWORKAREAS = (LVM_FIRST + 65)
    LVM_GETWORKAREAS = (LVM_FIRST + 70)
    LVM_GETNUMBEROFWORKAREAS = (LVM_FIRST + 73)
    LVM_GETSELECTIONMARK = (LVM_FIRST + 66)
    LVM_SETSELECTIONMARK = (LVM_FIRST + 67)
    LVM_SETHOVERTIME = (LVM_FIRST + 71)
    LVM_GETHOVERTIME = (LVM_FIRST + 72)
    LVM_SETTOOLTIPS = (LVM_FIRST + 74)
    LVM_GETTOOLTIPS = (LVM_FIRST + 78)
    LVM_SORTITEMSEX = (LVM_FIRST + 81)
    LVM_SETBKIMAGEA = (LVM_FIRST + 68)
    LVM_SETBKIMAGEW = (LVM_FIRST + 138)
    LVM_GETBKIMAGEA = (LVM_FIRST + 69)
    LVM_GETBKIMAGEW = (LVM_FIRST + 139)
    LVM_SETSELECTEDCOLUMN = (LVM_FIRST + 140)
    LVM_SETTILEWIDTH = (LVM_FIRST + 141)
    LVM_SETVIEW = (LVM_FIRST + 142)
    LVM_GETVIEW = (LVM_FIRST + 143)
    LVM_INSERTGROUP = (LVM_FIRST + 145)
    LVM_SETGROUPINFO = (LVM_FIRST + 147)
    LVM_GETGROUPINFO = (LVM_FIRST + 149)
    LVM_REMOVEGROUP = (LVM_FIRST + 150)
    LVM_MOVEGROUP = (LVM_FIRST + 151)
    LVM_MOVEITEMTOGROUP = (LVM_FIRST + 154)
    LVM_SETGROUPMETRICS = (LVM_FIRST + 155)
    LVM_GETGROUPMETRICS = (LVM_FIRST + 156)
    LVM_ENABLEGROUPVIEW = (LVM_FIRST + 157)
    LVM_SORTGROUPS = (LVM_FIRST + 158)
    LVM_INSERTGROUPSORTED = (LVM_FIRST + 159)
    LVM_REMOVEALLGROUPS = (LVM_FIRST + 160)
    LVM_HASGROUP = (LVM_FIRST + 161)
    LVM_SETTILEVIEWINFO = (LVM_FIRST + 162)
    LVM_GETTILEVIEWINFO = (LVM_FIRST + 163)
    LVM_SETTILEINFO = (LVM_FIRST + 164)
    LVM_GETTILEINFO = (LVM_FIRST + 165)
    LVM_SETINSERTMARK = (LVM_FIRST + 166)
    LVM_GETINSERTMARK = (LVM_FIRST + 167)
    LVM_INSERTMARKHITTEST = (LVM_FIRST + 168)
    LVM_GETINSERTMARKRECT = (LVM_FIRST + 169)
    LVM_SETINSERTMARKCOLOR = (LVM_FIRST + 170)
    LVM_GETINSERTMARKCOLOR = (LVM_FIRST + 171)
    LVM_SETINFOTIP = (LVM_FIRST + 173)
    LVM_GETSELECTEDCOLUMN = (LVM_FIRST + 174)
    LVM_ISGROUPVIEWENABLED = (LVM_FIRST + 175)
    LVM_GETOUTLINECOLOR = (LVM_FIRST + 176)
    LVM_SETOUTLINECOLOR = (LVM_FIRST + 177)
    LVM_CANCELEDITLABEL = (LVM_FIRST + 179)
    LVM_MAPINDEXTOID = (LVM_FIRST + 180)
    LVM_MAPIDTOINDEX = (LVM_FIRST + 181)
    TVM_INSERTITEMA = (TV_FIRST + 0)
    TVM_INSERTITEMW = (TV_FIRST + 50)
    TVM_DELETEITEM = (TV_FIRST + 1)
    TVM_EXPAND = (TV_FIRST + 2)
    TVM_GETITEMRECT = (TV_FIRST + 4)
    TVM_GETCOUNT = (TV_FIRST + 5)
    TVM_GETINDENT = (TV_FIRST + 6)
    TVM_SETINDENT = (TV_FIRST + 7)
    TVM_GETIMAGELIST = (TV_FIRST + 8)
    TVM_SETIMAGELIST = (TV_FIRST + 9)
    TVM_GETNEXTITEM = (TV_FIRST + 10)
    TVM_SELECTITEM = (TV_FIRST + 11)
    TVM_GETITEMA = (TV_FIRST + 12)
    TVM_GETITEMW = (TV_FIRST + 62)
    TVM_SETITEMA = (TV_FIRST + 13)
    TVM_SETITEMW = (TV_FIRST + 63)
    TVM_EDITLABELA = (TV_FIRST + 14)
    TVM_EDITLABELW = (TV_FIRST + 65)
    TVM_GETEDITCONTROL = (TV_FIRST + 15)
    TVM_GETVISIBLECOUNT = (TV_FIRST + 16)
    TVM_HITTEST = (TV_FIRST + 17)
    TVM_CREATEDRAGIMAGE = (TV_FIRST + 18)
    TVM_SORTCHILDREN = (TV_FIRST + 19)
    TVM_ENSUREVISIBLE = (TV_FIRST + 20)
    TVM_SORTCHILDRENCB = (TV_FIRST + 21)
    TVM_ENDEDITLABELNOW = (TV_FIRST + 22)
    TVM_GETISEARCHSTRINGA = (TV_FIRST + 23)
    TVM_GETISEARCHSTRINGW = (TV_FIRST + 64)
    TVM_SETTOOLTIPS = (TV_FIRST + 24)
    TVM_GETTOOLTIPS = (TV_FIRST + 25)
    TVM_SETINSERTMARK = (TV_FIRST + 26)
    TVM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT
    TVM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT
    TVM_SETITEMHEIGHT = (TV_FIRST + 27)
    TVM_GETITEMHEIGHT = (TV_FIRST + 28)
    TVM_SETBKCOLOR = (TV_FIRST + 29)
    TVM_SETTEXTCOLOR = (TV_FIRST + 30)
    TVM_GETBKCOLOR = (TV_FIRST + 31)
    TVM_GETTEXTCOLOR = (TV_FIRST + 32)
    TVM_SETSCROLLTIME = (TV_FIRST + 33)
    TVM_GETSCROLLTIME = (TV_FIRST + 34)
    TVM_SETINSERTMARKCOLOR = (TV_FIRST + 37)
    TVM_GETINSERTMARKCOLOR = (TV_FIRST + 38)
    TVM_GETITEMSTATE = (TV_FIRST + 39)
    TVM_SETLINECOLOR = (TV_FIRST + 40)
    TVM_GETLINECOLOR = (TV_FIRST + 41)
    TVM_MAPACCIDTOHTREEITEM = (TV_FIRST + 42)
    TVM_MAPHTREEITEMTOACCID = (TV_FIRST + 43)
    CBEM_INSERTITEMA = (WM_USER + 1)
    CBEM_SETIMAGELIST = (WM_USER + 2)
    CBEM_GETIMAGELIST = (WM_USER + 3)
    CBEM_GETITEMA = (WM_USER + 4)
    CBEM_SETITEMA = (WM_USER + 5)
    CBEM_DELETEITEM = CB_DELETESTRING
    CBEM_GETCOMBOCONTROL = (WM_USER + 6)
    CBEM_GETEDITCONTROL = (WM_USER + 7)
    CBEM_SETEXTENDEDSTYLE = (WM_USER + 14)
    CBEM_GETEXTENDEDSTYLE = (WM_USER + 9)
    CBEM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT
    CBEM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT
    CBEM_SETEXSTYLE = (WM_USER + 8)
    CBEM_GETEXSTYLE = (WM_USER + 9)
    CBEM_HASEDITCHANGED = (WM_USER + 10)
    CBEM_INSERTITEMW = (WM_USER + 11)
    CBEM_SETITEMW = (WM_USER + 12)
    CBEM_GETITEMW = (WM_USER + 13)
    TCM_GETIMAGELIST = (TCM_FIRST + 2)
    TCM_SETIMAGELIST = (TCM_FIRST + 3)
    TCM_GETITEMCOUNT = (TCM_FIRST + 4)
    TCM_GETITEMA = (TCM_FIRST + 5)
    TCM_GETITEMW = (TCM_FIRST + 60)
    TCM_SETITEMA = (TCM_FIRST + 6)
    TCM_SETITEMW = (TCM_FIRST + 61)
    TCM_INSERTITEMA = (TCM_FIRST + 7)
    TCM_INSERTITEMW = (TCM_FIRST + 62)
    TCM_DELETEITEM = (TCM_FIRST + 8)
    TCM_DELETEALLITEMS = (TCM_FIRST + 9)
    TCM_GETITEMRECT = (TCM_FIRST + 10)
    TCM_GETCURSEL = (TCM_FIRST + 11)
    TCM_SETCURSEL = (TCM_FIRST + 12)
    TCM_HITTEST = (TCM_FIRST + 13)
    TCM_SETITEMEXTRA = (TCM_FIRST + 14)
    TCM_ADJUSTRECT = (TCM_FIRST + 40)
    TCM_SETITEMSIZE = (TCM_FIRST + 41)
    TCM_REMOVEIMAGE = (TCM_FIRST + 42)
    TCM_SETPADDING = (TCM_FIRST + 43)
    TCM_GETROWCOUNT = (TCM_FIRST + 44)
    TCM_GETTOOLTIPS = (TCM_FIRST + 45)
    TCM_SETTOOLTIPS = (TCM_FIRST + 46)
    TCM_GETCURFOCUS = (TCM_FIRST + 47)
    TCM_SETCURFOCUS = (TCM_FIRST + 48)
    TCM_SETMINTABWIDTH = (TCM_FIRST + 49)
    TCM_DESELECTALL = (TCM_FIRST + 50)
    TCM_HIGHLIGHTITEM = (TCM_FIRST + 51)
    TCM_SETEXTENDEDSTYLE = (TCM_FIRST + 52)
    TCM_GETEXTENDEDSTYLE = (TCM_FIRST + 53)
    TCM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT
    TCM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT
    ACM_OPENA = (WM_USER + 100)
    ACM_OPENW = (WM_USER + 103)
    ACM_PLAY = (WM_USER + 101)
    ACM_STOP = (WM_USER + 102)
    MCM_FIRST = &H1000
    MCM_GETCURSEL = (MCM_FIRST + 1)
    MCM_SETCURSEL = (MCM_FIRST + 2)
    MCM_GETMAXSELCOUNT = (MCM_FIRST + 3)
    MCM_SETMAXSELCOUNT = (MCM_FIRST + 4)
    MCM_GETSELRANGE = (MCM_FIRST + 5)
    MCM_SETSELRANGE = (MCM_FIRST + 6)
    MCM_GETMONTHRANGE = (MCM_FIRST + 7)
    MCM_SETDAYSTATE = (MCM_FIRST + 8)
    MCM_GETMINREQRECT = (MCM_FIRST + 9)
    MCM_SETCOLOR = (MCM_FIRST + 10)
    MCM_GETCOLOR = (MCM_FIRST + 11)
    MCM_SETTODAY = (MCM_FIRST + 12)
    MCM_GETTODAY = (MCM_FIRST + 13)
    MCM_HITTEST = (MCM_FIRST + 14)
    MCM_SETFIRSTDAYOFWEEK = (MCM_FIRST + 15)
    MCM_GETFIRSTDAYOFWEEK = (MCM_FIRST + 16)
    MCM_GETRANGE = (MCM_FIRST + 17)
    MCM_SETRANGE = (MCM_FIRST + 18)
    MCM_GETMONTHDELTA = (MCM_FIRST + 19)
    MCM_SETMONTHDELTA = (MCM_FIRST + 20)
    MCM_GETMAXTODAYWIDTH = (MCM_FIRST + 21)
    MCM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT
    MCM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT
    DTM_FIRST = &H1000
    DTM_GETSYSTEMTIME = (DTM_FIRST + 1)
    DTM_SETSYSTEMTIME = (DTM_FIRST + 2)
    DTM_GETRANGE = (DTM_FIRST + 3)
    DTM_SETRANGE = (DTM_FIRST + 4)
    DTM_SETFORMATA = (DTM_FIRST + 5)
    DTM_SETFORMATW = (DTM_FIRST + 50)
    DTM_SETMCCOLOR = (DTM_FIRST + 6)
    DTM_GETMCCOLOR = (DTM_FIRST + 7)
    DTM_GETMONTHCAL = (DTM_FIRST + 8)
    DTM_SETMCFONT = (DTM_FIRST + 9)
    DTM_GETMCFONT = (DTM_FIRST + 10)
    PGM_SETCHILD = (PGM_FIRST + 1)
    PGM_RECALCSIZE = (PGM_FIRST + 2)
    PGM_FORWARDMOUSE = (PGM_FIRST + 3)
    PGM_SETBKCOLOR = (PGM_FIRST + 4)
    PGM_GETBKCOLOR = (PGM_FIRST + 5)
    PGM_SETBORDER = (PGM_FIRST + 6)
    PGM_GETBORDER = (PGM_FIRST + 7)
    PGM_SETPOS = (PGM_FIRST + 8)
    PGM_GETPOS = (PGM_FIRST + 9)
    PGM_SETBUTTONSIZE = (PGM_FIRST + 10)
    PGM_GETBUTTONSIZE = (PGM_FIRST + 11)
    PGM_GETBUTTONSTATE = (PGM_FIRST + 12)
    PGM_GETDROPTARGET = CCM_GETDROPTARGET
    BCM_GETIDEALSIZE = (BCM_FIRST + &H1)
    BCM_SETIMAGELIST = (BCM_FIRST + &H2)
    BCM_GETIMAGELIST = (BCM_FIRST + &H3)
    BCM_SETTEXTMARGIN = (BCM_FIRST + &H4)
    BCM_GETTEXTMARGIN = (BCM_FIRST + &H5)
    EM_SETCUEBANNER = (ECM_FIRST + 1)
    EM_GETCUEBANNER = (ECM_FIRST + 2)
    EM_SHOWBALLOONTIP = (ECM_FIRST + 3)
    EM_HIDEBALLOONTIP = (ECM_FIRST + 4)
    CB_SETMINVISIBLE = (CBM_FIRST + 1)
    CB_GETMINVISIBLE = (CBM_FIRST + 2)
    LM_HITTEST = (WM_USER + &H300)
    LM_GETIDEALHEIGHT = (WM_USER + &H301)
    LM_SETITEM = (WM_USER + &H302)
    LM_GETITEM = (WM_USER + &H303)
  End Enum
  Enum HitTestValues2
    HTERROR = -2
    HTTRANSPARENT = -1
    HTNOWHERE = 0
    HTCLIENT = 1
    HTCAPTION = 2
    HTSYSMENU = 3
    HTGROWBOX = 4
    HTMENU = 5
    HTHSCROLL = 6
    HTVSCROLL = 7
    HTMINBUTTON = 8
    HTMAXBUTTON = 9
    HTLEFT = 10
    HTRIGHT = 11
    HTTOP = 12
    HTTOPLEFT = 13
    HTTOPRIGHT = 14
    HTBOTTOM = 15
    HTBOTTOMLEFT = 16
    HTBOTTOMRIGHT = 17
    HTBORDER = 18
    HTOBJECT = 19
    HTCLOSE = 20
    HTHELP = 21
  End Enum

End Module
