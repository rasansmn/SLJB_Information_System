<%@ Page Title="View User | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="ViewUser.aspx.vb" Inherits="User_ViewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNotification" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCommon" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPerm1" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPerm2" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPerm3" Runat="Server">
    <h2><img alt="" src="../Images/icon4.jpg" height="25" /> <asp:Label ID="lblHeader" runat="server"></asp:Label></h2>
    <br /><table class="viewentity">
        <tr>
            <td>
                User ID:</td>
            <td>
                <asp:Label ID="lblUser_id" runat="server" Text="Label"></asp:Label>
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
                Username:</td>
            <td>
                <asp:Label ID="lblUsername" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Permission:</td>
            <td>
                <asp:Label ID="lblPermission" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Logs:</td>
            <td>
                <asp:HyperLink ID="lnkLogs" runat="server">HyperLink</asp:HyperLink>
            </td>
        </tr>
    </table>
    <p><b>Actions</b></p>
    <p class="entityactions">
    <asp:HyperLink ID="lnkEdit" runat="server"><img src="../Images/edit.png" alt="" height="12" />Edit</asp:HyperLink>
    <asp:HyperLink ID="lnkDelete" runat="server" onclick = "if (! confirm('Are you sure you want to delete this record?')) { return false; }"><img src="../Images/delete.png" alt="" height="12" />Delete</asp:HyperLink>
</p>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cphCommonBottom" Runat="Server">
</asp:Content>

