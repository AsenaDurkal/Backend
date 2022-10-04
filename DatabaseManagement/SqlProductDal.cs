using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseManagement
{
    public class SqlProductDal : IProductDal
    {
            Product product;

            List<Product> products;

            private SqlConnection GetSqlConnection()
            {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";
            return new SqlConnection(connectionString);
            }


            public void Create(Product p)
            {
                throw new NotImplementedException();
            }

            

            public List<Product> GetAllProducts()
            {
                using(var connection = GetSqlConnection())

                try{

                    connection.Open();
                    string sql = "select * from products";
                    SqlCommand command = new SqlCommand(sql,connection);
                    SqlDataReader read = command.ExecuteReader();
                    
                    products = new List<Product>();
                    while(read.Read()){
                        
                        products.Add(
                            new Product{
                                ProductID = int.Parse(read["ProductID"].ToString()),
                                ProductName = read["ProductName"].ToString(),
                                ProductPrice = double.Parse(read["UnitPrice"].ToString())
                            }
                        );
                    }
                   read.Close();

                }
                catch(Exception e){

                    Console.WriteLine($"Error: {e} ");
                }
                finally{
                    connection.Close();
                }
                return products;
            }

        public Product GetProductByID(int id)
        {
                using(var connection = GetSqlConnection())

                try{

                    connection.Open();
                    string sql = "select * from products";
                    SqlCommand command = new SqlCommand(sql,connection);
                    SqlDataReader read = command.ExecuteReader();
                    product = new Product();
                    while(read.Read()){
                        
                        if(id == int.Parse(read["ProductID"].ToString()))
                        {
                            product.ProductID = int.Parse(read["ProductID"].ToString());
                            product.ProductName = read["ProductName"].ToString();
                            product.ProductPrice = double.Parse(read["UnitPrice"].ToString());
                        }
                    }
                    read.Close();

                    
                
                }
                catch(Exception e){

                    Console.WriteLine($"Error: {e} ");
                }
                finally{
                    connection.Close();
                }
                return product;
            }

        public List<Product> Find(string ProductName)
        {
                using(var connection = GetSqlConnection())

                try
                {

                    connection.Open();
                    string sql = "select * from products";
                    SqlCommand command = new SqlCommand(sql,connection);
                    SqlDataReader read = command.ExecuteReader();
                    products = new List<Product>();
                    while(read.Read()){
                        
                        if(ProductName == read["ProductName"].ToString())
                        {
                            products.Add(new Product(){ProductID = int.Parse(read["ProductID"].ToString()),
                                        ProductName = read["ProductName"].ToString(),
                                        ProductPrice = double.Parse(read["UnitPrice"].ToString())});
                        }
                    }
                    read.Close();

                }
                catch(Exception e){

                    Console.WriteLine($"Error: {e} ");
                }
                finally{
                    connection.Close();
                }
                return products;
                
            }

        

        public void Update(Product p)
        {
            throw new NotImplementedException();
        }

        public void Delete(int productID)
        {
            throw new NotImplementedException();
        }
    }



}
