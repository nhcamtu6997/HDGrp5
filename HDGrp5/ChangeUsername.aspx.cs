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
    public partial class ChangeUsername : System.Web.UI.Page
    {
        // Connection String
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["user"] == null && Session["admin"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }
        protected void ChangeUser(object sender, EventArgs e)
        {
            String name = txtNewUsername.Text.Trim();
            con = new SqlConnection(strcon);
            con.Open();
            
            
            var text = "UPDATE g5_users SET name = @name WHERE id= @id;";
            cmd = new SqlCommand(text, con);
            cmd.Parameters.AddWithValue("@id", Session["userID"]);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();
            ErrorMessage.showErrorMessage(lblSuccess, "Username was changed successfully");
        }
    }
}