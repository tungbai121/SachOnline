<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_TrangChu.Master" AutoEventWireup="true" CodeBehind="SachTheoTheloai.aspx.cs" Inherits="SachOnline.SachTheoTheloai" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="1" width="100%">
        <tr>
            <td style="background-color: #BBA259">
                <asp:Label ID="LblTongSoSach" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="DlSach" runat="server" BackColor="#FFFFC0" RepeatColumns="3" Width="100%">
                    <ItemTemplate>
                        <table cellspacing="1">
                            <tr>
                                <td rowspan="3">
                                    <asp:Image ID="ImgSach" runat="server" Height="109px" 
                                        ImageUrl='<%# "~/Images/" + Eval("TenFileAnh") %>' Width="102px" />
                                </td>
                                <td>
                                    <asp:HyperLink ID="HplChiTiet" runat="server" 
                                        NavigateUrl='<%# "ChiTietSach.aspx?MaSach=" + Eval("MaSach") %>' 
                                        Text='<%# Eval("TenSach") %>'></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Tác giả: </strong>
                                    <asp:Label ID="LblTacGia" runat="server" Text='<%# Eval("TacGia") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Giá bán: </strong>
                                    <asp:Label ID="LblGia" runat="server" Text='<%# Eval("Gia") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>