using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilidades;

namespace InternetBanking
{
    public partial class Login : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
      
        protected void Logueo(object sender, EventArgs e)
        {
            //Verifica que los textbox esten limpios
            if (txtusuario != null && txtclave != null)
            {
                //verifica que el usuario existe y que la contraseña sea igual
                /*
                 * 
                 * MUCHO OJO, TODAVIA FALTA QUE VALIDE EL PASSWORD ESTOY ESPERANDO RESPUESTA DE INTEGRACION / CORE
                 *
                 */
                string vUsuario = txtusuario.Text;
                string vClave = txtclave.Text;
                if (Cliente.BuscarCliente(vUsuario) != null)
                {
                    Session["usuario"] = Cliente.BuscarCliente(vUsuario).Cedula;
                    Response.Redirect("Principal.aspx");
                }
                else
                {
                    Response.Write("<script> alert(" + "'Contraseña Incorrecta'" + ") </script>");
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