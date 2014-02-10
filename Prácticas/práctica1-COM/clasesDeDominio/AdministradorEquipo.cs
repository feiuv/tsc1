using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProoOfConceptInfo
{
    /// <summary>
    /// Clase Equipo
    /// </summary>
    public class AdministradorEquipo
    {
        private string nombre;
        private PlacaBase placabase;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nombre"></param>
        public AdministradorEquipo(string nombre)
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Set para nombre
        /// </summary>
        public string Nombre
        {
            set
            {
                nombre = value;
            }
            get
            {
                return nombre;
            }
        }

        /// <summary>
        /// Método get para obtener placabase
        /// </summary>
        /// <returns></returns>
        public PlacaBase getPlacaBase()
        {                        
            if (placabase == null)
            {
                placabase = new PlacaBase();
                placabase.Descripcion = WqlUtil.executeQueryDescriptionBaseBoard();
                placabase.Serial = WqlUtil.executeQuerySerialBaseBoard();
            }            
            return placabase;
        }

       
    }
}
