Imports System.Data
Imports System.Data.SqlClient

Public Class capturaestimacion

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        LBHORA3.Text = "SON LAS: " + Format(DateTime.Now, "hh:mm:ss tt")
        LBFECHA3.Text = "HOY ES:" + Format(Now(), "dd/MM/yyyy")
    End Sub

    Private Sub VERToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VERToolStripMenuItem.Click
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("ESTIMACION_GCG", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            ADP = New SqlDataAdapter(COMANDO)
            DT = New DataTable
            ADP.Fill(DT)
            DataGridView1.DataSource = DT

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()
            ' FRMINICIOCALID.Show()
        End If
    End Sub

    Private Sub GUARDARDATOSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GUARDARDATOSToolStripMenuItem.Click
      
    End Sub

    Private Sub capturaestimacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class