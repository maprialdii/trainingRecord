using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BioPM.ClassObjects
{
    public class ComDevEvent:DatabaseFactory
    {
        public static void InsertComDevEvent(string EVTID, string EVTNM, string EMTID, string EVTGR, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string maxdate = DateTime.MaxValue.ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"INSERT INTO trrcd.COMDEV_EVENT (BEGDA, ENDDA, EVTID, EVTNM, EMTID, EVTGR, CHUSR, CHGDT)
                            VALUES ('" + date + "','" + maxdate + "'," + EVTID + ",'" + EVTNM + "'," + EMTID + ",'" + EVTGR + "','" + CHUSR + "','" + date + "');";

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

        public static void InsertComDevEventTarget(string TRGID, string EVTID, string CPYID, string PRLVL, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string maxdate = DateTime.MaxValue.ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"INSERT INTO trrcd.COMDEV_EVENT_TARGET (BEGDA, ENDDA, TRGID, EVTID, CPYID, PRLVL, CHUSR, CHGDT)
                            VALUES ('" + date + "','" + maxdate + "','" + TRGID + "','" + EVTID + "','" + CPYID + "','" + PRLVL + "','" + CHUSR + "','" + date + "');";


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

        public static void UpdateComDevEvent(string EVTID, string EVTNM, string EMTID, string EVTGR, string USRDT)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.COMDEV_EVENT SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + USRDT + "' WHERE (EVTID = '" + EVTID + "' AND BEGDA <= GETDATE() AND ENDDA >= GETDATE())";

            SqlCommand cmd = DatabaseFactory.GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                InsertComDevEvent(EVTID, EVTNM, EMTID, EVTGR, USRDT);
            }
        }

        public static void UpdateComDevEventTarget(string TRGID, string EVTID, string CPYID, string PRLVL, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.COMDEV_EVENT_TARGET SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + CHUSR + "' WHERE (TRGID = " + TRGID + " AND BEGDA <= GETDATE() AND ENDDA >= GETDATE())";

            SqlCommand cmd = DatabaseFactory.GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                InsertComDevEventTarget(TRGID, EVTID, CPYID, PRLVL, CHUSR);
            }
        }

        public static void DeleteComDevEvent(string evtid, string usrdt)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.COMDEV_EVENT SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + usrdt + "' WHERE (EVTID = '" + evtid + "' AND BEGDA <= GETDATE() AND ENDDA >= GETDATE())";

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

        public static void DeleteComDevEventTarget(string trgid, string usrdt)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.COMDEV_EVENT_TARGET SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + usrdt + "' WHERE (TRGID = " + trgid + " AND BEGDA <= GETDATE() AND ENDDA >= GETDATE())";

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

        public static List<object[]> GetAllComdevEvent()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CE.EVTID, CE.EVTNM, EM.EVTMT, CE.EVTGR
                            FROM trrcd.COMDEV_EVENT CE WITH(INDEX(COMDEV_EVENT_IDX_BEGDA_ENDDA_ID)), trrcd.EVENT_METHOD EM WITH(INDEX(EVENT_METHOD_IDX_BEGDA_ENDDA_ID))
                            WHERE CE.EMTID = EM.EMTID
                            AND EM.BEGDA <= GETDATE() AND EM.ENDDA >= GETDATE()
                            AND CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE()
                            ORDER BY CE.EVTID ASC;";
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

        public static List<object[]> GetAllTargetComdevEvent(string evtid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CT.TRGID, CE.EVTNM, RK.CPYNM, CT.PRLVL
                            FROM trrcd.COMDEV_EVENT_TARGET CT WITH(INDEX(COMDEV_EVENT_TARGET_IDX_BEGDA_ENDDA_ID)), trrcd.COMDEV_EVENT CE WITH(INDEX(COMDEV_EVENT_IDX_BEGDA_ENDDA_ID)), trrcd.REFERENSI_KOMPETENSI RK WITH(INDEX(REFERENSI_KOMPETENSI_IDX_BEGDA_ENDDA_ID))
                            WHERE CE.EVTID=CT.EVTID AND RK.CPYID=CT.CPYID
                            AND CT.BEGDA <= GETDATE() AND CT.ENDDA >= GETDATE()
                            AND CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE()
                            AND RK.BEGDA <= GETDATE() AND RK.ENDDA >= GETDATE()
                            AND CT.EVTID=" + evtid +" ORDER BY CE.EVTID ASC;";
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

        public static object[] GetComdevEventById(string evtid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CE.EVTID, CE.EVTNM, CE.EMTID, EM.EVTMT, CE.EVTGR
                            FROM trrcd.COMDEV_EVENT CE WITH(INDEX(COMDEV_EVENT_IDX_BEGDA_ENDDA_ID)), trrcd.EVENT_METHOD EM WITH(INDEX(EVENT_METHOD_IDX_BEGDA_ENDDA_ID))
                            WHERE CE.EMTID = EM.EMTID
                            AND EM.BEGDA <= GETDATE() AND EM.ENDDA >= GETDATE()
                            AND CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE()
                            AND CE.EVTID=" + evtid + "ORDER BY CE.EVTID ASC;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                object[] data = null;
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString() };
                    data=values;
                }
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public static int GetComDevEventMaxID()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT MAX(EVTID) FROM trrcd.COMDEV_EVENT";
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

        public static object[] GetComdevEventTargetById(string trgid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CT.TRGID, CT.EVTID, CE.EVTNM, CT.CPYID, RK.CPYNM, CT.PRLVL
                            FROM trrcd.COMDEV_EVENT_TARGET CT WITH(INDEX(COMDEV_EVENT_TARGET_IDX_BEGDA_ENDDA_ID)), trrcd.COMDEV_EVENT CE WITH(INDEX(COMDEV_EVENT_IDX_BEGDA_ENDDA_ID)), trrcd.REFERENSI_KOMPETENSI RK WITH(INDEX(REFERENSI_KOMPETENSI_IDX_BEGDA_ENDDA_ID))
                            WHERE CE.EVTID=CT.EVTID AND RK.CPYID=CT.CPYID
                            AND CT.BEGDA <= GETDATE() AND CT.ENDDA >= GETDATE()
                            AND CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE()
                            AND RK.BEGDA <= GETDATE() AND RK.ENDDA >= GETDATE()
                            AND CT.TRGID='" + trgid + "' ORDER BY CE.EVTID ASC;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                object[] data = null;
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), };
                    data = values;
                }
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<object[]> GetComdevEventTargetByEvent(string evtid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CT.TRGID, CT.EVTID, CE.EVTNM, RK.CPYNM, CT.PRLVL, EM.EVTMT
                            FROM trrcd.COMDEV_EVENT_TARGET CT WITH(INDEX(COMDEV_EVENT_TARGET_IDX_BEGDA_ENDDA_ID)), trrcd.COMDEV_EVENT CE WITH(INDEX(COMDEV_EVENT_IDX_BEGDA_ENDDA_ID)), trrcd.REFERENSI_KOMPETENSI RK WITH(INDEX(REFERENSI_KOMPETENSI_IDX_BEGDA_ENDDA_ID)), trrcd.EVENT_METHOD EM
                            WHERE CE.EVTID=CT.EVTID AND RK.CPYID=CT.CPYID AND CE.EMTID=EM.EMTID
                            AND CT.BEGDA <= GETDATE() AND CT.ENDDA >= GETDATE()
                            AND CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE()
                            AND RK.BEGDA <= GETDATE() AND RK.ENDDA >= GETDATE()
                            AND EM.BEGDA <= GETDATE() AND EM.ENDDA >= GETDATE()
                            AND CE.EVTID=" + evtid + " ORDER BY CE.EVTID ASC;";
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

        public static int GetComDevEventTargetMaxID()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT MAX(TRGID) FROM trrcd.COMDEV_EVENT_TARGET";
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