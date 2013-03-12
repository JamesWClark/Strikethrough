<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Whiteboard.master" AutoEventWireup="true" CodeBehind="Whiteboard.aspx.cs" Inherits="Strikethrough.Members.Whiteboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WhiteboardPlaceholder" runat="server">
<canvas id="base-canvas" width="600" height="400"></canvas>
<script type="text/javascript">
    $(function () {
        $('#base-canvas').sketch();
    });
</script>
</asp:Content>
