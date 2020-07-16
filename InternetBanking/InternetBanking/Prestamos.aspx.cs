using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilidades;

namespace InternetBanking
{
    public partial class Prestamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                Cliente c1 = Cliente.GetClienteByUsuario(Session["usuario"].ToString());
                if (prestamos.GetPrestamosByCedula(c1.Cedula) != null)
                {
                    
                    DropDownList1.DataSource = prestamos.GetPrestamosByCedula(c1.Cedula);
                   
                    DropDownList1.DataTextField = "DisplayText";
                    DropDownList1.DataValueField = "id";
                    DropDownList1.DataBind();
         
                }
            }
        }
    }
}