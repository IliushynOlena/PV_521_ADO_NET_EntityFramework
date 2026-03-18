using _05_EntityFramework.Models;
using _06_DataAccessAirport.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _05_EntityFramework.Helpers
{
    internal static class DbInitializer
    {
        public static void SeedAirplanes(this ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Airplane>().HasData(new Airplane[]
           {
                new Airplane(){ Id = 1, Model = "AN747"},
                new Airplane(){ Id = 2, Model = "AN746"},
                new Airplane(){ Id = 3, Model = "AN746"},
                new Airplane(){ Id = 4, Model = "AN744"},
                new Airplane(){ Id = 5, Model = "AN743"},
           });

        }
        public static void SeedCredentials(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credential>().HasData(new Credential[]
            {
                new Credential(){ Id = 1, Login = "user1", Password = "12345"},
                new Credential(){ Id = 2, Login = "user2", Password = "12345"},
                new Credential(){ Id = 3, Login = "user3", Password = "12345"},
                new Credential(){ Id = 4, Login = "user4", Password = "12345"},
                new Credential(){ Id = 5, Login = "user5", Password = "12345"},
            });

        }
        public static void SeedClients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(new Client[]
         {
               new Client(){ CredentialId = 1,Name = "Vova", Email = "vova@gmail.com", Birthdate = new DateTime(1995,5,14) },
               new Client(){ CredentialId = 2,Name = "Ira", Email = "ira@gmail.com", Birthdate = new DateTime(2000,5,14) },
               new Client(){ CredentialId = 3,Name = "Nikita", Email = "nikita@gmail.com", Birthdate = new DateTime(2001,5,14) },
               new Client(){ CredentialId = 4,Name = "Sasha", Email = "sasha@gmail.com", Birthdate = new DateTime(2003,5,14) },
               new Client(){ CredentialId = 5,Name = "Dima", Email = "dima@gmail.com", Birthdate = new DateTime(2005,5,14) }
         });

        }
        public static void SeedFlights(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData(new Flight[]
        {
               new Flight(){ Number = 1, ArrivalCity= "Kyiv", DepartureCity= "Lviv", ArrivalTime = new DateTime(2026,3,10),
               DepartureTime =new DateTime(2026,3,10), AirplaneId = 1 },
                new Flight(){ Number = 2, ArrivalCity= "Kyiv", DepartureCity= "Praga", ArrivalTime = new DateTime(2026,3,10),
               DepartureTime =new DateTime(2026,3,10), AirplaneId = 1 },
                 new Flight(){ Number = 3, ArrivalCity= "Kyiv", DepartureCity= "Warshaw", ArrivalTime = new DateTime(2026,3,10),
               DepartureTime =new DateTime(2026,3,10), AirplaneId = 1 },
                  new Flight(){ Number = 4, ArrivalCity= "Kyiv", DepartureCity= "Kharkiv", ArrivalTime = new DateTime(2026,3,10),
               DepartureTime =new DateTime(2026,3,10), AirplaneId = 1 },

        });

        }
        public static void SeedClientFlights(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientFlight>().HasData(new ClientFlight[]
            {
                new ClientFlight(){ClientId =1, FlightId = 1},
                new ClientFlight(){ ClientId =2, FlightId = 1},
                new ClientFlight(){ ClientId =3, FlightId = 1},
                new ClientFlight(){ ClientId =4, FlightId = 2},
                new ClientFlight(){ ClientId =5, FlightId = 2},
            });

        }
    }
}
