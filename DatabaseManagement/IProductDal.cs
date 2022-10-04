using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseManagement
{
    public interface IProductDal
    {
        
        List<Product> GetAllProducts();
        Product GetProductByID(int id);

        List<Product> Find(string ProductName);
        void Create(Product p);

        void Update(Product p);

        void Delete (int productID);
    }
}