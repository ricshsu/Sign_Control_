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

namespace EDA_Sign
{
    public partial class Sign_Ctrl : Init
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
            DBProcess_sign.Login_log(userID, ref _msg);

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
            dtTemp = DBProcess_sign.Query_Data();
            this.Store1.DataSource = dtTemp;
            this.Store1.DataBind();
        }

    
        //protected void LookupReFlash(string Category, string Part_Id,string  EDA_Item) {
        //    _msg = null;
        //    dtTemp = DBProcess_.LookupSign(Category, Part_Id, EDA_Item, ref _msg);
        //    this.Store1.DataSource = dtTemp;
        //    this.Store1.DataBind();
        //}

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

            DBProcess_sign.Updata_Data(Text_Id, Text_Customer_ID, Text_Category, Text_Part, Text_Yield_Impact_Item, Text_Key_Module, Text_Data_Source, Text_Critical_Item, Text_MAIN_ID, userID, ref _msg);
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

            DBProcess_sign.Del_Data(Text_Id, userID, ref _msg);
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

            // After serarch data  , keep the data
            dtTemp = DBProcess_sign.LookupSign(Category, Part_Id, EDA_Item, ref _msg);
            this.Store1.DataSource = dtTemp;
            this.Store1.DataBind();


            String counts = DBProcess_sign.Signcount(Category, Part_Id, EDA_Item, ref _msg);
            X.MessageBox.Alert("提示", " After search , all have   " + counts + " counts ").Show();

        }

        //上傳資料

            protected void Upload_1(object sender, EventArgs e)
            {

                // upload file asp.net 元件
                string userID = Request.LogonUserIdentity.Name.Split('\\')[1].Trim().ToUpper(); 
                string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload_ASP.PostedFile.FileName);//讀檔
                FileUpload_ASP.SaveAs(csvPath);//temp file
                DataTable dt = new DataTable();
                _msg = "";
                dt.Columns.AddRange(new DataColumn[10] { new DataColumn("Customer_ID", typeof(string)), new DataColumn("Category", typeof(string)), new DataColumn("Part", typeof(string)), new DataColumn("Part_Id", typeof(string)), new DataColumn("Yield_Impact_Item", typeof(string)), new DataColumn("Key_Module", typeof(string)), new DataColumn("Data_Source", typeof(string)), new DataColumn("Critical_Item", typeof(string)), new DataColumn("EDA_Item", typeof(string)), new DataColumn("MAIN_ID", typeof(string)) });
                string csvData = File.ReadAllText(csvPath);

               
                foreach (string row in csvData.Split('\n')) //讀csv檔
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        dt.Rows.Add();
                        int i = 0;

                        foreach (string cell in row.Split(','))
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell;
                            i++;
                        }
                    }

                }

                maxid = DBProcess_sign.maxID();
                int countID = int.Parse(maxid.Rows[0][0].ToString()) + 1;

                for (int i = 1; i < dt.Rows.Count; i++) //匯入資料庫，剃除表頭
                {
                    DBProcess_sign.Upload_Data(countID + i, dt.Rows[i]["Customer_ID"].ToString().Trim(), dt.Rows[i]["Category"].ToString().Trim(), dt.Rows[i]["Part"].ToString().Trim(), dt.Rows[i]["Part_Id"].ToString().Trim(), dt.Rows[i]["Yield_Impact_Item"].ToString().Trim(), dt.Rows[i]["Key_Module"].ToString().Trim(), dt.Rows[i]["Data_Source"].ToString().Trim(), dt.Rows[i]["Critical_Item"].ToString().Trim(), dt.Rows[i]["EDA_Item"].ToString().Trim(), dt.Rows[i]["MAIN_ID"].ToString().Trim(), userID, ref _msg);
                    if (_msg != "")
                    {
                        X.MessageBox.Alert("提示", "Import data was error format problem ").Show();
                        break;
                    }
                }
                  X.MessageBox.Alert("提示", "共 " + dt.Rows.Count + "筆，更新完畢。").Show();
                  System.Threading.Thread.Sleep(300);
                  Panel2.Reload();
  
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

                maxid = DBProcess_sign.maxID();
                ID = int.Parse(maxid.Rows[0][0].ToString())+1;



                DBProcess_sign.Insert_Data(ID, Customer_ID, Category, Part, Part_Id, Yield_Impact_Item, Key_Module, Data_Source, Critical_Item, EDA_Item, MAIN_ID, userID, ref  _msg);
                ReFlash();

                String counts = DBProcess_sign.Signcount(Category, Part_Id, EDA_Item, ref _msg);
                X.MessageBox.Alert("提示", " After search , all have   " + counts + " counts ").Show();

            }


        }

       
}