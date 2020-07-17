using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilidades;

namespace InternetBanking
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                Session["monto"] = "";
                Session["Prestamo"] = "";
                Session["Concepto"] = "";
                Session["emisorID"] = "";
                Session["ReceptorID"] = "";
                double monto=0;
                Cliente c1 = Cliente.GetClienteByUsuario(Session["usuario"].ToString());
                if (c1 != null)
                {

                    if (Cuentas.ListarCuentasInicio(Session["usuario"].ToString()) != null)
                    {
                        List<Cuentas> cs1 = Cuentas.ListarCuentasInicio(c1.Usuario);
                        foreach (var item in cs1)
                        {
                            monto = monto + item.balance;
                        }
                    }
                    lblcorreo.Text = c1.CorreoElectronico;
                    lblNombre.Text = $"{c1.Nombre} {c1.Apellido}";
                    lblUltimoAcceso.Text = "Ultimo Acceso";
                    lblfecha.Text = Session["fecha"].ToString();
                    lblBalanceGeneralnumero.Text = monto.ToString();
                    Label1.Text = "Balance General";
                }
                else
                {
                    var page = HttpContext.Current.CurrentHandler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", "alert('" + "Usted no aparece como cliente en nuestro sistema" + "');window.location ='" + "Login.aspx" + "';", true);
                }
            }
        }     
    }
}