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

namespace EDA_Sign
{
    public partial class Child1_ : Init
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
            dtTemp = DBProcess_.Query_Data();
            this.Store1.DataSource = dtTemp;
            this.Store1.DataBind();
        }

        // After serarch data  , keep the data
        protected void LookupReFlash(string Category, string Part_Id,string  EDA_Item) {
            _msg = null;
            dtTemp = DBProcess_.LookupSign(Category, Part_Id, EDA_Item, ref _msg);
            this.Store1.DataSource = dtTemp;
            this.Store1.DataBind();
        }

        //更新資料
        protected void btnUpdae_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            int Text_Id = Int32.Parse(this.Text_Id.Text);
            string userID = HttpContext.Current.Session["checklogin"].ToString();
            string Text_Customer_ID = this.Text_Customer_ID.Text;
            string Text_Category = this.Text_Category.Text;
            string Text_Part = this.Text_Part.Text;
            string Text_Yield_Impact_Item = this.Text_Yield_Impact_Item.Text;
            string Text_Key_Module = this.Text_Key_Module.Text;
            string Text_Data_Source = this.Text_Data_Source.Text;
            string Text_Critical_Item = this.Text_Critical_Item.Text;
            string Text_MAIN_ID = this.Text_MAIN_ID.Text;

            _msg = "";

            System.Threading.Thread.Sleep(300);

            DBProcess_.Updata_Data(Text_Id, Text_Customer_ID, Text_Category, Text_Part, Text_Yield_Impact_Item, Text_Key_Module, Text_Data_Source, Text_Critical_Item, Text_MAIN_ID, userID, ref _msg);
            X.MessageBox.Alert("提示", "ID ：" + Text_Id + "  data successful updated").Show(); 
            ReFlash();
        }

        //刪除資料
        protected void btnDel_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
   
            string userID = HttpContext.Current.Session["checklogin"].ToString();
            System.Threading.Thread.Sleep(300);

            string Text_Customer_ID = this.Text_Customer_ID.Text;
            int Text_Id = Int32.Parse(this.Text_Id.Text); 

            string Category_ = Find_Category.Text;
            string Part_Id_ = Find_Part_Id.Text;
            string EDA_Item_ = Find_EDA_Item.Text;

            _msg = "";
            

                DBProcess_.Del_Data(Text_Id, userID, ref _msg);
                X.MessageBox.Alert("提示", "ID ：" + Text_Id + "  data successful delete").Show();
                ReFlash();     

 

        }



        //查詢資料
        protected void btnLookup_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {

            string userID = HttpContext.Current.Session["checklogin"].ToString();
            string Category = Find_Category.Text;
            string Part_Id = Find_Part_Id.Text;
            string EDA_Item = Find_EDA_Item.Text;
            _msg = "";
            LookupReFlash(Category, Part_Id, EDA_Item);
            String counts = DBProcess_.Signcount(Category, Part_Id, EDA_Item, ref _msg);
            X.MessageBox.Alert("提示", " After search , all have   " + counts + " counts ").Show();

        }

     }  
}