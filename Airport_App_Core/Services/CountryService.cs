using Aiport_App_Structure.Models;
using Airport_App_Core.Contracts;
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
    }
}
