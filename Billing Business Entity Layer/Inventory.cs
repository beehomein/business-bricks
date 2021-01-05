using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Business_Entity_Layer
{
    public class Inventory
    {
        public string category { get; set; }
        public string group { get; set; }
        public string divisionn { get; set; }
        public string size { get; set; }
        public string brand { get; set; }
        public string styleCode { get; set; }
        public string barcode { get; set; }
        public string length { get; set; }
        public int quantity { get; set; }
        public float mrp { get; set; }
        public float discount { get; set; }
        public float subTotal { get; set; }
        public float gst { get; set; }
        public float price { get; set; }
        public string promotionId { get; set; }
        public string manufacturedDate { get; set; }
        public string origin { get; set; }
    }
}
