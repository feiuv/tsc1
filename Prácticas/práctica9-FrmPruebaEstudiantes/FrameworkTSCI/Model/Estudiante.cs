using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkTSCI.Model
{
    public class Estudiante:Entity
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Matricula { get; set; }

    }
}
