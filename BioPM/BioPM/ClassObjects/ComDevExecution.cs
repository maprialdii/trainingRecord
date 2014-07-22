using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BioPM.ClassObjects
{
    public class ComDevExecution:DatabaseFactory
    {
        public static void InsertComDevExecution(string EXCID, string PERNR, string EVTID, string TITLE, string BATCH, string PMBCR, string EXCCO, string INSTI, string ADRIN, string CITIN, string COUIN, string CRTFL, string SCORE, string CHUSR, string BEGDA, string ENDDA, string RECID)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string maxdate = DateTime.MaxValue.ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"INSERT INTO trrcd.COMDEV_EVENT_EXECUTION (BEGDA, ENDDA, EXCID, PERNR, EVTID, TITLE, BATCH, PMBCR, EXCCO, INSTI, ADRIN, CITIN, COUIN, CRTFL, SCORE, CHGDT, CHUSR, RECID)
                            VALUES ('" + BEGDA + "','" + ENDDA + "'," + EXCID + ",'" + PERNR + "'," + EVTID + ",'" + TITLE + "','" + BATCH + "','" + PMBCR + "'," + EXCCO + ",'" + INSTI + "','" + ADRIN + "','" + CITIN + "','" + COUIN + "','" + CRTFL + "'," + SCORE + ",'" + date + "','" + CHUSR + "','" + RECID + "');";

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

        public static void UpdateComDevExecution(string EXCID, string PERNR, string EVTID, string TITLE, string BATCH, string PMBCR, string EXCCO, string INSTI, string ADRIN, string CITIN, string COUIN, string CRTFL, string SCORE, string CHUSR, string BEGDA, string ENDDA)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.COMDEV_EVENT_EXECUTION SET EVTID=" + EVTID + ",  TITLE = '" + TITLE + "',  BATCH = '" + BATCH + "',  PMBCR = '" + PMBCR + "',  EXCCO = '" + EXCCO + "',  INSTI = '" + INSTI + "',  ADRIN = '" + ADRIN + "',  CITIN = '" + CITIN + "',  COUIN = '" + COUIN + "',  CRTFL = '" + CRTFL + "',  SCORE = '" + SCORE + "',  BEGDA = '" + BEGDA + "',  ENDDA = '" + ENDDA + "',  CHGDT = '" + date + "', CHUSR = '" + CHUSR + "' WHERE (EXCID = " + EXCID + ")";

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

        public static void DeleteComDevExecution(string excid,  string chusr)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"DELETE from trrcd.COMDEV_EVENT_EXECUTION WHERE (EXCID = " + excid + ")";

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

        public static List<object[]> GetComdevExecutionByUserId(string pernr)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CE.EXCID, CV.EVTNM, CE.TITLE, CE.BATCH, CE.PMBCR, CE.INSTI, CE.BEGDA, CE.ENDDA, CE.CRTFL, CE.SCORE, CE.EXCCO
                            FROM trrcd.COMDEV_EVENT_EXECUTION CE WITH(INDEX(COMDEV_EVENT_EXECUTION_IDX_BEGDA_ENDDA_ID)), trrcd.COMDEV_EVENT CV WITH(INDEX(COMDEV_EVENT_IDX_BEGDA_ENDDA_ID))
                            WHERE CV.EVTID=CE.EVTID 
                            AND CV.BEGDA <= GETDATE() AND CV.ENDDA >= GETDATE() AND CE.CRTFL!=''
                            AND CE.PERNR='" + pernr + "' ORDER BY CE.EXCID DESC;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                List<object[]> batchs = new List<object[]>();
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString() };
                    batchs.Add(values);
                }
                return batchs;
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<object[]> GetComdevExecutionByPosition(string pernr)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT DISTINCT CE.EXCID, CE.PERNR, UD.CNAME, CE.TITLE, CE.BATCH, CV.EVTNM, UD.PRPOS
                            FROM trrcd.COMDEV_EVENT_EXECUTION CE, bioumum.USER_DATA UD, trrcd.COMDEV_EVENT CV
                            WHERE UD.PERNR=CE.PERNR AND CV.EVTID=CE.EVTID AND CE.EXCID NOT IN
                            (SELECT DISTINCT EXCID FROM trrcd.SURVEY_ANSWERS WHERE PRMID<=7 AND PRMID>=1)
                            AND CV.BEGDA <= GETDATE() AND CV.ENDDA >= GETDATE()
                            AND UD.PRORG=(SELECT PRORG FROM bioumum.USER_DATA WHERE PERNR='"+pernr+"') AND CE.PERNR!='"+pernr+"';";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                List<object[]> batchs = new List<object[]>();
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString() };
                    batchs.Add(values);
                }
                return batchs;
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<object[]> GetComdevExecution()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT DISTINCT CE.EXCID, CE.PERNR, UD.CNAME, CE.TITLE, CE.BATCH
                            FROM trrcd.COMDEV_EVENT_EXECUTION CE WITH(INDEX(COMDEV_EVENT_EXECUTION_IDX_BEGDA_ENDDA_ID)), trrcd.SURVEY_ANSWERS SA, bioumum.USER_DATA UD
                            WHERE CE.EXCID=SA.EXCID AND CE.PERNR=UD.PERNR
                            AND SA.BEGDA <= GETDATE() AND SA.ENDDA >= GETDATE()
                            AND SA.ANSST='Waiting for Approval' ORDER BY CE.EXCID DESC;";
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

        public static object[] GetComdevExecutionById(string excid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CE.EXCID, CE.EVTID, CV.EVTNM, CE.TITLE, CE.BATCH, CE.PMBCR, CE.INSTI, CE.BEGDA, CE.ENDDA, CE.CRTFL, CE.SCORE, CE.ADRIN, CE.CITIN, CE.COUIN, CE.EXCCO, CE.PERNR
                            FROM trrcd.COMDEV_EVENT_EXECUTION CE WITH(INDEX(COMDEV_EVENT_EXECUTION_IDX_BEGDA_ENDDA_ID)), trrcd.COMDEV_EVENT CV WITH(INDEX(COMDEV_EVENT_IDX_BEGDA_ENDDA_ID))
                            WHERE CV.EVTID=CE.EVTID 
                            AND CV.BEGDA <= GETDATE() AND CV.ENDDA >= GETDATE()
                            AND CE.EXCID=" + excid + ";";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                object[] data = null;
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString() };
                    data = values;
                }
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public static object[] GetTotalHoursExecution(string pernr)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT SUM(DATEDIFF(day,CE.BEGDA, CE.ENDDA))*8 AS TOTAL_JAM
                            FROM trrcd.COMDEV_EVENT_EXECUTION CE
                            WHERE PERNR='" + pernr + "';";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                object[] data = null;
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString() };
                    data = values;
                }
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public static object[] GetUnplannedExecution(string pernr)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT COUNT(*) AS DI_LUAR_RENCANA 
                            FROM trrcd.COMDEV_EVENT_EXECUTION
                            WHERE PERNR='" + pernr + "' AND RECID IS NULL;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                object[] data = null;
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString() };
                    data = values;
                }
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public static object[] GetPlannedExecution(string pernr)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT COUNT(*) AS SESUAI_RENCANA 
                            FROM trrcd.COMDEV_EVENT_EXECUTION
                            WHERE PERNR='" + pernr + "' AND RECID IS NOT NULL;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                object[] data = null;
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString() };
                    data = values;
                }
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public static object[] GetDetailInstitution(string excid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CE.INSTI, CE.ADRIN, CE.CITIN, CE.COUIN
                            FROM trrcd.COMDEV_EVENT_EXECUTION CE WITH(INDEX(COMDEV_EVENT_EXECUTION_IDX_BEGDA_ENDDA_ID))
                            WHERE CE.EXCID=" + excid + " ORDER BY CE.EXCID DESC;";
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



        public static int GetComDevExecutionMaxID()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT MAX(EXCID) FROM trrcd.COMDEV_EVENT_EXECUTION";
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