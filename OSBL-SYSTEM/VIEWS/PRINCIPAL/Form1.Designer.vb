<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMINICIPRINCIPAL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRMINICIPRINCIPAL))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTUSUARIO = New System.Windows.Forms.TextBox()
        Me.TXTPASS = New System.Windows.Forms.TextBox()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "USUARIO:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "CONTRASEÑA:"
        '
        'TXTUSUARIO
        '
        Me.TXTUSUARIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTUSUARIO.Location = New System.Drawing.Point(144, 26)
        Me.TXTUSUARIO.Name = "TXTUSUARIO"
        Me.TXTUSUARIO.Size = New System.Drawing.Size(256, 24)
        Me.TXTUSUARIO.TabIndex = 2
        '
        'TXTPASS
        '
        Me.TXTPASS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPASS.Location = New System.Drawing.Point(144, 95)
        Me.TXTPASS.Name = "TXTPASS"
        Me.TXTPASS.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXTPASS.Size = New System.Drawing.Size(256, 24)
        Me.TXTPASS.TabIndex = 3
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(144, 146)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(125, 54)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX1, New DevComponents.DotNetBar.SuperTooltipInfo("CYPLUS", "PUEDE USAR LAS TECLAS DE ACCESO RAPIDO PULSANDO ALT+A ó LA TECLA ENTER", "INTRODUZCA SU NOMBRE DE USUARIO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Y SU CONTRASEÑA Y PRESIONE ESTE BOTON", Global.OSBL_SYSTEM.My.Resources.Resources.descarga, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.ButtonX1.TabIndex = 4
        Me.ButtonX1.Text = "&ACEPTAR"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX2.Location = New System.Drawing.Point(275, 146)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(125, 54)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTooltip1.SetSuperTooltip(Me.ButtonX2, New DevComponents.DotNetBar.SuperTooltipInfo("CYPLUS", "PUEDE USAR LAS TECLAS DE ACCESO RAPIDO PULSANDO ALT+S ó LA TECLA ESC", "PARA SALIR COMPLETAMENTE DEL SISTEMA PULSE ESTE BOTON", Global.OSBL_SYSTEM.My.Resources.Resources.descarga, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray))
        Me.ButtonX2.TabIndex = 5
        Me.ButtonX2.Text = "&SALIR"
        '
        'EP
        '
        Me.EP.ContainerControl = Me
        '
        'FRMINICIPRINCIPAL
        '
        Me.AcceptButton = Me.ButtonX1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonX2
        Me.ClientSize = New System.Drawing.Size(457, 229)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.TXTPASS)
        Me.Controls.Add(Me.TXTUSUARIO)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "FRMINICIPRINCIPAL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SEGURIDAD ADMINISTRATIVA"
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTUSUARIO As System.Windows.Forms.TextBox
    Friend WithEvents TXTPASS As System.Windows.Forms.TextBox
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip

End Class
