<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Admin.Master" AutoEventWireup="true" CodeBehind="QuanLySach.aspx.cs" Inherits="SachOnline.QuanLySach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="1" width="100%">
        <tr>
            <td align="center" height="25px" colspan="4" style="background-color: #9999FF; font-weight: bold">QUẢN LÝ SÁCH</td>
        </tr>
        <tr>
            <td>Mã sách:</td>
            <td width="280px">
                <asp:TextBox ID="TxtMaSach" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td width="122px">Chọn Image sách:</td>
            <td>
                <asp:FileUpload ID="UplAnh" runat="server" Enabled="False" />
                <asp:Button ID="BtnUploadAnh" runat="server" onclick="BtnUploadAnh_Click" Text="Upload ảnh" Enabled="False" />
            </td>
        </tr>
        <tr>
            <td>Tên sách:</td>
            <td width="280px">
                <asp:TextBox ID="TxtTenSach" runat="server" Width="268px" Enabled="False"></asp:TextBox>
            </td>
            <td width="122px">
                <asp:Label ID="LblAnhSach" runat="server" Text="Image sách:"></asp:Label>
            </td>
            <td rowspan="5">
                <asp:Image ID="ImgSach" runat="server" Height="167px" Width="134px" />
            </td>
        </tr>
        <tr>
            <td>Tác giả:</td>
            <td width="280px">
                <asp:TextBox ID="TxtTacGia" runat="server" Width="266px" Enabled="False"></asp:TextBox>
            </td>
            <td width="122px">
                <asp:TextBox ID="TxtTenFileAnh" runat="server" Width="81px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Giá:</td>
            <td width="280px">
                <asp:TextBox ID="TxtGia" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td width="122px">&nbsp;</td>
        </tr>
        <tr>
            <td>Số lượng:</td>
            <td width="280px">
                <asp:TextBox ID="TxtSoLuong" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td width="122px">&nbsp;</td>
        </tr>
        <tr>
            <td>Mô tả:</td>
            <td width="280px">
                <asp:TextBox ID="TxtMoTa" runat="server" Rows="4" TextMode="MultiLine" Width="268px" Enabled="False"></asp:TextBox>
            </td>
            <td width="122px">&nbsp;</td>
        </tr>
        <tr>
            <td>Mã loại:</td>
            <td width="280px">
                <asp:TextBox ID="TxtMaLoai" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td width="122px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td height="14px"></td>
            <td width="280px" height="14px"></td>
            <td width="122px" height="14px"></td>
            <td height="14px"></td>
        </tr>
        <tr>
            <td align="center" colspan="4">
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
            <td align="center" colspan="4">
                <asp:Label ID="LblThongBao" runat="server" ForeColor="#CC3300" Visible="False"></asp:Label>
                &nbsp;&nbsp;
                <asp:Button ID="BtnCo" runat="server" onclick="BtnCo_Click" Text="Có" Visible="False" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnKhong" runat="server" onclick="BtnKhong_Click" Text="Không" Visible="False" />
            </td>
        </tr>
        <tr>
            <td width="65px" height="14px"></td>
            <td width="280px" height="14px"></td>
            <td width="122px" height="14px"></td>
            <td height="14px"></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GvSach" runat="server" AutoGenerateColumns="False" 
                    BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                    CellPadding="2" DataKeyNames="MaSach" 
                    ForeColor="Black" GridLines="None" 
                    onselectedindexchanged="GvSach_SelectedIndexChanged" Width="100%">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    <Columns>
                        <asp:BoundField DataField="MaSach" HeaderText="Mã sách" >
                        <HeaderStyle Width="3%" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TenSach" HeaderText="Tên sách" >
                        <HeaderStyle HorizontalAlign="Center" Width="12%" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TacGia" HeaderText="Tác giả" >
                        <HeaderStyle Width="15%" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Gia" HeaderText="Giá" >
                        <HeaderStyle Width="5%" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" >
                        <HeaderStyle Width="7%" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MoTa" HeaderText="Mô tả" />
                        <asp:BoundField DataField="TenFileAnh" HeaderText="Tên File ảnh" >
                        <HeaderStyle Width="5%" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MaLoai" HeaderText="Mã loại" >
                        <HeaderStyle Width="3%" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:CommandField SelectText="Chọn" ShowSelectButton="True" >
                        <HeaderStyle Width="5%" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <SortedAscendingCellStyle BackColor="#FAFAE7" />
                    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                    <SortedDescendingCellStyle BackColor="#E1DB9C" />
                    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>