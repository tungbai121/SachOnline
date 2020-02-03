<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Sach.ascx.cs" Inherits="SachOnline.UC_Sach" %>

<asp:DataList ID="DlSach" runat="server" Width="100%" BackColor="#FFFFC0" RepeatColumns="3">
    <ItemTemplate>
        <table cellspacing="1" width="100%">
            <tr>
                <td width="106px" rowspan="3">
                    <asp:Image ID="ImgSach" runat="server" Height="101px" 
                        ImageUrl='<%# "~/Images/" + Eval("TenFileAnh") %>' Width="101px" />
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