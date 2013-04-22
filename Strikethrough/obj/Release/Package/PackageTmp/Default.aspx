<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Strikethrough.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Assets/Stylesheets/member.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceholder" runat="server">
    <div style="text-align:center;"><img src="Assets/Images/home.png" /></div>
    <br />
    <div style="text-align:center;">
        <div class="button-wrapper"><asp:Button ID="btnLogin" runat="server" Text="Login" PostBackUrl="~/Account/Login.aspx" /></div>
        <div class="button-wrapper"><asp:Button ID="btnRegister" runat="server" Text="Register" PostBackUrl="~/Account/Register.aspx" /></div>
    </div>
</asp:Content>
