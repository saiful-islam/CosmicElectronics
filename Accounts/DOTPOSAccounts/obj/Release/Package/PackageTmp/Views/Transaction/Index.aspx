<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IslamTraders_Accounts.Views.Transaction.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <asp:LinkButton CssClass="btn btn-primary" ID="LinkButton1" runat="server" PostBackUrl="~/Views/Transaction/Create.aspx">New Transaction</asp:LinkButton>
    <h1>All Transaction List</h1>
    <table>
        <tr>
            <td>
                Filter by Date&nbsp;
            </td>
            <td>
                <asp:TextBox type="Date" CssClass="form-control" ID="txtFilter" runat="server"></asp:TextBox>                
            </td>
            <td>
                <asp:Button CssClass="btn btn-primary" ID="btnFilter" runat="server" Text="Apply" OnClick="btnFilter_Click" />
            </td>
            <td>
                &nbsp;Filter by Account Name&nbsp;
            </td>
            <td>
                <asp:TextBox CssClass="form-control" ID="txtFilter2" runat="server"></asp:TextBox>                
            </td>
            <td>
                <asp:Button CssClass="btn btn-primary" ID="btnFilter2" runat="server" Text="Apply" OnClick="btnFilter2_Click" />
            </td>
        </tr>

    </table>
    <br/>
    <asp:GridView ID="gvTransactions" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" CssClass="table" OnRowDeleting="gvTransactions_RowDeleting" OnRowEditing="gvTransactions_RowEditing">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="TransId" HeaderText="TransId" />
            <asp:BoundField DataField="Category1" HeaderText="Main Category" />
            <asp:BoundField DataField="Category2" HeaderText="Sub Category" />
            <asp:BoundField DataField="Category3" HeaderText="Final Category" />
            <asp:BoundField DataField="Account" HeaderText="Account" />
            <asp:BoundField DataField="PaymentId" HeaderText="Payment Id" />
            <asp:BoundField DataField="TransTotal" HeaderText="TransTotal" />
            <asp:BoundField DataField="TransDateUTC" HeaderText="Date" />
            <asp:BoundField DataField="TransComment" HeaderText="Comment" />
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
