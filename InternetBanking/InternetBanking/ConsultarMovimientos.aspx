<%@ Page Title="Consulta de Movimientos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ConsultarMovimientos.aspx.cs" Inherits="InternetBanking.ConsultarMovimientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="card-header py-3">
     <h6 class="m-0 font-weight-bold text-primary">Historial de movimientos</h6>          
    <div class="card-body">

    <asp:GridView ID="GV1" runat="server" OnSelectedIndexChanged="GV1_SelectedIndexChanged" CssClass="table table-bordered" AlternatingRowStyle-BackColor="#0099cc" AlternatingRowStyle-ForeColor="White">
    </asp:GridView>
       
        </div>
          </div>
</asp:Content>
