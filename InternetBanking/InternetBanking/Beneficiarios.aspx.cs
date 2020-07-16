using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilidades;

namespace InternetBanking
{
    public partial class Beneficiarios : System.Web.UI.Page
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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Cliente cliente = Cliente.GetClienteByUsuario(Session["usuario"].ToString());
            if(txtalias.Text!="" && txtcuenta.Text != "")
            {
                string alias = txtalias.Text;
                int cuenta;
                if (int.TryParse(txtcuenta.Text, out cuenta))
                {
                    Cuentas c1 = Cuentas.GetCuentasByID(cuenta);
                    if (c1 != null)
                    {
                        Beneficiario.RegistrarBeneficiario(cliente.Id.ToString(), c1.id.ToString(), alias);
                        Response.Write("<script> alert(" + "'Beneficiario Añadido'" + ") </script>");
                        Response.Redirect("Principal.aspx");
                    }
                    else
                        Response.Write("<script> alert(" + "'La cuenta a la que intenta atar el beneficiario no existe'" + ") </script>");
                }
                else
                    Response.Write("<script> alert(" + "'Ingrese un numeor de cuenta valido'" + ") </script>");
            }
            else
                Response.Write("<script> alert(" + "'Todos los campos deben de ser rellenados'" + ") </script>");
        }
    }
}