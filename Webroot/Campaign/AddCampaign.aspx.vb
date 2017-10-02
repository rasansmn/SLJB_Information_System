Imports System.Data.SqlClient
Imports System.Data

Partial Class Campaign_AddCampaign
    Inherits System.Web.UI.Page
    Dim logged_user As New Visitor()

    Protected Sub AddCampaignButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddCampaignButton.Click
        Try
            Dim campaign As New Campaign(txtLocation.Text, BuidDateOnForm(), Val(ddlDivision.SelectedValue))
            If campaign.insert() Then
                Dim log As New User_Log("Campaign", "Created")
                log.insert()
                Response.Redirect("Campaigns.aspx?action=insert")
            Else
                divError.Visible = True
                lblError.Text = "Record insertion failed"
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    'prepare a date
    Private Function BuidDateOnForm() As String
        Dim FormDate As String
        FormDate = ddlMonth.Text
        FormDate += "/"
        FormDate += ddlDate.Text
        FormDate += "/"
        FormDate += ddlYear.Text
        Return FormDate
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 2 Then 'access only for coordinator & admin
            Response.Redirect("~/Default.aspx")
        End If

        If Not IsPostBack Then
            divNotific.Visible = False
            divError.Visible = False

            'loading items to list
            Dim ds As New DataSet()
            Dim da As New SqlDataAdapter("SELECT [dsdivision_id], [name] from tblDsdivision", DBConnection.SQLConnection)
            da.Fill(ds, "dsdivisions")
            ddlDivision.DataSource = ds
            ddlDivision.DataValueField = "dsdivision_id"
            ddlDivision.DataTextField = "name"
            ddlDivision.DataBind()
        End If
    End Sub
End Class
