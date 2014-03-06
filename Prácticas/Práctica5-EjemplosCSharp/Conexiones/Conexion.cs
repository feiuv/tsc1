using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrameworkTSCI.Util
{
    public interface Conexion
    {
        bool NonQuery(string query);       
        DataSet Query(string query, string table);
        int ExcecuteScalar(string query);
    }
}
