Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class FRMSABANACAPTURA
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
    Private Sub SALIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()
            ' FRMINICIOCALID.Show()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LBHORA.Text = "SON LAS: " + Format(DateTime.Now, "hh:mm:ss tt")
        LBFECHA.Text = "HOY ES:" + Format(Now(), "dd/MM/yyyy")
    End Sub

  

    Private Sub FRMSABANACAPTURA_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      
        '***********************************************************************************
       




    End Sub

    Private Sub EXPORTARAEXCELToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EXPORTARAEXCELToolStripMenuItem.Click

    End Sub

    Private Sub INFORMESABANAToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        FRMREPORTSABANA.Show()
    End Sub

    Private Sub INFORMESABANAPORESPECIFICACIONToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles INFORMESABANAPORESPECIFICACIONToolStripMenuItem.Click
        FRMREPORTSABANAESPECIFICACION.Show()
    End Sub

    Private Sub SABANAPORLINEAToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SABANAPORLINEAToolStripMenuItem.Click
        Call GridAExcel(DVGSABANA)
    End Sub

    Private Sub SABANAPORESPECIFICACIONToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SABANAPORESPECIFICACIONToolStripMenuItem.Click
        Call GridAExcel(DataGridView1)
    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("SABANA_FINAL", CN)
            COMANDO.CommandType = CommandType.StoredProcedure

            ADP = New SqlDataAdapter(COMANDO)
            DT = New DataTable
            ADP.Fill(DT)
            DVGSABANA.DataSource = DT

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        Try
            CONECTARBD()
            COMANDO = New SqlCommand("SABANA_ESPECIFICACION", CN)
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
End Class