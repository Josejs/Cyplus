
Imports System.Data
Imports System.Data.SqlClient


Public Class vistaConsulta
    Public Function LlamarDatos(ByVal Consulta As String)
        With COMANDO
            .CommandType = CommandType.Text
            .CommandText = Consulta
            .Connection = CN
        End With
        ADP.SelectCommand = COMANDO
        Return 0
    End Function

    Private Sub vistaConsulta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LlamarDatos("SELECT * FROM JUNTAS WHERE NUM_ISO ='" & DAILYREPORT.TXTISOMETRICO.Text & "' ORDER BY JUNTA ASC")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView1.DataSource = DT

            LlamarDatos("SELECT * FROM PRODUCCION_DIARIA WHERE ISOMETRICO_p ='" & DAILYREPORT.TXTISOMETRICO.Text & "' ORDER BY JUNTA_p ASC")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView2.DataSource = DT

            LlamarDatos("SELECT * FROM ALMACEN") ' WHERE ISOMETRICO ='" & DAILYREPORT.TXTISOMETRICO.Text & "' ORDER BY JUNTA ASC")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView3.DataSource = DT
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub
End Class