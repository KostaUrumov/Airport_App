using Aiport_App_Structure.Data;
using System.ComponentModel.DataAnnotations;
using Aiport_App_Structure.Models;
using System.ComponentModel;

namespace Airport_App_Core.Models.CityModels
{
    public class AddNewCityModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(DataConstraints.City.NameMaxLength)]
        [MinLength(DataConstraints.City.NameMinLength)]
        [DisplayName("Name of the city")]
        public string Name { get; set; } = null!;

        [Required]
        public int CountryId { get; set; }
        
        public IEnumerable<Country> Countries { get; set; }= new List<Country>();
    }
}
