<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmErrorPage.aspx.cs" Inherits="UserRegisterSystem.FrmErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Oh No! some is Wrong...</h1>
            <asp:LinkButton ID="LkbLogIn" OnClick="LkbLogIn_Click" runat="server">Go to the LogIn Page</asp:LinkButton>
        </div>
    </form>
</body>
</html>
