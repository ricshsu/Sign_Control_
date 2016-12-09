using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

namespace Permissions_Control
{
    public partial class Main_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, DirectEventArgs e)
        {
            Session["checklogin"] = e.ExtraParams["user"];

            // Do some Authentication...
            if (e.ExtraParams["user"] != "rice" || e.ExtraParams["pass"] != "game")
            {
                e.Success = false;
                e.ErrorMessage = "Invalid username or password.";
            }

        }

        protected string CheckUser()
        {
            string User = null ; 

            return User;
        }
    }
}