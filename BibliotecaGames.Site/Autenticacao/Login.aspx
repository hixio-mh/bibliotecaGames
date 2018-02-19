<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BibliotecaGames.Site.Autenticacao.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signin Games</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="signin.css" rel="stylesheet" />
</head>
<body class="text-center">
    <form id="form1" runat="server" class="form-signin">
        <img class="mb-4" src="https://getbootstrap.com/assets/brand/bootstrap-solid.svg" alt="" width="72" height="72">
        <div >
            <h1 class="h3 mb-3 font-weight-normal">Welcome to Game</h1>
            <div>
            <label for="LblStatus" class="form-control">Please sign in</label>
            </div>
            <label for="TxtUsuario" class="sr-only">Email address</label>
            <div><asp:TextBox ID="TxtUsuario" runat="server" class="form-control" placeholder="Your Name"></asp:TextBox></div>
            <label for="TxtSenha" class="sr-only">Password</label>
            <div><asp:TextBox ID="TxtSenha" runat="server" TextMode="Password" class="form-control" placeholder="Password"></asp:TextBox></div>
            <asp:Button class="btn btn-lg btn-primary btn-block" type="submit" ID="btnLogin" Text="Signin" runat="server" OnClick="btnLogin_Click"/>
            <br />
            <asp:Label runat="server" ID="LblStatus"></asp:Label>
        </div>
    </form>
</body>
</html>
