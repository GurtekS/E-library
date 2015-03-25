Public Class HomeScreen


    Private Sub HomeScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Login.txtLoginEmail.Clear()
        Login.txtLogInPassword.Clear()
        Login.rdbEmployee.Checked = False
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub btnLogin_Click_1(sender As Object, e As EventArgs) Handles btnLogin.Click
        Login.txtLoginEmail.Clear()
        Login.txtLogInPassword.Clear()
        Login.rdbEmployee.Checked = False
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub btnSearchLastName_Click(sender As Object, e As EventArgs) Handles btnSearchLastName.Click
        Dim NumberOfRows As Integer
        Dim bookinfo As Object
        Dim FirstName, ISBN, Series, Genre, Bookdescription, ResourceID As String
        Dim Title As String
        Dim LastName As String
        Dim search As String
        search = "%" & txtSearch.Text & "%"
        'in this example members must click a button to view their currently checked out books. 
        dgvHomeScreen.Rows.Clear()
        'determine the number of books the current member has checked out.
        NumberOfRows = LibraryResourcesTableAdapter.FillByAuthorsLast(DatabaseDataSet.LibraryResources, search)

        'if the member has at least one book checked out then…
        If NumberOfRows > 0 Then
            Dim x As Integer = 0

            'begin a loop that will add information for each of the currently checked out books one at a time, to the DataGridView
            'you can reorder these columns, remove some of them or add new ones as you wish
            For x = 0 To NumberOfRows - 1

                bookinfo = LibraryResourcesTableAdapter.GetDataByAuthorsLast(search)(x)
                Title = bookinfo.Title
                FirstName = bookinfo.AuthorFirst
                LastName = bookinfo.AuthorLast
                ISBN = bookinfo.ISBN
                Series = bookinfo.Series
                Genre = bookinfo.Genre
                Bookdescription = bookinfo.bookinfo
                ResourceID = bookinfo.ResourceID

                'add information for the checked out resource to the DataGridView
                Dim dgvRow As New DataGridViewRow
                Dim dgvCell As DataGridViewCell
                dgvHomeScreen.ReadOnly = True

                'add title to the first column of the DataGridView
                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = Title
                dgvRow.Cells.Add(dgvCell)

                'add checkout data to the 5th column of the DataGridView
                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = FirstName
                dgvRow.Cells.Add(dgvCell)

                'add resourcestatus, created above, to the 6th column of the DataGridView
                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = LastName
                dgvRow.Cells.Add(dgvCell)

                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = ISBN
                dgvRow.Cells.Add(dgvCell)

                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = Series
                dgvRow.Cells.Add(dgvCell)

                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = Genre
                dgvRow.Cells.Add(dgvCell)

                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = Bookdescription
                dgvRow.Cells.Add(dgvCell)

                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = ResourceID
                dgvRow.Cells.Add(dgvCell)


                dgvHomeScreen.Rows.Add(dgvRow)
                'Results is the name of the DataGridView Control added to the Form
            Next
        Else
            MessageBox.Show("No entries found")
        End If

    End Sub

    Private Sub btnSearchbyTitle_Click(sender As Object, e As EventArgs) Handles btnSearchbyTitle.Click
        dgvHomeScreen.Rows.Clear()
        Dim Search As String
        Search = "%" & txtSearch.Text & "%"
        Dim title As String
        Dim LastName As String
        Dim NumberOfRows As Integer
        Dim bookinfo As Object
        Dim FirstName, ISBN, Series, Genre, Bookdescription, ResourceID As String
        'determine the number of books the current member has checked out.
        NumberOfRows = LibraryResourcesTableAdapter.FillByTitle(DatabaseDataSet.LibraryResources, Search)

        'if the member has at least one book checked out then…
        If NumberOfRows > 0 Then


            Dim x As Integer = 0
            'begin a loop that will add information for each of the currently checked out books one at a time, to the DataGridView
            'you can reorder these columns, remove some of them or add new ones as you wish
            For x = 0 To NumberOfRows - 1

                bookinfo = LibraryResourcesTableAdapter.GetDataByTitle(Search)(x)
                title = bookinfo.Title
                FirstName = bookinfo.AuthorFirst
                LastName = bookinfo.AuthorLast
                ISBN = bookinfo.ISBN
                Series = bookinfo.Series
                Genre = bookinfo.Genre
                Bookdescription = bookinfo.bookinfo
                ResourceID = bookinfo.ResourceID


                'add information for the checked out resource to the DataGridView
                Dim dgvRow As New DataGridViewRow
                Dim dgvCell As DataGridViewCell
                dgvHomeScreen.ReadOnly = True

                'add title to the first column of the DataGridView
                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = title
                dgvRow.Cells.Add(dgvCell)

                'add First name to cell
                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = FirstName
                dgvRow.Cells.Add(dgvCell)

                'add Last name to cell
                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = LastName
                dgvRow.Cells.Add(dgvCell)

                'Add ISBN to cell
                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = ISBN
                dgvRow.Cells.Add(dgvCell)

                'add Series to cell
                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = Series
                dgvRow.Cells.Add(dgvCell)

                'add Series to cell
                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = Genre
                dgvRow.Cells.Add(dgvCell)

                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = Bookdescription
                dgvRow.Cells.Add(dgvCell)

                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = ResourceID
                dgvRow.Cells.Add(dgvCell)


                dgvHomeScreen.Rows.Add(dgvRow)
                'Results is the name of the DataGridView Control added to the Form

            Next
        Else
            MessageBox.Show("No entries found")
        End If
    End Sub
End Class