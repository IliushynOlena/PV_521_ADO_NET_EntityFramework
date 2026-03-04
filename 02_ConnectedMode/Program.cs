using System.ComponentModel;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;

namespace _02_ConnectedMode
{
    class SportShopDB
    {
        //CRUD Interafce
        //C - create
        //R - read
        //U - update
        //D - delete

        SqlConnection connection;

        public SportShopDB(string path)
        {
            connection = new SqlConnection(path);
            connection.Open();
            Console.WriteLine("Success!!!!!");
        }
        public void Create(Product product)
        {
            string cmdText = $@"insert into Products
                            values('{product.Name}',
                                   '{product.Type}',
                                    {product.Quantity},
                                    {product.CostPrice},
                                   '{product.Producer}',
                                   {product.Price})";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandTimeout = 5;

            int row = command.ExecuteNonQuery();
            Console.WriteLine($"Rows affected : {row}");
        }
        public List<Product> GetAll()
        {
            string cmdCommand = @"SELECT * FROM Products;";
            SqlCommand command = new SqlCommand(cmdCommand, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();   
           
            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Type = (string)reader[2],
                    Quantity = (int)reader[3],
                    CostPrice = (int)reader[4],
                    Producer = (string)reader[5],
                    Price = (int)reader[6]
                });
            }
            reader.Close();
            return products;
        }
        public Product GetOneById(int id)
        {
            string cmdCommand = $@"SELECT * FROM Products WHERE Id = {id};";
            SqlCommand command = new SqlCommand(cmdCommand, connection);
            SqlDataReader reader = command.ExecuteReader();
            Product product = new Product();
            while (reader.Read())
            {
                product.Id = (int)reader[0];
                product.Name = (string)reader[1];
                product.Type = (string)reader[2];
                product.Quantity = (int)reader[3];
                product.CostPrice = (int)reader[4];
                product.Producer = (string)reader[5];
                product.Price = (int)reader[6];             
            }
            reader.Close();
            return product;
        }
        public void Update(Product product)
        {
            string cmdText = $@"
                                UPDATE Products
                                SET Name = '{product.Name}',
                                    TypeProduct = '{product.Type}',
                                    Quantity = {product.Quantity},
                                    CostPrice = {product.CostPrice},
                                    Producer = '{product.Producer}',
                                    Price = {product.Price} WHERE Id={product.Id}

                                ";
            SqlCommand command = new SqlCommand(cmdText, connection);
            int row = command.ExecuteNonQuery();
            Console.WriteLine($"Row affected : {row}");
        }
        public void Delete(int id)
        {
            string cmdText = $@"DELETE Products where Id ={id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            int row = command.ExecuteNonQuery();
            Console.WriteLine($"Row affected : {row}");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=DESKTOP-1LCG8OH\SQLEXPRESS;Initial Catalog=SportShop;Integrated Security=True;Connect Timeout=5;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Console.OutputEncoding = Encoding.UTF8;
            SportShopDB dB  = new SportShopDB(connectionString);  
            Product pr = new Product() { 
                Name = "Stanga",
                Type = "Sport equipment",
                Quantity = 4,
                CostPrice = 500,
                Producer= "China",
                Price = 800                    
            };
            //dB.Create(pr);
            //dB.Delete(69);
            var products = dB.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine(item.ToString());
            }

            Product find = dB.GetOneById(68);
            Console.WriteLine($"Find product : {find.Name} . {find.Price}");

            find.Price = 10000;

            dB.Update(find);
            

        }
    }
}
