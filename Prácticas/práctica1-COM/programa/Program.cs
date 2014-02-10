using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProoOfConceptInfo;

namespace ProgramaAdministrador
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("***Datos del equipo**");
            AdministradorEquipo admin = new ProoOfConceptInfo.AdministradorEquipo("XPS-1330");
            PlacaBase pb = admin.getPlacaBase();
            Console.WriteLine("Serial:" + pb.Serial);
            Console.WriteLine("Descripción: " + pb.Descripcion);
            Console.ReadKey();
        }
    }
}
