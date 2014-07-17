using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BioPM.ClassObjects
{
    public class CompetencyCatalog : DatabaseFactory
    {
        public static void InsertCompetency(string CPYID, string CPYKD, string CPYNM, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string maxdate = DateTime.MaxValue.ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"INSERT INTO bioumum.PARAMETER (BEGDA, ENDDA, PRMID, PRMTY, PRMKD, PRMNM, CHGDT, CHUSR)
                            VALUES ('" + date + "','" + maxdate + "'," + CPYID + ",'CM','" + CPYKD + "','" + CPYNM + "','" + date + "','" + CHUSR + "');";

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

        public static void UpdateCompetency(string CPYID, string CPYKD, string CPYNM, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE bioumum.PARAMETER SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + CHUSR + "' WHERE (CPYID = '" + CPYID + "' AND BEGDA <= GETDATE() AND ENDDA >= GETDATE())";

            SqlCommand cmd = DatabaseFactory.GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                InsertCompetency(CPYID, CPYKD, CPYNM, CHUSR);
            }
        }

        public static void DeleteCompetency(string cpyid, string usrdt)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE bioumum.PARAMETER SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + usrdt + "' WHERE (CPYID = '" + cpyid + "' AND BEGDA <= GETDATE() AND ENDDA >= GETDATE())";

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
        public static List<object[]> GetAllCompetency()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT RK.PRMID, RK.PRMKD, RK.PRMNM
                            FROM bioumum.PARAMETER RK 
                            WHERE RK.BEGDA <= GETDATE() AND RK.ENDDA >= GETDATE() AND PRMTY='CM' ORDER BY RK.PRMID ASC;";
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

        public static object[] GetCompetencyById(string prmid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT RK.PRMID, RK.PRMKD, RK.PRMNM
                            FROM bioumum.PARAMETER RK
                            WHERE RK.BEGDA <= GETDATE() AND RK.ENDDA >= GETDATE()
                            AND RK.PRMID=" + prmid + "ORDER BY RK.PRMID ASC;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                object[] data=null;
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString() };
                    data = values;
                }
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void InsertCompetencyStructure(string RLSID, string HCPID, string LCPID, string LEVEL, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string maxdate = DateTime.MaxValue.ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"INSERT INTO trrcd.RELASI_COMPETENCY (BEGDA, ENDDA, RLSID, HCPID, LCPID, LEVEL, CHUSR, CHGDT)
                            VALUES ('" + date + "','" + maxdate + "'," + RLSID + "," + HCPID + "," + LCPID + "," + LEVEL + ",'" + CHUSR + "','" + date + "');";

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

        public static void UpdateCompetencyStructure(string RLSID, string HCPID, string LCPID, string LEVEL, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.RELASI_COMPETENCY SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + CHUSR + "' WHERE (RLSID = '" + RLSID + "' AND BEGDA <= GETDATE() AND ENDDA >= GETDATE())";

            SqlCommand cmd = DatabaseFactory.GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                InsertCompetencyStructure(RLSID, HCPID, LCPID, LEVEL, CHUSR);
            }
        }
        public static void DeleteCompetencyStructure(string RLSID, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.RELASI_COMPETENCY SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + CHUSR + "' WHERE (RLSID = '" + RLSID + "' AND BEGDA <= GETDATE() AND ENDDA >= GETDATE())";

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

        public static object[] GetCompetencyStructureByID(string RLSID)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CP1.CPYNM, CP2.CPYNM, RC.LEVEL, RC.RLSID
                            FROM trrcd.REFERENSI_KOMPETENSI CP1, trrcd.REFERENSI_KOMPETENSI CP2, trrcd.RELASI_COMPETENCY RC
                            WHERE CP1.CPYID = RC.HCPID AND CP2.CPYID = RC.LCPID 
                            AND CP1.BEGDA <= GETDATE() AND CP1.ENDDA >= GETDATE() 
                            AND CP2.BEGDA <= GETDATE() AND CP2.ENDDA >= GETDATE()  
                            AND RC.BEGDA <= GETDATE() AND RC.ENDDA >= GETDATE()
                            AND RC.RLSID = " + RLSID + ";";

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

        public static List<object[]> GetCompetencyStructures()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CP1.CPYNM, CP2.CPYNM, RC.LEVEL, RC.RLSID
                            FROM biofarma.trrcd.REFERENSI_KOMPETENSI CP1, biofarma.trrcd.REFERENSI_KOMPETENSI CP2, biofarma.trrcd.RELASI_COMPETENCY RC
                            WHERE CP1.CPYID = RC.HCPID AND CP2.CPYID = RC.LCPID 
                            AND CP1.BEGDA <= GETDATE() AND CP1.ENDDA >= GETDATE() 
                            AND CP2.BEGDA <= GETDATE() AND CP2.ENDDA >= GETDATE()  
                            AND RC.BEGDA <= GETDATE() AND RC.ENDDA >= GETDATE();";

            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                List<object[]> data = new List<object[]>();
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString() };
                    data.Add(values);
                }
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public static int GetCompetencyMaxID()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT MAX(CPYID) FROM trrcd.REFERENSI_KOMPETENSI";
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

        public static int GetCompetencyRelationMaxID()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT MAX(RLSID) FROM trrcd.RELASI_COMPETENCY";
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