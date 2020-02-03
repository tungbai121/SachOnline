<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_TrangChu.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SachOnline.Default" %>

<%@ Register src="UC_Sach.ascx" tagname="Sach" tagprefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc:Sach ID="UCSach" runat="server" />
</asp:Content>