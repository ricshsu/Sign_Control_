using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace EDA_tool
{
	public class DBProcess_com
	{
        static string connStr = System.Configuration.ConfigurationManager.AppSettings["PCBDB39"];
        static String sql;
        static String _Msg;
        static List<string> lisSQL = new List<string>();

        public static string DelLog(string USER )
        {
            sql = "DELETE FROM  EDA.DBO.RECORD_STEP_LOG ";
            sql += "WHERE DateDiff(Day,Revise_Date,getdate()) >= 180";
            _Msg = "";

            lisSQL.Clear();
            lisSQL.Add(sql);
            SQLCheck.ExSql(lisSQL, ref _Msg);


            if (_Msg != "") return _Msg;

            // STEP LOG
            sql = " INSERT INTO EDA.DBO.RECORD_STEP_LOG";
            sql += " (TableName, Action, Details, Revisor, Revise_Date)";
            sql += " VALUES('RECORD_STEP_LOG','DELETE','" + lisSQL[0].Replace("'", "''") + "','" + USER + "','" + Groceries.Get_Now() + "')";
            lisSQL.Clear();
            lisSQL.Add(sql);
            _Msg = "";
            SQLCheck.ExSql(lisSQL, ref _Msg);


            return _Msg;


        }

	}
}