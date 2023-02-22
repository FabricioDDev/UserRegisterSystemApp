<%@ Page Title="" Language="C#" MasterPageFile="~/LogInUserMaster.Master" AutoEventWireup="true" CodeBehind="FrmLogIn.aspx.cs" Inherits="UserRegisterSystem.FrmLogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="LblUserName" runat="server" Text="Your Email or UserName"></asp:Label>
    <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox>

    <asp:Label ID="LblPass" runat="server" Text="Your Pass"></asp:Label>
    <asp:TextBox ID="TxtPass" runat="server"></asp:TextBox>

    <asp:Button ID="BtnGo" OnClick="BtnGo_Click" runat="server" Text="Go" />
    <asp:LinkButton ID="LkbtnSignIn" OnClick="LkbtnSignIn_Click" runat="server">Already have a account?</asp:LinkButton>
    <asp:LinkButton ID="LkbtnRecovery" runat="server">Lost your Password?</asp:LinkButton>
    <asp:Label ID="LblWarning" Visible="false" runat="server" Text=""></asp:Label>

</asp:Content>
