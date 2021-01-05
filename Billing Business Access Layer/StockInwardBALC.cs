using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Data_Access_Layer;
using Billing_Business_Entity_Layer;

namespace Billing_Business_Access_Layer
{
    public class StockInwardBALC
    {
        Connection connection;
        public int UpdatePurchaseAndTransferDetailsList(string tableName, string barcode, int currentQuantity, int pendingQuantity, string status)
        {
            connection = new Connection();
            return connection.UpdatePurchaseAndTransferDetailsList(tableName, barcode, currentQuantity, pendingQuantity, status);
        }
    }
}
