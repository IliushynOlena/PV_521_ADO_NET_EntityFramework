using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;

namespace _01_IntroADO_NET
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
            //connectionString : Property= value;propery2=value2;
            //Data Source - server name
            //Initial Catalog - name database
            //Integrated Sequrity - windows user - true / owervise - false
            //login - password
            /*string connectionString = @"Data Source=DESKTOP-1LCG8OH\SQLEXPRESS;Initial Catalog=SportShop;Integrated Security=True;Connect Timeout=5;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            Console.WriteLine("Connected success!!!!");
            */
            //insert , update, delete
            #region Execute Non-Query
            //string cmdText = @"insert into Products
            //                values('Snowboard New','winter Equipment',15,15000,'Italy',12000)";
            //SqlCommand command = new SqlCommand(cmdText, con);
            //command.CommandTimeout = 5;

            //int row = command.ExecuteNonQuery();
            //Console.WriteLine($"Rows affected : {row}");
            #endregion
            #region Execute Scalar ( return one value)
            //string cmdCommand = @"select AVG(Price) from Products";
            //SqlCommand command = new SqlCommand(cmdCommand, con);
            //int res = (int)command.ExecuteScalar();
            //Console.WriteLine($"Average price : {res}");
            #endregion
            #region Execute Reader
            /*
            string cmdCommand = @"SELECT * FROM Products;";
            SqlCommand command = new SqlCommand(cmdCommand, con);

            SqlDataReader reader =  command.ExecuteReader();   
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < reader.FieldCount; i++)
            {
                //Console.Write(reader.GetName(i) + "\t");
                Console.Write($"{reader.GetName(i),-15}");
            }
            Console.WriteLine("\n--------------------------------------------------------------------------------------------");
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader[i],-15}" );
                }
                Console.WriteLine();

            }

            reader.Close();




            //working with database
            con.Close();    
            */
            #endregion

            string connectionString = @"Data Source=DESKTOP-1LCG8OH\SQLEXPRESS;Initial Catalog=SportShop;Integrated Security=True;Connect Timeout=5;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var users = db.Query<Product>("SELECT Id, Name FROM Products");

                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }
            }
            //string cmdText = $@"insert into Products
            //                values('{product.Name}',
            //                       '{product.Type}',
            //                        {product.Quantity},
            //                        {product.CostPrice},
            //                       '{product.Producer}',
            //                       {product.Price})";
            //string cmdText = @"insert into Products
            //values('Snowboard New','winter Equipment',15,15000,'Italy',12000)";

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO Products (Name, TypeProduct, Quantity,CostPrice,Producer,Price)
              VALUES (@Name, @Type, @Quantity,@CostPrice,@Producer,@Price)";


                db.Execute(sql, new Product { Name = "New", Type = "New", Quantity  = 1, CostPrice = 1,
                  Producer = "New", Price = 1});
            }
            Console.WriteLine("---------------------------------");
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var users = db.Query<Product>("SELECT Id, Name FROM Products");

                foreach (var user in users)
                {
                    Console.WriteLine(user.Id + " "+ user.Name);
                }

                string sql = "UPDATE Products SET Name = @Name WHERE Id = @Id";

                db.Execute(sql, new { Id = 1, Name = "Mike" });

                users = db.Query<Product>("SELECT Id, Name FROM Products");

                foreach (var user in users)
                {
                    Console.WriteLine(user.Id + " " + user.Name);
                }
            }




        }
    }
}
