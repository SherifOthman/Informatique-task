<%@ Page Title="My Tasks"
Language="C#"
MasterPageFile="~/Site.Master"
AutoEventWireup="true"
CodeBehind="MyTasks.aspx.cs"
Inherits="Informatique_task.Pages.Member.MyTasks" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="/Content/Tasks.css" />
    <style>
        .notif-box {
            background: #fff8e1;
            border: 1px solid #ffc107;
            border-radius: 8px;
            padding: 18px 22px;
            margin-bottom: 20px;
        }
        .notif-header {
            display: flex;
            align-items: center;
            gap: 8px;
            font-weight: 700;
            font-size: 16px;
            color: #8a6d00;
            margin-bottom: 10px;
        }
        .notif-header .icon {
            font-size: 20px;
        }
        .notif-list {
            list-style: none;
            padding: 0;
            margin: 0;
        }
        .notif-list li {
            padding: 6px 0 6px 24px;
            background: url('data:image/svg+xml;utf8,<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="%23e67e00"><path d="M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm1 15h-2v-2h2v2zm0-4h-2V7h2v6z"/></svg>') left center no-repeat;
            color: #6b5200;
            font-size: 14px;
            line-height: 1.5;
        }
        .notif-list li:not(:last-child) {
            border-bottom: 1px solid #ffe082;
        }
    </style>
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
