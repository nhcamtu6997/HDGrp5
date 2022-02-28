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
    public partial class dashboardadmin : System.Web.UI.Page
    {
        // Connection String
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        string query;

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (!IsPostBack)
            {
                this.ShowList();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowList();

            //Required for jQuery DataTables to work
            GridView1.UseAccessibleHeader = true;
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        private void ShowList()
        {
            con = new SqlConnection(strcon);

            con.Open();

            query = "SELECT t.id, t.title, t.user_id, t.kategorie_name, t.create_date, t.status, u.name " +
                "FROM [dbo].[g5_tickets] AS t " +
                "JOIN [dbo].[g5_users] AS u ON t.user_id = u.id " +
                "ORDER BY id DESC;";

            cmd = new SqlCommand(query, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            con.Close();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.ShowList();

        }

        protected void GridView1_RowView(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "ViewTicket")
            {
                Response.Redirect("viewticket.aspx?id=" + e.CommandArgument.ToString());
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int TicketId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                con = new SqlConnection(strcon);
                query = "DELETE from [dbo].[g5_tickets] WHERE id = @id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", TicketId);
                
                con.Open();
                
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    Response.Write("<script>alert('Successfully deleted!')</script>");
                    GridView1.EditIndex = -1;
                }
                con.Close();
                this.ShowList();
            }
            catch (Exception ex)
            {
                con.Close();
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // Delete Confirmation Box
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //check if the row is the header row
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //add the thead and tbody section programatically
                e.Row.TableSection = TableRowSection.TableHeader;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (Button button in e.Row.Cells[8].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
        }

    }
}