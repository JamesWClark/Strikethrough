<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Member.master" AutoEventWireup="true" CodeBehind="SaveCanvas.aspx.cs" Inherits="Strikethrough.Members.SaveCanvas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MemberHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MemberPlaceholder" runat="server">
<div class="full-screen-div">
    <div class="center">
        <asp:Button ID="btnSave" runat="server" Text="Save" />   
        <input style="text-align:center;" name="" id="txtDocName" placeholder="Name your whiteboard" value="" runat="server" type="text" autocomplete="off" /> 
        <asp:DropDownList ID="ddlGroups" runat="server"></asp:DropDownList>
        <h3><asp:RequiredFieldValidator ID="rfvCanvasName" runat="server" ControlToValidate="txtDocName" ErrorMessage="This is a required field." SetFocusOnError="True"></asp:RequiredFieldValidator></h3>
    </div>
</div>
</asp:Content>
