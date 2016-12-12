using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;


namespace EDA_Sign
{
	public class DBProcess_
	{
        static string connStr = System.Configuration.ConfigurationSettings.AppSettings["PCBDB39"];
        static String sql;
        static String sql_temp;
        static DataTable dt = new DataTable();
        static String _msg;
        static StringBuilder sb = new StringBuilder();

        static List<string> lisSQL = new List<string>();

        public static DataTable Query_Data()
        {
            sql = " SELECT ID,Customer_ID,Category,Part,Part_Id,Yield_Impact_Item,Key_Module,Data_Source,Critical_Item,EDA_Item,MAIN_ID";
            sql += " FROM eSPC.dbo.Sample_for_test_2016";
            sql += " WHERE 1 = 1";
             _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);
            return dt;
        }

        public static DataTable maxID()
        {

            sql = "select  ISNULL(MAX(ID), 0) AS MaxX from eSPC.dbo.Sample_for_test_2016;";
            dt = GFun.GetDTable(connStr, sql, ref _msg);
            return dt;
        }

        public static DataTable QueryUser()
        {

            sql = "select  ISNULL(MAX(ID), 0) AS MaxX from eSPC.dbo.Sample_for_test_2016;";
            dt = GFun.GetDTable(connStr, sql, ref _msg);
            return dt;
        }

        //上傳資料
        public static string Upload_Data(int ID ,  string Customer_ID, string Category, string Part, string Part_Id, string Yield_Impact_Item, string Key_Module, string Data_Source, string Critical_Item, string EDA_Item, string MAIN_ID, string man, ref string _Msg)
        {
            sql = " INSERT eSPC.dbo.Sample_for_test_2016 VALUES (";
            sql += "  '" + ID + "'";
            sql += " , '" + Customer_ID + "'";
            sql += " , '" + Category + "'";
            sql += " , '" + Part + "'";
            sql += " , '" + Part_Id + "'";
            sql += " , '" + Yield_Impact_Item + "'";
            sql += " , '" + Key_Module + "'";
            sql += " , '" + Data_Source + "'";
            sql += " , '" + Critical_Item + "'";
            sql += " , '" + EDA_Item + "'";
            sql += " , '" + MAIN_ID + "'";
            sql += "  )";

            lisSQL.Clear();
            lisSQL.Add(sql);
            sql_temp = sql;
            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            if (_Msg != "") return _Msg;

            sql = " INSERT INTO EDA.dbo.Access_Permission_LOG_Info";
            sql += " (TableName, Action, Details, Revisor, Revise_Date)";
            sql += " VALUES('Access_Permission_GP_Info','M','" + lisSQL[0].Replace("'", "''") + "','" + man + "','" + Tools.Get_Now() + "')";

            lisSQL.Clear();
            lisSQL.Add(sql);
            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            return _Msg;
        }

        //單筆資料更新
        public static string Updata_Data(int ID, string Customer_ID, string man, ref string _Msg)
        {
            sql = " UPDATE eSPC.dbo.Sample_for_test_2016 ";
            sql += "SET Customer_ID='" + Customer_ID + "'";
            sql += "WHERE ID='" + ID + "'";
            sql += " ;";

            lisSQL.Clear();
            lisSQL.Add(sql);
            sql_temp = sql;
            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            if (_Msg != "") return _Msg;

            sql = " INSERT INTO EDA.dbo.Access_Permission_LOG_Info";
            sql += " (TableName, Action, Details, Revisor, Revise_Date)";
            sql += " VALUES('Access_Permission_GP_Info','M','" + lisSQL[0].Replace("'", "''") + "','" + man + "','" + Tools.Get_Now() + "')";

            lisSQL.Clear();
            lisSQL.Add(sql);
            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            return _Msg;
        }

        //刪除資料
        public static string Deldata_Data(int ID, string Customer_ID, string man, ref string _Msg)
        {
            sql = " UPDATE eSPC.dbo.Sample_for_test_2016 ";
            sql += "SET Customer_ID='" + Customer_ID + "'";
            sql += "WHERE ID='" + ID + "'";
            sql += " ;";

            lisSQL.Clear();
            lisSQL.Add(sql);
            sql_temp = sql;
            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            if (_Msg != "") return _Msg;

            sql = " INSERT INTO EDA.dbo.Access_Permission_LOG_Info";
            sql += " (TableName, Action, Details, Revisor, Revise_Date)";
            sql += " VALUES('Access_Permission_GP_Info','M','" + lisSQL[0].Replace("'", "''") + "','" + man + "','" + Tools.Get_Now() + "')";

            lisSQL.Clear();
            lisSQL.Add(sql);
            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            return _Msg;
        }
	}
}