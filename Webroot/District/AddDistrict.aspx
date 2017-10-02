<%@ Page Title="Add District | Sri Lanka Job Bank" Language="VB" MasterPageFile="~/MasterMain.master" AutoEventWireup="false" CodeFile="AddDistrict.aspx.vb" Inherits="District_AddDistrict" %>

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
<h2>Add a New District</h2>
<p>Use the form below to add a new district.</p>
<span class="failureNotification">
<asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
</span>
<asp:ValidationSummary ID="AddDisctrictValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="AddDistrictValidationGroup"/>

                         <div class="accountInfo">
                        <fieldset class="register">
                            <legend>District Information</legend>
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" 
                                    AssociatedControlID="txtDistrctname">District Name:</asp:Label>
                                <asp:TextBox ID="txtDistrctname" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="DisctrictNameRequired" runat="server" ControlToValidate="txtDistrctname" 
                                     CssClass="failureNotification" ErrorMessage="Distrct Name is required." ToolTip="District Name is required." 
                                     ValidationGroup="AddDistrictValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            
                        </fieldset>
                        <p class="submitButton">
                            <asp:Button ID="AddDistrictButton" runat="server" CommandName="MoveNext" Text="Add District" 
                                 ValidationGroup="AddDistrictValidationGroup" />
                        </p>
                    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPerm3" Runat="Server">
    
</asp:Content>

