using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace MSTech
{
    public static class Conector
    {
        
        public static SqlConnection Conexion()
        {
            string conString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(conString);
            return conexion;
        }
    }
}