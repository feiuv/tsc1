using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkTSCI.ExceptionTSCI
{
    public class InvalidateFieldException : System.Exception
    {

        public InvalidateFieldException(String field) : base(field)
        {           
        }
    }
}
