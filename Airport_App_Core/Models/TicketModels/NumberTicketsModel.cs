using System.ComponentModel.DataAnnotations;

namespace Airport_App_Core.Models.TicketModels
{
    public class NumberTicketsModel
    {
        [Required]
        public int NumberOfTickets { get; set; }

        [Required]
        public int FlightId { get; set; }
    }
}
