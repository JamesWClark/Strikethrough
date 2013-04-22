<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Member.master" AutoEventWireup="true" CodeBehind="CreateGroup.aspx.cs" Inherits="Strikethrough.Members.CreateGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MemberPlaceholder" runat="server">
    <h3>Create a New Group</h3>
    <asp:TextBox ID="txtGroupName" placeholder="group name" runat="server"></asp:TextBox>
    <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create Group" />
    <br />
    <asp:RequiredFieldValidator ID="rfvGroupName" runat="server" ControlToValidate="txtGroupName" ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
</asp:Content>
