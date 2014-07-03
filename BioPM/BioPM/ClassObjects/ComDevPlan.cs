using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BioPM.ClassObjects
{
    public class ComDevPlan:DatabaseFactory
    {
        public static void InsertComDevPlan(string RECID, string PERNR, string EVTID, string EVTMH, string EVTCO, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string maxdate = DateTime.MaxValue.ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"INSERT INTO trrcd.COMDEV_PLAN (BEGDA, ENDDA, RECID, PERNR, EVTID, EVTMH, EVTCO, CHUSR, CHGDT)
                            VALUES ('" + date + "','" + maxdate + "'," + RECID + ",'" + PERNR + "'," + EVTID + ",'" + EVTMH + "','" + EVTCO + "','" + date + "','" + CHUSR + "');";

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

        public static void InsertComDevPlanStatus(string RECID, string APVST, string APVPR, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string maxdate = DateTime.MaxValue.ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"INSERT INTO trrcd.COMDEV_PLAN_STATUS (BEGDA, ENDDA, RECID, APVST, APVPR, CHUSR, CHGDT)
                            VALUES ('" + date + "','" + maxdate + "'," + RECID + ",'" + APVST + "','" + APVPR + "','" + date + "','" + CHUSR + "');";

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

        public static void UpdateComDevPlan(string RECID, string PERNR, string EVTID, string EVTMH, string EVTMT, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.COMDEV_PLAN SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + CHUSR + "' WHERE (RECID = " + RECID + " AND BEGDA <= GETDATE() AND ENDDA >= GETDATE()";

            SqlCommand cmd = DatabaseFactory.GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                InsertComDevPlan(RECID, PERNR, EVTID, EVTMH, EVTMT, CHUSR);
            }
        }

        public static void UpdateComDevPlanStatus(string RECID, string APVST, string APVPR, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.COMDEV_PLAN_STATUS SET CHGDT = '" + date + "', APVST = '" + APVST + "', APVPR = '" + APVPR +  "', CHUSR = '" + CHUSR + "' WHERE (RECID = " + RECID + " AND BEGDA <= GETDATE() AND ENDDA >= GETDATE()";

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

        public static void DeleteComDevPlan(string recid, string chusr)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.COMDEV_PLAN SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + chusr+ "' WHERE (RECID = " + recid + " AND BEGDA <= GETDATE() AND ENDDA >= GETDATE()";

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


        public static List<object[]> GetComdevPlanByUsername(string pernr)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CP.EVTNM, CP.EVTMH, CP.EVTCO, CS.APVST
                            FROM trrcd.COMDEV_PLAN CP, trrcd.COMDEV_PLAN_STATUS CS 
                            WHERE CP.BEGDA <= GETDATE() AND CP.ENDDA >= GETDATE()
                            AND CS.BEGDA <= GETDATE() AND CS.ENDDA >= GETDATE()
                            AND CP.RECID=CS.RECID AND CP.PERNR='" + pernr +"' ORDER BY CP.RECID DESC;";
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
                            WHERE CP.BEGDA <= GETDATE() AND CP.ENDDA >= GETDATE()
                            AND CS.BEGDA <= GETDATE() AND CS.ENDDA >= GETDATE()
                            AND CP.RECID=CS.RECID AND CS.APVST='" + status + "' ORDER BY CP.RECID DESC;";
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

        public static List<object[]> GetComdevPlanById(string recid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CP.EVTNM, CP.EVTMH, CP.EVTCO, CS.APVST
                            FROM trrcd.COMDEV_PLAN CP, trrcd.COMDEV_PLAN_STATUS CS 
                            WHERE CP.BEGDA <= GETDATE() AND CP.ENDDA >= GETDATE()
                            AND CS.BEGDA <= GETDATE() AND CS.ENDDA >= GETDATE()
                            AND CP.RECID=CS.RECID AND CS.RECID='" + recid + "' ORDER BY CP.RECID DESC;";
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