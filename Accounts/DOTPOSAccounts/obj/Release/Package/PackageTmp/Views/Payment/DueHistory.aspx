<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DueHistory.aspx.cs" Inherits="IslamTraders_Accounts.Views.Payment.DueHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <asp:LinkButton CssClass="btn btn-primary" ID="LinkButton1" runat="server" PostBackUrl="~/Views/Payment/Create.aspx">New Due</asp:LinkButton>
    <h1>All Due History</h1>
    <table>
        <tr>
            <td>
                Filter by Account Name&nbsp;&nbsp;
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
    <asp:GridView ID="gvDueList" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" CssClass="table" OnRowDeleting="gvDueList_RowDeleting" OnRowEditing="gvDueList_RowEditing">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="PaymentId" HeaderText="PaymentId" />
            <asp:BoundField DataField="Account" HeaderText="Account" />
            <asp:BoundField DataField="AccountType" HeaderText="Account Type" />
            <asp:BoundField DataField="Payment" HeaderText="Payment" />
            <asp:BoundField DataField="PaymentDate" HeaderText="Date" />
            <asp:BoundField DataField="Comment" HeaderText="Comment" />
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
