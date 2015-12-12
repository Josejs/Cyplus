Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop 'LIBRERIA PARA MANDAR A EXCEL LOS DATOS
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Configuration.ConfigurationManager

Public Class REGISTROLISTAISOMETRICO

#Region "METODOS"
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
    Public Function LlamarDatos(ByVal Consulta As String)
        With COMANDO
            .CommandType = CommandType.Text
            .CommandText = Consulta
            .Connection = CN
        End With
        ADP.SelectCommand = COMANDO
        Return 0
    End Function
#End Region



    Private Sub REGISTROLISTAISOMETRICO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            If CheckBox1.Checked = True Then
                LlamarDatos("SELECT * FROM TBL_ISO ")
                dt = New DataTable
                ADP.Fill(dt)
                DataGridView1.DataSource = DT
                TextBox1.Enabled = False

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Label1.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged
        If Not CheckBox1.Checked Then
            TextBox1.Enabled = True

            TextBox1.Text = ""
        Else
            TextBox1.Enabled = False

            TextBox1.Text = ""

        End If

    End Sub


    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            BASICDATA.TXTID.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value
            BASICDATA.TXTNUMISOS.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value
            BASICDATA.CBISOMETRICO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value
            BASICDATA.TXTREV.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value
            BASICDATA.TXTNOLINEA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(3).Value

            BASICDATA.CBSERVICIOISOMETRICO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(4).Value
            BASICDATA.CBESPECIFICACIONISOMETRICO.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(5).Value
            BASICDATA.TXTRX.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(6).Value
            BASICDATA.CBAREA.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value



            BASICDATA.TXTCABEZAL.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(8).Value
            BASICDATA.TXTCODPINT.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(9).Value
            BASICDATA.TXTOT.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(10).Value
   

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()

        End If
    End Sub

    Private Sub EXPORTARAEXCELToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EXPORTARAEXCELToolStripMenuItem.Click
        Call GridAExcel(DataGridView1)
    End Sub

    Private Sub ACTUALIZARTABLAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACTUALIZARTABLAToolStripMenuItem.Click
        Try
            If CheckBox1.Checked = True Then
                LlamarDatos("SELECT * FROM TBL_ISO ")
                DT = New DataTable
                ADP.Fill(DT)
                DataGridView1.DataSource = DT
                TextBox1.Enabled = False

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If RadioButton2.Checked Then
            LlamarDatos("SELECT * FROM TBL_ISO WHERE NUM_ISO LIKE '%" & TextBox2.Text & "%' ORDER BY NUM_ISO ASC")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView1.DataSource = DT
        End If
        Label1.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub

  
   
   
    Private Sub txtespecifica_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtespecifica.TextChanged
        If respecifica.Checked Then
            LlamarDatos("SELECT * FROM TBL_ISO WHERE ESPECIFICACION LIKE '%" & txtespecifica.Text & "%' ORDER BY ESPECIFICACION ASC")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView1.DataSource = DT
        End If
        Label1.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        If RSERV.Checked Then
            LlamarDatos("SELECT * FROM TBL_ISO WHERE SERVICIO LIKE '%" & TextBox3.Text & "%' ORDER BY SERVICIO ASC")
            DT = New DataTable

            ADP.Fill(DT)
            DataGridView1.DataSource = DT
        End If
        Label1.Text = Me.DataGridView1.Rows.Count & " REGISTROS"
    End Sub
End Class