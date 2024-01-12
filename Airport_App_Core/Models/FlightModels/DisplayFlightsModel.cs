using Aiport_App_Structure.Models;

namespace Airport_App_Core.Models.FlightModels
{
    public class DisplayFlightsModel
    {
        public ICollection<Flight> AllFlights { get; set; } = new List<Flight>();

        public int FlightId { get; set; }
    }
}
