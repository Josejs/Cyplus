Imports System.Data
Imports System.Data.SqlClient

Public Class FRMESTIMACIONES

    Private Sub GENERARToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GENERARToolStripMenuItem.Click
        Try
            Dim dst As New CYPLUSDataSet

            Dim tb As New CYPLUSDataSetTableAdapters.SP_SEL_ESTIMACIONES_GADTableAdapter


            tb.Fill(dst.Tables("SP_SEL_ESTIMACIONES_GAD"))

            Dim rep As New rpESTIMACION

            rep.SetDataSource(dst)

            Me.crvdiaria.ReportSource = rep
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
End Class