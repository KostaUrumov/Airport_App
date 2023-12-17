using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aiport_App_Structure.Models
{
    public class FlightPassenger
    {
        [Required]
        public int PassengerId { get; set; }

        [ForeignKey(nameof(PassengerId))]
        public Passenger Passenger { get; set; } = null!;

        [Required]
        public int FlightId { get; set; }

        [ForeignKey(nameof(FlightId))]
        public Flight Flight { get; set; } = null!;
    }
}
