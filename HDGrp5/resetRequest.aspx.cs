using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HDGrp5
{
    public partial class resetRequest : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkAccountExists())
                {
                    Response.Write("<script>alert('No account found with this email address!');</script>");
                    clear();
                }
                else
                {
                    con = new SqlConnection(strcon);
                    cmd = new SqlCommand("spResetPassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramUserEmail = new SqlParameter("@Email", txtEmail.Text);
                    cmd.Parameters.Add(paramUserEmail);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (Convert.ToBoolean(rdr["ReturnCode"]))
                        {
                            sendRequest(txtEmail.Text, rdr["UserName"].ToString(), rdr["UniqueId"].ToString());
                            Response.Redirect("Successfull.aspx", true);
                        }
                        else
                        {
                            Response.Write("<script>alert('Can not send email');</script>");
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();

            }

        }

        private void sendRequest(string ToEmail, string UserName, string UniqueId)
        {
            MailMessage mailMessage = new MailMessage("test.projekten.tun@gmail.com", ToEmail);

            // StringBuilder class is present in System.Text namespace
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Guten Tag Kunden" + ",<br/><br/>");
            sbEmailBody.Append("Bitte klicken Sie auf den folgenden Link, um Ihr Passwort zurückzusetzen");
            sbEmailBody.Append("<br/>"); sbEmailBody.Append("http://localhost:44384/resetPage.aspx?uid=" + UniqueId);
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<b>Ticketing System Care</b>");

            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Reset Your Password";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "test.projekten.tun@gmail.com",
                Password = "Meine2+Projekte"
            };

            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }

        bool checkAccountExists()
        {
            con = new SqlConnection(strcon);
            con.Open();
            var text = "Select 1 from g5_users where email=@email;";
            cmd = new SqlCommand(text, con);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());

            SqlDataReader dra = cmd.ExecuteReader();
            if (dra.HasRows)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private void clear()
        {
            txtEmail.Text = string.Empty;
        }

    }
}