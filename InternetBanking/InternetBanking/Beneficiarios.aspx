<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Beneficiarios.aspx.cs" Inherits="InternetBanking.Beneficiarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="row justify-content-center">
        <div class="card o-hidden border-0 shadow-lg my-5">
          <div class="card-body p-0">
                <div class="p-5">
                  <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4"><B>Registro Beneficiarios</h1>
                  </div>

                 
    <asp:Label ID="Label1" 
        runat="server" 
        Text="nuemro de cuenta"
        ></asp:Label>
                    <br>


    
   <asp:TextBox ID="txtcuenta" 
         runat="server"
         class="form-control form-control-user"
         placeholder="Digite"
         width="600"
        height="40"
         aria-describedby="emailHelp">
         </asp:TextBox>

                   <br>
<b>
     <asp:Label ID="Label3" 
        runat="server" 
        Text="Alias"
        ></asp:Label>
    </b>
                    <br>
     <asp:TextBox ID="txtalias" 
         runat="server"
         class="form-control form-control-user"
         placeholder="Digite"
         width="600"
        height="40"
         aria-describedby="emailHelp">
         </asp:TextBox>
              <br>

                    <asp:Button ID="Button1" 
                        runat="server" 
                        Text="Enviar" 
                        width="600"
                        heigth="0"
                        class="btn btn-primary btn-icon-split" OnClick="Button1_Click" /></asp:Button>
    
                </div>
              </div>
            </div>
          </div>
        </div>

      </div>

    </div>

  </div>
    </b>
</asp:Content>
