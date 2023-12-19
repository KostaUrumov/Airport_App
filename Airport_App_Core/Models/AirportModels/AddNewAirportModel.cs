using Aiport_App_Structure.Data;
using System.ComponentModel.DataAnnotations;
using Aiport_App_Structure.Models;
using System.ComponentModel;

namespace Airport_App_Core.Models.AirportModels
{
    public class AddNewAirportModel
    {
        [Required]
        [MinLength(DataConstraints.Airport.NameMinLength)]
        [MaxLength(DataConstraints.Airport.NameMaxLength)]
        [DisplayName("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DataConstraints.Airport.CodeLength)]
        [DisplayName("Code")]
        public string AirportCode { get; set; } = null!;

        [Required]
        public int CityId { get; set; }
        public IEnumerable<City> Cityies { get; set; } = new List<City>();

    }
}
