<%@ Page Title="" Language="C#" MasterPageFile="~/LogInUserMaster.Master" AutoEventWireup="true" CodeBehind="FrmLogIn.aspx.cs" Inherits="UserRegisterSystem.FrmLogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="LblEmail_UserName" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TxtEmail_UserName" runat="server"></asp:TextBox>

    <asp:Label ID="LblPass" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TxtPass" runat="server"></asp:TextBox>

    <asp:Button ID="BtnGo" runat="server" Text="Go" />
    <asp:LinkButton ID="LkbtnSignIn" runat="server">Already have a account?</asp:LinkButton>
    <asp:LinkButton ID="LkbtnRecovery" runat="server">Lost your Password?</asp:LinkButton>
    <asp:Label ID="LblWarning" runat="server" Text=""></asp:Label>

</asp:Content>
