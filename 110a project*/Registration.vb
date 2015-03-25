Imports System.Net.Mail
Public Class Registration
    Dim MemberID As String
    Dim NumberOfRows As Integer
    Private PassValidation As Boolean
  
    Private Sub BtnGetStarted_Click(sender As Object, e As EventArgs) Handles BtnGetStarted.Click
        PassValidation = True
        MemberID = "PLIV" + txtMemberID.Text
        ErrorClear()
        Dim Email As Color = Color.Red



        'If any fields are empty then
        'If TxtFirstName.Text = String.Empty _
        '    Or TxtLastName.Text = String.Empty _
        '    Or txtAddress.Text = String.Empty _
        '    Or txtState.Text = String.Empty _
        '    Or txtZipCode.Text = String.Empty _
        '    Or txtEmail.Text = String.Empty _
        '    Or txtPassword.Text = String.Empty _
        '    Or txtCPassword.Text = String.Empty Then
        '    MessageBox.Show("Please fill in all fields before preceeding")
        '    'MessageBox.Show("Please fill in all fields before proceeding")
        If (PassValidation) Then
            picRed()
        End If
        If (PassValidation) Then
            picGreen()
        End If
        If (PassValidation) Then
            Me.Cursor = Cursors.WaitCursor
            '
            Dim Mail As New System.Net.Mail.MailMessage()
            With Mail
                .To.Add(txtEmail.Text)
                .From = New Net.Mail.MailAddress("KADigitalBooks@gmail.com") 'Must be: *@gmail.com
                .Subject = "Welcome to KA Digital Books, " & " " & TxtFirstName.Text & " " & TxtLastName.Text
                .Body = "Your User Name is" & " " & "=" & " " & txtEmail.Text & " " & vbCrLf _
                    & "Your Password is" & " " & "=" & " " & txtPassword.Text & " " & vbCrLf _
                    & "Please Remember this information so you can Check Out Books "
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
            '
            Me.Cursor = Cursors.Arrow
            LibraryMembersTableAdapter.Insert(MemberID, TxtFirstName.Text, TxtLastName.Text, txtAddress.Text, txtCity.Text, cbxState.SelectedItem, txtZipCode.Text, txtEmail.Text, txtPassword.Text)
            MessageBox.Show("Congradulations you have now registered and may login, also a confirmation email has been sent with your account credentials")
            Login.Show()
            Me.Close()
        End If

        'Dim db As New Database2DataSetTableAdapters.LibraryMembersTableAdapter()
        'db.Insert()

        'Dim pv As PublicValidation = New PublicValidation

        'pv.txtPassword_Validating(Me.txtPassword, New System.ComponentModel.CancelEventArgs)




        '    'Elseif any of the user inputs are not the correct datatype then
        '    'MessageBox.Show("Please input the correct information to proceed")
        '    'Elseif all fields are filled and correct then
        '    'Ask user for 5 numbers for memberID
        '    'Take user input, add “PLIV” before it and query search memberID under LibMembers table.
        '    'NumberOfRows =FillbyMemberID to see if there is an existing entry
        '    'If NumberOfRows = 1 Then
        '    'MessageBox.Show("MemberID taken. Please try another 5 numbers")
        '    'ElseIf NumberOfRows = 0 Then
        '    'If Liability Checkbox.checked = false then
        '    'MessageBox.Show("Please read liability form and check the checkbox")
        '    'ElseIf CheckBox.Checked = True Then
        '    'Create new memberID and insert user data into Members Table
        '    'MessageBox.Show("You are now registered and may login")
        '    'End If
        '    'End If
        '    'End If




        'End If

        'Me.ValidateChildren()
    End Sub
    Sub picGreen()
        If picGreenMemberID.Visible = False Or picGreenFirst.Visible = False Or picGreenLast.Visible = False Or picGreenStreetAddress.Visible = False Or picGreenCity.Visible = False Or picGreenState.Visible = False _
            Or picGreenZipCode.Visible = False Or picGreenEmail.Visible = False Or picGreenePass.Visible = False Or picGreenCPass.Visible = False Or picGreenAgree.Visible = False Then
            PassValidation = False
            MessageBox.Show("Please Fill in All Fields")
        End If
    End Sub
    Sub picRed()
        If picRedMemberID.Visible = True Or picRedFirst.Visible = True Or picRedLast.Visible = True Or picRedStreetAddress.Visible = True Or picRedCity.Visible = True Or picRedZipCode.Visible = True Or picRedState.Visible = True _
            Or picRedEmail.Visible = True Or picRedPass.Visible = True Or picRedCPass.Visible = True Or picRedAgree.Visible = True Then
            PassValidation = False
            MessageBox.Show("Please go back to the fields that have a X next to them and correct them")
        End If
    End Sub
    Sub ErrorClear()
        lblAgree.Visible = False
        lblCity.Visible = False
        lblCPass.Visible = False
        lblEmail.Visible = False
        lblFirstName.Visible = False
        lblLastName.Visible = False
        lblMemberID.Visible = False
        lblPass.Visible = False
        lblState.Visible = False
        lblStreetAddress.Visible = False
        lblZipCode.Visible = False
    End Sub


    Private Sub TxtFirstName_LostFocus(sender As Object, e As EventArgs) Handles TxtFirstName.LostFocus
        PassValidation = True
        Dim strName As String
        Dim intCount As Integer
        strName = TxtFirstName.Text
        intCount = TxtFirstName.Text.Count
        If intCount = 0 Then
            lblFirstName.Visible = True
            picRedFirst.Visible = True
            If lblFirstName.Visible = True Then
                TxtFirstName.SelectAll()
                PassValidation = False
            End If
        End If

        For x = 0 To intCount - 1
            If IsNumeric(strName(x)) Then
                lblFirstName.Visible = True
                picRedFirst.Visible = True
                If lblFirstName.Visible = True Then
                    TxtFirstName.SelectAll()
                    PassValidation = False
                    Exit For
                Else
                    picRedFirst.Visible = True
                    lblFirstName.Visible = True
                    TxtFirstName.Clear()
                    PassValidation = False
                End If
            End If
        Next
        If (PassValidation) Then
            picGreenFirst.Visible = True
            picRedFirst.Visible = False
            lblFirstName.Visible = False

        End If
    End Sub

    Private Sub txtMemberID_LostFocus(sender As Object, e As EventArgs) Handles txtMemberID.LostFocus
        PassValidation = True
        Dim NumberOfRowsMember As Integer
        Dim MemberID As Object
        MemberID = "PLIV" + txtMemberID.Text
        NumberOfRowsMember = LibraryMembersTableAdapter.FillByMemberID(DatabaseDataSet.LibraryMembers, MemberID)
        'If yes then need a new member ID
        If NumberOfRowsMember = 1 Then
            picRedMemberID.Visible = True
            lblMemberID.Visible = True
            PassValidation = False
        End If
        If (PassValidation) Then
            If MemberID.length < 5 Then
                picRedMemberID.Visible = True
                PassValidation = False
            End If
        End If
        If (PassValidation) Then
            picRedMemberID.Visible = False
            picGreenMemberID.Visible = True
            lblMemberID.Visible = False
        End If
    End Sub

    Private Sub TxtLastName_LostFocus(sender As Object, e As EventArgs) Handles TxtLastName.LostFocus
        PassValidation = True
        Dim strName As String
        Dim intCount As Integer
        strName = TxtLastName.Text
        intCount = TxtLastName.Text.Count
        If intCount = 0 Then
            lblLastName.Visible = True
            picRedLast.Visible = True
            If lblLastName.Visible = True Then
                TxtLastName.SelectAll()
                PassValidation = False
            End If
        End If
        For x = 0 To intCount - 1
            If IsNumeric(strName(x)) Then
                picRedLast.Visible = False
                lblLastName.Visible = True
                If lblLastName.Visible = True Then
                    TxtLastName.SelectAll()
                    PassValidation = False
                    Exit For
                Else
                    TxtLastName.Clear()
                    picRedLast.Visible = True
                    PassValidation = False
                End If
            End If
        Next
        If (PassValidation) Then
            picGreenLast.Visible = True
            picRedLast.Visible = False
            lblLastName.Visible = False
        End If
    End Sub

    Private Sub txtAddress_LostFocus(sender As Object, e As EventArgs) Handles txtAddress.LostFocus
        PassValidation = True
        If txtAddress.Text = String.Empty Then
            picRedStreetAddress.Visible = True
            lblStreetAddress.Visible = True
            PassValidation = False
        End If
        If (PassValidation) Then
            picGreenStreetAddress.Visible = True
            picRedStreetAddress.Visible = False
            lblStreetAddress.Visible = False
        End If
    End Sub

    Private Sub txtCity_LostFocus(sender As Object, e As EventArgs) Handles txtCity.LostFocus
        PassValidation = True
        If txtCity.Text = String.Empty Then
            picRedCity.Visible = True
            lblCity.Visible = True
            PassValidation = False
        End If
        If (PassValidation) Then
            picGreenCity.Visible = True
            picRedCity.Visible = False
            lblCity.Visible = False
        End If
    End Sub

    Private Sub txtZipCode_LostFocus(sender As Object, e As EventArgs) Handles txtZipCode.LostFocus
        PassValidation = True
        Dim strZip As String
        strZip = txtZipCode.Text
        'Find out if the text entered is numberic or not.
        'If it is numeric, find out if there are 5 digits or not
        If Not IsNumeric(strZip) Then
            picRedZipCode.Visible = True
            lblZipCode.Visible = True
            txtZipCode.SelectAll()
            PassValidation = False
        Else
            If strZip.Count() <> 5 Then
                picRedZipCode.Visible = True
                lblZipCode.Visible = True
                txtZipCode.SelectAll()
                PassValidation = False
            End If
        End If
        If (PassValidation) Then
            picGreenZipCode.Visible = True
            picRedZipCode.Visible = False
            lblZipCode.Visible = False
        End If
    End Sub

    Private Sub txtEmail_LostFocus(sender As Object, e As EventArgs) Handles txtEmail.LostFocus
        PassValidation = True
        Dim strEmail As String
        Dim intIndexOfAT As Integer
        Dim intIndexOfDot As Integer
        'Store the email from the text box to a string variable
        'Find out the position of "@" sign
        'If sign not found - give error message, select the entire text, and stay in the text box
        'If sign found, find out the position of "." starting after "@" sign
        'If "." not found - give error message, select the entire text, and stay in the text box
        strEmail = txtEmail.Text
        intIndexOfAT = strEmail.IndexOf("@")
        If intIndexOfAT <> -1 Then
            intIndexOfDot = strEmail.IndexOf(".", intIndexOfAT)
            If intIndexOfDot = -1 Then
                picRedEmail.Visible = True
                lblEmail.Visible = True
                txtEmail.SelectAll()
                PassValidation = False
            End If
        Else
            picRedEmail.Visible = True
            lblEmail.Visible = True
            txtEmail.SelectAll()
            PassValidation = False
        End If
        If (PassValidation) Then
            picGreenEmail.Visible = True
            picRedEmail.Visible = False
            lblEmail.Visible = False
        End If
    End Sub

    Private Sub txtPassword_LostFocus(sender As Object, e As EventArgs) Handles txtPassword.LostFocus

        PassValidation = True
        Dim strpassword As String
        Dim strlength As Double

        strpassword = txtPassword.Text
        strlength = strpassword.Length


        If strlength < Val(4) Then
            picRedPass.Visible = True
            lblPass.Visible = True
            txtPassword.SelectAll()
            PassValidation = False

        End If
        If (PassValidation) Then
            picGreenePass.Visible = True
            picRedPass.Visible = False
            lblPass.Visible = False
        End If
    End Sub



    Private Sub txtCPassword_LostFocus(sender As Object, e As EventArgs) Handles txtCPassword.LostFocus
        PassValidation = True
        Dim strCpassword As String
        Dim strpassword As String

        strpassword = txtPassword.Text
        strCpassword = txtCPassword.Text

        If strpassword <> strCpassword Or strCpassword = String.Empty Then
            picRedCPass.Visible = True
            lblCPass.Visible = True
            txtCPassword.SelectAll()
            PassValidation = False
        End If
        If (PassValidation) Then
            picGreenCPass.Visible = True
            picRedCPass.Visible = False
            lblCPass.Visible = False
        End If
    End Sub

    Private Sub chkboxAgree_CheckedChanged(sender As Object, e As EventArgs) Handles chkboxAgree.CheckedChanged
        PassValidation = True
        If chkboxAgree.Checked = False Then
            picRedAgree.Visible = True
            lblAgree.Visible = True
            PassValidation = False
            picGreenAgree.Visible = False
        End If
        If (PassValidation) Then
            picGreenAgree.Visible = True
            picRedAgree.Visible = False
            lblAgree.Visible = False
        End If
    End Sub

    Private Sub cbxState_LostFocus(sender As Object, e As EventArgs) Handles cbxState.LostFocus
        PassValidation = True
        If cbxState.SelectedItem = Nothing Then
            lblState.Visible = True
            picRedState.Visible = True
            PassValidation = False
        End If
        If (PassValidation) Then
            lblState.Visible = False
            picGreenState.Visible = True
            picRedState.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Login.txtLoginEmail.Clear()
        Login.txtLogInPassword.Clear()
        Login.rdbEmployee.Checked = False
        Login.Show()

        Me.Close()

    End Sub
End Class