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
  
        public partial class Main_ : Init
        {
            static string _msg = "";
            static DataTable Mailmaxid;


            protected void Page_Load(object sender, EventArgs e)
            {

            }
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

                Mailmaxid = DBProcess_sign.maxID();
                int countID = int.Parse(Mailmaxid.Rows[0][0].ToString()) + 1;

                for (int i = 1; i < dt.Rows.Count; i++) //匯入資料庫，剃除表頭
                {
                    DBProcess_sign.Upload_Data(countID + i, dt.Rows[i]["Customer_ID"].ToString().Trim(), dt.Rows[i]["Category"].ToString().Trim(), dt.Rows[i]["Part"].ToString().Trim(), dt.Rows[i]["Part_Id"].ToString().Trim(), dt.Rows[i]["Yield_Impact_Item"].ToString().Trim(), dt.Rows[i]["Key_Module"].ToString().Trim(), dt.Rows[i]["Data_Source"].ToString().Trim(), dt.Rows[i]["Critical_Item"].ToString().Trim(), dt.Rows[i]["EDA_Item"].ToString().Trim(), dt.Rows[i]["MAIN_ID"].ToString().Trim(), userID, ref _msg);
                    if (_msg != "")
                    {
                        X.MessageBox.Alert("提示", "Import data was error format problem ").Show();
                        Groceries.Delfile(csvPath);
                        break;
                    }
                }
                  X.MessageBox.Alert("提示", "共 " + dt.Rows.Count + "筆，更新完畢。").Show();
                  System.Threading.Thread.Sleep(300);
                  Groceries.Delfile(csvPath);
                  Panel2.Reload();
                  Panel1.Reload();
  
            }

 

        }

 
   
}