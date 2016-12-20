using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Text;

namespace Permissions_Control
{
    public partial class Main_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //writer down license inju
            string LicenseKey = "net,5,2038-11-11";
            byte[] b = Encoding.Default.GetBytes(LicenseKey);
            LicenseKey = Convert.ToBase64String(b);
            Session["Ext.Net.LicenseKey"] = LicenseKey;


        }

        protected void Button1_Click(object sender, DirectEventArgs e)
        {
            Session["checklogin"] = e.ExtraParams["user"];
            e.ExtraParams["user"] = "rice";
            e.ExtraParams["pass"] = "game";

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