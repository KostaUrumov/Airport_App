using Aiport_App_Structure.Data;
using System.ComponentModel.DataAnnotations;
using Aiport_App_Structure.Models;
using System.ComponentModel;

namespace Airport_App_Core.Models.CompanyModels
{
    public class AddNewCompanyModel
    {
        [Required]
        [MaxLength(DataConstraints.Manufacturer.NameMaxLength)]
        [MinLength(DataConstraints.Manufacturer.NameMinLength)]
        [DisplayName("Company name")]
        public string Name { get; set; } = null!;

        [Required]
        public int CountryId { get; set; }

        public IEnumerable<Country> Countries { get; set; } = new List<Country>();
    }
}
