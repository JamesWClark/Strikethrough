<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Whiteboard.master" AutoEventWireup="true" CodeBehind="Whiteboard.aspx.cs" Inherits="Strikethrough.Members.Whiteboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WhiteboardPlaceholder" runat="server">
    
    <asp:Button ID="btnSave" runat="server" Text="Save This Whiteboard" OnClientClick="setHiddenCanvasDataUrl()" OnClick="btnSave_Click" />
    
    <input style="text-align:center;" name="" id="txtCanvasName" placeholder="Name your whiteboard" value="" runat="server" type="text" />
    
    <h3><asp:RequiredFieldValidator ID="rfvCanvasName" runat="server" ControlToValidate="txtCanvasName" ErrorMessage="This is a required field." SetFocusOnError="True"></asp:RequiredFieldValidator></h3>
    
    <div id="canvas-wrapper">
        <canvas id="base-canvas" width="600" height="400"></canvas>
    </div>

    <h3><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></h3>

    <input type="hidden" id="hiddenDataUrl" runat="server" />

    <script type="text/javascript">
        $(function () {
            $('#base-canvas').sketch();
        });
        function setHiddenCanvasDataUrl() {
            var canvas = $("#base-canvas")[0];
            var dataUrl = canvas.toDataURL();
            $("#MainPlaceholder_MemberPlaceholder_WhiteboardPlaceholder_hiddenDataUrl").val(dataUrl);
        }
    </script>

</asp:Content>
