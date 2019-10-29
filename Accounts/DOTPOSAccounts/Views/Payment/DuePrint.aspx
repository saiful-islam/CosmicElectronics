<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DuePrint.aspx.cs" Inherits="IslamTraders_Accounts.Views.Payment.DuePrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .container {
           text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--<asp:TextBox ID="txtCustomerId" runat="server"></asp:TextBox>--%>
            <%--<div class="container">--%>
            <div class="container">COSMIC ELECTRONICS & MOTORS
                <br />
                East side of Raipur sub-registry office mosque, Raipur, Laxmipur.
                <br />
                Mobile# 01714-407431, 01930-010034
                <br />
                Date: <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></div>
            <br />
            <br />
            <br />
            <h4>Customer Info</h4>
            <p>
                Code: <asp:Label ID="lblCode" runat="server" Text=""></asp:Label>
                <br />
                Name: <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                <br />
                Mobile: <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label>
                <br />
                Address: <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
            </p>
            <h4>
                Total: <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                <br />
                Paid: <asp:Label ID="lblPaid" runat="server" Text=""></asp:Label>
                <br />
                Due: <asp:Label ID="lblDue" runat="server" Text=""></asp:Label>
            </h4>

        </div>
    </form>
</body>
</html>
