using Aiport_App_Structure.Models;
using Airport_App_Core.Contracts;
using Airport_App_Core.Models.Airplane;
using Airport_App_Core.Models.Flight;
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

        public async Task<IEnumerable<Aircraft>> AddAllAircrafts()
        {
            return await data.Aircrafts.OrderBy(x=>x.Model).ToListAsync();
        }

        public async Task<IEnumerable<Manufacturer>> GetAllCompanies()
        {
            return await data.Manufacturers.OrderBy(x=>x.Name).ToListAsync();
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
        
    }
}
