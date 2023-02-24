<%@ Page Title="" Language="C#" MasterPageFile="~/LogInUserMaster.Master" AutoEventWireup="true" CodeBehind="FrmLogIn.aspx.cs" Inherits="UserRegisterSystem.FrmLogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="sub-container d-flex justify-content-center align-items-center flex-column" style="width:50%;">
        <h1>Hello!</h1>
        <div class="d-flex flex-row">
            <label style="color:#666666; padding-right:10px;">We are really happy to see you again!</label>
            <i class="fas fa-chevron-right" style="font-size:2em;"></i>
        </div>
        <label style="color:#666666">you dont have account?</label>
        <asp:LinkButton ID="LkbtnSignIn" OnClick="LkbtnSignIn_Click" runat="server">Click here!</asp:LinkButton>
    </div>
    <div class="sub-container d-flex justify-content-center align-items-center flex-column" style="width:50%;">
        
        <asp:Label ID="LblWarning" CssClass="alert alert-danger" Visible="false" runat="server" Text=""></asp:Label>
        
        <h2>Log In</h2>
        <div class="mb-3" style="width:50%;">
            <asp:Label ID="LblUserName" CssClass="form-label" runat="server" Text="Your UserName"></asp:Label>
            <asp:TextBox ID="TxtUserName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3" style="width:50%;">
            <asp:Label ID="LblPass" CssClass="form-label" runat="server" Text="Your Pass"></asp:Label>
            <asp:TextBox ID="TxtPass" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3 d-flex justify-content-center" style="width:50%;">
            <asp:Button ID="BtnGo" CssClass="btn btn-primary btn-lg" OnClick="BtnGo_Click" runat="server" Text="Go" />
        </div>
        <div class="mb-3 d-flex justify-content-center" style="width:50%;">
            <asp:LinkButton ID="LkbtnRecovery" OnClick="LkbtnRecovery_Click"  runat="server">Did you lose your Password?</asp:LinkButton>
        </div>
        
        
    </div>
    
    

</asp:Content>
