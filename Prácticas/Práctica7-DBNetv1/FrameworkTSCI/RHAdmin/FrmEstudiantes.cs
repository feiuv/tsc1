using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RHAdmin
{
    public partial class frmEstudiantes : FrameworkTSCI.Base.TSCIForm
    {
        public frmEstudiantes()
        {
            InitializeComponent();
            this.Modulo = "RH";      
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarTxt())
                {

                    try
                    {
                        RH.Controller.EstudianteController controller = new RH.Controller.EstudianteController();
                        //Construir su representación a un objeto
                        FrameworkTSCI.Domain.Estudiante estudiante = new FrameworkTSCI.Domain.Estudiante
                        {
                            Nombre = txtNombre.Text,
                            ApP = txtApP.Text,
                            ApM = txtApM.Text,
                            Edad = Convert.ToInt32(txtEdad.Text),
                            Matricula = txtMatricula.Text
                        };
                        //Hacer la inserción
                        controller.Add(estudiante);
                        MessageBox.Show("Inserción realizada correctamente...");
                        txtNombre.Focus();
                    }
                    catch (FrameworkTSCI.ExceptionTSCI.InsertException e1)
                    {
                        MessageBox.Show(this, "El usuario se pudo registrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (FormatException e1)
                    {
                        MessageBox.Show(this, "Datos incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                    }
                }
            }
            catch (FrameworkTSCI.ExceptionTSCI.InvalidateFieldException e1)
            {
                try
                {
                    TextBox txt = (TextBox)this.Controls[this.Controls.IndexOfKey(e1.Message)];
                    txt.Focus();
                    txt.SelectAll();
                }
                catch { }
            }
        }

    }
}