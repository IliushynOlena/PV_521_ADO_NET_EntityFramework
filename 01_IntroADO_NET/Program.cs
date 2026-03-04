using System.Data.SqlClient;
using System.Text;

namespace _01_IntroADO_NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //connectionString : Property= value;propery2=value2;
            //Data Source - server name
            //Initial Catalog - name database
            //Integrated Sequrity - windows user - true / owervise - false
            //login - password
            string connectionString = @"Data Source=DESKTOP-1LCG8OH\SQLEXPRESS;Initial Catalog=SportShop;Integrated Security=True;Connect Timeout=5;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            Console.WriteLine("Connected success!!!!");

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



            #endregion
            //working with database
            con.Close();    
        }
    }
}
