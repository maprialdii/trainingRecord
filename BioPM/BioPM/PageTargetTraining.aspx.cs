using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BioPM
{
    public partial class PageTargetTraining : System.Web.UI.Page
    {
        string evtId, eventName, method;
        protected void Page_Load(object sender, EventArgs e)
        {
            evtId = Request.QueryString["key"].ToString();
            object[] data = BioPM.ClassObjects.ComDevEvent.GetComdevEventById(evtId);
            eventName = data[1].ToString();
            method = data[3].ToString();
        }
    }
}