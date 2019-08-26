<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DueCollection.aspx.cs" Inherits="IslamTraders_Accounts.Views.Report.DueCollection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Due Collection</h3>
    <asp:GridView ID="gvDueCollection" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" CssClass="table">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="OrderId" HeaderText="Order Id" />
            <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="Mobile" />
            <asp:BoundField DataField="DueTotal" HeaderText="Due" />
            <asp:BoundField DataField="DueDate" HeaderText="Due Date" />
        </Columns>

        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />

    </asp:GridView>
</asp:Content>
