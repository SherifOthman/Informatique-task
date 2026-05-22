<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs"
    Inherits="Informatique_task.Pages.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="/Content/Dashboard.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2 class="page-title">Dashboard</h2>

<div class="stats-row">
    <div class="stat-card stat-new">
        <div class="stat-number"><asp:Label ID="lblNewCount" runat="server" /></div>
        <div class="stat-label">New</div>
    </div>
    <div class="stat-card stat-progress">
        <div class="stat-number"><asp:Label ID="lblInProgressCount" runat="server" /></div>
        <div class="stat-label">In Progress</div>
    </div>
    <div class="stat-card stat-completed">
        <div class="stat-number"><asp:Label ID="lblCompletedCount" runat="server" /></div>
        <div class="stat-label">Completed</div>
    </div>
    <div class="stat-card stat-total">
        <div class="stat-number"><asp:Label ID="lblTotalCount" runat="server" /></div>
        <div class="stat-label">Total Tasks</div>
    </div>
</div>

<div class="quick-actions">
    <h3>Quick Actions</h3>
    <div class="actions-row">
        <asp:HyperLink NavigateUrl="~/Pages/Admin/CreateTask.aspx" runat="server" CssClass="action-btn action-create">+ Create Task</asp:HyperLink>
        <asp:HyperLink NavigateUrl="~/Pages/Admin/Tasks.aspx" runat="server" CssClass="action-btn action-view">View All Tasks</asp:HyperLink>
    </div>
</div>

</asp:Content>
