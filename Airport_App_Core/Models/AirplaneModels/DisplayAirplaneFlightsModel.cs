using Airport_App_Core.Models.FlightModels;

namespace Airport_App_Core.Models.AirplaneModels
{
    public class DisplayAirplaneFlightsModel
    {
        public string Manufacturer { get; set; } = null!;
        public string Model { get; set; } = null!;

        public List<DisplayFlightModel> Flights { get; set; } = null!;

    }
}
