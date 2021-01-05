using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Business_Entity_Layer
{
    public class TransfersList
    {
        public string transferId { get; set; }
        public int noOfProducts { get; set; }
        public string sourceFrom { get; set; }
        public string sourceTo { get; set; }
        public string status { get; set; }
    }
}
