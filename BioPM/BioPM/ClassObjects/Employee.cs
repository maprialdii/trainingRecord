﻿using System;
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
            string sqlCmd = @"SELECT UD.PERNR, UD.POSID, CG.CPYID, CG.PRLVL, PR.PRLVL, PR.LVL-CG.PRLVL AS GAP
                            FROM trrcd.COMPETENCY_GAP CG, bioumum.USERDATA UD, trrcd.POSITION_REQ PR 
                            WHERE CG.BEGDA <= GETDATE() AND CG.ENDDA >= GETDATE()
                            AND PR.BEGDA <= GETDATE() AND PR.ENDDA >= GETDATE()
                            AND UD.BEGDA <= GETDATE() AND UD.ENDDA >= GETDATE()
                            AND CG.PERNR=UD.PERNR and PR.CPYID=CG.CPYID and UD.PERNR='" + pernr + "';";
            SqlCommand cmd = GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                SqlDataReader reader = GetDataReader(cmd);
                List<object[]> batchs = new List<object[]>();
                while (reader.Read())
                {
                    object[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString() };
                    batchs.Add(values);
                }
                return batchs;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void InsertQualification(string PERNR, string CPYID, string PRLVL, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string maxdate = DateTime.MaxValue.ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"INSERT INTO trrcd.COMPETENCY_GAP (BEGDA, ENDDA, PERNR, CPYID, PRLVL, CHGDT, CHUSR)
                            VALUES ('" + date + "','" + maxdate + "','" + PERNR + "'," + CPYID + ",'" + PRLVL + "','" + date + "','" + CHUSR + "');";

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

        public static void UpdateQualification(string PERNR, string CPYID, string PRLVL, string CHUSR)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.COMPETENCY_GAP SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + CHUSR + "' WHERE (PERNR = '" + PERNR + "' AND CPYID = '" + CPYID + "'+ AND BEGDA <= GETDATE() AND ENDDA >= GETDATE()";

            SqlCommand cmd = DatabaseFactory.GetCommand(conn, sqlCmd);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                InsertQualification(PERNR, CPYID, PRLVL, CHUSR);
            }
        }

        public static void DeleteQualification(string pernr, string usrdt, string cpyid)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            string yesterday = DateTime.Now.AddMinutes(-1).ToString("MM/dd/yyyy HH:mm");
            SqlConnection conn = GetConnection();
            string sqlCmd = @"UPDATE trrcd.COMPETENCY_GAP SET ENDDA = '" + yesterday + "', CHGDT = '" + date + "', CHUSR = '" + usrdt + "' WHERE (PERNR = '" + pernr + "' AND CPYID=" + cpyid + " AND BEGDA <= GETDATE() AND ENDDA >= GETDATE()";

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
    }
}