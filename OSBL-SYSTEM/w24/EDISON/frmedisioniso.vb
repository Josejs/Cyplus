Imports System.Data
Imports System.Data.SqlClient

Public Class frmedisioniso

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

            Dim tb As New CYPLUSDataSetTableAdapters.SP_SEL_W24_ISO_CAMPTableAdapter



            tb.Fill(dst.Tables("SP_SEL_W24_ISO_CAMP"), TXTISOMETRICO.Text)

            Dim rep As New CRVW24XISO

            rep.SetDataSource(dst)

            Me.CRVW10.ReportSource = rep
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub
End Class