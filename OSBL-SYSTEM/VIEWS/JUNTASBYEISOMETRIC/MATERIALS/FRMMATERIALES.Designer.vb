<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMMATERIALES
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ARCHIVOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SALIRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LIBRERIAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ALMACENENTRADAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LBFECHA = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LBHORA = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CYPLUSDataSet = New OSBL_SYSTEM.CYPLUSDataSet()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.BTNELIMINAR = New DevComponents.DotNetBar.ButtonX()
        Me.BTNVER = New DevComponents.DotNetBar.ButtonX()
        Me.BTNEDITAR = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
        Me.BTNGUARDAR = New DevComponents.DotNetBar.ButtonX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MATID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MATIDENTIFICADOR = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.MATCOLADA = New System.Windows.Forms.TextBox()
        Me.MATFABRICANTE = New System.Windows.Forms.TextBox()
        Me.MATPESO = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.MATISOMETRICO = New System.Windows.Forms.TextBox()
        Me.BTNSEARCH = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXNUMEROSPOOL = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TXREVSPOOL = New System.Windows.Forms.TextBox()
        Me.TXSPOOL = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.TXHOJASPOOL = New System.Windows.Forms.TextBox()
        Me.TXTCANTIDADHOJAS = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.TXTDIAMETRO = New System.Windows.Forms.TextBox()
        Me.TXTCANTIDAD = New System.Windows.Forms.TextBox()
        Me.TXTDESCRIPCION = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.TXTUNIDAD = New System.Windows.Forms.TextBox()
        Me.TXTCATEGORIA = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.XTXTDIAM2 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.MATCODIGO = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.CYPLUSDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ARCHIVOToolStripMenuItem, Me.RToolStripMenuItem, Me.LIBRERIAToolStripMenuItem, Me.ALMACENENTRADAToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(9, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1680, 31)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ARCHIVOToolStripMenuItem
        '
        Me.ARCHIVOToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.SALIRToolStripMenuItem})
        Me.ARCHIVOToolStripMenuItem.Name = "ARCHIVOToolStripMenuItem"
        Me.ARCHIVOToolStripMenuItem.Size = New System.Drawing.Size(98, 27)
        Me.ARCHIVOToolStripMenuItem.Text = "&ARCHIVO"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(187, 6)
        '
        'SALIRToolStripMenuItem
        '
        Me.SALIRToolStripMenuItem.Image = Global.OSBL_SYSTEM.My.Resources.Resources._Error
        Me.SALIRToolStripMenuItem.Name = "SALIRToolStripMenuItem"
        Me.SALIRToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.SALIRToolStripMenuItem.Size = New System.Drawing.Size(190, 28)
        Me.SALIRToolStripMenuItem.Text = "&SALIR"
        '
        'RToolStripMenuItem
        '
        Me.RToolStripMenuItem.Image = Global.OSBL_SYSTEM.My.Resources.Resources.Newspaper
        Me.RToolStripMenuItem.Name = "RToolStripMenuItem"
        Me.RToolStripMenuItem.Size = New System.Drawing.Size(121, 27)
        Me.RToolStripMenuItem.Text = "REPORTES"
        '
        'LIBRERIAToolStripMenuItem
        '
        Me.LIBRERIAToolStripMenuItem.Image = Global.OSBL_SYSTEM.My.Resources.Resources.Bookshelf
        Me.LIBRERIAToolStripMenuItem.Name = "LIBRERIAToolStripMenuItem"
        Me.LIBRERIAToolStripMenuItem.Size = New System.Drawing.Size(111, 27)
        Me.LIBRERIAToolStripMenuItem.Text = "LIBRERIA"
        '
        'ALMACENENTRADAToolStripMenuItem
        '
        Me.ALMACENENTRADAToolStripMenuItem.Name = "ALMACENENTRADAToolStripMenuItem"
        Me.ALMACENENTRADAToolStripMenuItem.Size = New System.Drawing.Size(191, 27)
        Me.ALMACENENTRADAToolStripMenuItem.Text = "ALMACEN-ENTRADA"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LBFECHA, Me.ToolStripStatusLabel2, Me.LBHORA, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 730)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1680, 28)
        Me.StatusStrip1.TabIndex = 67
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LBFECHA
        '
        Me.LBFECHA.Name = "LBFECHA"
        Me.LBFECHA.Size = New System.Drawing.Size(84, 23)
        Me.LBFECHA.Text = "LBFECHA"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(16, 23)
        Me.ToolStripStatusLabel2.Text = "|"
        '
        'LBHORA
        '
        Me.LBHORA.Name = "LBHORA"
        Me.LBHORA.Size = New System.Drawing.Size(79, 23)
        Me.LBHORA.Text = "LBHORA"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(16, 23)
        Me.ToolStripStatusLabel1.Text = "|"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(301, 23)
        Me.ToolStripStatusLabel3.Text = "TERMOTECNICA COINDUSTRIAL S.A"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'CYPLUSDataSet
        '
        Me.CYPLUSDataSet.DataSetName = "CYPLUSDataSet"
        Me.CYPLUSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EP
        '
        Me.EP.ContainerControl = Me
        '
        'BTNELIMINAR
        '
        Me.BTNELIMINAR.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BTNELIMINAR.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BTNELIMINAR.Location = New System.Drawing.Point(402, 20)
        Me.BTNELIMINAR.Name = "BTNELIMINAR"
        Me.BTNELIMINAR.Size = New System.Drawing.Size(113, 43)
        Me.BTNELIMINAR.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.BTNELIMINAR, New DevComponents.DotNetBar.SuperTooltipInfo("CYPLUS", "PUEDE UTILIZAR LAS TECLAS DE ACCESO RAPIDO ALT+M", "BUSQUE UN REGISTRO DESDE LA BUSQUEDA AVANZADA, Y POSTERIORMENTE PRESIONE ESTE BOT" & _
                    "ON.", Global.OSBL_SYSTEM.My.Resources.Resources.descarga, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.BTNELIMINAR.TabIndex = 4
        Me.BTNELIMINAR.Text = "ELI&MINAR"
        '
        'BTNVER
        '
        Me.BTNVER.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BTNVER.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BTNVER.Location = New System.Drawing.Point(535, 20)
        Me.BTNVER.Name = "BTNVER"
        Me.BTNVER.Size = New System.Drawing.Size(113, 43)
        Me.BTNVER.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.BTNVER, New DevComponents.DotNetBar.SuperTooltipInfo("CYPLUS", "PUEDE UTILIZAR LAS TECLAS DE ACCESO RAPIDO ALT+V", "PRESIONE PARA VER LOS REGISTROS DE LOS MATERIALES POR ISOMETRICO", Global.OSBL_SYSTEM.My.Resources.Resources.descarga, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.BTNVER.TabIndex = 5
        Me.BTNVER.Text = "&VER REGISTROS"
        '
        'BTNEDITAR
        '
        Me.BTNEDITAR.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BTNEDITAR.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BTNEDITAR.Location = New System.Drawing.Point(269, 20)
        Me.BTNEDITAR.Name = "BTNEDITAR"
        Me.BTNEDITAR.Size = New System.Drawing.Size(113, 43)
        Me.BTNEDITAR.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.BTNEDITAR, New DevComponents.DotNetBar.SuperTooltipInfo("CYPLUS", "PUEDE UTILIZAR LAS TECLAS DE ACCESO RAPIDO ALT+E", "BUSQUE UN REGISTRO DESDE LA BUSQUEDA AVANZADA, EDITE EL REGISTRO Y POSTERIORMENTE" & _
                    " PRESIONE ESTE BOTON.", Global.OSBL_SYSTEM.My.Resources.Resources.descarga, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.BTNEDITAR.TabIndex = 3
        Me.BTNEDITAR.Text = "&EDITAR"
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX6.Location = New System.Drawing.Point(133, 20)
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Size = New System.Drawing.Size(113, 43)
        Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX6, New DevComponents.DotNetBar.SuperTooltipInfo("CYPLUS", "PUEDE UTILIZAR LAS TECLAS DE ACCESO RAPIDO ALT+N", "PRESIONE PARA LIMPIAR LAS CAJAS DE TEXTO Y PODER AGREGAR UN REGISTRO NUEVO.", Global.OSBL_SYSTEM.My.Resources.Resources.descarga, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.ButtonX6.TabIndex = 2
        Me.ButtonX6.Text = "&NUEVO"
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BTNGUARDAR.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BTNGUARDAR.Location = New System.Drawing.Point(6, 20)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(113, 43)
        Me.BTNGUARDAR.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.BTNGUARDAR, New DevComponents.DotNetBar.SuperTooltipInfo("CYPLUS", "PUEDE UTILIZAR LAS TECLAS DE ACCESO RAPIDO ALT+G", "LLENE LOS DATOS QUE SE LE PIDEN Y PRESIONE ESTE BOTON.", Global.OSBL_SYSTEM.My.Resources.Resources.descarga, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.BTNGUARDAR.TabIndex = 1
        Me.BTNGUARDAR.Text = "&GUARDAR"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID:"
        '
        'MATID
        '
        Me.MATID.Enabled = False
        Me.MATID.Location = New System.Drawing.Point(10, 45)
        Me.MATID.Name = "MATID"
        Me.MATID.ReadOnly = True
        Me.MATID.Size = New System.Drawing.Size(100, 24)
        Me.MATID.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "COD. DEL MATERIAL:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(200, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 18)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "I.T"
        '
        'MATIDENTIFICADOR
        '
        Me.MATIDENTIFICADOR.Location = New System.Drawing.Point(203, 182)
        Me.MATIDENTIFICADOR.Name = "MATIDENTIFICADOR"
        Me.MATIDENTIFICADOR.Size = New System.Drawing.Size(56, 24)
        Me.MATIDENTIFICADOR.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(394, 164)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 18)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "COLADA:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(636, 164)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(115, 18)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "FABRICANTE:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(273, 164)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 18)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "PESO:"
        '
        'MATCOLADA
        '
        Me.MATCOLADA.Location = New System.Drawing.Point(397, 182)
        Me.MATCOLADA.Name = "MATCOLADA"
        Me.MATCOLADA.Size = New System.Drawing.Size(192, 24)
        Me.MATCOLADA.TabIndex = 13
        '
        'MATFABRICANTE
        '
        Me.MATFABRICANTE.Location = New System.Drawing.Point(639, 182)
        Me.MATFABRICANTE.Name = "MATFABRICANTE"
        Me.MATFABRICANTE.Size = New System.Drawing.Size(236, 24)
        Me.MATFABRICANTE.TabIndex = 14
        '
        'MATPESO
        '
        Me.MATPESO.Location = New System.Drawing.Point(276, 182)
        Me.MATPESO.Name = "MATPESO"
        Me.MATPESO.Size = New System.Drawing.Size(108, 24)
        Me.MATPESO.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 69)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(117, 18)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "ISOMETRICO:"
        '
        'MATISOMETRICO
        '
        Me.MATISOMETRICO.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MATISOMETRICO.Location = New System.Drawing.Point(10, 87)
        Me.MATISOMETRICO.Name = "MATISOMETRICO"
        Me.MATISOMETRICO.Size = New System.Drawing.Size(389, 41)
        Me.MATISOMETRICO.TabIndex = 2
        '
        'BTNSEARCH
        '
        Me.BTNSEARCH.Location = New System.Drawing.Point(159, 185)
        Me.BTNSEARCH.Name = "BTNSEARCH"
        Me.BTNSEARCH.Size = New System.Drawing.Size(35, 24)
        Me.BTNSEARCH.TabIndex = 37
        Me.BTNSEARCH.Text = "..."
        Me.BTNSEARCH.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(594, 182)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 24)
        Me.Button1.TabIndex = 38
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.BTNGUARDAR)
        Me.GroupBox5.Controls.Add(Me.ButtonX6)
        Me.GroupBox5.Controls.Add(Me.BTNEDITAR)
        Me.GroupBox5.Controls.Add(Me.BTNVER)
        Me.GroupBox5.Controls.Add(Me.BTNELIMINAR)
        Me.GroupBox5.Location = New System.Drawing.Point(408, 590)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(658, 79)
        Me.GroupBox5.TabIndex = 69
        Me.GroupBox5.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TXNUMEROSPOOL)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.TXREVSPOOL)
        Me.GroupBox2.Controls.Add(Me.TXSPOOL)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Location = New System.Drawing.Point(1187, 27)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(419, 152)
        Me.GroupBox2.TabIndex = 70
        Me.GroupBox2.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(177, 18)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "NUMERO DE SPOOL:"
        '
        'TXNUMEROSPOOL
        '
        Me.TXNUMEROSPOOL.Location = New System.Drawing.Point(15, 53)
        Me.TXNUMEROSPOOL.Name = "TXNUMEROSPOOL"
        Me.TXNUMEROSPOOL.Size = New System.Drawing.Size(142, 24)
        Me.TXNUMEROSPOOL.TabIndex = 142
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 85)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(128, 18)
        Me.Label16.TabIndex = 140
        Me.Label16.Text = "SPOOL UNIDO:"
        '
        'TXREVSPOOL
        '
        Me.TXREVSPOOL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXREVSPOOL.Location = New System.Drawing.Point(262, 55)
        Me.TXREVSPOOL.Name = "TXREVSPOOL"
        Me.TXREVSPOOL.Size = New System.Drawing.Size(121, 24)
        Me.TXREVSPOOL.TabIndex = 139
        '
        'TXSPOOL
        '
        Me.TXSPOOL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXSPOOL.Location = New System.Drawing.Point(15, 105)
        Me.TXSPOOL.Name = "TXSPOOL"
        Me.TXSPOOL.Size = New System.Drawing.Size(257, 24)
        Me.TXSPOOL.TabIndex = 138
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(259, 35)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(108, 18)
        Me.Label17.TabIndex = 141
        Me.Label17.Text = "REV. SPOOL"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.TXHOJASPOOL)
        Me.GroupBox7.Controls.Add(Me.TXTCANTIDADHOJAS)
        Me.GroupBox7.Controls.Add(Me.Label20)
        Me.GroupBox7.Location = New System.Drawing.Point(405, 65)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(185, 57)
        Me.GroupBox7.TabIndex = 136
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "HOJA"
        '
        'TXHOJASPOOL
        '
        Me.TXHOJASPOOL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXHOJASPOOL.Location = New System.Drawing.Point(6, 29)
        Me.TXHOJASPOOL.Name = "TXHOJASPOOL"
        Me.TXHOJASPOOL.Size = New System.Drawing.Size(59, 24)
        Me.TXHOJASPOOL.TabIndex = 89
        '
        'TXTCANTIDADHOJAS
        '
        Me.TXTCANTIDADHOJAS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCANTIDADHOJAS.Location = New System.Drawing.Point(120, 29)
        Me.TXTCANTIDADHOJAS.Name = "TXTCANTIDADHOJAS"
        Me.TXTCANTIDADHOJAS.Size = New System.Drawing.Size(59, 24)
        Me.TXTCANTIDADHOJAS.TabIndex = 134
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(71, 32)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(31, 18)
        Me.Label20.TabIndex = 133
        Me.Label20.Text = "DE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 303)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 18)
        Me.Label4.TabIndex = 137
        Me.Label4.Text = "CATEGORIA:"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(526, 303)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(113, 18)
        Me.Label43.TabIndex = 139
        Me.Label43.Text = "DIAMETRO 1:"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(212, 303)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(95, 18)
        Me.Label46.TabIndex = 140
        Me.Label46.Text = "CANTIDAD:"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(898, 164)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(127, 18)
        Me.Label50.TabIndex = 141
        Me.Label50.Text = "DESCRIPCION:"
        '
        'TXTDIAMETRO
        '
        Me.TXTDIAMETRO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDIAMETRO.Location = New System.Drawing.Point(529, 321)
        Me.TXTDIAMETRO.Name = "TXTDIAMETRO"
        Me.TXTDIAMETRO.Size = New System.Drawing.Size(121, 24)
        Me.TXTDIAMETRO.TabIndex = 143
        '
        'TXTCANTIDAD
        '
        Me.TXTCANTIDAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCANTIDAD.Location = New System.Drawing.Point(215, 321)
        Me.TXTCANTIDAD.Name = "TXTCANTIDAD"
        Me.TXTCANTIDAD.Size = New System.Drawing.Size(113, 24)
        Me.TXTCANTIDAD.TabIndex = 144
        '
        'TXTDESCRIPCION
        '
        Me.TXTDESCRIPCION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDESCRIPCION.Location = New System.Drawing.Point(901, 182)
        Me.TXTDESCRIPCION.Multiline = True
        Me.TXTDESCRIPCION.Name = "TXTDESCRIPCION"
        Me.TXTDESCRIPCION.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TXTDESCRIPCION.Size = New System.Drawing.Size(275, 100)
        Me.TXTDESCRIPCION.TabIndex = 147
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(345, 303)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(75, 18)
        Me.Label51.TabIndex = 146
        Me.Label51.Text = "UNIDAD:"
        '
        'TXTUNIDAD
        '
        Me.TXTUNIDAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTUNIDAD.Location = New System.Drawing.Point(348, 321)
        Me.TXTUNIDAD.Name = "TXTUNIDAD"
        Me.TXTUNIDAD.Size = New System.Drawing.Size(172, 24)
        Me.TXTUNIDAD.TabIndex = 145
        '
        'TXTCATEGORIA
        '
        Me.TXTCATEGORIA.DisplayMember = "Text"
        Me.TXTCATEGORIA.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.TXTCATEGORIA.FormattingEnabled = True
        Me.TXTCATEGORIA.ItemHeight = 18
        Me.TXTCATEGORIA.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2})
        Me.TXTCATEGORIA.Location = New System.Drawing.Point(10, 321)
        Me.TXTCATEGORIA.Name = "TXTCATEGORIA"
        Me.TXTCATEGORIA.Size = New System.Drawing.Size(180, 24)
        Me.TXTCATEGORIA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.TXTCATEGORIA.TabIndex = 149
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "TUBERIA"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "ACCESORIO"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(679, 303)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(113, 18)
        Me.Label19.TabIndex = 150
        Me.Label19.Text = "DIAMETRO 2:"
        '
        'XTXTDIAM2
        '
        Me.XTXTDIAM2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.XTXTDIAM2.Location = New System.Drawing.Point(682, 321)
        Me.XTXTDIAM2.Name = "XTXTDIAM2"
        Me.XTXTDIAM2.Size = New System.Drawing.Size(121, 24)
        Me.XTXTDIAM2.TabIndex = 151
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.MATCODIGO)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.XTXTDIAM2)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.TXTCATEGORIA)
        Me.GroupBox1.Controls.Add(Me.TXTUNIDAD)
        Me.GroupBox1.Controls.Add(Me.Label51)
        Me.GroupBox1.Controls.Add(Me.TXTDESCRIPCION)
        Me.GroupBox1.Controls.Add(Me.TXTCANTIDAD)
        Me.GroupBox1.Controls.Add(Me.TXTDIAMETRO)
        Me.GroupBox1.Controls.Add(Me.Label50)
        Me.GroupBox1.Controls.Add(Me.Label46)
        Me.GroupBox1.Controls.Add(Me.Label43)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.GroupBox7)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.BTNSEARCH)
        Me.GroupBox1.Controls.Add(Me.MATISOMETRICO)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.MATPESO)
        Me.GroupBox1.Controls.Add(Me.MATFABRICANTE)
        Me.GroupBox1.Controls.Add(Me.MATCOLADA)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.MATIDENTIFICADOR)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.MATID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 41)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Size = New System.Drawing.Size(1654, 675)
        Me.GroupBox1.TabIndex = 68
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DATOS DEL MATERIAL"
        '
        'MATCODIGO
        '
        '
        '
        '
        Me.MATCODIGO.Border.Class = "TextBoxBorder"
        Me.MATCODIGO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MATCODIGO.Location = New System.Drawing.Point(10, 186)
        Me.MATCODIGO.Name = "MATCODIGO"
        Me.MATCODIGO.Size = New System.Drawing.Size(143, 24)
        Me.MATCODIGO.TabIndex = 154
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1612, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(35, 24)
        Me.Button2.TabIndex = 153
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FRMMATERIALES
        '
        Me.AcceptButton = Me.BTNSEARCH
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1680, 758)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "FRMMATERIALES"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MATERIALES POR ISOMETRICO"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.CYPLUSDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ARCHIVOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SALIRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents LBFECHA As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LBHORA As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LIBRERIAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CYPLUSDataSet As OSBL_SYSTEM.CYPLUSDataSet
    Friend WithEvents BTNSEARCH As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents XTXTDIAM2 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TXTCATEGORIA As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents TXTUNIDAD As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents TXTDESCRIPCION As System.Windows.Forms.TextBox
    Friend WithEvents TXTCANTIDAD As System.Windows.Forms.TextBox
    Friend WithEvents TXTDIAMETRO As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents TXHOJASPOOL As System.Windows.Forms.TextBox
    Friend WithEvents TXTCANTIDADHOJAS As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXNUMEROSPOOL As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TXREVSPOOL As System.Windows.Forms.TextBox
    Friend WithEvents TXSPOOL As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents BTNGUARDAR As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BTNEDITAR As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BTNVER As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BTNELIMINAR As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MATISOMETRICO As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents MATPESO As System.Windows.Forms.TextBox
    Friend WithEvents MATFABRICANTE As System.Windows.Forms.TextBox
    Friend WithEvents MATCOLADA As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents MATIDENTIFICADOR As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MATID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ALMACENENTRADAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MATCODIGO As DevComponents.DotNetBar.Controls.TextBoxX
End Class
