<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmConfigUser.aspx.cs" Inherits="UserRegisterSystem.FrmConfigUser" %>

<!DOCTYPE html>
<!-- ConfigUser page from the frontend -->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Gloock&display=swap" rel="stylesheet">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <style>
        body{
            background: rgb(238,174,202);
            background: radial-gradient(circle, rgba(238,174,202,1) 0%, rgba(148,187,233,1) 100%);
            width:100%;
            height:100vh;
            font-family: 'Gloock', serif;
        }
        .container-sm{
            background: rgba( 255, 255, 255, 0.25 );
            box-shadow: 0 8px 32px 0 rgba( 31, 38, 135, 0.37 );
            backdrop-filter: blur( 4px );
            -webkit-backdrop-filter: blur( 4px );
            border-radius: 10px;
            border: 1px solid rgba( 255, 255, 255, 0.18 );
            padding:5%;
        }
        .imageprofile{
            height:10vh;
            width:auto;
        }
    </style>
</head>
<body class="d-flex justify-content-center align-items-center">
    <form id="form1" runat="server"  class="container-fluid">
        <div class="container-sm d-flex justify-content-center align-items-center flex-column">
            <div class=" d-flex flex-row-reverse justify-content-around align-items-center w-100">
                <h1>UserConfig</h1>
                <asp:Button ID="BtnGoToDashBoard" CssClass="btn btn-danger" OnClick="BtnGoToDashBoard_Click" runat="server" Text="GoToDashBoard" />
            </div>

                <div class="sub-container d-flex justify-content-center align-items-center flex-column margin w-100">
                    <asp:Label ID="LblEmail" CssClass="label-control w-50" runat="server" Text=" Your Email"></asp:Label>
                    <asp:TextBox ID="TxtEmail" CssClass="form-control w-50" runat="server"></asp:TextBox>

                    <asp:Label ID="LblUserName" CssClass="label-control w-50" runat="server" Text="Your UserName"></asp:Label>
                    <asp:TextBox ID="TxtUserName" CssClass="form-control w-50" runat="server"></asp:TextBox>

                    <asp:Label ID="LblPassword" CssClass="label-control w-50" runat="server" Text="Your Password"></asp:Label>
                    <asp:TextBox ID="TxtPassword" CssClass="form-control w-50" runat="server"></asp:TextBox>
                     <asp:Label ID="LblImage" CssClass="label-control w-50" runat="server" Text="Your Profile Image"></asp:Label>
                    <input type="file" id="TxtImage" class="form-control w-50" runat="server" />
                    <asp:Image ID="ImgProfile" CssClass="imageprofile margin" runat="server" />

                
                    <asp:Button ID="BtnSave" CssClass="btn btn-success margin" OnClick="BtnSave_Click" runat="server" Text="Save" />
                    <asp:Label ID="LblWarning"  runat="server" Text=""></asp:Label>
                </div>

           
        </div>
    </form>
    <script src="https://kit.fontawesome.com/65700b021d.js" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js" integrity="sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN" crossorigin="anonymous"></script>
</body>
</html>
