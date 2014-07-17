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
                            AND PR1.PRMKD LIKE '%" + type + "%';";
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

        public static void SubmitAnswers(string ANSID, string EXCID, string PRMID, string VALUE, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string maxdate = DateTime.MaxValue.ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"INSERT INTO trrcd.SURVEY_ANSWERS (BEGDA, ENDDA, ANSID, EXCID, PRMID, VALUE, USRDT, CHGDT)
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