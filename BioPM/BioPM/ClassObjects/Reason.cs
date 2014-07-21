using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BioPM.ClassObjects
{
    public class Reason:DatabaseFactory
    {
        public static void InsertReason(string PERNR, string ACTPG, string REASN)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string maxdate = DateTime.MaxValue.ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"INSERT INTO trrcd.REASON (BEGDA, ENDDA, PERNR, ACTPG, REASN)
                            VALUES ('" + date + "','" + maxdate + "','" + PERNR + "','" + ACTPG + "','" + REASN + "');";

            SqlCommand cmd = DatabaseFactory.GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}