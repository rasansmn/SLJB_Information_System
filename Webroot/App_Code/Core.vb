'(c) Rasan Samarasinghe 2013-11-25

Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Core
    Private Shared send_email As Boolean = False 'turn on email messages

    'return the number of pages in a list page
    Public Shared Function getnumpages(ByVal query As String, ByVal itemsperpage As Integer) As Integer
        Try
            Dim adapt As New SqlDataAdapter(query, DBConnection.SQLConnection)
            Dim ds As New Data.DataSet
            adapt.Fill(ds, "tblCount")
            Return Math.Ceiling(ds.Tables("tblCount").Rows.Count / itemsperpage)
        Catch ex As Exception
        End Try
        Return 1
    End Function

    'sending email to the employer
    Public Shared Sub sendmail(ByVal toaddr As String, ByVal msg As String)
        Try
            Dim sb As New StringBuilder
            Dim mailmsg As New System.Net.Mail.MailMessage
            Dim mailaddr As New System.Net.Mail.MailAddress("fedoramedi@wegaspace.com")
            Dim mailer As New System.Net.Mail.SmtpClient()
            Dim creds As New System.Net.NetworkCredential("fedoramedi@wegaspace.com", "1234")
            sb.AppendLine(msg)
            sb.AppendLine("<br>Thank you.") 'add additional text
            mailmsg.IsBodyHtml = True
            mailmsg.Subject = "Appointment Request on FedoraMedi"
            mailmsg.Body = sb.ToString()
            mailmsg.From = mailaddr
            mailer.Host = "mail.wegaspace.com"
            mailer.UseDefaultCredentials = False
            mailer.Credentials = creds
            If send_email = True Then
                mailmsg.To.Add(toaddr)
                mailer.Send(mailmsg)
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class
