<%@ Page Title="View Employer | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="ViewEmployer.aspx.vb" Inherits="Employer_ViewEmployer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNotification" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCommon" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPerm1" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPerm2" Runat="Server">
    <h2><img alt="" src="../Images/icon2.jpg" height="25" /> <asp:Label ID="lblHeader" runat="server"></asp:Label></h2>
    <br /><table class="viewentity">
        <tr>
            <td>
                Employer ID:</td>
            <td>
                <asp:Label ID="lblEmpid" runat="server" Text="Label"></asp:Label>
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
                Description:</td>
            <td>
                <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
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
                Fax:</td>
            <td>
                <asp:Label ID="lblFax" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                E-Mail:</td>
            <td>
                <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Website:</td>
            <td>
                <asp:Label ID="lblWebsite" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Vacancies:</td>
            <td>
                <asp:HyperLink ID="lnkVacancies" runat="server">HyperLink</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                Coordinator:</td>
            <td>
                <asp:Label ID="lblCoordinator" runat="server" Text="Label"></asp:Label>
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
    <p class="entityactions">
    <asp:HyperLink ID="lnkEdit" runat="server"><img src="../Images/edit.png" alt="" height="12" />Edit</asp:HyperLink>
    <asp:HyperLink ID="lnkDelete" runat="server" onclick = "if (! confirm('Are you sure you want to delete this record?')) { return false; }"><img src="../Images/delete.png" alt="" height="12" />Delete</asp:HyperLink>
</p>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPerm3" Runat="Server">
</asp:Content>

