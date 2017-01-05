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

namespace EDA_Sign
{
    public partial class Child2_ : Init
    {
        static string connStr = System.Configuration.ConfigurationManager.AppSettings["KSPCBDB10"];
        static string _msg = "";
        static DataTable dtTemp;
        static DataTable maxid;



// reload
 

         protected void Page_Load(object sender, EventArgs e)
        {
            string userID = Request.LogonUserIdentity.Name.Split('\\')[1].Trim().ToUpper();
            Session["checklogin"] = userID;
            _msg = "";
            DBProcess_.Login_log(userID, ref _msg);

            //writer down license inju
            string LicenseKey = "net,5,9999-11-11";
            byte[] b = Encoding.Default.GetBytes(LicenseKey);
            LicenseKey = Convert.ToBase64String(b);
            Session["Ext.Net.LicenseKey"] = LicenseKey;

            if (!IsPostBack)
            {
                ReFlash();
            }
        }


        protected void ReFlash()
        {
            dtTemp = DBProcess_.Query_Data();
            this.Store1.DataSource = dtTemp;
            this.Store1.DataBind();
        }

 
           

        //新增資料
            protected void btnNew_DirectClick(object sender, Ext.Net.DirectEventArgs e)
            {

                string userID = HttpContext.Current.Session["checklogin"].ToString();
                int ID ;
                string Customer_ID = New_Customer_ID.Text;
                string Category = New_Category.Text;
                string Part = New_Part.Text;
                string Part_Id = New_Part_Id.Text;
                string Yield_Impact_Item = New_Yield_Impact_Item.Text;
                string Key_Module = New_Key_Module.Text;
                string Data_Source = New_Data_Source.Text;
                string Critical_Item = New_Critical_Item.Text;
                string EDA_Item = New_EDA_Item.Text;
                string MAIN_ID = New_MAIN_ID.Text;

                _msg = "";

                maxid = DBProcess_.maxID();
                ID = int.Parse(maxid.Rows[0][0].ToString())+1;



                DBProcess_.Insert_Data(ID, Customer_ID, Category, Part, Part_Id, Yield_Impact_Item, Key_Module, Data_Source, Critical_Item, EDA_Item, MAIN_ID, userID, ref  _msg);
                ReFlash();
 
                String counts = DBProcess_.Signcount(Category, Part_Id, EDA_Item, ref _msg);
                X.MessageBox.Alert("提示", " After search , all have   " + counts + " counts ").Show();

            }


        }

       
}