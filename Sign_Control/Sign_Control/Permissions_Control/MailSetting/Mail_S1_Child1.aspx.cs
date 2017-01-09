using System;
using System.Data;
using System.Xml.Xsl;
using System.Xml;
using System.Data.SqlClient;
using Ext.Net;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web;
using System.Text;
using EDA_Sign;//for tool

namespace EDA_Mail
{
    public partial class Mail_S1_Child1 : Init
    {
        static string connStr = System.Configuration.ConfigurationManager.AppSettings["KSPCBDB10"];
        static string strTableName = "";
        static string strAction = "";
        static string strDetails = "";
        static string _msg = "";
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
            dtTemp = DBProcess_mail.Query_Data();
            this.Storemail.DataSource = dtTemp;
            this.Storemail.DataBind();
        }

        // After serarch data  , keep the data
        protected void LookupReFlash(string Category, string Part_Id, string EDA_Item)
        {
            _msg = null;
            dtTemp = DBProcess_mail.LookupSign(Category, Part_Id, EDA_Item, ref _msg);
            this.Storemail.DataSource = dtTemp;
            this.Storemail.DataBind();
        }

 

 
 
 

    }
}