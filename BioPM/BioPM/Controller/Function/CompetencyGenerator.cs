using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using BioPM.Controller.Object;

namespace BioPM.Controller.Function
{
    public class CompetencyGenerator
    {
        protected Competency _organization = new Competency();
        protected StringBuilder _listCompetency = new StringBuilder();

        public StringBuilder ListCompetency
        {
            get { return _listCompetency; }
            set { _listCompetency = value; }
        }

        public void GenerateCompetency()
        {
            BioPM.Controller.Database.KatalogCompetency getCompetency = new Controller.Database.KatalogCompetency();
            IList<Competency> topLevelCompetency = Controller.Helper.TreeHelper.ConvertToForest(getCompetency.GetCompetencyFromDb());

            foreach (Competency topLevelCompetency_ in topLevelCompetency)
            {
                RenderCompetencyItems(topLevelCompetency_);
            }
        }

        public void RenderCompetencyItems(Competency competencyItem)
        {
            string competencyName = competencyItem.CompetencyName.ToString();

            if ((competencyItem.Parent == null) && (competencyItem.Children.Count == 0))
            {
                GenerateCompetencyListStructure(competencyName, "1");
            }
            else if (competencyItem.Children.Count > 0)
            {
                GenerateCompetencyListStructure(competencyName, "2");
                foreach (Competency child in competencyItem.Children)
                {
                    if (child.Children.Count > 0)
                    {
                        RenderCompetencyItems(child);
                    }
                    else
                    {
                        GenerateCompetencyListStructure(child.CompetencyName.ToString(), "1");
                    }
                }
                ListCompetency.Append("</ol>");
                ListCompetency.Append("</li>");
            }
        }

        protected void GenerateCompetencyListStructure(string competencyName, string type)
        {
            if (type == "1")
            {
                ListCompetency.Append("<li class = 'dd-item'>");
                ListCompetency.Append("<div class = 'dd-handle'>" + competencyName + "</div>");
                ListCompetency.Append("</li>");
            }
            if (type == "2")
            {
                ListCompetency.Append("<li class = 'dd-item'>");
                ListCompetency.Append("<div class = 'dd-handle'>" + competencyName + "</div>");
                ListCompetency.Append("<ol class = 'dd-list'>");
                /*Generate <li> element for sub organization*/
                //ListOrganization.Append("</ol>");
                //ListOrganization.Append("</li>");
            }
        }
    }
}