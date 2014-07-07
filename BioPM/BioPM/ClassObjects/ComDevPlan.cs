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
            string sqlCmd = @"INSERT INTO trrcd.COMDEV_PLAN (BEGDA, ENDDA, RECID, PERNR, EVTID, EVTMH, EVTCO, CHGDT, CHUSR)
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
            string sqlCmd = @"INSERT INTO trrcd.COMDEV_PLAN_STATUS (BEGDA, ENDDA, RECID, APVST, APVPR, CHGDT, CHUSR)
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
            string sqlCmd = @"SELECT CP.RECID, CE.EVTNM, CP.EVTMH, CP.EVTCO, CS.APVST
                            FROM trrcd.COMDEV_PLAN CP WITH(INDEX(COMDEV_PLAN_IDX_BEGDA_ENDDA_ID)), trrcd.COMDEV_PLAN_STATUS CS WITH(INDEX(COMDEV_PLAN_STATUS_IDX_BEGDA_ENDDA_ID)), trrcd.COMDEV_EVENT CE WITH(INDEX(COMDEV_EVENT_IDX_BEGDA_ENDDA_ID))
                            WHERE CP.BEGDA <= GETDATE() AND CP.ENDDA >= GETDATE()
                            AND CS.BEGDA <= GETDATE() AND CS.ENDDA >= GETDATE()
                            AND CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE()
                            AND CP.RECID=CS.RECID AND CP.EVTID=CE.EVTID AND CP.PERNR='" + pernr + "' ORDER BY CP.RECID DESC;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                List<object[]> batchs = new List<object[]>();
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString() };
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
            string sqlCmd = @"SELECT CP.RECID, CE.EVTNM, CP.EVTMH, CP.EVTCO, CS.APVST, UD.CNAME
                            FROM trrcd.COMDEV_PLAN CP WITH(INDEX(COMDEV_PLAN_IDX_BEGDA_ENDDA_ID)), trrcd.COMDEV_PLAN_STATUS CS WITH(INDEX(COMDEV_PLAN_STATUS_IDX_BEGDA_ENDDA_ID)), trrcd.COMDEV_EVENT CE WITH(INDEX(COMDEV_EVENT_IDX_BEGDA_ENDDA_ID)), bioumum.USER_DATA UD
                            WHERE CP.BEGDA <= GETDATE() AND CP.ENDDA >= GETDATE()
                            AND CS.BEGDA <= GETDATE() AND CS.ENDDA >= GETDATE()
                            AND CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE()
                            AND UD.PERNR=CP.PERNR
                            AND CP.RECID=CS.RECID AND CP.EVTID=CE.EVTID AND CS.APVST='" + status + "' ORDER BY CP.RECID DESC;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                List<object[]> batchs = new List<object[]>();
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString() };
                    batchs.Add(values);
                }
                return batchs;
            }
            finally
            {
                conn.Close();
            }
        }

        public static object[] GetComdevPlanById(string recid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CP.RECID, CP.EVTID, CP.EVTMH, CP.EVTCO, CS.APVST
                            FROM trrcd.COMDEV_PLAN CP WITH(INDEX(COMDEV_PLAN_IDX_BEGDA_ENDDA_ID)), trrcd.COMDEV_PLAN_STATUS CS WITH(INDEX(COMDEV_PLAN_STATUS_IDX_BEGDA_ENDDA_ID))
                            WHERE CP.BEGDA <= GETDATE() AND CP.ENDDA >= GETDATE()
                            AND CS.BEGDA <= GETDATE() AND CS.ENDDA >= GETDATE()
                            AND CP.RECID=CS.RECID AND CP.EVTID=CE.EVTIDAND CP.RECID='" + recid + "';";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                object[] data = null;
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString() };
                    data=values;
                }
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public static object[] GetComdevPlanStatusById(string recid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CS.APVID, CS.RECID, CS.APVPR, CS.APVST, CP.EVTMH, CP.EVTCO
                            FROM trrcd.COMDEV_PLAN_STATUS CS WITH(INDEX(COMDEV_PLAN_STATUS_IDX_BEGDA_ENDDA_ID)), trrcd.COMDEV_PLAN CP WITH(INDEX(COMDEV_PLAN_IDX_BEGDA_ENDDA_ID))
                            WHERE CS.BEGDA <= GETDATE() AND CS.ENDDA >= GETDATE()
                            AND CS.BEGDA <= GETDATE() AND CS.ENDDA >= GETDATE()
                            AND CP.RECID=CS.RECID AND CS.RECID='" + recid + "' ORDER BY CP.RECID DESC;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                object[] data = null;
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString() };
                    data = values;
                }
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public static int GetComDevPlanMaxID()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT MAX(RECID) FROM trrcd.COMDEV_PLAN";
            SqlCommand cmd = GetCommand(conn, sqlCmd);
            string id = "0";
            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0)) id = reader[0].ToString() + "";
                }
                return Convert.ToInt16(id);
            }
            finally
            {
                conn.Close();
            }
        }
        
    }
}