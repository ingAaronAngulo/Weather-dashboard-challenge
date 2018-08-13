using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Weather_dashboard_challenge.Model
{
    /// <summary>
    /// Utility class used for making a dialog box, 
    /// static so you can access it quickly
    /// </summary>
    public static class MessageBox
    {
        /// <summary>
        /// Method used to create and show the dialog box
        /// </summary>
        /// <param name="Page">The page where we want to show the dialog box</param>
        /// <param name="Message">The message we want to display</param>
        public static void Show(Page Page, String Message)
        {
            Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "MessageBox",
               "<script language='javascript'>alert('" + Message + "');</script>"
            );
        }
    }
}