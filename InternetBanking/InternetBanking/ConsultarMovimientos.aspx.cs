using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilidades;

namespace InternetBanking
{
    public partial class ConsultarMovimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Utilidades.Transacciones.GetTransacciones() != null)
            //{
            //    GV1.DataSource = Transacciones.GetTransacciones();
            //    GV1.DataBind();
            //}
        }

        protected void GV1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}