<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryWiseDue.aspx.cs" Inherits="IslamTraders_Accounts.Views.Report.CategoryWiseDue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Category Wise Due</h3>
    <asp:GridView ID="gvCategoryWiseDue" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" CssClass="table">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
            <asp:BoundField DataField="TotalDue" HeaderText="TotalDue" />
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
