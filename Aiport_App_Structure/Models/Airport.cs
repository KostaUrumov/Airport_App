using Aiport_App_Structure.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aiport_App_Structure.Models
{
    public class Airport
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstraints.Airport.NameMinLength)]
        [MaxLength(DataConstraints.Airport.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DataConstraints.Airport.CodeLength)]
        public string AirportCode { get; set; } = null!;

        [Required]
        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public City City { get; set; } = null!;
        
    }
}
