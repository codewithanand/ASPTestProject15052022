using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _15052022
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] != null)
            {
                loggedIn.Visible = true;
                loggedOut.Visible = false;
            }
            else
            {
                loggedIn.Visible = false;
                loggedOut.Visible = true;
            }
        }
    }
}