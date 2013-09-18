using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace FrameworkTSCI.Conexion
{
    public class MySQLConexion:Conexion
    {        
        
        public MySQLConexion()
        {                  

        }

        private string CadenaConexion()
        {
            string str = "server=localhost;User Id=root;password=tsci@@~~;Persist Security Info=True;database=TSCI";           
            try
            {
                //str = System.Configuration.ConfigurationManager.ConnectionStrings["DBEstudiantesConexion"].ConnectionString;
            }           
            catch (Exception e)
            {
                //throw new DiscosException(e.Message);
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
                
                MySqlConnection con = new MySqlConnection(CadenaConexion());
                con.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = con;
                command.CommandText = query;
                command.ExecuteNonQuery();
                
                con.Close();
                result = true;
            }
            catch (Exception e)
            {
               // throw new DiscosException(e.Message);
            }
            return result;
        }

        

        public MySqlDataReader Query(string query)
        {
            MySqlDataReader result = null;
            try
            {                
                // "insert into discos values('','','',3); "
                // "update discos set nombre = '' where id  = 3; "
                // "delete from discos where id  = 3; "
                MySqlConnection con = new MySqlConnection(CadenaConexion());
                con.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = con;
                command.CommandText = query;
                result = command.ExecuteReader();               
            }
            catch (Exception e)
            {
               // throw new DiscosException(e.Message);
            }
            return result;
        }

        public DataSet Query(string query, string table)
        {
            DataSet result = new DataSet();
            try
            {
                // "insert into discos values('','','',3); "
                // "update discos set nombre = '' where id  = 3; "
                // "delete from discos where id  = 3; "
                MySqlConnection con = new MySqlConnection(CadenaConexion());
                con.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
                
                adapter.Fill(result, table);
                con.Close();
            }
            catch(Exception e)
            {
               // throw new DiscosException(e.Message);
            }
            return result;
        }



        public int ExcecuteScalar(string query)
        {
            int result = 0;
            try
            {
                MySqlConnection con = new MySqlConnection(CadenaConexion());
                con.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = con;
                command.CommandText = query;
                result = Int32.Parse(command.ExecuteScalar().ToString());
                con.Close();
            }
            catch (Exception e)
            {
                //throw new DiscosException(e.Message);
            }
            return result;
        }
       
    }
}