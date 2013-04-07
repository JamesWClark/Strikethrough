<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/Assets/MasterPages/Mobile.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Strikethrough.Mobile.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceholder" runat="server">
    <asp:Login ID="Login1" runat="server" DisplayRememberMe="False" DestinationPageUrl="~/Members/Default.aspx"></asp:Login>
    <asp:Label ID="lblStub" runat="server" Text=""></asp:Label>
</asp:Content>
