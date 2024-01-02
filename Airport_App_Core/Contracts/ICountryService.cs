using Aiport_App_Structure.Models;
using Airport_App_Core.Models.CountryModels;

namespace Airport_App_Core.Contracts
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> AddAllCountries();
        Task AddNewCountry(AddNewCountryModel model);
        Task<List<CountryViewModel>> GetAllCountries();
        Task<AddNewCountryModel> FindCountry(int id);
        Task SaveChangesAsync(AddNewCountryModel model);
        Task Delete(int id);
        public bool CheckIfExist(AddNewCountryModel model);
    }
}
