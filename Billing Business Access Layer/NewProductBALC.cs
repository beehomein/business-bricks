using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Data_Access_Layer;
using Billing_Business_Entity_Layer;

namespace Billing_Business_Access_Layer
{
    public class NewProductBALC
    {
        Connection connection;
        public List<Category> categoryList;
        public List<Size> sizeList;
        public List<Group> groupList;
        public List<Division> divisionList;
        public List<Brand> brandList;

        #region Group
        public List<Group> ListGroup(Category category)
        {
            connection = new Connection();
            groupList = new List<Group>();
            groupList = connection.ListGroup(category);
            return groupList;
        }
        #endregion

        #region Division
        public List<Group> ListDivision(Group group)
        {
            connection = new Connection();
            divisionList = new List<Division>();
            divisionList = connection.ListDivision(group);
            return groupList;
        }
        #endregion

        #region Brand
        public List<Brand> ListBrand(Division division)
        {
            connection = new Connection();
            brandList = new List<Brand>();
            brandList = connection.ListBrand(division);
            return brandList;
        }
        #endregion

        #region Category
        public List<Category> ListCategory()
        {
            connection = new Connection();
            categoryList = new List<Category>();
            categoryList = connection.ListCategory();
            return categoryList;
        }
        #endregion
        
        #region Size
        public List<Size> ListSize()
        {
            connection = new Connection();
            sizeList = new List<Size>();
            sizeList = connection.ListSize();
            return sizeList;
        }
        #endregion

        #region Add New Product
        public int AddProduct(List<NewProduct> newProductList)
        {
            connection = new Connection();
            GST gst;
            foreach (var newProduct in newProductList)
            {
                gst=connection.SelectGst(Convert.ToInt32(newProduct.mrp));
                newProduct.discount = 0;
                newProduct.subTotal = newProduct.mrp - newProduct.discount;
                var gstPecentage = gst.gst;
                var calculatedGst = 0.0f;
                var calculatedPrice = 0.0f;
                calculatedGst = (newProduct.mrp * (100 + gstPecentage)) * gstPecentage;
                calculatedPrice = newProduct.mrp - calculatedGst;
                newProduct.price = calculatedPrice;
                newProduct.gst = calculatedGst;
            }
            return connection.AddProduct(newProductList);
        } 
        #endregion


    }
}
