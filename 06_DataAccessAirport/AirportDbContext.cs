using _05_EntityFramework.Helpers;
using _05_EntityFramework.Models;
using _06_DataAccessAirport.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_EntityFramework
{
    public class AirportDbContext: DbContext
    {
        //collections
        public DbSet<Client> Clients { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<ClientFlight> ClientFlights { get; set; }
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
            modelBuilder.Entity<Client>().HasKey(c => c.CredentialId);//set primary key

            //Relationship 
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Airplane)
                .WithMany(a => a.Flights)
                .HasForeignKey(f => f.AirplaneId);

            //set складений первинний ключ
            modelBuilder.Entity<ClientFlight>()
                .HasKey(cf => new { cf.ClientId,cf.FlightId});
            modelBuilder.Entity<Client>()
                .HasMany(c => c.ClientFlights)
                .WithOne(cf=>cf.Client);

            modelBuilder.Entity<Flight>()
               .HasMany(c => c.ClientFlights)
               .WithOne(cf => cf.Flight);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.Credential)
                .WithOne(c => c.Client)
                .HasForeignKey<Client>(c => c.CredentialId);//set foreign key

            //modelBuilder.Entity<Flight>()
            //    .HasMany(f => f.Clients)
            //    .WithMany(c => c.Flights);


            //Initialization
           modelBuilder.SeedAirplanes();
           modelBuilder.SeedCredentials();
           modelBuilder.SeedClients();
           modelBuilder.SeedFlights();         
           modelBuilder.SeedClientFlights();         
          

        }

    }
}
