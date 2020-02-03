<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Admin.Master" AutoEventWireup="true" CodeBehind="DefaultAdmin.aspx.cs" Inherits="SachOnline.DefaultAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="1" width="100%">
        <tr>
            <td align="center" height="90px" style="background-color: #666699;">
                <asp:Label runat="server" ID="LblWelcome" Font-Bold="True" ForeColor="White" />
            </td>
        </tr>
    </table>
</asp:Content>