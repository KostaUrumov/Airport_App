using Aiport_App_Structure.Data;
using Aiport_App_Structure.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Airport_App_Core.Models.FlightModels
{
    public class AddNewFlightModel
    {
      
        [Required]
        [MaxLength(DataConstraints.Flight.NumberLength)]
        public string FlightNumber { get; set; } = null!;

        [Required]
        public int DepartureAirportId { get; set; }

        public IEnumerable<Airport> DepartureAirport { get; set; } = new List<Airport>();


        [Required]
        public int ArrivalAirportId { get; set; }

       
        public IEnumerable<Airport> ArrivalAirport { get; set; } = new List<Airport>();

        [Required]
        public int AircraftId { get; set; }


        public IEnumerable<Aircraft> Aircraft { get; set; } = new List<Aircraft>();

        [Required]
        public int TotalTickets { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; } 

        [Required]
        public DateTime ArivalTime { get; set; } 

        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }
        
    }
}
