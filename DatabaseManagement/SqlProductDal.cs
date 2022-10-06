using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseManagement
{
    public class SqlProductDal : IProductDal
    {
            Product product = null;


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
                List<Product> products = null;

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

            public Product GetProductByID(int ID)
            {
                using(var connection = GetSqlConnection())
                try{
                    connection.Open();
                    string sql = "select * from products where ProductID= @roductID";
                    SqlCommand command = new SqlCommand(sql,connection);
                    command.Parameters.Add("@roductID", System.Data.SqlDbType.Int).Value = ID;
                    
                    //The code down belown is the longer version of the upper one.
                    // SqlParameter parameter = new SqlParameter();
                    // parameter.ParameterName = "@roductID";
                    // parameter.Value = ID;
                    //command.Parameters.Add(parameter);
                    SqlDataReader read = command.ExecuteReader();
                    read.Read();
                    if(read.HasRows){
                        product = new Product(){
                        ProductID = int.Parse(read["ProductID"].ToString()),
                        ProductName = read["ProductName"].ToString(),
                        ProductPrice = double.Parse(read["UnitPrice"].ToString())
                        };
                    }
                    read.Close();
                }
                catch(Exception e){

                    Console.WriteLine(e);
                }
                finally{
                    connection.Close();
                }
                return product;
            }

        public List<Product> Find(string ProductName)
        
        {
                List<Product> products = null;

                using(var connection = GetSqlConnection())

                try
                {

                    connection.Open();
                    string sql = "select * from products WHERE ProductName LIKE @ProductName";
                    SqlCommand command = new SqlCommand(sql,connection);
                    command.Parameters.Add("@ProductName",System.Data.SqlDbType.NVarChar).Value = "%" + ProductName + "%";
                    SqlDataReader read = command.ExecuteReader();
                    //read.Read();
                    products = new List<Product>();
                    while(read.Read()){
                        
                        products.Add(
                        new Product
                        {
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
