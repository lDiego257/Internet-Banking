<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InternetBanking.Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head>

  <meta charset="utf-8"/>
  <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
  <meta name="description" content=""/>
  <meta name="author" content=""/>

  <title>Login</title>

  <!-- Custom fonts for this template-->
  <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
  <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">

  <!-- Custom styles for this template-->
  <link href="css/sb-admin-2.min.css" rel="stylesheet"/>

</head>

<body class="bg-gradient-primary" >

  <div class="container">

    <!-- Outer Row -->
    <div class="row justify-content-center">

      <div class="col-xl-10 col-lg-12 col-md-9">

        <div class="card o-hidden border-0 shadow-lg my-5">
          <div class="card-body p-0">
            <!-- Nested Row within Card Body -->
            <div class="row">
              <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
              <div class="col-lg-6">
                <div class="p-5">
                  <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Bienvenido!</h1>
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
        </div>

      </div>

    </div>

  </div>

</body>


</html>


<%-- loguin sin diseño --%>


<%--<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
        <asp:TextBox ID="txtusuario" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Clave"></asp:Label>
            <asp:TextBox ID="txtclave" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" Text="Iniciar Sesion" Width="97px" OnClick="Button1_Click" />
    </form>
</body>--%>
