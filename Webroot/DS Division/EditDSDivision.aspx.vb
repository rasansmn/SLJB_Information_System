Imports System.Data.SqlClient
Imports System.Data

Partial Class DS_Division_EditDSDivision
    Inherits System.Web.UI.Page
    Dim dsdivision_id As Integer
    Dim update_dsdivision As DS_Division
    Dim logged_user As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 2 Then 'access only for coordinator & admin
            Response.Redirect("~/Default.aspx")
        End If

        If Not IsPostBack Then
            divNotific.Visible = False
            divError.Visible = False

            Dim ds As New DataSet() 'fill the list
            Dim da As New SqlDataAdapter("SELECT [district_id], [name] from tblDistrict", DBConnection.SQLConnection)
            da.Fill(ds, "tblDistricts")
            ddlDistrict.DataSource = ds
            ddlDistrict.DataValueField = "district_id"
            ddlDistrict.DataTextField = "name"
            ddlDistrict.DataBind()
        End If

        If Request.QueryString("id") <> Nothing Then 'fill the fields
            dsdivision_id = Request.QueryString("id")
            update_dsdivision = New DS_Division(dsdivision_id)
            If Not IsPostBack Then
                txtDSName.Text = update_dsdivision.name
                ddlDistrict.SelectedValue = update_dsdivision.district_id
            End If
        End If
    End Sub

    Protected Sub EditDSDivisionButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditDSDivisionButton.Click
        Try
            update_dsdivision.name = txtDSName.Text
            update_dsdivision.district_id = ddlDistrict.SelectedValue
            If update_dsdivision.update() Then
                Dim log As New User_Log("DS Division", "Deleted")
                log.insert()
                Response.Redirect("DSDivisions.aspx?action=update&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&district_id=" & Request.QueryString("district_id") & "&pagen=" & Request.QueryString("pagen"))
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
