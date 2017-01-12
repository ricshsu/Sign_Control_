using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
 
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

   }


 
}