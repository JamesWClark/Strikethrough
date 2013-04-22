<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Strikethrough.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $('#MainPlaceholder_Login1_UserName').attr('placeholder', 'Username');
            $('#MainPlaceholder_Login1_UserName').attr('autocomplete', 'off');
            $('#MainPlaceholder_Login1_Password').attr('placeholder', 'Password');
            $('#MainPlaceholder_Login1_UserNameRequired').text('Username is a required field.');
            $('#MainPlaceholder_Login1_PasswordRequired').text('Password is a required field.');
        });
    </script>
    <style>
        table {
            width:100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceholder" runat="server">
    <asp:Login ID="Login1" runat="server" DisplayRememberMe="False" DestinationPageUrl="~/Members/Default.aspx" PasswordLabelText="" TitleText="" UserNameLabelText="" Width="100%"></asp:Login>
    <br />
    <a href="Register.aspx">Create an account</a>
    <br />
    <a href="RecoverPassword.aspx">I forgot my password</a><br />
    <br />
    <asp:Label ID="lblStub" runat="server" Text=""></asp:Label>
</asp:Content>
