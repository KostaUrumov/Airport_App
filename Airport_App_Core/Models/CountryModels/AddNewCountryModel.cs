using Aiport_App_Structure.Data;
using System.ComponentModel.DataAnnotations;

namespace Airport_App_Core.Models.CountryModels
{
    public class AddNewCountryModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(DataConstraints.Country.NameMaxLength)]
        [MinLength(DataConstraints.Country.NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        public ICollection<string> Continents { get; set; } = new List<string>();

        public string ContinentId { get; set; } = null!;
    }
}
