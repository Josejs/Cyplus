Imports System.Data
Imports System.Data.SqlClient
Public Class CYPLUS_MATERIAL
    Sub OBJ_AREA()
        Try
            CONECTARBD()
            CADENA = "SELECT DISTINCT NO_PACKINGLIST from TBL_SPOOL ORDER BY NO_PACKINGLIST ASC"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)
            ComboBoxEx1.DataSource = DS.Tables(0)
            ComboBoxEx1.DisplayMember = "NO_PACKINGLIST"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub 'LLENA LA LISTA DE AREA
    Sub OBJ_AREA2()
        Try
            CONECTARBD2()
            CADENA = "SELECT DISTINCT MATERIAL_SPOOL from TBL_SPOOL ORDER BY MATERIAL_SPOOL ASC"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)
            ComboBox1.DataSource = DS.Tables(0)
            ComboBox1.DisplayMember = "MATERIAL_SPOOL"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD2()
        End Try
    End Sub 'LLENA LA LISTA DE AREA
    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR EL INFORME?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub

    Private Sub GroupPanel1_Click(sender As System.Object, e As System.EventArgs) Handles GroupPanel1.Click

    End Sub

    Private Sub PAKING_MATERIAL_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        OBJ_AREA()
        OBJ_AREA2()
    End Sub

    Private Sub GENERARToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GENERARToolStripMenuItem.Click
        Try
            Dim dst As New CYPLUSDataSet

            Dim tb As New CYPLUSDataSetTableAdapters.SP_REPORTE_PACKINGLIST_SPOOLTableAdapter

            tb.Fill(dst.Tables("SP_REPORTE_PACKINGLIST_SPOOL"), Convert.ToInt32(ComboBoxEx1.Text), ComboBox1.Text)
            Dim f As New CRV_MATERIAL
            f.SetDataSource(dst)
            'f.SetParameterValue("@MATERIAL", TextBox1.Text) 'ENVIAR PARAMETROS A CRYSTALREPORT
            'f.SetParameterValue("@PACKINGLIST", Convert.ToInt32(ComboBoxEx1.Text)) 'ENVIAR PARAMETROS A CRYSTALREPORT
            Me.CRVPACKING.ReportSource = f
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs)
        ' TextBox1.Text = UCase(TextBox1.Text) 'TEXTO MAYUSCULA
    End Sub
End Class