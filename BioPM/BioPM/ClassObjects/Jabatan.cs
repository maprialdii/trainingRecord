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
                            VALUES ('" + date + "','" + maxdate + "'," + PRQID + "," + POSID + "," + CPYID + ",'" + PRLVL + "','" + date + "','" + CHUSR + "');";

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

        public static List<object[]> GetAllKualifikasiJabatan()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT PR.PRQID, PR.POSID, RK.CPYNM, PR.PRLVL
                            FROM trrcd.REFERENSI_KOMPETENSI RK, trrcd.POSITION_REQ PR 
                            WHERE RK.BEGDA <= GETDATE() AND RK.ENDDA >= GETDATE()
                            AND PR.BEGDA <= GETDATE() AND PR.ENDDA >= GETDATE()
                            ORDER BY PR.POSID ASC;";
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

        public static object[] GetKualifikasiJabatanById(string posid, string cpyid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT PR.PRQID, PR.POSID, RK.CPYNM, PR.PRLVL
                            FROM trrcd.REFERENSI_KOMPETENSI RK, trrcd.POSITION_REQ PR 
                            WHERE RK.BEGDA <= GETDATE() AND RK.ENDDA >= GETDATE()
                            AND PR.BEGDA <= GETDATE() AND PR.ENDDA >= GETDATE()
                            AND PR.POSID='" +posid+"' AND PR.CPYID='"+cpyid+"' ORDER BY PR.POSID ASC;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                object[] data = null;
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString() };
                    values = data;
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