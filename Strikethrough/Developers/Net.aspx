<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Net.aspx.cs" Inherits="Strikethrough.Developers.Net" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        The point of this page is to learn how to show a visitor&#39;s IP address. It likely won&#39;t work on localhost test, but will when deployed to a web server.<br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="[if you are reading this, it didn't work]"></asp:Label>
    
    </div>
    </form>
</body>
</html>
