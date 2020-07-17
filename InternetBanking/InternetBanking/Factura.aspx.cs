using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilidades;

namespace InternetBanking
{
    public partial class Factura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                Transacciones t1 = Transacciones.GetLasTransaction(Session["emisorID"].ToString());
                lblconcepto.Text = Session["Concepto"].ToString();
                lblorigen.Text = Session["emisorID"].ToString();
                lbldestino.Text = Session["ReceptorID"].ToString();
                lblmonto.Text = Session["monto"].ToString();
                lblnumerounico.Text = t1.id.ToString();
            }
            
        }
    }
}