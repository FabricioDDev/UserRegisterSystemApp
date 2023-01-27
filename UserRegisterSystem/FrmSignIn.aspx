<%@ Page Title="" Language="C#" MasterPageFile="~/LogInUserMaster.Master" AutoEventWireup="true" CodeBehind="FrmSignIn.aspx.cs" Inherits="UserRegisterSystem.FrmSignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="LblEmail" runat="server" Text="Your Email"></asp:Label>
    <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>

    <asp:Label ID="LblUserName" runat="server" Text="Your UserName"></asp:Label>
    <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox>

    <asp:Label ID="LblPassword" runat="server" Text="YourPassword"></asp:Label>
    <asp:TextBox ID="TxtPassword" TextMode="Password" runat="server"></asp:TextBox>
    <asp:Button ID="BtnViewPass" runat="server" Text="ViewPass" />

    <asp:CheckBox ID="CkbRead" Text="Are you Agree the Politics?" runat="server" />
    <asp:Button ID="BtnCreate" runat="server" Text="Create Now" />

    <asp:Label ID="LblWarning" runat="server" Text=""></asp:Label>
</asp:Content>
