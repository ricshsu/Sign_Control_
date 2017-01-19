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
using EDA_tool;


namespace EDA_Mail
{
    public partial class Child2_ : System.Web.UI.Page 
    {
        static string _msg = "";
        static DataTable dtTemp;
        static DataTable maxid;
        
// reload
         protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ReFlash();
            }
        }
        
        protected void ReFlash()
        {
            String SYSTEM_ID = "WB";
            _msg = "";
            dtTemp = DBProcess_mail.Query_Data(SYSTEM_ID, ref _msg);
            this.Storemail.DataSource = dtTemp;
            this.Storemail.DataBind();
        }
        
        //新增資料
        protected void btnNew_DirectClick(object sender, Ext.Net.DirectEventArgs e)
            {
                string New_SYSTEM_ID = "WB";
                string New_USER_NOTES = this.New_USER_NOTES.Text;
                string New_MAIL_ADS = this.New_MAIL_ADS.Text;
                string New_IS_SEND = this.New_IS_SEND.Text.ToUpper();
                string New_IS_MODIFY = this.New_IS_MODIFY.Text.ToUpper();
                string New_IS_CC = this.New_IS_CC.Text.ToUpper();
                string New_Name = this.New_Name.Text;
                _msg = "";

                string[] check = { New_USER_NOTES, New_MAIL_ADS, New_IS_SEND, New_IS_MODIFY, New_IS_CC, New_Name };    
                List<string> finishcheck = new List<string>();               
                
              //判斷格式是否正確      
                bool result1 = Groceries.IsNumeric(New_USER_NOTES);
                    if (result1)  { finishcheck.Add("true"); }
                    else{ finishcheck.Add("false"); }
                bool result2 = Groceries.IsmailValid(New_MAIL_ADS);
                    if (result2) { finishcheck.Add("true"); }
                    else { finishcheck.Add("false"); }
                bool result3 = Groceries.checkFormat( New_IS_SEND);
                    if (result3) { finishcheck.Add("true"); }
                    else { finishcheck.Add("false"); }
                bool result4 = Groceries.checkFormat( New_IS_MODIFY);
                    if (result4) { finishcheck.Add("true"); }
                    else { finishcheck.Add("false"); }
                bool result5 = Groceries.checkFormat( New_IS_CC);
                    if (result5) { finishcheck.Add("true"); }
                    else { finishcheck.Add("false"); }

                //格式正確後，才把資料匯入資料庫
                bool FalseExists = finishcheck.Exists(element => element == "false");
                if (FalseExists != true)
                    {
                        DBProcess_mail.Insert_Data(New_SYSTEM_ID, New_USER_NOTES, New_MAIL_ADS, New_IS_SEND, New_IS_MODIFY, New_IS_CC, New_Name, ref  _msg);
                        ReFlash();
                        X.MessageBox.Alert("提示", "已新增以下資料 USER_NOTES:" + New_USER_NOTES + "  MAIL_ADS:" + New_MAIL_ADS).Show();
                    }
                else {
                        X.MessageBox.Alert("提示", "格式有誤，請檢查格式").Show();
                    }
                  
            }



 
        }       
}