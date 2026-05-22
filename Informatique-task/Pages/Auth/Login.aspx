<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Informatique_task.Pages.Auth.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light d-flex align-items-center justify-content-center" style="min-height:100vh;">

<form id="form1" runat="server">

<div class="container" style="max-width:400px;">

    <div class="card shadow p-4">

        <h3 class="text-center mb-3">Login</h3>

        <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>

        <div class="mb-3">
            <label>Username</label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label>Password</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>

        <asp:Button ID="btnLogin" runat="server"
            Text="Login"
            CssClass="btn btn-primary w-100 mb-3"
            OnClick="btnLogin_Click" />

        <div class="d-grid gap-2">
            <asp:Button ID="btnAdminFill" runat="server"
                Text="Admin"
                CssClass="btn btn-outline-secondary btn-sm"
                OnClientClick="document.getElementById('txtUsername').value='admin';document.getElementById('txtPassword').value='Admin@123';return false;" />

            <asp:Button ID="btnMemberFill" runat="server"
                Text="Member"
                CssClass="btn btn-outline-secondary btn-sm"
                OnClientClick="document.getElementById('txtUsername').value='ahmed';document.getElementById('txtPassword').value='123456';return false;" />
        </div>

    </div>

</div>

</form>

</body>
</html>
