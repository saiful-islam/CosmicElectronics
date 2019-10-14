<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="IslamTraders_Accounts.Views.Payment.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Due Info:<asp:Label ID="lblPaymentId" runat="server" Text=""></asp:Label></h3>
    <table>
        <tr>
            <td>
                <br />
                Account Type*
            </td>
            <td>
                <br />
                <asp:DropDownList DataTextField="Name" DataValueField="Id" CssClass="form-control" ID="ddlPaymentType" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                Account Type*
            </td>
            <td>
                <br />
                <asp:DropDownList AutoPostBack="True" DataTextField="Name" DataValueField="Id" CssClass="form-control" ID="ddlAccountType" runat="server" OnSelectedIndexChanged="ddlAccountType_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                Account Name*
            </td>
            <td>
                <br />
                <asp:DropDownList DataTextField="Name" DataValueField="Id" CssClass="form-control" ID="ddlAccount" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                Payment*
            </td>
            <td>
                <br />
                <asp:TextBox CssClass="form-control" ID="txtPayment" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                Comment*
            </td>
            <td>
                <br />
                <asp:TextBox CssClass="form-control" ID="txtComment" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td></td>
            <td>
                <br/>
                <asp:LinkButton CssClass="btn btn-default" ID="LinkButton1" runat="server" PostBackUrl="~/Views/Payment/Payment.aspx">Cancle</asp:LinkButton>
                <asp:Button CssClass="btn btn-primary" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
