<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEstado_Iso
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DvgEst = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ARCHIVOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ACTUALIZARTABLAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TXTISOMETRICO = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TXTSPOOL = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TXTESTADO = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TXTSTATUS = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.IMPRIMIRINFORMEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SALIRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXPORTARAEXCELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DvgEst, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.DvgEst)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 230)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Size = New System.Drawing.Size(806, 486)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "REGISTROS"
        '
        'DvgEst
        '
        Me.DvgEst.AllowUserToAddRows = False
        Me.DvgEst.AllowUserToDeleteRows = False
        Me.DvgEst.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DvgEst.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DvgEst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DvgEst.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DvgEst.Location = New System.Drawing.Point(4, 16)
        Me.DvgEst.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DvgEst.Name = "DvgEst"
        Me.DvgEst.ReadOnly = True
        Me.DvgEst.Size = New System.Drawing.Size(798, 467)
        Me.DvgEst.TabIndex = 2
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ARCHIVOToolStripMenuItem, Me.EXPORTARAEXCELToolStripMenuItem, Me.ACTUALIZARTABLAToolStripMenuItem, Me.IMPRIMIRINFORMEToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(832, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ARCHIVOToolStripMenuItem
        '
        Me.ARCHIVOToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.SALIRToolStripMenuItem})
        Me.ARCHIVOToolStripMenuItem.Name = "ARCHIVOToolStripMenuItem"
        Me.ARCHIVOToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.ARCHIVOToolStripMenuItem.Text = "ARCHIVO"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(147, 6)
        '
        'ACTUALIZARTABLAToolStripMenuItem
        '
        Me.ACTUALIZARTABLAToolStripMenuItem.Name = "ACTUALIZARTABLAToolStripMenuItem"
        Me.ACTUALIZARTABLAToolStripMenuItem.Size = New System.Drawing.Size(130, 20)
        Me.ACTUALIZARTABLAToolStripMenuItem.Text = "ACTUALIZAR TABLA"
        '
        'TXTISOMETRICO
        '
        '
        '
        '
        Me.TXTISOMETRICO.Border.Class = "TextBoxBorder"
        Me.TXTISOMETRICO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TXTISOMETRICO.Location = New System.Drawing.Point(9, 48)
        Me.TXTISOMETRICO.Name = "TXTISOMETRICO"
        Me.TXTISOMETRICO.Size = New System.Drawing.Size(103, 20)
        Me.TXTISOMETRICO.TabIndex = 9
        '
        'TXTSPOOL
        '
        '
        '
        '
        Me.TXTSPOOL.Border.Class = "TextBoxBorder"
        Me.TXTSPOOL.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TXTSPOOL.Location = New System.Drawing.Point(144, 48)
        Me.TXTSPOOL.Name = "TXTSPOOL"
        Me.TXTSPOOL.Size = New System.Drawing.Size(117, 20)
        Me.TXTSPOOL.TabIndex = 10
        '
        'TXTESTADO
        '
        '
        '
        '
        Me.TXTESTADO.Border.Class = "TextBoxBorder"
        Me.TXTESTADO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TXTESTADO.Location = New System.Drawing.Point(314, 48)
        Me.TXTESTADO.Name = "TXTESTADO"
        Me.TXTESTADO.Size = New System.Drawing.Size(148, 20)
        Me.TXTESTADO.TabIndex = 11
        '
        'TXTSTATUS
        '
        '
        '
        '
        Me.TXTSTATUS.Border.Class = "TextBoxBorder"
        Me.TXTSTATUS.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TXTSTATUS.Location = New System.Drawing.Point(534, 48)
        Me.TXTSTATUS.Name = "TXTSTATUS"
        Me.TXTSTATUS.Size = New System.Drawing.Size(155, 20)
        Me.TXTSTATUS.TabIndex = 12
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TXTISOMETRICO)
        Me.GroupBox2.Controls.Add(Me.TXTSTATUS)
        Me.GroupBox2.Controls.Add(Me.TXTSPOOL)
        Me.GroupBox2.Controls.Add(Me.TXTESTADO)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(13, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(726, 150)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(531, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(158, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "STATUS DE ISOMETRICO"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(311, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "ESTADOS FABRICADOS:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(141, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "SPOOL ACTUALES:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "ISOMETRICO:"
        '
        'IMPRIMIRINFORMEToolStripMenuItem
        '
        Me.IMPRIMIRINFORMEToolStripMenuItem.Name = "IMPRIMIRINFORMEToolStripMenuItem"
        Me.IMPRIMIRINFORMEToolStripMenuItem.Size = New System.Drawing.Size(132, 20)
        Me.IMPRIMIRINFORMEToolStripMenuItem.Text = "IMPRIMIR INFORME"
        '
        'SALIRToolStripMenuItem
        '
        Me.SALIRToolStripMenuItem.Image = Global.OSBL_SYSTEM.My.Resources.Resources._Error
        Me.SALIRToolStripMenuItem.Name = "SALIRToolStripMenuItem"
        Me.SALIRToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.SALIRToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.SALIRToolStripMenuItem.Text = "SALIR"
        '
        'EXPORTARAEXCELToolStripMenuItem
        '
        Me.EXPORTARAEXCELToolStripMenuItem.Image = Global.OSBL_SYSTEM.My.Resources.Resources.Excel_2013
        Me.EXPORTARAEXCELToolStripMenuItem.Name = "EXPORTARAEXCELToolStripMenuItem"
        Me.EXPORTARAEXCELToolStripMenuItem.Size = New System.Drawing.Size(142, 20)
        Me.EXPORTARAEXCELToolStripMenuItem.Text = "EXPORTAR A EXCEL"
        '
        'FrmEstado_Iso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 728)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MaximizeBox = False
        Me.Name = "FrmEstado_Iso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "STATUS DE ISOMETRICOS"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DvgEst, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DvgEst As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ARCHIVOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SALIRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EXPORTARAEXCELToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ACTUALIZARTABLAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TXTISOMETRICO As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TXTSPOOL As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TXTESTADO As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TXTSTATUS As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents IMPRIMIRINFORMEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
