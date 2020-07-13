using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilidades;

namespace InternetBanking
{
    public partial class ConsultarCuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            if (Cuentas.ListarCuentas(Session["usuario"].ToString()) != null)
            {
                GV1.DataSource = Cuentas.ListarCuentas(Session["usuario"].ToString());
                GV1.DataBind();
            }
            else
            {
                Response.Write("<script> alert(" + "'Usted no posee cuentas'" + ") </script>");
            }

        }

        protected void GV1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow fila = GV1.SelectedRow;
            Session["ConsultaCuenta"] = fila.Cells[1].Text;
            Response.Redirect("~/ConsultarMovimientos.aspx");
        }
    }

}