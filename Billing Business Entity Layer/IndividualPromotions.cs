using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Business_Entity_Layer
{
    public class IndividualPromotions
    {
        public string barcodeId { get; set; }
        public string offerType { get; set; }
        public string discountType { get; set; }
        public int discountValue { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }
        public string promotionId { get; set; }
    }
}
