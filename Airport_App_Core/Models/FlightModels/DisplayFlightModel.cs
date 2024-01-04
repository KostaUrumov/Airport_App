namespace Airport_App_Core.Models.FlightModels
{
    public class DisplayFlightModel
    {
        public int Id { get; set; }
        public string DepartureCity { get; set; } = null!;

        public string DepartureAirport { get; set; } = null!;
        public string DestinationCity { get; set; } = null!;

        public string DestinationAirport { get; set; } = null!;
        public string Price { get; set; } = null!;

        public string StartDate { get; set; } = null!;

        public string ArriveDate { get; set; } = null!;

        public int AvailableTickets { get; set; }
    }
}
