<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Member.master" AutoEventWireup="true" CodeBehind="GroupManager.aspx.cs" Inherits="Strikethrough.Members.GroupManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MemberPlaceholder" runat="server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Members/Groups/CreateGroup.aspx">Create a Group</asp:HyperLink>
    <br />
    <br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblTeacherMessage" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <asp:PlaceHolder ID="phTeacherList" runat="server"></asp:PlaceHolder>
    <br />
    <br />
    <asp:Label ID="lblMemberMessage" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <asp:PlaceHolder ID="phMemberList" runat="server"></asp:PlaceHolder>
</asp:Content>
