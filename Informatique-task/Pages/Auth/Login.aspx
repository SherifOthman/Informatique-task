<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Informatique_task.Pages.Auth.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="~/Content/Global.css" />
    <link rel="stylesheet" type="text/css" href="~/Content/Login.css" />
</head>
<body class="login-page">

<form id="form1" runat="server">

<div class="login-box">
    <h2>Login</h2>

    <asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label>

    <label class="form-label">Username</label>
    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-input"></asp:TextBox>

    <label class="form-label">Password</label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-input"></asp:TextBox>

    <asp:Button ID="btnLogin" runat="server"
        Text="Login"
        CssClass="btn-primary"
        OnClick="btnLogin_Click" />

    <asp:Button ID="btnAdminFill" runat="server"
        Text="Admin"
        CssClass="btn-secondary"
        OnClick="btnAdminFill_Click" />

    <asp:Button ID="btnMemberFill" runat="server"
        Text="Member"
        CssClass="btn-secondary"
        OnClick="btnMemberFill_Click" />
</div>

</form>

</body>
</html>
