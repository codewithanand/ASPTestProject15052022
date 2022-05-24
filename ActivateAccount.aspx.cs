using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _15052022
{
    public partial class ActivateAccount : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            linkExpiredAlertBox.Visible = false;
            accountActiveMsg.Visible = false ;

            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    Response.Redirect("Home.aspx");
                }
                string activation_code = Request.QueryString["activation_code"].ToString();
                string email_id = Request.QueryString["email"].ToString();
                string email = Base64Decode(email_id);

                if(con.State == ConnectionState.Closed)
                    con.Open();

                string selectQry = "select email, activation_code from [userinfo] where email='"+email.ToString()+"' and activation_code='"+activation_code.ToString()+"' and is_active=0 and activation_code != '0'";
                SqlCommand selectCmd = new SqlCommand(selectQry, con);
                SqlDataReader selectReader = selectCmd.ExecuteReader();
                if (selectReader.Read())
                {
                    con.Close();
                    con.Open();
                    string updateQry = "update [userinfo] set is_active=1, activation_code='0' where email='"+email.ToString()+"'";
                    SqlCommand updateCmd = new SqlCommand(updateQry, con);
                    updateCmd.ExecuteNonQuery();
                    con.Close();
                    accountActiveMsg.Visible=true;
                }
                else
                {
                    linkExpiredAlertBox.Visible = true;
                    con.Close();
                }
            }
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }

}