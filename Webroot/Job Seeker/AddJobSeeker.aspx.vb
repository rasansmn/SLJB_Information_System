Imports System.Data.SqlClient
Imports System.Data
Imports System.Globalization

Partial Class Job_Seeker_AddJobSeeker
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim cvurl, upurl As String
        Try
            'when uploading an external cv document
            If fleCv.HasFile = True And Job_Seeker.Checkfile(fleCv.FileName) = True Then
                cvurl = ("~/uploads/" & fleCv.FileName)
            Else
                cvurl = Nothing
            End If
            Dim new_job_seeker As New Job_Seeker(txtName.Text, txtAddress.Text, txtPhone.Text, ddlStatus.SelectedValue, txtNic.Text, BuildDateOnForm(), ddlGender.Text, txtLicense.Text, txtLanguages.Text, txtOl.Text, txtAl.Text, txtHigher.Text, txtExperience.Text, cvurl, Val(ddlDivision.SelectedValue))
            If fleCv.HasFile = True And Job_Seeker.Checkfile(fleCv.FileName) = False Then
                valFile.IsValid = False
            Else
                If new_job_seeker.insert() Then
                    If fleCv.HasFile = True Then
                        upurl = Server.MapPath("~/uploads/" & fleCv.FileName)
                        fleCv.SaveAs(upurl)
                    End If
                    Dim log As New User_Log("Job Seeker", "Created")
                    log.insert()
                    Response.Redirect("AddJobSeeker.aspx?action=insert")
                Else
                    divError.Visible = True
                    lblError.Text = "Record insertion failed"
                End If
            End If
        Catch ex As Exception
            divError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            divNotific.Visible = False
            divError.Visible = False

            Dim ds As New DataSet() 'fill the list
            Dim da As New SqlDataAdapter("SELECT [dsdivision_id], [name] from tblDsdivision", DBConnection.SQLConnection)
            da.Fill(ds, "dsdivisions")
            ddlDivision.DataSource = ds
            ddlDivision.DataValueField = "dsdivision_id"
            ddlDivision.DataTextField = "name"
            ddlDivision.DataBind()
        End If

        'user actions
        If Request.QueryString("action") = "insert" Then
            divNotific.Visible = True
            lblAlert.Text = "Record inserted successfully!"
        End If
    End Sub

    'prepare a date on form
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
