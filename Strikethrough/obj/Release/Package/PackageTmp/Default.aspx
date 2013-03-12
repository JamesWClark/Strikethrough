<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Strikethrough.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceholder" runat="server">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <h3>Welcome, <a href="Login.aspx">Login</a></h3>
            <h3>Don&#39;t have an account? <a href="Signup.aspx">Signup</a></h3>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <p>Welcome, <asp:LoginName ID="LoginName1" runat="server" />. Not you? <asp:LoginStatus ID="LoginStatus2" runat="server" /></p>
            <p><a href="Members/Default.aspx">Go to Whiteboard</a></p>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
