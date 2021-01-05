using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Data_Access_Layer;
using Billing_Business_Entity_Layer;

namespace Billing_Business_Access_Layer
{
    public class NewProductAttributesBALC
    {
        Connection connection;

        #region Group
        public int InsertGroup(Group group)
        {
            connection = new Connection();
            return connection.InsertGroup(group);
        }
        #endregion

        #region Division
        public int InsertDivision(Division division)
        {
            connection = new Connection();
            return connection.InsertDivision(division);
        }
        #endregion

        #region Brand
        public int InsertBrand(Brand brand)
        {
            connection = new Connection();
            return connection.InserBrand(brand);
        }
        #endregion
    }
}
