using Aiport_App_Structure.Models;
using Airport_App_Core.Models.CityModels;

namespace Airport_App_Core.Contracts
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllCities();
        bool CheckIfExist(AddNewCityModel city);
        Task AddNewCity(AddNewCityModel city);
        Task<List<DisplayCitiesModel>> AllCities();
        Task<AddNewCityModel> FindCity(int id);
        Task SaveChangesAsync(AddNewCityModel model);
    }
}
