<%@ Page Title="View Job Seeker | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="ViewJobSeeker.aspx.vb" Inherits="Job_Seeker_ViewJobSeeker" %>

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
    <h2><img alt="" src="../Images/icon1.jpg" height="25" /> <asp:Label ID="lblHeader" runat="server"></asp:Label></h2>
    <br />
    <table class="viewentity">
        <tr>
            <td>
                Job Seeker ID:</td>
            <td>
                <asp:Label ID="lblId" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Name:</td>
            <td>
                <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Address:</td>
            <td>
                <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Phone:</td>
            <td>
                <asp:Label ID="lblPhone" runat="server" Text="Label"></asp:Label>
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
                NIC No:</td>
            <td>
                <asp:Label ID="lblNic" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Birthday:</td>
            <td>
                <asp:Label ID="lblBirthday" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Gender:</td>
            <td>
                <asp:Label ID="lblGender" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                License No:</td>
            <td>
                <asp:Label ID="lblLicense" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Languages:</td>
            <td>
                <asp:Label ID="lblLanguages" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Ordinary Level:</td>
            <td>
                <asp:Label ID="lblOl" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Advanced Level:</td>
            <td >
                <asp:Label ID="lblAl" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Higher Education:</td>
            <td class="style2">
                <asp:Label ID="lblHigher" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Work Experience:</td>
            <td>
                <asp:Label ID="lblExperience" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                CV File:</td>
            <td>
                <asp:HyperLink ID="lnkCv" runat="server" Visible="False">Download</asp:HyperLink>
            </td>
        </tr>
        <tr id="trApplications" runat="server">
            <td>
                Applications:</td>
            <td>
                <asp:HyperLink ID="lnkApplications" runat="server">HyperLink</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                Created By:</td>
            <td class="style2">
                <asp:Label ID="lblCreatedby" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:HyperLink ID="lnkCreatedby" runat="server" Visible="False">HyperLink</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td >
                Created Time:</td>
            <td>
                <asp:Label ID="lblCreatedtime" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
     <p><b>Actions</b></p>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPerm2" Runat="Server">
   
<p class="entityactions">
&nbsp;<asp:Label ID="Label2" runat="server" AssociatedControlID="ddlVacancy" 
        Text="Vacancy:"></asp:Label>
    <asp:DropDownList ID="ddlVacancy" runat="server">
    </asp:DropDownList>
    <asp:Button ID="btnApply" runat="server" Text="Apply" />
</p>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPerm3" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cphCommonBottom" Runat="Server">
 <p class="entityactions">
    <asp:HyperLink ID="lnkEdit" runat="server"><img src="../Images/edit.png" alt="" height="12" />Edit</asp:HyperLink>
    <asp:HyperLink ID="lnkDelete" runat="server" onclick = "if (! confirm('Are you sure you want to delete this record?')) { return false; }"><img src="../Images/delete.png" alt="" height="12" />Delete</asp:HyperLink>
</p>
</asp:Content>

