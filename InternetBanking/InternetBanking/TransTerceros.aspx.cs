using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilidades;

namespace InternetBanking
{
    public partial class TransTerceros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                }

                if (Cuentas.ListarCuentas(Session["usuario"].ToString()) != null)
                {


                    DropDownList1.DataSource = Cuentas.ListarCuentasDrop(Session["usuario"].ToString());
                    DropDownList1.DataTextField = "DisplayText";
                    DropDownList1.DataValueField = "id";
                    DropDownList1.DataBind();
                }
                if (Beneficiario.ListarBeneficariosDrop(Session["usuario"].ToString()) != null)
                {
                    Cliente c1 = Cliente.GetClienteByUsuario(Session["usuario"].ToString());
                    DropDownList2.DataSource = Beneficiario.ListarBeneficariosDrop(c1.Id.ToString());
                    DropDownList2.DataTextField = "DisplayText";
                    DropDownList2.DataValueField = "CuentaBeneficiario";
                    DropDownList2.DataBind();
                }
            
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtreceptor.Text != "" || DropDownList2.SelectedValue != "0")
            {
                //Esto es para verificar si va a usar beneficiario o si va a usar el txt
                int emisor = int.Parse(DropDownList1.SelectedValue.ToString());
                string concepto = txtconcepto.Text;
                int receptor = 0;
                double monto = 0;
                if (DropDownList2.SelectedValue != "0")
                {
                    receptor = int.Parse(DropDownList2.SelectedValue.ToString());
                }
                else
                    receptor = int.Parse(txtmonto.Text);
                //Aqui acaba la verificacion de beneficiario o textbox

                //verifica que la cuenta existe
                Cuentas CuentaReceptor = Cuentas.GetCuentasByID(receptor);
                Cuentas CuentaEmisor = Cuentas.GetCuentasByID(emisor);
                if (CuentaReceptor != null)
                {
                    if (double.TryParse(txtmonto.Text, out monto))
                    {
                        if(CuentaEmisor.balance>= monto)
                        {
                            Session["monto"] = monto;
                            Session["Concepto"] = concepto;
                            Session["emisorID"] = CuentaEmisor.id;
                            Session["ReceptorID"] = CuentaReceptor.id;


                            Response.Redirect("TransConfirmar.aspx");
                        }
                        else
                            Response.Write("<script> alert(" + "'Monto insuficiente'" + ") </script>");
                    }
                    else
                        Response.Write("<script> alert(" + "'Ingrese un valor valido en el monto'" + ") </script>");
                }
                else
                    Response.Write("<script> alert(" + "'Cuenta no encontrada'" + ") </script>");

            }
            else
                Response.Write("<script> alert(" + "'Todos los campos son obligatorios'" + ") </script>");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue != "0")
            {
                this.txtreceptor.Enabled = false;
            }
            else
                this.txtreceptor.Enabled = true;
        }
    }
}