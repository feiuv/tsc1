using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrmPruebaEstudiantes
{
    public partial class FrmEstudiante : Form
    {
        public FrmEstudiante()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            FrameworkTSCI.Model.EstudiantesRepository r = new FrameworkTSCI.Model.EstudiantesRepository();
            r.Add(new FrameworkTSCI.Model.Estudiante
            {
                ApellidoMaterno  = "",
                ApellidoPaterno = "",
                Matricula = "",
                Nombre = ""
            });

        }
    }
}
