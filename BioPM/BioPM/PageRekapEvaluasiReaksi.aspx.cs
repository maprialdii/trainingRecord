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
    public partial class PageRekapEvaluasiReaksi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            if (Page.IsPostBack)
            {
                BindChart1();
                BindChart2();
                BindChart3();
                BindChart4();
                BindChart5();
                BindChart6();
                BindChart7();
                BindChart8();
                BindChart9();
                BindChart10();
                BindChart11();
                BindChart12();
                BindChart13();
                BindChart14();
                BindChart15();
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

        protected void BindChart1()
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
            string cmdstr = "select sa.value, COUNT(sa.ansid) as jumlah from trrcd.SURVEY_ANSWERS SA, trrcd.COMDEV_EVENT CE, trrcd.COMDEV_EVENT_EXECUTION CX where SA.BEGDA <= GETDATE() AND SA.ENDDA >= GETDATE() and CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE() and ce.evtid=" + ddlEvent.SelectedValue + " and cx.batch='" + ddlBatch.SelectedValue + "' and sa.prmid=2 and sa.EXCID=cx.EXCID and ce.EMTID=cx.EVTID group by ce.evtid, SA.prmid, CE.EVTNM, CX.BATCH, sa.VALUE;";
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
            barchart3.CategoriesAxis = category.Remove(0, 1);
            barchart3.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = values, BarColor = "#2fd1f9", Name = "Value" });
        }
        
        protected void BindChart4()
        {
            SqlConnection conn = GetConnection();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            string cmdstr = "select sa.value, COUNT(sa.ansid) as jumlah from trrcd.SURVEY_ANSWERS SA, trrcd.COMDEV_EVENT CE, trrcd.COMDEV_EVENT_EXECUTION CX where SA.BEGDA <= GETDATE() AND SA.ENDDA >= GETDATE() and CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE() and ce.evtid=" + ddlEvent.SelectedValue + " and cx.batch='" + ddlBatch.SelectedValue + "' and sa.prmid=4 and sa.EXCID=cx.EXCID and ce.EMTID=cx.EVTID group by ce.evtid, SA.prmid, CE.EVTNM, CX.BATCH, sa.VALUE;";
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
            barchart4.CategoriesAxis = category.Remove(0, 1);
            barchart4.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = values, BarColor = "#2fd1f9", Name = "Value" });
        }

        protected void BindChart5()
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
            barchart5.CategoriesAxis = category.Remove(0, 1);
            barchart5.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = values, BarColor = "#2fd1f9", Name = "Value" });
        }

        protected void BindChart6()
        {
            SqlConnection conn = GetConnection();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            string cmdstr = "select sa.value, COUNT(sa.ansid) as jumlah from trrcd.SURVEY_ANSWERS SA, trrcd.COMDEV_EVENT CE, trrcd.COMDEV_EVENT_EXECUTION CX where SA.BEGDA <= GETDATE() AND SA.ENDDA >= GETDATE() and CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE() and ce.evtid=" + ddlEvent.SelectedValue + " and cx.batch='" + ddlBatch.SelectedValue + "' and sa.prmid=6 and sa.EXCID=cx.EXCID and ce.EMTID=cx.EVTID group by ce.evtid, SA.prmid, CE.EVTNM, CX.BATCH, sa.VALUE;";
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
            barchart6.CategoriesAxis = category.Remove(0, 1);
            barchart6.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = values, BarColor = "#2fd1f9", Name = "Value" });
        }
        
        protected void BindChart7()
        {
            SqlConnection conn = GetConnection();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            string cmdstr = "select sa.value, COUNT(sa.ansid) as jumlah from trrcd.SURVEY_ANSWERS SA, trrcd.COMDEV_EVENT CE, trrcd.COMDEV_EVENT_EXECUTION CX where SA.BEGDA <= GETDATE() AND SA.ENDDA >= GETDATE() and CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE() and ce.evtid=" + ddlEvent.SelectedValue + " and cx.batch='" + ddlBatch.SelectedValue + "' and sa.prmid=7 and sa.EXCID=cx.EXCID and ce.EMTID=cx.EVTID group by ce.evtid, SA.prmid, CE.EVTNM, CX.BATCH, sa.VALUE;";
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
            barchart7.CategoriesAxis = category.Remove(0, 1);
            barchart7.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = values, BarColor = "#2fd1f9", Name = "Value" });
        }

        protected void BindChart8()
        {
            SqlConnection conn = GetConnection();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            string cmdstr = "select sa.value, COUNT(sa.ansid) as jumlah from trrcd.SURVEY_ANSWERS SA, trrcd.COMDEV_EVENT CE, trrcd.COMDEV_EVENT_EXECUTION CX where SA.BEGDA <= GETDATE() AND SA.ENDDA >= GETDATE() and CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE() and ce.evtid=" + ddlEvent.SelectedValue + " and cx.batch='" + ddlBatch.SelectedValue + "' and sa.prmid=8 and sa.EXCID=cx.EXCID and ce.EMTID=cx.EVTID group by ce.evtid, SA.prmid, CE.EVTNM, CX.BATCH, sa.VALUE;";
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
            barchart8.CategoriesAxis = category.Remove(0, 1);
            barchart8.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = values, BarColor = "#2fd1f9", Name = "Value" });
        }

        protected void BindChart9()
        {
            SqlConnection conn = GetConnection();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            string cmdstr = "select sa.value, COUNT(sa.ansid) as jumlah from trrcd.SURVEY_ANSWERS SA, trrcd.COMDEV_EVENT CE, trrcd.COMDEV_EVENT_EXECUTION CX where SA.BEGDA <= GETDATE() AND SA.ENDDA >= GETDATE() and CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE() and ce.evtid=" + ddlEvent.SelectedValue + " and cx.batch='" + ddlBatch.SelectedValue + "' and sa.prmid=9 and sa.EXCID=cx.EXCID and ce.EMTID=cx.EVTID group by ce.evtid, SA.prmid, CE.EVTNM, CX.BATCH, sa.VALUE;";
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
            barchart9.CategoriesAxis = category.Remove(0, 1);
            barchart9.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = values, BarColor = "#2fd1f9", Name = "Value" });
        }
        
        protected void BindChart10()
        {
            SqlConnection conn = GetConnection();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            string cmdstr = "select sa.value, COUNT(sa.ansid) as jumlah from trrcd.SURVEY_ANSWERS SA, trrcd.COMDEV_EVENT CE, trrcd.COMDEV_EVENT_EXECUTION CX where SA.BEGDA <= GETDATE() AND SA.ENDDA >= GETDATE() and CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE() and ce.evtid=" + ddlEvent.SelectedValue + " and cx.batch='" + ddlBatch.SelectedValue + "' and sa.prmid=10 and sa.EXCID=cx.EXCID and ce.EMTID=cx.EVTID group by ce.evtid, SA.prmid, CE.EVTNM, CX.BATCH, sa.VALUE;";
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
            barchart10.CategoriesAxis = category.Remove(0, 1);
            barchart10.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = values, BarColor = "#2fd1f9", Name = "Value" });
        }

        protected void BindChart11()
        {
            SqlConnection conn = GetConnection();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            string cmdstr = "select sa.value, COUNT(sa.ansid) as jumlah from trrcd.SURVEY_ANSWERS SA, trrcd.COMDEV_EVENT CE, trrcd.COMDEV_EVENT_EXECUTION CX where SA.BEGDA <= GETDATE() AND SA.ENDDA >= GETDATE() and CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE() and ce.evtid=" + ddlEvent.SelectedValue + " and cx.batch='" + ddlBatch.SelectedValue + "' and sa.prmid=11 and sa.EXCID=cx.EXCID and ce.EMTID=cx.EVTID group by ce.evtid, SA.prmid, CE.EVTNM, CX.BATCH, sa.VALUE;";
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
            barchart11.CategoriesAxis = category.Remove(0, 1);
            barchart11.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = values, BarColor = "#2fd1f9", Name = "Value" });
        }

        protected void BindChart12()
        {
            SqlConnection conn = GetConnection();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            string cmdstr = "select sa.value, COUNT(sa.ansid) as jumlah from trrcd.SURVEY_ANSWERS SA, trrcd.COMDEV_EVENT CE, trrcd.COMDEV_EVENT_EXECUTION CX where SA.BEGDA <= GETDATE() AND SA.ENDDA >= GETDATE() and CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE() and ce.evtid=" + ddlEvent.SelectedValue + " and cx.batch='" + ddlBatch.SelectedValue + "' and sa.prmid=12 and sa.EXCID=cx.EXCID and ce.EMTID=cx.EVTID group by ce.evtid, SA.prmid, CE.EVTNM, CX.BATCH, sa.VALUE;";
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
            barchart12.CategoriesAxis = category.Remove(0, 1);
            barchart12.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = values, BarColor = "#2fd1f9", Name = "Value" });
        }
        
        protected void BindChart13()
        {
            SqlConnection conn = GetConnection();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            string cmdstr = "select sa.value, COUNT(sa.ansid) as jumlah from trrcd.SURVEY_ANSWERS SA, trrcd.COMDEV_EVENT CE, trrcd.COMDEV_EVENT_EXECUTION CX where SA.BEGDA <= GETDATE() AND SA.ENDDA >= GETDATE() and CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE() and ce.evtid=" + ddlEvent.SelectedValue + " and cx.batch='" + ddlBatch.SelectedValue + "' and sa.prmid=13 and sa.EXCID=cx.EXCID and ce.EMTID=cx.EVTID group by ce.evtid, SA.prmid, CE.EVTNM, CX.BATCH, sa.VALUE;";
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
            barchart13.CategoriesAxis = category.Remove(0, 1);
            barchart13.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = values, BarColor = "#2fd1f9", Name = "Value" });
        }

        protected void BindChart14()
        {
            SqlConnection conn = GetConnection();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            string cmdstr = "select sa.value, COUNT(sa.ansid) as jumlah from trrcd.SURVEY_ANSWERS SA, trrcd.COMDEV_EVENT CE, trrcd.COMDEV_EVENT_EXECUTION CX where SA.BEGDA <= GETDATE() AND SA.ENDDA >= GETDATE() and CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE() and ce.evtid=" + ddlEvent.SelectedValue + " and cx.batch='" + ddlBatch.SelectedValue + "' and sa.prmid=14 and sa.EXCID=cx.EXCID and ce.EMTID=cx.EVTID group by ce.evtid, SA.prmid, CE.EVTNM, CX.BATCH, sa.VALUE;";
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
            barchart14.CategoriesAxis = category.Remove(0, 1);
            barchart14.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = values, BarColor = "#2fd1f9", Name = "Value" });
        }

        protected void BindChart15()
        {
            SqlConnection conn = GetConnection();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            string cmdstr = "select sa.value, COUNT(sa.ansid) as jumlah from trrcd.SURVEY_ANSWERS SA, trrcd.COMDEV_EVENT CE, trrcd.COMDEV_EVENT_EXECUTION CX where SA.BEGDA <= GETDATE() AND SA.ENDDA >= GETDATE() and CE.BEGDA <= GETDATE() AND CE.ENDDA >= GETDATE() and ce.evtid=" + ddlEvent.SelectedValue + " and cx.batch='" + ddlBatch.SelectedValue + "' and sa.prmid=15 and sa.EXCID=cx.EXCID and ce.EMTID=cx.EVTID group by ce.evtid, SA.prmid, CE.EVTNM, CX.BATCH, sa.VALUE;";
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
            barchart15.CategoriesAxis = category.Remove(0, 1);
            barchart15.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = values, BarColor = "#2fd1f9", Name = "Value" });
        }
        }
    }