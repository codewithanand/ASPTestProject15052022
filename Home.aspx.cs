using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _15052022
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(Session["user_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                notLoginMenu.Visible = false;
                loginMenu.Visible = true;
            }
        }
    }
}