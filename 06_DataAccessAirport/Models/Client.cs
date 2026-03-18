using _06_DataAccessAirport.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _05_EntityFramework.Models
{
    public class Client
    {
        //public int Id { get; set; }//not null indentity primary key(unique)
        public int CredentialId { get; set; } //int not null foreign key + primary key
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }
       public int Rating { get; set; }
        //public ICollection<Flight> Flights { get; set; }//null
        public ICollection<ClientFlight> ClientFlights { get; set; }//null
        public Credential Credential { get; set; }//null


    }
}
