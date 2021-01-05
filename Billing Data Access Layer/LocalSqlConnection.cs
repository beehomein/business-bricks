using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Data_Access_Layer
{
    static class LocalSqlConnection
    {
        public const string CONNECTION_STRING = @"Data Source=DESKTOP-CP8V18I\BEE007470;Initial Catalog=business_bricks;Integrated security=true";
    }
    static class LocalStoreProcedures
    {
        public const string INSERT_COMPANY_DETAILS = "USP_INSERT_COMPANY_DETAILS";
        public const string LIST_COMPANY_DETAILS = "USP_LIST_COMPANY_DETAILS";
        public const string SELECT_COMPANY_DETAILS = "USP_SELECT_COMPANY_DETAILS"; 
        
        public const string INSERT_GROUP = "USP_INSERT_GROUP_INTO_DYNAMIC_CATEGORY_TABLE";
        public const string INSERT_DIVISION = "USP_INSERT_DIVISION_INTO_DYNAMIC_GROUP_TABLE";
        public const string INSERT_BRAND = "USP_INSERT_BRAND_INTO_DYNAMIC_GROUP_TABLE";
        public const string LIST_DYNAMIC_TABLE = "USP_LIST_DYNAMIC_TABLE";
        public const string LIST_CATEGORY = "USP_LIST_CATEGORY";
        public const string LIST_SIZE = "USP_LIST_SIZE";

        public const string INSERT_NEW_PRODUCT = "USP_INSERT_NEW_PRODUCT";

        public const string INSERT_GST = "USP_INSERT_GST_PLAN";
        public const string LIST_GST = "USP_LIST_GST_PLAN";
        public const string SELECT_GST = "USP_SELECT_GST_PLAN";

        public const string LIST_BARCODE_REISTER = "USP_LIST_BARCODE_REGISTER";
        public const string INSERT_AND_UPDATE_BARCODE_REGISTER = "USP_INTEGRATED_INSERT_AND_UPDATE_BARCODE_REGISTER";

        public const string COUNT_OF_PURCHASES_LIST = "USP_COUNT_OF_PURCHASES_LIST";
        public const string CREATE_PURCHASE_DETAILS = "USP_CREATE_PURCHASE_DETAILS";
        public const string LIST_PURCHASES_LIST = "USP_LIST_PURCHASES_LIST";
        public const string LIST_PURCHASE_DETAILS_LIST = "USP_LIST_PURCHASE_DETAILS_LIST";
        public const string INSERT_PURCHASES_LIST = "USP_INSERT_PURCHASES_LIST";
        public const string INSERT_PURCHASE_DETAILS_LIST = "USP_INSERT_PURCHASE_DETAILS_LIST";

        public const string COUNT_OF_TRANSFER_LIST = "USP_COUNT_OF_TRANSFER_LIST";
        public const string CREATE_TRANSFER_DETAILS = "USP_CREATE_TRANSFER_DETAILS";
        public const string LIST_TRANSFER_LIST = "USP_LIST_TRANSFER_LIST";
        public const string LIST_TRANSFER_DETAILS_LIST = "USP_LIST_TRANSFER_DETAILS_LIST";
        public const string INSERT_TRANSFER_LIST = "USP_INSERT_TRANSFER_LIST";
        public const string INSERT_TRANSFER_DETAILS_LIST = "USP_INSERT_TRANSFER_DETAILS_LIST";

        public const string INSERT_INVENTORY = "USP_INSERT_INVENTORY";
        public const string SELECT_INVENTORY = "USP_SELECT_INVENTORY";
        public const string LIST_INVENTORY = "USP_LIST_INVENTORY";
        public const string UPDATE_INVENTORY = "USP_UPDATE_INVENTORY";
        public const string INTEGRATED_INSERT_AND_UPDATE = "USP_INTEGRATED_INSERT_AND_UPDATE";

        public const string UPDATE_PURCHASE_AND_TRANSFER_DETAILS_QUANTITY = "USP_UPDATE_PURCHASE_AND_TRANSFER_DETAILS_QUANTITY";
    }
}
