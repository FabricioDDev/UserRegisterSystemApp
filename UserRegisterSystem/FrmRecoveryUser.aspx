<%@ Page Title="" Language="C#" MasterPageFile="~/LogInUserMaster.Master" AutoEventWireup="true" CodeBehind="FrmRecoveryUser.aspx.cs" Inherits="UserRegisterSystem.FrmRecoveryUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--here we have the recovery user page from the frontend.
        here the user could recovery his password. we tried to create a dinamic page, so we use the same controlls for
        search the emailuser, write the code, and confirm the code. -->
    <style>
        *{
            margin:5px;
        }
        .form-label{
            font-size:1.3em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb-3 d-flex flex-column justify-content-center align-items-center">
        <asp:Label ID="LblForm" CssClass="form-label" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="TxtForm" CssClass="form-control" runat="server"></asp:TextBox>
        <div class="d-flex flex-row">
            <asp:Button ID="BtnConfirm" CssClass="btn btn-success" OnClick="BtnConfirm_Click" runat="server" Text="Confirm" />
            <asp:Button ID="BtnExit" CssClass="btn btn-primary" runat="server" Text="Exit"  OnClick="BtnExit_Click" />
        </div>    
    </div>
    
    <asp:Label ID="LblWarning" CssClass="alert alert-danger" runat="server" Text="" Visible="false"></asp:Label>
</asp:Content>


