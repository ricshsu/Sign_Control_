using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Mail;
 
namespace EDA_tool
{
    public class Groceries : System.Web.UI.Page 
    {
        public static string Get_Now()
        {
            DateTime myDate = DateTime.Now;
            string myDateString = myDate.ToString("yyyy-MM-dd HH:mm:ss");
            return myDateString;
        }

        public static  string Delfile(string path)//刪除上傳的資料
        {
            Boolean DoOrnot = false ;
            try
            {
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.File.Delete(path);
                    DoOrnot = true;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("{0}:the file is locked.",e.GetType().Name);
                //寫資料庫?
            }       
            return DoOrnot.ToString();     
        }

        //檢查是否為數字
        public static bool IsNumeric(String strNumber)
        {
            Regex NumberPattern = new Regex("[^0-9.-]");
            return !NumberPattern.IsMatch(strNumber);
        }

        //檢查EMAIL
        public static bool IsmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        //檢查格式

        public static bool checkFormat(string Var1)
        {
           try
                {
                    if (String.Equals(Var1, "Y"))
                    { return true; }
                    if (String.Equals(Var1, "N"))
                    { return true; }
                    else 
                    { return false; }
                }
                catch (FormatException)
                {
                    return false;
                }
        }
 

   }


 
}