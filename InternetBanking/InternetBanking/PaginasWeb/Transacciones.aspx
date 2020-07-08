<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasWeb/Master/Plantilla.Master" AutoEventWireup="true" CodeBehind="Transacciones.aspx.cs" Inherits="InternetBanking.PaginasWeb.Transacciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Cuenta Origen"></asp:Label>
    <asp:TextBox ID="txtcuentaorigen" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Cuenta Destino"></asp:Label>
    <asp:TextBox ID="txtcuentadestino" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Monto a pagar"></asp:Label>
    <asp:TextBox ID="txtmonto" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Concepto"></asp:Label>
    <asp:TextBox ID="txtconcepto" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
</asp:Content>
