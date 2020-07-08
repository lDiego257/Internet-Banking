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

        public static WSBanking ws = new WSBanking();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                VerificarSesion();
            }
            tblCliente Cliente = ws.BuscarClientePorId(int.Parse(Session["UsuarioID"].ToString()));
            lblnombre.Text = $"Bienvenido, {Cliente.Apellido}, {Cliente.Nombre}";
            lblusuario.Text = $"Usuario: {Cliente.Usuario}";
            lblultimoacceso.Text = $"Hora de acceso: {DateTime.Now.ToString()}";
        }
        public void VerificarSesion()
        {
            if (Session["UsuarioID"] == null)
                Response.Redirect("~/Login");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Transacciones.aspx");
        }
    }
}