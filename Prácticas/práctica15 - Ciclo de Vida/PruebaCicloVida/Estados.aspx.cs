using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaCicloVida
{
    public partial class Estados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Enabled = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ViewState["VS"] = "Estado 1"; 

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ViewState["VS"] = "Estado 2"; 
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Label1.Text = ViewState["VS"] == null? "[Vacio]": ViewState["VS"].ToString();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session["S1"] = "Sessión 1";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Label2.Text = Session["S1"] == null ? "[Vacio]" : Session["S1"].ToString();
      
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Application["A1"] = "Application 1";
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Label3.Text = Application["A1"] == null ? "[Vacio]" : Application["A1"].ToString();
      
        }
    }
}