using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkTSCI.Domain
{
    public class ConfigModulo:Base.Entity
    {
        public String Modulo { get; set; }
        public String Forma { get; set; }
        public String Campo { get; set; }
        public String RE { get; set; }
    }
}
