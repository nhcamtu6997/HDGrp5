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
    public partial class viewticket : System.Web.UI.Page
    {
        // Connection String
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sdr;
        SqlDataAdapter sda;
        DataSet ds;
        string query;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                btnCloseTicket.Visible = true;
            }
            else if (Session["user"] != null){
                btnCloseTicket.Visible = false;
            }
            string idstring = Request.QueryString["id"];
            Console.WriteLine(idstring);

            con = new SqlConnection(strcon);
            con.Open();
            query = "Select status from [dbo].[g5_tickets] WHERE id = @id;";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);

            sdr = cmd.ExecuteReader();
            

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    String status = sdr["status"].ToString();

                    if (status.Equals("closed"))
                    {
                        btnReopenTicket.Visible = true;
                        btnCloseTicket.Visible=false;
                    }
                }
            }


            if (!IsPostBack)
            {
                Page.DataBind();
                setRepBox();
                showDetaislTicket();
                showReplies();
            }            
        }  

        protected void btnReply_Click(object sender, EventArgs e)
        {
            saveReplies();
        }

        protected void btnCloseTicket_Click(object sender, EventArgs e)
        {
            try{
                con = new SqlConnection(strcon);
                con.Open();

                query = "UPDATE g5_tickets SET status = 'closed' WHERE id = @id;";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void btnReopenTicket_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(strcon);
                con.Open();

                query = "UPDATE g5_tickets SET status = 'open' WHERE id = @id;";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("id", Request.QueryString["id"]);

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void showDetaislTicket()
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    con = new SqlConnection(strcon);
                    con.Open();

                    query = "SELECT t.id, t.title, t.init_msg, t.kategorie_name, t.create_date, t.status, u.name FROM [dbo].[g5_tickets] AS t " +
                        "JOIN [dbo].[g5_users] AS u " +
                        "ON t.user_id = u.id " +
                        "WHERE t.id = @id;";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);

                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            // Put data from DB to frontend code
                            lblTitle.Text = sdr["title"].ToString();
                            lblUsername.Text = sdr["name"].ToString();
                            dMsg.InnerText = sdr["init_msg"].ToString();
                            lblDate.Text = sdr["create_date"].ToString();

                            // Set status of ticket 
                            if (String.Equals(sdr["status"].ToString(), "open"))
                            {
                                lblStatus.Text = "Open";
                                lblStatus.CssClass = "badge rounded-pill bg-info text-dark";
                            } 
                            else if (String.Equals(sdr["status"].ToString(), "closed"))
                            {
                                lblStatus.Text = "Closed";
                                lblStatus.CssClass = "badge rounded-pill bg-secondary";
                            }
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Ticket not found..! ";
                        lblMsg.CssClass = "alert alert-danger";
                    }

                    sdr.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        private void showReplies()
        {

            try{
                con = new SqlConnection(strcon);
                con.Open();
                query = "SELECT r.text, r.date, u.name FROM [dbo].[g5_ticket_replies] AS r " +
                    "JOIN [dbo].[g5_users] AS u " +
                    "ON r.user_id = u.id WHERE r.ticket_id = @id;";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);

                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();

                sda.SelectCommand = cmd; 
                sda.Fill(ds, "g5_ticket_replies");

                Repeater1.DataSource = ds;
                Repeater1.DataBind();

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void saveReplies()
        {
            try
            {
                con = new SqlConnection(strcon);
                con.Open();

                query = "INSERT INTO [dbo].[g5_ticket_replies] (user_id, text, ticket_id, date) VALUES (@user_id, @text, @ticket_id, @date);";
                cmd = new SqlCommand(query, con);

                if (Session["admin"] != null)
                {
                    cmd.Parameters.AddWithValue("@user_id", Session["adminID"].ToString());
                }
                else if (Session["user"] != null)
                {
                    cmd.Parameters.AddWithValue("@user_id", Session["userID"].ToString());
                }

                cmd.Parameters.AddWithValue("@text", txtReply.Text.Trim());
                cmd.Parameters.AddWithValue("@ticket_id", Request.QueryString["id"]);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                cmd.ExecuteNonQuery();
                Repeater1.DataBind();

                Response.Redirect(Request.Url.AbsoluteUri);
                clear();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    
        private void clear()
        {
            txtReply.Text = string.Empty;
        }

        private void setRepBox()
        {
            con = new SqlConnection(strcon);
            con.Open();

            query = "SELECT * FROM g5_tickets WHERE id = @id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);

            sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                while(sdr.Read())
                {
                    if (String.Equals(sdr["status"].ToString(), "open"))
                    {
                        btnReply.Visible = true;
                        txtReply.Visible = true;
                    }
                    else if (String.Equals(sdr["status"].ToString(), "closed"))
                    {
                        btnReply.Visible = false;
                        txtReply.Visible = false;
                    }
                }
                
            }
        }
        
    }
}