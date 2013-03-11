<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Strikethrough.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceholder" runat="server">
    <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Members/Default.aspx" DisplayRememberMe="False"></asp:Login>
</asp:Content>
