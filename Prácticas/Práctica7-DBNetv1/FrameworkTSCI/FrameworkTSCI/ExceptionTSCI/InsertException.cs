using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkTSCI.ExceptionTSCI
{
    public class InsertException : System.Exception
    {
        
        public InsertException(System.Exception e):base("FrameworkTSCI: Insert {0}" + e.Message)
        {           
        }
    }
}
