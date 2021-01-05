using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Data_Access_Layer;
using Billing_Business_Entity_Layer;

namespace Billing_Business_Access_Layer
{
    public class InventoryBALC
    {
        Connection connection;
        public int InsertInventory(Inventory inventory)
        {
            connection = new Connection();
            return connection.InsertInventory(inventory);
        }
        public Inventory SelectInventory(string barcode)
        {
            connection = new Connection();
            return connection.SelectInventory(barcode);
        }
        public List<Inventory> ListInventory()
        {
            connection = new Connection();
            return connection.ListInventory();
        }
        public int UpdateInventory(string barcode, string quantity)
        {
            connection = new Connection();
            return connection.UpdateInventory(barcode, quantity);
        }
        public int IntegratedInsertUpdateInventory(Inventory inventory)
        {
            connection = new Connection();
            return connection.IntegratedInsertUpdateInventory(inventory);
        }
    }
}
