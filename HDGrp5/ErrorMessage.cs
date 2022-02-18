using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace HDGrp5
{
    public class ErrorMessage
    {
        public static void showErrorMessage(Label label, string text)
        {
            label.Visible = true;
            label.Text = text;
            label.CssClass = "alert alert-danger";
        }
        public static void showErrorMessage(TextBox textbox, string text)
        {
            textbox.Visible = true;
            textbox.Text = text;
            textbox.CssClass = "alert alert-danger";
        }
    }
}