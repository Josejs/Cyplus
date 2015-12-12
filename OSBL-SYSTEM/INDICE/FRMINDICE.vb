Imports System.Data
Imports System.Data.SqlClient
Public Class FRMINDICE


    Sub OBJ_AREA()
        Try
            CONECTARBD()
            CADENA = "SELECT DISTINCT [N°_EMBARQUE] from TBL_SPOOL"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            CBINDICE.DataSource = DS.Tables(0)
            CBINDICE.DisplayMember = "N°_EMBARQUE"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()


        End Try
    End Sub 'LLENA LA LISTA DE AREA


    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR INFORME?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub

    Private Sub GENERARToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles GENERARToolStripMenuItem.Click
        Try
            Dim dst As New CYPLUSDataSet

            Dim tb As New CYPLUSDataSetTableAdapters.SP_CYP_INDICE_EMBARQUETableAdapter


            tb.Fill(dst.Tables("SP_CYP_INDICE_EMBARQUE"), CBINDICE.Text)

            Dim rep As New CRVINDICE

            rep.SetDataSource(dst)

            Me.crvdiaria.ReportSource = rep
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub FRMINDICE_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'CYPLUSDataSet.TBL_SPOOL' Puede moverla o quitarla según sea necesario.

        OBJ_AREA()
    End Sub
End Class