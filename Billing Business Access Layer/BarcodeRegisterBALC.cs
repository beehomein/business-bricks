using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Data_Access_Layer;
using Billing_Business_Entity_Layer;

namespace Billing_Business_Access_Layer
{
    public class BarcodeRegisterBALC
    {
        Connection connection;
        public int InsertBracodeRegister(BarcodeRegister barcodeRegister)
        {
            connection = new Connection();
            return connection.InsertBarcodeRegister(barcodeRegister);
        }
        public List<BarcodeRegister> ListBarcodeRegister()
        {
            connection = new Connection();
            return connection.ListBarcodeRegister();
        }
    }
}
