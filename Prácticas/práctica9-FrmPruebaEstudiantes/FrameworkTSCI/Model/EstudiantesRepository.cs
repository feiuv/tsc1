using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkTSCI.Model
{
    public class EstudiantesRepository: Repository<Estudiante>
    {

        Conexion.MSSQLConexion conexion = new Conexion.MSSQLConexion();
        public void Add(Estudiante e)
        {

            //e.Nombre + "'" + e.ApellidoPaterno + "'"
            //Console.WriteLine("adasdasd");
            //1+2131+23+8
            conexion.NonQuery("insert into estudiantes values();");
        }

        public void Delete(Estudiante e)
        {
            //......
        }

        public Estudiante GetById(int id)
        {
            return null;
        }
    }
}
