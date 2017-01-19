using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;


namespace EDA_tool
{
    public class SQLCheck
    {
        static string connStr = System.Configuration.ConfigurationManager.AppSettings["KSPCBDB10"];

        //純查詢
        public static DataTable GetDTable(string ConnStr, string Sql, ref string ErrMsg)
        {
            DataTable myDT = new DataTable();

            try
            {
                //連接微軟的資料庫
                SqlDataAdapter mySqlDa = new SqlDataAdapter(Sql, ConnStr);
                mySqlDa.Fill(myDT);
                //可設定timeout 時間 -->mySqlDa.SelectCommand.CommandTimeout = TimeOutTime

                ErrMsg = "";
                return myDT;
            }
            catch (Exception Ex)
            {
                ErrMsg = Ex.Message;
                return null;
            }
        }

        //異動資料庫
        public static void ExSql(IEnumerable mylist, ref string ErrMsg)
        {
            System.Collections.IEnumerator myEnumerator = mylist.GetEnumerator();
            SqlConnection myCn = new SqlConnection();
            SqlCommand myCm = new SqlCommand();
            SqlTransaction myTrans;
            int iCount = 0;

            try
            {

                myCn.ConnectionString = connStr;
                myCn.Open();
                myTrans = myCn.BeginTransaction(IsolationLevel.ReadUncommitted);

                myCm.Connection = myCn;
                myCm.Transaction = myTrans;
                myCm.CommandType = CommandType.Text;

                while (myEnumerator.MoveNext())
                {
                    myCm.CommandText = myEnumerator.Current.ToString();
                    myCm.ExecuteNonQuery();

                    iCount += 1;
                }

                myTrans.Commit();

                ErrMsg = "";
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                myCm.Transaction.Rollback();
            }
            finally
            {
                if (myCn != null)
                {
                    if (myCn.State == ConnectionState.Open)
                        myCn.Close();
                    myCn = null;
                }
            }
        }
    }
}