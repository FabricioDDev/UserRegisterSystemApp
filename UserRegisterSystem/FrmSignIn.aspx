<%@ Page Title="" Language="C#" MasterPageFile="~/LogInUserMaster.Master" AutoEventWireup="true" CodeBehind="FrmSignIn.aspx.cs" Inherits="UserRegisterSystem.FrmSignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-check-input{
            background-color:transparent;
        }
        .warning{
            color:red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="sub-container d-flex justify-content-center align-items-center flex-column" style="width:50%;">
        <h1>Lalala Company</h1>
        <div class="d-flex flex-row">
            <label style="color:#666666">lsdmfñldmfdlsñfmdsñlfmdsñlfmsd sdflm dsfm fdñodsñfñdlsñ skdnfñsdnf</label>
            <i class="fas fa-chevron-right" style="font-size:2em;"></i>
        </div>
        <asp:LinkButton ID="LkbtnLogIn" OnClick="LkbtnLogIn_Click" runat="server">have a account? click here</asp:LinkButton>
    </div>
    <div class="sub-container d-flex justify-content-center align-items-center flex-column" style="width:50%;">
        <h2>Create Account</h2>
        <div class="mb-3" style="width:50%;">
            <asp:Label ID="LblEmail" CssClass="form-label" runat="server" Text="Your Email*"></asp:Label>
            <asp:TextBox ID="TxtEmail" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3" style="width:50%;">
            <asp:Label ID="LblUserName" CssClass="form-label" runat="server" Text="Your UserName*"></asp:Label>
            <asp:TextBox ID="TxtUserName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3" style="width:50%;">
             <asp:Label ID="LblPassword" CssClass="form-label" runat="server" Text="YourPassword*"></asp:Label>
             <asp:TextBox ID="TxtPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
             <asp:Button ID="BtnViewPass" CssClass="btn btn-primary" OnClick="BtnViewPass_Click" runat="server" Text="ViewPass" />
        </div>
        <div class="mb-3" style="width:50%;">
            <asp:CheckBox ID="CkbRead" CssClass="form-check-input" Text="Are you Agree the Politics?" runat="server" />
        </div>
        <div class="mb-3" style="width:50%;">
            <asp:Button ID="BtnCreate" CssClass="btn btn-success" OnClick="BtnCreate_Click" runat="server" Text="Create Now" />
        </div>
        
        <asp:Label ID="LblWarning" CssClass="warning" runat="server" Text=""></asp:Label>
        
    </div>
</asp:Content>
