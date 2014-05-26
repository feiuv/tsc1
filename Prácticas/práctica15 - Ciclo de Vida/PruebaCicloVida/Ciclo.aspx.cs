using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaCicloVida
{
    public partial class Ciclo : System.Web.UI.Page
    {

        private static int x = 0;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Response.Write("Page_PreInit<br/>");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("Page_Init<br/>");
        }

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            Response.Write("InitComplete<br/>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Page_Load<br/>");

            if (IsPostBack)
            {
                Response.Write("--->Es PostBack<br/>");
            }
            else
            {
                Response.Write("---->No PostBack<br/>");
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Response.Write("Page_LoadComplete<br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write(" PreRender<br/>");
        }

        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            Response.Write(" Page_SaveStateComplete<br/>");
        }

        protected void Page_Render(object sender, EventArgs e)
        {
            Response.Write(" Render<br/>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = TextBox1.Text;
           
            //HiddenField1.Value = (Convert.ToInt32(HiddenField1.Value) + 1).ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label2.Text = x.ToString();
        }
        

    }
}