using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BioPM.ClassObjects
{
    public class Jabatan:DatabaseFactory
    {
        public static void InsertJabatan(string PRQID, string POSID, string CPYID, string PRLVL, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string maxdate = DateTime.MaxValue.ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"INSERT INTO trrcd.POSITION_REQ (BEGDA, ENDDA, PRQID, POSID, CPYID, PRLVL, CHGDT, CHUSR)
                            VALUES ('" + date + "','" + maxdate + "'," + PRQID + ",'" + POSID + "'," + CPYID + ",'" + PRLVL + "','" + date + "','" + CHUSR + "');";

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

        public static void UpdateJabatan(string PRQID, string POSID, string CPYID, string PRLVL, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.POSITION_REQ SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + CHUSR + "' WHERE (PRQID = " + PRQID + " AND BEGDA <= GETDATE() AND ENDDA >= GETDATE())";

            SqlCommand cmd = DatabaseFactory.GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                InsertJabatan(PRQID, POSID, CPYID, PRLVL, CHUSR);
            }
        }

        public static void DeleteJabatan(string prqid, string usrdt)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.POSITION_REQ SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + usrdt + "' WHERE (PRQID = " + prqid + " AND BEGDA <= GETDATE() AND ENDDA >= GETDATE())";

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

        public static List<object[]> GetAllJabatan()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT DISTINCT UD.POSID, UD.PRPOS+' '+UD.PRORG AS POSISI
                            FROM bioumum.USER_DATA UD
                            WHERE UD.POSID IS NOT NULL AND UD.POSID!='' AND UD.PRORG!=''
                            AND UD.BEGDA <= GETDATE() AND UD.ENDDA >= GETDATE()
                            ORDER BY UD.POSID ASC;";
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

        public static List<object[]> GetKualifikasiJabatan(string posid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT DISTINCT PR.PRQID, RK.PRMNM, PR.PRLVL, UD.PRPOS+' '+UD.PRORG AS POSISI
                            FROM BIOFARMA.bioumum.USER_DATA UD, BIOFARMA.trrcd.POSITION_REQ PR WITH(INDEX(POSITION_REQ_IDX_BEGDA_ENDDA_ID)), BIOFARMA.bioumum.PARAMETER RK
                            WHERE UD.POSID IS NOT NULL AND UD.POSID!='' AND RK.PRMID=PR.CPYID AND UD.POSID=PR.POSID
                            AND UD.BEGDA <= GETDATE() AND UD.ENDDA >= GETDATE()
                            AND PR.BEGDA <= GETDATE() AND PR.ENDDA >= GETDATE()
                            AND RK.BEGDA <= GETDATE() AND RK.ENDDA >= GETDATE()
                            AND PR.POSID='" + posid +"' ORDER BY PR.PRQID ASC;";
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

        public static object[] GetKualifikasiJabatanById(string prqid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT PR.PRQID, PR.POSID, PR.CPYID, PR.PRLVL
                            FROM trrcd.POSITION_REQ PR WITH(INDEX(POSITION_REQ_IDX_BEGDA_ENDDA_ID))
                            WHERE PR.BEGDA <= GETDATE() AND PR.ENDDA >= GETDATE()
                            AND PR.PRQID=" + prqid + "  ORDER BY PR.POSID ASC;";
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

        public static object[] GetKualifikasiJabatanByPositionAndCompetency(string posid, string cpyid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT PR.PRQID, PR.POSID, PR.CPYID, PR.PRLVL
                            FROM trrcd.POSITION_REQ PR WITH(INDEX(POSITION_REQ_IDX_BEGDA_ENDDA_ID))
                            WHERE PR.BEGDA <= GETDATE() AND PR.ENDDA >= GETDATE()
                            AND PR.POSID='" + posid + "' AND PR.CPYID=" + cpyid + "  ORDER BY PR.POSID ASC;";
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

        public static int GetPositionRequirementMaxID()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT MAX(PRQID) FROM trrcd.POSITION_REQ";
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