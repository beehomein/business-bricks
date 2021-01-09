using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Data_Access_Layer;
using Billing_Business_Entity_Layer;

namespace Billing_Business_Access_Layer
{
    public class IndividualPromotionsBALC
    {
        Connection connection;
        public int InsertIndividualPromotion(IndividualPromotions individualPromotions)
        {
            connection = new Connection();
            return connection.InsertIndividualPromotion(individualPromotions);
        }
        public int UpdateIndividualPromotion(IndividualPromotions individualPromotions)
        {
            connection = new Connection();
            return connection.UpdateIndividualPromotion(individualPromotions);
        }
        public int DeleteIndividualPromotion(string promotionId)
        {
            connection = new Connection();
            return connection.DeleteIndividualPromotion(promotionId);
        }
        public List<IndividualPromotions> ListIndividualPromotion()
        {
            connection = new Connection();
            return connection.ListIndividualPromotion();
        }
        public IndividualPromotions SelectIndividualPromotions(string promotionId)
        {
            connection = new Connection();
            return connection.SelectIndividualPromotions(promotionId);
        }
    }
}
