<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmDashBoard.aspx.cs" Inherits="UserRegisterSystem.FrmDashBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <!-- the dashboard Frontend, where we can SignOut, Go to the Config User, and have a welcome message with the UserName-->
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
        .img{
            border-radius:100%;
            height:5vh;
            width:auto;
        }
        .div{
             background: rgba( 255, 255, 255, 0.25 );
            box-shadow: 0 8px 32px 0 rgba( 31, 38, 135, 0.37 );
            backdrop-filter: blur( 4px );
            -webkit-backdrop-filter: blur( 4px );
            border-radius: 10px;
            border: 1px solid rgba( 255, 255, 255, 0.18 );
            padding:5%;
        }
        .nav{
             background: rgb(238,174,202);
            background: radial-gradient(circle, rgba(238,174,202,1) 0%, rgba(148,187,233,1) 100%);
            border-radius:10px;
        }
    </style>
</head>
<body class="d-flex justify-content-center align-items-center">
    <form id="form1" runat="server" class="container-fluid d-flex justify-content-center align-items-center">
        <div class="container d-flex justify-content-center align-items-center flex-column div">
                <div class="d-flex flex-row-reverse justify-content-around align-items-center w-100 nav">
                     <a href="FrmConfigUser.aspx" >
                        <asp:Image ID="ImgProfile" CssClass="img" ImageUrl="https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png" runat="server" />
                        <asp:Label ID="LblUserName" runat="server" Text=""></asp:Label>
                    </a>
                    <asp:Button ID="BtnSignOut" CssClass="btn btn-danger" OnClick="BtnSignOut_Click" runat="server" Text="SignOut" />
                </div>
                <div class="d-flex flex-column justify-content-center align-items-center">
                     <h1>DashBoard</h1>
                    <asp:Label ID="LblWelcome"  runat="server" Text=""></asp:Label>
                </div>
        </div>
    </form>
       <script src="https://kit.fontawesome.com/65700b021d.js" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js" integrity="sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN" crossorigin="anonymous"></script>
</body>
</html>
