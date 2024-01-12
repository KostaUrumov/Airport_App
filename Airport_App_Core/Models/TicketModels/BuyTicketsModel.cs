using Aiport_App_Structure.Data;
using Aiport_App_Structure.Models;
using System.ComponentModel.DataAnnotations;

namespace Airport_App_Core.Models.TicketModels
{
    public class BuyTicketsModel
    {

        [Required]
        [RegularExpression("[A-Z]{1}[a-z]*[ ][A-Z]{1}[a-z]*")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(DataConstraints.Passenger.MinAge, DataConstraints.Passenger.MaxAge)]
        public int Age { get; set; }

        [Required]
        public int FlightId { get; set; }

        public ICollection<Flight> Flight { get; set; } = new List<Flight>();
    }
}
