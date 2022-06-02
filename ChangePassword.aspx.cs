using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace _15052022
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            passChangedMsg.Visible = false;
            passNotMatchedMsg.Visible = false;

            if (!IsPostBack)
            {
                if(Session["user"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }

            if (con.State == ConnectionState.Closed)
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
            userGender.Text = dataset.Tables[0].Rows[0]["gender"].ToString();
            userCaste.Text = dataset.Tables[0].Rows[0]["caste"].ToString();
        }

        protected void updatePassBtn_Click(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Closed) 
                con.Open();
            string matchQry = "select user_id from [userinfo] where email='" + Session["user"] + "'";
            SqlCommand matchCmd = new SqlCommand(matchQry, con);
            SqlDataReader matchReader = matchCmd.ExecuteReader();
            if (matchReader.Read())
            {
                con.Close();

                con.Open();
                // check old password
                string matchPassQry = "select user_id from [userinfo] where email='" + Session["user"].ToString() + "' and pass='"+MyEncrypt(userOldPass.Text.ToString())+"'";
                SqlCommand matchPassCmd = new SqlCommand(matchPassQry, con);
                SqlDataReader matchPassReader = matchPassCmd.ExecuteReader();
                if (matchPassReader.HasRows)
                {
                    con.Close();
                    // Update password
                    con.Open();

                    string updateQry = "update [userinfo] set pass=@pass where email='" + Session["user"].ToString() + "'";
                    SqlCommand updateCmd = new SqlCommand(updateQry, con);
                    updateCmd.Parameters.AddWithValue("@pass", MyEncrypt(userNewPass.Text.ToString()));
                    updateCmd.ExecuteNonQuery();
                    con.Close();

                    // throw success message
                    passChangedMsg.Visible = true;
                    passNotMatchedMsg.Visible = false;
                }
                else
                {
                    con.Close();
                    // throw error message
                    passChangedMsg.Visible = false;
                    passNotMatchedMsg.Visible = true;
                }
            }
            else
            {
                con.Close();
                Response.Redirect("Login.aspx");
            }
        }

        private string MyEncrypt(string returnText)
        {
            string EncryptionKey = "E5C2B81A3B2B2";
            byte[] clearBytes = Encoding.Unicode.GetBytes(returnText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    returnText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return returnText;
        }
    }
}