<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_TrangChu.Master" AutoEventWireup="true" CodeBehind="ChiTietSach.aspx.cs" Inherits="SachOnline.ChiTietSach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="1">
        <tr>
            <td style="background-color: #999900">CHI TIẾT SÁCH</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GvChiTietSach" runat="server" AutoGenerateColumns="False" 
                    EnableModelValidation="True" ShowHeader="False" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table width="100%">
                                    <tr>
                                        <td width="101px" rowspan="4">
                                            <asp:Image ID="ImgSach" runat="server" Height="110px" 
                                                ImageUrl='<%# "~/Images/" + Eval("TenFileAnh") %>' Width="103px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="LblTenSach" runat="server" Font-Bold="True" ForeColor="#6600CC" 
                                                Text='<%# Eval("TenSach") %>'></asp:Label>
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
                                    <tr>
                                        <td>
                                            <strong>Số lượng hiện có: </strong>
                                            <asp:Label ID="LblSoLuong" runat="server" Text='<%# Eval("SoLuong") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table cellspacing="1">
                                    <tr>
                                        <td>
                                            <strong>Mô tả sách:<br /> </strong>
                                            <asp:Label ID="LblMoTa" runat="server" Text='<%# Eval("MoTa") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>