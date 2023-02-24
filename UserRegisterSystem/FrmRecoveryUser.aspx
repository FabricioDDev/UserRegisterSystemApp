<%@ Page Title="" Language="C#" MasterPageFile="~/LogInUserMaster.Master" AutoEventWireup="true" CodeBehind="FrmRecoveryUser.aspx.cs" Inherits="UserRegisterSystem.FrmRecoveryUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LblForm" runat="server" Text=""></asp:Label>
    <asp:TextBox ID="TxtForm" runat="server"></asp:TextBox>
    <asp:Button ID="BtnConfirm" OnClick="BtnConfirm_Click" runat="server" Text="Confirm" />
    <asp:Button ID="BtnExit" runat="server" Text="Exit"  OnClick="BtnExit_Click" />
    <asp:Label ID="LblWarning" runat="server" Text="" Visible="false"></asp:Label>
</asp:Content>


