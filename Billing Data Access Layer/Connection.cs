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

    }
}
