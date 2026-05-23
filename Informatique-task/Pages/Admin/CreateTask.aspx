<%@ Page Title="Create Task" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="CreateTask.aspx.cs"
    Inherits="Informatique_task.Pages.Admin.CreateTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="/Content/CreateTask.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2 class="page-title">Create New Task</h2>

<div style="text-align:center;">
    <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>
</div>

<div class="create-task-form">

    <div class="field-group">
        <label class="form-label">Title</label>
        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-input"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvTitle" runat="server"
            ControlToValidate="txtTitle"
            ErrorMessage="Title is required."
            CssClass="error" ValidationGroup="Create"
            Display="Dynamic" />
    </div>

    <div class="field-group">
        <label class="form-label">Description</label>
        <asp:TextBox ID="txtDescription" runat="server"
            TextMode="MultiLine" Rows="4"
            CssClass="form-input"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvDescription" runat="server"
            ControlToValidate="txtDescription"
            ErrorMessage="Description is required."
            CssClass="error" ValidationGroup="Create"
            Display="Dynamic" />
    </div>

    <div class="field-group">
        <label class="form-label">Assign To</label>
        <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-input"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvAssignTo" runat="server"
            ControlToValidate="ddlUsers"
            InitialValue="-- Select User --"
            ErrorMessage="Please select a user."
            CssClass="error" ValidationGroup="Create"
            Display="Dynamic" />
    </div>

    <div class="field-group">
        <label class="form-label">Attachment</label>
        <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-input" />
    </div>

    <div class="actions-row">
        <asp:HyperLink NavigateUrl="~/Pages/Admin/Tasks.aspx"
            runat="server" CssClass="btn-back">Back to Tasks</asp:HyperLink>
        <asp:Button ID="btnCreate" runat="server"
            Text="Create Task"
            CssClass="btn-primary"
            ValidationGroup="Create"
            OnClick="btnCreate_Click" />
    </div>
</div>

</asp:Content>
