using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BioPM.ClassObjects
{
    public class ComDevEvent:DatabaseFactory
    {
        public static List<object[]> GetComdevEvent()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CE.EVTNM, CE.EVTMT
                            FROM trrcd.COMDEV_EVENT CE 
                            ORDER BY CE.EVTID ASC;";
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

        public static List<object[]> GetTargetComdevEvent(string evtid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CE.EVTNM, RK.CPYNM, CT.PRLVL
                            FROM trrcd.COMDEV_EVENT_TARGET CT, trrcd.COMDEV_EVENT CE, trrcd.REFERENSI_KOMPETENSI RK
                            WHERE CE.EVTID=CT.EVTID AND RK.CPYID=CT.CPYID
                            AND CT.EVTID='" + evtid +"' ORDER BY CE.EVTID ASC;";
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