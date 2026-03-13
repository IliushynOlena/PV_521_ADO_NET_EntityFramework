using System.ComponentModel.DataAnnotations;

namespace _05_EntityFramework
{
    class Flight
    {
        public int Number { get; set; }
        public string ArrivalCity { get; set; }
        public string DepartureCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }



        //Relationship type : many to many (*...*)
        public ICollection<Client> Clients { get; set; }


        public Airplane Airplane { get; set; }
        public int AirplaneId { get; set; }

    }
}
