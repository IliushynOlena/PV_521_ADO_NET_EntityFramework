using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace _02_ConnectedMode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CRUD
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
            //Product newPr = new Product();
            //newPr.Name = Console.ReadLine();
            //newPr.Price = int.Parse(Console.ReadLine());
            //dB.Create(pr);
            //dB.Delete(69);
            //var products = dB.GetAll();
            //foreach (var item in products)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            Product find = dB.GetOneById(68);
            Console.WriteLine($"Find product : {find.Name} . {find.Price}");

            find.Price = 10000;
            find.Name = "new name";

            dB.Update(find);

            Console.WriteLine("Enter name product for search : ");
            string name = Console.ReadLine()!;
            var products = dB.GetAllByName(name);
            foreach (var item in products)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}
