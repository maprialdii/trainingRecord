using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BioRMM.Controller.Database
{
    public class DatabaseFactory 
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(System.Web.Configuration.WebConfigurationManager.AppSettings["ConnectionString"].ToString());
        }

        public static SqlCommand GetCommand(SqlConnection con, string sqlCommand)
        {
            return new SqlCommand(sqlCommand, (SqlConnection)con);
        }

        public static SqlDataReader GetDataReader(SqlCommand cmd)
        {
            return cmd.ExecuteReader();
        }

        public static SqlParameter GetParameter(string parameterName, object parameterValue)
        {
            return new SqlParameter(parameterName, parameterValue);
        }

    }
}