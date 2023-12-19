using Aiport_App_Structure.Models;
using Airport_App_Core.Contracts;
using Airport_App_Core.Models.CityModels;
using Airport_App_Structure.Data;
using Microsoft.EntityFrameworkCore;

namespace Airport_App_Core.Services
{
    public class CityService : ICityService
    {
        private readonly AirportDb data;

        public CityService(AirportDb _data)
        {
            data = _data;
        }

        public async Task AddNewCity(AddNewCityModel city)
        {
            City newcity = new City()
            {
                Name = city.Name,
                CountryId = city.CountryId,
            };
            data.Add(newcity);
            await data.SaveChangesAsync();
        }

        public async Task<List<DisplayCitiesModel>> AllCities()
        {
            List<DisplayCitiesModel> result = await data
                .Cities
                .Select(x => new DisplayCitiesModel
                {
                    CityName = x.Name,
                    Country = x.Country.Name,
                    Continent = x.Country.Continent.ToString()
                })
                .OrderBy(s => s.Country)
                .ThenBy(s => s.CityName)
                .ToListAsync();

            return result;
            
        }

        public bool CheckIfExist(AddNewCityModel city)
        {
            var find = data.Cities
                .Where(x=> x.Name == city.Name
                    && x.CountryId == city.CountryId);
            if (find != null)
            {
                return true;
            }

            return false;
                
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await data.Cities.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
