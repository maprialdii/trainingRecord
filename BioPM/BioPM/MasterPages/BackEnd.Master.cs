﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BioRMM.Controller.Function;

namespace BioRMM.MasterPages
{
    public partial class BackEnd : System.Web.UI.MasterPage
    {
        MenuGenerator Menu = new MenuGenerator();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["biofarma_userid"] != null)
            {
                lbUserName.Text = Session["biofarma_username"].ToString();
                Menu.GenerateMenu();
                navAccordion.InnerHtml = Menu.ListMenu.ToString();
            }
        }

	protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["biofarma_userid"] != null)
            {
                //lbUserName.Text = Session["biofarma_username"].ToString();
                //TestGenerateMenu();
                //testMenu.InnerText = sbMenu.ToString();
                //testMenu.InnerHtml = sbMenu.ToString();
                //navAccordion.InnerHtml = menuList.ToString();
		//Menu.GenerateMenu();
		//navAccordion.InnerHtml = Menu.ListMenu.ToString();
            }
        }

    }
}