<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Whiteboard.master" AutoEventWireup="true" CodeBehind="Whiteboard.aspx.cs" Inherits="Strikethrough.Members.Whiteboard" %>
<%@ OutputCache VaryByParam="*" Duration="60" VaryByCustom="isMobileDevice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WhiteboardPlaceholder" runat="server">
<div data-role="header" data-theme="a">
    <asp:LinkButton data-theme="b" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CausesValidation="False">Home</asp:LinkButton>
    <h1><asp:Label ID="lblHeader" runat="server" Text="Strikethrough"></asp:Label></h1>
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
        <span id="currentPage" style="display:inline-block; font-size:large;">1</span>
        <span style="display:inline-block; font-size:large;">/</span>
        <span id="totalPages" style="display:inline-block; font-size:large;">1</span>
        <span style="display:inline-block;"><a id="btnAddPage" data-role="button">+</a></span>
        <span style="display:inline-block;"><a id="btnGoToNext" data-role="button">&gt;</a></span>
        <!--<span style="display:inline-block;">
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="setDomCanvasUrls()" />
        </span>-->
        <span style="display:inline-block;"><a id="A1" onclick="setDomCanvasUrls()" data-role="button">Save</a></span>
    </div>
</div>

<div id="hidden-section" style="visibility:hidden">
    <!--
        edit modes
        1 - new
        2 - edit
        3 - assignment
    -->
    <input type="hidden" id="editMode" runat="server" />
    <input type="hidden" id="hiddenCanvasId" runat="server" />
    <input type="hidden" id="documentJSON" runat="server" />
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
    var editMode; //state of the document

    //function definitions
    //ideally wouldn't have to subtract 40 here, but i'm experiencing a problem with the height by about this margin (probably related to master css font-size in footer
    function fitToContainer(canvas) {
        canW = divH * aspectRatio;
        canH;
        //if canvas is wider than its container
        if (canW > divW) {
            canW = divW;
            canH = divW / aspectRatio - 30;
        } else {
            canW = divH * aspectRatio;
            canH = divH - 30;
        }
        canvas.width = canW;
        canvas.height = canH;
        centerPage();
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

            switch (editMode) {
                case '1':
                    var prevCanvas = $(currentCanvas).prev();
                    $(currentCanvas).remove();
                    currentCanvas = prevCanvas;
                    break;
                case '2':
                    var prevCanvas = $(currentCanvas).prev(); //get id of previous canvas
                    var prevId = $(prevCanvas).attr('id');
                    if (prevId.charAt(prevId.length - 1) === 'e') //if previous id ends with 'e', get another previous
                        prevCanvas = $(prevCanvas).prev();
                    var id = $(currentCanvas).attr('id'); 
                    $('canvas[id^="' + id + '"]').remove(); //delete with ID like example: canvas1, canvas1e
                    currentCanvas = prevCanvas;
                    break;
            }
            goToPage();
        }
    }
    function goToPrevious() {
        if (currentPage !== 1) {
            currentPage = currentPage - 1;
            updatePageTotals();
            switch (editMode) {
                case '1':
                    currentCanvas = $(currentCanvas).prev();
                    break;
                case '2':
                    currentCanvas = $(currentCanvas).prev(); //get id of previous canvas
                    var id = $(currentCanvas).attr('id');
                    if (id.charAt(id.length - 1) === 'e') //if previous id ends with 'e', get another previous
                        currentCanvas = $(currentCanvas).prev();
                    break;
            }
            goToPage();
        }
    }
    function goToNext() {
        if (currentPage !== totalPages) {
            currentPage = currentPage + 1;
            updatePageTotals();
            switch (editMode) {
                case '1':
                    currentCanvas = currentCanvas.next();
                    break;
                case '2':
                    currentCanvas = $(currentCanvas).next(); //get id of previous canvas
                    var id = $(currentCanvas).attr('id');
                    if (id.charAt(id.length - 1) === 'e') //if previous id ends with 'e', get another previous
                        currentCanvas = $(currentCanvas).next();
                    break;
            }
            goToPage();
        }
    }
    function goToPage() {
        hidePages(); //hide all pages
        var id = $(currentCanvas).attr('id');
        switch (editMode) {
            case '1':
                $(currentCanvas).show(); //show current page
                break;
            case '2':
                $('canvas[id^="' + id + '"]').show(); //show current page and background (elements with id like canvas1, canvas2, etc...
                break;
        }
        centerPage();
        registerButtons();
    }
    function hidePages() {
        //hide all pages
        $('#canvas-container').children().each(function () {
            $(this).hide();
        });
    }
    function centerPage() {
        var id = $(currentCanvas).attr('id');
        $('canvas[id^="' + id + '"]').css('margin-left', canW / -2); //centers the canvas
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
    function setDomCanvasUrls() {
        //pages of the document, parsing to base 64 and storing in DOM for .NET to store in session
        var data = {};
        switch (editMode) {
            case '1':
                $('#canvas-container').children().each(function () {
                    var canvas = $(this)[0];
                    var id = $(canvas).attr('id');
                    var dataUrl = canvas.toDataURL();
                    data[id] = dataUrl;
                });
                break;
            case '2':
                $('#canvas-container').children().each(function () {
                    var canvas = $(this)[0];
                    var id = $(canvas).attr('id'); //got an ID
                    if (id.charAt(id.length - 1) === 'e') { //ends with 'e' : it's a background
                        //skip processing this
                    } else { //look for a background
                        var background = $('#' + id + 'e'); //look for the same ID with 'e' at the end
                        if (background !== 'undefined' && background !== false) {//background found
                            var destinationCanvas = background;
                            var destinationContext = background.getContext('2d');
                            var sourceCanvas = canvas;
                            destinationContext.drawImage(sourceCanvas, 0, 0);
                            destinationContext.save();
                            var dataUrl = destinationCanvas.toDataURL();
                            data[id] = dataUrl;
                        }
                    }
                });
                break;
        }
        var json = JSON.stringify(data, null, 2);
        $('#MainPlaceholder_WhiteboardPlaceholder_documentJSON').val(json);
    }
    function loadCanvas(value) {
        totalPages = totalPages + 1;
        updatePageTotals();
        var foregroundId = "canvas" + idCount; //the active writing layer
        var backgroundId = foregroundId + "e"; //i want different but similar IDs here, because they represent one page in a document
        $('#canvas-container').append('<canvas class="whiteboard" id="' + foregroundId + '" width="' + canW + '" height="' + canH + '" style="display: none; z-index: 1;"></canvas>'); //foreground
        $('#canvas-container').append('<canvas class="whiteboard" id="' + backgroundId + '" width="' + canW + '" height="' + canH + '" style="display: none; z-index: 0;"></canvas>'); //background
        var canvas = document.querySelector('#' + backgroundId); //reference to background
        var context = canvas.getContext('2d');

        // load image from data url
        var imageObj = new Image();
        imageObj.onload = function () {
            context.drawImage(this, 0, 0);
        };
        imageObj.src = value;

        idCount = idCount + 1; //maintain unique IDs always
        $('#' + foregroundId).sketch(); //add drawing to foreground layer
    }
    //events
    $(document).ready(new function () {
        //initialize variables
        divH = $('#canvas-container').height(); //container div height
        divW = $('#canvas-container').width(); //container div width
        idCount = 1;
        totalPages = 1;
        currentPage = 1;
        aspectRatio = 0.772727273; // 8.5 divided by 11 (standard letter portrait)
        var relativeWeight = divH / 1056; // relative pen size = container height divided by 1056 (11 inches) = relative pen density

        //canvas and context
        var canvas = document.querySelector('#canvas1');
        var ctx = canvas.getContext('2d');

        //set the stage dimensions
        currentCanvas = $('#canvas1');
        fitToContainer(canvas);
        $('#canvas1').sketch();

        //check edit mode of document
        var attr = $('#MainPlaceholder_WhiteboardPlaceholder_editMode').attr('value');
        if (attr !== 'undefined' && attr !== false) { //has edit mode
            editMode = attr;
            switch (attr) {
                //new
                case '1':
                    break;
                //edit
                case '2':
                    $('#canvas1').remove();
                    totalPages = 0;
                    var json = $('#MainPlaceholder_WhiteboardPlaceholder_documentJSON').val();
                    $.each($.parseJSON(json), function (key, value) {
                        loadCanvas(value);
                    });
                    currentCanvas = $('.whiteboard').first();
                    goToPage();
                    break;
            }
        }
        


        //BUG: relative weight needs to adjust to scenario where available height is greater than width of page
        // see method fitToContainer
        $('#weight1').attr('data-size', 1 * relativeWeight);
        $('#weight2').attr('data-size', 4 * relativeWeight);
        $('#weight3').attr('data-size', 8 * relativeWeight);

        registerButtons();
    });
    $('#btnAddPage').click(addPage);
    $('#btnRemovePage').click(removePage);
    $('#btnGoToPrevious').click(goToPrevious);
    $('#btnGoToNext').click(goToNext);

</script>
</asp:Content>
