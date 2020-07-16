using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilidades;

namespace InternetBanking
{
    public partial class TransConfirmar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                lblconcepto.Text = Session["Concepto"].ToString();
                lblorigen.Text = Session["emisorID"].ToString();
                lbldestino.Text= Session["ReceptorID"].ToString();
                lblmonto.Text= Session["monto"].ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            Session["monto"] = "";
            Session["Concepto"] = "";
            Session["emisorID"] = "";
            Session["ReceptorID"] = "";
            Response.Redirect("Principal.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Cliente u1 = Cliente.GetClienteByUsuario(Session["Usuario"].ToString());
            Cuentas c1 = Cuentas.GetCuentasByID(int.Parse(Session["emisorID"].ToString()));
            Cuentas c2 = Cuentas.GetCuentasByID(int.Parse(Session["ReceptorID"].ToString()));
            Double Monto = double.Parse(Session["monto"].ToString());
            string concepto = Session["Concepto"].ToString();
            bool validar = Transacciones.PostTransaction(u1.Cedula, concepto, Monto, c1.id, c2.id);
            if (validar)
            {
                Session["monto"] = "";
                Session["Concepto"] = "";
                Session["emisorID"] = "";
                Session["ReceptorID"] = "";
                Response.Redirect("");
            }
            else
            {
                Response.Write("<script> alert(" + "'Ha ocurrido un error, intente mas tarde'" + ") </script>");
                Session["monto"] = "";
                Session["Concepto"] = "";
                Session["emisorID"] = "";
                Session["ReceptorID"] = "";
                Response.Redirect("");
            }
        }
    }
}