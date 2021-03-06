﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Member.master" AutoEventWireup="true" CodeBehind="GroupManager.aspx.cs" Inherits="Strikethrough.Members.GroupManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MemberPlaceholder" runat="server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Members/Groups/CreateGroup.aspx">Create a Group</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Members/Groups/AddTeacher.aspx">Add a Teacher</asp:HyperLink>
    <br />
    <br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblSupervisorOf" runat="server" Text=""></asp:Label>
    <br />
    <asp:PlaceHolder ID="phSupervisorOf" runat="server"></asp:PlaceHolder>
    <br />
    <br />
    <asp:Label ID="lblMemberOf" runat="server" Text=""></asp:Label>
    <br />
    <asp:PlaceHolder ID="phMemberOf" runat="server"></asp:PlaceHolder>
    <br />
    <br />
    <asp:Label ID="lblHasTeachers" runat="server" Text=""></asp:Label>
    <br />
    <asp:PlaceHolder ID="phHasTeachers" runat="server"></asp:PlaceHolder>
    <br />
    <br />
    <asp:Label ID="lblHasProspectiveStudents" runat="server" Text=""></asp:Label>
    <br />
    <asp:PlaceHolder ID="phHasProspectiveStudents" runat="server"></asp:PlaceHolder>
</asp:Content>
