<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Strikethrough.ErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: xx-large;
            color: #FF0000;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
    
        <strong><em>OOPs.. Unexpected error occured. The admins will be notified asap. 
        thanks for your patience..<br />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/error.jpg" />
        </em></strong>
    
    </div>
    </form>
</body>
</html>
