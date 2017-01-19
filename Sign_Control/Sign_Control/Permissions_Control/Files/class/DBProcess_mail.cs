using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;


namespace EDA_tool
{
    public class DBProcess_mail
    {
        static string connStr = System.Configuration.ConfigurationManager.AppSettings["KSPCBDB10"];
        static String sql;
        static String sql_temp;
        static DataTable dt = new DataTable();
        static String _msg;
        static StringBuilder sb = new StringBuilder();

        static List<string> lisSQL = new List<string>();

        public static DataTable Query_Data(string SYSTEM_ID, ref string _Msg)
        {
            sql = " SELECT SYSTEM_ID,USER_NOTES,MAIL_ADS,IS_SEND,IS_MODIFY,IS_CC,Name";
            sql += " FROM EDA.dbo.Daily_Yield_OOC_MAIL_fortest";
            sql += " WHERE SYSTEM_ID='" + SYSTEM_ID + "'";
            sql += " AND 1 = 1";
            _msg = "ORDER BY ID;";

            dt = SQLCheck.GetDTable(connStr, sql, ref _msg);
            return dt;
        }

 
        //單筆資料刪除
        public static string Del_Data(string SYSTEM_ID, string MAIL_ADS, string USER_NOTES, ref string _Msg)
        {
            sql = " DELETE FROM  EDA.dbo.Daily_Yield_OOC_MAIL_fortest";
            sql += " WHERE SYSTEM_ID='" + SYSTEM_ID + "'";
            sql += " AND (MAIL_ADS ='" + MAIL_ADS + "'";
            sql += " OR USER_NOTES ='" + USER_NOTES + "')";
            sql += " ;";

            lisSQL.Clear();
            lisSQL.Add(sql);
            sql_temp = sql;
            _Msg = "";
            SQLCheck.ExSql(lisSQL, ref _Msg);

            if (_Msg != "") return _Msg;

            return _Msg;
        }


        //條件資料查詢
        public static DataTable Lookup_(string SYSTEM_ID, string USER_NOTES, string MAIL_ADS, ref string _Msg)
        {
            sql = " SELECT * FROM EDA.dbo.Daily_Yield_OOC_MAIL_fortest ";
            sql += "WHERE SYSTEM_ID = '" + SYSTEM_ID + "'" + " AND ( USER_NOTES = " + "'" + USER_NOTES + "'" + "OR MAIL_ADS = " + "'" + MAIL_ADS + "')";
            sql += " ;";

            lisSQL.Clear();
            lisSQL.Add(sql);
            sql_temp = sql;
            _Msg = "";

            dt = SQLCheck.GetDTable(connStr, sql, ref _msg);
            return dt;
        }

        //查詢筆數
        public static string Count(string SYSTEM_ID, string USER_NOTES, string MAIL_ADS, ref string _Msg)
        {

            sql = " SELECT count(*) counts FROM EDA.dbo.Daily_Yield_OOC_MAIL_fortest ";
            sql += "WHERE SYSTEM_ID = '" + SYSTEM_ID + "'" + " AND ( USER_NOTES = " + "'" + USER_NOTES + "'" + "OR MAIL_ADS = " + "'" + MAIL_ADS + "')";
            sql += " ;";

            lisSQL.Clear();
            lisSQL.Add(sql);
            sql_temp = sql;
            _Msg = "";
            dt = SQLCheck.GetDTable(connStr, sql, ref _msg);

            return dt.Rows[0][0].ToString();

        }

        //INERT DATA
        //single data insert 
        public static string Insert_Data(string SYSTEM_ID, string USER_NOTES, string MAIL_ADS, string IS_SEND, string IS_MODIFY, string IS_CC, string Name, ref string _Msg)
        {

            sql = " INSERT INTO EDA.DBO.Daily_Yield_OOC_MAIL_fortest ";
            sql += "(SYSTEM_ID,USER_NOTES ,MAIL_ADS ,IS_SEND ,IS_MODIFY ,IS_CC ,Name) VALUES ";
            sql += "('" + SYSTEM_ID + "','" + USER_NOTES + "','" + MAIL_ADS + "','" + IS_SEND + "'";
            sql += ",'" + IS_MODIFY + "','" + IS_CC + "','" + Name + "')";
            sql += " ;";

            lisSQL.Clear();
            lisSQL.Add(sql);
            sql_temp = sql;
            _Msg = "";
            SQLCheck.ExSql(lisSQL, ref _Msg);

            return _Msg;
        }





    }
}