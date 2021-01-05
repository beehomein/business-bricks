using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Data_Access_Layer;
using Billing_Business_Entity_Layer;

namespace Billing_Business_Access_Layer
{
    public class TransferOrderBALC
    {
        Connection connection;
        int noOfrecords;
        string currentTransferDetailsTableId;
        public int GenarateTransferOrder(List<TransferDetailsList> transferDetailsListList)
        {
            noOfrecords = connection.LengthOfTransfersList();
            currentTransferDetailsTableId = "TO_" + noOfrecords;
            var tableCreationStatus = connection.CreateTransferDetails(currentTransferDetailsTableId);
            var totalQuantity = 0;
            foreach (var transferDetailsList in transferDetailsListList)
            {
                connection.InsertTransferDetailsList(transferDetailsList, currentTransferDetailsTableId);
                totalQuantity += transferDetailsList.quantity;
            }
            var company = connection.ListCompanyDetails();
            TransfersList transfersList = new TransfersList();
            transfersList.transferId = currentTransferDetailsTableId;
            transfersList.noOfProducts = totalQuantity;
            transfersList.sourceFrom = company[0].id;
            transfersList.sourceTo = company[0].id;
            transfersList.status = "Inside Product";
            return connection.InsertTransferList(transfersList);
        }
    }
}
