<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Navigation.ascx.cs" Inherits="SachOnline.UC_Navigation" %>

<table cellspacing="1" width="100%">
    <tr>
        <td align="center" style="background-color: #4CAF50;" height="40px">
            <asp:HyperLink ID="HplTrangChu" runat="server" NavigateUrl="~/Default.aspx" 
                Font-Bold="True" Font-Underline="False" ForeColor="#3F1F79">Trang chủ</asp:HyperLink>
                &nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HplGioiThieu" runat="server">Giới thiệu</asp:HyperLink>
                &nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HplDangNhap" runat="server" NavigateUrl="~/Login.aspx" 
                Font-Bold="True" Font-Underline="False" ForeColor="#3F1F79">Đăng nhập</asp:HyperLink>
                &nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HplLienHe" runat="server">Liên hệ</asp:HyperLink>
        </td>
    </tr>
</table>