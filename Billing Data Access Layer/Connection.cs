using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Billing_Business_Entity_Layer;
namespace Billing_Data_Access_Layer
{
    public class Connection
    {
        string ConnectionString;
        DataTable dataTable;
        DataSet dataset;
        SqlCommand sqlCommand;
        SqlConnection sqlConnection;
        SqlDataAdapter sqlDataAdapter;
        bool connectionStatus;
        public Connection()
        {
            ConnectionString = LocalSqlConnection.CONNECTION_STRING;
            try
            {
                sqlConnection = new SqlConnection(ConnectionString);
                sqlConnection.Open();
                connectionStatus = true;
            }
            catch
            {
                connectionStatus = false;
            }
        }

        #region Company Details
        /*
         * Function Name : InsertCompanyDetails
         * Parameters : CompanyDetails companyDetails
         * Return Type : int
         * 
         * Function Name : ListCompanyDetails
         * Parameters : -
         * Return Type : List<CompanyDetails>
         * 
         * Function Name : SelectCompanyDetails
         * Parameters : string id
         * Return Type : CompanyDetails
         * 
         */
        public int InsertCompanyDetails(CompanyDetails companyDetails)
        {
            if(connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.INSERT_COMPANY_DETAILS, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("COMPANY_NAME", companyDetails.name);
                sqlCommand.Parameters.AddWithValue("COMPANY_MOBILE_NUMBER", companyDetails.mobileNumber);
                sqlCommand.Parameters.AddWithValue("COMPANY_EMAIL", companyDetails.email);
                sqlCommand.Parameters.AddWithValue("COMPANY_TYPE", companyDetails.companyType);
                sqlCommand.Parameters.AddWithValue("COMPANY_ADDRESS", companyDetails.address);
                sqlCommand.Parameters.AddWithValue("COMPANY_ID", companyDetails.id);
                return sqlCommand.ExecuteNonQuery();
            }
            return 0;
        }
        public List<CompanyDetails> ListCompanyDetails()
        {
            if (connectionStatus)
            {
                List<CompanyDetails> companyDetailsList = new List<CompanyDetails>();
                CompanyDetails companyDetails;
                sqlCommand = new SqlCommand(LocalStoreProcedures.LIST_COMPANY_DETAILS, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                dataTable = new DataTable("Company Details");
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                foreach(DataRow row in dataTable.Rows)
                {
                    companyDetails = new CompanyDetails();
                    companyDetails.name = row[1].ToString();
                    companyDetails.mobileNumber = row[2].ToString();
                    companyDetails.email = row[3].ToString();
                    companyDetails.companyType = row[4].ToString();
                    companyDetails.address = row[5].ToString();
                    companyDetails.id = row[6].ToString();
                    companyDetailsList.Add(companyDetails);
                }
                return companyDetailsList;
            }
            return new List<CompanyDetails>();
        }
        public CompanyDetails SelectCompanyDetails(string id)
        {
            CompanyDetails companyDetails;
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.SELECT_COMPANY_DETAILS, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("COMPANY_ID", id);
                dataTable = new DataTable("Company Details");
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    companyDetails = new CompanyDetails();
                    DataRow row = dataTable.Rows[0];
                    companyDetails.name = row[1].ToString();
                    companyDetails.mobileNumber = row[2].ToString();
                    companyDetails.email = row[3].ToString();
                    companyDetails.companyType = row[4].ToString();
                    companyDetails.address = row[5].ToString();
                    companyDetails.id = row[6].ToString();
                    return companyDetails;
                }
                else
                {
                    companyDetails = new CompanyDetails();
                    companyDetails.name = "";
                    companyDetails.mobileNumber = "";
                    companyDetails.email = "";
                    companyDetails.companyType = "";
                    companyDetails.address = "";
                    companyDetails.id = "";
                    return companyDetails;
                }
            }
            companyDetails = new CompanyDetails();
            companyDetails.name = "";
            companyDetails.mobileNumber = "";
            companyDetails.email = "";
            companyDetails.companyType = "";
            companyDetails.address = "";
            companyDetails.id = "";
            return companyDetails;
        }
        #endregion

