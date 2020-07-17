<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="InternetBanking.Factura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row justify-content-center">
        <div class="card o-hidden border-0 shadow-lg my-5">
          <div class="card-body p-0">
                <div class="p-5">
                  <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Factura Electronica</h1>
                  </div>

                    <asp:Image ID="Image1" ImageUrl="~/BATRACAR.jpg" runat="server" Height="81px" Width="106px" />
                    <br>
                    <b>
    <asp:Label ID="Label1" 
        runat="server" 
        Text="Cuenta Origen"
        ></asp:Label>
                    </b>
<br>
    
                    <asp:Label ID="lblorigen" runat="server" Text="Label"></asp:Label>
<br>
<b>
     <asp:Label ID="Label2" 
        runat="server" 
        Text="Cuenta Destino"
        ></asp:Label>
                    </b>
<br>

      <asp:Label ID="lbldestino" runat="server" Text="Label"></asp:Label>
     
         <br>          
<b>
     <asp:Label ID="Label3" 
        runat="server" 
        Text="Monto a Pagar"
        ></asp:Label>
    </b>
                    <br>
   
                      <asp:Label ID="lblmonto" runat="server" Text="Label"></asp:Label>
<br>
<b>
         <asp:Label runat="server" 
             Text="Concepto">
         </asp:Label>
</b>
<br>
        <asp:Label ID="lblconcepto" runat="server" Text="Label"></asp:Label>
                     <br />
<b>
         <asp:Label runat="server" 
             Text="Numero unico de transaccion" ID="Label4">
         </asp:Label>
</b>
                    <br>
                        
                             
        <asp:Label ID="lblnumerounico" runat="server" Text="Label"></asp:Label>
                             
                             <br />
                    <br />
                </div>
              </div>
            </div>
          </div>

                             </b>
                   
                    </asp:Content>
