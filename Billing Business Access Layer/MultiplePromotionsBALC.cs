using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Data_Access_Layer;
using Billing_Business_Entity_Layer;

namespace Billing_Business_Access_Layer
{
    public class MultiplePromotionsBALC
    {
        Connection connection;
        public int InsertMultiplePromotion(MultiplePromotions multiplePromotions)
        {
            connection = new Connection();
            return connection.InsertMultiplePromotion(multiplePromotions);
        }
        public int UpdateMultiplePromotion(MultiplePromotions multiplePromotions)
        {
            connection = new Connection();
            return connection.UpdateMultiplePromotion(multiplePromotions);
        }
        public int DeleteMultiplePromotion(string promotionId)
        {
            connection = new Connection();
            return connection.DeleteMultiplePromotion(promotionId);
        }
        public List<MultiplePromotions> ListMultiplePromotion()
        {
            connection = new Connection();
            return connection.ListMultiplePromotion();
        }
        public MultiplePromotions SelectMultiplePromotions(string promotionId)
        {
            connection = new Connection();
            return connection.SelectMultiplePromotions(promotionId);
        }
    }
}
