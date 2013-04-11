<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="Strikethrough.Account.RecoverPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceholder" runat="server">
    <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" Enabled="False">
</asp:PasswordRecovery>
</asp:Content>
