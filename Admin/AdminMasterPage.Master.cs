using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _15052022.Admin
{
    public partial class AdminMasterPage : System.Web.UI.MasterPage
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin_email"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
            con.Open();
            string selectQry = "select admin_first_name, admin_last_name from [admininfo] where admin_email='" + Session["admin_email"].ToString() + "'";
            SqlCommand selectCmd = new SqlCommand(selectQry, con);
            SqlDataReader selectReader = selectCmd.ExecuteReader();
            if (selectReader.Read())
            {
                topAdminName.Text = selectReader.GetValue(0).ToString() + " " + selectReader.GetValue(1).ToString();
                con.Close();
            }
            else
            {
                con.Close();
            }
        }
    }
}