<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Member.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Strikethrough.Members.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberPlaceholder" runat="server">
    <asp:Button ID="btnCreateCanvas" runat="server" Text="Create New Whiteboard" PostBackUrl="~/Members/Whiteboard.aspx" />
    <asp:DropDownList ID="ddlOpen" runat="server"></asp:DropDownList>
    <asp:SqlDataSource ID="dsCanvas" runat="server"></asp:SqlDataSource>
    </asp:Content>


