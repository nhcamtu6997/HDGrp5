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
                return;
            }
            else { 
            string smail = SignUpEmail.Text.Trim();
            
                if (checkUserExists(smail))
                {
                    
                    ErrorMessage.showErrorMessage(lblErrorMsg ,"User already exists");
                    return;
                }
                else
                {
                    // string password = HashString(txtPassword.Text.Trim());

                    con = new SqlConnection(strcon);
                    con.Open();                   
                    var text = "INSERT INTO g5_users(email, password, name, user_type, active, activation_hash) VALUES (@email, @password, @name, @user_type, @active, @activation_hash);";
                    cmd = new SqlCommand(text, con);
                    cmd.Parameters.AddWithValue("@email", smail);
                    cmd.Parameters.AddWithValue("@password", Hash.HashString(txtPassword.Text.Trim()));                   
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@user_type", "user");
                    cmd.Parameters.AddWithValue("@active", 0);
                    //generate a random Hash for the activation URL in the E-Mail.
                    cmd.Parameters.AddWithValue("@activation_hash", generateActivation_Hash()); 
                   
                    cmd.ExecuteNonQuery();
                    Response.Redirect("Successfull.aspx", true);
                    

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
            int length = p1.Length;
            if (length < 8)
            {
                ErrorMessage.showErrorMessage(lblErrorMsg, "Password needs at least 8 characters");
                return false;
            }

            if (p1.Equals(p2)) { 
            return true;
        }
            else
            {
                ErrorMessage.showErrorMessage(lblErrorMsg, "Passwords don't match");
                return false;
            }
        }

        private string generateActivation_Hash()
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string s = String.Empty;
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                while (s.Length != 32)
                {
                    byte[] oneByte = new byte[1];
                    rng.GetBytes(oneByte);
                    char character = (char)oneByte[0];
                    if (valid.Contains(character))
                    {
                        s += character;
                    }
                }
            }
            return Hash.HashString(s);
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

    
}