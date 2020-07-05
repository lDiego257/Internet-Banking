using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternetBanking.Recursos
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                VerificarSesion();
            }          
           
        }
        public void VerificarSesion()
        {
            if (Session["UsuarioID"] == null)
                Response.Redirect("~/Login");
        }
    }
}