using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkTSCI.Base;
using FrameworkTSCI.Domain;
using FrameworkTSCI.Conexion;

namespace RH.Controller
{
    public class EstudianteController:Controller<Estudiante>
    {
        MSSQLConexion conexion = new MSSQLConexion();
        MySQLConexion conexionMysql = new MySQLConexion();

        public void Add(Estudiante e)
        {
            //	INSERT INTO Estudiantes (Nombre,ApP,ApM,Matricula,Edad) VALUES ('Ana','Olmedo', 'Jmx', 'S044109', 59);
            //String inser = "INSERT INTO Estudiantes (Nombre,ApP,ApM,Matricula,Edad) VALUES ('" + e.Nombre + "', '" + e.ApP + "','" + e.Matricula + "'," + e.Edad + ");";
            String comando = String.Format("INSERT INTO Estudiantes (Nombre,ApP,ApM,Matricula,Edad,IdUsuario) VALUES ('{0}','{1}', '{2}', '{3}', {4}, 1);", e.Nombre, e.ApP, e.ApM, e.Matricula, e.Edad);
            conexion.NonQuery(comando);
        }

        public void Delete(Estudiante e)
        {
            //	INSERT INTO Estudiantes (Nombre,ApP,ApM,Matricula,Edad) VALUES ('Ana','Olmedo', 'Jmx', 'S044109', 59);
             try{
                String comando = String.Format("DELETE FROM Estudiantes WHERE Id = {0}", e.Id);
                conexion.NonQuery(comando);
            }
            catch
            {
            }
        }
                     
        public List<Estudiante> GetAll()
        {
            throw new NotImplementedException();
        }

        public Estudiante GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
