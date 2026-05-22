<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tasks.aspx.cs" Inherits="Informatique_task.Pages.Admin.Tasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="/Content/Tasks.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="page-title">Tasks</h2>

    <div class="tasks-page">

        <div class="filter-box">

            <div class="filter-group">
                <label class="form-label">Search</label>
                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-input"></asp:TextBox>
            </div>

            <div class="filter-group">
                <label class="form-label">Assigned To</label>
                <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-input"></asp:DropDownList>
            </div>

            <div class="filter-group">
                <label class="form-label">Status</label>
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-input"></asp:DropDownList>
            </div>

            <div class="filter-group filter-actions">
                <asp:Button ID="btnSearch" runat="server"
                    Text="Search"
                    CssClass="btn-primary"
                    OnClick="btnSearch_Click" />
            </div>

        </div>

        <asp:GridView ID="gvTasks"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="table">

            <Columns>

                <asp:BoundField DataField="Id" HeaderText="ID" />

                <asp:BoundField DataField="Title" HeaderText="Title" />

                <asp:BoundField DataField="AssignedToName"
                    HeaderText="Assigned To" />

                <asp:BoundField DataField="StatusText"
                    HeaderText="Status" />

                <asp:TemplateField HeaderText="Details">
                    <ItemTemplate>
                        <a href='TaskDetails.aspx?id=<%# Eval("Id") %>'>Details</a>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>

    </div>
</asp:Content>
