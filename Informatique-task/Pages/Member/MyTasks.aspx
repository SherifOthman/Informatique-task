<%@ Page Title="My Tasks"
Language="C#"
MasterPageFile="~/Site.Master"
AutoEventWireup="true"
CodeBehind="MyTasks.aspx.cs"
Inherits="Informatique_task.Pages.Member.MyTasks" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="/Content/Tasks.css" />
    <link rel="stylesheet" type="text/css" href="/Content/MyTasks.css" />
</asp:Content>

<asp:Content ID="Content1"
ContentPlaceHolderID="MainContent"
runat="server">

<h2 class="page-title">My Tasks</h2>

<!-- NOTIFICATIONS -->

<asp:Panel ID="pnlNotifications"
    runat="server"
    Visible="false"
    CssClass="notif-box">

    <div class="notif-header">
        <span class="icon">&#x26A0;</span>
        <span>Notifications</span>
    </div>

    <asp:BulletedList ID="blNotifications"
        runat="server"
        CssClass="notif-list">
    </asp:BulletedList>

</asp:Panel>

<!-- TASK TABLE -->

<asp:GridView ID="gvTasks"
    runat="server"
    AutoGenerateColumns="False"
    CssClass="table">

    <Columns>

        <asp:BoundField
            DataField="Id"
            HeaderText="ID" />

        <asp:BoundField
            DataField="Title"
            HeaderText="Title" />

        <asp:BoundField
            DataField="StatusText"
            HeaderText="Status" />

        <asp:BoundField
            DataField="AssignedDateText"
            HeaderText="Assigned Date" />

        <asp:HyperLinkField DataNavigateUrlFields="Id"
            DataNavigateUrlFormatString="MemberTaskDetails.aspx?id={0}"
            HeaderText="Details" Text="View" />

    </Columns>

</asp:GridView>

</asp:Content>
