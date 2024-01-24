namespace Airport_App_Core.Models.FlightModels
{
    public class BookFlightModel
    {
        public string DepartureCity { get; set; } = null!;
        public string ArrivalCity { get; set; } = null!;
        public double Price { get; set; }
    }
}
