using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Business_Entity_Layer
{
    public class PurchaseDetailsList
    {
        public string barcode { get; set; }
        public string brand { get; set; }
        public string category { get; set; }
        public string groupName { get; set; }
        public string division { get; set; }
        public string size { get; set; }
        public int quantity { get; set; }
    }
}
