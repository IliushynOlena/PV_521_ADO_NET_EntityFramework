using _05_EntityFramework.Models;
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
        public static void SeedClients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(new Client[]
         {
               new Client(){ Id = 1,Name = "Vova", Email = "vova@gmail.com", Birthdate = new DateTime(1995,5,14) },
               new Client(){ Id = 2,Name = "Ira", Email = "ira@gmail.com", Birthdate = new DateTime(2000,5,14) },
               new Client(){ Id = 3,Name = "Nikita", Email = "nikita@gmail.com", Birthdate = new DateTime(2001,5,14) },
               new Client(){ Id = 4,Name = "Sasha", Email = "sasha@gmail.com", Birthdate = new DateTime(2003,5,14) },
               new Client(){ Id = 5,Name = "Dima", Email = "dima@gmail.com", Birthdate = new DateTime(2005,5,14) }
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
    }
}
