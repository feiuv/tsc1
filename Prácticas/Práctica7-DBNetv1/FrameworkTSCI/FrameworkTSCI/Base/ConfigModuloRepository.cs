using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrameworkTSCI.Domain;
namespace FrameworkTSCI.Base
{
    public class ConfigModuloRepository
    {
        private FrameworkTSCI.Conexion.MSSQLConexion conexion = new Conexion.MSSQLConexion();
     
          
        public ConfigModulo GetByFields(String modulo, String forma, String campo)
        {
            ConfigModulo config = null;
            string query = "select * from ConfigModulos where modulo = '{0}' and forma = '{1}' and campo = '{2}'";
            query = String.Format(query, modulo, forma, campo);
            DataSet dr = conexion.Query(query, "ConfigModulos");

            config = dr.Tables[0].Rows.Cast<DataRow>().
                        Select(
                             x =>

                        new ConfigModulo
                        {
                            Id = Int32.Parse(x[0].ToString()),
                            Modulo = x[1].ToString(),
                            Forma = x[2].ToString(),
                            Campo = x[3].ToString(),
                            RE = x[4].ToString()
                        }
            ).ToList<ConfigModulo>()[0];
            return config;
        }

        public ConfigModulo GetById(int id)
        {
            ConfigModulo config = null;
            string query = "select * from ConfigModulos where Id = {0};";
            query = String.Format(query, id);
            DataSet dr = conexion.Query(query, "Usuarios");

            config = dr.Tables[0].Rows.Cast<DataRow>().
                        Select(
                             x =>

                        new ConfigModulo
                        {
                            Id = Int32.Parse(x[0].ToString()),
                            Modulo = x[1].ToString(),
                            Forma = x[2].ToString(),
                            Campo = x[3].ToString(),
                            RE = x[4].ToString()
                        }
            ).ToList<ConfigModulo>()[0];
            return config;
        }
    }
}
