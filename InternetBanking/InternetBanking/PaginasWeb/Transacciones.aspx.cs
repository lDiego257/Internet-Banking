using InternetBanking.Recursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternetBanking.PaginasWeb
{
    public partial class Transacciones : System.Web.UI.Page
    {
        WSBanking ws = new WSBanking();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioID"] == null)
                    Response.Redirect("~/Login");

                tblCliente Cliente = ws.BuscarClientePorId(int.Parse(Session["UsuarioID"].ToString()));
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ws.Transaccion(txtcuentaorigen.Text, txtcuentadestino.Text, int.Parse(txtmonto.Text), txtconcepto.Text);

        }
    }
}