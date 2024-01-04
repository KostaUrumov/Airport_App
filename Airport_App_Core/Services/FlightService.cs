using Aiport_App_Structure.Models;
using Airport_App_Core.Contracts;
using Airport_App_Core.Models.FlightModels;
using Airport_App_Core.Models.TicketModels;
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

        public async Task AddNewFlight(AddNewFlightModel addFlight)
        {
            int index = 0;
            for (var i = 0; i < addFlight.AirplaneModelId.ToString().Length; i++)
            {
                if (addFlight.AirplaneModelId.ToString()[i] == 32)
                {
                    index = i;
                    break;
                }
            }

            string manufacturerAirplane = addFlight.AirplaneModelId.ToString().Substring(0, index);
            string model = addFlight.AirplaneModelId.ToString().Substring(index+1);

            Aircraft aircraft = await data.Aircrafts.FirstAsync(x => x.Manufacturer.Name == manufacturerAirplane
            && x.Model == model);
            Flight newFlight = new Flight();
            newFlight.FlightNumber = addFlight.FlightNumber;
            newFlight.AircraftId = aircraft.Id;
            newFlight.ArrivalAirportId = addFlight.ArrivalAirportId;
            newFlight.DepartureAirportId = addFlight.DepartureAirportId;
            newFlight.DepartureTime = addFlight.DepartureTime;
            newFlight.ArivalTime = addFlight.ArivalTime;
            newFlight.TotalTickets = addFlight.TotalTickets;
            newFlight.Price = addFlight.Price;
            newFlight.AircraftsFlights.Add(new AircraftFlights()
            {
                AircraftId = aircraft.Id,
            });
            data.Flights.Add(newFlight);

            await data.SaveChangesAsync();

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
                    StartDate = x.DepartureTime.ToString("dd/MM/yyyy HH/mm"),
                    Id = x.Id,
                    AvailableTickets = x.TotalTickets

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
                    Id = f.Id,
                    AvailableTickets = f.TotalTickets

                })
                .ToListAsync();
            return flights;
        }

        public bool CheckAirports(AddNewFlightModel addFlight)
        {
            if (addFlight.DepartureAirportId == addFlight.ArrivalAirportId)
            {
                return false;
            }

            return true;

        }

        public bool CheckDates(AddNewFlightModel addFlight)
        {
            if (addFlight.ArivalTime<= addFlight.DepartureTime)
            {
                return false;
            }
            return true;

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
                    StartDate = x.DepartureTime.ToString("dd/MM/yyyy HH/mm"),
                    Id = x.Id,
                    AvailableTickets = x.TotalTickets

                })
                .ToListAsync();

            return flights;
        }

        public async Task<AddNewFlightModel> FindFlight(int id)
        {
            var result = await data.Flights.FirstAsync(x => x.Id == id);
            AddNewFlightModel flight = new AddNewFlightModel();
            flight.Price = result.Price;
            flight.FlightNumber = result.FlightNumber;
            flight.ArivalTime = result.ArivalTime;
            flight.DepartureTime = result.DepartureTime;
            flight.Id = result.Id;
            flight.TotalTickets = result.TotalTickets;
            return flight;
        }

        public async Task<Flight> GetFlight(int id)
        {
            return await data.Flights.FirstAsync(x => x.Id == id);
        }

        public async Task ReduceAvailableTickets(NumberTicketsModel numberPassengers)
        {
            var flight = await data.Flights.FirstAsync(f => f.Id == numberPassengers.FlightId);
            flight.TotalTickets -= numberPassengers.NumberOfTickets;
           await data.SaveChangesAsync();
        }

        public async Task SaveChangesAsync(AddNewFlightModel addFlight)
        {
            var flight = await data.Flights.FirstAsync(x => x.Id == addFlight.Id);
            int index = 0;
            for (var i = 0; i < addFlight.AirplaneModelId.ToString().Length; i++)
            {
                if (addFlight.AirplaneModelId.ToString()[i] == 32)
                {
                    index = i;
                    break;
                }
            }
            string manufacturerAirplane = addFlight.AirplaneModelId.ToString().Substring(0, index);
            string model = addFlight.AirplaneModelId.ToString().Substring(index + 1);

            Aircraft aircraft = await data.Aircrafts.FirstAsync(x => x.Manufacturer.Name == manufacturerAirplane
            && x.Model == model);
            flight.FlightNumber = addFlight.FlightNumber;
            flight.AircraftId = aircraft.Id;
            flight.ArrivalAirportId = addFlight.ArrivalAirportId;
            flight.DepartureAirportId = addFlight.DepartureAirportId;
            flight.DepartureTime = addFlight.DepartureTime;
            flight.ArivalTime = addFlight.ArivalTime;
            flight.TotalTickets = addFlight.TotalTickets;
            flight.Price = addFlight.Price;
            await data.SaveChangesAsync();

        }

        public async Task<List<DisplayFlightModel>> SearchFlight(SearchFlightModel model)
        {
            List<DisplayFlightModel> flight = await data
                .Flights
                .Where(x => x.DepartureAirport.City.Id == model.DepartureCityId
                           && x.ArrivalAirport.City.Id == model.ArrivalCityId
                           && x.DepartureTime.Date == model.DepartureDate)
                .Select(x => new DisplayFlightModel
                {
                    DepartureCity = x.DepartureAirport.City.Name,
                    DepartureAirport = x.DepartureAirport.Name,
                    DestinationAirport = x.ArrivalAirport.Name,
                    DestinationCity = x.ArrivalAirport.City.Name,
                    Price = x.Price.ToString(),
                    ArriveDate = x.ArivalTime.ToString("dd/MM/yyyy HH/mm"),
                    StartDate = x.DepartureTime.ToString("dd/MM/yyyy HH/mm"),
                    Id = x.Id,
                    AvailableTickets = x.TotalTickets

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
                    Id = x.Id,
                    AvailableTickets = x.TotalTickets
                })
                .ToListAsync();

            return lastFiveTickets;
        }
    }
}
