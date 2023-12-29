using Aiport_App_Structure.Models;
using Airport_App_Core.Models.TicketModels;

namespace Airport_App_Core.Contracts
{
    public interface IPassengerService
    {
        public List<Passenger> AddPassengersToFlight(List<BuyTicketsModel> passengers);
        Task ReturnNewPassengers(List<Passenger> passengers, int id);
    }
}
