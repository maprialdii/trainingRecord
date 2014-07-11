using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BioPM.Controller.Database
{
    public class DatabaseSql
    {
	public static string GetDbConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetDbConnectionString());
        }

        public static SqlCommand GetCommand()
        {
            return new SqlCommand();
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