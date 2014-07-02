using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BioPM.ClassObjects
{
    public class Jabatan:DatabaseFactory
    {
        public static List<object[]> GetKualifikasiJabatan()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT PR.POSID, RK.CPYNM, PR.PRLVL
                            FROM trrcd.REFERENSI_KOMPETENSI RK, trrcd.POSITION_REQ PR 
                            ORDER BY PR.POSID ASC;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                List<object[]> batchs = new List<object[]>();
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString() };
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