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
            string sqlCmd = @"INSERT INTO bioumum.PARAMETER (BEGDA, ENDDA, PRMID, PRMTY, PRMKD, PRMNM, CHGDT, USRDT)
                            VALUES ('" + date + "','" + maxdate + "'," + CPYID + ",'CP','" + CPYKD + "','" + CPYNM + "','" + date + "','" + CHUSR + "');";

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
            string sqlCmd = @"UPDATE bioumum.PARAMETER SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', USRDT = '" + CHUSR + "' WHERE (PRMID = '" + CPYID + "' AND BEGDA <= GETDATE() AND ENDDA >= GETDATE())";

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
            string sqlCmd = @"UPDATE bioumum.PARAMETER SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', USRDT = '" + usrdt + "' WHERE (PRMID = '" + cpyid + "' AND BEGDA <= GETDATE() AND ENDDA >= GETDATE())";

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
                            WHERE RK.BEGDA <= GETDATE() AND RK.ENDDA >= GETDATE() AND PRMTY='CP' ORDER BY RK.PRMID ASC;";
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
            string sqlCmd = @"INSERT INTO bioumum.RELASI_PARAMETER (BEGDA, ENDDA, RLSID, PRMTY, PRMPR, PRMCH, PRMLV, CHUSR, CHGDT)
                            VALUES ('" + date + "','" + maxdate + "'," + RLSID + ",'CM'," + HCPID + "," + LCPID + "," + LEVEL + ",'" + CHUSR + "','" + date + "');";

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
            string sqlCmd = @"UPDATE bioumum.RELASI_PARAMETER SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + CHUSR + "' WHERE (RLSID = '" + RLSID + "' AND BEGDA <= GETDATE() AND ENDDA >= GETDATE())";

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
            string sqlCmd = @"UPDATE bioumum.RELASI_PARAMETER SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + CHUSR + "' WHERE (RLSID = '" + RLSID + "' AND BEGDA <= GETDATE() AND ENDDA >= GETDATE())";

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
            string sqlCmd = @"SELECT CP1.PRMNM, CP2.PRMNM, RC.PRMLV, RC.RLSID
                            FROM biofarma.bioumum.PARAMETER CP1, biofarma.bioumum.PARAMETER CP2, biofarma.bioumum.RELASI_PARAMETER RC
                            WHERE CP1.PRMID = RC.PRMPR AND CP2.PRMID = RC.PRMCH 
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
            string sqlCmd = @"SELECT CP1.PRMNM, CP2.PRMNM, RC.PRMLV, RC.RLSID
                            FROM biofarma.bioumum.PARAMETER CP1, biofarma.bioumum.PARAMETER CP2, biofarma.bioumum.RELASI_PARAMETER RC
                            WHERE CP1.PRMID = RC.PRMPR AND CP2.PRMID = RC.PRMCH 
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
            string sqlCmd = @"SELECT MAX(PRMID) FROM bioumum.PARAMETER";
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

        public static int GetLevel(string prmid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT PRMLV+1 AS LEVEL FROM bioumum.RELASI_PARAMETER WHERE PRMCH='" + prmid + "'";
            SqlCommand cmd = GetCommand(conn, sqlCmd);
            string level = "0";
            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0)) level = reader[0].ToString() + "";
                }
                return Convert.ToInt16(level);
            }
            finally
            {
                conn.Close();
            }
        }

        public static int GetCompetencyRelationMaxID()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT MAX(RLSID) FROM bioumum.RELASI_PARAMETER";
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