        #region New Product Attributes

            #region Group
            public int InsertGroup(Group group)
            {
                if (connectionStatus)
                {
                    sqlCommand = new SqlCommand(LocalStoreProcedures.INSERT_GROUP, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("CATEGORY", group.category);
                    sqlCommand.Parameters.AddWithValue("GROUP", group.group);
                    return sqlCommand.ExecuteNonQuery();
                }
                return 0;
            }
        #endregion

            #region Division
        public int InsertDivision(Division division)
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.INSERT_DIVISION, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("CATEGORY", division.category);
                sqlCommand.Parameters.AddWithValue("GROUP", division.group);
                sqlCommand.Parameters.AddWithValue("DIVISION", division.group);
                return sqlCommand.ExecuteNonQuery();
            }
            return 0;
        }
        #endregion

            #region Brand
            public int InserBrand(Brand brand)
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.INSERT_BRAND, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("CATEGORY", brand.category);
                sqlCommand.Parameters.AddWithValue("GROUP", brand.group);
                sqlCommand.Parameters.AddWithValue("DIVISION", brand.group);
                sqlCommand.Parameters.AddWithValue("BRAND", brand.brand);
                return sqlCommand.ExecuteNonQuery();
            }
            return 0;
        }
        #endregion

        #endregion

        #region New Product

            #region Size
            public List<Size> ListSize()
            {
                if (connectionStatus)
                {
                    List<Size> sizeList = new List<Size>();
                    Size size;
                    sqlCommand = new SqlCommand(LocalStoreProcedures.LIST_SIZE, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    dataTable = new DataTable("Size");
                    sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        size = new Size();
                        size.size  = row[0].ToString();
                        sizeList.Add(size);
                    }
                    return sizeList;
                }
                return new List<Size>();
            }
            #endregion
        
            #region Category
            public List<Category> ListCategory()
            {
                if (connectionStatus)
                {
                    List<Category> categoryList = new List<Category>();
                    Category category;
                    sqlCommand = new SqlCommand(LocalStoreProcedures.LIST_CATEGORY, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    dataTable = new DataTable("Category");
                    sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        category = new Category();
                        category.category  = row[0].ToString();
                        categoryList.Add(category);
                    }
                    return categoryList;
                }
                return new List<Category>();
            }
            #endregion
        
            #region Group
            public List<Group> ListGroup(Category category)
            {
                if (connectionStatus)
                {
                    List<Group> groupList = new List<Group>();
                    Group group;
                    sqlCommand = new SqlCommand(LocalStoreProcedures.LIST_DYNAMIC_TABLE, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("NAME", category.category);
                    dataTable = new DataTable("Group");
                    sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        group = new Group();
                        group.category = category.category;
                        group.group = row[0].ToString();
                        groupList.Add(group);
                    }
                    return groupList;
                }
                return new List<Group>();
            }
            #endregion

            #region Division
       
            public List<Division> ListDivision(Group group)
            {
                if (connectionStatus)
                {
                    List<Division> divisionList = new List<Division>();
                    Division division;
                    sqlCommand = new SqlCommand(LocalStoreProcedures.LIST_DYNAMIC_TABLE, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("NAME", group.category + "_" + group.group);
                    dataTable = new DataTable("Division");
                    sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        division = new Division();
                        division.category = group.category;
                        division.group = group.group;
                        division.division = row[0].ToString();
                        divisionList.Add(division);
                    }
                    return divisionList;
                }
                return new List<Division>();
            }
            #endregion

            #region Brand
            public List<Brand> ListBrand(Division division)
            {
                if (connectionStatus)
                {
                    List<Brand> brandList = new List<Brand>();
                    Brand brand;
                    sqlCommand = new SqlCommand(LocalStoreProcedures.LIST_DYNAMIC_TABLE, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("NAME", division.category + "_" + division.group + "_" + division.division);
                    dataTable = new DataTable("Division");
                    sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        brand = new Brand();
                        brand.category = division.category;
                        brand.group = division.group;
                        brand.group = division.division;
                        brand.brand = row[0].ToString();
                        brandList.Add(brand);
                    }
                    return brandList;
                }
                return new List<Brand>();
            }
        #endregion

        #region Add New Product
        public int AddProduct(List<NewProduct> newProductList)
        {
            int length = newProductList.Count();
            int executedLength = 0;
            if (connectionStatus)
            {
                foreach (var newProduct in newProductList)
                {
                    sqlCommand = new SqlCommand(LocalStoreProcedures.INSERT_NEW_PRODUCT, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("CATEGORY", newProduct.category);
                    sqlCommand.Parameters.AddWithValue("GROUP_NAME", newProduct.group);
                    sqlCommand.Parameters.AddWithValue("DIVISION", newProduct.divisionn);
                    sqlCommand.Parameters.AddWithValue("SIZE", newProduct.size);
                    sqlCommand.Parameters.AddWithValue("BRAND", newProduct.brand);
                    sqlCommand.Parameters.AddWithValue("STYLE_CODE", newProduct.styleCode);
                    sqlCommand.Parameters.AddWithValue("BARCODE", newProduct.barcode);
                    sqlCommand.Parameters.AddWithValue("LENGTH", newProduct.length);
                    sqlCommand.Parameters.AddWithValue("MRP", newProduct.mrp);
                    sqlCommand.Parameters.AddWithValue("SUB_TOTAL", newProduct.subTotal);
                    sqlCommand.Parameters.AddWithValue("GST", newProduct.gst);
                    sqlCommand.Parameters.AddWithValue("PRICE", newProduct.price);
                    sqlCommand.Parameters.AddWithValue("MANUFACTURED_DATE", newProduct.manufacturedDate);
                    if (sqlCommand.ExecuteNonQuery() == 1)
                    {
                        executedLength++;
                    }
                }
            }
            return executedLength;
        }
        #endregion

        #endregion

        #region GST Plan
        public int AddGst(GST gst)
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.INSERT_GST, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("ABOVE", gst.above);
                sqlCommand.Parameters.AddWithValue("GST", gst.gst);
                return sqlCommand.ExecuteNonQuery();
            }
            return 0;
        }
        public GST SelectGst(int mrp)
        {
            GST gst;

            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.SELECT_GST, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("MRP", mrp);
                dataTable = new DataTable("GST");
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    gst = new GST();
                    DataRow row = dataTable.Rows[0];
                    gst.gst = Convert.ToInt32(row[0].ToString());
                    return gst;
                }
                else
                {
                    gst = new GST();
                    DataRow row = dataTable.Rows[0];
                    gst.gst = 0;
                    return gst;
                }
            }
            return new GST();
        }
        public List<GST> ListGst()
        {
            if (connectionStatus)
            {
                List<GST> gstList = new List<GST>();
                GST gst;
                sqlCommand = new SqlCommand(LocalStoreProcedures.LIST_GST, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                dataTable = new DataTable("GST");
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    gst = new GST();
                    gst.above = Convert.ToInt32(row[1].ToString());
                    gst.gst = Convert.ToInt32(row[2].ToString());
                    gstList.Add(gst);
                }
                return gstList;
            }
            return new List<GST>();
        }
        #endregion

        #region Barcode Register
        public int InsertBarcodeRegister(BarcodeRegister barcodeRegister)
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.INSERT_AND_UPDATE_BARCODE_REGISTER, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("BARCODE", barcodeRegister.barcode);
                sqlCommand.Parameters.AddWithValue("QUANTITY", barcodeRegister.quantity);
                return sqlCommand.ExecuteNonQuery();
            }
            return 0;
        }
        public List<BarcodeRegister> ListBarcodeRegister()
        {
            if (connectionStatus)
            {
                List<BarcodeRegister> barcodeRegisterList = new List<BarcodeRegister>();
                BarcodeRegister barcodeRegister;
                sqlCommand = new SqlCommand(LocalStoreProcedures.LIST_BARCODE_REISTER, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                dataTable = new DataTable("Barcode Register");
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    barcodeRegister = new BarcodeRegister();
                    barcodeRegister.barcode = row[1].ToString();
                    barcodeRegister.quantity = Convert.ToInt32(row[2].ToString());
                    barcodeRegisterList.Add(barcodeRegister);
                }
                return barcodeRegisterList;
            }
            return new List<BarcodeRegister>();
        }
        #endregion

        #region Purchase Order
        public int LengthOfPurchasesList()
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.COUNT_OF_PURCHASES_LIST, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                dataTable = new DataTable("Length of Purchases List");
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    int lengthOfPurchasesList;
                    DataRow row = dataTable.Rows[0];
                    lengthOfPurchasesList = Convert.ToInt32(row[0].ToString());
                    return lengthOfPurchasesList;
                }
                else
                {
                    int lengthOfPurchasesList;
                    DataRow row = dataTable.Rows[0];
                    lengthOfPurchasesList = 0;
                    return lengthOfPurchasesList;
                }
            }
            return 0;
        }
        public int InsertPurchaseList(PurchasesList purchasesList)
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.INSERT_PURCHASES_LIST, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("PURCHASE_ID", purchasesList.purchaseId);
                sqlCommand.Parameters.AddWithValue("NO_OF_PRODUCTS", purchasesList.noOfProducts);
                sqlCommand.Parameters.AddWithValue("SOURCE_FROM", purchasesList.sourceFrom);
                sqlCommand.Parameters.AddWithValue("SOURCE_TO", purchasesList.sourceTo);
                sqlCommand.Parameters.AddWithValue("STATUS", purchasesList.status);
                return sqlCommand.ExecuteNonQuery();
            }
            return 0;
        }
        public int InsertPurchaseDetailsList(PurchaseDetailsList purchaseDetailsList, string tableName)
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.INSERT_PURCHASE_DETAILS_LIST, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("TABLE_NAME", tableName);
                sqlCommand.Parameters.AddWithValue("BARCODE", purchaseDetailsList.barcode);
                sqlCommand.Parameters.AddWithValue("BRAND", purchaseDetailsList.brand);
                sqlCommand.Parameters.AddWithValue("CAETEGORY", purchaseDetailsList.category);
                sqlCommand.Parameters.AddWithValue("GROUP_NAME", purchaseDetailsList.groupName);
                sqlCommand.Parameters.AddWithValue("DIVISION", purchaseDetailsList.division);
                sqlCommand.Parameters.AddWithValue("SIZE", purchaseDetailsList.size);
                sqlCommand.Parameters.AddWithValue("QUANTITY", purchaseDetailsList.quantity);
                return sqlCommand.ExecuteNonQuery();
            }
            return 0;
        }
        public int CreatePurchaseDetails(string tableName)
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.CREATE_PURCHASE_DETAILS, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("TABLE_NAME", tableName);
                return sqlCommand.ExecuteNonQuery();
            }
            return 0;
        }
        public List<PurchasesList> ListPurchsesList()
        {
            if (connectionStatus)
            {
                List<PurchasesList> purchasesListList = new List<PurchasesList>();
                PurchasesList purchasesList;
                sqlCommand = new SqlCommand(LocalStoreProcedures.LIST_PURCHASES_LIST, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                dataTable = new DataTable("Purchases List");
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    purchasesList = new PurchasesList();
                    purchasesList.purchaseId = row[1].ToString();
                    purchasesList.noOfProducts = Convert.ToInt32(row[2].ToString());
                    purchasesList.sourceFrom = row[3].ToString();
                    purchasesList.sourceTo = row[4].ToString();
                    purchasesList.status = row[5].ToString();
                    purchasesListList.Add(purchasesList);
                }
                return purchasesListList;
            }
            return new List<PurchasesList>();
        }
        public List<PurchaseDetailsList> ListPurchseDetailsList()
        {
            if (connectionStatus)
            {
                List<PurchaseDetailsList> purchasesDetailsList = new List<PurchaseDetailsList>();
                PurchaseDetailsList purchasesDetails;
                sqlCommand = new SqlCommand(LocalStoreProcedures.LIST_PURCHASE_DETAILS_LIST, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                dataTable = new DataTable("Purchase Details List");
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    purchasesDetails = new PurchaseDetailsList();
                    purchasesDetails.barcode = row[1].ToString();
                    purchasesDetails.brand = row[2].ToString();
                    purchasesDetails.category = row[3].ToString();
                    purchasesDetails.groupName = row[4].ToString();
                    purchasesDetails.division = row[5].ToString();
                    purchasesDetails.size = row[6].ToString();
                    purchasesDetails.quantity = Convert.ToInt32(row[7].ToString());
                    purchasesDetailsList.Add(purchasesDetails);
                }
                return purchasesDetailsList;
            }
            return new List<PurchaseDetailsList>();
        }
        #endregion

        #region Transfer Order

        public int LengthOfTransfersList()
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.COUNT_OF_TRANSFER_LIST, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                dataTable = new DataTable("Length of Purchases List");
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    int lengthOfPurchasesList;
                    DataRow row = dataTable.Rows[0];
                    lengthOfPurchasesList = Convert.ToInt32(row[0].ToString());
                    return lengthOfPurchasesList;
                }
                else
                {
                    int lengthOfPurchasesList;
                    DataRow row = dataTable.Rows[0];
                    lengthOfPurchasesList = 0;
                    return lengthOfPurchasesList;
                }
            }
            return 0;
        }
        public int InsertTransferList(TransfersList transfersList)
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.INSERT_TRANSFER_LIST, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("PURCHASE_ID", transfersList.transferId);
                sqlCommand.Parameters.AddWithValue("NO_OF_PRODUCTS", transfersList.noOfProducts);
                sqlCommand.Parameters.AddWithValue("SOURCE_FROM", transfersList.sourceFrom);
                sqlCommand.Parameters.AddWithValue("SOURCE_TO", transfersList.sourceTo);
                sqlCommand.Parameters.AddWithValue("STATUS", transfersList.status);
                return sqlCommand.ExecuteNonQuery();
            }
            return 0;
        }
        public int InsertTransferDetailsList(TransferDetailsList transferDetailsList, string tableName)
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.INSERT_TRANSFER_DETAILS_LIST, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("TABLE_NAME", tableName);
                sqlCommand.Parameters.AddWithValue("BARCODE", transferDetailsList.barcode);
                sqlCommand.Parameters.AddWithValue("BRAND", transferDetailsList.brand);
                sqlCommand.Parameters.AddWithValue("CAETEGORY", transferDetailsList.category);
                sqlCommand.Parameters.AddWithValue("GROUP_NAME", transferDetailsList.groupName);
                sqlCommand.Parameters.AddWithValue("DIVISION", transferDetailsList.division);
                sqlCommand.Parameters.AddWithValue("SIZE", transferDetailsList.size);
                sqlCommand.Parameters.AddWithValue("QUANTITY", transferDetailsList.quantity);
                return sqlCommand.ExecuteNonQuery();
            }
            return 0;
        }
        public int CreateTransferDetails(string tableName)
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.CREATE_TRANSFER_DETAILS, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("TABLE_NAME", tableName);
                return sqlCommand.ExecuteNonQuery();
            }
            return 0;
        }
        public List<TransfersList> ListTransfersList()
        {
            if (connectionStatus)
            {
                List<TransfersList> transfersListList = new List<TransfersList>();
                TransfersList transfersList;
                sqlCommand = new SqlCommand(LocalStoreProcedures.LIST_TRANSFER_LIST, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                dataTable = new DataTable("Transfers List");
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    transfersList = new TransfersList();
                    transfersList.transferId = row[1].ToString();
                    transfersList.noOfProducts = Convert.ToInt32(row[2].ToString());
                    transfersList.sourceFrom = row[3].ToString();
                    transfersList.sourceTo = row[4].ToString();
                    transfersList.status = row[5].ToString();
                    transfersListList.Add(transfersList);
                }
                return transfersListList;
            }
            return new List<TransfersList>();
        }
        public List<TransferDetailsList> ListTransferDetailsList()
        {
            if (connectionStatus)
            {
                List<TransferDetailsList> transfersDetailsList = new List<TransferDetailsList>();
                TransferDetailsList transferDetailsList;
                sqlCommand = new SqlCommand(LocalStoreProcedures.LIST_TRANSFER_DETAILS_LIST, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                dataTable = new DataTable("Purchase Details List");
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    transferDetailsList = new TransferDetailsList();
                    transferDetailsList.barcode = row[1].ToString();
                    transferDetailsList.brand = row[2].ToString();
                    transferDetailsList.category = row[3].ToString();
                    transferDetailsList.groupName = row[4].ToString();
                    transferDetailsList.division = row[5].ToString();
                    transferDetailsList.size = row[6].ToString();
                    transferDetailsList.quantity = Convert.ToInt32(row[7].ToString());
                    transfersDetailsList.Add(transferDetailsList);
                }
                return transfersDetailsList;
            }
            return new List<TransferDetailsList>();
        }
        #endregion

        #region Inventory

        public int InsertInventory(Inventory inventory)
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.INSERT_INVENTORY, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("CATEGORY", inventory.category);
                sqlCommand.Parameters.AddWithValue("GROUP_NAME", inventory.group);
                sqlCommand.Parameters.AddWithValue("DIVISION", inventory.divisionn);
                sqlCommand.Parameters.AddWithValue("SIZE", inventory.size);
                sqlCommand.Parameters.AddWithValue("BRAND", inventory.brand);
                sqlCommand.Parameters.AddWithValue("STYLE_CODE", inventory.styleCode);
                sqlCommand.Parameters.AddWithValue("BARCODE", inventory.barcode);
                sqlCommand.Parameters.AddWithValue("QUANTITY", inventory.quantity);
                sqlCommand.Parameters.AddWithValue("LENGTH", inventory.length);
                sqlCommand.Parameters.AddWithValue("MRP", inventory.mrp);
                sqlCommand.Parameters.AddWithValue("SUB_TOTAL", inventory.subTotal);
                sqlCommand.Parameters.AddWithValue("GST", inventory.gst);
                sqlCommand.Parameters.AddWithValue("PRICE", inventory.price);
                sqlCommand.Parameters.AddWithValue("MANUFACTURED_DATE", inventory.manufacturedDate);
                sqlCommand.Parameters.AddWithValue("ORIGIN", inventory.origin);
                return sqlCommand.ExecuteNonQuery();
            }
            return 0;
        }
        public Inventory SelectInventory(string barcode)
        {
            Inventory inventory = new Inventory();

            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.SELECT_INVENTORY, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("BARCODE", barcode);
                dataTable = new DataTable("Inventory");
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    inventory.category = row[1].ToString();
                    inventory.group = row[2].ToString();
                    inventory.divisionn = row[3].ToString();
                    inventory.size = row[4].ToString();
                    inventory.brand = row[5].ToString();
                    inventory.styleCode = row[6].ToString();
                    inventory.barcode = row[7].ToString();
                    inventory.quantity = Convert.ToInt32(row[8].ToString());
                    inventory.length = row[9].ToString();
                    inventory.mrp = (float)Convert.ToDouble(row[10].ToString());
                    inventory.discount = (float)Convert.ToDouble(row[11].ToString());
                    inventory.subTotal = (float)Convert.ToDouble(row[12].ToString());
                    inventory.gst = (float)Convert.ToDouble(row[13].ToString());
                    inventory.price = (float)Convert.ToDouble(row[14].ToString());
                    inventory.manufacturedDate = row[15].ToString();
                    inventory.origin = row[16].ToString();
                    return inventory;
                }
                else
                {
                    return inventory;
                }
            }
            return inventory;
        }
        public List<Inventory> ListInventory()
        {
            List<Inventory> inventories = new List<Inventory>();
            Inventory inventory;
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.LIST_INVENTORY, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                dataTable = new DataTable("Inventory");
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    inventory = new Inventory();
                    inventory.category = row[1].ToString();
                    inventory.group = row[2].ToString();
                    inventory.divisionn = row[3].ToString();
                    inventory.size = row[4].ToString();
                    inventory.brand = row[5].ToString();
                    inventory.styleCode = row[6].ToString();
                    inventory.barcode = row[7].ToString();
                    inventory.quantity = Convert.ToInt32(row[8].ToString());
                    inventory.length = row[9].ToString();
                    inventory.mrp = (float)Convert.ToDouble(row[10].ToString());
                    inventory.discount = (float)Convert.ToDouble(row[11].ToString());
                    inventory.subTotal = (float)Convert.ToDouble(row[12].ToString());
                    inventory.gst = (float)Convert.ToDouble(row[13].ToString());
                    inventory.price = (float)Convert.ToDouble(row[14].ToString());
                    inventory.manufacturedDate = row[15].ToString();
                    inventory.origin = row[16].ToString();
                    inventories.Add(inventory);
                }
            }
            return inventories;
        }
        public int UpdateInventory(string barcode, string quantity)
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.UPDATE_INVENTORY, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("BARCODE", barcode);
                sqlCommand.Parameters.AddWithValue("QUANTITY", quantity);
                return sqlCommand.ExecuteNonQuery();
            }
            return 0;
        }
        public int IntegratedInsertUpdateInventory(Inventory inventory)
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.INTEGRATED_INSERT_AND_UPDATE, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("CATEGORY", inventory.category);
                sqlCommand.Parameters.AddWithValue("GROUP_NAME", inventory.group);
                sqlCommand.Parameters.AddWithValue("DIVISION", inventory.divisionn);
                sqlCommand.Parameters.AddWithValue("SIZE", inventory.size);
                sqlCommand.Parameters.AddWithValue("BRAND", inventory.brand);
                sqlCommand.Parameters.AddWithValue("STYLE_CODE", inventory.styleCode);
                sqlCommand.Parameters.AddWithValue("BARCODE", inventory.barcode);
                sqlCommand.Parameters.AddWithValue("QUANTITY", inventory.quantity);
                sqlCommand.Parameters.AddWithValue("LENGTH", inventory.length);
                sqlCommand.Parameters.AddWithValue("MRP", inventory.mrp);
                sqlCommand.Parameters.AddWithValue("SUB_TOTAL", inventory.subTotal);
                sqlCommand.Parameters.AddWithValue("GST", inventory.gst);
                sqlCommand.Parameters.AddWithValue("PRICE", inventory.price);
                sqlCommand.Parameters.AddWithValue("MANUFACTURED_DATE", inventory.manufacturedDate);
                sqlCommand.Parameters.AddWithValue("ORIGIN", inventory.origin);
                return sqlCommand.ExecuteNonQuery();
            }
            return 0;
        }

        #endregion

        #region Stock Inward
        public int UpdatePurchaseAndTransferDetailsList(string tableName, string barcode, int currentQuantity, int pendingQuantity, string status)
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.UPDATE_PURCHASE_AND_TRANSFER_DETAILS_QUANTITY, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("TABLE_NAME", tableName);
                sqlCommand.Parameters.AddWithValue("BARCODE", barcode);
                sqlCommand.Parameters.AddWithValue("CURRENT_QUANTITY", currentQuantity);
                sqlCommand.Parameters.AddWithValue("PENDING_QUANTITY", pendingQuantity);
                sqlCommand.Parameters.AddWithValue("STATUS", status);
                return sqlCommand.ExecuteNonQuery();
            }
            return 0;
        }
        #endregion

        #region Customers
        public int InsertCustomer(Customers customers)
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.INSERT_CUSTOMERS, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("FIRST_NAME", customers.firstName);
                sqlCommand.Parameters.AddWithValue("LAST_NAME", customers.lastName);
                sqlCommand.Parameters.AddWithValue("MOBILE_NUMBER", customers.mobileNumber);
                sqlCommand.Parameters.AddWithValue("OCCUPATION", customers.occupation);
                sqlCommand.Parameters.AddWithValue("DATE_OF_BIRTH", customers.dateOfBirth);
                sqlCommand.Parameters.AddWithValue("GENDER", customers.gender);
                sqlCommand.Parameters.AddWithValue("AGE_GROUP", customers.ageGroup);
                sqlCommand.Parameters.AddWithValue("COMMUNICATION_TYPE", customers.communicationType);
                sqlCommand.Parameters.AddWithValue("EMAIL", customers.email);
                sqlCommand.Parameters.AddWithValue("CITY", customers.city);
                sqlCommand.Parameters.AddWithValue("CITY", customers.city);
                sqlCommand.Parameters.AddWithValue("LOYALTY_POINTS", customers.loyaltyPoints);
                return sqlCommand.ExecuteNonQuery();
            }
            return 0;
        }
        public List<Customers> ListCustomers()
        {
            if (connectionStatus)
            {
                List<Customers> companyDetailsList = new List<Customers>();
                Customers customers;
                sqlCommand = new SqlCommand(LocalStoreProcedures.LIST_CUSTOMERS, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                dataTable = new DataTable("Customers");
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    customers = new Customers();
                    customers.firstName = row[1].ToString();
                    customers.lastName = row[2].ToString();
                    customers.mobileNumber = Convert.ToInt32(row[3].ToString());
                    customers.occupation = row[4].ToString();
                    customers.dateOfBirth = row[5].ToString();
                    customers.gender = row[6].ToString();
                    customers.ageGroup = row[7].ToString();
                    customers.communicationType = row[8].ToString();
                    customers.email = row[9].ToString();
                    customers.city = row[10].ToString();
                    customers.loyaltyPoints = (float)Convert.ToDouble(row[11].ToString());
                    companyDetailsList.Add(customers);
                }
                return companyDetailsList;
            }
            return new List<Customers>();
        }
        public Customers SlectCustomer(int mobileNumnber)
        {
            Customers customers = new Customers();
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.SELECT_CUSTOMER, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("MOBILE_NUMBER", mobileNumnber);
                dataTable = new DataTable("Customers");
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    customers.firstName = row[1].ToString();
                    customers.lastName = row[2].ToString();
                    customers.mobileNumber = Convert.ToInt32(row[3].ToString());
                    customers.occupation = row[4].ToString();
                    customers.dateOfBirth = row[5].ToString();
                    customers.gender = row[6].ToString();
                    customers.ageGroup = row[7].ToString();
                    customers.communicationType = row[8].ToString();
                    customers.email = row[9].ToString();
                    customers.city = row[10].ToString();
                    customers.loyaltyPoints = (float)Convert.ToDouble(row[11].ToString());
                }
            }
            return customers;
        }
        public int UpdateLoyaltyPoints(float loyaltyPoints, int mobileNumnber)
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.UPDATE_LOYALTY_POINTS_OF_CUSTOMER, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("LOYALTY_POINTS", loyaltyPoints);
                sqlCommand.Parameters.AddWithValue("MOBILE_NUMBER", mobileNumnber);
                return sqlCommand.ExecuteNonQuery();
            }
            return 0;
        }
        public int UpdateCustomer(Customers customers, int previousMobilNumber)
        {
            if (connectionStatus)
            {
                sqlCommand = new SqlCommand(LocalStoreProcedures.INSERT_CUSTOMERS, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("PREVIOUS_MOBILE_NUMBER", previousMobilNumber);
                sqlCommand.Parameters.AddWithValue("FIRST_NAME", customers.firstName);
                sqlCommand.Parameters.AddWithValue("LAST_NAME", customers.lastName);
                sqlCommand.Parameters.AddWithValue("MOBILE_NUMBER", customers.mobileNumber);
                sqlCommand.Parameters.AddWithValue("OCCUPATION", customers.occupation);
                sqlCommand.Parameters.AddWithValue("DATE_OF_BIRTH", customers.dateOfBirth);
                sqlCommand.Parameters.AddWithValue("GENDER", customers.gender);
                sqlCommand.Parameters.AddWithValue("AGE_GROUP", customers.ageGroup);
                sqlCommand.Parameters.AddWithValue("COMMUNICATION_TYPE", customers.communicationType);
                sqlCommand.Parameters.AddWithValue("EMAIL", customers.email);
                sqlCommand.Parameters.AddWithValue("CITY", customers.city);
                sqlCommand.Parameters.AddWithValue("CITY", customers.city);
                sqlCommand.Parameters.AddWithValue("LOYALTY_POINTS", customers.loyaltyPoints);
                return sqlCommand.ExecuteNonQuery();
            }
            return 0;
        } 
        #endregion
    }
}
