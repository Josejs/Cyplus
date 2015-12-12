Imports System.Data
Imports System.Data.SqlClient

Public Class FRM_INFORME_FERRITA
    Sub OBJ_SPOOL()
        Try
            '  CONECTARBD2()
            CADENA = "SELECT  DISTINCT NUMERO_SPOOL from TBL_SPOOL WHERE NUMERO_ISOMETRICO='" & TXESPECIF.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN2
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            CBSPOOL.DataSource = DS.Tables(0)
            CBSPOOL.DisplayMember = "NUMERO_SPOOL"


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD2()


        End Try
    End Sub
    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        OBJ_SPOOL()

    End Sub

    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR INFORME?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub

    Private Sub GENERARToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GENERARToolStripMenuItem.Click
        Try
            Dim dst As New CYPLUSDataSet

            Dim tb As New CYPLUSDataSetTableAdapters.CYP_REPORTE_FERRITATableAdapter


            tb.Fill(dst.Tables("CYP_REPORTE_FERRITA"), TXESPECIF.Text, CBSPOOL.Text)

            Dim rep As New CRVFERRITA_ISO

            rep.SetDataSource(dst)

            Me.CRVSPOOL.ReportSource = rep
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
End Class