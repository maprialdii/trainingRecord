using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace BioPM
{
    public partial class PageSurveyAnswers : System.Web.UI.Page 
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
            ddlExecution.Visible = false;
            ddlKodeSurvey.Visible = false;
        }

        protected void ddlEmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEmployeeName.AutoPostBack = true;
            SqlConnection conn = GetConnection();
            string sqlCmd = @"SELECT CE.EXCID, CV.EVTNM, CE.TITLE, CE.BATCH, CE.PMBCR, CE.INSTI, CE.BEGDA, CE.ENDDA, CE.CRTFL, CE.SCORE, CE.EXCCO
                            FROM trrcd.COMDEV_EVENT_EXECUTION CE WITH(INDEX(COMDEV_EVENT_EXECUTION_IDX_BEGDA_ENDDA_ID)), trrcd.COMDEV_EVENT CV WITH(INDEX(COMDEV_EVENT_IDX_BEGDA_ENDDA_ID))
                            WHERE CV.EVTID=CE.EVTID 
                            AND CV.BEGDA <= GETDATE() AND CV.ENDDA >= GETDATE()
                            AND CE.PERNR='" + ddlEmployeeName.SelectedValue + "' ORDER BY CE.EXCID DESC;";
            SqlCommand cmd = GetCommand(conn, sqlCmd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            ddlExecution.DataSource = ds;
            ddlExecution.DataTextField = "TITLE";
            ddlExecution.DataValueField = "EXCID";
            ddlExecution.DataBind();
            ddlExecution.Enabled = true;
            ddlExecution.Items.Insert(0, new ListItem("Select Execution","NA"));
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {
            if (ddlKodeSurvey.SelectedValue == "1")
                Response.Redirect("PageEvaluasiReaksiPeserta.aspx");
            else if (ddlKodeSurvey.SelectedValue == "3")
                Response.Redirect("PageEvaluasiPerilaku.aspx");
        }

        protected void ddlExecution_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEmployeeName.AutoPostBack = true;
            ddlExecution.AutoPostBack = true;
            ddlKodeSurvey.Enabled = true;
            ddlExecution.Items.Insert(0, new ListItem("Select Evaluation", "NA"));
        }
    }
}