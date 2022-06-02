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
using System.Security.Cryptography;

namespace _15052022
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            invalidUserAlertBox.Visible = false;
            activationAlertBox.Visible=false;

            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    Response.Redirect("MyProfile.aspx");
                }
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Closed)
                con.Open();

            string checkActiveQry = "select user_id from [userinfo] where email='" + email.Text.ToString() + "' and is_active=1";
            SqlCommand checkActiveCmd = new SqlCommand(checkActiveQry, con);
            SqlDataReader checkActiveReader = checkActiveCmd.ExecuteReader();
            if (checkActiveReader.HasRows)
            {
                activationAlertBox.Visible = false;
                con.Close();
                con.Open();
                String selectQry = "select email, first_name from [userinfo] where email='" + email.Text.ToString() + "' and pass='" + MyEncrypt(pass.Text.ToString()) + "'";
                SqlCommand selectCmd = new SqlCommand(selectQry, con);
                SqlDataReader selectReader = selectCmd.ExecuteReader();
                if (selectReader.Read())
                {
                    invalidUserAlertBox.Visible = false;
                    Session["user"] = selectReader.GetValue(0).ToString();
                    Session["first_name"] = selectReader.GetValue(1).ToString();
                    con.Close();
                    Response.Redirect("MyProfile.aspx");
                }
                else
                {
                    invalidUserAlertBox.Visible = true;
                    con.Close();
                }
            }
            else
            {
                activationAlertBox.Visible = true;
                con.Close();
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