<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SachOnline.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FrmLogin" runat="server">
    <div>
        <table cellspacing="3" style="padding-right: 400px; padding-left: 400px" width="100%">
            <tr>
                <td align="center" height="32px" colspan="2" 
                    style="background-color: #9C2FAF; font-weight: bold;">ĐĂNG NHẬP TRANG QUẢN TRỊ&nbsp;
                </td>
            </tr>
            <tr>
                <td height="24px" colspan="2" style="background-color: #77AB3B">
                    <strong>Vui lòng nhập tên tài khoản và mật khẩu bên dưới!</strong>
                </td>
            </tr>
            <tr>
                <td style="background-color: #77AB3B">Tên đăng nhập:</td>
                <td style="background-color: #77AB3B">
                    <asp:TextBox ID="TxtTenDangNhap" runat="server" Width="230px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RfTenDangNhap" runat="server" 
                        ControlToValidate="TxtTenDangNhap" ErrorMessage="Chưa nhập tên đăng nhập!">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="background-color: #77AB3B">Mật khẩu:</td>
                <td style="background-color: #77AB3B">
                    <asp:TextBox ID="TxtMatKhau" runat="server" Width="230px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RfMatKhau" runat="server" 
                        ControlToValidate="TxtMatKhau" ErrorMessage="Chưa nhập mật khẩu!">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="background-color: #77AB3B">&nbsp;</td>
                <td style="background-color: #77AB3B">
                    <asp:Button ID="BtnDangNhap" runat="server" onclick="BtnDangNhap_Click" Text="Đăng nhập" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" style="background-color: #77AB3B">
                    <asp:ValidationSummary ID="VsDangNhap" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="background-color: #77AB3B">
                    <asp:Label ID="LblLoiDangNhap" runat="server" ForeColor="#CC3300"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>