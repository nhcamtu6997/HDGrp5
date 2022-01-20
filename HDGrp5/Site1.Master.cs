using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HDGrp5
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void b_dashboard_click(object sender, EventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }

        protected void b_create_ticket_click(object sender, EventArgs e)
        {
            Response.Redirect("createticket.aspx");
        }
    }
}