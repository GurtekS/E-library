Public Class Login

    Public USER As Object

    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        Dim NumberOfRows As Integer
        Dim RowData As Object
        Dim Password As String = String.Empty



        'If there is no text in the email or password textbox then
        If txtLoginEmail.Text = "" Or txtLogInPassword.Text = "" Then
            'Message box “Please fill insert email and password”
            MessageBox.Show("Please enter an email and password.")
            txtLoginEmail.Clear()
            txtLogInPassword.Clear()
            txtLoginEmail.Focus()


            'ElseIf RadioButton = Not Enabled Then
        ElseIf rdbEmployee.Checked = False Then
            'Query search for member table for email
            'NumberOfRowsMember = fillbyEmail from Members Table
            NumberOfRows = LibraryMembersTableAdapter.FillByEmail(DatabaseDataSet.LibraryMembers, txtLoginEmail.Text)
            If NumberOfRows = 1 Then
                RowData = LibraryMembersTableAdapter.GetDataByEmail(txtLoginEmail.Text)(0)
                USER = RowData
                Password = RowData.password
                If txtLogInPassword.Text = Password Then
                    MessageBox.Show("Welcome!")
                    MemberSearchScreen.lblMemberName.Text = "Welcome, " + USER.FirstName + "!"
                    MemberSearchScreen.Show()
                    Me.Hide()
                Else
                    MessageBox.Show(" Login failed. Please try again.")
                    txtLoginEmail.Clear()
                    txtLogInPassword.Clear()
                    txtLoginEmail.Focus()
                End If
            Else
                MessageBox.Show("Email not valid. Please register.")
                txtLoginEmail.Clear()
                txtLogInPassword.Clear()
                txtLoginEmail.Focus()
            End If
        ElseIf rdbEmployee.Checked = True Then

            'Query search employee table
            NumberOfRows = EmployeeTableAdapter.FillByEmail(DatabaseDataSet.Employee, txtLoginEmail.Text)
            If NumberOfRows = 1 Then
                RowData = EmployeeTableAdapter.GetDataByEmail(txtLoginEmail.Text)(0)
                USER = RowData
                Password = RowData.password
                If txtLogInPassword.Text = Password Then
                    MessageBox.Show("Welcome!")
                    EmployeeSearchScreen.lblEmployeeName.Text = "Welcome, " + USER.FirstName + "!"
                    EmployeeSearchScreen.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Login failed. Please try again.")
                    txtLoginEmail.Clear()
                    txtLogInPassword.Clear()
                    txtLoginEmail.Focus()
                End If
            Else
                MessageBox.Show("Email not valid. Please register.")
                txtLoginEmail.Clear()
                txtLogInPassword.Clear()
                txtLoginEmail.Focus()
            End If
        End If
        MemberSearchScreen.txtSearch.Clear()
        MemberSearchScreen.LibraryResourcesDataGridView.ClearSelection()
        EmployeeSearchScreen.txtSearch.Clear()
        EmployeeSearchScreen.dgvEmployee.ClearSelection()

    End Sub

    Private Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles BtnRegister.Click
        Registration.Show()
        Me.Hide()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class
