using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Business_Entity_Layer
{
    public class MultiplePromotions
    {
        public string barcodeIds { get; set; }
        public string offerType { get; set; }
        public string description { get; set; }
        public string promotionId { get; set; }
        public string column1 { get; set; }
        public string column2 { get; set; }
    }
}
