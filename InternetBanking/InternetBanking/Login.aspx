<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InternetBanking.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    
<head runat="server">
    <meta charset="utf-8"/>
    <title>Login</title>
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
</body>
</html>

 
 
