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
        SqlConnection con;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Login Button
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(strcon);
                
                con.Open();

                if (ddlLoginType.SelectedValue == "Admin")
                {
                    
                  
                    

                        var text_admin = "SELECT * FROM g5_users WHERE email=@email AND password=@password AND user_type=@user_type;";
                        cmd = new SqlCommand(text_admin, con);

                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", Hash.HashString(txtPassword.Text.Trim()));                        
                        cmd.Parameters.AddWithValue("@user_type", "admin");

                        // Use this for INSERT
                        // cmd.ExecuteNonQuery();

                        SqlDataReader dra = cmd.ExecuteReader();
                        if (dra.HasRows)
                        {
                            while (dra.Read())
                            {
                                Response.Write("<script>alert('Login successful');</script>");
                                // Set Session "admin"
                                Session["admin"] = dra.GetValue(3).ToString(); //name
                                Session["adminID"] = dra.GetValue(0).ToString();
                            }

                            Response.Redirect("dashboardadmin.aspx", false);
                        }
                        else
                        {
                            showErrorMsg("Admin");
                        }
                    }

                else if (ddlLoginType.SelectedValue == "User")
                {
                    var text_user = "SELECT * FROM g5_users WHERE email=@email AND password=@password AND user_type=@user_type;";
                    cmd = new SqlCommand(text_user, con);

                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", Hash.HashString(txtPassword.Text.Trim()));
                    cmd.Parameters.AddWithValue("@user_type", "user");


                    SqlDataReader dru = cmd.ExecuteReader();
                    if (dru.HasRows)
                    {
                        while (dru.Read())
                        {
                            // Set Session "user"
                            Session["user"] = dru.GetValue(3).ToString(); //name
                            Session["userID"] = dru.GetValue(0).ToString();
                        }

                        Response.Redirect("dashboarduser.aspx", false);
                    }
                    else
                    {
                        showErrorMsg("User");
                    }
                }
                

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
                clear();
            }
        }

        private void showErrorMsg(string userType)
        {
            lblMsg.Visible = true;
            lblMsg.Text = userType + " Invalid";
            lblMsg.CssClass = "alert alert-danger";
        }

        private void clear()
        {
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            ddlLoginType.ClearSelection();
        }
    }
}