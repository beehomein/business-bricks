using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Data_Access_Layer;
using Billing_Business_Entity_Layer;

namespace Billing_Business_Access_Layer
{
    public class CustomersBALC
    {
        Connection connection;
        public int InsertCustomer(Customers customers)
        {
            connection = new Connection();
            return connection.InsertCustomer(customers);
        }
        public List<Customers> ListCustomers()
        {
            connection = new Connection();
            return connection.ListCustomers();
        }
        public Customers SlectCustomer(int mobileNumnber)
        {
            connection = new Connection();
            return connection.SlectCustomer(mobileNumnber);
        }
        public int UpdateLoyaltyPoints(float loyaltyPoints, int mobileNumnber)
        {
            connection = new Connection();
            return connection.UpdateLoyaltyPoints(loyaltyPoints, mobileNumnber);
        }
        public int UpdateCustomer(Customers customers, int previousMobilNumber)
        {
            connection = new Connection();
            return connection.UpdateCustomer(customers, previousMobilNumber);
        }
    }
}
