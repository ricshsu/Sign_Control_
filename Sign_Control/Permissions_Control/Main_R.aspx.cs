﻿using System;
using System.Data;
using System.Xml.Xsl;
using System.Xml;
using System.Data.SqlClient;
using Ext.Net;
using System.Diagnostics;
using System.Collections.Generic;
//using Permissions_Control;
using System.IO;
using System.Configuration;
using System.Web.UI.WebControls;



namespace EDA_IBF
{
  
        public partial class Sample_ : Init
        {
            static string _msg = "";
            static DataTable maxid;

            protected void Page_Load(object sender, EventArgs e)
            {
                if (Session["checklogin"] == null)
                     X.Redirect("/Main_Login.aspx", "Please login ...");
 
            }

            protected void Button_Click(object sender, DirectEventArgs e)
            {
                Session.Clear();               
                X.Redirect("/Main_Login.aspx","Logout and wait ...");
           
            }


            protected void Upload_1(object sender, EventArgs e)
            {
                // upload file asp.net 元件
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

                maxid = DBProcess_.maxID();
                int countID = int.Parse(maxid.Rows[0][0].ToString()) + 1;

                for (int i = 0; i < dt.Rows.Count; i++) //匯入資料庫
                {
                    DBProcess_.Upload_Data(countID + i, dt.Rows[i]["Customer_ID"].ToString().Trim(), dt.Rows[i]["Category"].ToString().Trim(), dt.Rows[i]["Part"].ToString().Trim(), dt.Rows[i]["Part_Id"].ToString().Trim(), dt.Rows[i]["Yield_Impact_Item"].ToString().Trim(), dt.Rows[i]["Key_Module"].ToString().Trim(), dt.Rows[i]["Data_Source"].ToString().Trim(), dt.Rows[i]["Critical_Item"].ToString().Trim(), dt.Rows[i]["EDA_Item"].ToString().Trim(), dt.Rows[i]["MAIN_ID"].ToString().Trim(), "rice", ref _msg);
                }

            }

        }
   
}