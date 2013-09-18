using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
          /* RH.Controller.EstudianteController c = new RH.Controller.EstudianteController();
           FrameworkTSCI.Domain.Estudiante e = new FrameworkTSCI.Domain.Estudiante{ Nombre = "Ronaldo", ApP = "Hernandez", ApM = "MC", Matricula = "4232343", Edad = 12 };
           c.Add(e);
          */
           Assembly asm = Assembly.LoadFrom(@"C:\Users\servkey\Google Drive\Documentos\FEI\Cursos\5_Agosto13_Diciembre13\TSCI\repository\tsc1\Prácticas\Práctica7-DBNet\FrameworkTSCI\FrameworkTSCI\bin\Debug\FrameworkTSCI.dll");
           Type t = asm.GetType("FrameworkTSCI.Domain.Estudiante");
          
           PropertyInfo[] properties = t.GetProperties();
           List<object> parametros = new List<object>();
           foreach (var i in properties)
           {
               object tmp = Tipo(i.Name, i.PropertyType.FullName);

               parametros.Add(tmp);
           }
      
           
           object[] obj = parametros.ToArray();
           
           Object o1 = Activator.CreateInstance(t, obj);

           Assembly rh = Assembly.LoadFrom(@"C:\Users\servkey\Google Drive\Documentos\FEI\Cursos\5_Agosto13_Diciembre13\TSCI\repository\tsc1\Prácticas\Práctica7-DBNet\FrameworkTSCI\RH\bin\Debug\RH.dll");
           Type t1 = rh.GetType("RH.Controller.EstudianteController");
           Object o2 = Activator.CreateInstance(t1, null);
           MethodInfo mi = t1.GetMethod("Add");
           mi.Invoke(o2, new object[]{o1});
         }

        public static object Tipo(String name, String type)
        {
            object o = null;
            switch (type)
            {
                case "System.String":
                    o = "Luis";
                    break;
                case "System.Int32":
                    o = 3;
                    break;
            }
            return o;
        }
    }
}
