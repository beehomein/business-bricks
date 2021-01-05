using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Data_Access_Layer;
using Billing_Business_Entity_Layer;

namespace Billing_Business_Access_Layer
{
    public class PurchaseOrderBALC
    {
        Connection connection;
        int noOfrecords;
        string currentPurchaseDetailsTableId;
        public int GenaratePurchaseOrder(List<PurchaseDetailsList> purchaseDetailsListList)
        {
            noOfrecords = connection.LengthOfPurchasesList();
            currentPurchaseDetailsTableId = "PO_" + noOfrecords;
            var tableCreationStatus=connection.CreatePurchaseDetails(currentPurchaseDetailsTableId);
            var totalQuantity = 0;
            foreach (var purchaseDetailsList in purchaseDetailsListList)
            {
                connection.InsertPurchaseDetailsList(purchaseDetailsList, currentPurchaseDetailsTableId);
                totalQuantity+= purchaseDetailsList.quantity;
            }
            var company= connection.ListCompanyDetails();
            PurchasesList purchasesList = new PurchasesList();
            purchasesList.purchaseId = currentPurchaseDetailsTableId;
            purchasesList.noOfProducts = totalQuantity;
            purchasesList.sourceFrom = company[0].id;
            purchasesList.sourceTo = company[0].id;
            purchasesList.status = "Inside Product";
            return connection.InsertPurchaseList(purchasesList);
        }
    }
}
