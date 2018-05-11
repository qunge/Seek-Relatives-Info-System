using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SRIS.Common.Log;

namespace SRIS
{
    public class MyFrameworkConfig
    {
        public static void Register()
        {
            LogHelper.InitLog4Net();
        }
    }
}