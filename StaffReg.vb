Imports System.Data.OleDb

Public Class StaffReg
    Dim connString As String
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim da1 As OleDbDataAdapter
    Dim con As System.Data.OleDb.OleDbConnection
    Dim cmd2 As OleDbCommandBuilder
    Dim index As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btReg.Click

        If tbName.Text = "" Then
            MsgBox("Enter Staff Name ", MsgBoxStyle.Information)
        ElseIf tbPhone.Text = "" Then
            MsgBox("Enter Phone Number ", MsgBoxStyle.Information)
        ElseIf tbPass.Text = "" Then
            MsgBox("Enter Password ", MsgBoxStyle.Information)
        Else


            Try
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
                myConnection.ConnectionString = connString
                myConnection.Open()
                Dim str2 As String
                str2 = "SELECT * FROM Staff Where Sname='" & tbName.Text & "'"
                Dim cmd2 As New OleDbCommand(str2, myConnection)
                Dim dr As OleDbDataReader = cmd2.ExecuteReader
                Dim userFound As Boolean = False
                Dim Sname As String = ""
                While dr.Read
                    userFound = True
                    Sname = dr("Sname").ToString
                End While
                myConnection.Close()
                If userFound = True Then
                    MsgBox("Name already exist. Try another Name", MsgBoxStyle.OkOnly, "Already Exist")

                ElseIf userFound = False Then

                    myConnection.Open()
                    Dim str As String
                    str = "INSERT INTO Staff([Sname],[Phone],[Password]) Values (?,?,?)"
                    Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
                    cmd.Parameters.Add(New OleDbParameter("Sname", CType(tbName.Text, String)))
                    cmd.Parameters.Add(New OleDbParameter("Phone", CType(tbPhone.Text, String)))
                    cmd.Parameters.Add(New OleDbParameter("Password", CType(tbPass.Text, String)))
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    myConnection.Close()
                    tbName.Clear()
                    tbPhone.Clear()
                    tbPass.Clear()
                    MsgBox("Registration successfull", MsgBoxStyle.OkOnly)


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
            query1 = "SELECT * FROM Staff"
            da1 = New OleDbDataAdapter(query1, connString)
            cmd2 = New OleDbCommandBuilder(da1)
            myConnection.Close()
            da1.Update(AnoopDataSet1.Staff)
            Me.AnoopDataSet1.Staff.Clear() '//clears the dataset
            da1.Fill(AnoopDataSet1.Staff)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btReset.Click
        tbName.Clear()
        tbPhone.Clear()
        tbPass.Clear()
    End Sub

    Private Sub StaffReg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AnoopDataSet1.Staff' table. You can move, or remove it, as needed.
        Me.StaffTableAdapter.Fill(Me.AnoopDataSet1.Staff)
        'TODO: This line of code loads data into the 'AnoopDataSet1.Staff' table. You can move, or remove it, as needed.
        Me.StaffTableAdapter.Fill(Me.AnoopDataSet1.Staff)
        'TODO: This line of code loads data into the 'AnoopDataSet1.Staff' table. You can move, or remove it, as needed.
        ' Me.StaffTableAdapter.Fill(Me.AnoopDataSet1.Staff)
        Try
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb"
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim query1 As String
            query1 = "SELECT * FROM Staff"
            da1 = New OleDbDataAdapter(query1, connString)
            cmd2 = New OleDbCommandBuilder(da1)
            da1.Update(AnoopDataSet1.Staff)
            Me.AnoopDataSet1.Staff.Clear() '//clears the dataset
            da1.Fill(AnoopDataSet1.Staff)
            myConnection.Close()

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub


    Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        Select Case MsgBox("Are you sure? you want to delete this Item?", MsgBoxStyle.YesNo, "Delete Record")

            Case MsgBoxResult.Yes

                'Dim v As String = DataGridView1.Rows(index).Cells(0).Value
                Try
                    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Anoop.accdb")
                    con.Open()
                    Dim str As String
                    str = " Delete * from Staff where Sname = '" & DataGridView1.Rows(index).Cells(1).Value & "' "
                    Dim cmd As New OleDbCommand(str, con)
                    cmd.ExecuteNonQuery()
                    MsgBox("Record Deleted Successfully", MsgBoxStyle.OkOnly)
                    con.Close()
                Catch
                    MsgBox("Error", MsgBoxStyle.OkOnly)
                End Try
                Try
                    'DataGridView1.Rows.RemoveAt(index)
                    Dim f1 As New StaffReg
                    f1.Show()
                    Me.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                tbName.Clear()
                tbPhone.Clear()
                tbPass.Clear()

            Case MsgBoxResult.No

        End Select

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.Rows(index)
        tbName.Text = selectedRow.Cells(1).Value.ToString
        tbPhone.Text = selectedRow.Cells(2).Value.ToString
        tbPass.Text = selectedRow.Cells(3).Value.ToString

        'btReg.Enabled = False

    End Sub

    Private Sub tbPhone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbPhone.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or ((e.KeyChar = ".") And (sender.Text.IndexOf(".") = -1)))
    End Sub

    Private Sub tbSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSearch.TextChanged
        If tbSearch.Text = "" Then
            Dim f1 As New StaffReg
            f1.Show()
            Me.Close()

            Exit Sub
        Else
            Dim item As String = tbSearch.Text
            StaffBindingSource.Filter = "Sname LIKE '" & tbSearch.Text & "%'"

            If StaffBindingSource.Count <> 0 Then
                With DataGridView1
                    .DataSource = StaffBindingSource
                End With
            Else

                MsgBox("Staff " & item & vbNewLine & _
                       "The Staff name not Found ", MsgBoxStyle.Information, "Not Found !")

            End If
        End If
    End Sub

    Private Sub tbPhone_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPhone.TextChanged

    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()

    End Sub
End Class