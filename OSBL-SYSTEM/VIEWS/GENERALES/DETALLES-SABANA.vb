Imports System.Data
Imports System.Data.SqlClient
Public Class DETALLES_SABANA


#Region "METODOS"
    Public Function LlamarDatos(ByVal Consulta As String)
        With COMANDO
            .CommandType = CommandType.Text
            .CommandText = Consulta
            .Connection = CN
        End With
        ADP.SelectCommand = COMANDO
        Return 0
    End Function
    Sub LLENAG1()
        Try
            ' LlamarDatos("select NUM_ISO,SPOOL_P,JUNTA_P,TIPO1_P ,TIPO_JTA_P,CAMP_TALLER_P,DIAM_JTA,ESPECIFICACION_P,COLADA  from PRODUCCION_DIARIA join JUNTAS on PRODUCCION_DIARIA.ISOMETRICO_P=NUM_ISO AND SPOOL_P= SPOOL join MAT_ISO  on ISOMETRICO_P=ISOMETRICO group by NUM_ISO,SPOOL_P ,JUNTA_P,TIPO1_P,TIPO_JTA_P ,CAMP_TALLER_P,DIAM_JTA,ESPECIFICACION_P,COLADA")
            DT = New DataTable
            ADP.Fill(DT)
            DVG1.DataSource = DT
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




   

#End Region



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LBHORA.Text = "SON LAS: " + Format(DateTime.Now, "hh:mm:ss tt")
        LBFECHA.Text = "HOY ES:" + Format(Now(), "dd/MM/yyyy")
    End Sub

    Private Sub DETALLES_SABANA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LLENAG1()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' LLENAG2()
    End Sub
    Function GridAExcel(ByVal ElGrid As DataGridView) As Boolean
        'Creamos las variables
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet
        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()
            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = ElGrid.ColumnCount
            Dim NRow As Integer = ElGrid.RowCount
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).Name.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next
            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                Next
            Next
            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()
            'Aplicación visible
            exApp.Application.Visible = True
            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return True
    End Function
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Call GridAExcel(DVG1)
    End Sub
End Class