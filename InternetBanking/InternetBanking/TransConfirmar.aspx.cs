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
            Session["Prestamo"] = "";
            Session["Concepto"] = "";
            Session["emisorID"] = "";
            Session["ReceptorID"] = "";
            Response.Redirect("Principal.aspx");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["Prestamo"].ToString() != "1") {
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
                    var page = HttpContext.Current.CurrentHandler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", "alert('" + "Transaccion procesada exitosamente" + "');window.location ='" + "Principal.aspx" + "';", true);
                }
                else
                {

                    Session["monto"] = "";
                    Session["Concepto"] = "";
                    Session["emisorID"] = "";
                    Session["ReceptorID"] = "";
                    var page = HttpContext.Current.CurrentHandler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", "alert('" + "Ha ocurrido un error en el servidor, por favor intente mas tarde" + "');window.location ='" + "Principal.aspx" + "';", true);
                }
            }
            else
            {
                Cuentas c1 = Cuentas.GetCuentasByID(int.Parse(Session["emisorID"].ToString()));
                Double Monto = double.Parse(Session["monto"].ToString());
                prestamos p1 = prestamos.GetLoanByID(int.Parse(Session["ReceptorID"].ToString()));
                bool validar = PagoPrestamo.PostPrestamo(p1.id, c1.id, Monto);
                if (validar)
                {
                    Session["monto"] = "";
                    Session["Concepto"] = "";
                    Session["emisorID"] = "";
                    Session["ReceptorID"] = "";
                    Session["Prestamo"] = "";
                    var page = HttpContext.Current.CurrentHandler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", "alert('" + "Transaccion procesada exitosamente" + "');window.location ='" + "Principal.aspx" + "';", true);
                }
                else
                {

                    Session["monto"] = "";
                    Session["Concepto"] = "";
                    Session["emisorID"] = "";
                    Session["ReceptorID"] = "";
                    Session["Prestamo"] = "";
                    var page = HttpContext.Current.CurrentHandler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", "alert('" + "Ha ocurrido un error en el servidor, por favor intente mas tarde" + "');window.location ='" + "Principal.aspx" + "';", true);
                }
            }
        }
    }
}