using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWeb
{
    public partial class Estudiantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Model.TSCIEntities db = new Model.TSCIEntities();
            Model.Estudiantes t = new Model.Estudiantes();
            t.ApM = "Appp";
            t.Nombre = "asdasd";
            t.ApP = "asdasd";
            t.IdUsuario = 1;
            t.Matricula = "S0123123";
            t.Edad = 10;

            db.AddToEstudiantes(t);
            db.SaveChanges();
        }
    }
}