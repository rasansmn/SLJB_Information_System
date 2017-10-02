Imports System.Data.SqlClient

Partial Class District_Districts
    Inherits System.Web.UI.Page
    Dim query, querycount As String
    Dim numitems, limitstart, pagen, numpages As Integer
    Dim itemsperpage As Integer = 12
    Public logged_user As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            divNotific.Visible = False
            divError.Visible = False
        End If

        'user actions
        If Request.QueryString("action") = "delete" Then
            Try
                If District.delete(CInt(Request.QueryString("id"))) Then
                    Dim log As New User_Log("District", "Deleted")
                    log.insert()
                    divNotific.Visible = True
                    lblAlert.Text = "District deleted successfully!"
                Else
                    divError.Visible = True
                    lblError.Text = "Error on deleting"
                End If
            Catch ex As Exception
                divError.Visible = True
                lblError.Text = ex.Message
            End Try
        ElseIf Request.QueryString("action") = "insert" Then
            divNotific.Visible = True
            lblAlert.Text = "District inserted successfully!"
        ElseIf Request.QueryString("action") = "update" Then
            divNotific.Visible = True
            lblAlert.Text = "District updated successfully!"
        End If

        pagen = Val(Request.QueryString("pagen")) 'page number?
        If pagen < 1 Then
            pagen = 1
        End If

        'prepare the query for each page
        If Request.QueryString("sin") <> "" And Request.QueryString("stxt") <> "" Then
            querycount = "SELECT * FROM tblDistrict WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%'"
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblDistrict WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%' AND district_id NOT IN (SELECT TOP " & limitstart & " district_id FROM tblDistrict WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%' ORDER BY district_id DESC) ORDER BY district_id DESC"
            lblTitle.Text = "- Search (" & Request.QueryString("stxt") & ")"
            lblTableCapation.Text = "Showing search results for " & Request.QueryString("stxt")
        Else
            querycount = "SELECT * FROM tblDistrict"
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblDistrict WHERE district_id NOT IN (SELECT TOP " & limitstart & " district_id FROM tblDistrict ORDER BY district_id DESC) ORDER BY district_id DESC"
        End If

        'navigation buttons
        lblPages.Text = "Page " & pagen & " of " & numpages
        If pagen < numpages Then
            btnNext.Enabled = True
        End If
        If pagen > 1 Then
            btnPrev.Enabled = True
        End If

        showitems(query)

        If logged_user.getPerm() < 2 Then 'disable function for data entry operator
            btnAddDistrict.Visible = False
        End If
    End Sub

    Sub showitems(ByVal query As String) 'loading items to the repeater
        Try
            Dim adapter As New SqlDataAdapter(query, DBConnection.SQLConnection)
            Dim dsItem As New Data.DataSet
            adapter.Fill(dsItem, "tblDistricts")
            rptDistricts.DataSource = dsItem
            rptDistricts.DataBind()
            If rptDistricts.Items.Count = 0 Then
                lblTableCapation.Text = "No records found on this criteria."
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Function urlExtend() As String 'avoid miss the reffered page
        Return "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&pagen=" & pagen
    End Function

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Response.Redirect("Districts.aspx?sin=" & ddlLookin.SelectedValue & "&stxt=" & txtSearch.Text)
    End Sub

    Protected Sub btnPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Response.Redirect("Districts.aspx?pagen=" & pagen - 1 & "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt"))
    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Response.Redirect("Districts.aspx?pagen=" & pagen + 1 & "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt"))
    End Sub

    Protected Sub btnAddDistrict_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDistrict.Click
        Response.Redirect("~/District/AddDistrict.aspx")
    End Sub
End Class
