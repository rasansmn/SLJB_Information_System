<%@ Page Title="View Vacancy | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="ViewVacancy.aspx.vb" Inherits="Vacancy_ViewVacancy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNotification" Runat="Server">
    <div id="divError" class="error" runat="server" visible="false">
    <asp:Image ID="imgNotok" runat="server" ImageUrl="~/Images/notok.gif" />
<asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
</div>
<div id="divNotific" class="alert" runat="server" visible="false">
    <asp:Image ID="imgOk" runat="server" ImageUrl="~/Images/ok.gif" />
<asp:Label ID="lblAlert" runat="server" Text="Label"></asp:Label>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCommon" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPerm1" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPerm2" Runat="Server">
    <h2><img alt="" src="../Images/icon6.png" height="25" /> <asp:Label ID="lblHeader" runat="server"></asp:Label></h2>
    <br /><table class="viewentity">
        <tr>
            <td>
                Vacancy ID:</td>
            <td>
                <asp:Label ID="lblVacancy_id" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Title:</td>
            <td>
                <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Employer:</td>
            <td>
                <asp:HyperLink ID="lnkEmployer" runat="server">HyperLink</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                Description</td>
            <td>
                <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Qualifications:</td>
            <td>
                <asp:Label ID="lblQualifications" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Status:</td>
            <td>
                <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Number of positions:</td>
            <td>
                <asp:Label ID="lblPositions" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Interview Dates:</td>
            <td>
                <asp:Label ID="lblInterview" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Salary Range:</td>
            <td>
                <asp:Label ID="lblSalary" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Applications:</td>
            <td>
                <asp:HyperLink ID="lnkApplications" runat="server">HyperLink</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                Created By:</td>
            <td>
                <asp:Label ID="lblCreatedby" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:HyperLink ID="lnkCreatedby" runat="server" Visible="False">HyperLink</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                Created Time:</td>
            <td>
                <asp:Label ID="lblCreatedtime" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    <p><b>Actions</b></p>
   
      <%--  &nbsp;<asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="valJobseeker" CssClass="failureNotification" runat="server" />--%>
        <p class="entityactions">
        <asp:Label ID="Label1" runat="server" Text="Job Seeker ID:  "></asp:Label>
        <asp:TextBox ID="txtJobseekerid" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valreqjobseekerid" runat="server"  
                ValidationGroup="valJobseeker" CssClass="failureNotification" 
                ErrorMessage="Job Seeker ID is required." 
                ControlToValidate="txtJobseekerid" ToolTip="Job Seeker ID is required.">*</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="valjobseekernotexist" runat="server"  
                ValidationGroup="valJobseeker" CssClass="failureNotification" 
                ErrorMessage="Job Seeker ID is not exist" 
                ControlToValidate="txtJobseekerid" ToolTip="Job Seeker ID is not exist">*</asp:CustomValidator>
        <asp:Button ID="btnApply" runat="server"  ValidationGroup="valJobseeker" Text="Apply" />
    </p>

   
        <%--&nbsp;<asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="valAmount" CssClass="failureNotification" runat="server" />--%>
        <p class="entityactions">
        <asp:Label ID="Label2" runat="server" Text="Invoice Amount:  "></asp:Label>
        <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valreqinvoiceamount" runat="server" 
                CssClass="failureNotification" ValidationGroup="valAmount" 
                ErrorMessage="Invoice Amount is required." ControlToValidate="txtAmount" 
                ToolTip="Invoice Amount is required.">*</asp:RequiredFieldValidator>
        <asp:CustomValidator ID="valinvalidamount" CssClass="failureNotification"  
                ValidationGroup="valAmount" runat="server" ErrorMessage="Invalid Amount." 
                ControlToValidate="txtAmount" ToolTip="Invalid Amount.">*</asp:CustomValidator>
        <asp:Button ID="btnCreateInvoice" runat="server"  ValidationGroup="valAmount" Text="Create Invoice" />
    </p>
    <p class="entityactions">
    <asp:HyperLink ID="lnkEdit" runat="server"><img src="../Images/edit.png" alt="" height="12" />Edit</asp:HyperLink> 
    <asp:HyperLink ID="lnkDelete" runat="server" onclick = "if (! confirm('Are you sure you want to delete this record?')) { return false; }"><img src="../Images/delete.png" alt="" height="12" />Delete</asp:HyperLink> 
    <asp:HyperLink ID="lnkOpen" runat="server" Visible="False"><img src="../Images/Open.gif" alt="" height="12" />Open</asp:HyperLink>  
    <asp:HyperLink ID="lnkClose" runat="server" Visible="False"><img src="../Images/close.png" alt="" height="12" />Close</asp:HyperLink> 
</p>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPerm3" Runat="Server">
</asp:Content>

