using Aiport_App_Structure.Models;

namespace Airport_App_Core.Contracts
{
    public interface IAirportService
    {
        Task<IEnumerable<Airport>> AddAllAirports();
    }
}
