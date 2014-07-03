using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BioPM.ClassObjects
{
    public class EventMethod:DatabaseFactory
    {
        public static void InsertEventMethod(string EMTID, string EMTNM, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string maxdate = DateTime.MaxValue.ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"INSERT INTO trrcd.EVENT_METHOD (BEGDA, ENDDA, EMTID, EMTNM, CHGDT, CHUSR)
                            VALUES ('" + date + "','" + maxdate + "'," + EMTID + ",'" + EMTNM + "','" + date + "','" + CHUSR + "');";

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

        public static void UpdateEventMethod(string EMTID, string EMTNM, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.EVENT_METHOD SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + CHUSR + "' WHERE (EMTID = " + EMTID + " AND BEGDA <= GETDATE() AND ENDDA >= GETDATE()";

            SqlCommand cmd = DatabaseFactory.GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                InsertEventMethod(EMTID, EMTNM, CHUSR);
            }
        }

        public static void DeleteEventMethod(string emtid, string usrdt)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.EVENT_METHOD SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + usrdt + "' WHERE (EMTID = " + emtid + " AND BEGDA <= GETDATE() AND ENDDA >= GETDATE()";

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
        public static List<object[]> GetAllEventMethod()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT EM.EMTID, EM.EMTNM
                            FROM trrcd.EVENT_METHOD EM
                            WHERE EM.BEGDA <= GETDATE() AND EM.ENDDA >= GETDATE()
                            ORDER BY EM.EMTID ASC;";
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

        public static List<object[]> GetEventMethodById(string emtid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT EM.EMTID, EM.EMTNM
                            FROM trrcd.EVENT_METHOD EM
                            WHERE EM.BEGDA <= GETDATE() AND EM.ENDDA >= GETDATE()
                            AND EM.EMTID='" + emtid + "' ORDER BY EM.EMTID ASC;";
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