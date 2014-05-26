using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaCicloVida
{
    public partial class EstadosUno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            Label2.Text = Session["S1"] == null ? "[Vacio]" : Session["S1"].ToString();

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Label2.Text = Application["A1"] == null ? "[Vacio]" : Application["A1"].ToString();
        }

    }
}