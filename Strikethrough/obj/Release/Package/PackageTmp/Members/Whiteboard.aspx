<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Whiteboard.master" AutoEventWireup="true" CodeBehind="Whiteboard.aspx.cs" Inherits="Strikethrough.Members.Whiteboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WhiteboardPlaceholder" runat="server">
    
    <asp:Button ID="btnSave" runat="server" Text="Save This Whiteboard" OnClientClick="setHiddenCanvasDataUrl()" OnClick="btnSave_Click" />
    
    <input style="text-align:center;" name="" id="txtCanvasName" placeholder="Name your whiteboard" value="" runat="server" type="text" autocomplete="off" />
    
    <h3><asp:RequiredFieldValidator ID="rfvCanvasName" runat="server" ControlToValidate="txtCanvasName" ErrorMessage="This is a required field." SetFocusOnError="True"></asp:RequiredFieldValidator></h3>
    
    <div id="canvas-wrapper">
        <canvas id="base-canvas" width="600" height="400"></canvas>
    </div>

    <h3><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></h3>

    <input type="hidden" id="hiddenDataUrl" runat="server" />
    <input type="hidden" id="hiddenCanvasId" runat="server" />

    <script type="text/javascript">
        $(function () {
            $('#base-canvas').sketch();
        });
        function setHiddenCanvasDataUrl() {
            var canvas = $("#base-canvas")[0];
            var dataUrl = canvas.toDataURL();
            //this id does not exist by inspection until after the master pages are implemented
            $("#MainPlaceholder_MemberPlaceholder_WhiteboardPlaceholder_hiddenDataUrl").val(dataUrl);
        }
        $(document).ready(loadCanvas());
        function loadCanvas() {
            var canvas = $('#base-canvas')[0];
            var context = canvas.getContext('2d');

            // load image from data url
            var imageObj = new Image();
            imageObj.onload = function () {
                context.drawImage(this, 0, 0);
            };
            imageObj.src = $("#MainPlaceholder_MemberPlaceholder_WhiteboardPlaceholder_hiddenDataUrl").val();
        }
    </script>

</asp:Content>
