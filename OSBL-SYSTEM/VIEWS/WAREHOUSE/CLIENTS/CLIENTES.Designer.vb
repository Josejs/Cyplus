<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CLIENTES
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LBFECHA = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LBHORA = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ARCHIVOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SALIRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TXTMATERIALCLIENTE = New System.Windows.Forms.TextBox()
        Me.TXTDESCRIPCIONCLIENTE = New System.Windows.Forms.TextBox()
        Me.TXTCODIGOCLIENTE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTIDCLIENTE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BTNGUARDAR = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
        Me.BTNEDITAR = New DevComponents.DotNetBar.ButtonX()
        Me.BTNVER = New DevComponents.DotNetBar.ButtonX()
        Me.BTNELIMINAR = New DevComponents.DotNetBar.ButtonX()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LBFECHA, Me.ToolStripStatusLabel1, Me.LBHORA, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 422)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(890, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LBFECHA
        '
        Me.LBFECHA.Name = "LBFECHA"
        Me.LBFECHA.Size = New System.Drawing.Size(57, 17)
        Me.LBFECHA.Text = "LBFECHA"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(11, 17)
        Me.ToolStripStatusLabel1.Text = "|"
        '
        'LBHORA
        '
        Me.LBHORA.Name = "LBHORA"
        Me.LBHORA.Size = New System.Drawing.Size(55, 17)
        Me.LBHORA.Text = "LBHORA"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(11, 17)
        Me.ToolStripStatusLabel3.Text = "|"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(207, 17)
        Me.ToolStripStatusLabel2.Text = "TERMOTECNICA COINDUSTRIAL S.A"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ARCHIVOToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(890, 25)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ARCHIVOToolStripMenuItem
        '
        Me.ARCHIVOToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SALIRToolStripMenuItem})
        Me.ARCHIVOToolStripMenuItem.Name = "ARCHIVOToolStripMenuItem"
        Me.ARCHIVOToolStripMenuItem.Size = New System.Drawing.Size(78, 21)
        Me.ARCHIVOToolStripMenuItem.Text = "&ARCHIVO"
        '
        'SALIRToolStripMenuItem
        '
        Me.SALIRToolStripMenuItem.Image = Global.OSBL_SYSTEM.My.Resources.Resources._Error
        Me.SALIRToolStripMenuItem.Name = "SALIRToolStripMenuItem"
        Me.SALIRToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.SALIRToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.SALIRToolStripMenuItem.Text = "&SALIR"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TXTMATERIALCLIENTE)
        Me.GroupPanel1.Controls.Add(Me.TXTDESCRIPCIONCLIENTE)
        Me.GroupPanel1.Controls.Add(Me.TXTCODIGOCLIENTE)
        Me.GroupPanel1.Controls.Add(Me.Label4)
        Me.GroupPanel1.Controls.Add(Me.Label3)
        Me.GroupPanel1.Controls.Add(Me.Label2)
        Me.GroupPanel1.Controls.Add(Me.TXTIDCLIENTE)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Location = New System.Drawing.Point(16, 44)
        Me.GroupPanel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(858, 258)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 4
        Me.GroupPanel1.Text = "DATOS DEL CLIENTE"
        '
        'TXTMATERIALCLIENTE
        '
        Me.TXTMATERIALCLIENTE.Location = New System.Drawing.Point(588, 89)
        Me.TXTMATERIALCLIENTE.Multiline = True
        Me.TXTMATERIALCLIENTE.Name = "TXTMATERIALCLIENTE"
        Me.TXTMATERIALCLIENTE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TXTMATERIALCLIENTE.Size = New System.Drawing.Size(259, 127)
        Me.TXTMATERIALCLIENTE.TabIndex = 7
        '
        'TXTDESCRIPCIONCLIENTE
        '
        Me.TXTDESCRIPCIONCLIENTE.Location = New System.Drawing.Point(253, 89)
        Me.TXTDESCRIPCIONCLIENTE.Multiline = True
        Me.TXTDESCRIPCIONCLIENTE.Name = "TXTDESCRIPCIONCLIENTE"
        Me.TXTDESCRIPCIONCLIENTE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TXTDESCRIPCIONCLIENTE.Size = New System.Drawing.Size(259, 127)
        Me.TXTDESCRIPCIONCLIENTE.TabIndex = 6
        '
        'TXTCODIGOCLIENTE
        '
        Me.TXTCODIGOCLIENTE.Location = New System.Drawing.Point(7, 89)
        Me.TXTCODIGOCLIENTE.Name = "TXTCODIGOCLIENTE"
        Me.TXTCODIGOCLIENTE.Size = New System.Drawing.Size(199, 21)
        Me.TXTCODIGOCLIENTE.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(585, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "MATERIAL:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(250, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "DESCRIPCION:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "CODIGO DEL CLIENTE."
        '
        'TXTIDCLIENTE
        '
        Me.TXTIDCLIENTE.Location = New System.Drawing.Point(3, 28)
        Me.TXTIDCLIENTE.Name = "TXTIDCLIENTE"
        Me.TXTIDCLIENTE.ReadOnly = True
        Me.TXTIDCLIENTE.Size = New System.Drawing.Size(85, 21)
        Me.TXTIDCLIENTE.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BTNGUARDAR)
        Me.GroupBox2.Controls.Add(Me.ButtonX6)
        Me.GroupBox2.Controls.Add(Me.BTNEDITAR)
        Me.GroupBox2.Controls.Add(Me.BTNVER)
        Me.GroupBox2.Controls.Add(Me.BTNELIMINAR)
        Me.GroupBox2.Location = New System.Drawing.Point(125, 308)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(658, 79)
        Me.GroupBox2.TabIndex = 66
        Me.GroupBox2.TabStop = False
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BTNGUARDAR.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BTNGUARDAR.Location = New System.Drawing.Point(6, 20)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(113, 43)
        Me.BTNGUARDAR.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.BTNGUARDAR, New DevComponents.DotNetBar.SuperTooltipInfo("CYPLUS", "PUEDE UTILIZAR LA TECLAS DE ACCESO RAPIDO ALT+G", "LLENE LOS DATOS QUE SE LE PIDEN Y PRESIONE ESTE BOTON.", Global.OSBL_SYSTEM.My.Resources.Resources.descarga, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.BTNGUARDAR.TabIndex = 14
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
        Me.ButtonX6.TabIndex = 15
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
        Me.BTNEDITAR.TabIndex = 16
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
        Me.BTNVER.TabIndex = 63
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
        Me.BTNELIMINAR.TabIndex = 17
        Me.BTNELIMINAR.Text = "ELI&MINAR"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'CLIENTES
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 444)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "CLIENTES"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CLIENTES"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents LBFECHA As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LBHORA As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ARCHIVOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SALIRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTIDCLIENTE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTMATERIALCLIENTE As System.Windows.Forms.TextBox
    Friend WithEvents TXTDESCRIPCIONCLIENTE As System.Windows.Forms.TextBox
    Friend WithEvents TXTCODIGOCLIENTE As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BTNGUARDAR As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BTNEDITAR As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BTNVER As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BTNELIMINAR As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
End Class
