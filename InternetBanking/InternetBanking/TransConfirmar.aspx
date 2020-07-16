<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TransConfirmar.aspx.cs" Inherits="InternetBanking.TransConfirmar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row justify-content-center">
        <div class="card o-hidden border-0 shadow-lg my-5">
          <div class="card-body p-0">
                <div class="p-5">
                  <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Confirmar</h1>
                  </div>

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
                    <br>
                         <b>
                    <asp:Button id="Button1" 
                        runat="server" 
                        Text="Confirmar" 
                        width="600"
                        class="btn btn-primary btn-icon-split" OnClick="Button1_Click">
                      </asp:Button>
                             
                             <br />
                    <br />
                     <asp:Button id="Button2" 
                        runat="server" 
                        Text="Cancelar" 
                        width="600"
                        class="btn btn-primary btn-icon-split" OnClick="Button2_Click">

                      </asp:Button>
                </div>
              </div>
            </div>
          </div>

                             </b>
                   
                    </asp:Content>
