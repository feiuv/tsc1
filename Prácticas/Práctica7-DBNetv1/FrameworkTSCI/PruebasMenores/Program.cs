using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkTSCI.Domain;
using ExtensionMetodo;
namespace PruebasMenores
{
    class Program
    {
        static void Main(string[] args)
        {
            Estudiante e = new Estudiante();
            e.Nombre = "TSCI";

            int x1 = 5;
           x1.Adicion();
            String t = "hola mundo";
            int c = t.WordCount();
            List<Estudiante> lista = new List<Estudiante>();
            
            int[] x = new int[]{1,2,3,5,10 };


            var z = x.Where<int>(y => y % 2 == 0);
           
            foreach(var z1 in z){
                Console.WriteLine("x = {0}", z1);
            }
        }
    }
}
