Imports System.Data.SqlClient
Imports System.Data

Partial Class DS_Division_AddDSDivision
    Inherits System.Web.UI.Page
    Dim logged_user As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 2 Then 'access only for coordinator & admin
            Response.Redirect("~/Default.aspx")
        End If

        If Not IsPostBack Then
            divNotific.Visible = False
            divError.Visible = False

            'fill the list
            Dim ds As New DataSet()
            Dim da As New SqlDataAdapter("SELECT [district_id], [name] from tblDistrict", DBConnection.SQLConnection)
            da.Fill(ds, "tblDistricts")
            ddlDistrict.DataSource = ds
            ddlDistrict.DataValueField = "district_id"
            ddlDistrict.DataTextField = "name"
            ddlDistrict.DataBind()
        End If
    End Sub

    Protected Sub AddDSDivisionButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddDSDivisionButton.Click
        Try
            Dim new_dsdivision As New DS_Division(txtDSName.Text, Val(ddlDistrict.SelectedValue))
            If new_dsdivision.insert() Then
                Dim log As New User_Log("DS Division", "Created")
                log.insert()
                Response.Redirect("DSDivisions.aspx?action=insert")
            Else
                divError.Visible = True
                lblError.Text = "Record insertion failed"
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

End Class
