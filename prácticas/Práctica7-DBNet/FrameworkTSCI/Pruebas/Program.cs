using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            RH.Controller.EstudianteController c = new RH.Controller.EstudianteController();
            FrameworkTSCI.Domain.Estudiante e = new FrameworkTSCI.Domain.Estudiante{ Nombre = "Ronaldo", ApP = "Hernandez", ApM = "MC", Matricula = "4232343", Edad = 12 };
            c.Add(e);
        }
    }
}
