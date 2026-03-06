using System.Data.SqlClient;

namespace _02_ConnectedMode
{
    public class SportShopDB
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
            //string cmdText = $@"insert into Products
            //                values('{product.Name}',
            //                       '{product.Type}',
            //                        {product.Quantity},
            //                        {product.CostPrice},
            //                       '{product.Producer}',
            //                       {product.Price})";
            string cmdText = $@"insert into Products
                            values(@name,
                                   @type,
                                   @quantity,
                                   @costPrice,
                                   @producer,
                                   @price)";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandTimeout = 5;
            command.Parameters.AddWithValue("name", product.Name);
            command.Parameters.AddWithValue("type", product.Type);
            command.Parameters.AddWithValue("quantity", product.Quantity);
            command.Parameters.AddWithValue("costPrice", product.CostPrice);
            command.Parameters.AddWithValue("producer", product.Producer);
            command.Parameters.AddWithValue("price", product.Price);

            int row = command.ExecuteNonQuery();
            Console.WriteLine($"Rows affected : {row}");
        }
        public List<Product> GetAll()
        {
            string cmdCommand = @"SELECT * FROM Products;";
            SqlCommand command = new SqlCommand(cmdCommand, connection);
            SqlDataReader reader = command.ExecuteReader();
            return GetProductByQuery(reader);
        }
        public List<Product> GetAllByName(string name)
        {
            string cmdCommand = $@"SELECT * FROM Products where Name = @name;";
            SqlCommand command = new SqlCommand(cmdCommand, connection);
            //----- example 1 -----
            //command.Parameters.Add("name", System.Data.SqlDbType.NVarChar).Value = name;

            //----- example 2 -----
            //SqlParameter parameter = new SqlParameter()
            //{
            //    ParameterName = "name",
            //    SqlDbType = System.Data.SqlDbType.NVarChar,
            //    Value = name
            //};
            //command.Parameters.Add(parameter);

            //----- example 3 -----
            command.Parameters.AddWithValue("name", name);

            SqlDataReader reader = command.ExecuteReader();
            return GetProductByQuery(reader);

        }
        public Product GetOneById(int id)//55
        {
            //int ---> hello ?????
            string cmdCommand = $@"SELECT * FROM Products WHERE Id = {id};";
            SqlCommand command = new SqlCommand(cmdCommand, connection);
            SqlDataReader reader = command.ExecuteReader();
            return GetProductByQuery(reader).FirstOrDefault()!;

        }
        private List<Product> GetProductByQuery(SqlDataReader reader)
        {          
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
            command.Parameters.AddWithValue("name", product.Name);
            command.Parameters.AddWithValue("type", product.Type);
            command.Parameters.AddWithValue("quantity", product.Quantity);
            command.Parameters.AddWithValue("costPrice", product.CostPrice);
            command.Parameters.AddWithValue("producer", product.Producer);
            command.Parameters.AddWithValue("price", product.Price);
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
}
