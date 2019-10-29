<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DealerDue.aspx.cs" Inherits="IslamTraders_Accounts.Views.Payment.DealerDue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1>Dealer total Due</h1>
    <table>
        <tr>
            <td>Filter by Account Name&nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox CssClass="form-control" ID="txtFilter" runat="server"></asp:TextBox>
            </td>
            <%--    <td>
                <asp:DropDownList DataTextField="Name" DataValueField="Id" CssClass="form-control" ID="ddlAccountType" runat="server"></asp:DropDownList>
            </td>--%>
            <td>
                <asp:Button CssClass="btn btn-primary" ID="btnFilter" runat="server" Text="Apply" OnClick="btnFilter_Click" />
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="gvPaymentList" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" CssClass="table">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Code" HeaderText="Code" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
            <asp:BoundField DataField="OrderTotal" HeaderText="Order Total" />
            <asp:BoundField DataField="Paid" HeaderText="Total Paid" />
            <asp:BoundField DataField="DUE" HeaderText="Due" />
            <asp:HyperLinkField Text="Print" DataNavigateUrlFields="Code" DataNavigateUrlFormatString="DuePrint.aspx?id={0}" Target="_blank"></asp:HyperLinkField>
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
