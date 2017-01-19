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
using EDA_tool;//for tool

namespace EDA_Mail
{
    public partial class Mail_S1_Child1 : System.Web.UI.Page 
    {
      //  static string connStr = System.Configuration.ConfigurationManager.AppSettings["KSPCBDB10"];
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
            String SYSTEM_ID = "WB";
            _msg = "";
            dtTemp = DBProcess_mail.Query_Data(SYSTEM_ID,ref _msg);
            this.Storemail.DataSource = dtTemp;
            this.Storemail.DataBind();
        }

        // After serarch data  , keep the data
        protected void LookupReFlash(string SYSTEM_ID, string USER_NOTES, string MAIL_ADS)
        {
            _msg = null;
            dtTemp = DBProcess_mail.Lookup_(SYSTEM_ID, USER_NOTES, MAIL_ADS, ref _msg);
            this.Storemail.DataSource = dtTemp;
            this.Storemail.DataBind();
        }

        //update data

        //更新資料
        protected void btnDel_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            string Text_SYSTEM_ID = this.Text_SYSTEM_ID.Text;
            string Text_USER_NOTES = this.Text_USER_NOTES.Text;
            string Text_MAIL_ADS = this.Text_MAIL_ADS.Text;
            string Text_IS_SEND = this.Text_IS_SEND.Text;
            string Text_IS_MODIFY = this.Text_IS_MODIFY.Text;
            string Text_IS_CC = this.Text_IS_CC.Text;
            string Text_Name = this.Text_Name.Text;

            _msg = "";

            DBProcess_mail.Del_Data(Text_SYSTEM_ID, Text_MAIL_ADS, Text_USER_NOTES, ref _msg);
            X.MessageBox.Alert("提示", "DATA：" + Text_USER_NOTES + Text_MAIL_ADS + "   successful updated").Show();
            ReFlash();
        }

        //查詢資料

        //查詢資料
        protected void btnLookup_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {        
            string Find_SYSTEM_ID ="WB";
            string Find_USER_NOTES = this.Find_USER_NOTES.Text;
            string Find_MAIL_ADS = this.Find_MAIL_ADS.Text;
            _msg = "";
            LookupReFlash(Find_SYSTEM_ID, Find_USER_NOTES, Find_MAIL_ADS);
            String counts = DBProcess_mail.Count(Find_SYSTEM_ID, Find_USER_NOTES, Find_MAIL_ADS ,ref _msg);
            X.MessageBox.Alert("提示", " After search , all have   " + counts + " counts ").Show();

        }

 

    }
}