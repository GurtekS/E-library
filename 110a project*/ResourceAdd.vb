Public Class ResourceAdd
    Dim ResourceID As String
    Dim PassValidation As Boolean

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        PassValidation = True
        'check for Resource Id Length
        If (PassValidation) Then
            ResourceIDLength_Validation()
        End If
        'Check to see if the Resource ID is numeric values and to see if it already exists in the datatable
        If (PassValidation) Then
            ResourceID_Validation()
        End If
        'check to see if all of the textboxes are not empty
        If (PassValidation) Then
            txtTitle_Validation()
        End If
        If (PassValidation) Then
            txtLastName_Validation()
        End If
        If (PassValidation) Then
            txtMiddleName_Validation()
        End If
        If (PassValidation) Then
            txtPublication_Validation()
        End If
        If (PassValidation) Then
            txtSeries_Validation()
        End If
        If (PassValidation) Then
            txtISBN_Validation()
        End If
        'check to see if all comboboxes have a selected item
        If (PassValidation) Then
            CheckOut_Validation()
        End If
        If (PassValidation) Then
            Genre_Validation()
        End If
        If (PassValidation) Then
            AgeGroup_Validation()
        End If
        'check to see if they input a book description
        If (PassValidation) Then
            txtBookInfo_Validation()
        End If
        'insert all of the data from the form into the datatable after is passes all of the validations
        If PassValidation = True Then
            LibraryResourcesTableAdapter.Insert(ResourceID, txtTitle.Text, Nothing, txtLastName.Text, txtFirstName.Text, txtMiddleName.Text, txtPublicationYear.Text, txtSeries.Text, txtISBN.Text, CInt(cbxCheckoutPeriod.SelectedItem), cbxGenre.SelectedItem, cbxAgeGroup.SelectedItem, txtBookInfo.Text)
            MessageBox.Show("The New Book has been Entered")
        End If

    End Sub
    Sub ResourceID_Validation()
        Dim NumberOfRows As Double
        If Not IsNumeric(txtResourceID.Text) Then
            MessageBox.Show("The ResourceId Must be Only Numeric Characters")
            txtResourceID.SelectAll()
            PassValidation = False
        ElseIf cbxCopyNumber.SelectedItem = Nothing Then
            MessageBox.Show("Please Select a Book Copy Number")
            PassValidation = False
        End If

        If IsNumeric(txtResourceID.Text) Then
            ResourceID = "b" + CStr(txtResourceID.Text) + "_" + cbxCopyNumber.SelectedItem
            NumberOfRows = LibraryResourcesTableAdapter.FillByAddResource(DatabaseDataSet.LibraryResources, ResourceID)
            If NumberOfRows > 0 Then
                MessageBox.Show("a copy of that book already exists, please incriment your Book Copy Number by 1")
                PassValidation = False
            End If

        End If
    End Sub
    Sub AgeGroup_Validation()
        If cbxAgeGroup.SelectedItem = Nothing Then
            PassValidation = False
            MessageBox.Show("Please Select a Age Group")
        End If
    End Sub
    Sub Genre_Validation()
        If cbxGenre.SelectedItem = Nothing Then
            PassValidation = False
            MessageBox.Show("Please Select A Genre")
        End If
    End Sub
    Sub CheckOut_Validation()
        If cbxCheckoutPeriod.SelectedItem = Nothing Then
            PassValidation = False
            MessageBox.Show("Please select a checkout period")
        End If
    End Sub
    Sub txtTitle_Validation()
        If txtTitle.Text = String.Empty Then
            MessageBox.Show("Please Fill in All Fields")
            PassValidation = False
        End If
    End Sub
    Sub ResourceIDLength_Validation()


        Dim strResourceID As String
        Dim intlength As Integer

        strResourceID = txtResourceID.Text
        intlength = strResourceID.Length


        If intlength < Val(6) Then
            MessageBox.Show("ResourceID must be 7 digits long")
            txtResourceID.SelectAll()
            PassValidation = False

        End If
    End Sub
    Sub txtLastName_Validation()
        If txtLastName.Text = String.Empty Then
            MessageBox.Show("Please Fill in All Fields")
            PassValidation = False
        End If
    End Sub
    Sub txtFirstName_Validation()
        If txtFirstName.Text = String.Empty Then
            MessageBox.Show("Please Fill in All Fields")
            PassValidation = False
        End If
    End Sub
    Sub txtMiddleName_Validation()
        If txtMiddleName.Text = String.Empty Then
            MessageBox.Show("Please Fill in All Fields")
            PassValidation = False
        End If
    End Sub
    Sub txtPublication_Validation()
        If txtPublicationYear.Text = String.Empty Then
            MessageBox.Show("Please Fill in All Fields")
            PassValidation = False
        End If
    End Sub
    Sub txtSeries_Validation()
        If txtSeries.Text = String.Empty Then
            MessageBox.Show("Please Fill in All Fields")
            PassValidation = False
        End If
    End Sub
    Sub txtISBN_Validation()
        If txtISBN.Text = String.Empty Then
            MessageBox.Show("Please Fill in All Fields")
            PassValidation = False
        End If
    End Sub
    Sub txtBookInfo_Validation()
        If txtBookInfo.Text = String.Empty Then
            MessageBox.Show("Please Fill in All Fields")
            PassValidation = False
        End If
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        EmployeeSearchScreen.txtSearch.Clear()
        EmployeeSearchScreen.dgvEmployee.Rows.Clear()
        EmployeeSearchScreen.Show()
        Me.Close()
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        txtTitle.Clear()
        txtFirstName.Clear()
        txtLastName.Clear()
        txtISBN.Clear()
        txtBookInfo.Clear()
        txtMiddleName.Clear()
        txtResourceID.Clear()
        txtPublicationYear.Clear()
        txtSeries.Clear()
        cbxAgeGroup.SelectedItem = Nothing
        cbxGenre.SelectedItem = Nothing
        cbxCopyNumber.SelectedItem = Nothing
        cbxCheckoutPeriod.SelectedItem = Nothing
        txtResourceID.Focus()

    End Sub

    Private Sub cbxGenre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxGenre.SelectedIndexChanged

    End Sub
End Class