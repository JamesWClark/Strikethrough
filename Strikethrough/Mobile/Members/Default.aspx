<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/Assets/MasterPages/MobileMember.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Strikethrough.Mobile.Members.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberPlaceholder" runat="server">
    <asp:Button ID="btnCreateCanvas" runat="server" Text="Create New Whiteboard" PostBackUrl="~/Members/Whiteboard.aspx" />
    <h3>Or, open an existing whiteboard:</h3>
    <asp:DropDownList ID="ddlOpen" runat="server" DataTextField="Label" DataValueField="CanvasId" OnInit="ddlOpen_Init" OnSelectedIndexChanged="ddlOpen_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
    <asp:Label ID="lblStub" runat="server" Text=""></asp:Label>
    <asp:SqlDataSource ID="dsCanvasId" runat="server"></asp:SqlDataSource>
    <asp:HiddenField ID="hiddenUserId" runat="server" OnInit="hiddenUserId_Init" />
    </asp:Content>
