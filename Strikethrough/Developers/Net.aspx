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
    
        <br />
        <br />
        Based on the IP address, the following information is determinable from <a href="http://freegeoip.net/">http://freegeoip.net</a><br />
        <br />
        Using Json.NET, it is very easy to parse data requested in a format such as <a href="http://freegeoip.net/json/67.52.232.226">http://freegeoip.net/json/67.52.232.226</a><br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="[parse data here]"></asp:Label>
    
    </div>
    </form>
</body>
</html>
