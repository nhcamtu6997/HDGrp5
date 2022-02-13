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
            string smail = SignUpEmail.Text.Trim();
            Debug.WriteLine("output smail: " + smail);
            Debug.WriteLine("test");
            signup signup = new signup();
            if (signup.checkUserExists(smail))
            {
                Console.WriteLine("user already exists");
                return;
            }
            
            con = new SqlConnection(strcon);
            con.Open();

            string hash = txtPassword.ToString();
            using (SHA256 sha256 = SHA256.Create())
                Console.WriteLine(hash);
                      
        }

        private Boolean checkUserExists(string email)
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

    
}