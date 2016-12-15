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
        static string connStr = System.Configuration.ConfigurationManager.AppSettings["KSPCBDB10"];
        static String sql;
        static String sql_temp;
        static DataTable dt = new DataTable();
        static String _msg;
        static StringBuilder sb = new StringBuilder();

        static List<string> lisSQL = new List<string>();

        public static DataTable Query_Data()
        {
            sql = " SELECT ID,Customer_ID,Category,Part,Part_Id,Yield_Impact_Item,Key_Module,Data_Source,Critical_Item,EDA_Item,MAIN_ID";
            sql += " FROM EDA.dbo.Daily_Kanben_OOC_Monitor";
            sql += " WHERE 1 = 1";
             _msg = "";
             dt = SQLCheck.GetDTable(connStr, sql, ref _msg);
            return dt;
        }

        public static DataTable maxID()
        {

            sql = "select  ISNULL(MAX(ID), 0) AS MaxX from EDA.dbo.Daily_Kanben_OOC_Monitor;";
            dt = SQLCheck.GetDTable(connStr, sql, ref _msg);
            return dt;
        }

        public static DataTable QueryUser()
        {

            sql = "select  ISNULL(MAX(ID), 0) AS MaxX from EDA.dbo.Daily_Kanben_OOC_Monitor;";
            dt = SQLCheck.GetDTable(connStr, sql, ref _msg);
            return dt;
        }

        //上傳資料
        public static string Upload_Data(int ID ,  string Customer_ID, string Category, string Part, string Part_Id, string Yield_Impact_Item, string Key_Module, string Data_Source, string Critical_Item, string EDA_Item, string MAIN_ID, string man, ref string _Msg)
        {
            sql = " INSERT EDA.dbo.Daily_Kanben_OOC_Monitor VALUES (";
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
            SQLCheck.ExSql(lisSQL, ref _Msg);

            if (_Msg != "") return _Msg;

            // STEP LOG
            sql = " INSERT INTO EDA.DBO.RECORD_STEP_LOG";
            sql += " (TableName, Action, Details, Revisor, Revise_Date)";
            sql += " VALUES('Daily_Kanben_OOC_Monitor','UPLOAD','" + lisSQL[0].Replace("'", "''") + "','" + man + "','" + Tools.Get_Now() + "')";
            lisSQL.Clear();
            lisSQL.Add(sql);
            _Msg = "";
            SQLCheck.ExSql(lisSQL, ref _Msg);

            return _Msg;
        }

        //單筆資料更新
        public static string Updata_Data(int ID, string Customer_ID, string Category, string Part, string Yield_Impact_Item, string Key_Module, string Data_Source, string Critical_Item, string MAIN_ID, string man, ref string _Msg)
        {
            sql = " UPDATE EDA.dbo.Daily_Kanben_OOC_Monitor ";
            sql += "SET Customer_ID='" + Customer_ID + "'";
            sql += ",Category='" + Category + "'";
            sql += ",Part='" + Part + "'";
            sql += ",Yield_Impact_Item='" + Yield_Impact_Item + "'";
            sql += ",Key_Module='" + Key_Module + "'";
            sql += ",Data_Source='" + Data_Source + "'";
            sql += ",Critical_Item='" + Critical_Item + "'";
            sql += ",MAIN_ID='" + MAIN_ID + "'";
            sql += "WHERE ID='" + ID + "'";
            sql += " ;";

            lisSQL.Clear();
            lisSQL.Add(sql);
            sql_temp = sql;
            _Msg = "";
            SQLCheck.ExSql(lisSQL, ref _Msg);

            if (_Msg != "") return _Msg;

            //STEP LOG
            sql = " INSERT INTO EDA.DBO.RECORD_STEP_LOG";
            sql += " (TableName, Action, Details, Revisor, Revise_Date)";
            sql += " VALUES('Daily_Kanben_OOC_Monitor','UPDATE_ONE','" + lisSQL[0].Replace("'", "''") + "','" + man + "','" + Tools.Get_Now() + "')";
            lisSQL.Clear();
            lisSQL.Add(sql);
            _Msg = "";
            SQLCheck.ExSql(lisSQL, ref _Msg);

            return _Msg;
        }

        //單筆資料刪除
        public static string Del_Data(int ID, string man, ref string _Msg)
        {
            sql = " DELETE FROM  EDA.dbo.Daily_Kanben_OOC_Monitor ";
            sql += "WHERE ID='" + ID + "'";
            sql += " ;";

            lisSQL.Clear();
            lisSQL.Add(sql);
            sql_temp = sql;
            _Msg = "";
            SQLCheck.ExSql(lisSQL, ref _Msg);

            if (_Msg != "") return _Msg;

            // STEP LOG
            sql = " INSERT INTO EDA.DBO.RECORD_STEP_LOG";
            sql += " (TableName, Action, Details, Revisor, Revise_Date)";
            sql += " VALUES('Daily_Kanben_OOC_Monitor','DEL_ONE','" + lisSQL[0].Replace("'", "''") + "','" + man + "','" + Tools.Get_Now() + "')";
            lisSQL.Clear();
            lisSQL.Add(sql);
            _Msg = "";
            SQLCheck.ExSql(lisSQL, ref _Msg);

            return _Msg;
        }


        //條件資料查詢
        public static DataTable  LookupSign(string Category, string Part_Id, string EDA_Item, ref string _Msg)
        {
            sql = " SELECT * FROM EDA.dbo.Daily_Kanben_OOC_Monitor ";
            sql += "WHERE Category = '" + Category + "'" + "or Part_Id = " + "'" + Part_Id + "'" + "or EDA_Item = " + "'" + EDA_Item + "'";
            sql += " ;";

            lisSQL.Clear();
            lisSQL.Add(sql);
            sql_temp = sql;
            _Msg = "";

            dt = SQLCheck.GetDTable(connStr, sql, ref _msg);
            return dt;
        }
       
        public static string Signcount(string Category, string Part_Id, string EDA_Item, ref string _Msg)
        {

            sql = " SELECT count(*) counts FROM EDA.dbo.Daily_Kanben_OOC_Monitor ";
            sql += "WHERE Category = '" + Category + "'" + "or Part_Id = " + "'" + Part_Id + "'" + "or EDA_Item = " + "'" + EDA_Item + "'";
            sql += " ;";

            lisSQL.Clear();
            lisSQL.Add(sql);
            sql_temp = sql;
            _Msg = "";

            dt = SQLCheck.GetDTable(connStr, sql, ref _msg); 
            
            return   dt.Rows[0][0].ToString() ;
 
        }

        // LOGIN_LOG
        public static string Login_log( string man, ref string _Msg)
        {
            sql = " insert into EDA.DBO.RECORD_STEP_LOG";
            sql += " (tablename, action, details, revisor, revise_date)";
            sql += " values('Daily_Kanben_OOC_Monitor','login','" + "','" + man + "','" + Tools.Get_Now() + "')";
            lisSQL.Clear();
            lisSQL.Add(sql);
            _msg = "";
            SQLCheck.ExSql(lisSQL, ref _Msg);

            return _Msg;
        }

	}
}