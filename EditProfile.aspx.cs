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
    public partial class EditProfile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            succUpdateMsg.Visible = false;

            if (!IsPostBack)
            {
                if(Session["user"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                con.Open();
                string sql = "select * from [userinfo] where email='" + Session["user"].ToString() + "'";
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
                string gen = dataset.Tables[0].Rows[0]["gender"].ToString();
                if (gen == "male")
                {
                    genMale.Checked = true;
                }
                else
                {
                    genFemale.Checked = true;
                }
                userCaste.SelectedValue = dataset.Tables[0].Rows[0]["caste"].ToString();
            }
        }

        protected void updateProfileBtn_Click(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Closed)
                con.Open();
            string matchQry = "select user_id from [userinfo] where email='"+ Session["user"] + "'";
            SqlCommand matchCmd = new SqlCommand(matchQry, con);
            SqlDataReader matchReader = matchCmd.ExecuteReader();
            if (matchReader.Read())
            {
                con.Close();
                // Fetch gender
                string gender = "";
                if (genMale.Checked)
                {
                    gender = "male";
                }
                if (genFemale.Checked)
                {
                    gender = "female";
                }

                // Fetch caste
                string caste = "";
                caste = userCaste.SelectedValue.ToString();

                con.Open();
                string updateQry = "update [userinfo] set first_name=@fname, last_name=@lname, gender=@gender, caste=@caste where email='" + Session["user"].ToString() + "'";
                SqlCommand updateCmd = new SqlCommand(updateQry, con);
                updateCmd.Parameters.AddWithValue("@fname", userFname.Text.ToString());
                updateCmd.Parameters.AddWithValue("@lname", userLname.Text.ToString());
                updateCmd.Parameters.AddWithValue("@gender", gender);
                updateCmd.Parameters.AddWithValue("@caste", caste);
                updateCmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect("MyProfile.aspx");
            }
            else
            {
                con.Close();
                Response.Redirect("Login.aspx");
            }
            
        }
    }
}