using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Diagnostics;

namespace HDGrp5
{
    public partial class signup : System.Web.UI.Page
    {
        // Connection String
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;

       

        public void CreateUser(object sender, EventArgs e)
        {
            if(!PassWordValid(txtPassword.Text.Trim(), txtReEnterPassword.Text.Trim()))
            {
                showErrorMessage("Passwords don't match");
            }
            else { 
            string smail = SignUpEmail.Text.Trim();
            Debug.WriteLine("output smail: " + smail);
            Debug.WriteLine("test");


                if (checkUserExists(smail))
                {
                    Debug.WriteLine("user already exists");
                    showErrorMessage("User already exists");
                    return;
                }
                else
                {
                    // string password = HashString(txtPassword.Text.Trim());

                    con = new SqlConnection(strcon);
                    con.Open();
                    var text = "INSERT INTO g5_users(email, password, name, user_type) VALUES (@email, @password, @name, @user_type);";
                    cmd = new SqlCommand(text, con);
                    cmd.Parameters.AddWithValue("@email", smail);
                    cmd.Parameters.AddWithValue("@password", Hash.HashString(txtPassword.Text.Trim()));                   
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@user_type", "user");

                    cmd.ExecuteNonQuery();
                    

                }
            }
            
                      
        }

        private bool checkUserExists(string email)
        {
            con = new SqlConnection(strcon);
            con.Open();
            var text = "Select 1 from g5_users where email=@email;";
            cmd = new SqlCommand(text, con);
            cmd.Parameters.AddWithValue("email", email);

            
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

      
        
           
        
        private bool PassWordValid(string p1, string p2)
        {
            if (p1.Equals(p2))
            return true;

            else
            {
                return false;
            }
        }
        private void showErrorMessage(string text)
        {
            lblErrorMsg.Visible = true;
            lblErrorMsg.Text = text;
            lblErrorMsg.CssClass = "alert alert-danger";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

    
}