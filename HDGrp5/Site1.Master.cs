﻿using System;
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
            try
            {
                if (Session["admin"] != null)
                {
                    btnDashboardAoU.Visible = true;
                    btnCreateTicket.Visible = false;
                    btnLogoutOrIn.Text = "Logout";
                    lblHello.Visible = true;
                    lblHello.Text = "Hello admin " + Session["admin"].ToString();
                }
                else if (Session["user"] != null)
                {
                    btnDashboardAoU.Visible = true;
                    btnCreateTicket.Visible = true;
                    btnLogoutOrIn.Text = "Logout";
                    lblHello.Visible = true;
                    lblHello.Text = "Hello " + Session["user"].ToString();
                }
            }
            catch
            {

            }
            
        }

        protected void btnDashboardAoU_Click(object sender, EventArgs e)
        {
            if(Session["admin"] != null)
            {
                Response.Redirect("dashboardadmin.aspx");
            }
            else if (Session["user"] != null)
            {
                Response.Redirect("dashboarduser.aspx");
            }
            
           
        }

        protected void btnCreateTicket_Click(object sender, EventArgs e)
        {
            Response.Redirect("createticket.aspx");
        }

        protected void btnLogoutOrIn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

       
    }
}