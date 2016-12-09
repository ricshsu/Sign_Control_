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
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;


namespace EDA_IBF
{
    public partial class sample_2 : Init
    {
        static string connStr = System.Configuration.ConfigurationSettings.AppSettings["PCBDB39"];
        static string strGP_Id = "";
        static string strGP_Desc = "";
        static Boolean isFirst;
        static string _msg = "";

        static DataTable maxid;
 
        static DataTable dtTemp;

        public object TestData
        {
            get
            {
                String sql = "";
                SqlConnection connection = new SqlConnection(connStr); //建立連線
                connection.Open();//開啟連線
                sql += "SELECT distinct Parameter_Id ";
                sql += "FROM [EDA].[dbo].[ADTEC_SpecSetup]";

                SqlDataAdapter command = new SqlDataAdapter(sql, connection);
                DataTable dt = new DataTable(); //DataSet可以離線使用
                command.Fill(dt); //資料庫直接給值給ds
                object[] oData = new object[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    oData[i] = new object[] { dt.Rows[i]["Parameter_Id"] };
                }
                return oData;
            }
        }
   

        protected void Page_Load(object sender, EventArgs e)
        {

              
        }

        protected void Upload_1(object sender, EventArgs e)
        {
            // upload file asp.net 元件
            string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload_ASP.PostedFile.FileName);//讀檔
            FileUpload_ASP.SaveAs(csvPath);//temp file
            DataTable dt = new DataTable();
            _msg = "";
//            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("GP_Id", typeof(string)), new DataColumn("GP_Desc", typeof(string)), new DataColumn("Revisor", typeof(string)), new DataColumn("Revise_Date", typeof(string)) });
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
            int countID = int.Parse(maxid.Rows[0][0].ToString())+1;

            for (int i = 0; i < dt.Rows.Count; i++) //匯入資料庫
            {
                DBProcess_.Upload_Data(countID+ i, dt.Rows[i]["Customer_ID"].ToString().Trim(), dt.Rows[i]["Category"].ToString().Trim(), dt.Rows[i]["Part"].ToString().Trim(), dt.Rows[i]["Part_Id"].ToString().Trim(), dt.Rows[i]["Yield_Impact_Item"].ToString().Trim(), dt.Rows[i]["Key_Module"].ToString().Trim(), dt.Rows[i]["Data_Source"].ToString().Trim(), dt.Rows[i]["Critical_Item"].ToString().Trim(), dt.Rows[i]["EDA_Item"].ToString().Trim(), dt.Rows[i]["MAIN_ID"].ToString().Trim(), "rice", ref _msg);
            }

        }
 


        [DirectMethod]
        protected void finish_message(int count) // ext show message
        {
            X.Msg.Alert("Status", "update finish. it was insert " + count + " records ").Show();

        }
 
 

        protected void Upload_2(object sender, EventArgs e)
        {
            //showmessage();
         
            // upload file ext.net 元件
            string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(BasicFieldEXT_1.PostedFile.FileName);//讀檔
            Response.Write("<p>" + BasicFieldEXT_1.PostedFile.FileName + "</p>\n");
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
            int count = 1; 
            for (int i = 0; i < dt.Rows.Count; i++) //匯入資料庫
            {
                DBProcess_.Upload_Data(countID + i, dt.Rows[i]["Customer_ID"].ToString().Trim(), dt.Rows[i]["Category"].ToString().Trim(), dt.Rows[i]["Part"].ToString().Trim(), dt.Rows[i]["Part_Id"].ToString().Trim(), dt.Rows[i]["Yield_Impact_Item"].ToString().Trim(), dt.Rows[i]["Key_Module"].ToString().Trim(), dt.Rows[i]["Data_Source"].ToString().Trim(), dt.Rows[i]["Critical_Item"].ToString().Trim(), dt.Rows[i]["EDA_Item"].ToString().Trim(), dt.Rows[i]["MAIN_ID"].ToString().Trim(), "rice", ref _msg);
                count = i;
            }
            finish_message(count);
        
        }

        //DATATABLE 資料匯出EXCEL
        protected void ButtonExpEXCEL(object sender, Ext.Net.DirectEventArgs e)
        {
            dtTemp = DBProcess.Get_Test_file();

            //建立Excel 2003檔案
            IWorkbook wb = new HSSFWorkbook();
            ISheet ws;

            ////建立Excel 2007檔案
            //IWorkbook wb = new XSSFWorkbook();
            //ISheet ws;

            if (dtTemp.TableName != string.Empty)
            {
                ws = wb.CreateSheet(dtTemp.TableName);
            }
            else
            {
                ws = wb.CreateSheet("Sheet1");
            }

            ws.CreateRow(0);//第一行為欄位名稱
            for (int i = 0; i < dtTemp.Columns.Count; i++)
            {
                ws.GetRow(0).CreateCell(i).SetCellValue(dtTemp.Columns[i].ColumnName);
            }

            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                ws.CreateRow(i + 1);
                for (int j = 0; j < dtTemp.Columns.Count; j++)
                {
                    ws.GetRow(i + 1).CreateCell(j).SetCellValue(dtTemp.Rows[i][j].ToString());
                }
            }

            FileStream file = new FileStream(@"C:\npoi.xls", FileMode.Create);//產生檔案
            wb.Write(file);
            file.Close();
           // Excel_.exp();

        }

        protected void Button_Upload_EXT(object sender, DirectEventArgs e)
        {

            //Upload and save the file (EXT.NET)
            string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(BasicFieldEXT.PostedFile.FileName);//讀檔
            // BasicFieldEXT.SaveDelay();
            DataTable dt = new DataTable();
            _msg = "";
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("GP_Id", typeof(string)), new DataColumn("GP_Desc", typeof(string)), new DataColumn("Revisor", typeof(string)), new DataColumn("Revise_Date", typeof(string)) });

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

            for (int i = 0; i < dt.Rows.Count; i++) //匯入資料庫
            {
                DBProcess.Update_eGP(dt.Rows[i]["GP_Id"].ToString().Trim(), dt.Rows[i]["GP_Desc"].ToString().Trim(), dt.Rows[i]["Revisor"].ToString().Trim(), dt.Rows[i]["Revise_Date"].ToString().Trim(), "rice", ref _msg);
            }

        }

        // ext.net sample test
 

    }
}