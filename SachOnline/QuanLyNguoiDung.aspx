<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Admin.Master" AutoEventWireup="true" CodeBehind="QuanLyNguoiDung.aspx.cs" Inherits="SachOnline.QuanLyNguoiDung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="1" width="100%" style="padding-right: 150px; padding-left: 150px">
        <tr>
            <td align="center" height="25px" colspan="2" 
                style="background-color: #9999FF; font-weight: bold;">QUẢN LÝ NGƯỜI DÙNG
            </td>
        </tr>
        <tr>
            <td>ID:</td>
            <td>
                <asp:TextBox ID="TxtID" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Tên đăng nhập:</td>
            <td>
                <asp:TextBox ID="TxtTenDangNhap" runat="server" Width="290px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Mật khẩu:</td>
            <td>
                <asp:TextBox ID="TxtMatKhau" runat="server" Width="290px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="BtnThem" runat="server" onclick="BtnThem_Click" Text="Thêm" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnXoa" runat="server" onclick="BtnXoa_Click" Text="Xóa" Enabled="False" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnSua" runat="server" onclick="BtnSua_Click" Text="Sửa" Enabled="False" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnLuu" runat="server" onclick="BtnLuu_Click" Text="Lưu" Enabled="False" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnHuy" runat="server" onclick="BtnHuy_Click" Text="Huỷ" Enabled="False" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="LblThongBao" runat="server" ForeColor="#CC3300" Visible="False"></asp:Label>
                    &nbsp;&nbsp;
                <asp:Button ID="BtnCo" runat="server" onclick="BtnCo_Click" Text="Có" Visible="False" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnKhong" runat="server" onclick="BtnKhong_Click" Text="Không" Visible="False" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GvNguoiDung" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" 
                    onselectedindexchanged="GvNguoiDung_SelectedIndexChanged" Width="100%">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TenDangNhap" HeaderText="Tên đăng nhập" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MatKhau" HeaderText="Mật khẩu" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:CommandField SelectText="Chọn" ShowSelectButton="True" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>