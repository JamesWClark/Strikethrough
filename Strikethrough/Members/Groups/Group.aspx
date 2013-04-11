<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Member.master" AutoEventWireup="true" CodeBehind="Group.aspx.cs" Inherits="Strikethrough.Members.Groups.Group" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MemberPlaceholder" runat="server">
    <asp:Label ID="lblGroupName" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <br />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    <br />
    <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
</asp:Content>
