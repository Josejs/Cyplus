Imports System.Data
Imports System.Data.SqlClient

Public Class PACKINGCONDICION

#Region "METODOS"
    Sub OBJ_SERVICIO()
        Try
            CONECTARBD()
            CADENA = "SELECT  DISTINCT NO_PACKINGLIST from TBL_SPOOL"
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




    Private Sub SALIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR EL INFORME?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()

        End If
    End Sub

    Private Sub PACKINGCONDICION_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OBJ_SERVICIO()
    End Sub

    Private Sub GENERARToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GENERARToolStripMenuItem.Click
        Try
            Dim dst As New CYPLUSDataSet

            Dim tb As New CYPLUSDataSetTableAdapters.SELEC_PCK_CONDTableAdapter


            tb.Fill(dst.Tables("SELEC_PCK_COND"), CBPACKING.Text)

            Dim rep As New RPCONDICIONFINAL

            rep.SetDataSource(dst)

            Me.CRVPACKING.ReportSource = rep
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
End Class