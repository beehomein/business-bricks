using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Data_Access_Layer
{
    static class LocalSqlConnection
    {
        public const string CONNECTION_STRING = @"Data Source=DESKTOP-CP8V18I\BEE007470;Initial Catalog=business_bricks;Integrated security=true";
    }
    static class LocalStoreProcedures
    {
        public const string INSERT_COMPANY_DETAILS = "USP_INSERT_COMPANY_DETAILS";
        public const string LIST_COMPANY_DETAILS = "USP_LIST_COMPANY_DETAILS";
        public const string SELECT_COMPANY_DETAILS = "USP_SELECT_COMPANY_DETAILS"; 

    }
}
