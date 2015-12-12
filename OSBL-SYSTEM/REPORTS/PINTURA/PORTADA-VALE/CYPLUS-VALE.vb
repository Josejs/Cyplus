Imports System.Data
Imports System.Data.SqlClient
Public Class CYPLUS_VALE
    Sub OBJ_AREA()
        Try
            CONECTARBD()
            CADENA = "SELECT DISTINCT NO_EMBARQUE  from TBL_SPOOL ORDER BY NO_EMBARQUE ASC"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            ComboBoxEx1.DataSource = DS.Tables(0)
            ComboBoxEx1.DisplayMember = "NO_EMBARQUE"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub 'LLENA LA LISTA DE AREA
    Private Sub PAKING_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        OBJ_AREA()
    End Sub

    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR EL INFORME?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()

        End If
    End Sub

    Private Sub GENERARToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GENERARToolStripMenuItem.Click
        Try
            Dim dst As New CYPLUSDataSet
            Dim tb As New CYPLUSDataSetTableAdapters.SP_REPORTE_PACKINGLIST_VALETableAdapter
            tb.Fill(dst.Tables("SP_REPORTE_PACKINGLIST_VALE"), ComboBoxEx1.Text)
            Dim f As New CRV_VALE_REPORTE
            f.SetDataSource(dst)
            'f.SetParameterValue("@PACKINGLIST", ComboBoxEx1.Text)
            Me.CRVPACKING.ReportSource = f
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub

    Private Sub GroupPanel1_Click(sender As System.Object, e As System.EventArgs) Handles GroupPanel1.Click

    End Sub

    Private Sub MATERIALToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MATERIALToolStripMenuItem.Click
        Dim ma As New CYPLUS_MATERIAL
        ma.Show()
        'ma.TextBox1.Focus()
    End Sub
End Class