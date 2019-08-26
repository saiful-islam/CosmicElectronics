<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="IslamTraders_Accounts.Views.Transaction.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h3>Transaction Info:<asp:Label ID="lblTransId" runat="server" Text=""></asp:Label></h3>
    <table>
        <tr>
            <td>
                <br />
                Main Category*
            </td>
            <td>
                <br />
                <asp:DropDownList DataTextField="Name" DataValueField="Id" CssClass="form-control" ID="ddlCategory1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory1_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                Sub Category*
            </td>
            <td>
                <br />
                <asp:DropDownList DataTextField="Name" DataValueField="Id"  CssClass="form-control" ID="ddlCategory2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory2_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                Final Category*
            </td>
            <td>
                <br />
                <asp:DropDownList DataTextField="Name" DataValueField="Id" CssClass="form-control" ID="ddlCategory3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory3_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                Account*
            </td>
            <td>
                <br />
                <asp:DropDownList DataTextField="Name" DataValueField="Id" CssClass="form-control" ID="ddlAccount" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                Payment ID
            </td>
            <td>
                <br />
                <asp:TextBox CssClass="form-control" ID="txtPaymentId" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                Transaction Amount*&nbsp;&nbsp;
            </td>
            <td>
                <br />
                <asp:TextBox CssClass="form-control" ID="txtTransTotal" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                Comment
            </td>
            <td>
                <br />
                <asp:TextBox CssClass="form-control" ID="txtTransComment" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <br/>
                <asp:LinkButton CssClass="btn btn-default" ID="LinkButton1" runat="server" PostBackUrl="~/Views/Transaction/Index.aspx">Cancle</asp:LinkButton>
                <asp:Button CssClass="btn btn-primary" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
