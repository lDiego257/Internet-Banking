﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilidades;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace InternetBanking
{
    public partial class TransPropias : System.Web.UI.Page
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
                    DropDownList2.DataTextField = "DisplayText";
                    DropDownList1.DataSource = Cuentas.ListarCuentasDrop(Session["usuario"].ToString());

                    DropDownList1.DataTextField = "DisplayText";
                    DropDownList1.DataValueField = "id";
                    DropDownList1.DataBind();

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
            if (TextBox1.Text != "" && textbox3.Text != "")
            {
                if (DropDownList1.SelectedValue != DropDownList2.SelectedValue)
                {
                    double monto;
                    if (double.TryParse(TextBox1.Text, out monto))
                    {
                        string respuesta = Transacciones.PostTransaction(c1.Cedula, textbox3.Text, monto, int.Parse(DropDownList1.SelectedValue), int.Parse(DropDownList2.SelectedValue));                       
                        MessageBox.Show($"{respuesta}");
                        
                    }
                    else
                        Response.Write("<script> alert(" + "'Ingrese un monto con valor numerico'" + ") </script>");
                }
                else
                    Response.Write("<script> alert(" + "'No puede hacer una transaccion de una cuenta a ella misma'" + ") </script>");
            }
            else
                Response.Write("<script> alert(" + "'Todos los campos son obligatorios'" + ") </script>");
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}