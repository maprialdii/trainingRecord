using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BioPM.ClassObjects
{
    public class Survey:DatabaseFactory
    {
        public static List<object[]> GetQuestions(string type)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT PR1.PRMID, PR1.PRMNM, SUBSTRING(PRMKD, 12, 1) AS Initial
                            FROM bioumum.PARAMETER PR1
                            WHERE PR1.BEGDA <= GETDATE() AND PR1.ENDDA >= GETDATE()
                            AND PR1.PRMTY= '" + type + "';";
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

        public static List<object[]> GetSurveys()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT SR.SURID, SR.SURTL, ST.SRTNM
                            FROM trrcd.SURVEY SR, trrcd.SURVEY_TYPE ST
                            WHERE SR.BEGDA <= GETDATE() AND SR.ENDDA >= GETDATE()
                            AND ST.BEGDA <= GETDATE() AND ST.ENDDA >= GETDATE();";
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

        public static List<object[]> GetQuestionSurveys(string surid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT QS.QSTID, , ST.SRTNM
                            FROM trrcd.SURVEY SR, trrcd.QUESTION_ANSWER QA,
                            WHERE SR.BEGDA <= GETDATE() AND SR.ENDDA >= GETDATE()
                            AND ST.BEGDA <= GETDATE() AND ST.ENDDA >= GETDATE();";
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

        public static List<object[]> GetAnswersBySurvey(string excid, string kode)
        {
            int lowerBound = 0, upperBound = 0;
            SqlConnection conn = GetConnection();
            if (kode == "3")
            {
                lowerBound = 1;
                upperBound = 7;
            }
            else if (kode == "1")
            {
                lowerBound = 14;
                upperBound = 31;
            }
            string sqlCmd = @"SELECT ANSID, PRMID, VALUE
                            FROM trrcd.SURVEY_ANSWERS 
                            WHERE BEGDA <= GETDATE() AND ENDDA >= GETDATE()
                            WHERE PRMID>=" + lowerBound + " AND PRMID<=" + upperBound + " AND EXCID=" + excid + ";";
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

        public static void SubmitAnswers(string ANSID, string EXCID, string PRMID, string VALUE, string APVST, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string maxdate = DateTime.MaxValue.ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"INSERT INTO trrcd.SURVEY_ANSWERS (BEGDA, ENDDA, ANSID, EXCID, PRMID, VALUE, ANSST, PERNR ,CHUSR, CHGDT)
                            VALUES ('" + date + "','" + maxdate + "'," + ANSID + "," + EXCID + "," + PRMID + ",'" + VALUE + "','" + APVST + "','" + CHUSR + "','" + CHUSR + "','" + date + "');";

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

        public static void InsertQuestion(string ANSID, string EXCID, string PRMID, string VALUE, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string maxdate = DateTime.MaxValue.ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"INSERT INTO trrcd.SURVEY_ANSWERS (BEGDA, ENDDA, ANSID, EXCID, PRMID, VALUE, CHUSR, CHGDT)
                            VALUES ('" + date + "','" + maxdate + "'," + ANSID + ",'" + EXCID + "'," + PRMID + ",'" + VALUE + "','" + CHUSR + "','" + date + "');";

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

        public static void UpdateStatus(string EXCID, string ANSST, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.SURVEY_ANSWERS SET APVPR='" + CHUSR + "', APVDT='" + date + "', ANSST = '" + ANSST + "', CHGDT = '" + date + "', CHUSR = '" + CHUSR + "' WHERE (EXCID = '" + EXCID + "' AND PRMID<=7 AND PRMID>=1 AND BEGDA <= GETDATE() AND ENDDA >= GETDATE())";

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

        public static List<object[]> GetOptionAnswers(string qid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT PR2.PRMNM
                            FROM bioumum.PARAMETER PR1, bioumum.RELASI_PARAMETER RP, bioumum.PARAMETER PR2
                            WHERE PR1.PRMID=RP.PRMPR AND RP.PRMPR='" + qid + "' AND PR2.PRMID=RP.PRMCH;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                List<object[]> batchs = new List<object[]>();
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString() };
                    batchs.Add(values);
                }
                return batchs;
            }
            finally
            {
                conn.Close();
            }
        }

        public static object[] GetAnswerById(string excid, string prmid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT SA.PRMID, SA.VALUE
                            FROM trrcd.SURVEY_ANSWERS SA
                            WHERE SA.PRMID=" + prmid + " AND SA.EXCID="+ excid +" ORDER BY SA.ANSID ASC;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                object[] data = null;
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString() };
                    data = values;
                }
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public static object[] GetRekapSurvey(string evtid, string batch, string prmid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"select ce.evtid, SA.prmid, CE.EVTNM, CX.BATCH,
                            nilai_4 = COUNT(CASE WHEN value=4 THEN 1 END), 
                            nilai_3 = COUNT(CASE WHEN value=3 THEN 1 END), 
                            nilai_2 = COUNT(CASE WHEN value=2 THEN 1 END), 
                            nilai_1 = COUNT(CASE WHEN value=1 THEN 1 END) 
                            from trrcd.SURVEY_ANSWERS SA, trrcd.COMDEV_EVENT CE, trrcd.COMDEV_EVENT_EXECUTION CX
                            where SA.BEGDA <= GETDATE() AND SA.ENDDA >= GETDATE()
                            and CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE()
                            and ce.evtid=" + evtid + " and cx.batch='" + batch + "'and sa.prmid=" + prmid + " and sa.EXCID=cx.EXCID and ce.EMTID=cx.EVTID group by ce.evtid, SA.prmid, CE.EVTNM, CX.BATCH;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                object[] data = null;
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString() };
                    data = values;
                }
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public static string GetJumlahJawaban(string excid, string kode)
        {
            int lowerBound=0, upperBound=0;
            String status = null;
            if (kode == "3")
            {
                lowerBound = 1;
                upperBound = 7;
            }
            else if (kode == "1")
            {
                lowerBound = 14;
                upperBound = 31;
            }
            int sum=0;
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT COUNT(ANSID) AS JUMLAH_NGISI
                            FROM trrcd.SURVEY_ANSWERS
                            WHERE PRMID>=" + lowerBound + " AND PRMID<=" + upperBound + " AND EXCID=" + excid + ";";
            SqlCommand cmd = GetCommand(conn, sqlCmd);
            string jumlah = "0";

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0)) jumlah = reader[0].ToString() + "";
                }
                sum=Convert.ToInt16(jumlah);
            }
            finally
            {
                conn.Close();
            }
            if (sum == 0)
                status = "Belum Diisi";
            else
                status = "Selesai";
            return status;
        }

        public static int GetAnswersMaxID()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT MAX(ANSID) FROM trrcd.SURVEY_ANSWERS";
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

        public static int GetNumOfQuestion(string kode)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT COUNT(PRMID) FROM bioumum.PARAMETER WHERE PRMKD='"+kode+"';";
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