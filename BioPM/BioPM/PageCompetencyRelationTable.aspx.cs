using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace BioPM
{
    public partial class PageCompetencyRelationTable : System.Web.UI.Page
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

        }

        protected void ddlCompParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCompParent.AutoPostBack = true;
            txtCompLevel.Text = BioPM.ClassObjects.CompetencyCatalog.GetLevel(ddlCompParent.SelectedValue).ToString();
        }
    }
}