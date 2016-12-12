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
    public class DBProcess
    {
        static string connStr = System.Configuration.ConfigurationSettings.AppSettings["PCBDB39"];
        static String sql;
        static String sql_temp;
        static DataTable dt = new DataTable();
        static String _msg;
        static StringBuilder sb = new StringBuilder();

        static List<string> lisSQL = new List<string>();

        public static DataTable Get_Access_Permission_LOG_Info_TableName()
        {
            sql = " SELECT DISTINCT TableName as ReportName FROM EDA.dbo.Access_Permission_LOG_Info";

            _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);

            return dt;
        }

        public static DataTable Get_Access_Permission_LOG_Info_Action()
        {
            sql = " SELECT DISTINCT Action FROM EDA.dbo.Access_Permission_LOG_Info";

            _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);

            return dt;
        }

        public static DataTable Get_Access_Permission_LOG_Info_Details()
        {
            sql = " SELECT DISTINCT Revisor as User_ID FROM EDA.dbo.Access_Permission_LOG_Info";

            _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);

            return dt;
        }

        public static DataTable Get_Access_Permission_User_Mgmt_USER_Id()
        {
            sql = " SELECT DISTINCT USER_Id FROM EDA.dbo.Access_Permission_User_Mgmt";

            _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);

            return dt;
        }

        public static DataTable Get_Access_Permission_User_Mgmt_GP_Id()
        {
            sql = " SELECT DISTINCT GP_Id FROM EDA.dbo.Access_Permission_User_Mgmt";

            _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);

            return dt;
        }

        public static DataTable Get_Access_Permission_RPT_Mgmt_RPT_Id()
        {
            sql = " SELECT DISTINCT RPT_Id FROM EDA.dbo.Access_Permission_RPT_Mgmt";

            _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);

            return dt;
        }

        public static DataTable Get_Access_Permission_RPT_Mgmt_GP_Id()
        {
            sql = " SELECT DISTINCT GP_Id FROM EDA.dbo.Access_Permission_RPT_Mgmt";

            _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);

            return dt;
        }

        public static DataTable Get_Access_Permission_RPT_Info_RPT_Id()
        {
            sql = " SELECT DISTINCT RPT_Id FROM EDA.dbo.Access_Permission_RPT_Info";

            _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);

            return dt;
        }

        public static DataTable Get_Access_Permission_RPT_Info_RPT_Name()
        {
            sql = " SELECT DISTINCT RPT_Name FROM EDA.dbo.Access_Permission_RPT_Info";

            _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);

            return dt;
        }

        public static DataTable Get_Access_Permission_RPT_Info_RPT_URL()
        {
            sql = " SELECT DISTINCT RPT_URL FROM EDA.dbo.Access_Permission_RPT_Info";

            _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);

            return dt;
        }

        public static DataTable Get_Access_Permission_RPT_Info_RPT_Desc()
        {
            sql = " SELECT DISTINCT RPT_Desc FROM EDA.dbo.Access_Permission_RPT_Info";

            _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);

            return dt;
        }


        public static DataTable Get_Test_file()
        {
            sql = "SELECT  TOP 50 PERCENT  * FROM EDA.dbo.Access_Permission_LOG_Info ; ";

            _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);

            return dt;
        }

        public static DataTable Get_Login(string User_Id, string Password)
        {
            sql = " SELECT User_Id, Password";
            sql += " FROM EDA.dbo.Access_Permission_Login";
            sql += " WHERE 1 = 1";

            sql += " AND User_Id = '" + User_Id + "'";
            sql += "AND Password = '" + Password + "'";

            _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);

            return dt;
        }





        public static DataTable Query_eGP(string Old_Id, string Old_desc)
        {
            sql = " SELECT GP_Id, GP_Desc, Revisor, Convert(char(19), Revise_Date, 120) as Revise_Date";
            sql += " FROM EDA.dbo.Access_Permission_GP_Info";
            sql += " WHERE 1 = 1";
            if (Old_Id != "") 
            {
                sql += " AND GP_Id = '" + Old_Id + "'";
            }
            if (Old_desc != "") 
            {
                sql += "AND GP_Desc = '" + Old_desc + "'";
            }

            _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);

            return dt;
        }

        public static DataTable Query_RPT_Info(string Old_Id, string Old_Name, string Old_URL, string Old_desc)
        {
            sql = " SELECT RPT_Id, RPT_Name, RPT_URL, RPT_Desc, Revisor, Convert(char(19), Revise_Date, 120) as Revise_Date";
            sql += " FROM EDA.dbo.Access_Permission_RPT_Info";
            sql += " WHERE 1 = 1";
            if (Old_Id != "")
            {
                sql += " AND RPT_Id = '" + Old_Id + "'";
            }
            if (Old_Name != "") 
            {
                sql += " AND RPT_Name = '" + Old_Name + "'";
            }
            if (Old_URL != "") 
            {
                sql += " AND RPT_URL = '" + Old_URL + "'";
            }
            if (Old_desc != "")
            {
                sql += "AND RPT_Desc = '" + Old_desc + "'";
            }

            _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);

            return dt;
        }

        public static DataTable Query_RPT_Mgmt(string RPT_Id, string GP_Id)
        {
            sql = " SELECT RPT_Id, GP_Id, Revisor, Convert(char(19), Revise_Date, 120) as Revise_Date";
            sql += " FROM EDA.dbo.Access_Permission_RPT_Mgmt";
            sql += " WHERE 1 = 1";
            if (RPT_Id != "")
            {
                sql += " AND RPT_Id = '" + RPT_Id + "'";
            }
            if (GP_Id != "")
            {
                sql += " AND GP_Id = '" + GP_Id + "'";
            }

            _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);

            return dt;
        }

        public static DataTable Query_USER_Mgmt(string USER_Id, string GP_Id)
        {
            sql = " SELECT User_Id, GP_Id, Revisor, Convert(char(19), Revise_Date, 120) as Revise_Date";
            sql += " FROM EDA.dbo.Access_Permission_User_Mgmt";
            sql += " WHERE 1 = 1";
            if (USER_Id != "")
            {
                sql += " AND USER_Id = '" + USER_Id + "'";
            }
            if (GP_Id != "")
            {
                sql += " AND GP_Id = '" + GP_Id + "'";
            }

            _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);

            return dt;
        }

        public static DataTable Query_LOG_Info(string TableName, string Action, string Revisor, string From, string To)
        {
            if (From == "0001/1/1") From = "";
            if (To == "0001/1/1") To = "";

            sql = " SELECT Log_Id, TableName as ReportName, Action, Details, Revisor as User_ID, Convert(char(19), Revise_Date, 120) as Revise_Date";
            sql += " FROM EDA.dbo.Access_Permission_LOG_Info";
            sql += " WHERE 1 = 1";
            if (TableName != "")
            {
                sql += " AND TableName = '" + TableName + "'";
            }
            if (Action != "")
            {
                sql += " AND Action = '" + Action + "'";
            }
            if (Revisor != "")
            {
                sql += " AND Revisor = '" + Revisor + "'";
            }
            if (From != "" && To != "")
            {
                sql += " AND Revise_Date BETWEEN '" + From + "' AND '" + To + "'";
            }

            _msg = "";
            dt = GFun.GetDTable(connStr, sql, ref _msg);

            return dt;
        }

        public static string Update_eGP(string Old_Id, string Old_desc,string New_Id, string New_desc, string man, ref string _Msg)
        {
            sql = " Update EDA.dbo.Access_Permission_GP_Info Set";
            sql += " GP_Id = '" + New_Id + "'";
            sql += " , GP_Desc = '" + New_desc + "'";
            sql += " , Revisor = '" + man + "'";
            sql += " , Revise_Date = '" + Tools.Get_Now() + "'";
            sql += " WHERE 1 = 1";
            sql += " AND GP_Id = '" + Old_Id + "'";
            sql += " AND GP_Desc = '" + Old_desc + "'";

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

        public static string Update_RPT_Info(string Old_Name, string New_Name, string New_URL, string New_Desc, string man, ref string _Msg)
        {
            sql = " Update EDA.dbo.Access_Permission_RPT_Info Set";
            sql += " RPT_Name = '" + New_Name + "'";
            sql += " , RPT_URL = '" + New_URL + "'";
            sql += " , RPT_Desc = '" + New_Desc + "'";

            sql += " , Revisor = '" + man + "'";
            sql += " , Revise_Date = '" + Tools.Get_Now() + "'";
            sql += " WHERE 1 = 1";
            sql += " AND RPT_Name = '" + Old_Name + "'";

            lisSQL.Clear();
            lisSQL.Add(sql);

            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            if (_Msg != "") return _Msg;

            sql = " INSERT INTO EDA.dbo.Access_Permission_LOG_Info";
            sql += " (TableName, Action, Details, Revisor, Revise_Date)";
            sql += " VALUES('Access_Permission_RPT_Info','M','" + lisSQL[0].Replace("'", "''") + "','" + man + "','" + Tools.Get_Now() + "')";

            lisSQL.Clear();
            lisSQL.Add(sql);
            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            return _Msg;
        }

        public static string Update_RPT_Mgmt(string Old_RPT_Id, string Old_GP_Id, string New_RPT_Id, string New_GP_Id, string man, ref string _Msg)
        {
            sql = " Update EDA.dbo.Access_Permission_RPT_Mgmt Set";
            sql += " RPT_Id = '" + New_RPT_Id + "'";
            sql += " , GP_Id = '" + New_GP_Id + "'";

            sql += " , Revisor = '" + man + "'";
            sql += " , Revise_Date = '" + Tools.Get_Now() + "'";
            sql += " WHERE 1 = 1";
            sql += " AND RPT_Id = '" + Old_RPT_Id + "'";
            sql += " AND GP_Id = '" + Old_GP_Id + "'";

            lisSQL.Clear();
            lisSQL.Add(sql);

            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            if (_Msg != "") return _Msg;

            sql = " INSERT INTO EDA.dbo.Access_Permission_LOG_Info";
            sql += " (TableName, Action, Details, Revisor, Revise_Date)";
            sql += " VALUES('Access_Permission_RPT_Mgmt','M','" + lisSQL[0].Replace("'", "''") + "','" + man + "','" + Tools.Get_Now() + "')";

            lisSQL.Clear();
            lisSQL.Add(sql);
            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            return _Msg;
        }

        public static string Update_User_Mgmt(string Old_User_Id, string Old_GP_Id, string New_User_Id, string New_GP_Id, string man, ref string _Msg)
        {
            sql = " Update EDA.dbo.Access_Permission_User_Mgmt Set";
            sql += " User_Id = '" + New_User_Id + "'";
            sql += " , GP_Id = '" + New_GP_Id + "'";

            sql += " , Revisor = '" + man + "'";
            sql += " , Revise_Date = '" + Tools.Get_Now() + "'";
            sql += " WHERE 1 = 1";
            sql += " AND User_Id = '" + Old_User_Id + "'";
            sql += " AND GP_Id = '" + Old_GP_Id + "'";

            lisSQL.Clear();
            lisSQL.Add(sql);

            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            if (_Msg != "") return _Msg;

            sql = " INSERT INTO EDA.dbo.Access_Permission_LOG_Info";
            sql += " (TableName, Action, Details, Revisor, Revise_Date)";
            sql += " VALUES('Access_Permission_User_Mgmt','M','" + lisSQL[0].Replace("'", "''") + "','" + man + "','" + Tools.Get_Now() + "')";

            lisSQL.Clear();
            lisSQL.Add(sql);
            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            return _Msg;
        }

        public static string Insert_eGP(string New_Id, string New_desc, string man, ref string _Msg)
        {
            sql = " INSERT INTO EDA.dbo.Access_Permission_GP_Info";
            sql += " (GP_Id, GP_Desc, Revisor, Revise_Date)";
            sql += " VALUES ('" + New_Id + "','" + New_desc + "','" + man + "','" + Tools.Get_Now() + "')";

            lisSQL.Clear();
            lisSQL.Add(sql);

            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            if (_Msg != "") return _Msg;

            sql = " INSERT INTO EDA.dbo.Access_Permission_LOG_Info";
            sql += " (TableName, Action, Details, Revisor, Revise_Date)";
            sql += " VALUES('Access_Permission_GP_Info','I','" + lisSQL[0].Replace("'", "''") + "','" + man + "','" + Tools.Get_Now() + "')";

            lisSQL.Clear();
            lisSQL.Add(sql);
            _msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            return _Msg;
        }

        public static string Insert_RPT_Info(string New_RPT_Name, string New_RPT_URL, string New_RPT_Desc, string man, ref string _Msg)
        {
            sql = " INSERT INTO EDA.dbo.Access_Permission_RPT_Info";
            sql += " (RPT_Name, RPT_URL, RPT_Desc, Revisor, Revise_Date)";
            sql += " VALUES ('" + New_RPT_Name + "','" + New_RPT_URL + "','" + New_RPT_Desc + "','" + man + "','" + Tools.Get_Now() + "')";

            lisSQL.Clear();
            lisSQL.Add(sql);

            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            if (_Msg != "") return _Msg;

            sql = " INSERT INTO EDA.dbo.Access_Permission_LOG_Info";
            sql += " (TableName, Action, Details, Revisor, Revise_Date)";
            sql += " VALUES('Access_Permission_RPT_Info','I','" + lisSQL[0].Replace("'", "''") + "','" + man + "','" + Tools.Get_Now() + "')";

            lisSQL.Clear();
            lisSQL.Add(sql);
            _msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            return _Msg;
        }

        public static string Insert_RPT_Mgmt(string New_RPT_Id, string New_GP_Id, string man, ref string _Msg)
        {
            sql = " INSERT INTO EDA.dbo.Access_Permission_RPT_Mgmt";
            sql += " (RPT_Id, GP_Id, Revisor, Revise_Date)";
            sql += " VALUES ('" + New_RPT_Id + "','" + New_GP_Id + "','" + man + "','" + Tools.Get_Now() + "')";

            lisSQL.Clear();
            lisSQL.Add(sql);

            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            if (_Msg != "") return _Msg;

            sql = " INSERT INTO EDA.dbo.Access_Permission_LOG_Info";
            sql += " (TableName, Action, Details, Revisor, Revise_Date)";
            sql += " VALUES('Access_Permission_RPT_Mgmt','I','" + lisSQL[0].Replace("'", "''") + "','" + man + "','" + Tools.Get_Now() + "')";

            lisSQL.Clear();
            lisSQL.Add(sql);
            _msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            return _Msg;
        }

        public static string Insert_User_Mgmt(string New_User_Id, string New_GP_Id, string man, ref string _Msg)
        {
            sql = " INSERT INTO EDA.dbo.Access_Permission_User_Mgmt";
            sql += " (User_Id, GP_Id, Revisor, Revise_Date)";
            sql += " VALUES ('" + New_User_Id + "','" + New_GP_Id + "','" + man + "','" + Tools.Get_Now() + "')";

            lisSQL.Clear();
            lisSQL.Add(sql);

            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            if (_Msg != "") return _Msg;

            sql = " INSERT INTO EDA.dbo.Access_Permission_LOG_Info";
            sql += " (TableName, Action, Details, Revisor, Revise_Date)";
            sql += " VALUES('Access_Permission_User_Mgmt','I','" + lisSQL[0].Replace("'", "''") + "','" + man + "','" + Tools.Get_Now() + "')";

            lisSQL.Clear();
            lisSQL.Add(sql);
            _msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            return _Msg;
        }

        public static string Delete_eGP(string Old_Id, string Old_desc, string man, ref string _Msg)
        {
            sql = " DELETE EDA.dbo.Access_Permission_GP_Info";
            sql += " WHERE 1 = 1";
            sql += " AND GP_Id = '" + Old_Id + "'";
            sql += " AND GP_Desc = '" + Old_desc + "'";

            lisSQL.Clear();
            lisSQL.Add(sql);

            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            if (_Msg != "") return _Msg;

            sql = " INSERT INTO EDA.dbo.Access_Permission_LOG_Info";
            sql += " (TableName, Action, Details, Revisor, Revise_Date)";
            sql += " VALUES('Access_Permission_GP_Info','D','" + lisSQL[0].Replace("'", "''") + "','" + man + "','" + Tools.Get_Now() + "')";

            lisSQL.Clear();
            lisSQL.Add(sql);
            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            return _Msg;
        }

        public static string Delete_RPT_Info(string Old_Name, string man, ref string _Msg)
        {
            sql = " DELETE EDA.dbo.Access_Permission_RPT_Info";
            sql += " WHERE 1 = 1";
            sql += " AND RPT_Name = '" + Old_Name + "'";

            lisSQL.Clear();
            lisSQL.Add(sql);

            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            if (_Msg != "") return _Msg;

            sql = " INSERT INTO EDA.dbo.Access_Permission_LOG_Info";
            sql += " (TableName, Action, Details, Revisor, Revise_Date)";
            sql += " VALUES('Access_Permission_RPT_Info','D','" + lisSQL[0].Replace("'", "''") + "','" + man + "','" + Tools.Get_Now() + "')";

            lisSQL.Clear();
            lisSQL.Add(sql);
            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            return _Msg;
        }

        public static string Delete_RPT_Mgmt(string Old_RPT_Id, string Old_GP_Id, string man, ref string _Msg)
        {
            sql = " DELETE EDA.dbo.Access_Permission_RPT_Mgmt";
            sql += " WHERE 1 = 1";
            sql += " AND RPT_Id = '" + Old_RPT_Id + "'";
            sql += " AND GP_Id = '" + Old_GP_Id + "'";

            lisSQL.Clear();
            lisSQL.Add(sql);

            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            if (_Msg != "") return _Msg;

            sql = " INSERT INTO EDA.dbo.Access_Permission_LOG_Info";
            sql += " (TableName, Action, Details, Revisor, Revise_Date)";
            sql += " VALUES('Access_Permission_RPT_Mgmt','D','" + lisSQL[0].Replace("'", "''") + "','" + man + "','" + Tools.Get_Now() + "')";

            lisSQL.Clear();
            lisSQL.Add(sql);
            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            return _Msg;
        }

        public static string Delete_User_Mgmt(string Old_User_Id, string Old_GP_Id, string man, ref string _Msg)
        {
            sql = " DELETE EDA.dbo.Access_Permission_User_Mgmt";
            sql += " WHERE 1 = 1";
            sql += " AND User_Id = '" + Old_User_Id + "'";
            sql += " AND GP_Id = '" + Old_GP_Id + "'";

            lisSQL.Clear();
            lisSQL.Add(sql);

            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            if (_Msg != "") return _Msg;

            sql = " INSERT INTO EDA.dbo.Access_Permission_LOG_Info";
            sql += " (TableName, Action, Details, Revisor, Revise_Date)";
            sql += " VALUES('Access_Permission_User_Mgmt','D','" + lisSQL[0].Replace("'", "''") + "','" + man + "','" + Tools.Get_Now() + "')";

            lisSQL.Clear();
            lisSQL.Add(sql);
            _Msg = "";
            GFun.ExSql3(lisSQL, ref _Msg);

            return _Msg;
        }

    }
}