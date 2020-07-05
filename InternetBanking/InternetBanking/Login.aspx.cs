using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternetBanking
{
    public partial class Login : System.Web.UI.Page
    {
        WSBanking ws = new WSBanking();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string vUsuario = txtusuario.Text;
            string vClave = txtclave.Text;
            int idusuario= ws.login(vUsuario,vClave);

            if (idusuario == 0)
            {
                Response.Write("<script> alert(" + "'Datos incorrectos'" + ") </script>");
            }

            else
            {
                Session["UsuarioID"] = idusuario;
                Response.Redirect("~/PaginasWeb/Principal.aspx");
            }
        }
       
    }
}