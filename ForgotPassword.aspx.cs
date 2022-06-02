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
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

namespace _15052022
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["user"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
            emailEntry.Visible = true;
            enterOTP.Visible = false;
            changePassword.Visible = false;

            emailErrMsg.Visible = false;
            otpSentMsg.Visible = false;
            invOtpMsg.Visible = false ;
            passChangedMsg.Visible = false;
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string matchQry = "select user_id from [userinfo] where email='"+email.Text.ToString()+"' and is_active=1";
            SqlCommand matchCmd = new SqlCommand(matchQry, con);    
            SqlDataReader matchReader = matchCmd.ExecuteReader();
            if (!matchReader.HasRows)
            {
                con.Close();
                // Throw error
                emailErrMsg.Visible = true;
                emailEntry.Visible = true;
                enterOTP.Visible = false;
                changePassword.Visible = false;
            }
            else
            {
                con.Close();

                Random random = new Random();
                int myRandomNum = random.Next(100000, 999999);
                string activation_code = myRandomNum.ToString();

                // Email OTP to authenticate user
                MailMessage mail = new MailMessage();
                mail.To.Add(email.Text.Trim());
                mail.From = new MailAddress("anand.nslproject@gmail.com");
                mail.Subject = "OTP for email verification";
                string emailBody = "";

                // Add email body here
                emailBody += "<div style='color: #fff; background-color: #A02eff; padding: 20px;'>";
                emailBody += "<p style='text-align: center'><img src='https://thumbs.dreamstime.com/b/home-interior-logo-design-creative-modern-vector-image-ideas-inspiration-188864521.jpg' height='50px' width='50px'></p>";
                emailBody += "<p style='font-size: 18px; font-weight: 600; margin-top: 5px; text-align: center;'> MyAwesomeProject</p>";
                emailBody += "</div>";
                emailBody += "<div style='padding: 20px; border: 4px solid #A02eff; background-color: #fff;'>";
                emailBody += "<p style='font-size: 18px; font-weight: 600'> Hello User! </p>";
                emailBody += "<p> OTP for account verification-</p>";
                emailBody += "<h1>"+activation_code.ToString()+"</h1>";
                emailBody += "<p> Thank you for regestering with us.We will contact you ASAP.</p>";
                emailBody += "<p> If you have additional queries, please feel free to reach us at <span style='font-weight: 500;'> +91 XXXX XXX XXX </span> or drop us an email at <a href='#' style='text-decoration: none;'><span style='font-weight: 500; color: orange;'> project@support.com </span></a></p>";
                emailBody += "<p style='font-size: 18px; font-weight: 600'> Thanks </p>";
                emailBody += "<p> Project Admin </p>";
                emailBody += "</div>";
                emailBody += "<div style='color: #fff; background-color: #A02eff; padding: 20px;' >";
                emailBody += "<p style='text-align: center;'><a href='#'> Terms of use </a> | <a href='#'> Privacy Policy </a></p>";
                emailBody += "<p style='text-align: center;'><a href='#'> Unsubscribe </a></p>";
                emailBody += "</div>";

                mail.Body = emailBody;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com";   // Or your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential("anand.nslproject@gmail.com", "galliyan");    //SMTP username and password
                smtp.Send(mail);

                con.Open();
                string updateQry = "update [userinfo] set pass_otp='"+activation_code.ToString()+"'";
                SqlCommand updateCmd = new SqlCommand(updateQry, con);
                updateCmd.ExecuteNonQuery();
                con.Close();

                emailLabelMsg.Text = email.Text.ToString();
                otpSentMsg.Visible = true;

                emailEntry.Visible = false;
                enterOTP.Visible = true;
                changePassword.Visible = false;
            }
        }

        protected void verifyBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            string matchQry = "select user_id from [userinfo] where email='" + email.Text.ToString() + "' and pass_otp='"+ newOTP.Text.ToString() + "'";
            SqlCommand matchCmd = new SqlCommand(matchQry, con);
            SqlDataReader matchReader = matchCmd.ExecuteReader();
            if (matchReader.Read())
            {
                con.Close();
                invOtpMsg.Visible = false;

                con.Open();
                string updateQry = "update [userinfo] set pass_otp='0'";
                SqlCommand updateCmd = new SqlCommand(updateQry, con);
                updateCmd.ExecuteNonQuery();
                con.Close();

                emailEntry.Visible = false;
                enterOTP.Visible = false;
                changePassword.Visible = true;
            }
            else
            {
                con.Close();
                invOtpMsg.Visible = true;
                emailEntry.Visible = false;
                enterOTP.Visible = true;
                changePassword.Visible = false;
            }
        }

        protected void changeBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            string updateQry = "update [userinfo] set pass='"+ MyEncrypt(pass.Text.ToString())+"' where email='"+email.Text.ToString()+"'";
            SqlCommand updateCmd = new SqlCommand (updateQry, con); 
            updateCmd.ExecuteNonQuery ();
            con.Close();

            passChangedMsg.Visible = true;
            emailEntry.Visible = false;
            enterOTP.Visible = false;
            changePassword.Visible = false;
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