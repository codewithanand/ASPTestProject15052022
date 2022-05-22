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
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            emailErrAlertBox.Visible = false;
            if (Session["user"] != null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            if(con.State == ConnectionState.Closed)
                con.Open(); 

            string checkUserQry = "select * from [userinfo] where email='" + email.Text.ToString() + "'";
            SqlCommand checkUserCmd = new SqlCommand(checkUserQry, con);
            SqlDataReader reader = checkUserCmd.ExecuteReader();
            if (reader.HasRows)
            {
                emailErrAlertBox.Visible=true;
                con.Close();
            }
            else
            {
                con.Close();
                emailErrAlertBox.Visible = false;
                Random rndm = new Random();
                int myRandomNo = rndm.Next(10000000, 99999999);
                string activation_code = myRandomNo.ToString();

                con.Open();
                String insertQry = "insert into [userinfo] (first_name, last_name, email, pass, activation_code, is_active) values (@fname, @lname, @email, @pass, @activationcode, @isactive)";
                SqlCommand insertCmd = new SqlCommand(insertQry, con);
                insertCmd.Parameters.AddWithValue("@fname", fname.Text.ToString());
                insertCmd.Parameters.AddWithValue("@lname", lname.Text.ToString());
                insertCmd.Parameters.AddWithValue("@email", email.Text.ToString());
                insertCmd.Parameters.AddWithValue("@pass", MyEncrypt(pass.Text.ToString()) );
                insertCmd.Parameters.AddWithValue("@activationcode", activation_code);
                insertCmd.Parameters.AddWithValue("@isactive", 0);
                insertCmd.ExecuteNonQuery();
                con.Close();

                MailMessage mail = new MailMessage();
                mail.To.Add(email.Text.Trim());
                mail.From = new MailAddress("anand.nslproject@gmail.com");
                mail.Subject = "Thank you for registering with us.";
                string emailBody = "";

                // Add email body here
                emailBody += "<div style='color: #fff; background-color: #A02eff; padding: 20px;'>";
                emailBody += "<p style='text-align: center'><img src='https://thumbs.dreamstime.com/b/home-interior-logo-design-creative-modern-vector-image-ideas-inspiration-188864521.jpg' height='50px' width='50px'></p>";
                emailBody += "<p style='font-size: 18px; font-weight: 600; margin-top: 5px; text-align: center;'> MyAwesomeProject</p>";
                emailBody += "</div>";
                emailBody += "<div style='padding: 20px; border: 4px solid #A02eff; background-color: #fff;'>";
                emailBody += "<p style='font-size: 18px; font-weight: 600'> Hello "+fname.Text.ToString()+"! </p>";
                emailBody += "<p> To activate your account click on the button below-</p>";
                emailBody += "<p style='text-align: center; margin: 24px 0;'><a href='" + "http://localhost:63597/ActivateAccount.aspx?activation_code="+activation_code + "&email=" + Base64Encode(email.Text.Trim()) + "' style='border: 2px solid #A05eff; color: #fff; background-color: #A02eff; text-decoration: none; padding: 12px 20px;'> ACTIVATE ACCOUNT </a></p>";
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


                Response.Redirect("Login.aspx");

            }

        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
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
        /*private string MyDecrypt(string returnText)
        {
            string EncryptionKey = "E5C2B81A3B2B2";
            byte[] cipherBytes = Convert.FromBase64String(returnText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    returnText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return returnText;
        }*/
    }
}