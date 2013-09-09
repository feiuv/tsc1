using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkTSCI.Base;
using FrameworkTSCI.Domain;
using FrameworkTSCI.Conexion;

namespace RH.Controller
{
    class UsuarioController:Entity, Controller<Usuario>
    {
        MSSQLConexion conexion = new MSSQLConexion();
        MySQLConexion conexionMysql = new MySQLConexion();

        public void Add(Usuario e)
        {
            //	INSERT INTO Estudiantes (Nombre,ApP,ApM,Matricula,Edad) VALUES ('Ana','Olmedo', 'Jmx', 'S044109', 59);
            //String inser = "INSERT INTO Estudiantes (Nombre,ApP,ApM,Matricula,Edad) VALUES ('" + e.Nombre + "', '" + e.ApP + "','" + e.Matricula + "'," + e.Edad + ");";
            String comando = String.Format("INSERT INTO Usuarios (NombreDeUsuario,Password) VALUES ('{0}','{1}');", e.NombreUsuario, e.Password);
            conexion.NonQuery(comando);
        }

        public void Delete(Usuario e)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetAll()
        {
            string query = "select * from Usuarios;";
            DataSet dr = conexion.Query(query, "cds");

            List<Usuario> usuarios = dr.Tables[0].Rows.Cast<DataRow>().
                        Select(
                       
                        x =>

                        new Usuario
                        {
                            Id = Int32.Parse(x[0].ToString()),
                            NombreUsuario = x[1].ToString(),
                            Password = x[2].ToString()
                        }
            ).ToList<Usuario>();
            return usuarios; 
        }

        public Usuario GetById(int id)
        { 
            Usuario usuario = null;
            string query = "select * from Usuarios where Id = {0};";
            query = String.Format(query, id);
            DataSet dr = conexion.Query(query, "Usuarios");

            usuario = dr.Tables[0].Rows.Cast<DataRow>().
                        Select(
                             x =>

                        new Usuario
                        {
                            Id = Int32.Parse(x[0].ToString()),
                            NombreUsuario = x[1].ToString(),
                            Password = x[2].ToString()
                        }
            ).ToList<Usuario>()[0];
            return usuario;
        }

        public Usuario ValidarUsuario(String usuario, String password)
        {
            Usuario usr = null;
            string query = "select * from Usuarios where Usuario = '" + usuario + "' and password = '" + password + "'";
            DataSet dr = conexion.Query(query, "Usuarios");

            usr = dr.Tables[0].Rows.Cast<DataRow>().
                        Select(
                             x =>

                        new Usuario
                        {
                            Id = Int32.Parse(x[0].ToString()),
                            NombreUsuario = x[1].ToString(),
                            Password = x[2].ToString()
                        }
            ).ToList<Usuario>()[0];
            return usr;
        }
    }
}
