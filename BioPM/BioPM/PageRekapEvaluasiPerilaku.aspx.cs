using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BioPM
{
    public partial class PageRekapDataEvaluasi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            if (Page.IsPostBack)
            {
                BindChart();
                BindChart2();
                BindChart3();
            }
        }

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

        protected void BindChart()
        {
            SqlConnection conn = GetConnection();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            string cmdstr = "select sa.value, COUNT(sa.ansid) as jumlah from trrcd.SURVEY_ANSWERS SA, trrcd.COMDEV_EVENT CE, trrcd.COMDEV_EVENT_EXECUTION CX where SA.BEGDA <= GETDATE() AND SA.ENDDA >= GETDATE() and CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE() and ce.evtid=" + ddlEvent.SelectedValue + " and cx.batch='" + ddlBatch.SelectedValue + "' and sa.prmid=1 and sa.EXCID=cx.EXCID and ce.EMTID=cx.EVTID group by ce.evtid, SA.prmid, CE.EVTNM, CX.BATCH, sa.VALUE;";
            SqlCommand cmd = new SqlCommand(cmdstr, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(ds);
            dt = ds.Tables[0];
            string category = "";
            decimal[] values = new decimal[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                category = category + "," + dt.Rows[i]["value"].ToString();
                values[i] = Convert.ToDecimal(dt.Rows[i]["jumlah"]);
            }
            barchart1.CategoriesAxis = category.Remove(0, 1);
            barchart1.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = values, BarColor = "#2fd1f9", Name = "Value" });
        }

        protected void BindChart2()
        {
            SqlConnection conn = GetConnection();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            string cmdstr = "select sa.value, COUNT(sa.ansid) as jumlah from trrcd.SURVEY_ANSWERS SA, trrcd.COMDEV_EVENT CE, trrcd.COMDEV_EVENT_EXECUTION CX where SA.BEGDA <= GETDATE() AND SA.ENDDA >= GETDATE() and CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE() and ce.evtid=" + ddlEvent.SelectedValue + " and cx.batch='" + ddlBatch.SelectedValue + "' and sa.prmid=3 and sa.EXCID=cx.EXCID and ce.EMTID=cx.EVTID group by ce.evtid, SA.prmid, CE.EVTNM, CX.BATCH, sa.VALUE;";
            SqlCommand cmd = new SqlCommand(cmdstr, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(ds);
            dt = ds.Tables[0];
            string category = "";
            decimal[] values = new decimal[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                category = category + "," + dt.Rows[i]["value"].ToString();
                values[i] = Convert.ToDecimal(dt.Rows[i]["jumlah"]);
            }
            barchart2.CategoriesAxis = category.Remove(0, 1);
            barchart2.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = values, BarColor = "#2fd1f9", Name = "Value" });
        }

        protected void BindChart3()
        {
            SqlConnection conn = GetConnection();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            string cmdstr = "select sa.value, COUNT(sa.ansid) as jumlah from trrcd.SURVEY_ANSWERS SA, trrcd.COMDEV_EVENT CE, trrcd.COMDEV_EVENT_EXECUTION CX where SA.BEGDA <= GETDATE() AND SA.ENDDA >= GETDATE() and CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE() and ce.evtid=" + ddlEvent.SelectedValue + " and cx.batch='" + ddlBatch.SelectedValue + "' and sa.prmid=5 and sa.EXCID=cx.EXCID and ce.EMTID=cx.EVTID group by ce.evtid, SA.prmid, CE.EVTNM, CX.BATCH, sa.VALUE;";
            SqlCommand cmd = new SqlCommand(cmdstr, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(ds);
            dt = ds.Tables[0];
            string category = "";
            decimal[] values = new decimal[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                category = category + "," + dt.Rows[i]["value"].ToString();
                values[i] = Convert.ToDecimal(dt.Rows[i]["jumlah"]);
            }
            barchart3.CategoriesAxis = category.Remove(0, 1);
            barchart3.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = values, BarColor = "#2fd1f9", Name = "Value" });
        }
    }
}