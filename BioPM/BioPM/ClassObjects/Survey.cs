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
            string sqlCmd = @"SELECT CG.GAPID, UD.PERNR, UD.POSID, CG.CPYID, RK.CPYNM, CG.PRLVL, PR.PRLVL, CG.GAPLV
                            FROM bioumum.PARAMATER PR, oumum.USER_DATA UD, trrcd.POSITION_REQ PR WITH(INDEX(POSITION_REQ_IDX_BEGDA_ENDDA_ID)), trrcd.REFERENSI_KOMPETENSI RK WITH(INDEX(REFERENSI_KOMPETENSI_IDX_BEGDA_ENDDA_ID))
                            WHERE CG.BEGDA <= GETDATE() AND CG.ENDDA >= GETDATE()
                            AND PR.BEGDA <= GETDATE() AND PR.ENDDA >= GETDATE()
                            AND RK.BEGDA <= GETDATE() AND RK.ENDDA >= GETDATE()
                            AND UD.BEGDA <= GETDATE() AND UD.ENDDA >= GETDATE()
                            AND CG.PERNR=UD.PERNR and PR.CPYID=CG.CPYID and CG.CPYID=RK.CPYID and PR.POSID=UD.POSID and UD.PERNR='" + pernr + "';";
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

    }
}