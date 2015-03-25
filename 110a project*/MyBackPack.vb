Public Class MyBackPack
    Public Sub RefreshCurrentItems()
        Dim RowData As Object
        Dim CheckoutPeriod As Long
        Dim NumberOfRows As Integer
        Dim bookinfo As Object
        Dim resourceid As String
        Dim DueDate As Date
        Dim checkoutdate As Date
        Dim memberid As String = Login.USER.MemberID




        'in this example members must click a button to view their currently checked out books.  
        dgvResults.Rows.Clear()
        'determine the number of books the current member has checked out.
        NumberOfRows = CheckOutTableAdapter.FillByMemberID(DatabaseDataSet.CheckOut, Login.USER.MemberID)

        TextBox1.Text = NumberOfRows
        'if the member has at least one book checked out then…
        If NumberOfRows > 0 Then

            Dim x As Integer = 0
            'begin a loop that will add information for each of the currently checked out books one at a time, to the DataGridView
            'you can reorder these columns, remove some of them or add new ones as you wish
            For x = 0 To NumberOfRows - 1 Step 1

                bookinfo = CheckOutTableAdapter.GetDataByMemberID(memberid)(x)
                resourceid = bookinfo.resourceID
                'at “due” to the due date so that the member knows when the book is due


                RowData = LibraryResourcesTableAdapter.GetDataByResourceID(resourceid)(0)
                'calculate the due date for a book based on the check out date and the book’s checkout period.
                checkoutdate = bookinfo.checkoutdate
                CheckoutPeriod = RowData.checkoutperiod
                DueDate = DateAdd(DateInterval.Day, CheckoutPeriod, checkoutdate)

                'add information for the checked out resource to the DataGridView
                Dim dgvRow As New DataGridViewRow
                Dim dgvCell As DataGridViewCell
                dgvResults.ReadOnly = True

                'add title to the first column of the DataGridView
                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = RowData.title
                dgvRow.Cells.Add(dgvCell)

                'add checkout data to the 5th column of the DataGridView
                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = checkoutdate.Date
                dgvRow.Cells.Add(dgvCell)

                'add resourcestatus, created above, to the 6th column of the DataGridView
                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = DueDate.Date
                dgvRow.Cells.Add(dgvCell)

                dgvCell = New DataGridViewTextBoxCell()
                dgvCell.Value = resourceid
                dgvRow.Cells.Add(dgvCell)

                dgvResults.Rows.Add(dgvRow)
                'Results is the name of the DataGridView Control added to the Form

            Next
        End If


    End Sub


    Private Sub BtnReturn_Click(sender As Object, e As EventArgs) Handles BtnReturn.Click
        Dim currentdate As Date = Date.Today.Date
        Dim ResourceID As String
        Dim X As Integer


        If dgvResults.SelectedCells.Count = 0 Then
            MessageBox.Show("Please select the book you wish to return")
        Else
            X = dgvResults.SelectedRows.Count
            For X = 0 To X - 1
                'renew book by altering the due date and updating the record selected in ‘the “results” data grid the numbers in parentheses are the index of the ‘data grid column holding the piece of information needed.
                ResourceID = dgvResults.SelectedCells(3).Value
                CheckOutTableAdapter.ReturnBookUpdateQuery(currentdate, ResourceID)
                Me.RefreshCurrentItems()

            Next

            MessageBox.Show("you have successfully returned your book.", " Book Returned Successful", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub BtnRenew_Click(sender As Object, e As EventArgs) Handles BtnRenew.Click
        Dim currentdate As Date = Date.Today.Date
        Dim ResourceID As String
        Dim X As Integer


        If dgvResults.SelectedCells.Count = 0 Then
            MessageBox.Show("Please select the book you wish to renew")
        Else
            X = dgvResults.SelectedRows.Count
            'renew book by altering the due date and updating the record selected in ‘the “results” data grid the numbers in parentheses are the index of the ‘data grid column holding the piece of information needed.
            For X = 0 To X - 1
                ResourceID = dgvResults.SelectedCells(3).Value
                CheckOutTableAdapter.RenewBookUpdateQuery(currentdate, ResourceID)
                Me.RefreshCurrentItems()
            Next
            MessageBox.Show("you have successfully renewed your book.", " Book Renewal Successful", MessageBoxButtons.OK)
        End If

    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles BtnBack.Click
        MemberSearchScreen.txtSearch.Clear()
        MemberSearchScreen.LibraryResourcesDataGridView.Rows.Clear()
        MemberSearchScreen.Show()
        Me.Hide()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        HomeScreen.Show()
        Me.Close()
    End Sub

    Private Sub dgvResults_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResults.CellContentClick

    End Sub
End Class