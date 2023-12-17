namespace Airport_App_Core.Models.Flight
{
    public class DisplayFlightModel
    {
        public string DepartureCity { get; set; } = null!;

        public string DepartureAirport { get; set; } = null!;
        public string DestinationCity { get; set; } = null!;

        public string DestinationAirport { get; set; } = null!;
        public string Price { get; set; } = null!;

    }
}
