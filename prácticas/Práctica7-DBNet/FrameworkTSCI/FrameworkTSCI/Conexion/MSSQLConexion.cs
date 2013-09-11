using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;

namespace FrameworkTSCI.Conexion
{
    public class MSSQLConexion:Conexion
    {        
        
        public MSSQLConexion()
        {                  

        }

        private string CadenaConexion()
        {        
             //SERVKEY-XPS\SQLSERVER;Initial Catalog=TSCI;Integrated Security=True
            string str = @"Data Source=SERVKEY-XPS\SQLSERVER;Initial Catalog=TSCI;User ID=tsci;Password=tsci@@~~";           
            try
            {
                //str = System.Configuration.ConfigurationManager.ConnectionStrings["ProoOfConceptWF1.Properties.Settings.DiscosSS"].ConnectionString;
            }           
            catch (Exception e)
            {
               // throw new DiscosException(e.Message);
            }
            return str;
            
        }

        public bool NonQuery(string query)
        {
            bool result = false;
            try
            {
                
                // "insert into discos values('','','',3); "
                // "update discos set nombre = '' where id  = 3; "
                // "delete from discos where id  = 3; "
                
                SqlConnection con = new SqlConnection(CadenaConexion());
                con.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = query;
                command.ExecuteNonQuery();
                
                con.Close();
                result = true;
            }
            catch (Exception e)
            {
                throw new FrameworkTSCI.ExceptionTSCI.InsertException(e);
            }
            return result;
        }



        public SqlDataReader Query(string query)
        {
            SqlDataReader result = null;

            // "insert into discos values('','','',3); "
            // "update discos set nombre = '' where id  = 3; "
            // "delete from discos where id  = 3; "
            // select  * from discos"";
            SqlConnection con = new SqlConnection(CadenaConexion());
            con.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = query;
            result = command.ExecuteReader();

            return result;
        }

        public DataSet Query(string query, string table)
        {
            DataSet result = new DataSet();
            
            // "insert into discos values('','','',3); "
            // "update discos set nombre = '' where id  = 3; "
            // "delete from discos where id  = 3; "
            SqlConnection con = new SqlConnection(CadenaConexion());
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(result, table);
            con.Close();
            return result;
        }



        public int ExcecuteScalar(string query)
        {
            int result = 0;
            SqlConnection con = new SqlConnection(CadenaConexion());
            con.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = query;
            result = Int32.Parse(command.ExecuteScalar().ToString());
            con.Close();
            return result;
        }


        public void ExecuteStoredProcedure(string query, SqlParameter[] parameters)
        {
            SqlConnection con = new SqlConnection(CadenaConexion());
            con.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = query;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);
            command.ExecuteNonQuery();

            if (command.Parameters["@Output"].Value != DBNull.Value)
            {
                int output = (int)command.Parameters["@Output"].Value;
                /*if (output == 1)
                    throw new DiscosException("No se pudo insertar el disco");*/
            }
            con.Close();
        }         
    }
}