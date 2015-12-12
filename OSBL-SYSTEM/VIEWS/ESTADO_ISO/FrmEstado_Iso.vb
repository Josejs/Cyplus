﻿Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Public Class FrmEstado_Iso
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

    Private Sub SALIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SALIRToolStripMenuItem.Click
        If (MessageBox.Show("¿DESEA CERRAR?", "CYPLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        Else
            Me.Close()

        End If
    End Sub

    Private Sub EXPORTARAEXCELToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EXPORTARAEXCELToolStripMenuItem.Click
        Call GridAExcel(DvgEst)
    End Sub

    Private Sub FrmEstado_Iso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            CONECTARBD()
            Dim DA As New SqlDataAdapter("EXEC STATUS_ISO", CN)
            Dim DT As New DataTable

            DA.Fill(DT)
            DvgEst.DataSource = DT
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub ACTUALIZARTABLAToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ACTUALIZARTABLAToolStripMenuItem.Click
        Try
            CONECTARBD()
            Dim DA As New SqlDataAdapter("EXEC STATUS_ISO", CN)
            Dim DT As New DataTable

            DA.Fill(DT)
            DvgEst.DataSource = DT
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            DECONECTARBD()

        End Try
    End Sub

    Private Sub DvgEst_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DvgEst.CellEnter
        If IsDBNull(DvgEst.Rows(e.RowIndex).Cells(0).Value) Then
            TXTISOMETRICO.Text = "-"
        Else
            TXTISOMETRICO.Text = DvgEst.Rows(e.RowIndex).Cells(0).Value
        End If


        If IsDBNull(DvgEst.Rows(e.RowIndex).Cells(1).Value) Then
            TXTSPOOL.Text = "-"
        Else
            TXTSPOOL.Text = DvgEst.Rows(e.RowIndex).Cells(1).Value
        End If

        If IsDBNull(DvgEst.Rows(e.RowIndex).Cells(2).Value) Then
            TXTESTADO.Text = "-"
        Else
            TXTESTADO.Text = DvgEst.Rows(e.RowIndex).Cells(2).Value
        End If

        If IsDBNull(DvgEst.Rows(e.RowIndex).Cells(3).Value) Then
            TXTSTATUS.Text = "-"
        Else
            TXTSTATUS.Text = DvgEst.Rows(e.RowIndex).Cells(3).Value
        End If


    End Sub

    Private Sub IMPRIMIRINFORMEToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles IMPRIMIRINFORMEToolStripMenuItem.Click
        FRMSTATUSISO.Show()

    End Sub
End Class