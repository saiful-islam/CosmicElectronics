<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryWiseTotalSell.aspx.cs" Inherits="IslamTraders_Accounts.Views.Report.CategoryWiseTotalSell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Category wise Today Sale</h3>

    <table>
        <tr>
            <td>Sale Date&nbsp;
            </td>
            <td>
                <asp:TextBox type="date" CssClass="form-control" ID="txtSaleDate" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button CssClass="btn btn-primary" ID="btnFilter" runat="server" Text="Apply" OnClick="btnFilter_Click" />
            </td>
        </tr>
    </table>
    <br />
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3>Category: Cookeries</h3>
            <table class="table table-striped">
                <tr>
                    <td>
                        <h3>Today Order:
                            <asp:Label ID="lblOrderCookeries" runat="server" Text="0"></asp:Label></h3>
                    </td>
                    <td>
                        <h3>Today Payment:
                            <asp:Label ID="lblPaymentCookeries" runat="server" Text="0"></asp:Label></h3>
                    </td>
                    <td>
                        <h3>Today Due:
                            <asp:Label ID="lblDueCookeries" runat="server" Text="0"></asp:Label></h3>
                    </td>
                </tr>
            </table>
        </div>
        <div class="panel-body">
            <asp:GridView ID="gvCookeries" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" CssClass="table">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="OrderId" HeaderText="Order Id" />
                    <asp:BoundField DataField="Customer" HeaderText="Customer" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                    <asp:BoundField DataField="TotalOrder" HeaderText="Total Order" />
                    <asp:BoundField DataField="TotalPayment" HeaderText="Payment" />
                    <asp:BoundField DataField="TotalDue" HeaderText="Due" />
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
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3>Category: Furniture</h3>
            <table class="table table-striped">
                <tr>
                    <td>
                        <h3>Today Order:
        <asp:Label ID="lblOrderFurniture" runat="server" Text="0"></asp:Label></h3>
                    </td>
                    <td>
                        <h3>Today Payment:
        <asp:Label ID="lblPaymentFurniture" runat="server" Text="0"></asp:Label></h3>
                    </td>
                    <td>
                        <h3>Today Due:
        <asp:Label ID="lblDueFurniture" runat="server" Text="0"></asp:Label></h3>
                    </td>
                </tr>
            </table>
        </div>
        <div class="panel-body">
            <asp:GridView ID="gvFurniture" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" CssClass="table">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="OrderId" HeaderText="Order Id" />
                    <asp:BoundField DataField="Customer" HeaderText="Customer" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                    <asp:BoundField DataField="TotalOrder" HeaderText="Total Order" />
                    <asp:BoundField DataField="TotalPayment" HeaderText="Payment" />
                    <asp:BoundField DataField="TotalDue" HeaderText="Due" />
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
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3>Category: Foam & Porda</h3>
            <table class="table table-striped">
                <tr>
                    <td>
                        <h3>Today Order:
        <asp:Label ID="lblOrderFoam_Porda" runat="server" Text="0"></asp:Label></h3>
                    </td>
                    <td>
                        <h3>Today Payment:
        <asp:Label ID="lblPaymentFoam_Porda" runat="server" Text="0"></asp:Label></h3>
                    </td>
                    <td>
                        <h3>Today Due:
        <asp:Label ID="lblDueFoam_Porda" runat="server" Text="0"></asp:Label></h3>
                    </td>
                </tr>
            </table>
        </div>
        <div class="panel-body">
            <asp:GridView ID="gvFoam_Porda" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" CssClass="table">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="OrderId" HeaderText="Order Id" />
                    <asp:BoundField DataField="Customer" HeaderText="Customer" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                    <asp:BoundField DataField="TotalOrder" HeaderText="Total Order" />
                    <asp:BoundField DataField="TotalPayment" HeaderText="Payment" />
                    <asp:BoundField DataField="TotalDue" HeaderText="Due" />
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
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3>Category: Electronics</h3>
            <table class="table table-striped">
                <tr>
                    <td>
                        <h3>Today Order:
        <asp:Label ID="lblOrderElectronics" runat="server" Text="0"></asp:Label></h3>
                    </td>
                    <td>
                        <h3>Today Payment:
        <asp:Label ID="lblPaymentElectronics" runat="server" Text="0"></asp:Label></h3>
                    </td>
                    <td>
                        <h3>Today Due:
        <asp:Label ID="lblDueElectronics" runat="server" Text="0"></asp:Label></h3>
                    </td>
                </tr>
            </table>
        </div>
        <div class="panel-body">
            <asp:GridView ID="gvElectronics" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" CssClass="table">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="OrderId" HeaderText="Order Id" />
                    <asp:BoundField DataField="Customer" HeaderText="Customer" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                    <asp:BoundField DataField="TotalOrder" HeaderText="Total Order" />
                    <asp:BoundField DataField="TotalPayment" HeaderText="Payment" />
                    <asp:BoundField DataField="TotalDue" HeaderText="Due" />
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
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3>Category: Doors</h3>
            <table class="table table-striped">
                <tr>
                    <td>
                        <h3>Today Order:
        <asp:Label ID="lblOrderDoors" runat="server" Text="0"></asp:Label></h3>
                    </td>
                    <td>
                        <h3>Today Payment:
        <asp:Label ID="lblPaymentDoors" runat="server" Text="0"></asp:Label></h3>
                    </td>
                    <td>
                        <h3>Today Due:
        <asp:Label ID="lblDueDoors" runat="server" Text="0"></asp:Label></h3>
                    </td>
                </tr>
            </table>
        </div>
        <div class="panel-body">
            <asp:GridView ID="gvDoors" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" CssClass="table">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="OrderId" HeaderText="Order Id" />
                    <asp:BoundField DataField="Customer" HeaderText="Customer" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                    <asp:BoundField DataField="TotalOrder" HeaderText="Total Order" />
                    <asp:BoundField DataField="TotalPayment" HeaderText="Payment" />
                    <asp:BoundField DataField="TotalDue" HeaderText="Due" />
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
        </div>

    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3>Category: LB Biniar/MDF Furniture</h3>
            <table class="table table-striped">
                <tr>
                    <td>
                        <h3>Today Order:
                        <asp:Label ID="lblOrderPartical" runat="server" Text="0"></asp:Label></h3>
                    </td>
                    <td>
                        <h3>Today Payment:
                        <asp:Label ID="lblPaymentPartical" runat="server" Text="0"></asp:Label></h3>
                    </td>
                    <td>
                        <h3>Today Due:
                        <asp:Label ID="lblDuePartical" runat="server" Text="0"></asp:Label></h3>
                    </td>
                </tr>
            </table>
        </div>
        <div class="panel-body">
            <asp:GridView ID="gvPartical" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" CssClass="table">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="OrderId" HeaderText="Order Id" />
                    <asp:BoundField DataField="Customer" HeaderText="Customer" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                    <asp:BoundField DataField="TotalOrder" HeaderText="Total Order" />
                    <asp:BoundField DataField="TotalPayment" HeaderText="Payment" />
                    <asp:BoundField DataField="TotalDue" HeaderText="Due" />
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
        </div>

    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3>Category: Shegun Wood Furniture</h3>
            <table class="table table-striped">
                <tr>
                    <td>
                        <h3>Today Order:
                        <asp:Label ID="lblOrderShegun" runat="server" Text="0"></asp:Label></h3>
                    </td>
                    <td>
                        <h3>Today Payment:
                        <asp:Label ID="lblPaymentShegun" runat="server" Text="0"></asp:Label></h3>
                    </td>
                    <td>
                        <h3>Today Due:
                        <asp:Label ID="lblDueShegun" runat="server" Text="0"></asp:Label></h3>
                    </td>
                </tr>
            </table>
        </div>
        <div class="panel-body">
            <asp:GridView ID="gvShegun" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" CssClass="table">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="OrderId" HeaderText="Order Id" />
                    <asp:BoundField DataField="Customer" HeaderText="Customer" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                    <asp:BoundField DataField="TotalOrder" HeaderText="Total Order" />
                    <asp:BoundField DataField="TotalPayment" HeaderText="Payment" />
                    <asp:BoundField DataField="TotalDue" HeaderText="Due" />
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
        </div>
    </div>
</asp:Content>
