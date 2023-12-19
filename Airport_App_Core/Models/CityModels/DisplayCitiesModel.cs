using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Airport_App_Core.Models.CityModels
{
    public class DisplayCitiesModel
    {
        public string Country { get; set; } = null!;

        public string CityName { get; set; } = null!;

        public string Continent { get; set; } = null!;
    }
}
