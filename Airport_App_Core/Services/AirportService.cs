using Aiport_App_Structure.Models;
using Airport_App_Core.Contracts;
using Airport_App_Structure.Data;
using Microsoft.EntityFrameworkCore;

namespace Airport_App_Core.Services
{
    public class AirportService : IAirportService
    {
        private readonly AirportDb data;

        public AirportService(AirportDb _data)
        {
            data = _data;
        }

        public async Task<IEnumerable<Airport>> AddAllAirports()
        {
            return await data.Airports.OrderBy(x=>x.Name).ToListAsync();
        }
    }
}
