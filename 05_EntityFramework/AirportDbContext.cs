using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_EntityFramework
{
    internal class AirportDbContext: DbContext
    {
        //collections
        public DbSet<Client> Clients { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public AirportDbContext()
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        }

        //connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Airplane_PV_521_v2;Integrated Security=True;Connect Timeout=5;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        //work with database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Validation data - Fluent API
            modelBuilder.Entity<Airplane>()
                .Property(a => a.Model)
                .IsRequired() // [Required]
                .HasMaxLength(100);//[MaxLength(100)]

            modelBuilder.Entity<Client>().ToTable("Passangers");
            modelBuilder.Entity<Client>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("FirstName");
            modelBuilder.Entity<Client>()
              .Property(c => c.Email)
              .IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Flight>().HasKey(f=>f.Number);
            modelBuilder.Entity<Flight>()
                .Property(f=>f.ArrivalCity)
                .HasMaxLength(100);

            modelBuilder.Entity<Flight>()
                .Property(f=>f.DepartureCity)
                .HasMaxLength(100);

            //Relationship 
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Airplane)
                .WithMany(a => a.Flights)
                .HasForeignKey(f => f.AirplaneId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Flights)
                .WithMany(f => f.Clients);


            //Initialization
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
            {
                new Airplane(){ Id = 1, Model = "AN747"},
                new Airplane(){ Id = 2, Model = "AN746"},
                new Airplane(){ Id = 3, Model = "AN746"},
                new Airplane(){ Id = 4, Model = "AN744"},
                new Airplane(){ Id = 5, Model = "AN743"},
            });
            modelBuilder.Entity<Client>().HasData(new Client[]
           {
               new Client(){ Id = 1,Name = "Vova", Email = "vova@gmail.com", Birthdate = new DateTime(1995,5,14) },
               new Client(){ Id = 2,Name = "Ira", Email = "ira@gmail.com", Birthdate = new DateTime(2000,5,14) },
               new Client(){ Id = 3,Name = "Nikita", Email = "nikita@gmail.com", Birthdate = new DateTime(2001,5,14) },
               new Client(){ Id = 4,Name = "Sasha", Email = "sasha@gmail.com", Birthdate = new DateTime(2003,5,14) },
               new Client(){ Id = 5,Name = "Dima", Email = "dima@gmail.com", Birthdate = new DateTime(2005,5,14) }
           });
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
