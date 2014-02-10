using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProoOfConceptInfo
{
    /// <summary>
    /// Método para placa base.
    /// </summary>
    public class PlacaBase
    {        
        private string serial;
        private string descripcion;
        
        public string Serial
        {
            set { 
                serial = value;
            }
            get { 
                return serial;
            }
        }

        public string Descripcion
        {
            set
            {
                descripcion = value;
            }
            get {
                return descripcion;
            }
        }

    }

}
