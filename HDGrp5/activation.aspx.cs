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
  
    public partial class activation : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        private void activate()
        {


            int id = Int32.Parse(Request.QueryString["id"]);
            string hash = Request.QueryString["activationhash"];
            con = new SqlConnection(strcon);
            con.Open(); 
            var text = "UPDATE g5_users SET active = 1 WHERE id=@id AND activation_hash=@hash;";
            cmd = new SqlCommand(text, con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@hash", hash);
            cmd.ExecuteNonQuery();


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            activate();
        }
        
    }

    
}