using Aiport_App_Structure.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aiport_App_Structure.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstraints.City.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; } = null!;
    }
}
