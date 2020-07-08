<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasWeb/Master/Plantilla.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="InternetBanking.Recursos.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblnombre" runat="server" Text="Nombre"></asp:Label>
    <br />
    <asp:Label ID="lblultimoacceso" runat="server" Text="Ultimo acceso"></asp:Label>
    <br />
    <asp:Label ID="lblusuario" runat="server" Text="Usuario"></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Transferencia Propio" OnClick="Button1_Click" />
</asp:Content>
