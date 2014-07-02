using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BioPM.ClassObjects
{
    public class CompetencyCatalog : DatabaseFactory
    {
        public static List<object[]> GetAllCompetency()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT RK.CPYID, RK.CPYNM
                            FROM trrcd.REFERENSI_KOMPETENSI RK ORDER BY RK.CPYID ASC;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                List<object[]> batchs = new List<object[]>();
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString() };
                    batchs.Add(values);
                }
                return batchs;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}