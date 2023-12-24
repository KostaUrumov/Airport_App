using Airport_App_Core.Contracts;
using Airport_App_Core.Models.FlightModels;
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

        public Task AddNewFlight(AddNewFlightModel addFlight)
        {
           
        }

        public async Task<List<DisplayFlightModel>> AllByCountryDeparture(int countryId)
        {
            List<DisplayFlightModel> flights = await data
                .Flights
                .Where(x => x.DepartureAirport.City.Country.Id == countryId)
                .Select(x => new DisplayFlightModel
                {
                    DepartureCity = x.DepartureAirport.City.Name,
                    DepartureAirport = x.DepartureAirport.Name,
                    DestinationAirport = x.ArrivalAirport.Name,
                    DestinationCity = x.ArrivalAirport.City.Name,
                    Price = x.Price.ToString(),
                    ArriveDate = x.ArivalTime.ToString("dd/MM/yyyy HH/mm"),
                    StartDate = x.DepartureTime.ToString("dd/MM/yyyy HH/mm")

                })
                .ToListAsync();
            return flights;
        }

        public async Task<List<DisplayFlightModel>> AllFlights()
        {
            List<DisplayFlightModel> flights = await data
                .Flights
                .Select(f=> new DisplayFlightModel
                {
                    DepartureCity = f.DepartureAirport.City.Name,
                    DepartureAirport = f.DepartureAirport.Name,
                    DestinationAirport = f.ArrivalAirport.Name,
                    DestinationCity = f.ArrivalAirport.City.Name,
                    Price = f.Price.ToString(),
                    ArriveDate = f.ArivalTime.ToString("dd/MM/yyyy HH/mm"),
                    StartDate = f.DepartureTime.ToString("dd/MM/yyyy HH/mm"),
                    Id = f.Id

                })
                .ToListAsync();
            return flights;
        }

        public async Task<List<DisplayFlightModel>> FilterByDepartureAirport(int airportId)
        {
            List<DisplayFlightModel> flights = await data
                .Flights
                .Where(x=> x.DepartureAirportId == airportId)
                .Select(x => new DisplayFlightModel
                {
                    DepartureCity = x.DepartureAirport.City.Name,
                    DepartureAirport = x.DepartureAirport.Name,
                    DestinationAirport = x.ArrivalAirport.Name,
                    DestinationCity = x.ArrivalAirport.City.Name,
                    Price = x.Price.ToString(),
                    ArriveDate = x.ArivalTime.ToString("dd/MM/yyyy HH/mm"),
                    StartDate = x.DepartureTime.ToString("dd/MM/yyyy HH/mm")

                })
                .ToListAsync();

            return flights;
        }

        public async Task<List<DisplayFlightModel>> SearchFlight(SearchFlightModel model)
        {
            List<DisplayFlightModel> flight = await data
                .Flights
                .Where(x => x.DepartureAirport.City.Id == model.DepartureCityId
                           && x.ArrivalAirport.City.Id == model.ArrivalCityId)
                .Select(x => new DisplayFlightModel
                {
                    DepartureCity = x.DepartureAirport.City.Name,
                    DepartureAirport = x.DepartureAirport.Name,
                    DestinationAirport = x.ArrivalAirport.Name,
                    DestinationCity = x.ArrivalAirport.City.Name,
                    Price = x.Price.ToString(),
                    ArriveDate = x.ArivalTime.ToString("dd/MM/yyyy HH/mm"),
                    StartDate = x.DepartureTime.ToString("dd/MM/yyyy HH/mm")

                })
                .ToListAsync();

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
