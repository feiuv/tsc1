using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqTest
{
    class Persona{
        public String Nombre { get; set; }
        public String ApPaterno { get; set; }
        public int Edad { get; set; }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            /**Linq To Object**/

            List<Persona> personas = new List<Persona>();
            List<Persona> menores = new List<Persona>();
            //Definición de origen de datos
            personas.Add(new Persona
            {
                Nombre = "Juan",
                ApPaterno = "Perez",
                Edad = 30
            });

            personas.Add(new Persona
            {
                Nombre = "Juana",
                ApPaterno = "Lopez",
                Edad = 10
            });


            personas.Add(new Persona
            {
                Nombre = "Juana",
                ApPaterno = "Lopez",
                Edad = 21
            });
            
            personas.Add(new Persona
            {
                Nombre = "Chabelo",
                ApPaterno = "Lopez",
                Edad = 687
            });


            //opción 1
            /*
            foreach (Persona ps in personas)
            {
                if (ps.Edad < 20)
                {
                    menores.Add(ps);
                    Console.WriteLine(ps.Nombre);
                }
            }*/

            //opción 2
            //Definición de las consultas
            List<Persona> personasFiltro = personas.Where<Persona>(x => x.Edad < 20).ToList<Persona>();

            List<Persona> personasFiltroA = (from p in personas 
                                             where p.Edad < 20
                                             select p).ToList<Persona>();

            foreach (Persona tmp in personasFiltro)
            {
                Console.WriteLine("Nombre : {0}", tmp.Nombre);
            }
            
            /**Linq to SQL**/
            //DB
            LinqTest.TSCIEntities db = new TSCIEntities();
            Console.WriteLine("*********************");
            
            foreach(LinqTest.Estudiantes e in db.Estudiantes){
                Console.WriteLine("Nombre : {0}", e.Nombre);
            }




            /*
            Console.WriteLine("Linq to Object");
            List<Persona> personas = new List<Persona>();
            personas.Add(new Persona { 
                Nombre = "Juan",
                ApPaterno = "Perez",
                Edad = 23
            });

            personas.Add(new Persona
            {
                Nombre = "Pedro",
                ApPaterno = "Jiménez",
                Edad = 8
            });

            var lista0 = personas.Where<Persona>(x => x.Edad > 15).ToList<Persona>();
            var lista1 = from p in personas
                        where p.Edad > 10 
                        select p;

            foreach(var p in lista1)
            {
                Console.WriteLine("Nombre: {0}", p.Nombre);
                Console.WriteLine("App: {0}", p.ApPaterno);
                Console.WriteLine("Edad {0}", p.Edad);
            }

            Console.WriteLine("Linq to SQL");

            LinqTest.TSCIEntities entidades = new TSCIEntities();

            var lista2 = entidades.Estudiantes.Where<LinqTest.Estudiantes>(x => x.Edad > 15).ToList<LinqTest.Estudiantes>();
            var lista3 = from p in entidades.Estudiantes
                         where p.Edad > 15
                         select p;*/
        }
    }
}
