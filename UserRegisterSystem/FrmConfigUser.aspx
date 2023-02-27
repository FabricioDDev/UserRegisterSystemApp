<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmConfigUser.aspx.cs" Inherits="UserRegisterSystem.FrmConfigUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LblEmail" runat="server" Text=" Your Email"></asp:Label>
            <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>

            <asp:Label ID="LblUserName" runat="server" Text="Your UserName"></asp:Label>
            <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox>

            <asp:Label ID="LblPassword" runat="server" Text="Your Password"></asp:Label>
            <asp:TextBox ID="TxtPassword" runat="server"></asp:TextBox>

            <asp:Label ID="LblImage" runat="server" Text="Your Profile Image"></asp:Label>
            <input type="file" id="TxtImage" runat="server" />
            <asp:Image ID="ImgProfile" runat="server" />

            <asp:Button ID="BtnGoToDashBoard" runat="server" Text="GoToDashBoard" />
            <asp:Button ID="BtnSave" OnClick="BtnSave_Click" runat="server" Text="Save" />
            <asp:Label ID="LblWarning" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
