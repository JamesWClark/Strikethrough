﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Member.master" AutoEventWireup="true" CodeBehind="AddTeacher.aspx.cs" Inherits="Strikethrough.Members.Groups.AddTeacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MemberPlaceholder" runat="server">
    <h3>Add a Teacher</h3>
    <asp:TextBox ID="txtTeacherEmail" autocomplete="off" placeholder="email address" runat="server" Width="221px"></asp:TextBox> 
    <asp:Button data-theme="b" ID="btnAddTeacher" runat="server" Text="Add Teacher" OnClick="btnAddTeacher_Click" />
    <br />
    <asp:RequiredFieldValidator ID="rfvTeacherEmail" runat="server" ErrorMessage="This is a required field" ControlToValidate="txtTeacherEmail"></asp:RequiredFieldValidator>
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
