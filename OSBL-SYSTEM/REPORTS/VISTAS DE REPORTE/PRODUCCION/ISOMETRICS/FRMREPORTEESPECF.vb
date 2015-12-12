Imports System.Data
Imports System.Data.SqlClient


Public Class FRMREPORTEESPECF

    Private Sub GENERARToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GENERARToolStripMenuItem.Click
        Try
            Dim dst As New CYPLUSDataSet

            Dim tb As New CYPLUSDataSetTableAdapters.SELEC_ESPEFTableAdapter


            tb.Fill(dst.Tables("SELEC_ESPEF"), TXESPECIF.Text)

            Dim rep As New RPISOMESPECIF

            rep.SetDataSource(dst)

            Me.CRVSPOOL.ReportSource = rep
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try

    End Sub

   
    Private Sub SALIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR EL INFORME?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()

        End If
    End Sub

    Private Sub TXESPECIF_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXESPECIF.TextChanged
        Try
            Dim cmd As New SqlCommand("Select ESPECIFICACION FROM TBL_ISO", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "TBL_ISO")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("ESPECIFICACION").ToString())
            Next
            TXESPECIF.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXESPECIF.AutoCompleteCustomSource = col
            TXESPECIF.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
End Class