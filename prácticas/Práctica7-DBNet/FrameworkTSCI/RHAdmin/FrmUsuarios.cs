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
    public partial class FrmUsuarios : FrameworkTSCI.Base.TSCIForm
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // this.Hide(); 

            if (ValidarTxt())
            {
                RH.Controller.UsuarioController u = new RH.Controller.UsuarioController();
                try
                {
                    FrameworkTSCI.Domain.Usuario user = u.ValidarUsuario(txtUser.Text, txtPassword.Text);
                    new frmEstudiantes().Show();
                }
                catch (FrameworkTSCI.ExceptionTSCI.InvalidatedUserException e1)
                {
                    MessageBox.Show("Datos incorrectos.");
                }
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
