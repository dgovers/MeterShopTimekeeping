using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterShopTimekeeping
{
    class dbHandler2
    {
        public static string SrvName = @"SQ0208";
        public static string DbName = @"MK6D";

        public static string GetConnectionString()
        {
            return "Data Source=" + SrvName + "; initial catalog=" + DbName + "; Trusted_Connection = True " + ";";

        }
    }
}
