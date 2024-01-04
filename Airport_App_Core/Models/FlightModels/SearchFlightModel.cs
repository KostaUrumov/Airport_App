using Aiport_App_Structure.Models;
using System.ComponentModel.DataAnnotations;

namespace Airport_App_Core.Models.FlightModels
{
    public class SearchFlightModel
    {
        [Required]
        public int DepartureCityId { get; set; }
        public IEnumerable<City> DepartureCity { get; set; } = new List<City>();

        [Required]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        [Required]
        public int ArrivalCityId { get; set; }
        public IEnumerable<City> ArrivalCity { get; set; } = new List<City>();
    }
}
