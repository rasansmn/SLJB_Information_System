﻿'(c) Rasan Samarasinghe 2013-11-25

Imports System.Data.SqlClient

Partial Class Employer_Employers
    Inherits System.Web.UI.Page
    Dim query, querycount As String
    Dim numitems, limitstart, pagen, numpages As Integer
    Dim itemsperpage As Integer = 12
    Dim logged_user As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 2 Then 'access only for coordinator & admin
            Response.Redirect("~/Default.aspx")
        End If

        If IsPostBack Then
            divNotific.Visible = False
            divError.Visible = False
        End If

        'user actions
        If Request.QueryString("action") = "delete" Then
            Try
                If Employer.delete(CInt(Request.QueryString("id"))) Then
                    Dim log As New User_Log("Employer", "Deleted")
                    log.insert()
                    divNotific.Visible = True
                    lblAlert.Text = "Employer deleted successfully!"
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
            lblAlert.Text = "Employer inserted successfully!"
        ElseIf Request.QueryString("action") = "update" Then
            divNotific.Visible = True
            lblAlert.Text = "Employer updated successfully!"
        End If

        pagen = Val(Request.QueryString("pagen")) 'page number?
        If pagen < 1 Then
            pagen = 1
        End If

        'prepare the query to show on each page
        If Request.QueryString("sin") <> "" And Request.QueryString("stxt") <> "" Then
            querycount = "SELECT * FROM tblEmployer WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%'"
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblEmployer WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%' AND emp_id NOT IN (SELECT TOP " & limitstart & " emp_id FROM tblEmployer WHERE " & Request.QueryString("sin") & " LIKE '%" & Request.QueryString("stxt") & "%' ORDER BY emp_id DESC) ORDER BY emp_id DESC"
            lblTitle.Text = "- Search (" & Request.QueryString("stxt") & ")"
            lblTableCapation.Text = "Showing search results for " & Request.QueryString("stxt")
        Else
            querycount = "SELECT * FROM tblEmployer"
            numpages = Core.getnumpages(querycount, itemsperpage)
            If pagen > numpages And numpages <> 0 Then
                pagen = numpages
            End If
            limitstart = (pagen - 1) * itemsperpage
            query = "SELECT TOP " & itemsperpage & " * FROM tblEmployer WHERE emp_id NOT IN (SELECT TOP " & limitstart & " emp_id FROM tblEmployer ORDER BY emp_id DESC) ORDER BY emp_id DESC"
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
    End Sub

    Sub showitems(ByVal query As String) 'loading items to repeater
        Try
            Dim adapter As New SqlDataAdapter(query, DBConnection.SQLConnection)
            Dim dsItem As New Data.DataSet
            adapter.Fill(dsItem, "tblDistricts")
            rptEmployers.DataSource = dsItem
            rptEmployers.DataBind()
            If rptEmployers.Items.Count = 0 Then
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
        Response.Redirect("Employers.aspx?sin=" & ddlLookin.SelectedValue & "&stxt=" & txtSearch.Text)
    End Sub

    Protected Sub btnPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Response.Redirect("Employers.aspx?pagen=" & pagen - 1 & "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt"))
    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Response.Redirect("Employers.aspx?pagen=" & pagen + 1 & "&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt"))
    End Sub

    Protected Sub btnAddEmployer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddEmployer.Click
        Response.Redirect("~/Employer/AddEmployer.aspx")
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Session("ReportQuery") = Nothing
        Session("ReportQuery") = querycount
        Response.Redirect("~/Report/ViewReport.aspx?action=employers")
    End Sub
End Class
