using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkTSCI.ExceptionTSCI
{
    public class InvalidatedUserException:Exception
    {
        public InvalidatedUserException(): base("Datos incorrectos del usuario")
        {           
        }
    }
}
