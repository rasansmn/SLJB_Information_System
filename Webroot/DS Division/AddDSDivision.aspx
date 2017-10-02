<%@ Page Title="Add Divisional Secretariat | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="AddDSDivision.aspx.vb" Inherits="DS_Division_AddDSDivision" %>

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
 <h2>Add a New Divisional Secretariat</h2>
<p>Use the form below to add a new Divisional Secretariat.</p>
<span class="failureNotification">
<asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
</span>
<asp:ValidationSummary ID="AddDisctrictValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="AddDSDivisionValidationGroup"/>

                         <div class="accountInfo">
                        <fieldset class="register">
                            <legend>Divisional Secretariat Information</legend>
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" 
                                    AssociatedControlID="txtDSName">DS Name:</asp:Label>
                                <asp:TextBox ID="txtDSName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="DisctrictNameRequired" runat="server" ControlToValidate="txtDSName" 
                                     CssClass="failureNotification" ErrorMessage="DS Name is required." ToolTip="DS Name is required." 
                                     ValidationGroup="AddDSDivisionValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                               <p>
       <asp:Label ID="Label15" runat="server" Text="District:" 
           AssociatedControlID="ddlDistrict"></asp:Label>
       <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="general">
       </asp:DropDownList>
   </p>
                        </fieldset>
                        <p class="submitButton">
                            <asp:Button ID="AddDSDivisionButton" runat="server" CommandName="MoveNext" Text="Add Divisional Secretariat" 
                                 ValidationGroup="AddDSDivisionValidationGroup" />
                        </p>
                    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPerm3" Runat="Server">
</asp:Content>

