using Aiport_App_Structure.Models;
using Airport_App_Core.Models.Airplane;

namespace Airport_App_Core.Contracts
{
    public interface IAirplaneService
    {
        Task<IEnumerable<Aircraft>> AddAllAircrafts();
        Task<IEnumerable<Manufacturer>> GetAllCompanies();
        Task<List<DisplayAirplaneFlightsModel>> GetFlightsPerPlane(int id);
    }
}
