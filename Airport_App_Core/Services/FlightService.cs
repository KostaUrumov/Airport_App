using Aiport_App_Structure.Models;
using Airport_App_Core.Contracts;
using Airport_App_Core.Models.Flight;
using Airport_App_Structure.Data;
using Microsoft.EntityFrameworkCore;

namespace Airport_App_Core.Services
{
    public class FlightService : IFlightsService
    {
        private readonly AirportDb data;

        public FlightService(AirportDb _data)
        {
            data = _data;
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await data.Cities.OrderBy(x=>x.Name).ToListAsync();
        }

        public async Task<List<DisplayFlightModel>> SearchFlight(SearchFlightModel model)
        {
            List<DisplayFlightModel> flight = data
                .Flights
                .Where(x => x.DepartureAirport.City.Id == model.DepartureCityId
                           && x.ArrivalAirport.City.Id == model.ArrivalCityId)
                .Select(x => new DisplayFlightModel
                {
                    DepartureCity = x.DepartureAirport.City.Name,
                    DepartureAirport = x.DepartureAirport.Name,
                    DestinationAirport = x.ArrivalAirport.Name,
                    DestinationCity = x.ArrivalAirport.City.Name,
                    Price = x.Price.ToString()
                    
                })
                .ToList();

            return flight;
        }

        public async Task<List<DisplayFlightModel>> TakeLastFive()
        {
            List<DisplayFlightModel> lastFiveTickets = await data
                .Flights
                .OrderByDescending(x => x.Id)
                .Take(5)
                .Select(x => new DisplayFlightModel
                {
                    Price = x.Price.ToString(),
                    DepartureAirport = x.DepartureAirport.Name,
                    DepartureCity = x.DepartureAirport.City.Name,
                    DestinationAirport = x.ArrivalAirport.Name,
                    DestinationCity = x.ArrivalAirport.City.Name,
                })
                .ToListAsync();

            return lastFiveTickets;
        }
    }
}
