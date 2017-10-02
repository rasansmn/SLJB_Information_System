
Partial Class District_EditDistrict
    Inherits System.Web.UI.Page
    Dim district_id As Integer
    Dim update_district As District
    Dim logged_user As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 2 Then 'access only for coordinator & admin
            Response.Redirect("~/Default.aspx")
        End If

        If Request.QueryString("id") <> Nothing Then
            district_id = Request.QueryString("id")
            update_district = New District(district_id)
            If Not IsPostBack Then 'fill the text field
                txtDistrctname.Text = update_district.name
            End If
        End If
    End Sub

    Protected Sub UpdateDistrictButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateDistrictButton.Click
        Try
            update_district.name = txtDistrctname.Text
            If update_district.update() Then
                Dim log As New User_Log("District", "Updated")
                log.insert()
                Response.Redirect("Districts.aspx?action=update&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&pagen=" & Request.QueryString("pagen"))
            Else
                divError.Visible = True
                lblError.Text = "Record updating failed"
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub
End Class
