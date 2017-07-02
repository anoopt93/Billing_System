
Imports System.Data.OleDb
Imports System.Drawing.Printing
Imports System.Text
Imports System.IO

Public Class Report

    Dim connString As String
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim da1 As OleDbDataAdapter
    Dim cmd2 As OleDbCommandBuilder
    Dim con As System.Data.OleDb.OleDbConnection
    Private BMP As Bitmap

    Private Sub Report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AnoopDataSet2.Sales' table. You can move, or remove it, as needed.
        ' Me.SalesTableAdapter.Fill(Me.AnoopDataSet2.Sales)


        ' Load data to DataGridview1 
        Try
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim query1 As String
            query1 = "SELECT * FROM Sales"
            da1 = New OleDbDataAdapter(query1, connString)
            cmd2 = New OleDbCommandBuilder(da1)
            da1.Update(AnoopDataSet2.Sales)
            Me.AnoopDataSet2.Sales.Clear() '//clears the dataset
            da1.Fill(AnoopDataSet2.Sales)
            cmd2.Dispose()
            myConnection.Close()

            Dim total As String = 0
            For i As Integer = 0 To DataGridView1.RowCount - 1
                total += DataGridView1.Rows(i).Cells(4).Value
            Next
            TotalLabel.Text = total

            myConnection.Close()
        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        'Add Items to Combobox1

        Try
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim query1 As String
            query1 = "SELECT DISTINCT(User) From Sales"
            Dim cmd As New OleDbCommand(query1, myConnection)
            Dim dr As OleDbDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr("User"))

            End While

            myConnection.Close()

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If ComboBox1.Text = "" Then

            MsgBox("Select a User", MsgBoxStyle.OkOnly, "User?")

        End If

        Try
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim strDate As Date = DateTimePicker1.Text
            Dim endDate As Date = DateTimePicker2.Text
            Dim query1 As String
            query1 = "SELECT * FROM Sales WHERE SDate between # " & strDate & " # and # " & endDate & " # AND User ='" & ComboBox1.Text & "'"
            da1 = New OleDbDataAdapter(query1, connString)
            cmd2 = New OleDbCommandBuilder(da1)
            da1.Update(AnoopDataSet2.Sales)
            Me.AnoopDataSet2.Sales.Clear() '//clears the dataset
            da1.Fill(AnoopDataSet2.Sales)
            myConnection.Close()

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try
        Dim total As String = 0
        For i As Integer = 0 To DataGridView1.RowCount - 1
            total += DataGridView1.Rows(i).Cells(4).Value
        Next
        TotalLabel.Text = total

    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.RowHeadersVisible = False

        'Print Panel

        Dim pd As New PrintDocument
        Dim pdialog As New PrintDialog
        Dim ppd As New PrintPreviewDialog
        BMP = New Bitmap(Panel1.Width, Panel1.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        Panel1.DrawToBitmap(BMP, New Rectangle(0, 0, Panel1.Width, Panel1.Height))
        AddHandler pd.PrintPage, (Sub(s, args)
                                      args.Graphics.DrawImage(BMP, 0, 0)
                                      args.HasMorePages = False
                                  End Sub)

        'choose a printer
        pdialog.ShowDialog(Me)
        pd.PrinterSettings.PrinterName = pdialog.PrinterSettings.PrinterName

        If pd.PrinterSettings.CanDuplex.ToString Then
            pd.PrinterSettings.Duplex = Duplex.Vertical
        End If

        'Preview the document
        ppd.Document = pd
        ppd.ShowDialog(Me)


        pd.Print()      'actually print data
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    Private Sub btTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTotal.Click


        Try
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim strDate As Date = DateTimePicker1.Text
            Dim endDate As Date = DateTimePicker2.Text
            Dim query1 As String
            query1 = "SELECT * FROM Sales WHERE SDate between # " & strDate & " # and # " & endDate & " # "
            da1 = New OleDbDataAdapter(query1, connString)
            cmd2 = New OleDbCommandBuilder(da1)
            da1.Update(AnoopDataSet2.Sales)
            Me.AnoopDataSet2.Sales.Clear() '//clears the dataset
            da1.Fill(AnoopDataSet2.Sales)
            myConnection.Close()

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try
        Dim total As String = 0
        For i As Integer = 0 To DataGridView1.RowCount - 1
            total += DataGridView1.Rows(i).Cells(4).Value
        Next
        TotalLabel.Text = total
    End Sub

End Class