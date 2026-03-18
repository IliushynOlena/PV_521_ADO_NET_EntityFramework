using _05_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_DataAccessAirport.Models
{
    public class ClientFlight
    {
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Flight Flight { get; set; }
        public int FlightId { get; set; }
    }
}
