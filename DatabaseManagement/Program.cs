using System;

using System.Data.SqlClient;

namespace DatabaseManagement
{
class Program{
     
    static void Main(string[] args)


    {

        SqlProductDal dal = new SqlProductDal();
        Product p = dal.GetProductByID(3);
        Console.WriteLine(p.ProductName + p.ProductPrice);
        List<Product> ps = new List<Product>();
        ps = dal.Find("Tofu");
        foreach (var a in ps)
        {
            Console.WriteLine(a.ProductName);
        }
        // var myManager = new ProductManager(new SqlProductDal());
        // var products = myManager.GetAllProducts();

        // foreach (var p in products){

        //     Console.WriteLine($"product name {p.ProductName}");
        // }

        
    }

}}