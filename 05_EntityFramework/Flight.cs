using System.ComponentModel.DataAnnotations;

namespace _05_EntityFramework
{
    class Flight
    {
        [Key]//set primary key
        public int Number { get; set; }

        [MaxLength(100)]
        public string ArrivalCity { get; set; }

        [MaxLength(100)]
        public string DepartureCity { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }






        //Relationship type : many to many (*...*)
        public ICollection<Client> Clients { get; set; }


        //Relationship type : one to many (1...*)
        public Airplane Airplane { get; set; }

        //Forign key naming : RelatedEntityName + RelatedEntityNamePrimaryKey 
        public int AirplaneId { get; set; }//foreign key Airplane (Id)

    }
}
