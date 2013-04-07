<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/Assets/MasterPages/Mobile.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Strikethrough.Mobile.Signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceholder" runat="server">
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" ContinueDestinationPageUrl="~/Members/Default.aspx">
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
