<%@ Page Title="" Language="C#" MasterPageFile="~/Assets/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Strikethrough.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            //$('#MainPlaceholder_CreateUserWizard1_CreateUserStepContainer_UserName')
            $('#MainPlaceholder_CreateUserWizard1_CreateUserStepContainer_UserName').attr('placeholder', 'Username');
            $('#MainPlaceholder_CreateUserWizard1_CreateUserStepContainer_Password').attr('placeholder', 'Password');
            $('#MainPlaceholder_CreateUserWizard1_CreateUserStepContainer_ConfirmPassword').attr('placeholder', 'Confirm Password');
            $('#MainPlaceholder_CreateUserWizard1_CreateUserStepContainer_Email').attr('placeholder', 'Email');
            $('#MainPlaceholder_CreateUserWizard1_CreateUserStepContainer_Question').attr('placeholder', 'Security Question');
            $('#MainPlaceholder_CreateUserWizard1_CreateUserStepContainer_Answer').attr('placeholder', 'Security Answer');

            $('#MainPlaceholder_CreateUserWizard1_CreateUserStepContainer_UserNameRequired').text('Username is a required field.');
            $('#MainPlaceholder_CreateUserWizard1_CreateUserStepContainer_PasswordRequired').text('Password is a required field.');
            $('#MainPlaceholder_CreateUserWizard1_CreateUserStepContainer_ConfirmPasswordRequired').text('Confirm Password is a required field.');
            $('#MainPlaceholder_CreateUserWizard1_CreateUserStepContainer_EmailRequired').text('Email is a required field.');
            $('#MainPlaceholder_CreateUserWizard1_CreateUserStepContainer_QuestionRequired').text('Question is a required field.');
            $('#MainPlaceholder_CreateUserWizard1_CreateUserStepContainer_AnswerRequired').text('Answer is a required field.');
            $('input:text').each(function () {
                $(this).attr('autocomplete', 'off');
            });
        });
        
    </script>
    <style>
        table {
            width:100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceholder" runat="server">
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" ContinueDestinationPageUrl="~/Members/Default.aspx" AnswerLabelText="" ConfirmPasswordLabelText="" EmailLabelText="" PasswordLabelText="" QuestionLabelText="" UserNameLabelText="">
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
