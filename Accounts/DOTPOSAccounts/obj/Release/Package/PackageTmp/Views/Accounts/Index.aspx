<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IslamTraders_Accounts.Views.Accounts.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <asp:LinkButton CssClass="btn btn-primary" ID="LinkButton1" runat="server" PostBackUrl="~/Views/Accounts/Create.aspx">New Account</asp:LinkButton>
    <h1>All Account List</h1>
    <table>
        <tr>
            <td>
                Filter by Name
            </td>
            <td>
                <asp:TextBox CssClass="form-control" ID="txtFilter" runat="server"></asp:TextBox>                
            </td>
            <td>
                <asp:Button CssClass="btn btn-primary" ID="btnFilter" runat="server" Text="Apply" OnClick="btnFilter_Click" />
            </td>
        </tr>
    </table>
    <br/>
    <asp:GridView ID="gvAccounts" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" CssClass="table" OnRowDeleting="gvAccounts_RowDeleting" OnRowEditing="gvAccounts_RowEditing">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Account Id" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="AccountType" HeaderText="Account Type" />
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
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
