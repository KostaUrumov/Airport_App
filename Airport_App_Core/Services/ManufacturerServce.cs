using Aiport_App_Structure.Models;
using Airport_App_Core.Contracts;
using Airport_App_Core.Models.CompanyModels;
using Airport_App_Structure.Data;
using Microsoft.EntityFrameworkCore;

namespace Airport_App_Core.Services
{
    public class ManufacturerServce : IManufacturerServce
    {
        private readonly AirportDb data;

        public ManufacturerServce(AirportDb _data)
        {
            data = _data;
        }

        public async Task AddNewManufacturer(AddNewCompanyModel company)
        {
            Manufacturer manu = new Manufacturer()
            {
                CountryId = company.CountryId,
                Name = company.Name
            };

            data.Add(manu);
            await data.SaveChangesAsync();
        }

        public bool CheckIfExist(AddNewCompanyModel company)
        {
            var result = data.Manufacturers
                .FirstOrDefault(x => x.Name == company.Name && x.CountryId == company.CountryId);

            if (result == null)
            {
                return false;
            }

            return true;
             
        }

        public async Task<AddNewCompanyModel> FindCompany(int id)
        {
            AddNewCompanyModel model = new AddNewCompanyModel();
            var findModel = await data.Manufacturers.FirstAsync(x => x.Id == id);
            model.CountryId = findModel.CountryId;
            model.Name = findModel.Name;
            model.Id = findModel.Id;

            return model;
        }

        public async Task<IEnumerable<Manufacturer>> GetAllCompanies()
        {
            return await data.Manufacturers.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<List<DisplayCompaniesModel>> ReturnAllManufacturers()
        {
            List<DisplayCompaniesModel> result = await data
                .Manufacturers
                .Select(m => new DisplayCompaniesModel
                {
                    Origin = m.Country.Name,
                    Name = m.Name,
                    Id = m.Id
                })
                .OrderBy(x => x.Name)
                .ToListAsync();

            return result;
        }

        public async Task SaveChangesAsync(AddNewCompanyModel company)
        {
            var oldCompany = await data.Manufacturers.FirstAsync(x => x.Id == company.Id);
            oldCompany.CountryId = company.CountryId;
            oldCompany.Name = company.Name;

            await data.SaveChangesAsync();
        }
    }
}
