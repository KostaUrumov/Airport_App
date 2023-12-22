using Aiport_App_Structure.Models;
using Airport_App_Core.Contracts;
using Airport_App_Core.Models.CityModels;
using Airport_App_Structure.Data;
using Microsoft.AspNetCore.Mvc;
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
                    Continent = x.Country.Continent.ToString(),
                    Id = x.Id
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

        public async Task Delete(int id)
        {
            var findCity = await data.Cities.FirstAsync(c => c.Id == id);
            var airport = await data.Airports.FirstOrDefaultAsync(x => x.CityId == findCity.Id);
            if (airport != null)
            {
                return;
            }

            data.Remove(findCity);
            await data.SaveChangesAsync();
        }
       

        public async Task<AddNewCityModel> FindCity(int id)
        {
            List<AddNewCityModel> res = await data
                .Cities
                .Where(c=>c.Id == id)
                .Select(a=> new AddNewCityModel
                {
                    Name = a.Name,
                    CountryId = a.CountryId,
                    Id = a.Id
                })
                .ToListAsync();
            return res[0];
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await data.Cities.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task SaveChangesAsync(AddNewCityModel model)
        {
            var oldCity = await data.Cities.FirstAsync(c => c.Id == model.Id);
            oldCity.Name = model.Name;
            oldCity.CountryId = model.CountryId;

            await data.SaveChangesAsync();
        }
    }
}
