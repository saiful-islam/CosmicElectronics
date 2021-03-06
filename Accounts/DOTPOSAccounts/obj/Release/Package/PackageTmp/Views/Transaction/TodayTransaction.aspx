﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodayTransaction.aspx.cs" Inherits="IslamTraders_Accounts.Views.Transaction.TodayTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Today Cost: <asp:Label ID="lblTodayCost" runat="server" Text=""></asp:Label></h3>
    <h3>Today Cash In: <asp:Label ID="lblTodayCashIn" runat="server" Text=""></asp:Label></h3>
    <br/>
    <asp:GridView ID="gvTransactions" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" CssClass="table">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="TransId" HeaderText="TransId" />
            <asp:BoundField DataField="Category1" HeaderText="Main Category" />
            <asp:BoundField DataField="Category2" HeaderText="Sub Category" />
            <asp:BoundField DataField="Category3" HeaderText="Final Category" />
            <asp:BoundField DataField="Account" HeaderText="Account" />
            <asp:BoundField DataField="TransTotal" HeaderText="TransTotal" />
            <asp:BoundField DataField="TransDateUTC" HeaderText="Date" />
            <asp:BoundField DataField="TransComment" HeaderText="Comment" />
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
