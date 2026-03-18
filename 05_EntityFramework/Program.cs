using _05_EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace _05_EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirportDbContext dbContext = new AirportDbContext();

            dbContext.Clients.Add(new Client() { 
                 Name = "Olga",
                 Email = "olga@gmail.com",
                 Birthdate = new DateTime(1995,5,14),
            
            });
            //dbContext.SaveChanges();
            //foreach (var client in dbContext.Clients)
            //{
            //    Console.WriteLine($"{client.Name}. Email: {client.Email}");
            //}

            //Include data loading : Include(relation data) - JOIN in SQL
            var flights = dbContext.Flights
                .Include(f=>f.Airplane)
                .Where(f => f.ArrivalCity == "kyiv")
                .OrderBy(f => f.ArrivalTime);
            foreach (var flight in flights)
            {
                Console.WriteLine($"From : {flight.ArrivalCity}. To : {flight.DepartureCity}.\n" +
                    $"Date : {flight.ArrivalTime}\n " +
                    $"AirplaneId : {flight.AirplaneId}." +
                    $" Name Airplane : {flight.Airplane?.Model} \n" +
                    $"Max count passangers : {flight.Airplane?.MaxCountPassangers}\n");
                //if (flight.Airplane != null)
                //    Console.WriteLine(flight.Airplane.Model);
                //else
                //    Console.WriteLine("Airplane not set");
            }

            var client = dbContext.Clients.Find(1);
            //Reference  Collection
            //dbContext?.Entry(client).Collection(c => c!.Flights).Load();
            //Console.WriteLine($"Name : {client?.Name}. Rating : {client?.Rating}");
            //Console.WriteLine($"Count All flights : {client?.Flights.Count}");

            //foreach (var f in client!.Flights)
            //{

            //    Console.WriteLine($"From : {f.ArrivalCity}. To : {f.DepartureCity}.\n" +
            //      $"Date : {f.ArrivalTime}\n ");
            //}
           



            //var airplanes = dbContext.Airplanes
            //    .Where(a=> a.MaxCountPassangers < 100)
            //    .OrderBy(a=>a.MaxCountPassangers);


            //foreach (var item in airplanes)
            //{
            //    Console.WriteLine($"{item.Id}. {item.Model}. {item.MaxCountPassangers}");
            //}
        }
    }
}
