using Aiport_App_Structure.Models;
using Airport_App_Core.Models.FlightModels;
using Airport_App_Core.Models.TicketModels;

namespace Airport_App_Core.Contracts
{
    public interface IFlightsService
    {
        Task<List<DisplayFlightModel>> TakeLastFive();
        Task<List<DisplayFlightModel>> SearchFlight(SearchFlightModel model);
        Task<List<DisplayFlightModel>> AllByCountryDeparture(int countryId);
        Task<List<DisplayFlightModel>> FilterByDepartureAirport(int airportId);
        Task<List<DisplayFlightModel>> AllFlights();
        Task AddNewFlight(AddNewFlightModel addFlight);
        Task<AddNewFlightModel> FindFlight(int id);
        Task SaveChangesAsync(AddNewFlightModel addFlight);
        public bool CheckAirports(AddNewFlightModel addFlight);
        public bool CheckDates(AddNewFlightModel addFlight);
        Task<Flight>GetFlight(int id);
        public bool CheckIfThereAreEnoughTickets(NumberTicketsModel numberPassengers);
        Task<List<Flight>> GetAllFlights();
        Task<DisplayFlightRevenewModel> CheckRevenewForFlight(int id);
        public List<BookFlightModel> MostBookedFlights();
    }
}
