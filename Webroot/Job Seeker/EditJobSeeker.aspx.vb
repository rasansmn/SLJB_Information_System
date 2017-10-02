Imports System.Data.SqlClient
Imports System.Data

Partial Class Job_Seeker_EditJobSeeker
    Inherits System.Web.UI.Page
    Dim jobseeker_id As Integer
    Dim update_job_seeker As Job_Seeker

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            divNotific.Visible = False
            divError.Visible = False
        End If
        If Request.QueryString("id") <> Nothing Then 'flll the text fields
            jobseeker_id = Request.QueryString("id")
            update_job_seeker = New Job_Seeker(jobseeker_id)


            If Not IsPostBack Then
                Dim ds As New DataSet()
                Dim da As New SqlDataAdapter("SELECT [dsdivision_id], [name] from tblDsdivision", DBConnection.SQLConnection)
                da.Fill(ds, "dsdivisions")
                ddlDivision.DataSource = ds
                ddlDivision.DataValueField = "dsdivision_id"
                ddlDivision.DataTextField = "name"
                ddlDivision.DataBind()


                txtName.Text = update_job_seeker.name
                txtAddress.Text = update_job_seeker.address
                txtPhone.Text = update_job_seeker.phone
                ddlStatus.SelectedValue = update_job_seeker.status
                ddlDivision.SelectedValue = update_job_seeker.dsdivision_id
                txtNic.Text = update_job_seeker.nic
                txtLicense.Text = update_job_seeker.license
                txtLanguages.Text = update_job_seeker.languages
                txtOl.Text = update_job_seeker.ordinary_level
                txtAl.Text = update_job_seeker.Advanced_level
                txtHigher.Text = update_job_seeker.higher_edu
                txtExperience.Text = update_job_seeker.work_experience
            End If

        End If
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim cvurl, upurl As String

        If fleCv.HasFile = True And Job_Seeker.Checkfile(fleCv.FileName) = False Then
            valFile.IsValid = False
        Else
            
            Try
                update_job_seeker.name = txtName.Text
                update_job_seeker.address = txtAddress.Text
                update_job_seeker.phone = txtPhone.Text
                update_job_seeker.status = ddlStatus.SelectedValue
                update_job_seeker.dsdivision_id = ddlDivision.SelectedValue
                update_job_seeker.nic = txtNic.Text
                update_job_seeker.birthday = BuildDateOnForm()
                update_job_seeker.gender = ddlGender.SelectedValue
                update_job_seeker.license = txtLicense.Text
                update_job_seeker.languages = txtLanguages.Text
                update_job_seeker.ordinary_level = txtOl.Text
                update_job_seeker.Advanced_level = txtAl.Text
                update_job_seeker.higher_edu = txtHigher.Text
                update_job_seeker.work_experience = txtExperience.Text

                'when uploading an external cv file
                If fleCv.HasFile = True And Job_Seeker.Checkfile(fleCv.FileName) = True Then
                    cvurl = ("~/uploads/" & fleCv.FileName)
                    upurl = Server.MapPath("~/uploads/" & fleCv.FileName)
                    fleCv.SaveAs(upurl)
                    update_job_seeker.cv = cvurl
                End If
                If update_job_seeker.update() Then
                    Dim log As New User_Log("Job Seeker", "Updated")
                    log.insert()
                    Response.Redirect("JobSeekers.aspx?action=update&sin=" & Request.QueryString("sin") & "&stxt=" & Request.QueryString("stxt") & "&dsdivision_id=" & Request.QueryString("dsdivision_id") & "&pagen=" & Request.QueryString("pagen"))
                Else
                    divError.Visible = True
                    lblError.Text = "Record updating failed"
                End If
            Catch ex As Exception
                divError.Visible = True
                lblError.Text = ex.Message
            End Try
        End If

       
    End Sub

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
