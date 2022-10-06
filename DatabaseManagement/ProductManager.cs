using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static DatabaseManagement.Program;

namespace DatabaseManagement
{
    public class ProductManager : IProductDal
    {       
        
            IProductDal _productDal;
            public ProductManager(IProductDal productDal){

                _productDal = productDal;
            }

        public void Create(Product p)
        {
            throw new NotImplementedException();
        }

        public void Delete(int productID)
        {
            throw new NotImplementedException();
        }

        public List<Product> Find(string ProductName)
        {
            return _productDal.Find(ProductName);
        }

        public List<Product> GetAllProducts()
            {
                return _productDal.GetAllProducts();
            }

        public Product GetProductByID(int id)
        {
            return _productDal.GetProductByID(id);
        }

        public void Update(Product p)
        {
            throw new NotImplementedException();
        }
    }
}