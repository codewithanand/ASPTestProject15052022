using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _15052022.Admin
{
    public partial class AdminLogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["admin_email"] == null)
            {
                Response.Redirect("AdminLogin.aspx");
            }
            Session.Abandon();
            Session.Clear();
            Response.Redirect("AdminLogin.aspx");
        }
    }
}