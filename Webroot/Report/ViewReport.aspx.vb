Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Data.SqlClient

Partial Class Report_ViewReport
    Inherits System.Web.UI.Page
    Dim logged_user As New Visitor()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If logged_user.getPerm < 3 Then 'access only for admin
            Response.Redirect("~/Default.aspx")
        End If

        Dim rptDoc As New ReportDocument()
        'what report want to see?
        If Request.QueryString("action") = "logs" Then
            Dim ds As New dsLog()
            Dim adapter As New SqlDataAdapter(Session("ReportQuery").ToString(), DBConnection.SQLConnection)
            adapter.Fill(ds, "tblLog")
            rptDoc.Load(Server.MapPath("~/Report/rptLog.rpt"))
            rptDoc.SetDataSource(ds)
        ElseIf Request.QueryString("action") = "jobseekers" Then
            Dim ds As New dsJobseeker()
            Dim adapter As New SqlDataAdapter(Session("ReportQuery").ToString(), DBConnection.SQLConnection)
            adapter.Fill(ds, "tblJobseeker")
            rptDoc.Load(Server.MapPath("~/Report/rptJobseeker.rpt"))
            rptDoc.SetDataSource(ds)
        ElseIf Request.QueryString("action") = "applications" Then
            Dim ds As New dsApplication()
            Dim adapter As New SqlDataAdapter(Session("ReportQuery").ToString(), DBConnection.SQLConnection)
            adapter.Fill(ds, "tblApplication")
            rptDoc.Load(Server.MapPath("~/Report/rptApplication.rpt"))
            rptDoc.SetDataSource(ds)
        ElseIf Request.QueryString("action") = "employers" Then
            Dim ds As New dsEmployer()
            Dim adapter As New SqlDataAdapter(Session("ReportQuery").ToString(), DBConnection.SQLConnection)
            adapter.Fill(ds, "tblEmployer")
            rptDoc.Load(Server.MapPath("~/Report/rptEmployer.rpt"))
            rptDoc.SetDataSource(ds)
        ElseIf Request.QueryString("action") = "vacancies" Then
            Dim ds As New dsVacancy()
            Dim adapter As New SqlDataAdapter(Session("ReportQuery").ToString(), DBConnection.SQLConnection)
            adapter.Fill(ds, "tblVacancy")
            rptDoc.Load(Server.MapPath("~/Report/rptVacancy.rpt"))
            rptDoc.SetDataSource(ds)
        ElseIf Request.QueryString("action") = "campaigns" Then
            Dim ds As New dsCampaign()
            Dim adapter As New SqlDataAdapter(Session("ReportQuery").ToString(), DBConnection.SQLConnection)
            adapter.Fill(ds, "tblCampaign")
            rptDoc.Load(Server.MapPath("~/Report/rptCampaign.rpt"))
            rptDoc.SetDataSource(ds)
        ElseIf Request.QueryString("action") = "vacancyinvoices" Then
            Dim ds As New dsVacancyinvoice()
            Dim adapter As New SqlDataAdapter(Session("ReportQuery").ToString(), DBConnection.SQLConnection)
            adapter.Fill(ds, "tblVacancyinvoice")
            rptDoc.Load(Server.MapPath("~/Report/rptVacancyinvoice.rpt"))
            rptDoc.SetDataSource(ds)
        ElseIf Request.QueryString("action") = "campaigninvoices" Then
            Dim ds As New dsCampaigninvoice()
            Dim adapter As New SqlDataAdapter(Session("ReportQuery").ToString(), DBConnection.SQLConnection)
            adapter.Fill(ds, "tblCampaigninvoice")
            rptDoc.Load(Server.MapPath("~/Report/rptCampaigninvoice.rpt"))
            rptDoc.SetDataSource(ds)
        End If
        CrystalReportViewer1.ReportSource = rptDoc
    End Sub

End Class
