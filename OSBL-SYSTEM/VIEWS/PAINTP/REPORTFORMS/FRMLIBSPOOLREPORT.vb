Imports System.Data
Imports System.Data.SqlClient



Public Class FRMLIBSPOOLREPORT


    Sub OBJ_AREA()
        Try
            CONECTARBD()
            CADENA = "SELECT DISTINCT NO_ORDEN from TBL_SPOOL"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            CBNUMERO.DataSource = DS.Tables(0)
            CBNUMERO.DisplayMember = "NO_ORDEN"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()


        End Try
    End Sub 'LLENA LA LISTA DE AREA

 
    Private Sub FRMLIBSPOOLREPORT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OBJ_AREA()
    End Sub

    Private Sub GENERARToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GENERARToolStripMenuItem.Click
        Try
            Dim dst As New CYPLUSDataSet

            Dim tb As New CYPLUSDataSetTableAdapters.SEL_LIBTableAdapter


            tb.Fill(dst.Tables("SEL_LIB"), CBNUMERO.Text)

            Dim rep As New RPLIBCOND

            rep.SetDataSource(dst)

            Me.CRVSPOOL.ReportSource = rep
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
End Class