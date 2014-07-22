using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace BioPM
{
    public partial class FormTrainingExecution : System.Web.UI.Page
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        }

        public static SqlCommand GetCommand(SqlConnection con, string sqlCommand)
        {
            return new SqlCommand(sqlCommand, (SqlConnection)con);
        }

        public static SqlDataReader GetDataReader(SqlCommand cmd)
        {
            return cmd.ExecuteReader();
        }

        public static SqlParameter GetParameter(string parameterName, object parameterValue)
        {
            return new SqlParameter(parameterName, parameterValue);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ddlRecID.Enabled = false;
        }

        protected void ddlEmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEmployeeName.AutoPostBack = true;
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CONVERT(varchar(10), CP.RECID)+' - '+CE.EVTNM AS PENGAJUAN, CP.RECID
                            FROM trrcd.COMDEV_PLAN CP, trrcd.COMDEV_PLAN_STATUS CS, trrcd.COMDEV_EVENT CE
                            WHERE CP.RECID=CS.RECID AND CE.EVTID=CP.EVTID AND CS.APVST='Approved' AND CP.PERNR='" + ddlEmployeeName.SelectedValue + "';";
            SqlCommand cmd = GetCommand(conn, sqlCmd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            ddlRecID.DataSource = ds;
            ddlRecID.DataTextField = "PENGAJUAN";
            ddlRecID.DataValueField = "RECID";
            ddlRecID.DataBind();
            ddlRecID.Enabled = true;
            ddlRecID.Items.Insert(0, new ListItem("Select Approval Code", "NA"));
        }
    }
}