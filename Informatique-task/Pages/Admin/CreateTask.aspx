<%@ Page Title="Create Task" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="CreateTask.aspx.cs"
    Inherits="Informatique_task.Pages.Admin.CreateTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="/Content/CreateTask.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2 class="page-title">Create New Task</h2>

<asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>

<div class="create-task-form">
    <label class="form-label">Title</label>
    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-input"></asp:TextBox>

    <label class="form-label">Description</label>
    <asp:TextBox ID="txtDescription" runat="server"
        TextMode="MultiLine" Rows="4"
        CssClass="form-input"></asp:TextBox>

    <label class="form-label">Assign To</label>
    <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-input"></asp:DropDownList>

    <label class="form-label">Attachment</label>
    <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-input" />

    <asp:Button ID="btnCreate" runat="server"
        Text="Create Task"
        CssClass="btn-primary"
        OnClick="btnCreate_Click" />
</div>

</asp:Content>
