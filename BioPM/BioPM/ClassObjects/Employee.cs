using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BioPM.ClassObjects
{
    public class EmployeeCatalog : DatabaseFactory
    {
        public static void InsertEmployee()
        {
            string date = DateTime.Today.ToString("MM/dd/yyyy");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"";

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

        public static void UpdateEmployee()
        {

        }

        public static void DeleteEmployee()
        {
            
        }

        public static object[] GetEmployee()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                object[] batch = null;

                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString() };
                    batch = values;
                }
                return batch;
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<object[]> GetAllEmployee()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT US.PERNR, US.CNAME, US.PRPOS, US.PRORG, US.GRPNM, US.SGRNM, US.PSGRP
                            FROM bioumum.USER_DATA US ORDER BY US.PERNR;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                List<object[]> batchs = new List<object[]>();
                while (reader.Read())
                {
                    object[] values =  { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString()};
                    batchs.Add(values);
                }
                return batchs;
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<object[]> GetAllNIK()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT US.PERNR
                            FROM bioumum.USER_DATA US 
                            WHERE US.PERNR!='' and US.PERNR is not null
                            ORDER BY US.PERNR;";
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

        public static object[] GetPosID(string pernr)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT US.PERNR, US.POSID
                            FROM bioumum.USER_DATA US 
                            WHERE US.BEGDA <= GETDATE() AND US.ENDDA >= GETDATE()
                            AND US.PERNR='" + pernr + "';";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                object[] data = null;
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString() };
                    data = values;
                }
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<object[]> GetEmployeeByPosition(string posid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT US.PERNR, US.CNAME
                            FROM bioumum.USER_DATA US 
                            WHERE US.BEGDA <= GETDATE() AND US.ENDDA >= GETDATE()
                            AND US.POSID='" + posid + "' ORDER BY US.PERNR;";
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

    public class CostCenterCatalog : DatabaseFactory
    {
        public static List<object[]> GetAllCostCenter()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CC.COCTR, CC.COCNM
                            FROM biopm.COST_CENTER CC ORDER BY CC.COCNM;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                List<object[]> costcenters = new List<object[]>();
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString() };
                    costcenters.Add(values);
                }
                return costcenters;
            }
            finally
            {
                conn.Close();
            }
        }

        public static object[] GetCostCenter(string COCTR)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CC.COCTR, CC.COCNM
                            FROM biopm.COST_CENTER CC 
                            WHERE CC.COCTR = '"+ COCTR +"' ORDER BY CC.COCNM;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                object[] costcenter = null;

                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString() };
                    costcenter = values;
                }
                return costcenter;
            }
            finally
            {
                conn.Close();
            }
        }
    }

    public class QualificationCatalog : DatabaseFactory
    {
        public static List<object[]> GetQualification(string pernr)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CG.GAPID, UD.PERNR, UD.POSID, CG.CPYID, RK.CPYNM, CG.PRLVL, PR.PRLVL, PR.PRLVL-CG.PRLVL AS GAP
                            FROM trrcd.COMPETENCY_GAP CG WITH(INDEX(COMPETENCY_GAP_IDX_BEGDA_ENDDA_ID)), bioumum.USER_DATA UD, trrcd.POSITION_REQ PR WITH(INDEX(POSITION_REQ_IDX_BEGDA_ENDDA_ID)), trrcd.REFERENSI_KOMPETENSI RK WITH(INDEX(REFERENSI_KOMPETENSI_IDX_BEGDA_ENDDA_ID))
                            WHERE CG.BEGDA <= GETDATE() AND CG.ENDDA >= GETDATE()
                            AND PR.BEGDA <= GETDATE() AND PR.ENDDA >= GETDATE()
                            AND RK.BEGDA <= GETDATE() AND RK.ENDDA >= GETDATE()
                            AND UD.BEGDA <= GETDATE() AND UD.ENDDA >= GETDATE()
                            AND CG.PERNR=UD.PERNR and PR.CPYID=CG.CPYID and CG.CPYID=RK.CPYID and UD.PERNR='" + pernr + "';";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                List<object[]> batchs = new List<object[]>();
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString() };
                    batchs.Add(values);
                }
                return batchs;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void InsertQualification(string GAPID, string PERNR, string CPYID, string PRLVL, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string maxdate = DateTime.MaxValue.ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"INSERT INTO trrcd.COMPETENCY_GAP (BEGDA, ENDDA, GAPID, PERNR, CPYID, PRLVL, CHGDT, CHUSR)
                            VALUES ('" + date + "','" + maxdate + "'," + GAPID + ",'" + PERNR + "'," + CPYID + "," + PRLVL + ",'" + date + "','" + CHUSR + "');";

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

        public static void UpdateQualification(string GAPID, string PERNR, string CPYID, string PRLVL, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.COMPETENCY_GAP SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + CHUSR + "' WHERE (GAPID = " + GAPID + " AND BEGDA <= GETDATE() AND ENDDA >= GETDATE())";

            SqlCommand cmd = DatabaseFactory.GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                InsertQualification(GAPID, PERNR, CPYID, PRLVL, CHUSR);
            }
        }

        public static void DeleteQualification(string gapid, string usrdt)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.COMPETENCY_GAP SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + usrdt + "' WHERE (GAPID = " + gapid + " AND BEGDA <= GETDATE() AND ENDDA >= GETDATE())";

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

        public static int GetQualificationMaxID()
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT MAX(GAPID) FROM trrcd.COMPETENCY_GAP";
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

        public static object[] GetQualificationById(string gapid)
        {
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CG.GAPID, UD.PERNR, UD.POSID, CG.CPYID, CG.PRLVL, PR.PRLVL, PR.LVL-CG.PRLVL AS GAP
                            FROM trrcd.COMPETENCY_GAP CG WITH(INDEX(COMPETENCY_GAP_IDX_BEGDA_ENDDA_ID)), bioumum.USERDATA UD, trrcd.POSITION_REQ PR WITH(INDEX(POSITION_REQ_IDX_BEGDA_ENDDA_ID)) 
                            WHERE CG.BEGDA <= GETDATE() AND CG.ENDDA >= GETDATE()
                            AND PR.BEGDA <= GETDATE() AND PR.ENDDA >= GETDATE()
                            AND UD.BEGDA <= GETDATE() AND UD.ENDDA >= GETDATE()
                            AND CG.PERNR=UD.PERNR and PR.CPYID=CG.CPYID and CG.GAPID='" + gapid + "';";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                object[] data = null;
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
    }
}