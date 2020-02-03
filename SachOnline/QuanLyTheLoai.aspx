<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Admin.Master" AutoEventWireup="true" CodeBehind="QuanLyTheLoai.aspx.cs" Inherits="SachOnline.QuanLyTheLoai" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="1" width="100%" style="padding-right: 150px; padding-left: 150px;">
        <tr>
            <td align="center" height="25px" colspan="2" style="background-color: #9999FF; font-weight: bold;">
                QUẢN LÝ THỂ LOẠI SÁCH
            </td>
        </tr>
        <tr>
            <td>Mã Loại:</td>
            <td>
                <asp:TextBox ID="TxtMaLoai" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Thể loại sách:</td>
            <td>
                <asp:TextBox ID="TxtTenLoai" runat="server" Width="320px" Enabled="False"></asp:TextBox>
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
                <asp:GridView ID="GvTheLoai" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" GridLines="None" 
                    onselectedindexchanged="GvTheLoai_SelectedIndexChanged" Width="100%" DataKeyNames="MaLoai" ForeColor="#333333">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="MaLoai" HeaderText="Mã loại" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TenLoai" HeaderText="Tên loại" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:CommandField SelectText="Chọn" ShowSelectButton="True" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>