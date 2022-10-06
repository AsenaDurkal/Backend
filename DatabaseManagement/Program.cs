using System;

using System.Data.SqlClient;

namespace DatabaseManagement
{

class Program{
     
    static void Main(string[] args)


    {
        Console.WriteLine("you herE??");
        SqlProductDal dal = new SqlProductDal();
        Product p = dal.GetProductByID(3);
        Console.WriteLine(p.ProductName + p.ProductPrice);
        List<Product> ps = new List<Product>();
        ps = dal.Find("Kon");

        foreach (var a in ps)
            {
                Console.WriteLine(a.ProductID + $"a.{a.ProductName}");
                Console.WriteLine("hh");
            }
    
    }

}
}