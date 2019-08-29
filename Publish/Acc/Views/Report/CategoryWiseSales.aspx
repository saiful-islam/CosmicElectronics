<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryWiseSales.aspx.cs" Inherits="IslamTraders_Accounts.Views.Report.CategoryWiseSales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Category wise Sales</h3>
    <table>
        <tr>
            <td>
                From Date&nbsp;
            </td>
            <td>
                <asp:TextBox type="date" CssClass="form-control" ID="txtFromDate" runat="server"></asp:TextBox>                
            </td>
            <td>
                To Date&nbsp;
            </td>
            <td>
                <asp:TextBox type="date" CssClass="form-control" ID="txtToDate" runat="server"></asp:TextBox>                
            </td>
            <td>
                <asp:Button CssClass="btn btn-primary" ID="btnFilter" runat="server" Text="Apply" OnClick="btnFilter_Click" />
            </td>
        </tr>
    </table>
    <br/>
    <asp:GridView ID="gvCategoryWiseSale" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" CssClass="table">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="CategoryName" HeaderText="Category" />
            <asp:BoundField DataField="OrderTotal" HeaderText="Order Total" />
            <asp:BoundField DataField="CashReceived" HeaderText="Cash Received" />
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
