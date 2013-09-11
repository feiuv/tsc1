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
        public int Edad { get; set;}

        public Estudiante()
        {
            
        }

        public Estudiante(string nombre, string app, string apm, string matricula, int edad, int id)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.ApM = apm;
            this.ApP = app;
            this.Matricula = matricula;
            this.Edad = edad;
        }

        public Estudiante(string nombre, string app, string apm, string matricula, int edad): this(nombre, app, apm, matricula, 0, edad)
        {
           
        }
    
    }
}
