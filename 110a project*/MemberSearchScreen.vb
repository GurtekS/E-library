Public Class MemberSearchScreen

    Dim user As Object
    Dim FirstName, LastName, StreetAddress, City, State, Email, MemberID As String
    Dim Zip As String



   

    Private Sub BtnBackPack_Click(sender As Object, e As EventArgs) Handles BtnBackPack.Click
        Email = Login.txtLoginEmail.Text
        user = LibraryMembersTableAdapter.GetDataByEmail(Login.txtLoginEmail.Text)(0)
        FirstName = user.FirstName
        LastName = user.LastName
        StreetAddress = user.StreetAddress
        City = user.city
        State = user.State
        Zip = user.Zip
        MemberID = user.MemberID
        MyBackPack.RefreshCurrentItems()
        MyBackPack.lblName.Text = FirstName + " " + LastName
        MyBackPack.lblAddress.Text = StreetAddress + " " + City + ", " + State + " " + Zip
        MyBackPack.lblEmail.Text = Email
        MyBackPack.lblMemberID.Text = MemberID
        MyBackPack.Show()
        Me.Hide()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        HomeScreen.Show()
        Me.Close()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
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
        LibraryResourcesDataGridView.Rows.Clear()
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
                LibraryResourcesDataGridView.ReadOnly = True

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


                LibraryResourcesDataGridView.Rows.Add(dgvRow)
                'Results is the name of the DataGridView Control added to the Form
            Next
        Else
            MessageBox.Show("No entries found")
        End If

    End Sub

    Private Sub BtnCheckout_Click(sender As Object, e As EventArgs) Handles BtnCheckout.Click
        Dim ResourceID As String
        Dim TempMem As Integer
        Dim X As Integer
        Dim CurrentDate As Date



        If LibraryResourcesDataGridView.SelectedCells.Count = 0 Then
            MessageBox.Show("Please select the book you wish to checkout")
        Else
            X = LibraryResourcesDataGridView.SelectedRows.Count
            For X = 0 To X - 1
                'renew book by altering the due date and updating the record selected in ‘the “results” data grid the numbers in parentheses are the index of the ‘data grid column holding the piece of information needed.
                ResourceID = LibraryResourcesDataGridView.SelectedCells(7).Value
                TempMem = CheckOutTableAdapter.FillByCheckoutReturnDate(DatabaseDataSet.CheckOut, ResourceID)
                If TempMem > 0 Then
                    MessageBox.Show("Book is not available")
                Else
                    'Insert new Enty checkout table
                    CurrentDate = Date.Now

                    CheckOutTableAdapter.Insert(ResourceID, Login.USER.MemberID, CurrentDate, Nothing)
                    Me.Cursor = Cursors.WaitCursor
                    '
                    Dim Mail As New System.Net.Mail.MailMessage()
                    With Mail
                        .To.Add(Login.txtLoginEmail.Text)
                        .From = New Net.Mail.MailAddress("KADigitalBooks@gmail.com") 'Must be: *@gmail.com
                        .Subject = "You Have Successfully checked out , " & " " & LibraryResourcesDataGridView.SelectedCells(0).Value
                        .Body = "Heres the Information on the book you checked out" & " " & vbCrLf _
                            & " Book Title" & " " & "=" & " " & LibraryResourcesDataGridView.SelectedCells(0).Value & " " & vbCrLf _
                            & " Authors First Name" & " " & "=" & " " & LibraryResourcesDataGridView.SelectedCells(1).Value & " " & vbCrLf _
                            & " Authors Last Name " & " " & "=" & " " & LibraryResourcesDataGridView.SelectedCells(2).Value & " " & vbCrLf _
                            & " The ISBN Number" & " " & "=" & " " & LibraryResourcesDataGridView.SelectedCells(3).Value & " " & vbCrLf _
                            & " The Book Series" & " " & "=" & " " & LibraryResourcesDataGridView.SelectedCells(4).Value & " " & vbCrLf _
                            & " The Book Genre" & " " & "=" & " " & LibraryResourcesDataGridView.SelectedCells(5).Value & " " & vbCrLf _
                            & " And The Book Description" & " " & "=" & " " & LibraryResourcesDataGridView.SelectedCells(6).Value

                    End With
                    '
                    Dim SMTP As New Net.Mail.SmtpClient("SMTP.gmail.com")
                    SMTP.Credentials = New System.Net.NetworkCredential("KADigitalBooks@gmail.com", "Kick@$$Books") 'Must be: *@gmail.com
                    SMTP.Port = 587
                    SMTP.Host = "smtp.gmail.com"
                    SMTP.EnableSsl = True
                    SMTP.Send(Mail)
                    SMTP = Nothing
                    Mail.Dispose()
                    MessageBox.Show("Book has been placed into your BackPack and a Confirmation email has been sent")
                End If


            Next

        End If
    End Sub

    Private Sub btnSearchByTitle_Click(sender As Object, e As EventArgs) Handles btnSearchByTitle.Click
        LibraryResourcesDataGridView.Rows.Clear()
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
                LibraryResourcesDataGridView.ReadOnly = True

                'add title to the first column of the DataGridView
                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = Title
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


                LibraryResourcesDataGridView.Rows.Add(dgvRow)
                'Results is the name of the DataGridView Control added to the Form

            Next
        Else
            MessageBox.Show("No entries found")
        End If
    End Sub

    Private Sub btnNewSearch_Click(sender As Object, e As EventArgs) Handles btnNewSearch.Click
        txtSearch.Text = String.Empty
        LibraryResourcesDataGridView.Rows.Clear()
        txtSearch.Focus()

    End Sub
End Class