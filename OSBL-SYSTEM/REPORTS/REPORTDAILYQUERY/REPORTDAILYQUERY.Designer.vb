<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REPORTDAILYQUERY
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
        Me.CRVSPOOL = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ARCHIVOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SALIRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GENERARToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CBJUNTAS = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.CBISOMETRICO = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CRVSPOOL
        '
        Me.CRVSPOOL.ActiveViewIndex = -1
        Me.CRVSPOOL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRVSPOOL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRVSPOOL.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRVSPOOL.Location = New System.Drawing.Point(12, 208)
        Me.CRVSPOOL.Margin = New System.Windows.Forms.Padding(2)
        Me.CRVSPOOL.Name = "CRVSPOOL"
        Me.CRVSPOOL.Size = New System.Drawing.Size(1014, 502)
        Me.CRVSPOOL.TabIndex = 6
        Me.CRVSPOOL.ToolPanelWidth = 150
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ARCHIVOToolStripMenuItem, Me.GENERARToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1031, 27)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ARCHIVOToolStripMenuItem
        '
        Me.ARCHIVOToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SALIRToolStripMenuItem})
        Me.ARCHIVOToolStripMenuItem.Name = "ARCHIVOToolStripMenuItem"
        Me.ARCHIVOToolStripMenuItem.Size = New System.Drawing.Size(84, 23)
        Me.ARCHIVOToolStripMenuItem.Text = "&ARCHIVO"
        '
        'SALIRToolStripMenuItem
        '
        Me.SALIRToolStripMenuItem.Name = "SALIRToolStripMenuItem"
        Me.SALIRToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.SALIRToolStripMenuItem.Size = New System.Drawing.Size(168, 24)
        Me.SALIRToolStripMenuItem.Text = "&SALIR"
        '
        'GENERARToolStripMenuItem
        '
        Me.GENERARToolStripMenuItem.Name = "GENERARToolStripMenuItem"
        Me.GENERARToolStripMenuItem.Size = New System.Drawing.Size(84, 23)
        Me.GENERARToolStripMenuItem.Text = "&GENERAR"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.CBJUNTAS)
        Me.GroupBox1.Controls.Add(Me.CBISOMETRICO)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(564, 173)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'CBJUNTAS
        '
        Me.CBJUNTAS.DisplayMember = "Text"
        Me.CBJUNTAS.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CBJUNTAS.FormattingEnabled = True
        Me.CBJUNTAS.ItemHeight = 14
        Me.CBJUNTAS.Location = New System.Drawing.Point(413, 47)
        Me.CBJUNTAS.Name = "CBJUNTAS"
        Me.CBJUNTAS.Size = New System.Drawing.Size(121, 20)
        Me.CBJUNTAS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CBJUNTAS.TabIndex = 3
        '
        'CBISOMETRICO
        '
        Me.CBISOMETRICO.DisplayMember = "Text"
        Me.CBISOMETRICO.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CBISOMETRICO.FormattingEnabled = True
        Me.CBISOMETRICO.ItemHeight = 14
        Me.CBISOMETRICO.Location = New System.Drawing.Point(167, 47)
        Me.CBISOMETRICO.Name = "CBISOMETRICO"
        Me.CBISOMETRICO.Size = New System.Drawing.Size(121, 20)
        Me.CBISOMETRICO.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CBISOMETRICO.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(343, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "N° JUNTAS"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NUMERO DE ISOMETRICO"
        '
        'REPORTDAILYQUERY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1031, 716)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CRVSPOOL)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "REPORTDAILYQUERY"
        Me.Text = "REPORTDAILYQUERY"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CRVSPOOL As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ARCHIVOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SALIRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GENERARToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CBJUNTAS As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents CBISOMETRICO As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
