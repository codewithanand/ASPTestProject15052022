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
    public partial class Dashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin_email"] == null)
                {
                    Response.Redirect("AdminLogin.aspx");
                }
            }
            con.Open();
            string getUserDataQry = "select count(user_id) as totUser from [userinfo]";
            SqlCommand getUserDataCmd = new SqlCommand(getUserDataQry, con);
            SqlDataAdapter getUserDataAdapter = new SqlDataAdapter(getUserDataCmd);
            DataSet userDataSet = new DataSet();
            getUserDataAdapter.Fill(userDataSet);

            con.Close();
            totUserLbl.Text = userDataSet.Tables[0].Rows[0]["totUser"].ToString();
        }
    }
}