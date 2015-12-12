﻿Imports System.Data
Imports System.Data.SqlClient
Public Class FRMREPORTSABANAESPECIFICACION

    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()
            ' FRMINICIOCALID.Show()
        End If
    End Sub

    Private Sub GENERARToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles GENERARToolStripMenuItem.Click
        Try
            Dim dst As New CYPLUSDataSet

            Dim tb As New CYPLUSDataSetTableAdapters.SABANA_ESPECIFICACIONTableAdapter


            tb.Fill(dst.Tables("SABANA_ESPECIFICACION"))

            Dim rep As New RPSABANAESPECIFICACION

            rep.SetDataSource(dst)

            Me.crvdiaria.ReportSource = rep
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
End Class