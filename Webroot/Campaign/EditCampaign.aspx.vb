Imports System.Data.SqlClient
Imports System.Data

Partial Class Campaign_EditCampaign
    Inherits System.Web.UI.Page
    Dim campaign_id As Integer
    Dim update_campaign As Campaign
    Dim logged_user As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 2 Then 'access only for coordinator & admin
            Response.Redirect("~/Default.aspx")
        End If

        If Not IsPostBack Then
            divNotific.Visible = False
            divError.Visible = False
        End If

        If Request.QueryString("id") <> Nothing Then 'load items to list
            campaign_id = Request.QueryString("id")
            update_campaign = New Campaign(campaign_id)
            If Not IsPostBack Then
                Dim ds As New DataSet()
                Dim da As New SqlDataAdapter("SELECT [dsdivision_id], [name] from tblDsdivision", DBConnection.SQLConnection)
                da.Fill(ds, "dsdivisions")
                ddlDivision.DataSource = ds
                ddlDivision.DataValueField = "dsdivision_id"
                ddlDivision.DataTextField = "name"
                ddlDivision.DataBind()
                ddlDivision.SelectedValue = update_campaign.dsdivision_id
                txtLocation.Text = update_campaign.location
            End If
        End If
    End Sub

    Protected Sub UpdateCampaignButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateCampaignButton.Click
        Try
            update_campaign.location = txtLocation.Text
            update_campaign.dsdivision_id = ddlDivision.SelectedValue
            update_campaign.campaign_date = BuildDateOnForm()
            If update_campaign.update() Then
                Dim log As New User_Log("Campaign", "Updated")
                log.insert()
                Response.Redirect("Campaigns.aspx?action=update&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&pagen=" & Request.QueryString("pagen"))
            Else
                divError.Visible = True
                lblError.Text = "Record updating failed"
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    'prepare a date 
    Private Function BuildDateOnForm() As String
        Dim FormDate As String
        FormDate = ddlMonth.Text
        FormDate += "/"
        FormDate += ddlDate.Text
        FormDate += "/"
        FormDate += ddlYear.Text
        Return FormDate
    End Function
End Class
