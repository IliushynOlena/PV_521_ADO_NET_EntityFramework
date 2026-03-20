using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace _08_DapperTechnology
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public int CostPrice { get; set; }
        public string Producer { get; set; }
        public int Price { get; set; }
        public override string ToString()
        {
            return $"Name:{Name,10} | Type:{Type,10} | Q:{Quantity,5}| Price: {CostPrice,5}| Producer :{Producer,10}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=DESKTOP-1LCG8OH\SQLEXPRESS;Initial Catalog=SportShop;Integrated Security=True;Connect Timeout=5;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();

                var products = db.Query<Product>("SELECT Id, Name, Price FROM Products");
                foreach (Product product in products)
                {
                    Console.WriteLine($"Id : {product.Id} . Name : {product.Name}." +
                        $" Price : {product.Price}");
                }

                //Insert
                string sqlCommand = "INSERT INTO Products (Name, TypeProduct, Quantity,CostPrice,Producer,Price)" +
                    "VALUES (@Name, @Type, @Quantity,@CostPrice,@Producer,@Price)";

                db.Execute(sqlCommand, new Product
                {
                    Name = "NewProduct",
                    Type = "NewType",
                    Quantity = 1,
                    CostPrice = 1,
                    Producer = "New Producer",
                    Price = 2
                });

                products = db.Query<Product>("SELECT Id, Name, Price FROM Products");
                foreach (Product product in products)
                {
                    Console.WriteLine($"Id : {product.Id} . Name : {product.Name}." +
                        $" Price : {product.Price}");
                }

                sqlCommand = "UPDATE Products SET Price = 200 WHERE Id = @id";
                db.Execute(sqlCommand,new {Id = 77});

                products = db.Query<Product>("SELECT Id, Name, Price FROM Products");
                foreach (Product product in products)
                {
                    Console.WriteLine($"Id : {product.Id} . Name : {product.Name}." +
                        $" Price : {product.Price}");
                }

            }
        }
    }
}
