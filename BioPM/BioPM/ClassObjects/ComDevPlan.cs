using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BioPM.ClassObjects
{
    public class ComDevPlan:DatabaseFactory
    {
        public static List<object[]> GetComdevPlanByUsername(string pernr)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CP.EVTNM, CP.EVTMH, CP.EVTCO, CS.APVST
                            FROM trrcd.COMDEV_PLAN CP, trrcd.COMDEV_PLAN_STATUS CS 
                            WHERE CP.RECID=CS.RECID AND CP.PERNR='"+ pernr +"' ORDER BY CP.RECID DESC;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                List<object[]> batchs = new List<object[]>();
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString() };
                    batchs.Add(values);
                }
                return batchs;
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<object[]> GetComdevPlanByStatus(string status)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CP.EVTNM, CP.EVTMH, CP.EVTCO, CS.APVST
                            FROM trrcd.COMDEV_PLAN CP, trrcd.COMDEV_PLAN_STATUS CS 
                            WHERE CP.RECID=CS.RECID AND CS.APVST='" + status + "' ORDER BY CP.RECID DESC;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                List<object[]> batchs = new List<object[]>();
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString() };
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