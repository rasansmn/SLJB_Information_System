<%@ Page Title="View Job Campaign | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="ViewCampaign.aspx.vb" Inherits="Campaign_ViewCampaign" %>

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
    <h2><img alt="" src="../Images/icon9.gif" height="25" /> <asp:Label ID="lblHeader" runat="server"></asp:Label></h2>
    <br />
    <table class="viewentity">
        <tr>
            <td>
                Campaign ID:</td>
            <td>
                <asp:Label ID="lblCampaignid" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Location:</td>
            <td>
                <asp:Label ID="lblLocation" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Date:</td>
            <td>
                <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Divisional Area:</td>
            <td>
                <asp:Label ID="lblDivision" runat="server" Text="Label"></asp:Label>
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
&nbsp;<asp:Label ID="Label2" runat="server" AssociatedControlID="ddlEmployer" 
        Text="Employer: "></asp:Label>
    <asp:DropDownList ID="ddlEmployer" runat="server">
    </asp:DropDownList>
    <asp:Label ID="Label1" runat="server" Text=" Invoice Payment: " 
        AssociatedControlID="txtAmount"></asp:Label>
    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
    <asp:Button ID="btnSumbit" runat="server" Text="Submit Sponsorship" />
</p>
<p class="entityactions">
    <asp:HyperLink ID="lnkEdit" runat="server"><img src="../Images/edit.png" alt="" height="12" />Edit</asp:HyperLink>
    <asp:HyperLink ID="lnkDelete" runat="server" onclick = "if (! confirm('Are you sure you want to delete this record?')) { return false; }"><img src="../Images/delete.png" alt="" height="12" />Delete</asp:HyperLink>
</p>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPerm3" Runat="Server">
</asp:Content>

