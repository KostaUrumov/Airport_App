using Aiport_App_Structure.Models;
using Airport_App_Core.Models.TicketModels;

namespace Airport_App_Core.Contracts
{
    public interface IPassengerService
    {
        public List<Passenger> CreatePassengers(List<BuyTicketsModel> passengers);
        public bool IsPassengerAlreadyIn(Passenger passenger);
        Task AddToFlight(Passenger passenger, int flightId);
        public bool CheckIfPassengerIsInThisFlight(Passenger passenger, int flightId);
        Task CreateAndSaveNewPassengers(Passenger passenger, int flightId);

    }
}
