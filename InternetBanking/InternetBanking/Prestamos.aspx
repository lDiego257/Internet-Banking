<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Prestamos.aspx.cs" Inherits="InternetBanking.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body class="bg-gradient-primary" >

  <div class="container">

    <!-- Outer Row -->
    <div class="row justify-content-center">

      <div class="col-xl-10 col-lg-12 col-md-9">

        <div class="card o-hidden border-0 shadow-lg my-5">
          <div class="card-body p-0">
            <!-- Nested Row within Card Body -->
            <div class="row">

                  </div>
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
                      
                    </div>
                    <asp:Button ID="Button1" 
                        runat="server" 
                        Text="Iniciar Sesion" 
                        OnClick="Logueo"
                        width="340px"
                        height="40"
                        class="btn btn-primary btn-icon-split"/>
                      </form>
                </div>
              </div>        
      </div>
  </div>
      <!-- Bootstrap core JavaScript-->
  <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

  <!-- Core plugin JavaScript-->
  <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

  <!-- Custom scripts for all pages-->
  <script src="js/sb-admin-2.min.js"></script>
</body>

</asp:Content>
