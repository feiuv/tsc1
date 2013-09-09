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
            try
            {
                if (ValidarTxt())
                {
                    new frmEstudiantes().Show();
                }
            }
            catch
            {
            }

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
