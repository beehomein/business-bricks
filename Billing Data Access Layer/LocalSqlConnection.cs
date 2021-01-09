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
        //company details
        public const string INSERT_COMPANY_DETAILS = "USP_INSERT_COMPANY_DETAILS";
        public const string LIST_COMPANY_DETAILS = "USP_LIST_COMPANY_DETAILS";
        public const string SELECT_COMPANY_DETAILS = "USP_SELECT_COMPANY_DETAILS"; 
        //product attributes
        public const string INSERT_GROUP = "USP_INSERT_GROUP_INTO_DYNAMIC_CATEGORY_TABLE";
        public const string INSERT_DIVISION = "USP_INSERT_DIVISION_INTO_DYNAMIC_GROUP_TABLE";
        public const string INSERT_BRAND = "USP_INSERT_BRAND_INTO_DYNAMIC_GROUP_TABLE";
        public const string LIST_DYNAMIC_TABLE = "USP_LIST_DYNAMIC_TABLE";
        public const string LIST_CATEGORY = "USP_LIST_CATEGORY";
        public const string LIST_SIZE = "USP_LIST_SIZE";
        //product
        public const string INSERT_NEW_PRODUCT = "USP_INSERT_NEW_PRODUCT";
        //gst
        public const string INSERT_GST = "USP_INSERT_GST_PLAN";
        public const string LIST_GST = "USP_LIST_GST_PLAN";
        public const string SELECT_GST = "USP_SELECT_GST_PLAN";
        //barcode
        public const string LIST_BARCODE_REISTER = "USP_LIST_BARCODE_REGISTER";
        public const string INSERT_AND_UPDATE_BARCODE_REGISTER = "USP_INTEGRATED_INSERT_AND_UPDATE_BARCODE_REGISTER";
        //purchase order
        public const string COUNT_OF_PURCHASES_LIST = "USP_COUNT_OF_PURCHASES_LIST";
        public const string CREATE_PURCHASE_DETAILS = "USP_CREATE_PURCHASE_DETAILS";
        public const string LIST_PURCHASES_LIST = "USP_LIST_PURCHASES_LIST";
        public const string LIST_PURCHASE_DETAILS_LIST = "USP_LIST_PURCHASE_DETAILS_LIST";
        public const string INSERT_PURCHASES_LIST = "USP_INSERT_PURCHASES_LIST";
        public const string INSERT_PURCHASE_DETAILS_LIST = "USP_INSERT_PURCHASE_DETAILS_LIST";
        //transfer order
        public const string COUNT_OF_TRANSFER_LIST = "USP_COUNT_OF_TRANSFER_LIST";
        public const string CREATE_TRANSFER_DETAILS = "USP_CREATE_TRANSFER_DETAILS";
        public const string LIST_TRANSFER_LIST = "USP_LIST_TRANSFER_LIST";
        public const string LIST_TRANSFER_DETAILS_LIST = "USP_LIST_TRANSFER_DETAILS_LIST";
        public const string INSERT_TRANSFER_LIST = "USP_INSERT_TRANSFER_LIST";
        public const string INSERT_TRANSFER_DETAILS_LIST = "USP_INSERT_TRANSFER_DETAILS_LIST";
        //inventory
        public const string INSERT_INVENTORY = "USP_INSERT_INVENTORY";
        public const string SELECT_INVENTORY = "USP_SELECT_INVENTORY";
        public const string LIST_INVENTORY = "USP_LIST_INVENTORY";
        public const string UPDATE_INVENTORY = "USP_UPDATE_INVENTORY";
        public const string INTEGRATED_INSERT_AND_UPDATE = "USP_INTEGRATED_INSERT_AND_UPDATE";
        //stock inward
        public const string UPDATE_PURCHASE_AND_TRANSFER_DETAILS_QUANTITY = "USP_UPDATE_PURCHASE_AND_TRANSFER_DETAILS_QUANTITY";
        //customers
        public const string INSERT_CUSTOMERS = "USP_INSERT_CUSTOMERS";
        public const string LIST_CUSTOMERS = "USP_LIST_CUSTOMERS";
        public const string SELECT_CUSTOMER = "USP_SELECT_CUSTOMER";
        public const string UPDATE_LOYALTY_POINTS_OF_CUSTOMER = "USP_UPDATE_LOYALTY_POINTS_OF_CUSTOMER";
        public const string UPDATE_CUSTOMER_DETAILS = "USP_UPDATE_CUSTOMER_DETAILS";
        //individual promotions
        public const string INSERT_INDIVIDUAL_PROMOTION = "USP_INSERT_INDIVIDUAL_PROMOTION";
        public const string UPDATE_INDIVIDUAL_PROMOTION = "USP_UPDATE_INDIVIDUAL_PROMOTION";
        public const string DELETE_INDIVIDUAL_PROMOTION = "USP_DELETE_INDIVIDUAL_PROMOTION";
        public const string LIST_INDIVIDUAL_PROMOTIONS = "USP_LIST_INDIVIDUAL_PROMOTIONS";
        public const string SELECT_INDIVIDUAL_PROMOTIONS = "USP_SELECT_INDIVIDUAL_PROMOTIONS";
        //multiple promotions
        public const string INSERT_MULTIPLE_PROMOTION = "USP_INSERT_MULTIPLE_PROMOTION";
        public const string UPDATE_MULTIPLE_PROMOTION = "USP_UPDATE_MULTIPLE_PROMOTION";
        public const string DELETE_MULTIPLE_PROMOTION = "USP_DELETE_MULTIPLE_PROMOTION";
        public const string LIST_MULTIPLE_PROMOTIONS = "USP_LIST_MULTIPLE_PROMOTIONS";
        public const string SELECT_MULTIPLE_PROMOTIONS = "USP_SELECT_MULTIPLE_PROMOTIONS";
        //price promotions
        public const string INSERT_PRICE_PROMOTIONS = "USP_INSERT_PRICE_PROMOTIONS";
        public const string UPDATE_PRICE_PROMOTIONS = "USP_UPDATE_PRICE_PROMOTIONS";
        public const string DELETE_PRICE_PROMOTIONS = "USP_DELETE_PRICE_PROMOTIONS";
        public const string LIST_PRICE_PROMOTIONS = "USP_LIST_PRICE_PROMOTIONS";
        public const string SELECT_PRICE_PROMOTIONS = "USP_SELECT_PRICE_PROMOTIONS";
    }
}
