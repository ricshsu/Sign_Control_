﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 

//


namespace EDA_Sign
{
    public class Tools
    {
        public static string Get_Now()
        {
            DateTime myDate = DateTime.Now;
            string myDateString = myDate.ToString("yyyy-MM-dd HH:mm:ss");
            return myDateString;
        }


   }


 
}