namespace Airport_App_Core.Models.UserModels
{
    public class MostTravelledPassengerModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public List<DestinationModel> Destinations { get; set; } = new List<DestinationModel>();
    }
}
