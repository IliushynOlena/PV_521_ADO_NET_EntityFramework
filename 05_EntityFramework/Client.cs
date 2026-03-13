using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _05_EntityFramework
{
    class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }
       public int Rating { get; set; }



        //null ---> not null
        //not null ---> null

        //Relationship type : many to many (*...*)
        public ICollection<Flight> Flights { get; set; }
    }
}
