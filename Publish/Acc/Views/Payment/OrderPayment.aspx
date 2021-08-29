<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderPayment.aspx.cs" Inherits="IslamTraders_Accounts.Views.Payment.OrderPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <br />
            <br />
            <h4>Customer Info</h4>
            <p>
                Code:
                <asp:Label ID="lblCode" runat="server" Text=""></asp:Label>
                <br />
                Name:
                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                <br />
                Mobile:
                <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label>
                <br />
                Address:
                <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
            </p>
            <h4>Order ID:
                <asp:Label ID="lblOrderId" runat="server" Text="Order ID"></asp:Label>
                <br />
                Total:
                <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                <br />
                Paid:
                <asp:Label ID="lblPaid" runat="server" Text=""></asp:Label>
                <br />
                Due:
                <asp:Label ID="lblDue" runat="server" Text=""></asp:Label>
            </h4>
            <asp:GridView ID="gvPayment" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="PaidDate" HeaderText="Payment Date" />
                    <asp:BoundField DataField="PaidToday" HeaderText="Payment Amount" />
                </Columns>
            </asp:GridView>

            <table>
                <tr>
                    <td>
                        <h3>Payment: &nbsp;&nbsp;  </h3>
                    </td>
                    <td>
                        <h3>
                            <asp:TextBox ID="txtPayment" runat="server"></asp:TextBox> </h3>
                    </td>
                    <td>
                       
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                    <td>

                    </td>
                     <td>
                        <asp:Button ID="btnPayment" runat="server" Text="Payment" OnClick="btnPayment_Click" />
                    </td>
                </tr>
            </table>
            
        </div>

</asp:Content>
