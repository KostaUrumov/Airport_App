using Aiport_App_Structure.Models;
using System.ComponentModel.DataAnnotations;

namespace Airport_App_Core.Models.TicketModels
{
    public class BuyTicketsModel
    {

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int Age { get; set; }

        [Required]
        public int FlightId { get; set; }

        public ICollection<Flight> Flight { get; set; } = new List<Flight>();
    }
}
