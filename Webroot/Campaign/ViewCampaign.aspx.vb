Imports System.Data.SqlClient
Imports System.Data

Partial Class Campaign_ViewCampaign
    Inherits System.Web.UI.Page
    Dim campaign As Campaign
    Dim campaign_id As Integer
    Dim logged_user As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then 'fill the list
            divNotific.Visible = False
            divError.Visible = False
            Dim ds As New DataSet()
            Dim da As New SqlDataAdapter("SELECT [emp_id], [name] from tblEmployer", DBConnection.SQLConnection)
            da.Fill(ds, "tblEmployers")
            ddlEmployer.DataSource = ds
            ddlEmployer.DataValueField = "emp_id"
            ddlEmployer.DataTextField = "name"
            ddlEmployer.DataBind()
        End If

        If logged_user.getPerm < 2 Then 'access only for coordinator & admin
            Response.Redirect("~/Default.aspx")
        End If

        'user actions
        If Request.QueryString("action") = "submit" Then
            divNotific.Visible = True
            lblAlert.Text = "Sponsorship added successfully!"
        End If

        If Request.QueryString("id") <> Nothing Then
            campaign_id = Request.QueryString("id")
            campaign = New Campaign(campaign_id)

            If Not IsPostBack Then 'fill the labels
                lblHeader.Text = "Job Campaign: " & campaign.location
                lblCampaignid.Text = campaign.campaign_id
                lblLocation.Text = campaign.location
                lblDate.Text = campaign.campaign_date
                lblDivision.Text = DS_Division.getName(campaign.dsdivision_id)
                If logged_user.getPerm = 3 Then
                    lnkCreatedby.Text = User_Account.getName(campaign.user_id)
                    lnkCreatedby.NavigateUrl = "~/User/ViewUser.aspx?id=" & campaign.user_id
                    lnkCreatedby.Visible = True
                Else
                    lblCreatedby.Text = User_Account.getName(campaign.user_id)
                    lblCreatedby.Visible = True
                End If
                lblCreatedtime.Text = campaign.created_time.ToString()
                lnkDelete.NavigateUrl = "~/Campaign/Campaigns.aspx?action=delete&id=" & campaign.campaign_id
                lnkEdit.NavigateUrl = "~/Campaign/EditCampaign.aspx?id=" & campaign.campaign_id
            End If
        End If
    End Sub

    Protected Sub btnSumbit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSumbit.Click
        Try
            Dim new_sponsorship As New Sponsorship(Val(ddlEmployer.SelectedValue), campaign.campaign_id)
            If new_sponsorship.insert() Then
                If Val(txtAmount.Text) > 0 Then
                    Dim invoice As New Campaign_Invoice(Val(txtAmount.Text), new_sponsorship.sponsorship_id)
                    invoice.insert()
                End If
                Dim log As New User_Log("Sponsorship", "Created")
                log.insert()
                Response.Redirect("ViewCampaign.aspx?action=submit&id=" & campaign_id)
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
