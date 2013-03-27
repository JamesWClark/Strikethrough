<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Whiteboard.master" AutoEventWireup="true" CodeBehind="Whiteboard.aspx.cs" Inherits="Strikethrough.Members.Whiteboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WhiteboardPlaceholder" runat="server">

    <asp:Button ID="btnSave" runat="server" Text="Save This Whiteboard" OnClientClick="setHiddenCanvasDataUrl()" OnClick="btnSave_Click" />   
    <input style="text-align:center;" name="" id="txtCanvasName" placeholder="Name your whiteboard" value="" runat="server" type="text" autocomplete="off" /> 
    <h3><asp:RequiredFieldValidator ID="rfvCanvasName" runat="server" ControlToValidate="txtCanvasName" ErrorMessage="This is a required field." SetFocusOnError="True"></asp:RequiredFieldValidator></h3>
    
    <canvas id="base-canvas" width="600" height="400" style="z-index: 0;"></canvas>
    <div id="canvas-container">
    </div>

    <h3><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></h3>
    <input type="hidden" id="hiddenDataUrl" runat="server" />
    <input type="hidden" id="hiddenCanvasId" runat="server" />

    <script type="text/javascript">
        var z = 1; //used for z-index. seems unnecessary, but i'm retaining this implementation b/c it's possible that later i will be looping multiple layers.
        var canvasHeight = 400;
        var canvasWidth = 600;

        if ($("#MainPlaceholder_MemberPlaceholder_WhiteboardPlaceholder_hiddenDataUrl").attr('value')) {
            var src = $("#MainPlaceholder_MemberPlaceholder_WhiteboardPlaceholder_hiddenDataUrl").val();
            loadImage(src);
            $('#canvas-container').html('<canvas id="layer' + z + '" width="' + canvasWidth + '" height="' + canvasHeight + '" style="z-index: ' + z + ';" ></canvas>');
            $('#layer' + z + '').sketch();
        }
        else {
            $('#base-canvas').sketch();
        }
        function loadImage(src) {
            var canvas = $('#base-canvas')[0];
            var context = canvas.getContext('2d');
            // load image from data url
            var imageObj = new Image();
            imageObj.onload = function () {
                context.drawImage(this, 0, 0);
            };
            imageObj.src = src;
        }
        //called by whiteboard.aspx.cs code-behind file's button control (onClientClick attribute)
        function setHiddenCanvasDataUrl() {
            saveCanvas();
            var canvas = $("#base-canvas")[0];
            var dataUrl = canvas.toDataURL();
            //this id does not exist by inspection until after the master pages are implemented
            $("#MainPlaceholder_MemberPlaceholder_WhiteboardPlaceholder_hiddenDataUrl").val(dataUrl);
        }
        //this method flattens the canvas layers into one single canvas image before being sent to the database server as a base 64 image text
        function saveCanvas() {
            var destinationCanvas = document.getElementById('base-canvas');
            var destinationContext = destinationCanvas.getContext('2d');
            $('#canvas-container canvas').each(function () {
                var sourceCanvas = $(this)[0];
                destinationContext.drawImage(sourceCanvas, 0, 0);
                //document.write(this.id);
            });
            destinationContext.save();
            //window.open(destinationCanvas.toDataURL("image/png"), "toDataURL() image", "width=600, height=200");
        }
    </script>
</asp:Content>
