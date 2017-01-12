using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Web;
using System.Text;


namespace EDA_tool 
{ 
	public class Init : System.Web.UI.Page 
	{
        
         private void Page_Init(object sender, System.EventArgs e) 
         {
             
             //writer down license  
             string LicenseKey = "net,5,9999-11-11";
             byte[] b = Encoding.Default.GetBytes(LicenseKey);
             LicenseKey = Convert.ToBase64String(b);
             Session["Ext.Net.LicenseKey"] = LicenseKey;

             //login log
             string _Mailmsg = "";
             string userID = Request.LogonUserIdentity.Name.Split('\\')[1].Trim().ToUpper();
             Session["checklogin"] = userID;
             _Mailmsg = "";
             DBProcess_sign.Login_log(userID, ref _Mailmsg);
 
             //Delete log
             DBProcess_com.DelLog(userID);

         }
 
 	} 
 } 
