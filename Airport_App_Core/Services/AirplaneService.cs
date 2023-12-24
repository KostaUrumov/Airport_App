using Aiport_App_Structure.Models;
using Airport_App_Core.Contracts;
using Airport_App_Core.Models.AirplaneModels;
using Airport_App_Core.Models.FlightModels;
using Airport_App_Structure.Data;
using Microsoft.EntityFrameworkCore;

namespace Airport_App_Core.Services
{
    public class AirplaneService : IAirplaneService
    {
        private readonly AirportDb data;

        public AirplaneService(AirportDb _data)
        {
            data = _data;
        }

        public async Task AddAircraft(AddNewPlane plane)
        {
            Aircraft aircraft = new Aircraft()
            {
                Capacity = plane.Capacity,
                Model = plane.Model,
                ManufacturerId = plane.ManufacturerId
            };

            data.AddRange(aircraft);
            await data.SaveChangesAsync();
        }

        public async Task<IEnumerable<Aircraft>> AddAllAircrafts()
        {
            return await data.Aircrafts.OrderBy(x=>x.Model).ToListAsync();
        }

        public async Task<List<string>> AddPlanes()
        {
            List<string> result = await data
                .Aircrafts
                .Select(a => a.Manufacturer.Name.ToString()+ " " + a.Model.ToString())
                .ToListAsync();
            return result;
        }

        public async Task DeleteAsync(int id)
        {
            var find = await data.Aircrafts.FirstAsync(x => x.Id == id);
            data.Remove(find);
            await data.SaveChangesAsync();        }

        public async Task<AddNewPlane> FindJet(int id)
        {
            AddNewPlane[] result = await data
                .Aircrafts
                .Where(a => a.Id == id)
                .Select(a => new AddNewPlane
                {
                    Capacity = a.Capacity,
                    ManufacturerId = a.ManufacturerId,
                    Model = a.Model,
                    Id = a.Id
                })
                .ToArrayAsync();

            return result[0];
        }

        public async Task<List<DisplayAirplaneModel>> GetAllPLanes()
        {
            List<DisplayAirplaneModel> result = await data
                .Aircrafts
                .Select(x=> new DisplayAirplaneModel
                {
                    Manufacturer = x.Manufacturer.Name,
                    Model = x.Model,
                    Seats = x.Capacity,
                    Id = x.Id
                })
                .OrderBy(p=> p.Manufacturer)
                .ThenByDescending(p=> p.Seats)
                .ToListAsync();
            return result;
        }

        public async Task<List<DisplayAirplaneFlightsModel>> GetFlightsPerPlane(int id)
        {
            List<DisplayAirplaneFlightsModel> result = await data
                .Aircrafts
                .Where(x => x.Id == id)
                .Select(x => new DisplayAirplaneFlightsModel
                {
                    Manufacturer = x.Manufacturer.Name,
                    Model = x.Model,
                    Flights = (List<DisplayFlightModel>)x.AircraftsFlights.Where(f=>f.AircraftId == id)
                    .Select(m=> new DisplayFlightModel
                    {
                        DepartureAirport = m.Flight.DepartureAirport.Name,
                        DepartureCity = m.Flight.DepartureAirport.City.Name,
                        DestinationAirport = m.Flight.ArrivalAirport.Name,
                        DestinationCity = m.Flight.DepartureAirport.City.Name,
                        Price = m.Flight.Price.ToString(),
                        ArriveDate = m.Flight.ArivalTime.ToString("dd/MM/yyyy HH/mm"),
                        StartDate = m.Flight.DepartureTime.ToString("dd/MM/yyyy HH/mm")
                    })
                    
                })
                .ToListAsync();

                return result;
                
        }

        public async Task SaveChangesAsync(AddNewPlane plane)
        {
            var oldPlane = data.Aircrafts.First(x => x.Id == plane.Id);
            oldPlane.Capacity = plane.Capacity;
            oldPlane.ManufacturerId = plane.ManufacturerId;
            oldPlane.Model = plane.Model;

            await data.SaveChangesAsync();
        }
    }
}
