Imports System.Data
Imports System.Data.SqlClient

Public Class FRMSALIDASFECHAALMACEN

    Private Sub GENERARToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GENERARToolStripMenuItem.Click
        Try
            Dim dst As New CYPLUSDataSet

            Dim tb As New CYPLUSDataSetTableAdapters.SELECCION_SALIDA_ALMACENTableAdapter


            tb.Fill(dst.Tables("SELECCION_SALIDA_ALMACEN"), dtfecha.Text)

            Dim rep As New RPSALIDAFECHA

            rep.SetDataSource(dst)

            Me.CRVENTRADAALMACEN.ReportSource = rep
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub SALIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR INFORME?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()


        End If
    End Sub
End Class