<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Transaccion.aspx.cs" Inherits="InternetBanking.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center">

      <div class="col-xl-10 col-lg-12 col-md-9">

        <div class="card o-hidden border-0 shadow-lg my-5">
          <div class="card-body p-0">
            <!-- Nested Row within Card Body -->
            <div class="row">
              <div class="col-lg-6">
                <div class="p-5">
                  <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Prestamos</h1>
                  </div>

                    <b>
    <asp:Label ID="Label1" 
        runat="server" 
        Text="Cuenta Origen"
        ></asp:Label>
                    </b>

    
    <asp:DropDownList ID="DropDownList1"
        runat="server"
        class="form-control form-control-user"
         placeholder="Seleccione"
        width="600"
         aria-describedby="emailHelp">
        <asp:ListItem >Seleccione</asp:ListItem>
    </asp:DropDownList>

<b>
     <asp:Label ID="Label2" 
        runat="server" 
        Text="Cuenta Destino"
        ></asp:Label>
                    </b>


     <asp:DropDownList ID="DropDownList2"
        runat="server"
        class="form-control form-control-user"
        
          width="600"
         aria-describedby="emailHelp">
         <asp:ListItem >Seleccione</asp:ListItem>

     </asp:DropDownList>
                   
<b>
     <asp:Label ID="Label3" 
        runat="server" 
        Text="Monto a Pagar"
        ></asp:Label>
    </b>
     <asp:TextBox ID="TextBox1" 
         runat="server"
         class="form-control form-control-user"
         placeholder="Digite"
          width="600"
         aria-describedby="emailHelp">
         </asp:TextBox>

<b>
         <asp:Label runat="server" 
             Text="Concepto">
         </asp:Label>
</b>

         <asp:TextBox id="textbox3"
         runat="server"
         class="form-control form-control-user"
         width="600"
         aria-describedby="emailHelp">

         </asp:TextBox>

    
                </div>
              </div>
            </div>
          </div>
        </div>

      </div>

    </div>

  </div>


</asp:Content>
