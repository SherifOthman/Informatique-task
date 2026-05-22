<%@ Page Title="Task Details" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="TaskDetails.aspx.cs"
    Inherits="Informatique_task.Pages.Admin.TaskDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="/Content/CreateTask.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2 class="page-title">Task Details</h2>

<asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>

<asp:Panel ID="pnlDetails" runat="server" CssClass="create-task-form">

    <label class="form-label">Title</label>
    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-input"></asp:TextBox>

    <label class="form-label">Description</label>
    <asp:TextBox ID="txtDescription" runat="server"
        TextMode="MultiLine" Rows="4"
        CssClass="form-input"></asp:TextBox>

    <label class="form-label">Assigned To</label>
    <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-input"></asp:DropDownList>

    <label class="form-label">Status</label>
    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-input">
        <asp:ListItem Value="New">New</asp:ListItem>
        <asp:ListItem Value="InProgress">In Progress</asp:ListItem>
        <asp:ListItem Value="Completed">Completed</asp:ListItem>
    </asp:DropDownList>

    <div style="margin-bottom:16px;">
        <span class="form-label" style="display:inline;">Attachment: </span>
        <asp:HyperLink ID="lnkAttachment" runat="server" Text="Download" />
        <asp:Label ID="lblNoAttachment" runat="server" Text="None" />
    </div>

    <div style="margin-bottom:16px;color:#777;font-size:13px;">
        Created: <asp:Label ID="lblCreatedDate" runat="server" /><br />
        Assigned: <asp:Label ID="lblAssignedDate" runat="server" />
    </div>

    <div style="display:flex;gap:12px;">
        <asp:HyperLink NavigateUrl="~/Pages/Admin/Tasks.aspx"
            runat="server" CssClass="btn-secondary"
            style="flex:1;text-align:center;text-decoration:none;margin:0;">Back to Tasks</asp:HyperLink>
        <asp:Button ID="btnSave" runat="server"
            Text="Save Changes"
            CssClass="btn-primary"
            OnClick="btnSave_Click"
            style="flex:1;" />
    </div>

</asp:Panel>

</asp:Content>
