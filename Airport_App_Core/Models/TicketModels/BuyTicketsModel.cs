using System.ComponentModel.DataAnnotations;

namespace Airport_App_Core.Models.TicketModels
{
    public class BuyTicketsModel
    {

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int Age { get; set; }

        public int FlightId { get; set; }
    }
}
