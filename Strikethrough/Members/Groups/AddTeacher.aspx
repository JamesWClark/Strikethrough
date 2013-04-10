<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Member.master" AutoEventWireup="true" CodeBehind="AddTeacher.aspx.cs" Inherits="Strikethrough.Members.Groups.AddTeacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MemberPlaceholder" runat="server">
    <h3>Add a Teacher</h3>
    <asp:TextBox ID="txtTeacherEmail" placeholder="email address" runat="server" Width="221px"></asp:TextBox> 
    <asp:Button ID="btnAddTeacher" runat="server" Text="Add Teacher" OnClick="btnAddTeacher_Click" />
    <br />
    <asp:RequiredFieldValidator ID="rfvTeacherEmail" runat="server" ErrorMessage="This is a required field" ControlToValidate="txtTeacherEmail"></asp:RequiredFieldValidator>
</asp:Content>
