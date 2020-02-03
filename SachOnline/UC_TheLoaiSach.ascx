<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_TheLoaiSach.ascx.cs" Inherits="SachOnline.UC_TheLoaiSach" %>

<asp:GridView ID="GvTheLoaiSach" runat="server" Width="100%" 
    AutoGenerateColumns="False" EnableModelValidation="True" ShowHeader="False">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <table cellspacing="1" width="100%">
                    <tr>
                        <td style="background-color: #CCCCFF">
                            <asp:Image ID="ImgIconList" runat="server" ImageUrl="~/Images/icon_list.gif" />
                        </td>
                        <td style="background-color: #CCCCFF" width="100%">
                            <asp:HyperLink ID="HplTheLoai" runat="server" Font-Underline="False" 
                                NavigateUrl='<%# "SachTheoTheLoai.aspx?MaLoai=" + Eval("MaLoai") %>' 
                                Text='<%# Eval("TenLoai") %>'></asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>