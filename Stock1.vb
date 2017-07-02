Imports System.Data.OleDb

Public Class Stock1
    Dim connString As String
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim da1 As OleDbDataAdapter
    Dim cmd2 As OleDbCommandBuilder
    Dim con As System.Data.OleDb.OleDbConnection
    Dim index As Integer

    Private Sub Stock1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AnoopDataSet2.Table1' table. You can move, or remove it, as needed.
        Me.Table1TableAdapter.Fill(Me.AnoopDataSet2.Table1)
        'TODO: This line of code loads data into the 'AnoopDataSet.Table1' table. You can move, or remove it, as needed.
        'Me.Table1TableAdapter.Fill(Me.AnoopDataSet.Table1)
        Try
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim query1 As String
            query1 = "SELECT * FROM Table1"
            da1 = New OleDbDataAdapter(query1, connString)
            cmd2 = New OleDbCommandBuilder(da1)
            myConnection.Close()
            da1.Update(AnoopDataSet2.Table1)
            Me.AnoopDataSet2.Table1.Clear() '//clears the dataset
            da1.Fill(AnoopDataSet2.Table1)
            myConnection.Close()
        Catch ex As Exception

            MsgBox(ex.Message)

        End Try
        

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
        
            If tbPname.Text = "" Then
                MsgBox("Enter Product Name ", MsgBoxStyle.Information)
            ElseIf tbPrice.Text = "" Then
                MsgBox("Enter Product Price ", MsgBoxStyle.Information)
            ElseIf tbQty.Text = "" Then
                MsgBox("Enter Product Quantity ", MsgBoxStyle.Information)
            Else

                Try

                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
                    myConnection.ConnectionString = connString
                    myConnection.Open()

                    Dim str2 As String
                    str2 = "SELECT * FROM Table1 Where P_name='" & tbPname.Text & "'"
                    Dim cmd2 As New OleDbCommand(str2, myConnection)
                    Dim dr As OleDbDataReader = cmd2.ExecuteReader
                    Dim userFound As Boolean = False
                    Dim Sname As String = ""
                    While dr.Read
                        userFound = True
                        Sname = dr("P_name").ToString
                    End While
                    myConnection.Close()
                    If userFound = True Then

                        MsgBox("Item already exist. Try another", MsgBoxStyle.OkOnly, "Already Exist")

                    Else

                        myConnection.Open()
                        Dim str As String
                        str = "INSERT INTO Table1([P_name],[Price],[Qty]) Values (?,?,?)"
                        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)

                        'cmd.Parameters.Add(New OleDbParameter("P_id", CType(tbPid.Text, String)))
                    cmd.Parameters.Add(New OleDbParameter("P_name", CType(tbPname.Text.ToUpper, String)))
                        cmd.Parameters.Add(New OleDbParameter("Price", CType(tbPrice.Text, String)))
                        cmd.Parameters.Add(New OleDbParameter("Qty", CType(tbQty.Text, String)))
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                        myConnection.Close()
                        tbPname.Clear()
                        tbPrice.Clear()
                        tbQty.Clear()
                        MsgBox("1 Item added successfully", MsgBoxStyle.OkOnly)

                    End If


                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If


            Try
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
                myConnection.ConnectionString = connString
                myConnection.Open()
                Dim query1 As String
                query1 = "SELECT * FROM Table1"
                da1 = New OleDbDataAdapter(query1, connString)
                cmd2 = New OleDbCommandBuilder(da1)
                myConnection.Close()
                da1.Update(AnoopDataSet2.Table1)
                Me.AnoopDataSet2.Table1.Clear() '//clears the dataset
                da1.Fill(AnoopDataSet2.Table1)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btReset.Click
        tbPname.Clear()
        tbPrice.Clear()
        tbQty.Clear()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click

        Select Case MsgBox("Are you sure? you want to delete this Item?", MsgBoxStyle.YesNo, "Delete Record")

            Case MsgBoxResult.Yes

                Dim v As String = DataGridView1.Rows(index).Cells(0).Value
                Try

                    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb")
                    con.Open()
                    Dim cmd As New OleDbCommand("Delete from Table1 where id = " + v, con)
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Record Deleted Successfully", MsgBoxStyle.OkOnly)

                Catch
                    MsgBox("Error", MsgBoxStyle.OkOnly)
                End Try
                Try


                    ' DataGridView1.Rows.RemoveAt(index)

                    Dim f1 As New Stock1
                    f1.Show()
                    Me.Close()


                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                tbPname.Clear()
                tbPrice.Clear()
                tbQty.Clear()

            Case MsgBoxResult.No

        End Select
    End Sub


    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.Rows(index)
        tbPname.Text = selectedRow.Cells(1).Value.ToString
        tbPrice.Text = selectedRow.Cells(2).Value.ToString
        tbQty.Text = selectedRow.Cells(3).Value.ToString

        'btAdd.Enabled = False
        'tbPname.Enabled = False



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUpdate.Click

        Dim newDataRow As DataGridViewRow
        Try
            newDataRow = DataGridView1.Rows(index)

            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim str As String

            str = "UPDATE Table1 SET P_name= '" & tbPname.Text.ToUpper & "',Price= '" & tbPrice.Text & "',Qty= '" & tbQty.Text & "' WHERE id=" & DataGridView1.Rows(index).Cells(0).Value & ""
            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)


            cmd.ExecuteNonQuery()
            ' cmd.Dispose()
            myConnection.Close()
            tbPname.Clear()
            tbPrice.Clear()
            tbQty.Clear()
            MsgBox("1 Item Updated successfully", MsgBoxStyle.OkOnly)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try

            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim query1 As String
            query1 = "SELECT * FROM Table1"
            da1 = New OleDbDataAdapter(query1, connString)
            cmd2 = New OleDbCommandBuilder(da1)
            da1.Update(AnoopDataSet2.Table1)
            Me.AnoopDataSet2.Table1.Clear() '//clears the dataset
            da1.Fill(AnoopDataSet2.Table1)
            myConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub tbQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbQty.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
             Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

    Private Sub tbSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSearch.TextChanged
        Try

            If tbSearch.Text = "" Then
                Dim f1 As New Stock1
                f1.Show()
                Me.Close()

                Exit Sub
            Else
                Dim item As String = tbSearch.Text
                Table1BindingSource.Filter = "P_name LIKE '" & tbSearch.Text & "%'"

                If Table1BindingSource.Count <> 0 Then
                    With DataGridView1
                        .DataSource = Table1BindingSource
                    End With
                Else

                    MsgBox("Product " & item & vbNewLine & _
                           "The Search Item not Found ", MsgBoxStyle.Information, "Not Found !")

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tbPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPrice.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = ".") And (sender.Text.IndexOf(".") = -1)))
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub
End Class