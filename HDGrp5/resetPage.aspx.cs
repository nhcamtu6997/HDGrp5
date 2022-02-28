using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HDGrp5
{
    public partial class resetpass : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPasswordResetLinkValid())
                {
                    Response.Write("<script>alert('Password Reset link has expired or is invalid');</script>");
                } else
                {
                    return;
                }
            }
        }

        private bool IsPasswordResetLinkValid()
        {
            con = new SqlConnection(strcon);
            con.Open();
            var text = "Select 1 from [dbo].[g5_reset_password_requests] where id=@id;";
            cmd = new SqlCommand(text, con);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["uid"]);

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



        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (!checkAccountExists())
            {
                Response.Write("<script>alert('No account found with this email address!');</script>");
                clear();
            }
            else if (!PassWordValid(txtNewPass.Text.Trim(), txtRepNewPass.Text.Trim()))
            {
                return;
            }
            else
            {
                resetPassword();
            }
        }

        // Methode to define account
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

        private void resetPassword()
        {
            con = new SqlConnection(strcon);
            con.Open();
            var text1 = "UPDATE g5_users SET" +
                " password = @password" +
                " WHERE email = @email;";
            var text2 = "DELETE FROM g5_reset_password_requests WHERE id = @id";
            var text = text1 + " ; " + text2;
            cmd = new SqlCommand(text, con);
            cmd.Parameters.AddWithValue("@password", Hash.HashString(txtNewPass.Text.Trim()));
            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@id", Request.QueryString["uid"]);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("resetSuccessfull.aspx");
        }

        private bool PassWordValid(string p1, string p2)
        {
            int length = p1.Length;
            if (length < 8)
            {
                Response.Write("<script>alert('Password needs at least 8 characters');</script>");
                return false;
            }

            if (p1.Equals(p2))
            {
                return true;
            }
            else
            {
                Response.Write("<script>alert('Passwords don't match');</script>");
                return false;
            }
        }

        private void clear()
        {
            txtEmail.Text = string.Empty;
            txtNewPass.Text = string.Empty;
            txtRepNewPass.Text = string.Empty;
        }

    }
}