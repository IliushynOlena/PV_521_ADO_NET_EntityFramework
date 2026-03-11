using System.ComponentModel.DataAnnotations;

namespace _05_EntityFramework
{
    //Entity - Airplane
    class Airplane
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Model { get; set; }
        public int MaxCountPassangers { get; set; }




        //Relationship type : one to many (1...*)
        public ICollection<Flight> Flights { get; set; }
    }
}
