using Airport_App_Core.Models.Flight;

namespace Airport_App_Core.Contracts
{
    public interface IFlightsService
    {
        Task<List<DisplayFlightModel>> TakeLastFive();
    }
}
