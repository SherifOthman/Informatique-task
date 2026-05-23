<%@ Page Title="Task Details" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="TaskDetails.aspx.cs"
    Inherits="Informatique_task.Pages.Admin.TaskDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="/Content/CreateTask.css" />
    <link rel="stylesheet" type="text/css" href="/Content/TaskDetails.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2 class="page-title">Task Details</h2>

<asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>

<asp:Panel ID="pnlDetails" runat="server" CssClass="create-task-form">

    <div class="field-group">
        <label class="form-label">Title</label>
        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-input"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvTitle" runat="server"
            ControlToValidate="txtTitle"
            ErrorMessage="Title is required."
            CssClass="error" ValidationGroup="Save"
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
            CssClass="error" ValidationGroup="Save"
            Display="Dynamic" />
    </div>

    <div class="field-group">
        <label class="form-label">Assigned To</label>
        <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-input"></asp:DropDownList>
    </div>

    <div class="field-group">
        <label class="form-label">Status</label>
        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-input">
            <asp:ListItem Value="New">New</asp:ListItem>
            <asp:ListItem Value="InProgress">In Progress</asp:ListItem>
            <asp:ListItem Value="Completed">Completed</asp:ListItem>
        </asp:DropDownList>
    </div>

    <div class="attachment-row">
        <span class="form-label">Attachment: </span>
        <asp:HyperLink ID="lnkAttachment" runat="server" Text="Download" Target="_blank" />
        <asp:Label ID="lblNoAttachment" runat="server" Text="None" />
    </div>

    <div class="dates-row">
        Created: <asp:Label ID="lblCreatedDate" runat="server" /><br />
        Assigned: <asp:Label ID="lblAssignedDate" runat="server" />
    </div>

    <div class="actions-row">
        <asp:HyperLink NavigateUrl="~/Pages/Admin/Tasks.aspx"
            runat="server" CssClass="btn-back">Back to Tasks</asp:HyperLink>
        <asp:Button ID="btnSave" runat="server"
            Text="Save Changes"
            CssClass="btn-primary"
            OnClick="btnSave_Click"
            ValidationGroup="Save" />
    </div>

</asp:Panel>

</asp:Content>
