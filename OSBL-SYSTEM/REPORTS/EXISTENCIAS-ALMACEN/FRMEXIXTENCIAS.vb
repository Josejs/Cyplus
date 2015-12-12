Imports System.Data
Imports System.Data.SqlClient


Public Class FRMEXIXTENCIAS

    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()

        End If
    End Sub

    Private Sub EDICIONToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EDICIONToolStripMenuItem.Click
        Try
            Dim dst As New CYPLUSDataSet

            Dim tb As New CYPLUSDataSetTableAdapters.EXISTENCIASTableAdapter


            tb.Fill(dst.Tables("EXISTENCIAS"))

            Dim rep As New RPEXISTENCIAS

            rep.SetDataSource(dst)

            Me.CrystalReportViewer1.ReportSource = rep
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
End Class