using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilidades;
using System.Windows.Forms;

namespace InternetBanking
{
    public partial class Login : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["usuario"] = null;
        }
      
        protected void Logueo(object sender, EventArgs e)
        {
            //Verifica que los textbox no esten limpios
            if (txtusuario != null && txtclave != null)
            {             
                string vUsuario = txtusuario.Text;
                string vClave = txtclave.Text;
                if (usuario.ValidaUsuario(vUsuario,vClave))
                {
                    Response.Write("<script> alert(" + "'Chevere'" + ") </script>");
                    Session["usuario"] = vUsuario;
                    Response.Redirect("Principal.aspx");
                   
                }
                else
                {
                    Response.Write("<script> alert(" + "'Usuario o Contraseña Incorrecta'" + ") </script>");
                }
            }
            else
                   Response.Write("<script> alert(" + "'Debe rellenar todos los datos'" + ") </script>");

            //if (idusuario == 0)
            //{
            //    Response.Write("<script> alert(" + "'Datos incorrectos'" + ") </script>");
            //}

            //else
            //{
            //    Session["UsuarioID"] = idusuario;
            //    Response.Redirect("~/PaginasWeb/Principal.aspx");
            //}

        }
       
    }
}