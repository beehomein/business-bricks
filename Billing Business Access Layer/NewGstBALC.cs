using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Data_Access_Layer;
using Billing_Business_Entity_Layer;

namespace Billing_Business_Access_Layer
{
    public class NewGstBALC
    {
        Connection connection;
        public int AddGst(GST gst)
        {
            connection = new Connection();
            return connection.AddGst(gst);
        }
        public List<GST> ListGST()
        {
            connection = new Connection();
            List<GST>  gstList=connection.ListGst();
            return new List<GST>();
        }
    }
}
