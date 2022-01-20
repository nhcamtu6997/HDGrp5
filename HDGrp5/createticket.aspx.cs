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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Add button clicked
        protected void Button2_Click(object sender, EventArgs e)
        {
            createNewTicket();
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmss");
        }



        void createNewTicket()
        {
            try
            {
                var timeStamp = GetTimestamp(DateTime.Now);

                SqlConnection con = new SqlConnection(strcon);
                
                con.Open();
                
                var text = "INSERT INTO g5_tickets(uniqid, user_id, title, init_msg, kategorie_id, date, last_reply, user_read, admin_read, resolved) VALUES (@uniqid, @user_id, @title, @init_msg, @kategorie_id, @date, @last_reply, @user_read, @admin_read, @resolved);";

                // ('617c0ba6d462b', 2, 'there some issues', 'there some issues', 1, '1635519398', 2, 1, 0, 0);

                SqlCommand cmd = new SqlCommand(text, con);

                cmd.Parameters.AddWithValue("@uniqid", "gr5" + timeStamp);
                cmd.Parameters.AddWithValue("@user_id", 2);
                cmd.Parameters.AddWithValue("@title", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@init_msg", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@kategorie_id", 1);
                cmd.Parameters.AddWithValue("@date", timeStamp);
                cmd.Parameters.AddWithValue("@last_reply", 2);
                cmd.Parameters.AddWithValue("@user_read", 1);
                cmd.Parameters.AddWithValue("@admin_read", 0);
                cmd.Parameters.AddWithValue("@resolved", 0);

                cmd.ExecuteNonQuery();

                con.Close();

                Response.Write("<script>alert('Wir haben Ihre Ticket bekommen!');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}