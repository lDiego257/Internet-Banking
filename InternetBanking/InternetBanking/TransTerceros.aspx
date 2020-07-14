<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TransTerceros.aspx.cs" Inherits="InternetBanking.TransTerceros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center">
        <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="row" />
                <div class="p-5">
                  <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Transacciones a terceros</h1>
                  </div>

<%-- Cuenta origen --%>
                    <b>
    <asp:Label ID="Label1" 
        runat="server" 
        Text="Cuenta Origen"
        ></asp:Label>
                    </b>
<br>
    
    <asp:DropDownList ID="DropDownList1"
        runat="server"
        class="form-control form-control-user"
         placeholder="Seleccione"
        width="600"
         aria-describedby="emailHelp">
        <asp:ListItem >Seleccione</asp:ListItem>
    </asp:DropDownList>
<br>

                    <%-- Beneficiarios --%>
<b>
     <asp:Label ID="Label2" 
        runat="server" 
        Text="Beneficiarios"
        ></asp:Label>
                    </b>
                    <br>

     <asp:DropDownList ID="DropDownList2"
        runat="server"
        class="form-control form-control-user"
        
          width="600"
         aria-describedby="emailHelp">
         <asp:ListItem >Seleccione</asp:ListItem>

     </asp:DropDownList>

<br>

<%-- Numero de cuenta receptor --%>
                    <b>
     <asp:Label ID="Label4" 
        runat="server" 
        Text="Numero de cuenta receptor"
        ></asp:Label>
                    </b>
<br>

    <%-- <asp:DropDownList ID="DropDownList3"
        runat="server"
        class="form-control form-control-user"
        width="600"
        aria-describedby="emailHelp">
         <asp:ListItem >Seleccione</asp:ListItem>


     </asp:DropDownList>
                    <br >--%>
           <asp:TextBox ID="TextBox1"
         runat="server"
          class="form-control form-control-user"
         width="600"
               placeholder="Numero de cuenta"
         aria-describedby="emailHelp"></asp:TextBox>
<br>
<%-- Monto a pagar --%>
                    <b>
     <asp:Label ID="Label3" 
        runat="server" 
        Text="Monto a Pagar"
        ></asp:Label>
    </b>
                  
                    <br>
   <asp:TextBox ID="TextBox2" 
       runat="server"
       class="form-control form-control-user"
       placeholder="Monto"
       width="600"
       aria-describedby="emailHelp"></asp:TextBox>

    
<br>

<b>
         <asp:Label runat="server" 
             Text="Concepto">
         </asp:Label>
</b>
<br>
         <asp:TextBox id="textbox3"
         runat="server"
         class="form-control form-control-user"
         width="600"
         aria-describedby="emailHelp">

         </asp:TextBox> 
                    <br />
                    <asp:Button id="Button1" 
                        runat="server" 
                        Text="Enviar" 
                        width="600"
                        class="btn btn-primary btn-icon-split">
                      </asp:Button>

                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
