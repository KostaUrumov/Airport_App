using Aiport_App_Structure.Models;
using Airport_App_Core.Contracts;
using Airport_App_Core.Models.AirportModels;
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

        public async Task AddNewAirport(AddNewAirportModel port)
        {
            Airport airport = new Airport()
            {
                Name = port.Name,
                AirportCode = port.AirportCode,
                CityId = port.CityId,
            };
            data.Airports.Add(airport);
            await data.SaveChangesAsync();
        }

        public bool CheckIfExist(AddNewAirportModel port)
        {
            var find =  data.Airports
                 .FirstOrDefault(x => x.Name == port.Name);
            if (find != null)
            {
                return true;
            }

            return false;
        }

        public async Task<AddNewAirportModel> FindAirport(int id)
        {
            AddNewAirportModel[] list = await data
                .Airports
                .Where(p => p.Id == id)
                .Select(a => new AddNewAirportModel
                {
                    AirportCode = a.AirportCode,
                    Name = a.Name,
                    Id = a.Id
                })
                .ToArrayAsync();
            return list[0];
        }

        public async Task<List<DisplayAirportModel>> GetAllAirports()
        {
            List<DisplayAirportModel> ports = await data
                .Airports
                .Select(a => new DisplayAirportModel
                {
                    Name = a.Name,
                    City = a.City.Name,
                    Country = a.City.Country.Name,
                    Code = a.AirportCode,
                    Id = a.Id
                })
                .OrderBy(x=> x.Country)
                .ThenBy(x=>x.City)
                .ToListAsync();

            return ports;
        }

        public async Task SaveChangesAsync(AddNewAirportModel port)
        {
            var airport = data.Airports.First(x => x.Id == port.Id);
            airport.CityId = port.CityId;
            airport.AirportCode = port.AirportCode;
            airport.Name = port.Name;
            await data.SaveChangesAsync();
        }
    }
}
