<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Informatique_task.Pages.Auth.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="~/Content/Site.css" />
</head>
<body>

<form id="form1" runat="server">

<div class="login-box">
    <h2>Login</h2>

    <asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label>

    <label>Username</label>
    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>

    <label>Password</label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>

    <asp:Button ID="btnLogin" runat="server"
        Text="Login"
        CssClass="btn-login"
        OnClick="btnLogin_Click" />

    <asp:Button ID="btnAdminFill" runat="server"
        Text="Admin"
        CssClass="btn-fill"
        OnClientClick="document.getElementById('txtUsername').value='admin';document.getElementById('txtPassword').value='Admin@123';return false;" />

    <asp:Button ID="btnMemberFill" runat="server"
        Text="Member"
        CssClass="btn-fill"
        OnClientClick="document.getElementById('txtUsername').value='ahmed';document.getElementById('txtPassword').value='123456';return false;" />
</div>

</form>

</body>
</html>
