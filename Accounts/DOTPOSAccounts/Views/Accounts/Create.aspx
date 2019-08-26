<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="IslamTraders_Accounts.Views.Accounts.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Account Info:<asp:Label ID="lblAccountId" runat="server" Text=""></asp:Label></h3>
    <table>
        <tr>
            <td>
                <br />
                Account Name*
            </td>
            <td>
                <br />
                <asp:TextBox CssClass="form-control" ID="txtAccountName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                Mobile*
            </td>
            <td>
                <br />
                <asp:TextBox CssClass="form-control" ID="txtMobile" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                Address*
            </td>
            <td>
                <br />
                <asp:TextBox CssClass="form-control" ID="txtAddress" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                Description
            </td>
            <td>
                <br />
                <asp:TextBox CssClass="form-control" ID="txtDescription" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                Account Type*
            </td>
            <td>
                <br />
                <asp:DropDownList DataTextField="Name" DataValueField="Id" CssClass="form-control" ID="ddlAccountType" runat="server"></asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td></td>
            <td>
                <br/>
                <asp:LinkButton CssClass="btn btn-default" ID="LinkButton1" runat="server" PostBackUrl="~/Views/Accounts/Index.aspx">Cancle</asp:LinkButton>
                <asp:Button CssClass="btn btn-primary" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
