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
                if (Cuentas.ListarCuentas(Session["usuario"].ToString()) != null)
                {
                    DropDownList2.DataTextField = "DisplayText";
                  
                    DropDownList2.DataSource = Cuentas.ListarCuentasDrop(Session["usuario"].ToString());
                    DropDownList2.DataTextField = "DisplayText";
                    DropDownList2.DataValueField = "id";
                    DropDownList2.DataBind();
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Cliente c1 = Cliente.GetClienteByUsuario(Session["usuario"].ToString());
            if (TextBox1.Text != "")
            {
                double monto;
                if (double.TryParse(TextBox1.Text,out monto))
                {
                    Cuentas Emisor = Cuentas.GetCuentasByID(int.Parse(DropDownList2.SelectedValue));
                    if (Emisor.balance >= monto)
                    {
                        if (prestamos.GetLoanByID(int.Parse(DropDownList2.SelectedValue)) != null)
                            {
                            prestamos p1 = prestamos.GetLoanByID(int.Parse(DropDownList2.SelectedValue));

                            if (p1.cantidadfaltante >= monto)
                            {
                                Session["Concepto"] = "Pago de prestamo";
                                Session["emisorID"] = Emisor.id;
                                Session["ReceptorID"] = p1.id.ToString();
                                Session["monto"] = monto.ToString();
                                Session["Prestamo"] = "1";
                                Response.Redirect("TransConfirmar.aspx");
                            }
                            else
                                Response.Write("<script> alert(" + "'El monto ingresado supera la cantidad que le queda por pagar'" + ") </script>");
                        }
                        else Response.Write("<script> alert(" + "'Usted no tiene ningun prestamo'" + ") </script>");
                    }
                    else Response.Write("<script> alert(" + "'Balance insuficiente'" + ") </script>");
                }
                else Response.Write("<script> alert(" + "'Ingrese un monto valido'" + ") </script>");
            }
            else Response.Write("<script> alert(" + "'Todos los campos son obligatorios'" + ") </script>");
        }
    }
}