<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Prestamos.aspx.cs" Inherits="InternetBanking.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form class="user" runat="server">
                    <div class="form-group">
                         <asp:TextBox type="Text" 
                             ID="txtusuario" 
                             runat="server"
                             class="form-control form-control-user"
                             placeholder="ID"
                             aria-describedby="emailHelp">

                         </asp:TextBox>
                    </div>

                    <div class="form-group">
                         <asp:TextBox type="password" 
                             ID="txtclave"
                             runat="server"
                             class="form-control form-control-user"
                             placeholder="Password">

                         </asp:TextBox>
</asp:Content>
