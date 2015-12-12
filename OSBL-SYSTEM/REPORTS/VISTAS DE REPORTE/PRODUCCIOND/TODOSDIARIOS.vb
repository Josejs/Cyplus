Imports System.Data
Imports System.Data.SqlClient
Public Class TODOSDIARIOS

    Private Sub GENERARToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GENERARToolStripMenuItem.Click
        Try
            Dim dst As New CYPLUSDataSet

            Dim tb As New CYPLUSDataSetTableAdapters.PRODUCCION_DIARIATableAdapter


            tb.Fill(dst.Tables("PRODUCCION_DIARIA"))

            Dim rep As New RPPRODUCCIONDIARIALINEA

            rep.SetDataSource(dst)

            Me.crvdiaria.ReportSource = rep
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub SALIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR INFORME?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub

    Private Sub TODOSDIARIOS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class