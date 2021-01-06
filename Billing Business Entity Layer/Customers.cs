using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Business_Entity_Layer
{
    public class Customers
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int mobileNumber { get; set; }
        public string occupation { get; set; }
        public string dateOfBirth { get; set; }
        public string gender { get; set; }
        public string ageGroup { get; set; }
        public string communicationType { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public float loyaltyPoints { get; set; }
    }
}
