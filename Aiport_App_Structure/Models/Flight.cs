using Aiport_App_Structure.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aiport_App_Structure.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstraints.Flight.NumberLength)]
        public string FlightNumber { get; set; } = null!;

        [Required]
        public int DepartureAirportId { get; set; }

        [ForeignKey(nameof(DepartureAirportId))]
        public Airport DepartureAirport { get; set; } = null!;


        [Required]
        public int ArrivalAirportId { get; set; }

        [ForeignKey(nameof(ArrivalAirportId))]
        public Airport ArrivalAirport { get; set; } = null!;

        [Required]
        public int AircraftId { get; set; }

        [ForeignKey(nameof(AircraftId))]
        public Aircraft Aircraft { get; set; } = null!;

        [Required]
        public int TotalTickets { get; set; }

        [Required]
        [Precision(18,2)]
        public decimal Price { get; set; }

        public ICollection<AircraftFlights> AircraftsFlights { get; set; } = new List<AircraftFlights>();
    }
}
