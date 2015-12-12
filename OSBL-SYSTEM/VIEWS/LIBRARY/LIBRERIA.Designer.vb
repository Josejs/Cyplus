<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LIBRERIA
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LBFECHA = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LBHORA = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.BTNGUARDAR = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
        Me.BTNEDITAR = New DevComponents.DotNetBar.ButtonX()
        Me.BTNVER = New DevComponents.DotNetBar.ButtonX()
        Me.BTNELIMINAR = New DevComponents.DotNetBar.ButtonX()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TXTPESOUNITARIO = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXTSUPERFICIE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTXSTANDARD = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXTCCODCLI = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXTMATERIAL = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTCEDULA2 = New System.Windows.Forms.TextBox()
        Me.TXTCEDULA1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTXMEDIDA = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTDESC = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTDIM2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTDIM1 = New System.Windows.Forms.TextBox()
        Me.TXTCODIGO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ARCHIVOToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(9, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1204, 25)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ARCHIVOToolStripMenuItem
        '
        Me.ARCHIVOToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.SALIRToolStripMenuItem})
        Me.ARCHIVOToolStripMenuItem.Name = "ARCHIVOToolStripMenuItem"
        Me.ARCHIVOToolStripMenuItem.Size = New System.Drawing.Size(78, 21)
        Me.ARCHIVOToolStripMenuItem.Text = "&ARCHIVO"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(156, 6)
        '
        'SALIRToolStripMenuItem
        '
        Me.SALIRToolStripMenuItem.Image = Global.OSBL_SYSTEM.My.Resources.Resources._Error
        Me.SALIRToolStripMenuItem.Name = "SALIRToolStripMenuItem"
        Me.SALIRToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.SALIRToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.SALIRToolStripMenuItem.Text = "&SALIR"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LBFECHA, Me.ToolStripStatusLabel2, Me.LBHORA, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 647)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1204, 22)
        Me.StatusStrip1.TabIndex = 67
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LBFECHA
        '
        Me.LBFECHA.Name = "LBFECHA"
        Me.LBFECHA.Size = New System.Drawing.Size(64, 17)
        Me.LBFECHA.Text = "LBFECHA"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(12, 17)
        Me.ToolStripStatusLabel2.Text = "|"
        '
        'LBHORA
        '
        Me.LBHORA.Name = "LBHORA"
        Me.LBHORA.Size = New System.Drawing.Size(60, 17)
        Me.LBHORA.Text = "LBHORA"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(12, 17)
        Me.ToolStripStatusLabel1.Text = "|"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(229, 17)
        Me.ToolStripStatusLabel3.Text = "TERMOTECNICA COINDUSTRIAL S.A"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.BTNGUARDAR)
        Me.GroupBox5.Controls.Add(Me.ButtonX6)
        Me.GroupBox5.Controls.Add(Me.BTNEDITAR)
        Me.GroupBox5.Controls.Add(Me.BTNVER)
        Me.GroupBox5.Controls.Add(Me.BTNELIMINAR)
        Me.GroupBox5.Location = New System.Drawing.Point(172, 488)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(658, 79)
        Me.GroupBox5.TabIndex = 69
        Me.GroupBox5.TabStop = False
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BTNGUARDAR.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BTNGUARDAR.Location = New System.Drawing.Point(6, 20)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(113, 43)
        Me.BTNGUARDAR.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.BTNGUARDAR, New DevComponents.DotNetBar.SuperTooltipInfo("CYPLUS", "PUEDE UTILIZAR LA TECLAS DE ACCESO RAPIDO ALT+G", "LLENE LOS DATOS QUE SE LE PIDEN Y PRESIONE ESTE BOTON." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10), Global.OSBL_SYSTEM.My.Resources.Resources.descarga, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.BTNGUARDAR.TabIndex = 1
        Me.BTNGUARDAR.Text = "&GUARDAR"
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX6.Location = New System.Drawing.Point(133, 20)
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Size = New System.Drawing.Size(113, 43)
        Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX6, New DevComponents.DotNetBar.SuperTooltipInfo("CYPLUS", "PUEDE UTILIZAR LA TECLAS DE ACCESO RAPIDO ALT+N", "PRESIONE PARA LIMPIAR LAS CAJAS DE TEXTO Y PODER AGREGAR UN REGISTRO NUEVO.", Global.OSBL_SYSTEM.My.Resources.Resources.descarga, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.ButtonX6.TabIndex = 2
        Me.ButtonX6.Text = "&NUEVO"
        '
        'BTNEDITAR
        '
        Me.BTNEDITAR.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BTNEDITAR.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BTNEDITAR.Location = New System.Drawing.Point(269, 20)
        Me.BTNEDITAR.Name = "BTNEDITAR"
        Me.BTNEDITAR.Size = New System.Drawing.Size(113, 43)
        Me.BTNEDITAR.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.BTNEDITAR, New DevComponents.DotNetBar.SuperTooltipInfo("CYPLUS", "PUEDE UTILIZAR LA TECLAS DE ACCESO RAPIDO ALT+E", "BUSQUE UN REGISTRO DESDE LA BUSQUEDA AVANZADA, EDITE EL REGISTRO Y POSTERIORMENTE" & _
                    " PRESIONE ESTE BOTON.", Global.OSBL_SYSTEM.My.Resources.Resources.descarga, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.BTNEDITAR.TabIndex = 3
        Me.BTNEDITAR.Text = "&EDITAR"
        '
        'BTNVER
        '
        Me.BTNVER.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BTNVER.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BTNVER.Location = New System.Drawing.Point(535, 20)
        Me.BTNVER.Name = "BTNVER"
        Me.BTNVER.Size = New System.Drawing.Size(113, 43)
        Me.BTNVER.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.BTNVER, New DevComponents.DotNetBar.SuperTooltipInfo("CYPLUS", "PUEDE UTILIZAR LA TECLAS DE ACCESO RAPIDO ALT+V", "PRESIONE PARA VER LOS REGISTRO DE ENTRADAS DE ALMACEN.", Global.OSBL_SYSTEM.My.Resources.Resources.descarga, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.BTNVER.TabIndex = 5
        Me.BTNVER.Text = "&VER REGISTROS"
        '
        'BTNELIMINAR
        '
        Me.BTNELIMINAR.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BTNELIMINAR.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BTNELIMINAR.Location = New System.Drawing.Point(402, 20)
        Me.BTNELIMINAR.Name = "BTNELIMINAR"
        Me.BTNELIMINAR.Size = New System.Drawing.Size(113, 43)
        Me.BTNELIMINAR.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.BTNELIMINAR, New DevComponents.DotNetBar.SuperTooltipInfo("CYPLUS", "PUEDE UTILIZAR LA TECLAS DE ACCESO RAPIDO ALT+M", "BUSQUE UN REGISTRO DESDE LA BUSQUEDA AVANZADA, Y POSTERIORMENTE PRESIONE ESTE BOT" & _
                    "ON.", Global.OSBL_SYSTEM.My.Resources.Resources.descarga, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.BTNELIMINAR.TabIndex = 4
        Me.BTNELIMINAR.Text = "ELI&MINAR"
        '
        'EP
        '
        Me.EP.ContainerControl = Me
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TXTPESOUNITARIO)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.TXTSUPERFICIE)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TXTXSTANDARD)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.TXTCCODCLI)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.TXTMATERIAL)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TXTCEDULA2)
        Me.GroupBox1.Controls.Add(Me.TXTCEDULA1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TXTXMEDIDA)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TXTDESC)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TXTDIM2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TXTDIM1)
        Me.GroupBox1.Controls.Add(Me.TXTCODIGO)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TXTID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1078, 442)
        Me.GroupBox1.TabIndex = 70
        Me.GroupBox1.TabStop = False
        '
        'TXTPESOUNITARIO
        '
        Me.TXTPESOUNITARIO.Location = New System.Drawing.Point(599, 221)
        Me.TXTPESOUNITARIO.Name = "TXTPESOUNITARIO"
        Me.TXTPESOUNITARIO.Size = New System.Drawing.Size(108, 21)
        Me.TXTPESOUNITARIO.TabIndex = 129
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(596, 203)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(116, 15)
        Me.Label13.TabIndex = 128
        Me.Label13.Text = "PESO UNITARIO:"
        '
        'TXTSUPERFICIE
        '
        Me.TXTSUPERFICIE.Location = New System.Drawing.Point(406, 221)
        Me.TXTSUPERFICIE.Name = "TXTSUPERFICIE"
        Me.TXTSUPERFICIE.Size = New System.Drawing.Size(108, 21)
        Me.TXTSUPERFICIE.TabIndex = 127
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(403, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(158, 15)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "SUPERFICIE UNITARIA:"
        '
        'TXTXSTANDARD
        '
        Me.TXTXSTANDARD.Location = New System.Drawing.Point(504, 159)
        Me.TXTXSTANDARD.Name = "TXTXSTANDARD"
        Me.TXTXSTANDARD.Size = New System.Drawing.Size(100, 21)
        Me.TXTXSTANDARD.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(501, 141)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 15)
        Me.Label12.TabIndex = 125
        Me.Label12.Text = "STANDARD:"
        '
        'TXTCCODCLI
        '
        Me.TXTCCODCLI.Location = New System.Drawing.Point(238, 100)
        Me.TXTCCODCLI.Name = "TXTCCODCLI"
        Me.TXTCCODCLI.Size = New System.Drawing.Size(183, 21)
        Me.TXTCCODCLI.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(235, 82)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(125, 15)
        Me.Label11.TabIndex = 122
        Me.Label11.Text = "CODIGO CLIENTE:"
        '
        'TXTMATERIAL
        '
        Me.TXTMATERIAL.Location = New System.Drawing.Point(24, 221)
        Me.TXTMATERIAL.Multiline = True
        Me.TXTMATERIAL.Name = "TXTMATERIAL"
        Me.TXTMATERIAL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TXTMATERIAL.Size = New System.Drawing.Size(351, 118)
        Me.TXTMATERIAL.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(21, 203)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 15)
        Me.Label10.TabIndex = 121
        Me.Label10.Text = "MATERIAL:"
        '
        'TXTCEDULA2
        '
        Me.TXTCEDULA2.Location = New System.Drawing.Point(363, 159)
        Me.TXTCEDULA2.Name = "TXTCEDULA2"
        Me.TXTCEDULA2.Size = New System.Drawing.Size(100, 21)
        Me.TXTCEDULA2.TabIndex = 8
        '
        'TXTCEDULA1
        '
        Me.TXTCEDULA1.Location = New System.Drawing.Point(238, 159)
        Me.TXTCEDULA1.Name = "TXTCEDULA1"
        Me.TXTCEDULA1.Size = New System.Drawing.Size(100, 21)
        Me.TXTCEDULA1.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(360, 141)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 15)
        Me.Label9.TabIndex = 119
        Me.Label9.Text = "CEDULA 2:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(235, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 15)
        Me.Label8.TabIndex = 118
        Me.Label8.Text = "CEDULA 1:"
        '
        'TXTXMEDIDA
        '
        Me.TXTXMEDIDA.Location = New System.Drawing.Point(24, 159)
        Me.TXTXMEDIDA.Name = "TXTXMEDIDA"
        Me.TXTXMEDIDA.Size = New System.Drawing.Size(140, 21)
        Me.TXTXMEDIDA.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(143, 15)
        Me.Label7.TabIndex = 117
        Me.Label7.Text = "UNIDAD DE MEDIDA:"
        '
        'TXTDESC
        '
        Me.TXTDESC.Location = New System.Drawing.Point(710, 100)
        Me.TXTDESC.Multiline = True
        Me.TXTDESC.Name = "TXTDESC"
        Me.TXTDESC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TXTDESC.Size = New System.Drawing.Size(351, 80)
        Me.TXTDESC.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(707, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(153, 15)
        Me.Label6.TabIndex = 116
        Me.Label6.Text = "DESCRIPCION BREVE:"
        '
        'TXTDIM2
        '
        Me.TXTDIM2.Location = New System.Drawing.Point(590, 100)
        Me.TXTDIM2.Name = "TXTDIM2"
        Me.TXTDIM2.Size = New System.Drawing.Size(91, 21)
        Me.TXTDIM2.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(587, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 15)
        Me.Label4.TabIndex = 114
        Me.Label4.Text = "DIAMETRO 2:"
        '
        'TXTDIM1
        '
        Me.TXTDIM1.Location = New System.Drawing.Point(461, 100)
        Me.TXTDIM1.Name = "TXTDIM1"
        Me.TXTDIM1.Size = New System.Drawing.Size(91, 21)
        Me.TXTDIM1.TabIndex = 3
        '
        'TXTCODIGO
        '
        Me.TXTCODIGO.Location = New System.Drawing.Point(21, 100)
        Me.TXTCODIGO.Name = "TXTCODIGO"
        Me.TXTCODIGO.Size = New System.Drawing.Size(186, 21)
        Me.TXTCODIGO.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(458, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 15)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "DIAMETRO 1:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 15)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "CODIGO TCM:"
        '
        'TXTID
        '
        Me.TXTID.Location = New System.Drawing.Point(24, 39)
        Me.TXTID.Name = "TXTID"
        Me.TXTID.ReadOnly = True
        Me.TXTID.Size = New System.Drawing.Size(100, 21)
        Me.TXTID.TabIndex = 102
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 15)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "ID:"
        '
        'LIBRERIA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1204, 669)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "LIBRERIA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LIBRERIA"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ARCHIVOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SALIRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents LBFECHA As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LBHORA As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents BTNGUARDAR As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BTNEDITAR As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BTNVER As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BTNELIMINAR As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TXTMATERIAL As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TXTCEDULA2 As System.Windows.Forms.TextBox
    Friend WithEvents TXTCEDULA1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTXMEDIDA As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTDIM2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTDIM1 As System.Windows.Forms.TextBox
    Friend WithEvents TXTCODIGO As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTCCODCLI As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TXTXSTANDARD As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TXTPESOUNITARIO As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TXTSUPERFICIE As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
