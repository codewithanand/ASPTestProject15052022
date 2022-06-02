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
    public partial class AdminLogin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin_email"] != null)
                {
                    Response.Redirect("Dashboard.aspx");
                }
            }
            activationAlertBox.Visible = false;
            invalidUserAlertBox.Visible = false;
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string matchQry = "select admin_id from [admininfo] where admin_email='"+admin_email.Text.ToString()+"' and is_active=1";
            SqlCommand matchCmd = new SqlCommand(matchQry, con);
            SqlDataReader matchReader = matchCmd.ExecuteReader();
            if (matchReader.HasRows)
            {
                con.Close();
                // check for password
                con.Open();
                string passQry = "select admin_id, admin_email from [admininfo] where admin_email='" + admin_email.Text.ToString() + "' and admin_pass='" + admin_pass.Text.ToString() + "'";
                SqlCommand passCmd = new SqlCommand(passQry, con);
                SqlDataReader passReader = passCmd.ExecuteReader();
                if (passReader.Read())
                {
                    Session["admin_email"] = passReader.GetValue(1).ToString();
                    con.Close();
                    // redirect to dashboard
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    // throw invalid credentials error message
                    activationAlertBox.Visible = false;
                    invalidUserAlertBox.Visible = true;
                }
            }
            else
            {
                con.Close();
                // throw invalid email error message
                activationAlertBox.Visible = true;
                invalidUserAlertBox.Visible = false;
            }
        }
    }
}