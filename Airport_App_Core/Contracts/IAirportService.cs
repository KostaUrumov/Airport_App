using Aiport_App_Structure.Models;
using Airport_App_Core.Models.AirportModels;

namespace Airport_App_Core.Contracts
{
    public interface IAirportService
    {
        Task<IEnumerable<Airport>> AddAllAirports();
        public bool CheckIfExist(AddNewAirportModel port);
        Task AddNewAirport(AddNewAirportModel port);
        Task<List<DisplayAirportModel>> GetAllAirports();
        Task<AddNewAirportModel> FindAirport(int id);
        Task SaveChangesAsync(AddNewAirportModel port);
    }
}
