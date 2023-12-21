namespace Airport_App_Core.Models.AirplaneModels
{
    public class DisplayAirplaneModel
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public int Seats { get; set; }
    }
}
