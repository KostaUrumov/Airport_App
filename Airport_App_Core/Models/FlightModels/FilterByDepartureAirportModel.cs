using Aiport_App_Structure.Models;

namespace Airport_App_Core.Models.FlightModels
{
    public class FilterByDepartureAirportModel
    {
        public int AirportId { get; set; }

        public IEnumerable<Airport> Airports { get; set; } = new List<Airport>();
    }
}
