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
    // Still need to add function view and delete ticket
    public partial class dashboard : System.Web.UI.Page
    {
        // Connection String
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["user"] == null)
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
            var query = "SELECT id, title, user_id, kategorie_name, create_date FROM g5_tickets WHERE user_id=@user_id";

            cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@user_id",Session["userID"].ToString());
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
    }
}