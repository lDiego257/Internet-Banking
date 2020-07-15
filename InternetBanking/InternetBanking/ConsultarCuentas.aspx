<%@ Page Title="Consultar Cuenta" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ConsultarCuentas.aspx.cs" Inherits="InternetBanking.ConsultarCuentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Consultar Cuentas</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card-header py-3">
     <h6 class="m-0 font-weight-bold text-primary">Cuentas bancarias</h6>          
    <div class="card-body">
    <asp:GridView ID="GV1" runat="server" OnSelectedIndexChanged="GV1_SelectedIndexChanged" CssClass="table table-bordered" AlternatingRowStyle-BackColor="#0099cc" AlternatingRowStyle-ForeColor="White">
<AlternatingRowStyle BackColor="#0099CC" ForeColor="White"></AlternatingRowStyle>
        <Columns>
            <asp:ButtonField CommandName="Select" HeaderText="Movimientos" ShowHeader="True" Text="Consultar" />
        </Columns>
    </asp:GridView>
    </div>
        </div>  

</asp:Content>
