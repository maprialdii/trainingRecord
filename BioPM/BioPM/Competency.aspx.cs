using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BioRMM.Controller.Function;

namespace BioRMM.Pages
{
    public partial class Competency : System.Web.UI.Page
    {
        CompetencyGenerator Com = new CompetencyGenerator();
        protected void Page_Load(object sender, EventArgs e)
        {
            Com.GenerateCompetency();
            List.InnerHtml = Com.ListCompetency.ToString();
        }
    }
}