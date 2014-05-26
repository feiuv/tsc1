using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSCILinq
{
    class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
     }

    class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int IdCategoria { get; set; } 
    }

    class Direccion
    {
        public int Id { get; set; }
        public string DireccionEstudiante { get; set; }
        public int IdEstudiante { get; set;}
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            List<Direccion> direcciones = new List<Direccion>();
            List<Categoria> categorias = new List<Categoria>();
 
            Categoria c10 = new Categoria {Id = 10, Nombre = "Inicial" };
            Categoria c11 = new Categoria {Id = 11, Nombre = "Intermedio" };
            Categoria c12 = new Categoria {Id = 12, Nombre = "Avanzado" };

            categorias.Add(c10);
            categorias.Add(c11);
            categorias.Add(c12);

            Estudiante e10 = new Estudiante { Id = 10, Nombre = "Luis", ApellidoPaterno = "MJ", IdCategoria = 10 };
            Estudiante e11 = new Estudiante { Id = 11, Nombre = "Adriana", ApellidoPaterno = "XJ", IdCategoria = 12 };
            Estudiante e12 = new Estudiante { Id = 12, Nombre = "Juan", ApellidoPaterno = "TJ", IdCategoria = 11 };
            Estudiante e13 = new Estudiante { Id = 13, Nombre = "Hugo", ApellidoPaterno = "XJ", IdCategoria = 11 };
            Estudiante e14 = new Estudiante { Id = 14, Nombre = "Paco", ApellidoPaterno = "PO", IdCategoria = 10 };
            Estudiante e15 = new Estudiante { Id = 15, Nombre = "María", ApellidoPaterno = "JY", IdCategoria = 12 };
            Estudiante e16 = new Estudiante { Id = 16, Nombre = "Ana", ApellidoPaterno = "MT", IdCategoria = 10 };
            Estudiante e17 = new Estudiante { Id = 17, Nombre = "Rodrigo", ApellidoPaterno = "JJ" };
            estudiantes.Add(e10);
            estudiantes.Add(e11);
            estudiantes.Add(e12);
            estudiantes.Add(e13);
            estudiantes.Add(e14);
            estudiantes.Add(e15);
            estudiantes.Add(e16);
            estudiantes.Add(e17);


            Direccion d10 = new Direccion { Id = 10, DireccionEstudiante = "Siempre Viva", IdEstudiante = 12 };
            Direccion d11 = new Direccion { Id = 11, DireccionEstudiante = "Av. Centro", IdEstudiante = 15 };
            Direccion d12 = new Direccion { Id = 12, DireccionEstudiante = "Av. Xalapa", IdEstudiante = 10 };
            Direccion d13 = new Direccion { Id = 13, DireccionEstudiante = "Enriquez", IdEstudiante = 13 };
            Direccion d14 = new Direccion { Id = 14, DireccionEstudiante = "Tuxpan", IdEstudiante = 17 };
            Direccion d15 = new Direccion { Id = 15, DireccionEstudiante = "Murillo Vidal", IdEstudiante = 14 };
            Direccion d16 = new Direccion { Id = 16, DireccionEstudiante = "Lucio", IdEstudiante = 11 };
            Direccion d17 = new Direccion { Id = 17, DireccionEstudiante = "5 de mayo", IdEstudiante = 16 };

            direcciones.Add(d10);
            direcciones.Add(d11);
            direcciones.Add(d12);
            direcciones.Add(d13);
            direcciones.Add(d14);
            direcciones.Add(d15);
            direcciones.Add(d16);
            direcciones.Add(d17);

            //Categorías
            var queryCategorias =
                                 from cat in categorias
                                  join est in estudiantes
                                  on cat.Id equals est.IdCategoria into EstudiantesDeCategoria
                                  select new
                                  {
                                      CategoriaNombre = cat.Nombre,
                                      Estudiantes = EstudiantesDeCategoria
                                };

        foreach (var item in queryCategorias)
        {
            Console.WriteLine("\nNombre de Categoría: {0}", item.CategoriaNombre);
            Console.WriteLine("Estudiantes: ");
            foreach (var e in item.Estudiantes)
            {
                Console.Write("{0}, ", e.Nombre);                    
            }
        }
        return;
   
        String query = "select Nombre from Estudiantes e join Direccion d on e.IdDireccion = d.Id";
        var queryJoin = from est in estudiantes
                                join dir in direcciones
                                on est.Id equals dir.IdEstudiante
                                //where est.Id > 10 && dir.DireccionEstudiante.StartsWith("Av. ")
                                select new {
                                    Nombre = est.Nombre,
                                    DireccionEstudiante = dir.DireccionEstudiante
                                };

            foreach (var item in queryJoin)
            {
                Console.WriteLine("Nombre: {0}, Dirección: {1}", item.Nombre, item.DireccionEstudiante);   
            }
            return;

            TSCIEntities db = new TSCIEntities();

            /*foreach(Estudiantes e in db.Estudiantes){
                Console.WriteLine("Nombre: {0}, Edad: {1}, Matrícula: {2}, Id: {3}", e.Nombre, e.Edad, e.Matricula, e.Id);
            }*/
            /*
            var query =  from e1 in db.Estudiantes
                               where e1.Edad > 27
                               select e1;

            var query1 = db.Estudiantes.Where(e1 => e1.Edad > 27);

            foreach (var item in query)
            {
                Console.WriteLine("Nombre: {0}, Edad: {1}, Matrícula: {2}, Id: {3}", item.Nombre, item.Edad, item.Matricula, item.Id);
            }

            return;






            //LINQ Para Objetos en memoria
            int[] x = new int[] { 2, 5, 10, 25, 123 };

            //Comun
            /*foreach (int item in x)
	        {
		        if (item%2==0)
	            {
                    Console.WriteLine(item);
	            }
	        }*/

            //1er -> Origen de datos
            //2do -> Definición de la consulta
            //3er -> La ejecución de la consulta
            
            //X
            //Consulta
   /*
            var itemLQ = 
                                from i in x
                                 where (i % 2 == 0)
                                 select i;

            var item1LQ = x.Where(z => (z % 2) == 0 );

            //Ejecución de la consulta
            foreach (int i in itemLQ)
            {
                Console.WriteLine(i);
            }*/

        }
    }
}
