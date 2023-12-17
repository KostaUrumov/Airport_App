using Aiport_App_Structure.Data;
using System.ComponentModel.DataAnnotations;

namespace Aiport_App_Structure.Models
{
    public class Passenger
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstraints.Passenger.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(DataConstraints.Passenger.MinAge, DataConstraints.Passenger.MaxAge)]
        public int Age { get; set; }
    }
}
