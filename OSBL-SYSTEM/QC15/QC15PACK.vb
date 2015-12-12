Imports System.Data
Imports System.Data.SqlClient

Public Class QC15PACK
    Sub OBJ_AREA()
        Try
            CONECTARBD()
            CADENA = "SELECT DISTINCT NO_PACKINGLIST from TBL_SPOOL ORDER BY NO_PACKINGLIST ASC"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            TXTNUMPACK.DataSource = DS.Tables(0)
            TXTNUMPACK.DisplayMember = "NO_PACKINGLIST"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()


        End Try
    End Sub 'LLENA LA LISTA DE AREA




    Private Sub GENERARToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GENERARToolStripMenuItem.Click
        Try
            Dim dst As New CYPLUSDataSet

            Dim tb As New CYPLUSDataSetTableAdapters.PACKING_LISTTableAdapter


            tb.Fill(dst.Tables("PACKING_LIST"), TXTNUMPACK.Text)

            Dim rep As New QC15REP

            rep.SetDataSource(dst)

            Me.CRVSPOOL.ReportSource = rep
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR EL INFORME?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()

        End If
    End Sub

    Private Sub QC15PACK_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        OBJ_AREA()
    End Sub
End Class