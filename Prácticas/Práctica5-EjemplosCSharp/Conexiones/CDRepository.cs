using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FrameworkTSCI.Util;

namespace ProoOfConceptWF1.Model
{
    class CDRepository:Operation<CD>
    {
        public void Add(CD element)
        {              
            string query = String.Format("insert into cds values (NULL, '{0}','{1}','{2}','{3}',{4},{5});", element.Title, element.Artist, element.Country, element.Company, element.Price, element.Year);
            //string query = String.Format("insert into TblCds values ('{0}');", element.Title);
            MSConexion con = new MSConexion();
            //SSConexion con = new SSConexion();
            con.NonQuery(query);   
        }

        public void Delete(CD element)
        {
            throw new NotImplementedException();
        }

        public void Update(CD element)
        {
            throw new NotImplementedException();
        }

        public CD FindById(int id)
        {
            //  throw new NotImplementedException();
            CD disco = new CD();

            
            /*string query = "select * from cds where id = {0};";
            query = String.Format(query, id);
            MSConexion con = new MSConexion();
            DataSet dr = con.Query(query, "cds");

            disco = dr.Tables[0].Rows.Cast<DataRow>().
                Select(
                        x =>

                        new CD
                        {
                            Id = Int32.Parse(x[0].ToString()),
                            Title = x[1].ToString(),
                            Artist = x[2].ToString(),
                            Country = x[3].ToString(),
                            Company = x[4].ToString(),
                            Price = Double.Parse(x[5].ToString()),
                            Year = Int32.Parse(x[6].ToString())
                        }
            ).ToList<CD>()[0];            */
            
            string query = "select * from cds where id={0};";
            query = String.Format(query, id);
            MSConexion con = new MSConexion();
            MySql.Data.MySqlClient.MySqlDataReader dr = con.Query(query);

            if (dr.Read())
            {
                disco.Id = Int32.Parse(dr[0].ToString());
                disco.Title = dr[1].ToString();
                disco.Artist = dr[2].ToString();
                disco.Country = dr[3].ToString();
                disco.Company = dr[4].ToString();
                disco.Price = Double.Parse(dr[5].ToString());
                disco.Year = Int32.Parse(dr[6].ToString());        
               
            }
            dr.Close();
            return disco;
        }

        public List<CD> FindByAll()
        {
            List<CD> discos = new List<CD>();
            string query = "select * from cds;";

            MSConexion con = new MSConexion();
            DataSet dr = con.Query(query,"cds");
            
            discos = dr.Tables[0].Rows.Cast<DataRow>().
                Select(
                        x =>
                
                        new CD{ 
                           Id = Int32.Parse(x[0].ToString()),
                           Title = x[1].ToString(),
                           Artist = x[2].ToString(),
                           Country = x[3].ToString(),
                           Company = x[4].ToString(),
                           Price = Double.Parse(x[5].ToString()),
                           Year = Int32.Parse(x[6].ToString())
                        }
            ).ToList<CD>();            

            return discos;            
        }

        public int Count()
        {
            MSConexion con = new MSConexion();
            return con.ExcecuteScalar("select count(*) from cds;");
        }

        public void AddSP(CD cd)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Nombre", cd.Title);
            parameters[1] = new SqlParameter("@Output", -1);
            parameters[1].Direction = ParameterDirection.Output;

            SSConexion con = new SSConexion();
            con.ExecuteStoredProcedure("AddCD", parameters);           
        }
    }
}
