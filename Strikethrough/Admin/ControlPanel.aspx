<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs" Inherits="Strikethrough.Admin.ControlPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        User lookup:
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />
        <br />
        Queries:<br />
        <asp:PlaceHolder ID="phQueries" runat="server"></asp:PlaceHolder>
        <br />
        <br />
        <asp:Label ID="lblStub" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
