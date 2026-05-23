<%@ Page Title="Task Details"
Language="C#"
MasterPageFile="~/Site.Master"
AutoEventWireup="true"
CodeBehind="MemberTaskDetails.aspx.cs"
Inherits="Informatique_task.Pages.Member.MemberTaskDetails" %>

<asp:Content ID="Content1"
ContentPlaceHolderID="MainContent"
runat="server">

<h2 class="page-title">Task Details</h2>

<div class="card">

    <asp:Label ID="lblMessage"
        runat="server"
        CssClass="error">
    </asp:Label>

    <!-- TITLE -->

    <label class="form-label">Title</label>

    <asp:TextBox ID="txtTitle"
        runat="server"
        CssClass="form-input"
        Enabled="false">
    </asp:TextBox>

    <!-- DESCRIPTION -->

    <label class="form-label">Description</label>

    <asp:TextBox ID="txtDescription"
        runat="server"
        TextMode="MultiLine"
        Rows="5"
        CssClass="form-input"
        Enabled="false">
    </asp:TextBox>

    <!-- STATUS -->

    <label class="form-label">Status</label>

    <asp:DropDownList ID="ddlStatus"
        runat="server"
        CssClass="form-input">
    </asp:DropDownList>

    <!-- ATTACHMENT -->

    <label class="form-label">Attachment</label>

    <asp:HyperLink ID="lnkAttachment"
        runat="server"
        Target="_blank">

        View Attachment

    </asp:HyperLink>

    <br /><br />

    <div class="actions-row">
        <asp:HyperLink NavigateUrl="~/Pages/Member/MyTasks.aspx"
            runat="server" CssClass="btn-back">Back to My Tasks</asp:HyperLink>
        <asp:Button ID="btnSave"
            runat="server"
            Text="Update Status"
            CssClass="btn-primary"
            OnClick="btnSave_Click" />
    </div>

</div>

</asp:Content>
