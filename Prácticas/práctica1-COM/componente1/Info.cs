using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
////////////////////////////////////////
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Diagnostics;
using InterfazAdministrador;
using ProoOfConceptInfo;
namespace InfoCOM
{
    [ComVisible(true)]
    [Guid("315239A0-2A2A-4D6E-9129-A4AF3AA25560")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("ServiceInfo.InfoCOM")]
    [Serializable]

    public class Info : ServicedComponent, IInfo
    {
        private AdministradorEquipo admin = new AdministradorEquipo("XPS-1330");
        public Info()
        {
            //System.Windows.Forms.MessageBox.Show("Invocando...");
        }

        [AutoComplete(true)]
        public string descripcionBaseBoard()
        {
               return  admin.getPlacaBase().Descripcion;
        }

        [AutoComplete(true)]
        public string serialBaseBoard()
        {
            return admin.getPlacaBase().Serial;
        }

        [AutoComplete(true)]
        public string checksum()
        {
            throw new NotImplementedException();
        }
    }
}


