Imports System.Data
Imports System.Data.SqlClient

Public Class REPORTDAILYQUERY

    Private Sub REPORTDAILYQUERY_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub GENERARToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GENERARToolStripMenuItem.Click
        Try
            Dim dst As New CYPLUSDataSet

            Dim tb As New CYPLUSDataSetTableAdapters.SELC_R_DTableAdapter


            tb.Fill(dst.Tables("SELC_R_D"), CBISOMETRICO.Text, CBJUNTAS.Text)

            Dim rep As New RDQSELECCION

            rep.SetDataSource(dst)

            Me.CRVSPOOL.ReportSource = rep
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub SALIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALIRToolStripMenuItem.Click

    End Sub
End Class