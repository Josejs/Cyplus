Imports System.Data
Imports System.Data.SqlClient

Public Class FRMPORTADAPACKING
#Region "METODOS"
    Sub OBJ_SERVICIO()
        Try
            CONECTARBD()
            CADENA = "SELECT  DISTINCT NO_PACKINGLIST from TBL_SPOOL ORDER BY NO_PACKINGLIST ASC"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            CBPACKING.DataSource = DS.Tables(0)
            CBPACKING.DisplayMember = "NO_PACKINGLIST"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub 'LLENA LA LISTA DEL SERVICIO

#End Region

    Private Sub FRMPORTADAPACKING_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        OBJ_SERVICIO()
        CBPACKING.Text = PACKINGCONDICION.CBPACKING1.Text
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

            Dim tb As New CYPLUSDataSetTableAdapters.REPORT_PORTADA_PACKINGTableAdapter


            tb.Fill(dst.Tables("REPORT_PORTADA_PACKING"), CBPACKING.Text)

            Dim rep As New CRVPORTADAPACKING

            rep.SetDataSource(dst)

            Me.CRVPACKING.ReportSource = rep
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
End Class