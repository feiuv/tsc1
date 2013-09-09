using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace FrameworkTSCI.Base
{
    public class TSCIForm : Form
    {
        public String Modulo { get; set; }
        public TSCIForm()
            : base()
        {
            StartPosition = FormStartPosition.CenterScreen;
        }

        public bool ValidarTxt()
        {
            
            ConfigModuloRepository r = new ConfigModuloRepository();   
            bool result = true;
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    Domain.ConfigModulo pattern = null;
                    try
                    {
                        pattern = r.GetByFields(Modulo, this.Name, c.Name);
                    }
                    catch { }

                    if (pattern != null && !Util.RegularExp.Match(pattern.RE, c.Text))
                    {
                        result = false;
                        throw new ExceptionTSCI.InvalidateFieldException(c.Name);
                    }

                }

                //result = false;
            }
            return result;
        }

    }
}
