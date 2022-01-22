using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HDGrp5
{
    public partial class createticket : System.Web.UI.Page
    {
        // Connection String
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            createNewTicket();
        }

        protected void btnDiscard_Click(object sender, EventArgs e)
        {
            Response.Redirect("dashboarduser.aspx", false);
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyMMddHHmmss");
        }

        // need to create table and code for link uploaded files 
        private void createNewTicket()
        {
            try
            {
                var timeStamp = GetTimestamp(DateTime.Now);

                con = new SqlConnection(strcon);

                con.Open();

                var text = "INSERT INTO g5_tickets(user_id, title, init_msg, kategorie_name, create_date, status) VALUES (@user_id, @title, @init_msg, @kategorie_name, @create_date, @status);";

                cmd = new SqlCommand(text, con);

                cmd.Parameters.AddWithValue("@user_id", Session["userID"].ToString());
                cmd.Parameters.AddWithValue("@title", txtSubject.Text.Trim());
                cmd.Parameters.AddWithValue("@init_msg", txtMessage.Text.Trim());
                cmd.Parameters.AddWithValue("@kategorie_name", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@create_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@status", "open");

                cmd.ExecuteNonQuery();

                clear();
                Response.Redirect("dashboarduser.aspx");
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
        private void clear()
        {
            txtSubject.Text = string.Empty;
            txtMessage.Text = string.Empty;
            ddlCategory.ClearSelection();
        }

    }
}
