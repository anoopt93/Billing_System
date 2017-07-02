Imports System.Data.OleDb
Imports System.Data.DataTable
Imports System.Drawing.Printing

Public Class Invoice
    Dim connString As String
    Dim myConnection As OleDbConnection = New OleDbConnection
    'Dim da1 As OleDbDataAdapter
    'Dim cmd2 As OleDbCommandBuilder
    Dim con As System.Data.OleDb.OleDbConnection
    Dim index As Integer
    Private BMP As Bitmap
    Dim scAutoComplete As New AutoCompleteStringCollection
    Public quantity As Integer
    Dim delindex As Integer




    Private Sub Invoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AnoopDataSet4.Table1' table. You can move, or remove it, as needed.
        'Me.Table1TableAdapter1.Fill(Me.AnoopDataSet4.Table1)
   

        DataGridView1.AllowUserToResizeRows = False

        DataGridView1.ClearSelection()

        DataGridView1.CurrentCell = DataGridView1.Item("Product", 0)

        DataGridView1.BeginEdit(True)


        Me.LabelName.Visible = False
        Me.LabelPhone.Visible = False

        'Load Tax value from Table Tax
        Try
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim str As String
            str = "SELECT tax FROM Tax "
            Dim cmd2 As New OleDbCommand(str, myConnection)
            Dim dr1 As OleDbDataReader = cmd2.ExecuteReader
            If dr1.Read = True Then
                Me.LbTax.Text = dr1.Item(0)
            End If
            myConnection.Close()

            ' Hide tax labels if the tax is set to 0
            If LbTax.Text = 0 Then

                Me.Label8.Visible = False
                ' Me.LabelTax.Visible = False
                Me.LbTax.Visible = False
                Me.Label10.Visible = False
            End If
        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        'Load Discount% value from Table Discount
        Try
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim str As String
            str = "SELECT discount FROM Discount "
            Dim cmd2 As New OleDbCommand(str, myConnection)
            Dim dr1 As OleDbDataReader = cmd2.ExecuteReader
            If dr1.Read = True Then
                Me.LbDisc.Text = dr1.Item(0)
            End If
            myConnection.Close()

            ' Hide Discount labels if the tax is set to 0
            If LbDisc.Text = 0 Then
                Me.LbDisc.Visible = False
                Me.LbDiscTotal.Visible = False
                Me.Label18.Visible = False
                Me.Label19.Visible = False

            End If
        Catch ex As Exception

            MsgBox(ex.Message)

        End Try




        'Set Invoice Number(Auto generated)

        Try
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim str As String
            str = "SELECT  Max(Id) FROM Sales "
            Dim cmd2 As New OleDbCommand(str, myConnection)
            Dim dr2 As OleDbDataReader = cmd2.ExecuteReader
            If dr2.Read = True Then
                Me.Label11.Text = dr2.Item(0) + 1
            End If
            myConnection.Close()
        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        'Load Stock Details with quantity Less than 10

        Try
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim query1 As String
            query1 = "SELECT * FROM Table1 WHERE Qty<=10"
            Dim da1 As New OleDbDataAdapter(query1, connString)
            Dim cmd2
            cmd2 = New OleDbCommandBuilder(da1)
            da1.Update(AnoopDataSet4.Table1)
            Me.AnoopDataSet4.Table1.Clear() '//clears the dataset
            da1.Fill(AnoopDataSet4.Table1)
            myConnection.Close()

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try


        ' Auto complete Product textbox in Datagridview

        Try

            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
            myConnection.ConnectionString = connString
            Dim ds As New DataSet
            Dim da As OleDbDataAdapter
            da = New OleDbDataAdapter("Select * from [Table1]", myConnection)
            'da.Fill(ds, "Table1")
            DataGridView1.DataSource = ds.Tables("Table1")


            Dim cmd As New OleDbCommand("Select P_name From Table1", myConnection)
            Dim dr As OleDbDataReader
            myConnection.Open()
            dr = cmd.ExecuteReader
            Do While dr.Read
                scAutoComplete.Add(dr.GetString(0))
            Loop
            myConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        'Set Date

        Label12.Text = System.DateTime.Now

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click

        Dim f1 As New Invoice
        f1.Label5.Text = Me.Label5.Text
        f1.Show()
        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrint.Click

        'Save Bill Details To Sales Table

        Try
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim str As String
            str = "INSERT INTO Sales([Bill_no],[Sdate],[User],[Total]) Values (?,?,?,?)"
            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
            cmd.Parameters.Add(New OleDbParameter("Bill_no", CType(Label11.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Sdate", CType(Label12.Text, Date)))
            cmd.Parameters.Add(New OleDbParameter("User", CType(Label5.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("Total", CType(LabelTotal.Text, String)))

            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myConnection.Close()
            MsgBox("Saved successfully", MsgBoxStyle.OkOnly)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



        'Reduce Product Quantity from Table1(Product's Table) 

        Try
            Dim index As Integer = 0
            For index = 0 To DataGridView1.RowCount - 1


                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
                myConnection.ConnectionString = connString
                myConnection.Open()
                Dim str As String
                str = "Update Table1 SET Qty = Qty-'" & DataGridView1.Rows(index).Cells(2).Value & "' WHERE P_name ='" & DataGridView1.Rows(index).Cells(1).Value & "'"
                Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                myConnection.Close()
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        If TextBox1.Text = "" Then
            TextBox1.Visible = False
            LabelName.Visible = False
        Else
            TextBox1.Visible = False
            LabelName.Text = TextBox1.Text
            LabelName.Visible = True
        End If
        If TextBox2.Text = "" Then
            TextBox2.Visible = False
            LabelPhone.Visible = False
        Else
            TextBox2.Visible = False
            LabelPhone.Text = TextBox2.Text
            LabelPhone.Visible = True
        End If

        Me.DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.RowHeadersVisible = False
        'Me.DataGridView1.Columns(5).Visible = False
        Me.DataGridView1.DefaultCellStyle.SelectionBackColor = Me.DataGridView1.DefaultCellStyle.BackColor
        Me.DataGridView1.DefaultCellStyle.SelectionForeColor = Me.DataGridView1.DefaultCellStyle.ForeColor

        'Print Bill
        Try

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
            'ppd.Document = pd
            'ppd.ShowDialog(Me)

            pd.Print()      'actually print data
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ' Refresh the page after Print
        Dim f1 As New Invoice
        f1.Label5.Text = Me.Label5.Text
        f1.Show()
        Me.Close()

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        delindex = e.RowIndex
    End Sub



    Private Sub DataGridView1_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellLeave



        'Autofill Price Column in DataGridview1

        Try

            For index = DataGridView1.CurrentCell.RowIndex To DataGridView1.RowCount - 1


                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
                myConnection.ConnectionString = connString
                Dim ds As New DataSet

                DataGridView1.DataSource = ds.Tables("Table1")
                Dim cmd As New OleDbCommand("SELECT Price FROM Table1 WHERE P_name='" & DataGridView1.Rows(index).Cells(1).Value & "'", myConnection)
                Dim dr As OleDbDataReader
                myConnection.Open()
                dr = cmd.ExecuteReader
                ' index = DataGridView1.CurrentCell.RowIndex
                Do While dr.Read()

                    DataGridView1.Rows(index).Cells(3).Value = dr.GetValue(0)
                    ' index = index + 1
                Loop
                myConnection.Close()


            Next
            index = index + 1


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



        'Auto fill Tax column
        Try

            For j As Integer = 0 To DataGridView1.RowCount - 1
                If LbTax.Text = 0 Then
                    DataGridView1.Rows(j).Cells(4).Value = 0
                Else
                    DataGridView1.Rows(j).Cells(4).Value = ((DataGridView1.Rows(j).Cells(2).Value * DataGridView1.Rows(j).Cells(3).Value) * LbTax.Text) / 100
                End If
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        'Autofill Amount Column
        Try

            For i As Integer = 0 To DataGridView1.RowCount - 1

                DataGridView1.Rows(i).Cells(5).Value = (DataGridView1.Rows(i).Cells(2).Value * DataGridView1.Rows(i).Cells(3).Value) + DataGridView1.Rows(i).Cells(4).Value

            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ' Calculate Subtotal
        Dim amttotal As Double = 0
        For i As Integer = 0 To DataGridView1.RowCount - 1

            amttotal += DataGridView1.Rows(i).Cells(5).Value
            LabelAmtTotal.Text = amttotal

            'Calculate Discount
            Dim dis As Double = 0
            If LbDisc.Text = 0 Then
                LbDiscTotal.Text = 0
            Else

                dis = (amttotal * LbDisc.Text) / 100
                LbDiscTotal.Text = Format(dis, "0.00")

            End If
            'Calculate Grand Total
            Dim Total As Double = (amttotal) - LbDiscTotal.Text

            LabelTotal.Text = Total
        Next

        If (DataGridView1.Rows.Count >= 11) Then

            MsgBox(" Save, Print the Bill. Press New Button for new Bill ")
            Me.DataGridView1.AllowUserToAddRows = False


        End If

    End Sub
    Private Sub DataGridView1_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridView1.DefaultValuesNeeded
        'With e.Row
        '.Cells("Qty").Value = "1"

        'End With
    End Sub


    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing

        'Autofill/Suggest Product name in DataGridview1
        'Dim titleText As String = DataGridView1.Columns(1).HeaderText
        'If titleText.Equals("Product") AndAlso TypeOf e.Control Is TextBox Then
        If DataGridView1.CurrentCell.ColumnIndex = 1 AndAlso TypeOf e.Control Is TextBox Then
            With DirectCast(e.Control, TextBox)
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.CustomSource
                .AutoCompleteCustomSource = scAutoComplete

            End With
        Else
            With DirectCast(e.Control, TextBox)
                .AutoCompleteMode = AutoCompleteMode.None
            End With
        End If

    End Sub

    Private Sub DataGridView1_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DataGridView1.RowPrePaint

        'Serial No for each item in bill
        Try

        If e.RowIndex >= 0 Then
            Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value = e.RowIndex + 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click

        'Delete Selected Row
        Try
            DataGridView1.Rows.RemoveAt(delindex)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ' Calculations..............................

        ' Calculate Subtotal
        Dim amttotal As Double = 0
        For i As Integer = 0 To DataGridView1.RowCount - 1

            amttotal += DataGridView1.Rows(i).Cells(5).Value
            LabelAmtTotal.Text = amttotal

            'Calculate Discount
            Dim dis As Double = 0
            If LbDisc.Text = 0 Then
                LbDiscTotal.Text = 0
            Else

                dis = (amttotal * LbDisc.Text) / 100
                LbDiscTotal.Text = dis
            End If
            'Calculate Grand Total
            Dim Total As Double = (amttotal) - LbDiscTotal.Text

            LabelTotal.Text = Total
        Next

        Me.DataGridView1.AllowUserToAddRows = True



    End Sub

    'Enter Key Work as Tab key
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If (Me.DataGridView1.Focused OrElse Me.DataGridView1.EditMode) AndAlso keyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)

    End Function
    ' Validation for Qty Coloumn
    Private Sub DataGridView1_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
        If DataGridView1.CurrentCell.ColumnIndex = 2 Then
            Me.DataGridView1.Rows(e.RowIndex).ErrorText = ""
            Dim newInteger As Integer
            If DataGridView1.Rows(e.RowIndex).IsNewRow Then Return
            If Not Integer.TryParse(e.FormattedValue.ToString(), newInteger) _
               OrElse newInteger < 0 Then
                e.Cancel = True
                ' Me.DataGridView1.Rows(e.RowIndex).ErrorText = "the value must be a non-negative integer"
                MsgBox("Enter Quantity", MsgBoxStyle.Information)
            End If
        End If

    End Sub

    ' Vertical Line for DataGridview
    Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
        Dim columnSum As Integer
        For x As Integer = 0 To DataGridView1.Columns.Count - 2
            columnSum += DataGridView1.Columns(x).Width
            e.Graphics.DrawLine(New Pen(Brushes.Black), columnSum + 1, 0, columnSum + 1, DataGridView1.Height)
        Next
    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        'Checking for Item available or not

        If e.ColumnIndex = 2 Then


            Try
                Dim i As Integer = 0
                For i = DataGridView1.CurrentCell.RowIndex To DataGridView1.RowCount - 1

                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
                    myConnection.ConnectionString = connString
                    Dim ds2 As New DataSet
                    Dim da2 As OleDbDataAdapter
                    da2 = New OleDbDataAdapter("Select * from [Table1]", myConnection)
                    DataGridView1.DataSource = ds2.Tables("Table1")


                    Dim cmd2 As New OleDbCommand("Select Qty From Table1 Where P_name ='" & DataGridView1.Rows(i).Cells(1).Value & "'", myConnection)
                    Dim dr2 As OleDbDataReader
                    myConnection.Open()
                    dr2 = cmd2.ExecuteReader
                    Do While dr2.Read

                        quantity = dr2.GetValue(0)


                        If DataGridView1.CurrentCell.ColumnIndex = 2 Then


                            Dim cur As Integer
                            cur = DataGridView1.Rows(i).Cells(2).Value
                            If DataGridView1.Rows(i).Cells(2).Value > quantity Then

                                MsgBox("Only " & quantity & " Items available.")
                                DataGridView1.Rows(i).Cells(2).Value = 0
                            End If

                        End If
                        ''Dim str As New OleDbCommand("UPDATE Table1 SET Qty = Qty-'" & DataGridView1.Rows(i).Cells(2).Value & "'WHERE P_name='" & DataGridView1.Rows(i).Cells(1).Value & "'", myConnection)
                        ''str.ExecuteNonQuery()
                        ''Me.DataGridView2.Refresh()

                    Loop
                    myConnection.Close()
                Next


                i = i + 1
            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        'Rectangle
        Dim blackPen As New Pen(Color.FromArgb(255, 0, 0, 0), 1)
        e.Graphics.DrawRectangle(blackPen, 16, 420, 737, 80)
        'Vertical Line
        e.Graphics.DrawLine(New Pen(Brushes.Black), 502, 420, 502, 500)
        'Boarder
        Dim Pen1 As New Pen(Color.FromArgb(255, 0, 0, 0), 2)
        e.Graphics.DrawRectangle(Pen1, 5, 8, 760, 523)
        'e.Graphics.DrawRectangle(New Pen(Brushes.Black), 5, 8, 760, 523)
        'Horizontal Line
        e.Graphics.DrawLine(New Pen(Brushes.Black), 502, 460, 752, 460)
        e.Graphics.DrawLine(New Pen(Brushes.Black), 502, 495, 752, 495)



    End Sub

End Class