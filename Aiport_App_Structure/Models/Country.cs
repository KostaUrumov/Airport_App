using Aiport_App_Structure.Data;
using Aiport_App_Structure.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Aiport_App_Structure.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstraints.Country.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public Continent Continent { get; set; }

    }
}
