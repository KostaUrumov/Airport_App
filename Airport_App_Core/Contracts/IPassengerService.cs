using Airport_App_Core.Models.TicketModels;

namespace Airport_App_Core.Contracts
{
    public interface IPassengerService
    {
        Task AddPassengersToFlight(List<BuyTicketsModel> passengers);
    }
}
