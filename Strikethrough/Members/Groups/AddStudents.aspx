<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Member.master" AutoEventWireup="true" CodeBehind="AddStudents.aspx.cs" Inherits="Strikethrough.Members.Groups.AddStudents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MemberPlaceholder" runat="server">
    <h3>Prospective Students</h3>
    <asp:Table ID="tblProspectiveStudents" runat="server"></asp:Table>
    <br />
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
    <br />
    <br />
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</asp:Content>
