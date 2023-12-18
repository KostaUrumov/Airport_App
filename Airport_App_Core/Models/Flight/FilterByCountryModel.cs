using Aiport_App_Structure.Models;

namespace Airport_App_Core.Models.Flight
{
    public class FilterByCountryModel
    {
        public int CountryId { get; set; }
        public IEnumerable<Country> Countries { get; set; } = new List<Country>();
    }
}
