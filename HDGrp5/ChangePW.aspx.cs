using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace HDGrp5
{
    
    public partial class ChangePW : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;



        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["user"] == null && Session["admin"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }
        protected void ChangePassword(object sender, EventArgs e)
        {
            if (!PassWordValid(txtNewPassword.Text.Trim(), txtConfirmNewPassword.Text.Trim()) || !CurrentPassWordValid(txtCurrentPassword.Text.Trim()))
            {
                return;
            }
            else
            {
                con = new SqlConnection(strcon);
                con.Open();
                var text = "UPDATE g5_users SET password = @password WHERE id = @id;";
                cmd = new SqlCommand(text, con);
                if (Session["admin"] != null)
                {
                    cmd.Parameters.AddWithValue("@id", Session["adminID"]);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id", Session["userID"]);
                }
                cmd.Parameters.AddWithValue("@password", Hash.HashString(txtNewPassword.Text.Trim()));
                cmd.ExecuteNonQuery();
                lblSuccess.Text = "Password changed successfully!";
                lblSuccess.Visible = true;
                clear();
                return;
            }
        }

        private bool PassWordValid(string p1, string p2)
        {
            int length = p1.Length;
            if (length < 8)
            {
                ErrorMessage.showErrorMessage(lblErrorMsg, "Password needs at least 8 characters");
                return false;
            }

            if (p1.Equals(p2))
            {
                return true;
            }
            else
            {
                ErrorMessage.showErrorMessage(lblErrorMsg, "Passwords don't match");
                return false;
            }
        }
        private bool CurrentPassWordValid(string p)
            {
                con = new SqlConnection(strcon);
                con.Open();
                var text = "Select password from g5_users WHERE id=@id;";
                cmd = new SqlCommand(text, con);

                cmd.Parameters.AddWithValue("id", Session["userID"]);
                cmd.ExecuteNonQuery();

                SqlDataReader dru = cmd.ExecuteReader();
            if (dru.HasRows)
            {
                while (dru.Read())
                {
                    string Password = dru.GetValue(0).ToString();
                    String currentpw = Hash.HashString(p);
                    if (currentpw.Equals(Password))
                    {
                        return true;
                    }
                    else return false;
                }
            }
            return false;
            }

        private void clear()
        {
            txtCurrentPassword.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            txtConfirmNewPassword.Text = string.Empty;
        }


    }
}