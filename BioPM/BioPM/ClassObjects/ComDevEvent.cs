using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BioPM.ClassObjects
{
    public class ComDevEvent:DatabaseFactory
    {
        public static void InsertComDevEvent(string EVTID, string EVTNM, string EMTID, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string maxdate = DateTime.MaxValue.ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"INSERT INTO trrcd.COMDEV_EVENT (BEGDA, ENDDA, EVTID, EVTNM, EMTID, CHUSR, CHGDT)
                            VALUES ('" + date + "','" + maxdate + "','" + EVTID + "','" + EVTNM + "','" + EMTID + "','" + CHUSR + "','" + date + "');";

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

        public static void UpdateComDevEvent(string EVTID, string EVTNM, string EMTID, string USRDT)
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
                InsertComDevEvent(EVTID, EVTNM, EMTID, USRDT);
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

        public static List<object[]> GetAllComdevEvent()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CE.EVTID, CE.EVTNM, EM.EVTMT
                            FROM trrcd.COMDEV_EVENT CE, trrcd.EVENT_METHOD EM
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

        public static List<object[]> GetTargetComdevEvent(string evtid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CE.EVTID, CE.EVTNM, RK.CPYNM, CT.PRLVL
                            FROM trrcd.COMDEV_EVENT_TARGET CT, trrcd.COMDEV_EVENT CE, trrcd.REFERENSI_KOMPETENSI RK
                            WHERE CE.EVTID=CT.EVTID AND RK.CPYID=CT.CPYID
                            AND CT.BEGDA <= GETDATE() AND CT.ENDDA >= GETDATE()
                            AND CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE()
                            AND RK.BEGDA <= GETDATE() AND RK.ENDDA >= GETDATE()
                            AND CT.EVTID='" + evtid +"' ORDER BY CE.EVTID ASC;";
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

        public static List<object[]> GetComdevEventById(string evtid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CE.EVTID, CE.EVTNM, EM.EMTNM
                            FROM trrcd.COMDEV_EVENT CE, trrcd.EVENT_METHOD EM
                            WHERE CE.EMTID = EM.EMTID
                            AND CM.BEGDA <= GETDATE() AND CM.ENDDA >= GETDATE()
                            AND CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE()
                            AND CE.EVTID='" + evtid + "'ORDER BY CE.EVTID ASC;";
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
    }
}