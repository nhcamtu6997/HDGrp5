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
                ShowList();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowList();
        }

        private void ShowList()
        {
            con = new SqlConnection(strcon);
            
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

        //protected void GridView1_RowClose(object sender, GridViewUpdateEventArgs e)
        //{
        //    GridViewRow row = GridView1.Rows[e.RowIndex];
        //    int ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

        //    try
        //    {
        //        con = new SqlConnection(strcon);
        //        con.Open();

        //        query = "UPDATE [dbo].[g5_tickets] SET status = @status WHERE id = @id";

        //        cmd = new SqlCommand(query, con);

        //        cmd.Parameters.AddWithValue("@id", ID);
        //        cmd.Parameters.AddWithValue("@status", "closed");

        //        cmd.ExecuteNonQuery();
        //        con.Close();
                
        //        GridView1.EditIndex = -1;
        //        GridView1.DataBind();

        //        Response.Write("<script>alert('Gut gemacht');</script>");
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script>alert('" + ex.Message + "');</script>");
        //    }
        //}

        
    }
}