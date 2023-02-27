﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmDashBoard.aspx.cs" Inherits="UserRegisterSystem.FrmDashBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="FrmConfigUser.aspx">
                <asp:Image ID="ImgProfile" ImageUrl="https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png" runat="server" />
                <asp:Label ID="LblUserName" runat="server" Text=""></asp:Label>
            </a>
            
            <h1>DashBoard</h1>
            <asp:Label ID="LblWelcome"  runat="server" Text=""></asp:Label>
            <asp:Button ID="BtnSignOut" OnClick="BtnSignOut_Click" runat="server" Text="SignOut" />
        </div>
    </form>
</body>
</html>
