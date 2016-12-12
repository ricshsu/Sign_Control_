using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using EDA_Sign;
using System.Data;
using Permissions_Control;

namespace Permissions_Control.ws
{   
    /// <summary>
    /// WS_Permission 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
    // [System.Web.Script.Services.ScriptService]

    public class WS_Permission : System.Web.Services.WebService
    {

        static DataTable dtTemp;
        static Boolean booTemp;

        [WebMethod(EnableSession = true)]
        public Boolean CheckUser(string Name, string Password)
        {
          
          //  dtTemp = DBProcess.Get_Login(Name, Password);

            if (dtTemp.Rows.Count == 1 && dtTemp.Rows[0]["Password"].ToString() == Password)
            {
                Session["USERID"] = Name.ToUpper();
                booTemp = true;
            }
            else
            {
                Session["USERID"] = null;
                Session.Remove("USERID");
                booTemp = false;
            }

            return booTemp;
        }

        [WebMethod(EnableSession = true)]
        public void RemoveSession()
        {
            Session["USERID"] = null;
            Session.Remove("USERID");
        }

        [WebMethod(EnableSession = true)]
        public Boolean CheckSession()
        {
            if (Session["USERID"] == null)
            {
                return false;
            }
            else return true;
        }
    }
}
