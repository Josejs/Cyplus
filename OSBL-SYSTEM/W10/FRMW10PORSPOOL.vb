Imports System.Data
Imports System.Data.SqlClient

Public Class FRMW10PORSPOOL

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

            Dim tb As New CYPLUSDataSetTableAdapters.Traza_dos_por_spoolTableAdapter


            tb.Fill(dst.Tables("Traza_dos_por_spool"), TXTISOMETRICO.Text, TXTSPOOL.Text)

            Dim rep As New w10porspool

            rep.SetDataSource(dst)

            Me.CRVW10.ReportSource = rep
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub TXTISOMETRICO_TextChanged(sender As System.Object, e As System.EventArgs) Handles TXTISOMETRICO.TextChanged
        Try
            Dim cmd As New SqlCommand("Select NUM_ISO FROM TBL_ISO", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "TBL_ISO")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("NUM_ISO").ToString())
            Next
            TXTISOMETRICO.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXTISOMETRICO.AutoCompleteCustomSource = col
            TXTISOMETRICO.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()
        End Try
    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click
        Try
            CONECTARBD()
            CADENA = "SELECT DISTINCT NUMERO_SPOOL from TBL_SPOOL where NUMERO_ISOMETRICO='" & TXTISOMETRICO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            txtspool.DataSource = DS.Tables(0)
            txtspool.DisplayMember = "NUMERO_SPOOL"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()


        End Try
    End Sub

    Private Sub FRMW10PORSPOOL_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class