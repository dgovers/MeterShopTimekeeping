using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterShopTimekeeping
{
    class dbHandler
    {
        //PROD tcp:apwsmorptp001,49172
        //DEV tcp:AJ001745,49172

        public static string SrvName = @"tcp:apwsmorptp001,49172";
        public static string DbName = @"MeterShopTimekeeping";

        public static string GetConnectionString()
        {
            return "Data Source=" + SrvName + "; initial catalog=" + DbName + "; Trusted_Connection = True " + ";";

        }
    }
}
