<%@ Page Title="Edit User Account | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="EditUser.aspx.vb" Inherits="User_EditUser" EnableEventValidation="false" %>

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
    <h2><img alt="" src="../Images/icon4.jpg" height="25" /> Edit Account</h2>
<p>Use the form below to update existing account.</p>
<p>User name and Passwords are required to be a minimum of 4 characters in length.</p>
<span class="failureNotification">
<asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
</span>
<asp:ValidationSummary ID="UpdateUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="UpdateUserValidationGroup"/>
                    <div class="accountInfo">
<div class="accountInfo">
                        <fieldset class="register">
                            <legend>Account Information</legend>
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtUsername">User Name:</asp:Label>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUsername" 
                                     CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                                     ValidationGroup="UpdateUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="valUsername" CssClass="failureNotification" ControlToValidate="txtUsername" runat="server" ErrorMessage="Invalid username" ValidationGroup="UpdateUserValidationGroup" ToolTip="User Name is required.">*</asp:CustomValidator>
                            </p>
                            <p>
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="txtName">Name:</asp:Label>
                                <asp:TextBox ID="txtName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="txtName" 
                                     CssClass="failureNotification" ErrorMessage="Name is required." ToolTip="Name is required." 
                                     ValidationGroup="UpdateUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="txtPassword">Password:</asp:Label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="passwordEntry" 
                                    TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword" 
                                     CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                                     ValidationGroup="UpdateUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="valPassword" ControlToValidate="txtPassword" CssClass="failureNotification" ToolTip="Invalid password" runat="server" ValidationGroup="UpdateUserValidationGroup" ErrorMessage="Invalid password">*</asp:CustomValidator>
                            </p>
                            <p>
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                                    AssociatedControlID="txtConfirmPassword">Confirm Password:</asp:Label>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="passwordEntry" 
                                    TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="txtConfirmPassword" 
                                    CssClass="failureNotification" Display="Dynamic" 
                                     ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired" runat="server" 
                                     ToolTip="Confirm Password is required." 
                                    ValidationGroup="UpdateUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                    ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" 
                                     CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                     ValidationGroup="UpdateUserValidationGroup">*</asp:CompareValidator>
                            </p>
                            <p>
                                <asp:Label ID="PermissionLabel" runat="server" Text="Permission:" 
                                    AssociatedControlID="ddlPermission"></asp:Label>
                                <asp:DropDownList ID="ddlPermission" runat="server">
                                    <asp:ListItem Value="1">Data Entry Operator</asp:ListItem>
                                    <asp:ListItem Value="2">Coordinator</asp:ListItem>
                                    <asp:ListItem Value="3">Admin</asp:ListItem>
                                    <asp:ListItem Value="0">Deactivated</asp:ListItem>
                                </asp:DropDownList>
                            </p>
                        </fieldset>
                        <p class="submitButton">
                            <asp:Button ID="UpdateUserButton" runat="server" CommandName="MoveNext" Text="Update User" 
                                 ValidationGroup="UpdateUserValidationGroup" />
                        </p>
                    </div></div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPerm1" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPerm2" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPerm3" Runat="Server">
</asp:Content>

