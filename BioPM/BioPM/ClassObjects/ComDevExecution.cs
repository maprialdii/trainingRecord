using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BioPM.ClassObjects
{
    public class ComDevExecution:DatabaseFactory
    {
        public static List<object[]> GetComdevExecutionByUserId(string pernr)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CV.EVTNM, CE.TITLE, CE.BATCH, CE.INSTI, CE.BEGDA, CE.ENDDA, CE.CRTFL, CE.SCORE
                            FROM trrcd.COMDEV_EVENT_EXECUTION CE, trrcd.COMDEV_EVENT CV 
                            WHERE CV.EVTID=CE.EVTID AND CE.PERNR='" + pernr + "' ORDER BY CE.EVTID DESC;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                List<object[]> batchs = new List<object[]>();
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString() };
                    batchs.Add(values);
                }
                return batchs;
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<object[]> GetDetailInstitution(string evtid, string pernr)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CE.INSTI, CE.ADRIN, CE.CITIN, CE.COUIN
                            FROM trrcd.COMDEV_EVENT_EXECUTION CE 
                            WHERE CE.PERNR='" + pernr + "' AND CE.EVTID='"+ evtid +"' ORDER BY CE.EVTID DESC;";
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