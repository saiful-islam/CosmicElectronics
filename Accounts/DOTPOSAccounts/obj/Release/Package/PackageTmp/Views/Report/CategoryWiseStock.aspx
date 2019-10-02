﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryWiseStock.aspx.cs" Inherits="IslamTraders_Accounts.Views.Report.CategoryWiseStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Category wise Stock</h3>
    <table>
        <tr>
            <td>Company(Manufacturer) Name&nbsp;
            </td>
            <td>
                <asp:DropDownList DataTextField="Name" DataValueField="Id" CssClass="form-control" ID="ddlManufacturer" runat="server"></asp:DropDownList>
            </td>
            <td>&nbsp;&nbsp;&nbsp;
            </td>
            <td>Category Name&nbsp;
            </td>
            <td>
                <asp:DropDownList DataTextField="Name" DataValueField="Id" CssClass="form-control" ID="ddlCategory" runat="server"></asp:DropDownList>
            </td>
            <td>
                <asp:Button CssClass="btn btn-primary" ID="btnFilter" runat="server" Text="Apply" OnClick="btnFilter_Click" />
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="gvCategoryWiseStock" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" CssClass="table">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Manufacturer" HeaderText="Manufacturer" />
            <asp:BoundField DataField="Category" HeaderText="Category" />
            <asp:BoundField DataField="Sku" HeaderText="Sku" />
            <asp:BoundField DataField="Product" HeaderText="Product" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="Cost" HeaderText="Cost" />
            <asp:BoundField DataField="Total_Cost" HeaderText="Total Cost" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="Total_Price" HeaderText="Total Price" />
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
