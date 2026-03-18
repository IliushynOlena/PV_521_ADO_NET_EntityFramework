using _06_DataAccessAirport.Models;
using System.ComponentModel.DataAnnotations;

namespace _05_EntityFramework.Models
{
    public class Flight
    {
        public int Number { get; set; }
        public string ArrivalCity { get; set; }
        public string DepartureCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        //public ICollection<Client> Clients { get; set; }
        public ICollection<ClientFlight> ClientFlights { get; set; }
        public Airplane Airplane { get; set; }//null
        public int AirplaneId { get; set; }

    }
}
