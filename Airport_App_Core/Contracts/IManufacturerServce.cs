using Aiport_App_Structure.Models;
using Airport_App_Core.Models.CompanyModels;

namespace Airport_App_Core.Contracts
{
    public interface IManufacturerServce
    {
        Task<IEnumerable<Manufacturer>> GetAllCompanies();
        public bool CheckIfExist(AddNewCompanyModel company);
        Task AddNewManufacturer(AddNewCompanyModel company);
        Task<List<DisplayCompaniesModel>> ReturnAllManufacturers();
        Task<AddNewCompanyModel> FindCompany(int id);
        Task SaveChangesAsync(AddNewCompanyModel company);
        Task Delete(int id);
    }
}
