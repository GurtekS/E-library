<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MemberSearchScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LibraryResourcesDataGridView = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblMemberName = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.BtnBackPack = New System.Windows.Forms.Button()
        Me.BtnCheckout = New System.Windows.Forms.Button()
        Me.btnSearchByLast = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DatabaseDataSet = New _110A_Project.DatabaseDataSet()
        Me.LibraryResourcesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableAdapterManager = New _110A_Project.DatabaseDataSetTableAdapters.TableAdapterManager()
        Me.LibraryResourcesTableAdapter = New _110A_Project.DatabaseDataSetTableAdapters.LibraryResourcesTableAdapter()
        Me.LibraryMembersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LibraryMembersTableAdapter = New _110A_Project.DatabaseDataSetTableAdapters.LibraryMembersTableAdapter()
        Me.CheckOutBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CheckOutTableAdapter = New _110A_Project.DatabaseDataSetTableAdapters.CheckOutTableAdapter()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSearchByTitle = New System.Windows.Forms.Button()
        Me.btnNewSearch = New System.Windows.Forms.Button()
        CType(Me.LibraryResourcesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LibraryResourcesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LibraryMembersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckOutBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LibraryResourcesDataGridView
        '
        Me.LibraryResourcesDataGridView.BackgroundColor = System.Drawing.Color.White
        Me.LibraryResourcesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.LibraryResourcesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8})
        Me.LibraryResourcesDataGridView.GridColor = System.Drawing.SystemColors.Control
        Me.LibraryResourcesDataGridView.Location = New System.Drawing.Point(15, 167)
        Me.LibraryResourcesDataGridView.Name = "LibraryResourcesDataGridView"
        Me.LibraryResourcesDataGridView.RowHeadersVisible = False
        Me.LibraryResourcesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.LibraryResourcesDataGridView.Size = New System.Drawing.Size(664, 196)
        Me.LibraryResourcesDataGridView.TabIndex = 36
        '
        'Column1
        '
        Me.Column1.HeaderText = "Title"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "First Name"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Last Name"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "ISBN"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "Series"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Genre"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "Book Info"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.HeaderText = "ResourceID"
        Me.Column8.Name = "Column8"
        Me.Column8.Visible = False
        '
        'lblMemberName
        '
        Me.lblMemberName.AutoSize = True
        Me.lblMemberName.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemberName.Location = New System.Drawing.Point(262, 9)
        Me.lblMemberName.Name = "lblMemberName"
        Me.lblMemberName.Size = New System.Drawing.Size(171, 33)
        Me.lblMemberName.TabIndex = 35
        Me.lblMemberName.Text = "Welcome  !"
        '
        'btnExit
        '
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(685, 295)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(108, 56)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'BtnBackPack
        '
        Me.BtnBackPack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBackPack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBackPack.Location = New System.Drawing.Point(685, 169)
        Me.BtnBackPack.Name = "BtnBackPack"
        Me.BtnBackPack.Size = New System.Drawing.Size(108, 35)
        Me.BtnBackPack.TabIndex = 5
        Me.BtnBackPack.Text = "Backpack"
        Me.BtnBackPack.UseVisualStyleBackColor = True
        '
        'BtnCheckout
        '
        Me.BtnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCheckout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCheckout.Location = New System.Drawing.Point(685, 222)
        Me.BtnCheckout.Name = "BtnCheckout"
        Me.BtnCheckout.Size = New System.Drawing.Size(108, 53)
        Me.BtnCheckout.TabIndex = 6
        Me.BtnCheckout.Text = "Checkout"
        Me.BtnCheckout.UseVisualStyleBackColor = True
        '
        'btnSearchByLast
        '
        Me.btnSearchByLast.CausesValidation = False
        Me.btnSearchByLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchByLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchByLast.Location = New System.Drawing.Point(47, 129)
        Me.btnSearchByLast.Name = "btnSearchByLast"
        Me.btnSearchByLast.Size = New System.Drawing.Size(149, 32)
        Me.btnSearchByLast.TabIndex = 2
        Me.btnSearchByLast.Text = "Search By Last Name"
        Me.btnSearchByLast.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(193, 102)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(137, 20)
        Me.txtSearch.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Authors LastName or title"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(762, 9)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(40, 13)
        Me.LinkLabel1.TabIndex = 8
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Logout"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(381, 16)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "To checkout a book, Select book, then click Checkout."
        '
        'DatabaseDataSet
        '
        Me.DatabaseDataSet.DataSetName = "DatabaseDataSet"
        Me.DatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LibraryResourcesBindingSource
        '
        Me.LibraryResourcesBindingSource.DataMember = "LibraryResources"
        Me.LibraryResourcesBindingSource.DataSource = Me.DatabaseDataSet
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CheckOutTableAdapter = Nothing
        Me.TableAdapterManager.EmployeeTableAdapter = Nothing
        Me.TableAdapterManager.LibraryMembersTableAdapter = Nothing
        Me.TableAdapterManager.LibraryResourcesTableAdapter = Me.LibraryResourcesTableAdapter
        Me.TableAdapterManager.UpdateOrder = _110A_Project.DatabaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'LibraryResourcesTableAdapter
        '
        Me.LibraryResourcesTableAdapter.ClearBeforeFill = True
        '
        'LibraryMembersBindingSource
        '
        Me.LibraryMembersBindingSource.DataMember = "LibraryMembers"
        Me.LibraryMembersBindingSource.DataSource = Me.DatabaseDataSet
        '
        'LibraryMembersTableAdapter
        '
        Me.LibraryMembersTableAdapter.ClearBeforeFill = True
        '
        'CheckOutBindingSource
        '
        Me.CheckOutBindingSource.DataMember = "CheckOut"
        Me.CheckOutBindingSource.DataSource = Me.DatabaseDataSet
        '
        'CheckOutTableAdapter
        '
        Me.CheckOutTableAdapter.ClearBeforeFill = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(244, 16)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "If its not shown, try another search."
        '
        'btnSearchByTitle
        '
        Me.btnSearchByTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchByTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchByTitle.Location = New System.Drawing.Point(202, 129)
        Me.btnSearchByTitle.Name = "btnSearchByTitle"
        Me.btnSearchByTitle.Size = New System.Drawing.Size(149, 32)
        Me.btnSearchByTitle.TabIndex = 3
        Me.btnSearchByTitle.Text = "Search By Title"
        Me.btnSearchByTitle.UseVisualStyleBackColor = True
        '
        'btnNewSearch
        '
        Me.btnNewSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewSearch.Location = New System.Drawing.Point(357, 129)
        Me.btnNewSearch.Name = "btnNewSearch"
        Me.btnNewSearch.Size = New System.Drawing.Size(149, 32)
        Me.btnNewSearch.TabIndex = 4
        Me.btnNewSearch.Text = "New Search"
        Me.btnNewSearch.UseVisualStyleBackColor = True
        '
        'MemberSearchScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 394)
        Me.Controls.Add(Me.btnNewSearch)
        Me.Controls.Add(Me.btnSearchByTitle)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.LibraryResourcesDataGridView)
        Me.Controls.Add(Me.lblMemberName)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.BtnBackPack)
        Me.Controls.Add(Me.BtnCheckout)
        Me.Controls.Add(Me.btnSearchByLast)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MemberSearchScreen"
        Me.Text = "HomeScreen"
        CType(Me.LibraryResourcesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LibraryResourcesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LibraryMembersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckOutBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LibraryResourcesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents lblMemberName As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents BtnBackPack As System.Windows.Forms.Button
    Friend WithEvents BtnCheckout As System.Windows.Forms.Button
    Friend WithEvents btnSearchByLast As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DatabaseDataSet As _110A_Project.DatabaseDataSet
    Friend WithEvents LibraryResourcesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TableAdapterManager As _110A_Project.DatabaseDataSetTableAdapters.TableAdapterManager
    Friend WithEvents LibraryResourcesTableAdapter As _110A_Project.DatabaseDataSetTableAdapters.LibraryResourcesTableAdapter
    Friend WithEvents LibraryMembersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LibraryMembersTableAdapter As _110A_Project.DatabaseDataSetTableAdapters.LibraryMembersTableAdapter
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckOutBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CheckOutTableAdapter As _110A_Project.DatabaseDataSetTableAdapters.CheckOutTableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSearchByTitle As System.Windows.Forms.Button
    Friend WithEvents btnNewSearch As System.Windows.Forms.Button
End Class
