<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Whiteboard.master" AutoEventWireup="true" CodeBehind="Whiteboard.aspx.cs" Inherits="Strikethrough.Members.Whiteboard" %>
<%@ OutputCache VaryByParam="*" Duration="60" VaryByCustom="isMobileDevice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WhiteboardPlaceholder" runat="server">
<div data-role="header" data-theme="a">
    <asp:LinkButton data-theme="b" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CausesValidation="False">Home</asp:LinkButton>
    <h1>Strikethrough</h1>
    <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutPageUrl="~/Default.aspx" data-theme="b" LogoutAction="Redirect" />
    <div style="text-align:center;">
    <fieldset data-role="controlgroup" data-type="horizontal">
        <legend></legend>
        <a id="color1" data-color="#000000" data-tool="marker" data-role="button">Black</a>
        <a id="color2" data-color="#FF0000" data-tool="marker" data-role="button">Red</a>
        <a id="color3" data-color="#0080FF" data-tool="marker" data-role="button">Blue</a>
        <a id="weight1" data-role="button">1</a>
        <a id="weight2" data-role="button">2</a>
        <a id="weight3" data-role="button">3</a>
        <a id="eraser" data-size="35" data-tool="eraser" data-role="button">Erase</a>
    </fieldset>
    </div>
</div>

<div data-role="content" class="fit-content">	
    <div id="canvas-container" class="yellow-bg">        
        <canvas class="whiteboard" id="canvas1"></canvas>
    </div>
</div>

<div data-role="footer" class="bottom-footer">
    <div id="footer-controls" style="text-align:center;">
        <span style="display:inline-block;"><a id="btnTrash" data-role="button">Delete</a></span>
        <span style="display:inline-block;"><a id="btnGoToPrevious" data-role="button">&lt;</a></span>  
        <span style="display:inline-block;"><a id="btnRemovePage" data-role="button">-</a></span>              
        <span id="currentPage" style="display:inline-block;">1</span>
        <span style="display:inline-block;">/</span>        
        <span id="totalPages" style="display:inline-block;">1</span>
        <span style="display:inline-block;"><a id="btnAddPage" data-role="button">+</a></span>
        <span style="display:inline-block;"><a id="btnGoToNext" data-role="button">&gt;</a></span>
        <span style="display:inline-block;"><asp:Button ID="btnSave" runat="server" Text="Save" /></span>
    </div>
</div>

<div id="hidden-section">
    <input type="hidden" id="hiddenDataUrl" runat="server" />
    <input type="hidden" id="hiddenCanvasId" runat="server" />
</div>

<!-- ## SCRIPTS ## -->
<script type="text/javascript">
    //variables
    var divH; //container div height
    var divW; //container div width
    var canW; //internal canvas width
    var canH; //internal canvas height
    var totalPages;
    var currentPage;
    var currentCanvas; //the visible canvas
    var aspectRatio; // 8.5 divided by 11 (standard letter portrait)
    var idCount; //the number of times a new canvas is created (important for unique ID)

    //function definitions
    function fitToContainer(canvas) {
        canW = divH * aspectRatio;
        canH;
        //if canvas is wider than its container
        if (canW > divW) {
            canW = divW;
            canH = divW / aspectRatio;
        } else {
            canW = divH * aspectRatio;
            canH = divH;
        }
        canvas.width = canW;
        canvas.height = canH;
    }
    function addPage() {
        idCount = idCount + 1;
        totalPages = totalPages + 1;
        currentPage = totalPages; //set current page to last page
        updatePageTotals();
        $('#canvas-container').append('<canvas class="whiteboard" id="canvas' + idCount + '" width="' + canW + '" height="' + canH + '"></canvas>');
        $('#canvas' + idCount).sketch();
        currentCanvas = $('.whiteboard').last();
        goToPage(currentCanvas);
    }
    function removePage() {
        if (currentPage !== 1) {
            currentPage = currentPage - 1;
            totalPages = totalPages - 1;
            updatePageTotals();
            var prevCanvas = currentCanvas.prev();
            $(currentCanvas).remove();
            currentCanvas = prevCanvas;
            goToPage();
        }
    }
    function goToPrevious() {
        if (currentPage !== 1) {
            currentPage = currentPage - 1;
            updatePageTotals();
            currentCanvas = currentCanvas.prev();
            goToPage();
        }
    }
    function goToNext() {
        if (currentPage !== totalPages) {
            currentPage = currentPage + 1;
            updatePageTotals();
            currentCanvas = currentCanvas.next();
            goToPage();
        }
    }
    function goToPage() {
        hidePages(); //hide all pages 
        $(currentCanvas).show(); //show current page
        registerButtons();

    }
    function hidePages() {
        //hide all pages
        $('#canvas-container').children().each(function () {
            $(this).hide();
        });
    }
    function updatePageTotals() {
        $('#currentPage').text(currentPage);
        $('#totalPages').text(totalPages);
    }
    function registerButtons() {
        var id = '#' + $(currentCanvas).attr('id');
        $('#color1').attr('href', id);
        $('#color2').attr('href', id);
        $('#color3').attr('href', id);
        $('#weight1').attr('href', id);
        $('#weight2').attr('href', id);
        $('#weight3').attr('href', id);
        $('#eraser').attr('href', id);
        $('#weight1').click();
    }
    $(document).ready(new function () {
        //initialize variables
        divH = $('#canvas-container').height(); //container div height
        divW = $('#canvas-container').width(); //container div width
        idCount = 1;
        totalPages = 1;
        currentPage = 1;
        currentCanvas = $('#canvas1');
        aspectRatio = 0.772727273; // 8.5 divided by 11 (standard letter portrait)

        //canvas and context
        var canvas = document.querySelector('#canvas1');
        var ctx = canvas.getContext('2d');

        //set the stage dimensions
        $('#canvas1').sketch();
        fitToContainer(canvas);

        //establish relative pen sizes
        var relativeWeight = divH / 1056; // container height divided by 1056 (11 inches) = relative pen density
        /* BUG: relative weight needs to adjust to scenario where available height is greater than width of page */
        /* see method fitToContainer */
        $('#weight1').attr('data-size', 1 * relativeWeight);
        $('#weight2').attr('data-size', 4 * relativeWeight);
        $('#weight3').attr('data-size', 8 * relativeWeight);

        registerButtons();
    });
    //events
    $('#btnAddPage').click(addPage);
    $('#btnRemovePage').click(removePage);
    $('#btnGoToPrevious').click(goToPrevious);
    $('#btnGoToNext').click(goToNext);

</script>
</asp:Content>
