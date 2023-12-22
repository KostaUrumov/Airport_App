using Aiport_App_Structure.Models;
using Airport_App_Core.Contracts;
using Airport_App_Core.Models.CountryModels;
using Airport_App_Structure.Data;
using Microsoft.EntityFrameworkCore;

namespace Airport_App_Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly AirportDb data;

        public CountryService(AirportDb _data)
        {
            data = _data;
        }

        public async Task<IEnumerable<Country>> AddAllCountries()
        {
            return await data.Countries.OrderBy(c=> c.Name).ToListAsync();
        }

        public async Task AddNewCountry(AddNewCountryModel model)
        {
            Country newCountry = new Country();
            newCountry.Name = model.Name;
            if (model.ContinentId == "Europe")
            {
                newCountry.Continent = Aiport_App_Structure.Models.Enums.Continent.Europe;
            }
            if (model.ContinentId == "Asia")
            {
                newCountry.Continent = Aiport_App_Structure.Models.Enums.Continent.Asia;
            }
            if (model.ContinentId == "North_America")
            {
                newCountry.Continent = Aiport_App_Structure.Models.Enums.Continent.North_America;
            }
            if (model.ContinentId == "South_America")
            {
                newCountry.Continent = Aiport_App_Structure.Models.Enums.Continent.South_America;
            }

            if (model.ContinentId == "Australia")
            {
                newCountry.Continent = Aiport_App_Structure.Models.Enums.Continent.Australia;
            }

            if (model.ContinentId == "Africa")
            {
                newCountry.Continent = Aiport_App_Structure.Models.Enums.Continent.Africa;
            }

            data.Add(newCountry);
            await data.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var result = await data.Countries.FirstAsync(c => c.Id == id);
            var company = await data.Manufacturers.FirstOrDefaultAsync(c => c.CountryId == id);
            if (company != null)
            {
                return;
            }
            data.Remove(result);
            await data.SaveChangesAsync();
        }

        public async Task<AddNewCountryModel> FindCountry(int id)
        {
            List<AddNewCountryModel> model = await data
                .Countries
                .Where(c => c.Id == id)
                .Select(c => new AddNewCountryModel
                {
                    Name = c.Name,
                    Id = c.Id

                })
                .ToListAsync();
            return model[0];
        }

        public async Task<List<CountryViewModel>> GetAllCountries()
        {
            List<CountryViewModel> countries = await data
                .Countries
                .Select(c => new CountryViewModel
                {
                    Name = c.Name,
                    Continent = c.Continent.ToString(),
                    Id = c.Id
                })
                .OrderBy(x => x.Name)
                .ToListAsync();
            return countries;
        }

        public async Task SaveChangesAsync(AddNewCountryModel model)
        {
            var findCountry = await  data.Countries.FirstAsync(x => x.Id == model.Id);
            findCountry.Name = model.Name;
            if (model.ContinentId == "Europe")
            {
                findCountry.Continent = Aiport_App_Structure.Models.Enums.Continent.Europe;
            }
            if (model.ContinentId == "Asia")
            {
                findCountry.Continent = Aiport_App_Structure.Models.Enums.Continent.Asia;
            }
            if (model.ContinentId == "North_America")
            {
                findCountry.Continent = Aiport_App_Structure.Models.Enums.Continent.North_America;
            }
            if (model.ContinentId == "South_America")
            {
                findCountry.Continent = Aiport_App_Structure.Models.Enums.Continent.South_America;
            }

            if (model.ContinentId == "Australia")
            {
                findCountry.Continent = Aiport_App_Structure.Models.Enums.Continent.Australia;
            }

            if (model.ContinentId == "Africa")
            {
                findCountry.Continent = Aiport_App_Structure.Models.Enums.Continent.Africa;
            }

            await data.SaveChangesAsync();
        }

        
    }
}
