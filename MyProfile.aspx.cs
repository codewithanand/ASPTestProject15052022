using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _15052022
{
    public partial class MyProfile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            string sql = "select * from [userinfo] where email='"+Session["user"].ToString()+"'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            con.Close();
            pUserFname.Text = dataset.Tables[0].Rows[0]["first_name"].ToString();
            pUserLname.Text = dataset.Tables[0].Rows[0]["last_name"].ToString();

            userFname.Text = dataset.Tables[0].Rows[0]["first_name"].ToString();
            userLname.Text = dataset.Tables[0].Rows[0]["last_name"].ToString();
            userEmailAdd.Text = dataset.Tables[0].Rows[0]["email"].ToString();
            userGender.Text = dataset.Tables[0].Rows[0]["gender"].ToString();
            userCaste.Text = dataset.Tables[0].Rows[0]["caste"].ToString();
            
        }
    }
}