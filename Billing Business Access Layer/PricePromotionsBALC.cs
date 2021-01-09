using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Data_Access_Layer;
using Billing_Business_Entity_Layer;

namespace Billing_Business_Access_Layer
{
    public class PricePromotionsBALC
    {
        Connection connection;
        public int InsertPricePromotion(PricePromotions pricePromotions)
        {
            connection = new Connection();
            return connection.InsertPricePromotion(pricePromotions);
        }
        public int UpdatePricePromotion(PricePromotions pricePromotions)
        {
            connection = new Connection();
            return connection.UpdatePricePromotion(pricePromotions);
        }
        public int DeletePricePromotion(string promotionId)
        {
            connection = new Connection();
            return connection.DeletePricePromotion(promotionId);
        }
        public List<PricePromotions> ListPricePromotion()
        {
            connection = new Connection();
            return connection.ListPricePromotion();
        }
        public PricePromotions SelectPricePromotions(string promotionId)
        {
            connection = new Connection();
            return connection.SelectPricePromotions(promotionId);
        }
    }
}

