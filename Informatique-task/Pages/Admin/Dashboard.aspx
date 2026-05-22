<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs"
Inherits="Informatique_task.Pages.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Admin Dashboard</h2>

<div>
    <p>Welcome, <%= Session["FullName"] %></p>
    <p><asp:HyperLink NavigateUrl="~/Pages/Admin/Tasks.aspx" runat="server">View Tasks</asp:HyperLink></p>
</div>

</asp:Content>