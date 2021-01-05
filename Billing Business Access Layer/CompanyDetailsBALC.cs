using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Data_Access_Layer;
using Billing_Business_Entity_Layer;
namespace Billing_Business_Access_Layer
{
    public class CompanyDetailsBALC
    {
        public int previousCompanyId { get; set; }
        public int InsertCompanyDetails(CompanyDetails companyDetails)
        {
            Connection connection = new Connection();
            previousCompanyId = connection.ListCompanyDetails().Count();
            companyDetails.id = "BBBCL" + previousCompanyId;
            return connection.InsertCompanyDetails(companyDetails);
        }
    }
}
