using Aiport_App_Structure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System.Globalization;
namespace Airport_App_Structure.Data
{
    public class AirportDb : IdentityDbContext
    {
        public AirportDb(DbContextOptions<AirportDb> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AircraftFlights>()
                .HasKey(k => new { k.AircraftId, k.FlightId });

            builder.Entity<FlightPassenger>()
                .HasKey(k => new { k.PassengerId, k.FlightId });

            builder.Entity<Country>()
                .HasData(
                new Country { Id = 1, Continent = (Aiport_App_Structure.Models.Enums.Continent)1, Name = "Germany" },
                new Country { Id = 2, Continent = (Aiport_App_Structure.Models.Enums.Continent)2, Name = "Australia" },
                new Country { Id = 3, Continent = (Aiport_App_Structure.Models.Enums.Continent)3, Name = "USA" },
                new Country { Id = 4, Continent = (Aiport_App_Structure.Models.Enums.Continent)1, Name = "France" },
                new Country { Id = 5, Continent = (Aiport_App_Structure.Models.Enums.Continent)5, Name = "Egypt" },
                new Country { Id = 6, Continent = (Aiport_App_Structure.Models.Enums.Continent)6, Name = "Japan" }
                );

            builder.Entity<City>()
                .HasData(
                new City { Id = 1, Name = "Berlin", CountryId = 1 },
                new City { Id = 2, Name = "Sydney", CountryId = 2 },
                new City { Id = 3, Name = "Los Angeles", CountryId = 3 },
                new City { Id = 4, Name = "Paris", CountryId = 4 },
                new City { Id = 5, Name = "Cairo", CountryId = 5 },
                new City { Id = 6, Name = "Tokyo", CountryId = 6 }
                );

            builder.Entity<Airport>()
                .HasData(
                new Airport { Id = 1, Name = "Berlin International Airport", AirportCode = "BER", CityId = 1 },
                new Airport { Id = 2, Name = "Los Angeles International Airport", AirportCode = "LAX", CityId = 3 },
                new Airport { Id = 3, Name = "Paris-Orly Airport", AirportCode = "ORY", CityId = 4 },
                new Airport { Id = 4, Name = "Haneda Airport", AirportCode = "HND", CityId = 6 }
                );

            builder.Entity<Manufacturer>()
                .HasData(
                    new Manufacturer { Id = 1, CountryId = 3, Name = "Boeing" },
                    new Manufacturer { Id = 2, CountryId = 4, Name = "Airbus" }
                );

            builder.Entity<Aircraft>()
                .HasData(
                    new Aircraft { Id = 1, ManufacturerId = 1, Model = "737", Capacity = 257 },
                    new Aircraft { Id = 2, ManufacturerId = 2, Model = "A 330", Capacity = 164 }
                );

            builder.Entity<Flight>()
                .HasData(
                new Flight { Id = 1, FlightNumber = "BO78P0", DepartureAirportId = 1, ArrivalAirportId = 3, AircraftId = 2, TotalTickets = 164, Price = 87.21M, DepartureTime = new DateTime(2024, 1, 12, 8, 30, 52), ArivalTime = new DateTime(2024, 1, 12, 11, 3, 52) },
                new Flight { Id = 2, FlightNumber = "LAU781", DepartureAirportId = 1, ArrivalAirportId = 2, AircraftId = 1, TotalTickets = 251, Price = 887.21M, DepartureTime =  new DateTime(2024, 1, 12, 8, 30, 52), ArivalTime = new DateTime(2024, 1, 13, 4, 22, 52) }
                );

            builder.Entity<AircraftFlights>()
                .HasData(
                new AircraftFlights {FlightId = 1, AircraftId = 2 },
                new AircraftFlights { FlightId = 2, AircraftId = 1 }
                );



            base.OnModelCreating(builder);
        }

        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<FlightPassenger> FlightsPassengers { get; set; }
        public DbSet<AircraftFlights> AircraftsFlights { get; set; }

    }
}
