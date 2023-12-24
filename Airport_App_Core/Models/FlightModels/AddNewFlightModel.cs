using Aiport_App_Structure.Data;
using Aiport_App_Structure.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Airport_App_Core.Models.FlightModels
{
    public class AddNewFlightModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(DataConstraints.Flight.NumberLength)]
        public string FlightNumber { get; set; } = null!;

        [Required]
        public int DepartureAirportId { get; set; }

        public IEnumerable<Airport> Departures { get; set; } = new List<Airport>();


        [Required]
        public int ArrivalAirportId { get; set; }

       
        public IEnumerable<Airport> ArrivalAirport { get; set; } = new List<Airport>();

        

        [Required]
        public int TotalTickets { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; } 

        [Required]
        public DateTime ArivalTime { get; set; } 

        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public ICollection<string> AirplaneModel { get; set; } = new List<string>();

        [Required]
        public string AirplaneModelId { get; set; } = null!;

    }
}
