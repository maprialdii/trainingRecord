using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BioRMM.Controller.Function
{
    public class MenuGenerator
    {
        protected StringBuilder _listMenu = new StringBuilder();

        public StringBuilder ListMenu
        {
            get { return _listMenu; }
            set { _listMenu = value; }
        }

        public void GenerateMenu()
        {
            BioRMM.Controller.Database.KatalogMenu getMenu = new Controller.Database.KatalogMenu();
            IList<Controller.Object.Menu> topLevelMenus = Controller.Helper.TreeHelper.ConvertToForest(getMenu.GetMenuFromDb());

            foreach (Controller.Object.Menu topLevelMenu in topLevelMenus)
            {
                RenderMenuItems(topLevelMenu);
            }
        }

        public void RenderMenuItems(Controller.Object.Menu menuItem)
        {
            string menuName      = menuItem.MenuName.ToString();
            string navigationUrl = menuItem.NavUrl.ToString();
            string iconClass     = menuItem.IconClass.ToString();

            if ((menuItem.Parent == null) && (menuItem.Children.Count == 0)) {
                GenerateMenuListStructure(menuName, navigationUrl, iconClass, "1");
            }
            else if (menuItem.Children.Count > 0)
            {
                if (menuItem.Parent == null) {
                    GenerateMenuListStructure(menuName, navigationUrl, iconClass, "2");
                }
                else if (menuItem.Parent != null) {
                    GenerateMenuListStructure(menuName, navigationUrl, iconClass, "3");
                }
                foreach (Controller.Object.Menu child in menuItem.Children) {
                    if (child.Children.Count > 0) {
                        RenderMenuItems(child);
                    }
                    else {
                        GenerateMenuListStructure(child.MenuName.ToString(), child.NavUrl.ToString(), child.IconClass.ToString(), "4");
                    }
                }
                ListMenu.Append("</ul>");
                ListMenu.Append("</li>");
            }
        }

        protected void GenerateMenuListStructure(string menuName, string navUrl, string navIcon, string type)
        {
            if (type == "1")
            {
                ListMenu.Append("<li>");
			ListMenu.Append("<a href = '" + navUrl + "'>");
			    ListMenu.Append("<i class = '" + navIcon + "'></i>");
			    ListMenu.Append("<span>" + menuName + "</span>");
			ListMenu.Append("</a>");
                ListMenu.Append("</li>");
            }
            if (type == "2")
            {
                ListMenu.Append("<li class = 'sub-menu'>");
			ListMenu.Append("<a href = 'javascript:;'>");
			    ListMenu.Append("<i class = '" + navIcon + "'></i>");
			    ListMenu.Append("<span>" + menuName + "</span>");
			ListMenu.Append("</a>");
			ListMenu.Append("<ul class = 'sub'>");
			    /*Generate <li> element for sub menu*/
			//ListMenu.Append("</ul>");
                //ListMenu.Append("</li>");
            }
            if (type == "3")
            {
                ListMenu.Append("<li class = 'sub-menu'>");
			ListMenu.Append("<a href = 'javascript:;'>");
			    ListMenu.Append("<span>" + menuName + "</span>");
			    ListMenu.Append("</a>");
			ListMenu.Append("<ul class = 'sub'>");
			    /*Generate <li> element for sub menu*/
			//ListMenu.Append("</ul>");
                //ListMenu.Append("</li>");
            }
            if (type == "4")
            {
                ListMenu.Append("<li><a href = '" + navUrl + "'>" + menuName + "</a></li>");
            }
        }
    }
}