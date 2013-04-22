<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Member.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Strikethrough.Members.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberPlaceholder" runat="server">
    
    <div data-role="collapsible-set" data-theme="c" data-content-theme="d">
        <div data-role="collapsible">
            <h3>Groups</h3>
            <div style="text-align:center;">
                <div class="button-wrapper"><asp:Button ID="btnCreateGroup" runat="server" Text="Create Group" PostBackUrl="Groups/CreateGroup.aspx" /></div>
                &nbsp;
                <div class="button-wrapper"><asp:Button ID="btnAddTeacher" runat="server" Text="Add Teacher" PostBackUrl="Groups/AddTeacher.aspx" /></div>
            </div>
            <br />
            <asp:Label ID="lblSupervisorOf" runat="server" Text=""></asp:Label>
            <br />
            <asp:PlaceHolder ID="phSupervisorOf" runat="server"></asp:PlaceHolder>
            <br />
            <asp:Label ID="lblMemberOf" runat="server" Text=""></asp:Label>
            <br />
            <asp:PlaceHolder ID="phMemberOf" runat="server"></asp:PlaceHolder>
        </div>
        <div data-role="collapsible">
            <h3>Whiteboards</h3>
            <asp:PlaceHolder ID="phWhiteboards" runat="server"></asp:PlaceHolder>
        </div>
        <div data-role="collapsible">
            <h3>Notifications</h3>
            <asp:PlaceHolder ID="phNotifications" runat="server"></asp:PlaceHolder>
        </div>
    </div>

    <a href="/Members/Whiteboard.aspx">Create New Whiteboard</a>
    <br />
    <asp:DropDownList ID="ddlOpen" runat="server" DataTextField="Label" DataValueField="CanvasId" OnInit="ddlOpen_Init" OnSelectedIndexChanged="ddlOpen_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
    <asp:Label ID="lblStub" runat="server" Text=""></asp:Label>
    <asp:SqlDataSource ID="dsCanvasId" runat="server"></asp:SqlDataSource>
    <asp:HiddenField ID="hiddenUserId" runat="server" OnInit="hiddenUserId_Init" />
    
</asp:Content>

