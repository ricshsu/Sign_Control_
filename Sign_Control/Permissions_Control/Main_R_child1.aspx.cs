using System;
using System.Data;
using System.Xml.Xsl;
using System.Xml;
using System.Data.SqlClient;
using Ext.Net;
using System.Diagnostics;
using System.Collections.Generic;
using Permissions_Control;
using System.IO;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web;

namespace EDA_Sign
{
    public partial class sample_3 : Init
    {
        static string connStr = System.Configuration.ConfigurationSettings.AppSettings["PCBDB39"];
        static string strTableName = "";
        static string strAction = "";
        static string strDetails = "";
        static string _msg = "";
        static Boolean isFirst;
        static DataTable dtTemp;



// reload
 

         protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReFlash();
            }
        }

        protected void Cell_Click(object sender, DirectEventArgs e)
        {
            strTableName = e.ExtraParams["strTableName"];
            strAction = e.ExtraParams["strAction"];
            strDetails = e.ExtraParams["Details"];
        }

 

        protected void ReFlash()
        {
            dtTemp = DBProcess_.Query_Data();
            this.Store1.DataSource = dtTemp;
            this.Store1.DataBind();
        }
        //更新資料
        protected void btnUpdae_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            string userID = HttpContext.Current.Session["checklogin"].ToString();
            System.Threading.Thread.Sleep(300);
            string Text_Customer_ID = this.Text_Customer_ID.Text;
            int Text_Id = Int32.Parse(this.Text_Id.Text);
            _msg = "";

            DBProcess_.Updata_Data(Text_Id, Text_Customer_ID, userID, ref _msg);
            X.MessageBox.Alert("提示", "button was pressed ,and value was ：" + Text_Id + " and " + Text_Customer_ID + ":::" + _msg).Show();
            ReFlash();
        }

        //刪除資料
        protected void btnDel_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {

            string userID = HttpContext.Current.Session["checklogin"].ToString();
            System.Threading.Thread.Sleep(300);
            string Text_Customer_ID = this.Text_Customer_ID.Text;
            int Text_Id = Int32.Parse(this.Text_Id.Text);
            _msg = "";
            X.MessageBox.Alert("提示", "button was pressed ,and value was ：" + Text_Id + " and " + Text_Customer_ID).Show();
            DBProcess_.Updata_Data(Text_Id, Text_Customer_ID, userID, ref _msg);

            ReFlash();
        }

     }  
}