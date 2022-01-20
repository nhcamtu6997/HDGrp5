using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HDGrp5
{
    public partial class login : System.Web.UI.Page
    {
        // Connection String
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Login Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                
                var text = "SELECT * FROM g5_users WHERE email= '" + TextBox1.Text.Trim() + "' AND password= '"+ TextBox2.Text.Trim() +"';";

                SqlCommand cmd = new SqlCommand(text, con);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Welcome "+ dr.GetValue(3).ToString() + "');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid');</script>");
                }

                con.Close();

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}