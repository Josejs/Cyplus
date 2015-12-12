Imports System.Data
Imports System.Data.SqlClient
Public Class FRMREPORTEPORTADA

    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR INFORME?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub

    Private Sub TXTISOMETRICO_TextChanged(sender As System.Object, e As System.EventArgs) Handles TXTISOMETRICO.TextChanged
        Try
            Dim cmd As New SqlCommand("Select ISOMETRICO FROM CHECKLIST_PND", CN)
            If CN.State = ConnectionState.Closed Then CN.Open()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "CHECKLIST_PND")

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("ISOMETRICO").ToString())
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
            CADENA = "SELECT DISTINCT SPOOL from CHECKLIST_PND where ISOMETRICO='" & TXTISOMETRICO.Text & "'"
            COMANDO = New SqlCommand()
            COMANDO.CommandText = CADENA
            COMANDO.CommandType = CommandType.Text
            COMANDO.Connection = CN
            ADP = New SqlDataAdapter(COMANDO)
            DS = New DataSet()
            ADP.Fill(DS)

            txtspool.DataSource = DS.Tables(0)
            txtspool.DisplayMember = "SPOOL"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()


        End Try
    End Sub

    Private Sub GENERARToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GENERARToolStripMenuItem.Click
        Try
            Dim dst As New CYPLUSDataSet

            Dim tb As New CYPLUSDataSetTableAdapters.SELEC_PORTADA_SPOOLTableAdapter


            tb.Fill(dst.Tables("SELEC_PORTADA_SPOOL"), TXTISOMETRICO.Text, txtspool.Text)

            Dim rep As New RPPORTADASPOOL

            rep.SetDataSource(dst)

            Me.crvdiaria.ReportSource = rep
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub FRMREPORTEPORTADA_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class