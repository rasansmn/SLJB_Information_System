
Partial Class District_AddDistrict
    Inherits System.Web.UI.Page
    Dim logged_user As New Visitor()

    Protected Sub AddDistrictButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddDistrictButton.Click
        Try
            Dim district As New District(txtDistrctname.Text)
            If district.insert() Then
                Dim log As New User_Log("District", "Created")
                log.insert()
                Response.Redirect("Districts.aspx?action=insert")
            Else
                divError.Visible = True
                lblError.Text = "Record insertion failed"
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 2 Then 'access only for coordinator & admin
            Response.Redirect("~/Default.aspx")
        End If
    End Sub
End Class
