using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BioPM.Controller.Object;
using BioPM.Controller.Database;
using System.Data.SqlClient;
using System.Data;

namespace BioPM.Controller.Database
{
    public class KatalogCompetency
    {
        List<Competency> listCompetency = new List<Competency>();

        public List<Competency> GetCompetencyFromDb()
        {
            SqlConnection conn = DatabaseFactory.GetConnection(); //Database.DatabaseSql.GetConnection();
            SqlCommand cmd = Database.DatabaseSql.GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                //cmd.CommandText = "SELECT * FROM bioumum.V_ORGANIZATION_STRUCTURE;";
//                cmd.CommandText = @"SELECT OS.CLDID, OG.ORGNM, OS.PRTID, OS.STRID, OS.ORGLV 
//                                    FROM bioumum.ORGANIZATION OG, bioumum.ORGANIZATION_STRUCTURE OS
//                                    WHERE OS.CLDID = OG.ORGID";
                cmd.CommandText = @"SELECT RC.LCPID, RK.CPYNM, RC.HCPID, RC.RLSID, RC.LEVEL
                                    FROM BIOFARMA.trrcd.REFERENSI_KOMPETENSI RK, BIOFARMA.trrcd.RELASI_COMPETENCY RC
                                    WHERE RC.LCPID = RK.CPYID";

                //cmd.CommandText = "EXEC biofarma.sp_ROLE_MODUL_get @roleid;";

                //cmd.Parameters.Add("@roleid", SqlDbType.NVarChar, 30);
                //cmd.Parameters["@roleid"].Direction = ParameterDirection.Input;
                //cmd.Parameters["@roleid"].Value = "00";

                SqlDataReader reader = Database.DatabaseSql.GetDataReader(cmd);
                while (reader.Read())
                {
                    Competency m = new Competency();
                    m.Id = Convert.ToInt16(reader["LCPID"]);
                    m.CompetencyName = Convert.ToString(reader["CPYNM"]);
                    //m.NavUrl  = HttpContext.Current.Server.MapPath(Convert.ToString(reader["NVURL"])); //Converting server path (~) into computer physical path (H:\)
                    //m.NavUrl = VirtualPathUtility.ToAbsolute(Convert.ToString(reader["NVURL"])); //Converting server path (~) into URL path (localhost/Default.aspx)
                    //m.IconClass = Convert.ToString(reader["ICONM"]);
                    //If the Parent ID [PARID] in database == Null, then it was first level Menu (root)
                    if (reader["HCPID"] != DBNull.Value)
                    {
                        m.Parent = new Competency();
                        m.Parent.Id = Convert.ToInt16(reader["HCPID"]);
                    }
                    listCompetency.Add(m);
                }
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
            return listCompetency;
        }
    }
}