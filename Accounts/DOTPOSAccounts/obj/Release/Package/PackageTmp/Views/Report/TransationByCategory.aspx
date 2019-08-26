<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TransationByCategory.aspx.cs" Inherits="IslamTraders_Accounts.Views.Report.TransationByCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Transation by Category</h3>
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
    <asp:GridView ID="gvTransationByCategory" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" CssClass="table">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Category1" HeaderText="Main Category" />
            <asp:BoundField DataField="Category2" HeaderText="Sub Category" />
            <asp:BoundField DataField="Category3" HeaderText="Final Category" />
            <asp:BoundField DataField="Total" HeaderText="Total" />
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
