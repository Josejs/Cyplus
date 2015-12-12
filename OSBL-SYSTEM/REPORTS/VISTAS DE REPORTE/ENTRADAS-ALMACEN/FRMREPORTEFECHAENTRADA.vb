Imports System.Data
Imports System.Data.SqlClient
Public Class FRMREPORTEFECHAENTRADA

    Private Sub SALIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR INFORME?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()


        End If
    End Sub

    Private Sub GENERARToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GENERARToolStripMenuItem.Click
        Try
            Dim dst As New CYPLUSDataSet

            Dim tb As New CYPLUSDataSetTableAdapters.SELECCION_ALMACEN_FTableAdapter


            tb.Fill(dst.Tables("SELECCION_ALMACEN_F"), dtfecha.Text)

            Dim rep As New RPENTRADAF

            rep.SetDataSource(dst)

            Me.CRVENTRADAALMACEN.ReportSource = rep
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
End Class