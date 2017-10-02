
Partial Class User_AddUser
    Inherits System.Web.UI.Page
    Dim logged_user As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 3 Then 'access only for admin
            Response.Redirect("~/Default.aspx")
        End If

        If IsPostBack Then
            divNotific.Visible = False
            divError.Visible = False
        End If
    End Sub

    Protected Sub CreateUserButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreateUserButton.Click
        Try
            Dim User_Account As New User_Account(txtUsername.Text, txtName.Text, txtConfirmPassword.Text, CInt(ddlPermission.SelectedValue))
            'validating the user input
            If User_Account.getExist(txtUsername.Text) Then
                valUsername.IsValid = False
                valUsername.ErrorMessage = "Username already exist"
                valUsername.ToolTip = "Username already exist"
            ElseIf txtUsername.Text.Length < 4 Then
                valUsername.IsValid = False
                valUsername.ErrorMessage = "Username should be at least 4 charactors"
                valUsername.ToolTip = "Username should be at least 4 charactors"
            ElseIf txtPassword.Text.Length < 4 Then
                valPassword.IsValid = False
                valPassword.ErrorMessage = "Password should be at least 4 charactors"
                valPassword.ToolTip = "Password should be at least 4 charactors"
            Else
                If User_Account.insert() Then
                    Dim log As New User_Log("User", "Created")
                    log.insert()
                    Response.Redirect("Users.aspx?action=insert")
                Else
                    divError.Visible = True
                    lblError.Text = "Record insertion failed"
                End If
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

End Class
