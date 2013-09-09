using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkTSCI.Domain
{
    public class Estudiante: Base.Entity
    {
        public String Nombre { get; set; }
        public String ApP { get; set; }
        public String ApM { get; set; }
        public String Matricula { get; set; }
        private int edad;
        public int Edad
        {
            get
            {
                return edad;
            }
            set
            {
                //TODO: Validación
                edad = value;
            }
        }
    }
}
