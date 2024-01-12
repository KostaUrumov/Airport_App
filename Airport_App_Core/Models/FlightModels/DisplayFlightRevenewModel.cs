namespace Airport_App_Core.Models.FlightModels
{
    public class DisplayFlightRevenewModel
    {
        public string FlightNumber { get; set; } = null!;
        public string DepartureCity { get; set; } = null!;
        public string DepartureAirport { get; set; } = null!;

        public string ArrivalAirport { get; set; } = null!;
        public string ArrivalCity { get; set; } = null!;
        public int TotalTicketsSold { get; set; }
        public string Money { get; set; } = null!;
    }
}
