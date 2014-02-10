using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfazAdministrador
{
    public interface IInfo
    {
        string descripcionBaseBoard();
        string serialBaseBoard();     
        string checksum();
    }
}
