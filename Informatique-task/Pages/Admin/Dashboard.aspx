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
        <div class="stat-number"><%= newCount %></div>
        <div class="stat-label">New</div>
    </div>
    <div class="stat-card stat-progress">
        <div class="stat-number"><%= inProgressCount %></div>
        <div class="stat-label">In Progress</div>
    </div>
    <div class="stat-card stat-completed">
        <div class="stat-number"><%= completedCount %></div>
        <div class="stat-label">Completed</div>
    </div>
    <div class="stat-card stat-total">
        <div class="stat-number"><%= totalCount %></div>
        <div class="stat-label">Total Tasks</div>
    </div>
</div>

<div class="quick-actions">
    <h3>Quick Actions</h3>
    <div class="actions-row">
        <a href="<%= ResolveUrl("~/Pages/Admin/CreateTask.aspx") %>" class="action-btn action-create">+ Create Task</a>
        <a href="<%= ResolveUrl("~/Pages/Admin/Tasks.aspx") %>" class="action-btn action-view">View All Tasks</a>
    </div>
</div>

</asp:Content>
