<%@ Page Title="Login | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterGuest.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="User_Login" %>

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
 <h2>Log In</h2>
<p>Please Enter your username and password.</p>
<span class="failureNotification">
    <asp:Literal ID="litFailure" runat="server"></asp:Literal>
</span>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        CssClass="failureNotification" ValidationGroup="LoginUserValidationGroup" />
    <fieldset class="login">
         <legend>Account Information</legend>
         <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtUsername">Username:</asp:Label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUsername" 
                             CssClass="failureNotification" ErrorMessage="Username is required." ToolTip="User Name is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                  <p>
                        <asp:Label ID="Label1" runat="server" Text="Password:"></asp:Label><br />
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="passwordEntry" 
                            TextMode="Password"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                            ErrorMessage="Password is required." ControlToValidate="txtPassword" 
                            CssClass="failureNotification" ToolTip="Password is required." 
                            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                  <p>
                      <asp:CheckBox ID="chkRememberme" runat="server" />
 <asp:Label ID="Label2" runat="server" Text="Remember Me" AssociatedControlID="chkRememberme" 
                          CssClass="inline"></asp:Label>
                  </p>
        
          </fieldset>
       <p class="submitButton">
       
           <asp:Button ID="btnLogin" runat="server" Text="Log In" 
               onclick="btnLogin_Click" ValidationGroup="LoginUserValidationGroup" 
                />
       </p>
</asp:Content>

