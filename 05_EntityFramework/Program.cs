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
            foreach (var client in dbContext.Clients)
            {
                Console.WriteLine($"{client.Name}. Email: {client.Email}");
            }

            int a = 0;
            int? b = null;

            var flights = dbContext.Flights.Where(f => f.ArrivalCity == "kyiv").OrderBy(f => f.ArrivalTime);
            foreach (var flight in flights)
            {
                Console.WriteLine($"From : {flight.ArrivalCity}. To : {flight.DepartureCity}.\n" +
                    $"Date : {flight.ArrivalTime}\n ");
            }

        }
    }
}
