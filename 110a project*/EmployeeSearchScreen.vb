Public Class EmployeeSearchScreen

    Private Sub btnAddNewBooks_Click(sender As Object, e As EventArgs) Handles btnAddNewBooks.Click
        Dim ResourceID, title As String
        Dim Genre As String
        Dim CheckoutPeriod As Integer



        If dgvEmployee.SelectedCells.Count = 0 Then

        Else

            Dim MyChar() As Char = {"b"}
            Dim NumberOfRows As Integer
            Dim rowdata As Object


            'store ResourceID
            title = dgvEmployee.SelectedCells(0).Value

            ResourceID = dgvEmployee.SelectedCells(7).Value
            ResourceID = ResourceID.TrimStart(MyChar)
            ResourceID = ResourceID.Remove(7)
            ResourceAdd.txtResourceID.Text = ResourceID
            ResourceID = "%" & ResourceID & "%"
            NumberOfRows = LibraryResourcesTableAdapter.FillByTitle(DatabaseDataSet.LibraryResources, title)
            ResourceAdd.cbxCopyNumber.SelectedIndex = NumberOfRows

            'Autofill Resource information to Resource Add page
            rowdata = LibraryResourcesTableAdapter.GetDataByTitle(title)(0)
            ResourceAdd.txtTitle.Text = rowdata.title
            ResourceAdd.txtLastName.Text = rowdata.AuthorLast
            ResourceAdd.txtFirstName.Text = rowdata.AuthorFirst
            ResourceAdd.txtMiddleName.Text = rowdata.AuthorMiddle
            ResourceAdd.txtPublicationYear.Text = rowdata.PublicationDate
            ResourceAdd.txtSeries.Text = rowdata.Series
            ResourceAdd.txtISBN.Text = rowdata.ISBN

            CheckoutPeriod = rowdata.CheckOutPeriod
            If CheckoutPeriod = 14 Then
                ResourceAdd.cbxCheckoutPeriod.SelectedIndex = 1
            End If
            If CheckoutPeriod = 28 Then
                ResourceAdd.cbxCheckoutPeriod.SelectedIndex = 3
            End If
            ResourceAdd.txtBookInfo.Text = rowdata.BookInfo

            Genre = rowdata.Genre
            If Genre = "Fantasy" Then
                ResourceAdd.cbxGenre.SelectedIndex = 2
            End If
            If Genre = "ScienceFiction" Then
                ResourceAdd.cbxGenre.SelectedIndex = 0
            End If

            ResourceAdd.cbxAgeGroup.SelectedIndex = 1

        End If




        ResourceAdd.Show()
        Me.Hide()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        HomeScreen.Show()
        Me.Close()

    End Sub

    Private Sub btnSearchByTitle_Click(sender As Object, e As EventArgs) Handles btnSearchByTitle.Click
        dgvEmployee.Rows.Clear()
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
                dgvEmployee.ReadOnly = True

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


                dgvEmployee.Rows.Add(dgvRow)
                'Results is the name of the DataGridView Control added to the Form

            Next
        Else
            MessageBox.Show("No entries found")
        End If
    End Sub

    Private Sub btnSearchByLast_Click(sender As Object, e As EventArgs) Handles btnSearchByLast.Click
        Dim NumberOfRows As Integer
        Dim bookinfo As Object
        Dim FirstName, ISBN, Series, Genre, Bookdescription, ResourceID As String
        Dim Title As String
        Dim LastName As String
        Dim search As String
        search = "%" & txtSearch.Text & "%"
        'in this example members must click a button to view their currently checked out books. 
        dgvEmployee.Rows.Clear()
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
                dgvEmployee.ReadOnly = True

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


                dgvEmployee.Rows.Add(dgvRow)
                'Results is the name of the DataGridView Control added to the Form
            Next
        Else
            MessageBox.Show("No entries found")
        End If
    End Sub

    Private Sub btnNewSearch_Click(sender As Object, e As EventArgs) Handles btnNewSearch.Click
        txtSearch.Text = String.Empty
        dgvEmployee.Rows.Clear()
        txtSearch.Focus()

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles lblEmployeeName.Click

    End Sub
End Class