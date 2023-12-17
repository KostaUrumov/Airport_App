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
